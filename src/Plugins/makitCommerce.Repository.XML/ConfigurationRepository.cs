using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using makit.makitCommerce.Repositories;
using makit.makitCommerce.Domain.Models;
using System.Xml;
using System.IO;
using System.Web.Hosting;

namespace makit.makitCommerce.Repository.XML
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public IDictionary<String, String> GetConfigurationKeys()
        {
            Dictionary<String, String> configValues = new Dictionary<string, string>();

            // Get the file from within the webapp App_Data folder
            string filePath = Path.Combine(HostingEnvironment.MapPath("~/App_Data/"), "ConfigurationValues.xml");

            // Read through the config file
            XmlTextReader reader = new XmlTextReader(filePath);
            while (reader.Read())
            {
                // For each key that has attributes
                if (reader.Name.Equals("add", StringComparison.InvariantCultureIgnoreCase) && reader.HasAttributes)
                {
                    // Will loop the attributes to fill these
                    string keyName = null;
                    string value = null;

                    for (int i = 0; i < reader.AttributeCount; i++)
                    {
                        // Move to the current attribute in the list
                        reader.MoveToAttribute(i);

                        // If its the key or value then store these appropriately
                        if (reader.Name.Equals("key", StringComparison.InvariantCultureIgnoreCase))
                        {
                            keyName = reader.Value;
                        }
                        else if (reader.Name.Equals("value", StringComparison.InvariantCultureIgnoreCase))
                        {
                            value = reader.Value;
                        }
                    }

                    // If a key was found with a name and value then add to the dictionary
                    if (keyName != null && value != null)
                    {
                        configValues.Add(keyName, value);
                    }
                }
            }
            reader.Close();
            reader = null;

            return configValues;
        }

        public void SaveConfigurationKeys(
            IDictionary<String, String> keys)
        {
            //TODO: Implement SaveConfigurationKeys
        }

        public void Dispose()
        {
            //TODO: Implement IDisposable
        }
    }
}
