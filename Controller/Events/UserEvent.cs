using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Events
{
    public delegate void UserReadHandler(UserReadEventArgs args);
    public class UserReadEventArgs : EventArgs
    {
        public UserReadEventArgs(int iD, string name, int? age)
        {
            ID = iD;
            Name = name;
            Age = age;
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
        public int? Age { get; private set; }

    }
}
