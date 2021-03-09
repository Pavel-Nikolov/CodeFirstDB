using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Events
{
    public delegate void ProductReadHandler(ProductReadEventArgs args);
    public class ProductReadEventArgs : EventArgs
    {
        public string Barcode { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string BrandName { get; set; }

        public ProductReadEventArgs(string barcode, string name, int quantity, decimal price, string brandName)
        {
            Barcode = barcode;
            Name = name;
            Quantity = quantity;
            Price = price;
            BrandName = brandName;
        }
    }
}
