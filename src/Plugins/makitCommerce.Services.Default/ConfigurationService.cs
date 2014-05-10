namespace makit.makitCommerce.Services.Default
{
    using System;
    using System.Collections.Generic;
    using makit.makitCommerce.Repositories;

    public class ConfigurationService : IConfigurationService
    {

        #region Members

        private readonly IConfigurationRepository configurationRepository;
        private IDictionary<string, string> configurationValues;

        #endregion

        #region Contructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationService"/> class.
        /// </summary>
        /// <param name="configurationRepository">The configuration repository.</param>
        public ConfigurationService(
            IConfigurationRepository configurationRepository)
        {
            this.configurationRepository = configurationRepository;

            this.UpdateCachedConfigurationValues();
        }

        #endregion

        #region Retrieving Settings

        /// <summary>
        /// Gets a setting value as a boolean.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValueIfNotFound">The default value if the setting is not found.</param>
        /// <returns>
        /// The value of the setting with the given key.
        /// </returns>
        public bool GetBooleanSetting(
            string key,
            bool defaultValueIfNotFound)
        {
            string settingValue = this.GetStringSetting(key);

            if (settingValue == null)
            {
                return defaultValueIfNotFound;
            }

            return Convert.ToBoolean(settingValue);
        }

        /// <summary>
        /// Gets a setting value as a byte.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValueIfNotFound">The default value if the setting is not found.</param>
        /// <returns>
        /// The value of the setting with the given key.
        /// </returns>
        public byte GetByteSetting(
            string key,
            byte defaultValueIfNotFound)
        {
            string settingValue = this.GetStringSetting(key);

            if (settingValue == null)
            {
                return defaultValueIfNotFound;
            }

            return Convert.ToByte(settingValue);
        }

        /// <summary>
        /// Gets a setting value as a decimal.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValueIfNotFound">The default value if the setting is not found.</param>
        /// <returns>
        /// The value of the setting with the given key.
        /// </returns>
        public decimal GetDecimalSetting(
            string key,
            decimal defaultValueIfNotFound)
        {
            string settingValue = this.GetStringSetting(key);

            if (settingValue == null)
            {
                return defaultValueIfNotFound;
            }

            return Convert.ToDecimal(settingValue);
        }

        /// <summary>
        /// Gets a setting value as an integer.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValueIfNotFound">The default value if the setting is not found.</param>
        /// <returns>
        /// The value of the setting with the given key.
        /// </returns>
        public int GetIntegerSetting(
            string key, 
            int defaultValueIfNotFound)
        {
            string settingValue = this.GetStringSetting(key);

            if (settingValue == null)
            {
                return defaultValueIfNotFound;
            }

            return Convert.ToInt32(settingValue);
        }

        /// <summary>
        /// Gets a setting value as a file location in a string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The value of the setting with the given key.
        /// </returns>
        public string GetFileLocationSetting(
            string key)
        {
            string settingValue = this.GetStringSetting(key);

            // If the value isn't null then check it ends with a back slash, if not then 
            // one is appended, before returning
            if (settingValue != null)
            {
                if (settingValue.EndsWith(@"\") == false)
                {
                    settingValue = string.Concat(settingValue, @"\");
                }

                return settingValue;
            }

            return null;
        }

        /// <summary>
        /// Gets a setting value as a single.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValueIfNotFound">The default value if the setting is not found.</param>
        /// <returns>
        /// The value of the setting with the given key.
        /// </returns>
        public float GetSingleSetting(
            string key, 
            float defaultValueIfNotFound)
        {
            string settingValue = this.GetStringSetting(key);

            if (settingValue == null)
            {
                return defaultValueIfNotFound;
            }

            return Convert.ToSingle(settingValue);
        }

        /// <summary>
        /// Gets a setting value as a string array.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="delimiter">The delimiter <c>char</c> for splitting out the values from the setting string.</param>
        /// <returns>
        /// The value of the setting with the given key.
        /// </returns>
        public string[] GetStringArray(
            string key,
            char delimiter = '|')
        {
            string settingValue = this.GetStringSetting(key);

            // Default to returning null
            string[] arrResults = null;

            // If the value was not null then split the value by the delimiter and return the array
            if (settingValue != null)
            {
                arrResults = settingValue.Split(delimiter);
            }

            return arrResults;

        }

        /// <summary>
        /// Gets a setting value as a string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValueIfNotFound">The default value if the setting is not found.</param>
        /// <returns>
        /// The value of the setting with the given key.
        /// </returns>
        public string GetStringSetting(
            string key,
            string defaultValueIfNotFound = null)
        {
            string valueToReturn = defaultValueIfNotFound;
            
            // If no config values then get from DB and cache them
            if (this.configurationValues == null)
            {
                this.UpdateCachedConfigurationValues();
            }

            if(this.configurationValues.ContainsKey(key))
            {
                string settingValue = this.configurationValues[key];

                if (settingValue != null)
                {
                    valueToReturn = settingValue;
                }
            }

            return valueToReturn;
        }

        /// <summary>
        /// Gets a setting value as a URL in a string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The value of the setting with the given key.
        /// </returns>
        public string GetUrlSetting(
            string key)
        {
            string settingValue = this.GetStringSetting(key);

            // If the value isn't null then check it ends with a slash, if not then 
            // one is appended, before returning
            if (settingValue != null)
            {
                if (settingValue.EndsWith("/") == false)
                {
                    settingValue = string.Concat(settingValue, "/");
                }

                return settingValue;
            }

            return null;
        }

        #endregion

        #region Update Method

        /// <summary>
        /// Updates the cached configuration values from the repository
        /// </summary>
        public void UpdateCachedConfigurationValues()
        {
            // Get the keys from the repository
            this.configurationValues = this.configurationRepository.GetConfigurationKeys();

            // Store the time so a sliding cache can be maintained if neccessary
            //_LastRetrievedFromRepository = DateTime.Now();
        }

        #endregion

    }
}
