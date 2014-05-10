using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using makit.makitCommerce.Services;

namespace makit.makitCommerce.WebUI.Infrastructure
{
    public class BaseMakitCommerceController : Controller
    {
        private readonly ISessionService sessionService;

        public BaseMakitCommerceController(
            ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        protected string GetSessionIdFromCookie()
        {
            string sessionIdToReturn = "";

            HttpCookie sessionIdCookie = Request.Cookies["MUID"];
            if (sessionIdCookie == null || !this.sessionService.IsValidSessionId(sessionIdCookie.Value))
            {
                sessionIdToReturn = this.sessionService.GetNewSessionId();
                SaveSessionIdToCookie(sessionIdToReturn);
            }
            else
            {
                sessionIdToReturn = sessionIdCookie.Value;
            }

            return sessionIdToReturn;
        }

        protected void SaveSessionIdToCookie(
            string sessionIdToSave)
        {
            HttpCookie newSessionIdCookie = new HttpCookie("MUID", sessionIdToSave);
            newSessionIdCookie.Expires = DateTime.MaxValue;

            if(Request.Cookies["MUID"] == null)
            {
                Response.Cookies.Add(newSessionIdCookie);
            }
            else
            {
                Response.Cookies.Set(newSessionIdCookie);
            }
        }
    }
}