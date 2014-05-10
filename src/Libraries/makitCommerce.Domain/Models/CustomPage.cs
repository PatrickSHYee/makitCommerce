namespace makit.makitCommerce.Domain.Models
{
    public class CustomPage : PageModel
    {
        /// <summary>
        /// Gets or sets the name of the custom page.
        /// </summary>
        /// <value>
        /// The name of the custom page.
        /// </value>
        public string CustomPageName { get; set; }

        /// <summary>
        /// Gets or sets the custom page contents.
        /// </summary>
        /// <value>
        /// The custom page contents.
        /// </value>
        public string CustomPageContents { get; set; }

        /// <summary>
        /// Gets or sets the custom page template.
        /// </summary>
        /// <value>
        /// The custom page template.
        /// </value>
        public string CustomPageTemplate { get; set; }
    }
}
