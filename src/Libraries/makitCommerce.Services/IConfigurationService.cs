namespace makit.makitCommerce.Services
{
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets a setting value as a boolean.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValueIfNotFound">The default value if the setting is not found.</param>
        /// <returns>The value of the setting with the given key.</returns>
        bool GetBooleanSetting(
            string key,
            bool defaultValueIfNotFound);

        /// <summary>
        /// Gets a setting value as a byte.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValueIfNotFound">The default value if the setting is not found.</param>
        /// <returns>The value of the setting with the given key.</returns>
        byte GetByteSetting(
            string key,
            byte defaultValueIfNotFound);
        
        /// <summary>
        /// Gets a setting value as a decimal.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValueIfNotFound">The default value if the setting is not found.</param>
        /// <returns>The value of the setting with the given key.</returns>
        decimal GetDecimalSetting(
            string key,
            decimal defaultValueIfNotFound);

        /// <summary>
        /// Gets a setting value as an integer.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValueIfNotFound">The default value if the setting is not found.</param>
        /// <returns>The value of the setting with the given key.</returns>
        int GetIntegerSetting(
            string key,
            int defaultValueIfNotFound);

        /// <summary>
        /// Gets a setting value as a file location in a string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The value of the setting with the given key.</returns>
        string GetFileLocationSetting(
            string key);

        /// <summary>
        /// Gets a setting value as a single.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValueIfNotFound">The default value if the setting is not found.</param>
        /// <returns>The value of the setting with the given key.</returns>
        float GetSingleSetting(
            string key,
            float defaultValueIfNotFound);

        /// <summary>
        /// Gets a setting value as a string array.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="delimiter">The delimiter <c>char</c> for splitting out the values from the setting string.</param>
        /// <returns>The value of the setting with the given key.</returns>
        string[] GetStringArray(
            string key,
            char delimiter);

        /// <summary>
        /// Gets a setting value as a string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValueIfNotFound">The default value if the setting is not found.</param>
        /// <returns>The value of the setting with the given key.</returns>
        string GetStringSetting(
            string key, 
            string defaultValueIfNotFound = null);

        /// <summary>
        /// Gets a setting value as a URL in a string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The value of the setting with the given key.</returns>
        string GetUrlSetting(
            string key);

        /// <summary>
        /// Updates the cached configuration values from the repository
        /// </summary>
        void UpdateCachedConfigurationValues();
    }
}
