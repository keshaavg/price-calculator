using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PriceCalculator.Tests
{
    public class PercentageOffDiscountShould
    {
        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public void Throws_ArgumentNullException_ForNullOrEmptyProduct(string productName)
        {
            // Arrange + Act + Assert
            Assert.Throws<ArgumentNullException>(() => new PercentageOffDiscount(productName, 0.10m));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1.1)]
        public void Throws_ArgumentOutOfRangeException_ForPercentageLessThanZero_OrGreaterThan1(decimal percentage)
        {
            // Arrange + Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new PercentageOffDiscount("Milk", percentage));
        }

        [Fact]
        public void AppliesNoDiscount_ForNonApplicableProduct()
        {
            // Arrange
            var sut = new PercentageOffDiscount("Apples", 0.10m);
            var _productsInCart = new List<ProductInCart>()
            {
                new ProductInCart() { Product =  new Product("Milk", 1.30M), Quantity = 1}
            };

            // Act
            var result = sut.ApplyDiscount(_productsInCart);

            // Assert
            Assert.False(result.Any());
        }

        [Fact]
        public void AppliesDiscount_ForApplicableProduct()
        {
            // Arrange
            var sut = new PercentageOffDiscount("Apples", 0.10m);
            var _productsInCart = new List<ProductInCart>()
            {
                new ProductInCart() { Product =  new Product("Apples", 1.00M), Quantity = 1}
            };

            // Act
            var result = sut.ApplyDiscount(_productsInCart);

            // Assert
            Assert.Single(result);
            Assert.Equal(.10M, result.First().DiscountAmount);
        }

        [Fact]
        public void AppliesDiscount_ForMoreThanOneApplicableProduct()
        {
            // Arrange
            var sut = new PercentageOffDiscount("Apples", 0.10m);
            var _productsInCart = new List<ProductInCart>()
            {
                new ProductInCart() { Product =  new Product("Apples", 1.00M), Quantity = 2}
            };

            // Act
            var result = sut.ApplyDiscount(_productsInCart);

            // Assert
            Assert.Single(result);
            Assert.Equal(.20M, result.First().DiscountAmount);
        }

        [Fact]
        public void AppliesDiscount_ToReleventProduct_ForMoreThanOneOneProduct()
        {
            // Arrange
            var sut = new PercentageOffDiscount("Apples", 0.10m);
            var _productsInCart = new List<ProductInCart>()
            {
                new ProductInCart() { Product =  new Product("Apples", 1.00M), Quantity = 1},
                new ProductInCart() { Product =  new Product("Milk", 1.30M), Quantity = 1}
            };

            // Act
            var result = sut.ApplyDiscount(_productsInCart);

            // Assert
            Assert.Single(result);
            Assert.Equal(.10M, result.First().DiscountAmount);
        }
    }
}
