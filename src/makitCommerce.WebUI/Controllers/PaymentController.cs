namespace makit.makitCommerce.WebUI.Controllers
{
    using System.Web.Mvc;
    using makit.makitCommerce.Services;
    using makit.makitCommerce.WebUI.Infrastructure;

    public class PaymentController : BaseMakitCommerceController
    {
        public PaymentController(
            ISessionService sessionService)
            : base(sessionService)
        {
        }

        public ActionResult Index(
            string paymentMethodCode)
        {
            //TODO: Implement

            return View();
        }


        public ActionResult PaymentCallback()
        {
            // TODO: implement
            return Content("TODO");
        }

    }
}
