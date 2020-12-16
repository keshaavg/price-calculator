namespace PriceCalculator
{
    /// <summary>
    /// Define <see cref="DiscountOutput"/>
    /// </summary>
    public class DiscountOutput
    {
        /// <summary>
        /// Gets or sets Display text for discount
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// Gets or sets calculated discount amount
        /// </summary>
        public decimal DiscountAmount { get; set; }
    }
}