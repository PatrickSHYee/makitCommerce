namespace makit.makitCommerce.Services
{
    using makit.makitCommerce.Domain.Models;
    
    public interface IProductService
    {
        ProductDetail GetProduct(
            string id);
        
        Product GetNotFoundModel();
    }
}
