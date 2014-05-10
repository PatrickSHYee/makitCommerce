using System;
using System.Collections.Generic;
using System.Text;
using makit.makitCommerce.Repositories;
using makit.makitCommerce.Domain.Models;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Web.Hosting;
using makit.makitCommerce.Domain.DataTypes;

namespace makit.makitCommerce.Repository.Xml
{
    public class ProductRepository : IProductRepository
    {
        public ProductDetail GetProduct(
            string productID)
        {
            ProductDetail prod = null;

            // Get the file from within the webapp App_Data folder
            string filePath = Path.Combine(HostingEnvironment.MapPath("~/App_Data/Products/"), productID + ".xml");

            // Create and load the file
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            // Get the product ID, if it can't be found or it doesn't match the given ID 
            // then no point considering because the XML must be incorrect.
            XmlNode productIDNode = doc.SelectSingleNode("//ProductDetail/ProductID/text()");
            if (productIDNode != null && productIDNode.Value == productID)
            {
                prod = new ProductDetail();

                prod.ProductId = productID;
                prod.PageTitle = GetNodeValueIfExists(doc, "PageTitle");
                prod.MetaDescription = GetNodeValueIfExists(doc, "MetaDescription");
                prod.MetaKeywords = GetNodeValueIfExists(doc, "MetaKeywords");
                prod.ProductName = GetNodeValueIfExists(doc, "ProductName");

                prod.ProductShortDescription = GetNodeValueIfExists(doc, "ProductShortDescription");
                prod.ProductLongDescription = GetNodeValueIfExists(doc, "ProductLongDescription");

                prod.ProductUnitPrice = new Currency(Int32.Parse(GetNodeValueIfExists(doc, "ProductUnitPrice/AmountInPence")),
                                                        GetNodeValueIfExists(doc, "ProductUnitPrice/CurrencyCode"));
                
                // Add the attributes if any exist
                XmlNode attributesNode = doc.SelectSingleNode("//ProductDetail/ProductAttributes");
                if (attributesNode != null && attributesNode.HasChildNodes)
                {
                    prod.ProductAttributes = new Dictionary<string, string>();

                    foreach (XmlElement currentAttributeElement in attributesNode)
                    {
                        string key = currentAttributeElement.GetAttribute("key");
                        string value = currentAttributeElement.GetAttribute("value");

                        if (key != null && value != null)
                            prod.ProductAttributes.Add(key, value);
                    }
                }

            }

            doc = null;

            return prod;
        }

        public void Dispose()
        {
            //TODO: Implement IDisposable
        }

        private string GetNodeValueIfExists(
            XmlDocument doc, 
            string tagName)
        {
            XmlNode node = doc.SelectSingleNode("//ProductDetail/" + tagName + "/text()");

            if (node != null)
                return node.Value;

            return null;
        }
    }
}
