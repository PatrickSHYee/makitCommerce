namespace makit.makitCommerce.Services
{
    using makit.makitCommerce.Domain.Models;

    public interface ICategoryService
    {
        Category GetSideBarCategory();
       
        Category GetCategory(
            string id, 
            bool addSidebar = true);
       
        Category GetNotFoundModel();
    }
}
