using Common.Query.Filter;
using Shop.Domain.OrderAgg;

namespace Shop.Query.Orders.DTOs;

public class OrderFilterParams : BaseFilterParam
{ 
    public long? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public OrderStatus? Status { get; set; }

}