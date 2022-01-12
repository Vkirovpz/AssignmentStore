using System;
using AssigmentStore.Products.Contracts;
using AssigmentStore.Products;

namespace AssigmentStore
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Exampe input for testing.

            var cashier = new Cashier();
            var cart = new Cart(); 

            var apples = new Food("apple", "BrandA", 1.50, 2.45, new DateTime(2021, 06, 14));
            var milk = new Beverage("milk", "BrandM", 0.99, 3,  new DateTime(2022, 02, 02));
            var tShirt = new Clothes("T-shirt", "BrandT", 15.99, 2, "M", "violet");
            var laptop = new Appliances("laptop", "BrandL", 2345, 1, "ModelL", new DateTime(2021, 03, 03), 1.125);

            cart.products.Add(apples);
            cart.products.Add(milk);
            cart.products.Add(tShirt);
            cart.products.Add(laptop);

            var DateTimeOfPurchase = new DateTime(2021, 06, 14, 12, 34, 56);

            cashier.PrintReceipt(cart, DateTimeOfPurchase);

        }

    }
}
