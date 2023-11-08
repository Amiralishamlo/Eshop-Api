using Common.Application;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.ChargeWallet;

public class ChargeUserWalletCommand:IBaseCommand
{
    public ChargeUserWalletCommand(long userId, int price, string description, bool isFinally, WalletType type)
    {
        UserId = userId;
        Price = price;
        Description = description;
        IsFinally = isFinally;
        Type = type;
    }
    public long UserId { get; private set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public WalletType Type { get; private set; }
}