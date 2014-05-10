namespace makit.makitCommerce.Infrastructure.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(
            IWindsorContainer container, 
            IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                            .Where(type => type.Name.EndsWith("Service"))
                            .WithService.DefaultInterfaces()
                            .LifestyleTransient());

            //TODO: In Plugins folder as well?
        }
    }
}