namespace makit.makitCommerce.WebUI.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Castle.MicroKernel;
    using makit.makitCommerce.WebUI.Controllers;

    public class StoreControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public StoreControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public override void ReleaseController(
            IController controller)
        {
            kernel.ReleaseComponent(controller);
        }

        /// <summary>
        /// Gets the controller instance.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        /// <param name="controllerType">Type of the controller.</param>
        /// <returns></returns>
        protected override IController GetControllerInstance(
            RequestContext requestContext, 
            Type controllerType)
        {
            if (controllerType == null)
            {
                string message = string.Format(
                        "The controller for path '{0}' was not found or does not implement IController", 
                        requestContext.HttpContext.Request.Path);

                throw new HttpException(
                    404,
                    message);
            }

            if (!typeof(IController).IsAssignableFrom(controllerType))
            {
                string message = string.Format(
                    "The controller type '{0}' must implement IController.", 
                    controllerType);

                throw new ArgumentException(
                    message,
                    "controllerType");
            }

            // Use Windsor to instanciate the controllers
            return (IController)kernel.Resolve(controllerType);

            //// This code is the custom bit from the default GetControllerInstance to handle slug only URLs
            //if (object.ReferenceEquals(controllerType, typeof(SEOController)))
            //{
            //    //TODO: Slug rewrite code here. Delete below line to replace with slug code.
            //    return base.GetControllerInstance(requestContext, controllerType);
            //}
            //else
            //{
            //    // Not slug only so default to the base method
            //    return base.GetControllerInstance(requestContext, controllerType);
            //}

        }
    }
}