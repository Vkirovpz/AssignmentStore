using System.Collections.Generic;
using AssigmentStore.Products;

namespace AssigmentStore
{
    public class Cart
    {
        public IList<Product> products;
        public Cart()
        {
            this.products = new List<Product>();
        }
    }
}

