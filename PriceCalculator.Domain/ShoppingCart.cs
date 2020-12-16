using System.Linq;
using System.Collections.Generic;
using System;

namespace PriceCalculator
{
    /// <summary>
    /// An implemetation of shopping Basket
    /// </summary>
    public class ShoppingCart
    {
        IEnumerable<Discount> _applicableDiscounts;
        IList<ProductInCart> _productsInBaskets;

        /// <summary>
        /// Initialiases <see cref="ShoppingCart"/>
        /// </summary>
        /// <param name="applicableDiscounts">List of <see cref="Discount"/> applicable to basket</param>
        public ShoppingCart(IEnumerable<Discount> applicableDiscounts)
        {
            _productsInBaskets = new List<ProductInCart>();
            _applicableDiscounts = applicableDiscounts ?? throw new ArgumentNullException(nameof(applicableDiscounts));

        }

        /// <summary>
        /// Get basket sub total
        /// </summary>
        public decimal SubTotal { get; private set; }

        /// <summary>
        /// Gets <see cref="DiscountOutput"/> after discount is applied
        /// </summary>
        public IEnumerable<DiscountOutput> DiscountsApplied { get; private set; }

        /// <summary>
        /// Gets Total
        /// </summary>
        public decimal Total { get; private set; }

        /// <summary>
        /// Add product to basket
        /// </summary>
        /// <param name="product"><see cref="Product"/> to be added to basket</param>
        public void AddProduct(Product product)
        {
            var productInBasket = _productsInBaskets.FirstOrDefault(x => x.Product.Name == product.Name);
            if (productInBasket != null)
            {
                productInBasket.Quantity++;
            }
            else 
            {
                _productsInBaskets.Add(new ProductInCart() { Product = product, Quantity = 1 });
            }

            SubTotal += product.UnitPrice; 
        }

        /// <summary>
        /// Applying discounts to basket and calculates total 
        /// </summary>
        public void Checkout()
        {
            DiscountsApplied = ApplyDiscount();
            Total = SubTotal -  DiscountsApplied.Sum(d => d.DiscountAmount);
        }

        private IEnumerable<DiscountOutput> ApplyDiscount()
        {
            List<DiscountOutput> output = new List<DiscountOutput>();
            
            foreach (var applicableDiscount in _applicableDiscounts)
            {
                 output.AddRange(applicableDiscount.ApplyDiscount(_productsInBaskets));
            }

            return output;
        }
    }
}
