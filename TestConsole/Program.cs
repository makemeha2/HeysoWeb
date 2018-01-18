using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var currDate = DateTime.Now.ToString("yyyy-MM-dd");

            var yyyy = currDate.Substring(0, 4);
            var mm = currDate.Substring(5, 2);
            var dd = currDate.Substring(8, 2);

            Console.WriteLine(string.Format("{0}-{1}-{2}", yyyy, mm, dd));
            Console.ReadLine();
        }
    }
}
