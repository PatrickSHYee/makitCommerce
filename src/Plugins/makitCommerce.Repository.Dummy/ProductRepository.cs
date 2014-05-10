using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using makit.makitCommerce.Repositories;
using makit.makitCommerce.Domain.Models;

namespace makit.makitCommerce.Repository.Dummy
{
    public class ProductRepository : IProductRepository
    {
        public ProductDetail GetProduct(
            string productId)
        {
            ProductDetail mdl = new ProductDetail();
            mdl.ProductId = productId;
            mdl.ProductName = "Test Product " + productId;


            return mdl;
        }

        public void Dispose()
        {
            //TODO: Implement IDisposable
        }
    }
}
