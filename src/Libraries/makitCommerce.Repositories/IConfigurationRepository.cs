namespace makit.makitCommerce.Repositories
{
    using System;
    using System.Collections.Generic;

    public interface IConfigurationRepository : IDisposable
    {
        IDictionary<string, string> GetConfigurationKeys();

        void SaveConfigurationKeys(
            IDictionary<string, string> keys);
    }
}
