using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.wisielec
{
    public class Game
    {
        //Pola statyczne - przechowywanie danych 

        static string Haslo;
        static string DziedzinaHasla;
        static char[] PokazHaslo;
        static int LiczbaProb = 4;
        static void Main()
        {

            Console.WriteLine("Witaj w grze wisielec :)");

            TworzenieRozgrywki();

            Napisz();

            bool literaZnaleziona;
            char literaGracza;

            Aktualizacje(out literaGracza, out literaZnaleziona);

            CzyWygranaLubPrzegrana();


        }

        static void TworzenieRozgrywki()
        {
            // Odczytanie listy haseł i dziedziny z pliku

            string plik = @"dziedzina.txt";
            string[] lines = File.ReadAllLines(plik);

            // Wylosowanie danego hasla i ustawienie pola hasła i dziedziny +  wyświetlanie z jakiej dziedziny jest haslo

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

            // Przypisanie wartości do pól statycznych

            Haslo = Hasla[index];
            DziedzinaHasla = Dziedziny[index];

            // Przygotowanie hasla + jego wyświetlanie

            char[] PokazHaslo = new char[Haslo.Length];

            for (int i = 0; i < Haslo.Length; i++)
            {
                PokazHaslo[i] = '_';
            }

            Console.WriteLine(PokazHaslo);
        }

        static void Napisz()
        {
            // Wyświetlanie dziedziny hasla + ilości szans gracza do przegranej

            Console.WriteLine("Dziedzina: " + DziedzinaHasla);

            Console.WriteLine("Ilość szans: " + LiczbaProb);
        }

        static void Aktualizacje(out char literaGracza, out bool literaZnaleziona)
        {
            literaZnaleziona = false;
            bool literaBylaJuzSprawdzana = false;


            Console.WriteLine("Podaj literę:");
            literaGracza = Console.ReadLine()[0];

            char[] PokazHaslo = new char[Haslo.Length];

            for (int i = 0; i < Haslo.Length; i++)
            {
                if (Haslo[i] == literaGracza)
                {
                    PokazHaslo[i] = literaGracza;
                    literaZnaleziona = true;
                    literaBylaJuzSprawdzana = true;
                }
            }
            if (!literaZnaleziona)
            {
                Console.WriteLine("Litera nie występuje w haśle.");
                LiczbaProb--;
            }

            Console.WriteLine("Ilość szans: " + LiczbaProb);
        }


        static void CzyWygranaLubPrzegrana()
        {
            // Jak użytkownik straci zycia to przegrywa

            if (string.Equals(Haslo, new string(PokazHaslo)))
            {
                Console.WriteLine("Gratulacje! Odgadłeś hasło: " + Haslo);
            }
            else
            {
                Console.WriteLine("Przegrałeś! Hasło to: " + Haslo);
            }

            Console.WriteLine("Koniec gry.");
        }

    }
}





