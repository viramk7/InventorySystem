using Resources.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Resources.Utility.ResourceBuilder();
            string filePath = builder.Create(new DbResourceProvider(@"data source=DESKTOP-07TA8EG;initial catalog=InventorySystemDB;user id=sa;password=sit@123"),
                summaryCulture: "en-us");

            Console.WriteLine("Created file {0}", filePath);
        }
    }
}
