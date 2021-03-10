using Controller.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    static class Print
    {
        public static void PrintBrand(BrandReadEventArgs args)
        {
            Console.WriteLine(args);
            if (args.Products.Count > 0)
            {
                Console.WriteLine("Product info");
                foreach (ProductReadEventArgs item in args.Products)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
        }

        internal static void PrintUser(UserReadEventArgs args)
        {
            Console.WriteLine(args);
            if (args.Products.Count > 0) 
            {
                Console.WriteLine("Product info");
                foreach (ProductReadEventArgs item in args.Products)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
        }

        public static void PrintProduct(ProductReadEventArgs args)
        {
            Console.WriteLine(args);
            if (args.Brand != null)
            {
                Console.WriteLine("Brand info:");
                Console.WriteLine(args.Brand);
            }
            Console.WriteLine();
        }

        
    }
}
