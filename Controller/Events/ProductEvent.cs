using Model;
using System;

namespace Controller.Events
{
    public delegate void ProductReadHandler(ProductReadEventArgs args);
    public class ProductReadEventArgs : EventArgs
    {
        public string Barcode { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public BrandReadEventArgs Brand { get; set; }

        public ProductReadEventArgs(Product product, bool loadConnection = false)
        {
            Barcode = product.Barcode;
            Name = product.Name;
            Quantity = product.Quantity;
            Price = product.Price;
            if (loadConnection)
            {
                Brand = new BrandReadEventArgs(product.Brand);
            }
        }

        public override string ToString()
        {
            return $"Barcode: {Barcode}, Name: {Name}, Quantity: {Quantity}, Price: {Price:C}";
        }
    }
}
