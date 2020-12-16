using System;
using System.Collections.Generic;

namespace PriceCalculator
{
    /// <summary>
    /// Implements <see cref="PercentageOffDiscount"/> discount strategy 
    /// </summary>
    public class PercentageOffDiscount : Discount
    {
        private readonly decimal _percentage;

        /// <summary>
        /// Initialiases <see cref="PercentageOffDiscount"/>
        /// </summary>
        /// <param name="productName">Product name for which this discount applies</param>
        /// <param name="percentage">Percentage discount</param>
        public PercentageOffDiscount(string productName, decimal percentage): base(productName)
        {
            if (percentage < 0 || percentage > 1) throw new ArgumentOutOfRangeException(nameof(percentage));
            _percentage = percentage;

        }

        /// <summary>
        /// Methood to apply discount
        /// </summary>
        /// <param name="items">Product basket for which discount is applied</param>
        /// <returns><see cref="DiscountOutput"/></returns>
        public override IEnumerable<DiscountOutput> ApplyDiscount(IEnumerable<ProductInCart> items)
        {
            List<DiscountOutput> discountOutputs = new List<DiscountOutput>();
            foreach (var item in items)
            {
                if (item.Product.Name == ProductName)
                {
                    var amount = Math.Round((item.Product.UnitPrice * item.Quantity) * _percentage, 2);
                    var dicountOutput = new DiscountOutput()
                    {
                        DisplayText = $"{item.Product.Name} {_percentage:P0} OFF:",
                        DiscountAmount = amount
                    };

                    discountOutputs.Add(dicountOutput);
                }
            }

            return discountOutputs;
        }
    }
}
