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
    public class AccountRepository : IAccountRepository
    {
        public bool AuthoriseLogin(
            string username, 
            string password)
        {
            //TODO: Implement authorise login
            return false;
        }

        public void Dispose()
        {
            //TODO: Implement IDisposable
        }
    }
}
