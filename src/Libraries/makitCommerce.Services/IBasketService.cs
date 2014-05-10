namespace makit.makitCommerce.Services
{
    using makit.makitCommerce.Domain.Models;

    public interface IBasketService
    {
        /// <summary>
        /// Gets the basket with the given session ID.
        /// </summary>
        /// <param name="sessionId">The session ID.</param>
        /// <returns>The <see cref="CustomerBasket"/> instance for the given ID.</returns>
        CustomerBasket GetBasket(string sessionId);

        /// <summary>
        /// Creates a new basket with the given session ID.
        /// </summary>
        /// <param name="sessionId">The session ID to create the basket for.</param>
        /// <returns>The newly created <see cref="CustomerBasket"/> instance.</returns>
        CustomerBasket CreateNewBasket(string sessionId);

        /// <summary>
        /// Adds the product to basket with the given quantity.
        /// </summary>
        /// <param name="sessionId">The session ID.</param>
        /// <param name="productId">The product ID.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The <see cref="ProductDetail"/> model of the added product if valid, else <c>null</c>.</returns>
        ProductDetail AddProductToBasket(
            string sessionId, 
            string productId, 
            short quantity);

        BasketItem BuildBasketItemModel(
            ProductDetail productToBuildFrom);
    }
}
