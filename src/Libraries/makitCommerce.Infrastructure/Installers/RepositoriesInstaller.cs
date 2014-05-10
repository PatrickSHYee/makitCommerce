namespace makit.makitCommerce.Infrastructure.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(
            IWindsorContainer container, 
            IConfigurationStore store)
        {
            //TODO: Make this use a config of which plugin to use

            container.Register(
                AllTypes.FromAssemblyInDirectory(new AssemblyFilter(@"Plugins"))
                .Where(type => type.IsPublic)
                .WithService.FirstInterface());
        }
    }
}