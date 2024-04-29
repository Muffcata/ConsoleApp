using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.zadanie_1
{
    internal class Table
    {
        public void TableOfName()
        {
            string[] tablica = new string[5];

            tablica[0] = "Marta";
            tablica[1] = "Maciej";
            tablica[2] = "Monika";
            tablica[3] = "Miłosz";
            tablica[4] = "Mikołaj";

            foreach(string s in tablica)
            {
                Console.WriteLine(s);
            }
            string[] nowaTablica = new string[tablica.Length -1];
        }
    }
}
