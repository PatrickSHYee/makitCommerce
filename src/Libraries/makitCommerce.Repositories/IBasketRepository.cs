namespace makit.makitCommerce.Repositories
{
    using System;
    using makit.makitCommerce.Domain.Models;

    public interface IBasketRepository : IDisposable
    {
        CustomerBasket GetCustomerBasket(
            string sessionId);

        void UpdateCustomerBasket(
            CustomerBasket basketModelToUpdateWith);
    }
}
