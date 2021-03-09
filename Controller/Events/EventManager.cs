using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Events
{
    public static class EventManager
    {
        public static event BrandReadHandler OnBrandRead;
        public static event ProductReadHandler OnProductRead;
        public static event UserReadHandler OnUserRead;

        

        public static void ReadBrand(Brand brand)
        {
            BrandReadEventArgs args = new BrandReadEventArgs(brand.ID, brand.Name);
            if (OnBrandRead != null)
            {
                OnBrandRead.Invoke(args);
            }
        }

        public static void ReadProduct(Product product)
        {
            ProductReadEventArgs args = new ProductReadEventArgs(
                product.Barcode,
                product.Name,
                product.Quantity,
                product.Price,
                product.Brand.Name);

            if (OnProductRead != null)
            {
                OnProductRead.Invoke(args);
            }
            
        }

        public static void ReadUser(User user)
        {
            UserReadEventArgs args = new UserReadEventArgs(
                user.ID,
                user.Name,
                user.Age);

            if(OnUserRead != null)
            {
                OnUserRead.Invoke(args);
            }
        }
    }
}
