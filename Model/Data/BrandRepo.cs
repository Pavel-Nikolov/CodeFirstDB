using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public class BrandRepo : IDB<Brand, int>
    {
        public void Create(Brand item)
        {
            using (Context context = new Context())
            {
                context.Brands.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int key)
        {
            Brand Deleted;
            using (Context context = new Context())
            {
                Deleted = context.Brands.Find(key);
                if (Deleted == null)
                {
                    throw new ArgumentException("No such element");
                }
                context.Entry<Brand>(Deleted).State = EntityState.Deleted;
                context.SaveChanges();
            }


        }

        public ICollection<Brand> Find(string index)
        {
            using (Context context = new Context())
            {
                return context.Brands.Include(p => p.Products).Where(x => x.Name == index).ToList();
            }
        }

        public Brand Read(int key)
        {
            Brand brandFromBb;
            using (Context context = new Context())
            {
                brandFromBb = context.Brands.Include(p => p.Products).Single(x => x.ID == key);
                if (brandFromBb == null)
                {
                    throw new ArgumentException("No Such Object");
                }
                
            }
            return brandFromBb;
        }

        public ICollection<Brand> ReadAll()
        {
            using (Context context = new Context())
            {
                return context.Brands.Include(p => p.Products).ToList();
            }
        }

        public void Update(Brand item)
        {
            using (Context context = new Context())
            {
                context.Entry<Brand>(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
