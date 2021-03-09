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

        public BrandReadEventArgs(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public override string ToString()
        {
            return $"ID: {this.ID}, Name: {this.Name}";
        }
    }
}
