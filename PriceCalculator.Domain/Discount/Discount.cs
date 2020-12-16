using System;
using System.Collections.Generic;

namespace PriceCalculator
{
    /// <summary>
    /// Defines base class for discount strategy 
    /// </summary>
    public abstract class Discount
    {

        /// <summary>
        /// Initialiases <see cref="Discount"/>
        /// </summary>
        /// <param name="productName">Product name for which discount applies</param>
        public Discount(string productName)
        {
            if(string.IsNullOrWhiteSpace(productName)) throw new ArgumentNullException(nameof(productName));
            ProductName = productName;
        }

        /// <summary>
        /// Methood to apply discount
        /// </summary>
        /// <param name="items">Product basket for which discount is applied</param>
        /// <returns><see cref="DiscountOutput"/></returns>
        public abstract IEnumerable<DiscountOutput> ApplyDiscount(IEnumerable<ProductInCart> items);

        /// <summary>
        /// Gets Product name for which discount applies
        /// </summary>
        public virtual string ProductName { get; private set; }
    }
}