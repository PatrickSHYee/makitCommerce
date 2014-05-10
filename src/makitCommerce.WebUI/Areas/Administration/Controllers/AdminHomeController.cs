using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using makit.makitCommerce.WebUI.Areas.Administration.Models;
using System.Web.Security;

namespace makit.makitCommerce.WebUI.Areas.Administration.Controllers
{
    public class AdminHomeController : Controller
    {

        // **************************************
        // URL: /Administration/Index
        // **************************************
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // **************************************
        // URL: /Administration/Login
        // **************************************

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(
            LoginModel model, 
            string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //AccountManager.authoriseLogin(model.Username, model.Password)
                if (true)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Administration/Logout
        // **************************************

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }

    }
}
