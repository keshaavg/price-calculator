using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PriceCalculator.Tests
{
    public class BuyXGetYPercentageFreeShould
    {
        [Theory]
        [InlineData("", "Milk")]
        [InlineData("    ", "Milk")]
        [InlineData(null, "Milk")]
        [InlineData("Milk", "")]
        [InlineData("Milk", "  ")]
        [InlineData("Milk", null)]
        public void Throws_ArgumentNullException_ForNullOrEmptyProduct(string productName, string productQualifiesForDiscount)
        {
            // Arrange + Act + Assert
            Assert.Throws<ArgumentNullException>(() => new BuyXGetPercentageFree(productName, productQualifiesForDiscount, 2, 0.10m));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1.1)]
        public void Throws_ArgumentOutOfRangeException_ForPercentageLessThanZero_OrGreaterThan1(decimal percentage)
        {
            // Arrange + Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new BuyXGetPercentageFree("Milk", "Bread", 2, percentage));
        }

        [Fact]
        public void AppliesNoDiscount_ForNonApplicableProduct()
        {
            // Arrange
            var sut = new BuyXGetPercentageFree("Bread", "Beans", 2,  0.50m);
            var _productsInCart = new List<ProductInCart>()
            {
                new ProductInCart() { Product =  new Product("Milk", 1.30M), Quantity = 2},
                new ProductInCart() { Product =  new Product("Bread", .80M), Quantity = 1}
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
            var sut = new BuyXGetPercentageFree("Bread", "Beans", 2, 0.50m);
            var _productsInCart = new List<ProductInCart>()
            {
                new ProductInCart() { Product =  new Product("Beans", 1.30M), Quantity = 2},
                new ProductInCart() { Product =  new Product("Bread", .80M), Quantity = 1}
            };

            // Act
            var result = sut.ApplyDiscount(_productsInCart);

            // Assert
            Assert.Single(result);
            Assert.Equal(.40M, result.First().DiscountAmount);
        }

        [Fact]
        public void AppliesDiscount_ToReleventProduct_ForMoreThanOneOneProduct()
        {
            // Arrange
            var sut = new BuyXGetPercentageFree("Bread", "Beans", 2, 0.50m);
            var _productsInCart = new List<ProductInCart>()
            {
                new ProductInCart() { Product =  new Product("Beans", 1.30M), Quantity = 2},
                new ProductInCart() { Product =  new Product("Bread", .80M), Quantity = 1},
                new ProductInCart() { Product =  new Product("Apples", 1.00M), Quantity = 1},
            };

            // Act
            var result = sut.ApplyDiscount(_productsInCart);

            // Assert
            Assert.Single(result);
            Assert.Equal(.40M, result.First().DiscountAmount);
        }


        [Theory]
        [InlineData(2, 2, 1, 0.5, 0.4)]
        [InlineData(2, 3, 1, 0.5, 0.4)]
        [InlineData(2, 4, 1, 0.5, 0.4)]
        [InlineData(2, 4, 2, 0.5, 0.8)]
        [InlineData(2, 6, 3, 0.5, 1.2)]
        [InlineData(3, 3, 1, 0.5, .4)]
        [InlineData(3, 6, 2, 0.5, .8)]
        public void AppliesDiscount_BuyXGetYPercentageFree(int x, int quantityX, int quantityY, decimal percentage, decimal expected )
        {
            // Arrange
            var sut = new BuyXGetPercentageFree("Bread", "Beans", x, percentage);
            var _productsInCart = new List<ProductInCart>()
            {
                new ProductInCart() { Product =  new Product("Beans", 1.30M), Quantity = quantityX},
                new ProductInCart() { Product =  new Product("Bread", .80M), Quantity = quantityY}
            };

            // Act
            var result = sut.ApplyDiscount(_productsInCart);

            // Assert
            Assert.Single(result);
            Assert.Equal(expected, result.First().DiscountAmount);
        }
    }
}
