using PriceCalculator.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PriceCalculator.Tests
{
    public class ShoppingCartShould
    {
        [Fact]
        public void Throws_ArgumentNullException_ForNullApplicableDiscount()
        {
            // Arrange + Act + Assert
            Assert.Throws<ArgumentNullException>(() => new ShoppingCart(null));
        }

        [Fact]
        public void AddProduct_AndReturnSubTotal()
        {
            // Arrange
            var sut = new ShoppingCart(new List<Discount>());
            
            // Act
            sut.AddProduct(new Product("Milk", 1.30M));

            // Assert
            Assert.Equal(1.30M, sut.SubTotal);
        }

        [Fact]
        public void Checkout_TotalWithNoDiscount()
        {
            // Arrange
            var sut = new ShoppingCart(new List<Discount>());

            // Act
            sut.AddProduct(new Product("Milk", 1.30M));
            sut.AddProduct(new Product("Beans", .80M));
            sut.Checkout();

            // Assert
            Assert.Equal(2.10M, sut.SubTotal);
            Assert.Equal(2.10M, sut.Total);
        }

        [Fact]
        public void Checkout_TotalWithDiscount()
        {
            // Arrange
            var sut = new ShoppingCart(LoadData.Discounts);

            // Act
            sut.AddProduct(new Product("Apples", 1.30M));
            sut.AddProduct(new Product("Beans", .80M));
            sut.Checkout();

            // Assert
            Assert.Equal(2.10M, sut.SubTotal);
            Assert.Single(sut.DiscountsApplied);
            Assert.Equal(.13M, sut.DiscountsApplied.First().DiscountAmount);
            Assert.Equal(1.97M, sut.Total);
        }
    }
}
