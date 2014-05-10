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
    public class BasketRepository : IBasketRepository
    {
        public CustomerBasket GetCustomerBasket(
            string sessionId)
        {
            CustomerBasket basket = null;

            XmlSerializer serializer = new XmlSerializer(typeof(CustomerBasket));

            // Get the file from within the webapp App_Data folder
            string filePath = Path.Combine(HostingEnvironment.MapPath("~/App_Data/Baskets/"), sessionId + ".xml");

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    basket = (CustomerBasket)serializer.Deserialize(reader);
                    reader.Close();
                }
            }

            return basket;
        }

        public void UpdateCustomerBasket(
            CustomerBasket basketModelToUpdateWith)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CustomerBasket));

            // Get the file from within the webapp App_Data folder
            string filePath = Path.Combine(HostingEnvironment.MapPath("~/App_Data/Baskets/"), basketModelToUpdateWith.SessionId + ".xml");

            using (TextWriter textWriter = new StreamWriter(filePath))
            {
                serializer.Serialize(textWriter, basketModelToUpdateWith);
                textWriter.Close();
            }

            //TODO: write items to XML
        }

        public void Dispose()
        {
            //TODO: Implement IDisposable
        }
    }
}
