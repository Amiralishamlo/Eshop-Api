namespace Shop.Domain.ProductAgg.Services
{
    public interface IProductDomainService
    {
        bool SlugIsExist(string slug);
    }
}
