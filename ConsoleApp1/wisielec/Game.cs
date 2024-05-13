using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.wisielec
{
    public class Game
    {
        static void Main()
        {

            Console.WriteLine("Witaj w grze wisielec :)");
            (string wylosowaneHaslo, string wylosowanaDziedzina) = TworzenieRozgrywki();

            Console.WriteLine("Dziedzina: " + wylosowanaDziedzina);

            char[] pokazHaslo = Napisz(wylosowaneHaslo, out int liczbaProb);
            Console.WriteLine(pokazHaslo);

            Console.WriteLine("Ilość szans: " + liczbaProb);

            Console.WriteLine("Podaj literę:");

            char literaGracza = Console.ReadLine()[0];

            bool literaZnaleziona;

            Aktualizacje(ref pokazHaslo, wylosowaneHaslo, literaGracza, out literaZnaleziona, out liczbaProb);

            CzyWygranaLubPrzegrana(ref liczbaProb, pokazHaslo, wylosowaneHaslo);

           
        }

        static (string Haslo, string DziedzinaHasla) TworzenieRozgrywki()
        {

            //odczytanie listy haseł i dziedziny z pliku

            string plik = @"dziedzina.txt";
            string[] lines = File.ReadAllLines(plik);

            //wylosowanie danego hasla i ustawienie pola hasła i dziedziny +  wyświetlanie z jakiej dziedziny jest haslo

            var Hasla = new List<string>();
            var Dziedziny = new List<string>();

            foreach (var line in lines)
            {
                var podzial = line.Split('|');

                if (podzial.Length >= 2)
                {
                    string DziedzinaHasla = podzial[0];
                    string Haslo = podzial[1];

                    Dziedziny.Add(DziedzinaHasla);
                    Hasla.Add(Haslo);
                }
            }

            Random haslo = new Random();
            int index = haslo.Next(0, Hasla.Count);

            return (Hasla[index], Dziedziny[index]);

        }

        static char[] Napisz(string wylosowaneHaslo, out int liczbaProb)
        {
            //wyświetlanie ukrytego hasla + ilość szans gracza do przegranej
            liczbaProb = 4;

            char[] pokazHaslo = new char[wylosowaneHaslo.Length];

            for (int i = 0; i < wylosowaneHaslo.Length; i++)
            {
                pokazHaslo[i] = '_';
            }
            return pokazHaslo;

        }

        static void Aktualizacje(ref char[] pokazHaslo, string wylosowaneHaslo, char litera, out bool literaZnaleziona, out int liczbaProb)
        {
            literaZnaleziona = false;
            liczbaProb = 4;

            bool literaBylaJuzSprawdzana = false; 

            for (int i = 0; i < wylosowaneHaslo.Length; i++)
            {
                if (wylosowaneHaslo[i] == litera)
                {
                    pokazHaslo[i] = litera;
                    literaZnaleziona = true;
                    literaBylaJuzSprawdzana = true; 
                }
            }

            if (!literaBylaJuzSprawdzana)
            {
                Console.WriteLine("Litera nie występuje w haśle.");
                liczbaProb--; 
            }

            Console.WriteLine("Ilość szans: " + liczbaProb);
        }


        static void CzyWygranaLubPrzegrana(ref int liczbaProb, char[] pokazHaslo, string wylosowaneHaslo)
        {
            //jak użytkownik straci zycia to przegrywa

            if (string.Equals(wylosowaneHaslo, new string(pokazHaslo)))
            {
                Console.WriteLine("Gratulacje! Odgadłeś hasło: " + wylosowaneHaslo);
            }
            else
            {
                Console.WriteLine("Przegrałeś! Hasło to: " + wylosowaneHaslo);
            }

            Console.WriteLine("Koniec gry.");
        }

    }
}





