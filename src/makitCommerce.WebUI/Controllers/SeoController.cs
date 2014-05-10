using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using makit.makitCommerce.WebUI.Infrastructure;
using makit.makitCommerce.Services;

namespace makit.makitCommerce.WebUI.Controllers
{
    public class SeoController : BaseMakitCommerceController
    {
        public SeoController(
            ISessionService sessionService)
            : base(sessionService)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SEOSiteMap()
        {
            return View();
        }

        public ActionResult HumanSiteMap()
        {
            return View();
        }

    }
}
