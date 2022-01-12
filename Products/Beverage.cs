using System;

namespace AssigmentStore.Products.Contracts
{
    public class Beverage : Product, IPerishable
    {
        public Beverage(string name, string brand, double price, double quantity, DateTime expirationDate) : base(name, brand, price, quantity)
        {
            this.ExpirationDate = expirationDate;
        }
        public DateTime ExpirationDate { get; set; }
    }
}
