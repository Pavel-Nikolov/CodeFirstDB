using Model;

namespace Controller.Events
{
    public static class EventManager
    {
        public static event BrandReadHandler OnBrandRead;
        public static event ProductReadHandler OnProductRead;
        public static event UserReadHandler OnUserRead;

        

        public static void ReadBrand(Brand brand)
        {
            BrandReadEventArgs args = new BrandReadEventArgs(brand, true);
            if (OnBrandRead != null)
            {
                OnBrandRead.Invoke(args);
            }
        }

        public static void ReadProduct(Product product)
        {
            
            ProductReadEventArgs args = new ProductReadEventArgs(product, true);

            if (OnProductRead != null)
            {
                OnProductRead.Invoke(args);
            }
            
        }

        public static void ReadUser(User user)
        {
            UserReadEventArgs args = new UserReadEventArgs(user, true);

            if(OnUserRead != null)
            {
                OnUserRead.Invoke(args);
            }
        }
    }
}
