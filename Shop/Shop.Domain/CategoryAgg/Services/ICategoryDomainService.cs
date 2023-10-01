namespace Shop.Domain.CategoryAgg.Services
{
    public interface ICategoryDomainService
    {
        public bool IsSlugExist(string slug);
    }
}
