using System;

namespace AssigmentStore.Products
{
    public class Appliances : Product
    {
        public Appliances(string name, string brand, double price,double quantity, string model,DateTime productionDate,double weight) : base(name, brand, price, quantity)
        {
            this.Model = model;
            this.ProductionDate = productionDate;
            this.Weight = weight;
        }

        public string Model { get; set; }
        public DateTime ProductionDate { get; set; }
        public double Weight { get; set; }

    }
}
