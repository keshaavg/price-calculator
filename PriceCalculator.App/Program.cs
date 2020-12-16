using PriceCalculator.App.Data;
using System;
using System.Linq;

namespace PriceCalculator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputProducts = args;
                if (inputProducts == null || inputProducts.Length == 0)
                {
                    Console.WriteLine($"No products enetered,  Please enter products with spaces, " +
                        $"Available products {string.Join(' ', LoadData.Products.Select(x => x.Name))}");

                    inputProducts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }

                var shoppingCart = new ShoppingCart(LoadData.Discounts);

                foreach (var inputProduct in inputProducts)
                {
                    var product = LoadData.Products.FirstOrDefault(x => x.Name.ToLower() == inputProduct.ToLower());
                    if (product == null)
                    {
                        throw new ArgumentException("Invalid product name entered");
                    }

                    shoppingCart.AddProduct(product);
                }
                shoppingCart.Checkout();
                var discounts = shoppingCart.DiscountsApplied;
                Console.WriteLine("SubTotal: " + $"{shoppingCart.SubTotal.ToCurrencyString()}");
                if (discounts.Any())
                {
                    discounts.ToList().ForEach(d =>
                            Console.WriteLine($"{d.DisplayText} - {d.DiscountAmount.ToCurrencyString()}"));
                }
                else
                {
                    Console.WriteLine("(No offers available)");
                }
                
                Console.WriteLine($"Total Price: {shoppingCart.Total.ToCurrencyString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
