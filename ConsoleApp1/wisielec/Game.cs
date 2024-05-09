using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.wisielec
{

    public class Game
    {
      
        static void Main(string[] args)
        {
            TworzenieRozgrywki();

        }
        
        //static string DziedzinaHaslo;
        //static char[] PokazHaslo;
        //static int LiczbaSzans = 4;
        static void TworzenieRozgrywki()
        {
            string Haslo;
            char[] PokazHaslo;
            //odczytanie listy haseł i dziedziny z pliku

            string plik = @"C:\Users\marta\OneDrive\Pulpit\wisielec-hasla.txt";
            
            //wylosowanie danego hasla i ustawienie pola hasła i dziedziny
           
            string[] lines = File.ReadAllLines(plik);

            var Hasla = new List<string>();

            foreach (var item  in lines)
            {
                var podzial = item.Split('|');

                if (podzial.Length > 0)
                {
                    Haslo = podzial[0];
                    Hasla.Add(Haslo);

                    Random random = new Random();
                    int indexHasla = random.Next(0, Hasla.Count);
                    //string wylosowaneHaslo = Hasla[indexHasla];

                    //Console.WriteLine("Wylosowane hasło: " + wylosowaneHaslo);

                }

              
            }

           

            



            //przygotowanie widocznego hasła
        }

       

        //static void Napisz()
        //{

        //}

        //static void Aktualizacje()
        //{

        //}

        //static void CzyWygranaLubPrzegrana()
        //{

        //}
    }
}


