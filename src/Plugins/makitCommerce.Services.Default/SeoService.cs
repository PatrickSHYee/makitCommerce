namespace makit.makitCommerce.Services.Default
{
    using makit.makitCommerce.Domain.Models;
    using makit.makitCommerce.Services;

    public class SeoService : ISeoService
    {
        #region Members

        private readonly IConfigurationService configurationManager;

        #endregion

        #region Constructors

        public SeoService(
            IConfigurationService configurationManager)
        {
            this.configurationManager = configurationManager;
        }

        #endregion

        #region Methods

        public PageModel AddMetaDataToModel(
            PageModel model)
        {
            if (model != null)
            {
                string prefix = this.configurationManager.GetStringSetting("seo.title.prefix");
                string postfix = this.configurationManager.GetStringSetting("seo.title.postfix");
                string separator = this.configurationManager.GetStringSetting("seo.title.separator");

                if (!string.IsNullOrEmpty(prefix))
                {
                    model.PageTitle = string.Concat(
                        prefix,
                        separator,
                        model.PageTitle);
                }

                if (!string.IsNullOrEmpty(postfix))
                {
                    model.PageTitle = string.Concat(
                        model.PageTitle,
                        separator,
                        postfix);
                }

                //TODO: Other meta data
            }

            return model;
        }

        #endregion
    }
}
