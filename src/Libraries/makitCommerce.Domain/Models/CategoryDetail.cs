namespace makit.makitCommerce.Domain.Models
{
    using System.Collections.Generic;
    
    public class CategoryDetail : Category
    {
        /// <summary>
        /// Gets or sets the category breadcrumbs.
        /// </summary>
        /// <value>
        /// The category breadcrumbs.
        /// </value>
        public List<Category> CategoryBreadcrumbs { get; set; }

        /// <summary>
        /// Gets or sets the sub categories.
        /// </summary>
        /// <value>
        /// The sub categories.
        /// </value>
        public List<Category> SubCategories { get; set; }

        /// <summary>
        /// Gets or sets the sub products.
        /// </summary>
        /// <value>
        /// The sub products.
        /// </value>
        public List<Product> SubProducts { get; set; }

        /// <summary>
        /// Gets or sets the category template.
        /// </summary>
        /// <value>
        /// The category template.
        /// </value>
        public string CategoryTemplate { get; set; }

        /// <summary>
        /// Gets or sets the category attributes.
        /// </summary>
        /// <value>
        /// The category attributes.
        /// </value>
        public Dictionary<string, string> CategoryAttributes { get; set; }

        /// <summary>
        /// Gets or sets the category long description.
        /// </summary>
        /// <value>
        /// The category long description.
        /// </value>
        public string CategoryLongDescription { get; set; }
    }
}
