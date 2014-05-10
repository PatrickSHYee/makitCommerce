namespace makit.makitCommerce.Domain.Models
{
    public class Category : PageModel
    {
        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        /// <value>
        /// The category id.
        /// </value>
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <value>
        /// The name of the category.
        /// </value>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the presentation name of the category.
        /// </summary>
        /// <value>
        /// The presentation name of the category.
        /// </value>
        public string CategoryPresentationName { get; set; }

        /// <summary>
        /// Gets or sets the category URL slug.
        /// </summary>
        /// <value>
        /// The category URL slug.
        /// </value>
        public string CategoryUrlSlug { get; set; }

        /// <summary>
        /// Gets or sets the category short description.
        /// </summary>
        /// <value>
        /// The category short description.
        /// </value>
        public string CategoryShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the category image 1.
        /// </summary>
        /// <value>
        /// The category image 1.
        /// </value>
        public string CategoryImage1 { get; set; }

        /// <summary>
        /// Gets or sets the category image 2.
        /// </summary>
        /// <value>
        /// The category image 2.
        /// </value>
        public string CategoryImage2 { get; set; }
    }
}
