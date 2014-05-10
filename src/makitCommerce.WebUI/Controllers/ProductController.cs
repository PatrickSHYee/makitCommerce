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
    public class ProductController : BaseMakitCommerceController
    {
        private readonly IProductService productService;

        public ProductController(
            IProductService productService,
            ISessionService sessionService)
            : base(sessionService)
        {
            this.productService = productService;
        }

        public ActionResult Index()
        {
            return this.View(
                "NotFound", 
                this.productService.GetNotFoundModel());
        }

        public ActionResult Display(
            string id, 
            string slug)
        {
            // TODO: if slug wrong then perm redirect

            ProductDetail prod = this.productService.GetProduct(id);

            if (prod == null || prod.ProductId == null)
            {
                return this.View(
                    "NotFound", 
                    this.productService.GetNotFoundModel());
            }
            else
            {
                //TODO: Template from prod model
                return this.View(
                    "TemplateDefault", 
                    prod);
            }

        }

    }
}
