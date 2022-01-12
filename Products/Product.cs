namespace AssigmentStore.Products
{
    public abstract class Product
    {
        protected Product(string name, string brand, double price, double quantity)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name { get; set; }

        public string Brand { get; set; }

        public double Price { get; set; }

        public double Quantity { get; set; }
    }
}
