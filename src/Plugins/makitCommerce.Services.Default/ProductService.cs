namespace makit.makitCommerce.Services.Default
{
    using makit.makitCommerce.Repositories;
    using makit.makitCommerce.Domain.Models;
    using makit.makitCommerce.Services;

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUrlService urlGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="urlGenerator">The URL generator.</param>
        public ProductService(
            IProductRepository productRepository,
            IUrlService urlGenerator)
        {
            this.productRepository = productRepository;
            this.urlGenerator = urlGenerator;
        }

        public ProductDetail GetProduct(
            string id)
        {
            ProductDetail prod = this.productRepository.GetProduct(id);

            // Generate the Url slug here
            prod.ProductUrlSlug = this.urlGenerator.GetUrlSlugString(prod.ProductName);

            return prod;
        }

        public Product GetNotFoundModel()
        {
            Product prod = new Product();
            prod.PageTitle = "Not Found"; //TODO: localisation
            return prod;
        }
    }
}
