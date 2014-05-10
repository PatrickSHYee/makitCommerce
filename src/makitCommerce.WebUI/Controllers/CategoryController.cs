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
    public class CategoryController : BaseMakitCommerceController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(
            ICategoryService categoryService,
            ISessionService sessionService)
            : base(sessionService)
        {
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return this.View(
                "NotFound", 
                this.categoryService.GetNotFoundModel());
        }

        public ActionResult Display(
            string id, 
            string slug)
        {
            // if slug wrong then perm redirect

            Category categoryModel = this.categoryService.GetCategory(id);

            if (categoryModel == null || categoryModel.CategoryId == null)
            {
                return this.View(
                    "NotFound", 
                    this.categoryService.GetNotFoundModel());
            }
            else
            {
                //TODO: Template from cat model
                return this.View(
                    "TemplateDefault", 
                    categoryModel);
            }
 
        }

    }
}
