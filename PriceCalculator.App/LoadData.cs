using System.Collections.Generic;

namespace PriceCalculator.App.Data
{
    /// <summary>
    /// helper Class to initial product and applicable discount data, this can be easily 
    /// configured and loaded from database
    /// </summary>
    public static class LoadData
    {
        /// <summary>
        /// initialises product
        /// </summary>
        public static IEnumerable<Product> Products = new List<Product>
        {
            new Product("Beans", .65M),
            new Product("Bread", .80M),
            new Product("Milk", 1.30M),
            new Product("Apple", 1.00M),
        };


        /// <summary>
        /// Initialises Applicable <see cref="Discount"/> for <see cref="Product"/>
        /// </summary>
        public static IEnumerable<Discount> Discounts = new List<Discount>
        {
            new BuyXGetPercentageFree("Bread", "Beans", 2, .5M),
            new PercentageOffDiscount("Apple", .10M) 
        };
    }
}
