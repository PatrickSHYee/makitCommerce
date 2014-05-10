using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace makit.makitCommerce.WebUI.Areas.Administration.Controllers
{
    [Authorize]
    public class AdminCategoriesController : Controller
    {
        //
        // GET: /Administration/AdminCategories/

        public ActionResult Index()
        {
            return View();
        }

    }
}
