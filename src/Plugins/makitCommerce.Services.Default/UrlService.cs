namespace makit.makitCommerce.Services.Default
{
    using System.Text.RegularExpressions;

    public class UrlService : IUrlService
    {
        public string GetUrlSlugString(
            string stringForUrl)
        {
            if (stringForUrl == null)
            {
                return null;
            }
            else
            {
                //TODO: Change below to loop and not regex

                // Remove any HTML from the string
                stringForUrl = Regex.Replace(stringForUrl, "<(.|\\n)*?>", " ");

                // Remove all characters other than the basics and return the string
                return Regex.Replace(stringForUrl, "[^a-zA-Z0-9]", "-").ToLower();
            }
        }

    }
}
