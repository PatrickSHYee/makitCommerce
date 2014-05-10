using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using makit.makitCommerce.Repositories;
using makit.makitCommerce.Domain.Models;

namespace makit.makitCommerce.Repository.Dummy
{
    public class CategoryRepository : ICategoryRepository
    {
        public CategoryDetail GetCategory(
            string categoryId, 
            bool includingSubItems)
        {
            CategoryDetail cat = new CategoryDetail();
            cat.CategoryId = categoryId;
            cat.CategoryName = "Test Category " + categoryId;
            cat.PageTitle = "Test Category " + categoryId;

            // For the dummy, if starts with p then a product list category
            if (categoryId.StartsWith("p"))
            {
                // Add products

                cat.SubProducts = new List<Product>();

                for (int i = 1; i <= 5; i++)
                {
                    Product sub = new Product();
                    sub.ProductId = i.ToString();
                    sub.ProductName = "Example Product " + i.ToString();
                    cat.SubProducts.Add(sub);
                }
            }
            else
            {
                // Add categories

                cat.SubCategories = new List<Category>();

                for (int i = 1; i <= 5; i++)
                {
                    Category sub = new Category();
                    sub.CategoryId = i.ToString();
                    sub.CategoryName = "Example " + i.ToString();
                    cat.SubCategories.Add(sub);
                }

                for (int i = 6; i <= 8; i++)
                {
                    Category sub = new Category();
                    sub.CategoryId = "p" + i.ToString();
                    sub.CategoryName = "Example p" + i.ToString();
                    cat.SubCategories.Add(sub);
                }
            }

            return cat;
        }

        public void Dispose()
        {
            //TODO: Implement IDisposable
        }
    }
}
