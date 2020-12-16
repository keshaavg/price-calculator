using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator
{
    /// <summary>
    /// Implements <see cref="BuyXGetPercentageFree"/> discount strategy 
    /// </summary>
    public class BuyXGetPercentageFree : Discount
    {
        
        private readonly int _quantityX;
        private readonly decimal _percentage;
        private string _productQualifiesForDiscount;

        /// <summary>
        /// Initialiases <see cref="BuyXGetPercentageFree"/>
        /// </summary>
        /// <param name="productName">Product name for which this discount applies</param>
        /// <param name="productQualifiesForDiscount">Product that qualifies this discount</param>
        /// <param name="x">Number of items for discount can be applicable</param>
        /// <param name="percentage">Percentage discount</param>
        public BuyXGetPercentageFree(string productName, string productQualifiesForDiscount, int x, decimal percentage) : base(productName)
        {
            if (string.IsNullOrWhiteSpace(productQualifiesForDiscount)) throw new ArgumentNullException(nameof(productQualifiesForDiscount));
            if (percentage < 0 || percentage > 1) throw new ArgumentOutOfRangeException(nameof(percentage));
            _quantityX = x;
            _percentage = percentage;
            _productQualifiesForDiscount = productQualifiesForDiscount;
        }

        /// <summary>
        /// Methood to apply discount
        /// </summary>
        /// <param name="items">Product basket for which discount is applied</param>
        /// <returns><see cref="DiscountOutput"/></returns>
        public override IEnumerable<DiscountOutput> ApplyDiscount(IEnumerable<ProductInCart> items)
        {
            List<DiscountOutput> discountOutputs = new List<DiscountOutput>();
            var discountApplicable = items.FirstOrDefault(x => x.Product.Name == _productQualifiesForDiscount && x.Quantity >= _quantityX);
            if (discountApplicable != null)
            {
                foreach (var item in items)
                {
                    if (item.Product.Name == ProductName)
                    {
                        var discountFactor = Math.Min((int) Math.Ceiling((decimal)discountApplicable.Quantity / _quantityX), item.Quantity); 
                        var amount = Math.Round((item.Product.UnitPrice * discountFactor) * _percentage, 2);
                        var dicountOutput = new DiscountOutput()
                        {
                            DisplayText = $"Buy {_quantityX} {_productQualifiesForDiscount} Get {item.Product.Name} {_percentage:P0} OFF:",
                            DiscountAmount = amount
                        };

                        discountOutputs.Add(dicountOutput);
                    }
                }
            }

            return discountOutputs;
        }
    }
}
