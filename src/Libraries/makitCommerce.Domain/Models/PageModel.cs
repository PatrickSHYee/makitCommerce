namespace makit.makitCommerce.Domain.Models
{
    public class PageModel
    {
        /// <summary>
        /// Gets or sets the page title.
        /// </summary>
        /// <value>
        /// The page title.
        /// </value>
        public string PageTitle { get; set; }

        /// <summary>
        /// Gets or sets the meta description.
        /// </summary>
        /// <value>
        /// The meta description.
        /// </value>
        public string MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta keywords.
        /// </summary>
        /// <value>
        /// The meta keywords.
        /// </value>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// Gets or sets the ID of the category to display.
        /// </summary>
        /// <value>
        /// The ID of the category to display.
        /// </value>
        public string CategoryIdToDisplay { get; set; }

        /// <summary>
        /// Gets or sets the category to display.
        /// </summary>
        /// <value>
        /// The category to display.
        /// </value>
        public Category CategoryToDisplay { get; set; }
    }
}
