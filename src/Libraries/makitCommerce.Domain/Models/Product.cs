namespace makit.makitCommerce.Domain.Models
{
    using System.Collections.Generic;    
    using makit.makitCommerce.Domain.DataTypes;

    public class Product : PageModel
    {
        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        /// <value>
        /// The product id.
        /// </value>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product URL slug.
        /// </summary>
        /// <value>
        /// The product URL slug.
        /// </value>
        public string ProductUrlSlug { get; set; }

        /// <summary>
        /// Gets or sets the product short description.
        /// </summary>
        /// <value>
        /// The product short description.
        /// </value>
        public string ProductShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the product unit price.
        /// </summary>
        /// <value>
        /// The product unit price.
        /// </value>
        public Currency ProductUnitPrice { get; set; }
    }

    public class ProductDetail : Product
    {
        /// <summary>
        /// Gets or sets the product long description.
        /// </summary>
        /// <value>
        /// The product long description.
        /// </value>
        public string ProductLongDescription { get; set; }

        /// <summary>
        /// Gets or sets the product attributes.
        /// </summary>
        /// <value>
        /// The product attributes.
        /// </value>
        public Dictionary<string, string> ProductAttributes { get; set; }
    }
}
