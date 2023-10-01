using Common.Domain;

namespace Shop.Domain.UserAgg
{
    public class UserRole : AggregateRoot
    {
        public UserRole(long roleId)
        {
            RoleId = roleId;
        }

        public long UserId { get; internal set; }
        public long RoleId { get; private set; }
    }
}
