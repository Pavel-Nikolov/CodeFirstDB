using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Events
{
    public delegate void BrandReadHandler(BrandReadEventArgs args);
    public class BrandReadEventArgs:EventArgs
    {
        public int ID { get;private set; }
        public string Name { get;private set; }
        public ICollection<ProductReadEventArgs> Products { get; set; }

        public BrandReadEventArgs(Brand brand, bool loadConnection = false)
        {
            ID = brand.ID;
            Name = brand.Name;
            if (loadConnection)
            {
                Products = new List<ProductReadEventArgs>();
                foreach (Product item in brand.Products)
                {
                    Products.Add(new ProductReadEventArgs(item));
                }
            }
        }

        public override string ToString()
        {
            return $"ID: {this.ID}, Name: {this.Name}";
        }
    }
}
