﻿using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.ValueObjects;

namespace Shop.Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        private Order()
        {

        }

        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pennding;
            Items = new List<OrderItem>();
        }

        public long UserId { get; private set; }

        public OrderStatus Status { get; private set; }

        public OrderDiscount? Discount { get; private set; }

        public OrderAddress? Address { get; private set; }

        public ShippingMethod? ShippingMethod { get; private set; }

        public List<OrderItem> Items { get; private set; }

        public int ItemCount => Items.Count;

        public DateTime? LastUpdate { get; set; }

        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(f => f.TotalPrice);

                if (ShippingMethod != null)
                    totalPrice += ShippingMethod.ShippingCost;

                if (Discount != null)
                    totalPrice -= Discount.DiscountAmount;

                return totalPrice;
            }
        }


        public void AddItem(OrderItem Item)
        {
            ChangeOrderGuard();
            var orderItems = Items.FirstOrDefault(x => x.InventoryId == Item.InventoryId);
            if (orderItems != null)
            {
                orderItems.ChangeCount(Item.Count + orderItems.Count);
                return;
            }
            Items.Add(Item);
        }

        public void RemoveItem(long itemId)
        {
            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(x => x.Id == itemId);
            if (currentItem != null)
                Items.Remove(currentItem);
        }

        public void IncreaseItemCount(long itemId, int count)
        {
            ChangeOrderGuard();

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();

            currentItem.IncreaseCount(count);
        }

        public void DecreaseItemCount(long itemId, int count)
        {
            ChangeOrderGuard();

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();

            currentItem.DecreaseCount(count);
        }
        public void ChangeCountItem(long itemId, int newCount)
        {
            ChangeOrderGuard();
            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();

            currentItem.ChangeCount(newCount);
        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Checkout(OrderAddress orderAddress)
        {
            ChangeOrderGuard();
            Address = orderAddress;
        }

        public void ChangeOrderGuard()
        {
            if (Status != OrderStatus.Pennding)
                throw new InvalidDomainDataException("امکان ویرایش این سفارش وجود ندارد");
        }
    }

}
