namespace makit.makitCommerce.Domain.DataTypes
{
    using System;
    using System.Globalization;

    public class Currency
    {
        #region Properties

        /// <summary>
        /// Gets or sets the amount in pence.
        /// </summary>
        /// <value>
        /// The amount in pence.
        /// </value>
        public int AmountInPence { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets the base cost as a decimal, with no currency symbol.
        /// </summary>
        public decimal BaseCost
        {
            get
            {
                return ((decimal)AmountInPence) / 100;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        public Currency()
        {
            this.AmountInPence = 0;
            this.CurrencyCode = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="amountInPence">The amount in pence.</param>
        /// <param name="currencyCode">The currency code.</param>
        public Currency(
            int amountInPence, 
            string currencyCode)
        {
            this.AmountInPence = amountInPence;
            this.CurrencyCode = currencyCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class from another instance of a <see cref="Currency"/> class.
        /// </summary>
        /// <param name="fromCurrency">The <see cref="Currency"/> model to create this object from.</param>
        /// <param name="multiplyBy">The amount to multiply the given <see cref="Currency"/> amount by.</param>
        public Currency(
            Currency fromCurrency, 
            int multiplyBy)
        {
            this.AmountInPence = fromCurrency.AmountInPence * multiplyBy;
            this.CurrencyCode = fromCurrency.CurrencyCode;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            NumberFormatInfo correctFormat = null;

            if (this.CurrencyCode != null)
            {
                CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

                foreach (CultureInfo currentCulture in cultures)
                {
                    RegionInfo currentRegion = new RegionInfo(currentCulture.LCID);

                    if (currentRegion.ISOCurrencySymbol.Equals(this.CurrencyCode, StringComparison.OrdinalIgnoreCase))
                    {
                        correctFormat = currentCulture.NumberFormat;
                        break;
                    }
                }
            }

            if (correctFormat != null)
            {
                return string.Format(correctFormat, "{0:C}", BaseCost);
            }

            return string.Format("{0:N2}", BaseCost);
        }

        #endregion

    }
}
