using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using makit.makitCommerce.Domain.Models;
using makit.makitCommerce.WebUI.Infrastructure;
using makit.makitCommerce.Services;

namespace makit.makitCommerce.WebUI.Controllers
{
    public class CustomPageController : BaseMakitCommerceController
    {
        #region Members

        private readonly ICustomPageService customPageService;

        #endregion

        #region Constructor

        public CustomPageController(
            ICustomPageService customPageService,
            ISessionService sessionService)
            : base(sessionService)
        {
            this.customPageService = customPageService;
        }

        #endregion

        #region ActionResult Methods

        public ActionResult Index()
        {
            return this.Render("Home");
        }

        public ActionResult Render(
            string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = "Home";
            }

            return this.View(
                "Render", 
                this.customPageService.GetCustomPage(id));
        }

        #endregion
    }
}
