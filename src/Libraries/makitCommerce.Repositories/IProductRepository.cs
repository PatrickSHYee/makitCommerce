namespace makit.makitCommerce.Repositories
{
    using System;
    using makit.makitCommerce.Domain.Models;

    public interface IProductRepository : IDisposable
    {
        ProductDetail GetProduct(
            string productId);
    }
}
