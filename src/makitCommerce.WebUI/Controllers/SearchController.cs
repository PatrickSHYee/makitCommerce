using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using makit.makitCommerce.WebUI.Infrastructure;
using makit.makitCommerce.Services;

namespace makit.makitCommerce.WebUI.Controllers
{
    public class SearchController : BaseMakitCommerceController
    {
        public SearchController(
            ISessionService sessionService)
            : base(sessionService)
        {
        }

        public ActionResult Index(
            string searchTerms)
        {
            return View();
        }


        #region AJAX

        public ActionResult SearchSuggestions(string query)
        {
            //TODO: Json list of SearchSuggestion

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public struct SearchSuggestion
        {
            public string query { get; set; }
            public string[] suggestions { get; set; }
            public string[] data { get; set; }
        }

        #endregion

    }
}
