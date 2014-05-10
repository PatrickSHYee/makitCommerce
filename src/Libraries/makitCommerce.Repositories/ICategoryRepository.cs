namespace makit.makitCommerce.Repositories
{
    using System;
    using makit.makitCommerce.Domain.Models;

    public interface ICategoryRepository : IDisposable
    {
        CategoryDetail GetCategory(
            string categoryId,
            bool includingSubItems);
    }
}
