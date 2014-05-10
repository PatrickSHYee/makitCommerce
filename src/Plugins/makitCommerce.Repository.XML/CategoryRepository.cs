using System;
using System.Collections.Generic;
using System.Text;
using makit.makitCommerce.Repositories;
using makit.makitCommerce.Domain.Models;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Web.Hosting;

namespace makit.makitCommerce.Repository.XML
{
    public class CategoryRepository : ICategoryRepository
    {
        public CategoryDetail GetCategory(
            string categoryId, 
            bool includingSubItems)
        {
            CategoryDetail cat = null;

            // Get the file from within the webapp App_Data folder
            string filePath = Path.Combine(HostingEnvironment.MapPath("~/App_Data/Categories/"), categoryId + ".xml");

            // Create and load the file
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            // Get the category ID, if it can't be found or it doesn't match the given ID 
            // then no point considering because the XML must be incorrect.
            XmlNode categoryIDNode = doc.SelectSingleNode("//CategoryDetail/CategoryID/text()");
            if (categoryIDNode != null && categoryIDNode.Value == categoryId)
            {
                cat = new CategoryDetail();

                cat.CategoryId = categoryId;
                cat.PageTitle = GetNodeValueIfExists(doc, "PageTitle");
                cat.MetaDescription = GetNodeValueIfExists(doc, "MetaDescription");
                cat.MetaKeywords = GetNodeValueIfExists(doc, "MetaKeywords");
                //TODO: cat.CategoryIDToDisplay = GetNodeValueIfExists(doc, "CategoryIDToDisplay");
                //cat.CategoryToDisplay
                cat.CategoryName = GetNodeValueIfExists(doc, "CategoryName");
                cat.CategoryPresentationName = GetNodeValueIfExists(doc, "CategoryPresentationName");
                cat.CategoryShortDescription = GetNodeValueIfExists(doc, "CategoryShortDescription");
                cat.CategoryLongDescription = GetNodeValueIfExists(doc, "CategoryLongDescription");
                cat.CategoryTemplate = GetNodeValueIfExists(doc, "CategoryTemplate");
                cat.CategoryImage1 = GetNodeValueIfExists(doc, "CategoryImage1");
                cat.CategoryImage2 = GetNodeValueIfExists(doc, "CategoryImage2");

                // Add the attributes if any exist
                XmlNode attributesNode = doc.SelectSingleNode("//CategoryDetail/CategoryAttributes");
                if (attributesNode != null && attributesNode.HasChildNodes)
                {
                    cat.CategoryAttributes = new Dictionary<string, string>();

                    foreach (XmlElement currentAttributeElement in attributesNode)
                    {
                        string key = currentAttributeElement.GetAttribute("key");
                        string value = currentAttributeElement.GetAttribute("value");

                        if (key != null && value != null)
                            cat.CategoryAttributes.Add(key, value);
                    }
                }

                // The below will stop recursive calling. Each call to get a subcategory would otherwise in turn involve getting a subcategory
                // TODO: This could possibly be moved out of the repository and go through the CategoryManager. Then if the category is already cached it
                // would use that instead. Have issues with full category and category detail then though
                if (includingSubItems)
                {
                    // Add the sub categories if any exist
                    XmlNode subCategoriesNode = doc.SelectSingleNode("//CategoryDetail/SubCategories");
                    if (subCategoriesNode != null && subCategoriesNode.HasChildNodes)
                    {
                        cat.SubCategories = new List<Category>();

                        // Loop through each sub-category node
                        foreach (XmlElement currentSubCatElement in subCategoriesNode)
                        {
                            // Get the category ID
                            string catId = currentSubCatElement.InnerText;
                            if (catId != null)
                            {
                                // Request the category model from this repository but don't include full detail to stop recursive calling of GetCategory
                                Category subCat = GetCategory(catId, false);

                                if (subCat != null)
                                    cat.SubCategories.Add(subCat);
                            }
                        }
                    }

                    // Add the sub products if any exist
                    XmlNode subProductsNode = doc.SelectSingleNode("//CategoryDetail/SubProducts");
                    if (subProductsNode != null && subProductsNode.HasChildNodes)
                    {
                        cat.SubProducts = new List<Product>();

                        // Loop through each sub-product node
                        foreach (XmlElement currentProductNode in subProductsNode)
                        {
                            // Get the product ID
                            string productId = currentProductNode.InnerText;
                            if (productId != null)
                            {
                                // Create the product model with just the product ID. This will be filled further up the stack.
                                ProductDetail prod = new ProductDetail();
                                prod.ProductId = productId;

                                cat.SubProducts.Add(prod);
                            }
                        }
                    }
                }
            }

            doc = null;

            return cat;
        }

        public void Dispose()
        {
            //TODO: Implement IDisposable
        }

        private string GetNodeValueIfExists(
            XmlDocument doc, 
            string tagName)
        {
            XmlNode node = doc.SelectSingleNode("//CategoryDetail/" + tagName + "/text()");

            if (node != null)
                return node.Value;

            return null;
        }
    }
}
