using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public static class MyExtentionMethod//Changed to IEnumerable<> 
    {
        public static decimal TotalPrices(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;
            foreach (Product product in productEnum)
            {
                total += product.Price;
            }
            return total;
        }
        public static IEnumerable<Product> FilterByCategory(this IEnumerable<Product> ProductEnum, string categoryParam)
        {
            foreach (Product product in ProductEnum)
            {
                if (product.Category == categoryParam)
                {
                    yield return product;
                }
            }
        }
        public static IEnumerable<Product> Filter(this IEnumerable<Product> ProductEnum, Func<Product,bool> SelectorParam)
        {
            foreach (Product product in ProductEnum)
            {
                if (SelectorParam(product)) //calls delegate that is declared in HomeController and passed through "Func<Product,bool> SelectorParam"
                {
                    yield return product;
                }
            }
        } 
    }
}