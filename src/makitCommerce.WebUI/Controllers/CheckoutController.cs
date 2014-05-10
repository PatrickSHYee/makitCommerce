using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using makit.makitCommerce.WebUI.Infrastructure;
using makit.makitCommerce.Services;

namespace makit.makitCommerce.WebUI.Controllers
{
    public class CheckoutController : BaseMakitCommerceController
    {
        public CheckoutController(
            ISessionService sessionService)
            : base(sessionService)
        {
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            //TODO:Implement

            // Redirects to LoginOrRegister if not logged in or have basket details
            // else redirects to SelectMethodOfPayment

            return RedirectToAction("LoginOrRegister");
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult LoginOrRegister()
        {
            //TODO:Implement

            // This is the login/register page

            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult SelectMethodOfPayment()
        {
            //TODO: Implement

            return View();
        }

        // For the future
        //public ActionResult EditDetails()

    }
}
