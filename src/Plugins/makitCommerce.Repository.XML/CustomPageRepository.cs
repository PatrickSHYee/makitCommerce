using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using makit.makitCommerce.Repositories;
using makit.makitCommerce.Domain.Models;
using System.Xml.Serialization;
using System.IO;
using System.Web.Hosting;

namespace makit.makitCommerce.Repository.XML
{
    public class CustomPageRepository : ICustomPageRepository
    {
        public CustomPage GetCustomPage(
            string pageName)
        {
            CustomPage page = null;

            XmlSerializer serializer = new XmlSerializer(typeof(CustomPage));
            
            // Get the file from within the webapp App_Data folder
            string filePath = Path.Combine(HostingEnvironment.MapPath("~/App_Data/CustomPages/"), pageName + ".xml");

            using (StreamReader reader = new StreamReader(filePath))
            {
                page = (CustomPage)serializer.Deserialize(reader);
                reader.Close();
            }

            return page;
        }

        public void SaveCustomPage(
            CustomPage pge)
        {

            // HACK: TEMP for testing
            CustomPage page = new CustomPage();
            page.PageTitle = "Welcome";
            page.CustomPageContents = "<b>Welcome</b> to this!";
            page.CategoryIdToDisplay = "1";
            string pageName = "Home";

            XmlSerializer serializer = new XmlSerializer(typeof(CustomPage));

            //HACK: Hardcoded and filename from an "index" file that's loaded into memory
            string path = "D:\\VisualStudio\\makitCommerce\\src\\makitCommerce.WebUI\\App_Data\\CustomPages\\";
            using (TextWriter textWriter = new StreamWriter(path + pageName + ".xml"))
            {
                serializer.Serialize(textWriter, page);
                textWriter.Close();
            }
        }

        public void Dispose()
        {
            //TODO: Implement IDisposable
        }
    }
}
