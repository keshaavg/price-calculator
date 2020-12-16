namespace PriceCalculator
{
    /// <summary>
    /// Defines products in shopping basket
    /// </summary>
    public class ProductInCart
    {
        /// <summary>
        /// gets <see cref="Product"/>
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Total quantity requested for product
        /// </summary>
        public int Quantity { get; set; }
    }
}