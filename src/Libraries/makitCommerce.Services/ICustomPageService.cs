namespace makit.makitCommerce.Services
{
    using makit.makitCommerce.Domain.Models;

    public interface ICustomPageService
    {
        /// <summary>
        /// Gets the custom page with the given ID.
        /// </summary>
        /// <param name="id">The id of the custom page to retrieve.</param>
        /// <returns>The <see cref="CustomPage"/> instance with the custom page data for the given ID.</returns>
        CustomPage GetCustomPage(
            string id);
    }
}
