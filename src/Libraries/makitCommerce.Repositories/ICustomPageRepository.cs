namespace makit.makitCommerce.Repositories
{
    using System;
    using makit.makitCommerce.Domain.Models;

    public interface ICustomPageRepository : IDisposable
    {
        CustomPage GetCustomPage(
            string pageName);

        void SaveCustomPage(
            CustomPage pageModel);
    }
}
