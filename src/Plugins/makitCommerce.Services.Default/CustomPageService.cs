namespace makit.makitCommerce.Services.Default
{
    using System.Diagnostics;
    using makit.makitCommerce.Repositories;
    using makit.makitCommerce.Domain.Models;
    using makit.makitCommerce.Services;

    public class CustomPageService : ICustomPageService
    {
        #region Members

        private readonly ICategoryService categoryManager;
        private readonly ICustomPageRepository customPageRepository;
        private readonly ISeoService seoManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomPageService"/> class.
        /// </summary>
        /// <param name="categoryManager">The category manager.</param>
        /// <param name="customPageRepository">The custom page repository.</param>
        /// <param name="seoManager">The SEO manager.</param>
        public CustomPageService(
            ICategoryService categoryManager,
            ICustomPageRepository customPageRepository,
            ISeoService seoManager)
        {
            this.categoryManager = categoryManager;
            this.customPageRepository = customPageRepository;
            this.seoManager = seoManager;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the custom page with the given ID.
        /// </summary>
        /// <param name="id">The id of the custom page to retrieve.</param>
        /// <returns>The <see cref="CustomPage"/> instance with the custom page data for the given ID.</returns>
        public CustomPage GetCustomPage(
            string id)
        {
            CustomPage pageModel = this.customPageRepository.GetCustomPage(id);

            if (pageModel == null || pageModel.CustomPageContents == null)
            {
                pageModel = GetNotFoundModel();
            }

            if (pageModel.CategoryIdToDisplay != null)
            {
                pageModel.CategoryToDisplay = this.categoryManager.GetCategory(pageModel.CategoryIdToDisplay, false);
            }

            pageModel = (CustomPage)this.seoManager.AddMetaDataToModel(pageModel);

            return pageModel;
        }

        #endregion

        #region Private Methods

        private CustomPage GetNotFoundModel()
        {
            Trace.WriteLine("makit.makitCommerce.Core.CustomPages.CustomPageManager.getNotFoundModel: Start.");

            CustomPage pg = new CustomPage();
            pg.PageTitle = "Not Found";
            pg.CustomPageContents = "Not Found";
            // TODO: Above from handler?

            Trace.WriteLine("makit.makitCommerce.Core.CustomPages.CustomPageManager.getNotFoundModel: Finish.");

            return pg;
        }

        #endregion
    }
}
