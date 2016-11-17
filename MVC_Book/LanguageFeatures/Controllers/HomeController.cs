﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }
        public ViewResult AutoProperty()
        {
            Product product = new Product();
            product.Name = "Kayak";
            string productName = product.Name;
            return View("Result", (object)String.Format("Product Name: {0}", productName));
        }
        public ActionResult CreateProduct()
        {
            Product product = new Product();
            product.ProductID = 100;
            product.Name = "Kayak";
            product.Description = "A boat for one person";
            product.Price = 275M;
            product.Category = "Watersports";

            return View("Result", (object)String.Format($"Category: {product.Category}"));
        }
        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };

            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> myDict = new Dictionary<string, int> { { "apple", 10 }, { "orange", 20 }, { "plum", 30 } };

            return View("Result", (object)stringArray[1]);
        }
        public ViewResult UseExtension()
        {
            // create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product> {
                                new Product {Name = "Kayak", Price = 275M},
                                new Product {Name = "Lifejacket", Price = 48.95M},
                                new Product {Name = "Soccer ball", Price = 19.50M},
                                new Product {Name = "Corner flag", Price = 34.95M}
                                }
            };

            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object)String.Format("Total: {0:c}", cartTotal));


        }
        public ActionResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                                    new Product {Name = "Kayak", Price = 275M},
                                    new Product {Name = "Lifejacket", Price = 48.95M},
                                    new Product {Name = "Soccer ball", Price = 19.50M},
                                    new Product {Name = "Corner flag", Price = 34.95M}
                                    }
            };
            // create and populate an array of Product objects
            Product[] productArray = {
                        new Product {Name = "Kayak", Price = 275M},
                        new Product {Name = "Lifejacket", Price = 48.95M},
                        new Product {Name = "Soccer ball", Price = 19.50M},
                        new Product {Name = "Corner flag", Price = 34.95M}
                        };
            // get the total value of the products in the cart
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = products.TotalPrices();

            return View("Result",(object)String.Format("Cart Total: {0}, Array Total: {1}", cartTotal, arrayTotal));
        }
        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                        new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                        new Product {Name = "Lifejacket", Category = "Watersports",Price = 48.95M},
                        new Product {Name = "Soccer ball", Category = "Soccer",Price = 19.50M},
                        new Product {Name = "Corner flag", Category = "Soccer",Price = 34.95M}

                        }
            };
            decimal total = 0;
            foreach (Product prod in products.FilterByCategory("Soccer"))
            {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total: {0}", total));
        }
        public ViewResult UseFilterExtensionMethodWithDelegate()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                        new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                        new Product {Name = "Lifejacket", Category = "Watersports",Price = 48.95M},
                        new Product {Name = "Soccer ball", Category = "Soccer",Price = 19.50M},
                        new Product {Name = "Corner flag", Category = "Soccer",Price = 34.95M}

                        }
            };
            Func<Product, bool> SelectorParam = delegate (Product product) { return product.Category == "Soccer"; }; // Or Lambda:
            //Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";
            //OR more abstract => 
            /*foreach (Product prod in products.Filter(prod => prod.Category == "Soccer")) {
            total += prod.Price;
            }*/
            decimal total = 0;
            foreach (Product prod in products.Filter(SelectorParam))
            {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total: {0}", total));
        }
    }


}