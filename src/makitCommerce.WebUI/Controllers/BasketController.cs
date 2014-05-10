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
    public class BasketController : BaseMakitCommerceController
    {
        private readonly IBasketService basketService;

        public BasketController(
            IBasketService basketService,
            ISessionService sessionService)
            : base(sessionService)
        {
            this.basketService = basketService;
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index(
            string returnURL)
        {
            //TODO: Implement

            // use returnURL if given for button on view

            string MUID = GetSessionIdFromCookie();
            CustomerBasket basketForPage = this.basketService.GetBasket(MUID);

            if (basketForPage == null)
                basketForPage = new CustomerBasket();

            return View(basketForPage);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AddToBasket(
            string productId, 
            short quantity, 
            String returnUrl)
        {
            string sessionId = GetSessionIdFromCookie();

            ProductDetail addedProduct = this.basketService.AddProductToBasket(sessionId, productId, quantity);

            if (addedProduct == null)
            {
                //TODO: Handle with friendly message
            }

            return RedirectToAction("Index", new { returnURL = returnUrl });
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult DeleteFromBasket(
            string productId)
        {
            //TODO: Implement

            return RedirectToAction("Index");
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Update(
            FormCollection basketCollection)
        {
            //TODO: Implement

            return RedirectToAction("Index");
        }


        #region AJAX

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AddToBasketAjax(
            string productId, 
            short quantity)
        {
            string sessionId = GetSessionIdFromCookie();

            ProductDetail addedProduct = this.basketService.AddProductToBasket(sessionId, productId, quantity);

            //TODO: Use Resources below, so not hardcoded.
            AddToBasketReturnData data = new AddToBasketReturnData();

            if (addedProduct == null)
            {
                data.SuccessMessage = "Couldn't add the chosen product to your basket.";
            }
            else
            {
                data.SuccessMessage = string.Format(
                    "Added {0} of {1} to your basket.",
                    quantity.ToString(), 
                    addedProduct.ProductName);

                data.MiniBasketContent = string.Format(
                    "<em>{0} items</em><span>{1}</span>", 
                    "1", 
                    "£13.99");
            }

            return this.Json(data, JsonRequestBehavior.AllowGet);
        }

        public struct AddToBasketReturnData
        {
            public string SuccessMessage { get; set; }

            public string MiniBasketContent { get; set; }
        }

        #endregion

    }
}
