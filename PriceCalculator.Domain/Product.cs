namespace PriceCalculator
{
    /// <summary>
    /// Define product attibutes
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initialiases <see cref="Product"/>
        /// </summary>
        /// <param name="name">Name of product</param>
        /// <param name="unitPrice">unit price of product</param>
        public Product(string name, decimal unitPrice)
        {
            Name = name;
            UnitPrice = unitPrice;
        }

        /// <summary>
        /// Gets product name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets unit price for product
        /// </summary>
        public decimal UnitPrice { get; private set; }
    }
}