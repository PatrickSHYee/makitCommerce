namespace makit.makitCommerce.Services
{
    using makit.makitCommerce.Domain.Models;

    public interface ISeoService
    {
        PageModel AddMetaDataToModel(
            PageModel model);
    }
}
