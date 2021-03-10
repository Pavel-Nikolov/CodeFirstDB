using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public class UserRepo : IDB<User, int>
    {
        public void Create(User item)
        {
            using (Context context = new Context())
            {
                Product productFromDb;
                List<Product> products = item.Products.ToList();
                for (int i = 0; i < products.Count; i++)
                {
                    productFromDb = context.Products.Find(products[i].Barcode);
                    if (productFromDb != null)
                    {
                        products[i] = productFromDb;
                    }
                }
                item.Products = products;
                context.Users.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int key)
        {
            using (Context context = new Context())
            {
                User userToBeDeleted = context.Users.Find(key);
                context.Users.Remove(userToBeDeleted);
                context.SaveChanges();
            }
        }

        public ICollection<User> Find(string index)
        {
            using (Context context = new Context())
            {
                return context.Users.Include(p => p.Products).Where(x => x.Name == index).ToList();
            }
        }

        public User Read(int key)
        {
            using (Context context = new Context())
            {
                return context.Users.Include(p => p.Products).Single(x=>x.ID == key);                
            }
        }

        public ICollection<User> ReadAll()
        {
            using (Context context = new Context())
            {
                return context.Users.Include(p => p.Products).ToList();
            }
        }

        public void Update(User item)
        {
            using (Context context = new Context())
            {
                Product productFromDb;
                List<Product> products = item.Products.ToList();
                for (int i = 0; i < products.Count; i++)
                {
                    productFromDb = context.Products.Find(products[i].Barcode);
                    if (productFromDb != null)
                    {
                        products[i] = productFromDb;
                    }
                }
                item.Products = products;
                //context.Users.Attach(item);
                //context.Entry<User>(item).Collection(p => p.Products).Load();
                //context.Entry<User>(item).State = EntityState.Modified;
                //context.SaveChanges();

                User userFromDb = context.Users.Include(p => p.Products).Single(x => x.ID == item.ID);
                context.Entry<User>(userFromDb).CurrentValues.SetValues(item);
                userFromDb.Products = item.Products;
                context.SaveChanges();
            }
        }
    }
}
