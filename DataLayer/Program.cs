using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sets all Object Method txt files to default
            DataProcessor dp = new DataProcessor(@"\Setup\");
            dp.Load();
            dp.SetAllFormatsToDefault();
            Console.WriteLine("Done");
            Console.ReadKey();
        }

    }
}
