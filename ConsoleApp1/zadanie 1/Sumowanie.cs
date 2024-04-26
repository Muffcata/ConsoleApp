using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.zadanie_1
{
    internal class Sumowanie
    {
        public void SumowanieMethod()
        {
            Console.WriteLine("Podaj liczbę całkowitą...");

            int num = Convert.ToInt32(Console.ReadLine());
            int suma = 0;

            for (int i = 1; i <= num; i++)
            {
                suma += i;
            }

            Console.WriteLine($"Suma liczb od 1 do {num} wynosi: {suma}");
            Console.ReadLine();

            //List<int> list = new List<int>();

            //list.Add(0);
            //list.Add(1);
            //list.Add(2);
            //list.Add(3);
            //list.Add(4);

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i] + list[0]);
            //}
            //Console.ReadLine();

            //Console.WriteLine(list[1]);

            //Console.ReadLine();

            List<int> list = new List<int>();

            list.Add(12);
            list.Add(14);
            list.Add(2);
            list.Add(33);
            list.Add(45);

            Console.WriteLine("Podaj liczbę...");
            int userNum = Convert.ToInt32(Console.ReadLine());

            bool finder = false;

            foreach (int li in list)
            {
                if (li == userNum)
                {
                    finder = true;
                    break;
                }
            }

            switch (finder)
            {
                case true:

                    Console.WriteLine($"Liczba {userNum} znajduje się w liście.");
                    break;

                case false:

                    Console.WriteLine($"Liczba {userNum} nie została znaleziona w liście.");
                    break;
            }

            Console.ReadLine();

        }
    }
}

