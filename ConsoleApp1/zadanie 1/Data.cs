using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.zadanie_1
{
    internal class Data
    {
        public void DataMethod()
        {
            DateTime dt = new DateTime(1990, 02, 24);
            DateTime war = new DateTime(1914, 06, 08);

            TimeSpan z = dt - war;
            

            Console.WriteLine("Tyle minęło od wybuchu I wojny światowej do dnia moich urodzin \t {0}", z.TotalDays);
        }
    }
}
