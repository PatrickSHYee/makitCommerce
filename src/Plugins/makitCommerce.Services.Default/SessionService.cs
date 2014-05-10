namespace makit.makitCommerce.Services.Default
{
    using System;

    public class SessionService : ISessionService
    {
        public string GetNewSessionId()
        {
            return Guid.NewGuid().ToString();
        }

        public bool IsValidSessionId(
            string sessionIdToValidate)
        {
            bool isValid = false;

            if (!string.IsNullOrWhiteSpace(sessionIdToValidate))
            {
                //TODO: Validate
                isValid = true;
            }

            return isValid;
        }
    }
}
