using System;

namespace PriceCalculator.App
{
    public static class StringExtensionMethod
    {
        public static string ToCurrencyString(this decimal value)
        {
            return value < 1 ? $"{Convert.ToInt32(Math.Round(value, 2) * 100)}p" : $"{value:C}";
        }
    }
}
