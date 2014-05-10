namespace makit.makitCommerce.Services.Default
{
    using makit.makitCommerce.Repositories;
    using makit.makitCommerce.Domain.Models;
    using makit.makitCommerce.Services;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductService productManager;
        private readonly ISeoService seoManager;
        private readonly IUrlService urlGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="categoryRepository">The category repository.</param>
        /// <param name="productManager">The product manager.</param>
        /// <param name="seoManager">The SEO manager.</param>
        /// <param name="urlGenerator">The URL generator.</param>
        public CategoryService(
            ICategoryRepository categoryRepository,
            IProductService productManager,
            ISeoService seoManager,
            IUrlService urlGenerator)
        {
            this.categoryRepository = categoryRepository;
            this.productManager = productManager;
            this.seoManager = seoManager;
            this.urlGenerator = urlGenerator;
        }

        public Category GetSideBarCategory()
        {
            //TODO: Get from config
            return this.GetCategory("C000ALL", false);
        }

        public Category GetCategory(
            string id, 
            bool addSidebar = true)
        {
            // If not cached then do the below

            CategoryDetail cat = this.categoryRepository.GetCategory(id, true);

            // Generate all the Url slugs here for the sub cat's as well as the current category
            cat.CategoryUrlSlug = this.urlGenerator.GetUrlSlugString(cat.CategoryName);

            if (cat.SubCategories != null)
            {
                foreach (Category subCat in cat.SubCategories)
                {
                    subCat.CategoryUrlSlug = this.urlGenerator.GetUrlSlugString(subCat.CategoryName);
                }
            }

            // Retrieve all the sub-product models if any exist in the category
            if (cat.SubProducts != null)
            {
                for (int i = 0; i < cat.SubProducts.Count; i++)
                {
                    cat.SubProducts[i] = this.productManager.GetProduct(cat.SubProducts[i].ProductId);
                }
            }

            if (addSidebar)
            {
                // TODO: Below depend on page? Or same for everywhere?
                cat.CategoryToDisplay = this.GetSideBarCategory();
            }

            cat = (CategoryDetail)this.seoManager.AddMetaDataToModel(cat);

            //TODO: Cache here if turned on in config

            return cat;
        }

        public Category GetNotFoundModel()
        {
            Category cat = new Category();
            cat.PageTitle = "Not Found"; //TODO: localisation
            return cat;
        }
    }
}
