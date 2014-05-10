namespace makit.makitCommerce.Services.Default
{
    using makit.makitCommerce.Repositories;
    using makit.makitCommerce.Domain.Models;

    public class BasketService : IBasketService
    {
        private readonly IBasketRepository basketRepository;
        private readonly IProductRepository productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketService"/> class.
        /// </summary>
        /// <param name="basketRepository">The basket repository.</param>
        /// <param name="productRepository">The product repository.</param>
        public BasketService(
            IBasketRepository basketRepository,
            IProductRepository productRepository)
        {
            this.basketRepository = basketRepository;
            this.productRepository = productRepository;
        }

        /// <summary>
        /// Gets the basket with the given session ID.
        /// </summary>
        /// <param name="sessionId">The session ID.</param>
        /// <returns>
        /// The <see cref="CustomerBasket"/> instance for the given ID.
        /// </returns>
        public CustomerBasket GetBasket(
            string sessionId)
        {
            CustomerBasket basketToUpdate = this.basketRepository.GetCustomerBasket(sessionId);
            return basketToUpdate;
        }

        /// <summary>
        /// Creates a new basket with the given session ID.
        /// </summary>
        /// <param name="sessionId">The session ID to create the basket for.</param>
        /// <returns>
        /// The newly created <see cref="CustomerBasket"/> instance.
        /// </returns>
        public CustomerBasket CreateNewBasket(
            string sessionId)
        {
            CustomerBasket createdBasket = new CustomerBasket();
            createdBasket.SessionId = sessionId;
            return createdBasket;
        }

        /// <summary>
        /// Adds the product to basket with the given quantity.
        /// </summary>
        /// <param name="sessionId">The session ID.</param>
        /// <param name="productId">The product ID.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>
        /// The <see cref="ProductDetail"/> model of the added product if valid, else <c>null</c>.
        /// </returns>
        public ProductDetail AddProductToBasket(
            string sessionId, 
            string productId, 
            short quantity)
        {
            //TODO: Validate productID and quantity

            ProductDetail prod = this.productRepository.GetProduct(productId);

            //TODO: throw exception?
            if (prod != null)
            {
                BasketItem itemBeingAdded = BuildBasketItemModel(prod);
                itemBeingAdded.Quantity = quantity;

                CustomerBasket basketToUpdate = GetBasket(sessionId);

                if (basketToUpdate == null)
                {
                    basketToUpdate = CreateNewBasket(sessionId);
                }

                basketToUpdate.AddItem(itemBeingAdded);

                this.basketRepository.UpdateCustomerBasket(basketToUpdate);

                return prod;
            }

            return null;
        }

        public BasketItem BuildBasketItemModel(
            ProductDetail productToBuildFrom)
        {
            BasketItem itemBeingBuilt = new BasketItem();
            itemBeingBuilt.ProductId = productToBuildFrom.ProductId;
            itemBeingBuilt.ProductName = productToBuildFrom.ProductName;
            itemBeingBuilt.UnitPrice = productToBuildFrom.ProductUnitPrice;

            return itemBeingBuilt;
        }
    }
}
