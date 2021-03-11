using Model;
using System;
using System.Collections.Generic;

namespace Controller.Events
{
    public delegate void UserReadHandler(UserReadEventArgs args);
    public class UserReadEventArgs : EventArgs
    {
        public UserReadEventArgs(User user, bool loadConnection = false)
        {
            ID = user.ID;
            Name = user.Name;
            Age = user.Age;
            if (loadConnection)
            {
                Products = new List<ProductReadEventArgs>();
                foreach (Product item in user.Products)
                {
                    Products.Add(new ProductReadEventArgs(item));
                }
            }
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
        public int? Age { get; private set; }

        public ICollection<ProductReadEventArgs> Products { get; set; }

        public override string ToString()
        {
            return $"Id: {ID}, Name: {Name}, Age: {ToStringNullable(Age)}";
        }

        private static string ToStringNullable(int? age)
        {
            if (age.HasValue)
            {
                return age.Value.ToString();
            }
            return "N/A";
        }
    }
}
