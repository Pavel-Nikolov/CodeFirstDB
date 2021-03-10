using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public class ProductRepo : IDB<Product, string>
    {
        public void Create(Product item)
        {
            using (Context context = new Context())
            {
                Brand brandFromDB = context.Brands.Find(item.Brand.ID);
                if (brandFromDB != null)
                {
                    item.Brand = brandFromDB;
                }
                context.Products.Add(item);
                context.SaveChanges();
            }
            
        }

        public void Delete(string key)
        {
            using (Context context = new Context())
            {
                Product productToBeDeleted = context.Products.Find(key);
                context.Products.Remove(productToBeDeleted);
                context.SaveChanges();
            }
        }

        public ICollection<Product> Find(string index)
        {
            ICollection<Product> products = new List<Product>();
            using (Context context = new Context())
            {
                products = context.Products.Include(x => x.Brand).Where(x => x.Name == index).ToList();
            }
            return products;
        }

        public Product Read(string key)
        {
            Product product;
            using (Context context = new Context())
            {
                product = context.Products.Include(x=>x.Brand).SingleOrDefault(x => x.Barcode == key);
                
            }
            if (product == null)
            {
                throw new ArgumentException("No such product");
            }
            return product;
        }

        public ICollection<Product> ReadAll()
        {
            ICollection<Product> products = new List<Product>();
            using (Context context = new Context())
            {
                products = context.Products.Include(p => p.Brand).ToList();
            }
            return products;
        }

        public void Update(Product item)
        {
            using (Context context = new Context())
            {
                item.Brand = context.Brands.Find(item.Brand.ID);
                context.Entry<Product>(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
