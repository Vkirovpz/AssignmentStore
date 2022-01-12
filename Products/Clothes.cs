

namespace AssigmentStore.Products
{
    public class Clothes : Product
    {
        public Clothes(string name, string brand, double price, double quantity, string size, string color) : base(name, brand, price, quantity)
        {
            this.Size = size;
            this.Color = color;
        }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
