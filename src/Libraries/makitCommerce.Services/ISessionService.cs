namespace makit.makitCommerce.Services
{
    public interface ISessionService
    {
        string GetNewSessionId();

        bool IsValidSessionId(
            string sessionIdToValidate);
    }
}
