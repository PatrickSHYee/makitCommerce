namespace makit.makitCommerce.Repositories
{
    using System;

    public interface IAccountRepository : IDisposable
    {
        bool AuthoriseLogin(
            string userName, 
            string password);
    }
}
