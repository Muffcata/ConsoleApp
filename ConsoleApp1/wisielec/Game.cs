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

            char[] pokazHaslo = Napisz(wylosowaneHaslo);
            Console.WriteLine();

            while (true)
            {
                Aktualizacje(pokazHaslo, wylosowaneHaslo);

                // Sprawdzenie czy hasło zostało odgadnięte
                if (!wylosowaneHaslo.Contains('_'))
                {
                    Console.WriteLine("Gratulacje, odgadłeś hasło!");
                    break; // Zakończ grę
                }
            }
        }

        static (string Haslo, string DziedzinaHasla) TworzenieRozgrywki()
        {

            //odczytanie listy haseł i dziedziny z pliku

            string plik = @"C:\Users\InMoto\OneDrive\Pulpit\dziedzina.txt";
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

        static char[] Napisz(string wylosowaneHaslo)
        {
            //wyświetlanie ukrytego hasla + ilość szans gracza do przegranej
     
            char[] pokazHaslo = new char[wylosowaneHaslo.Length];

            for (int i = 0; i < wylosowaneHaslo.Length; i++)
            {
                pokazHaslo[i] = '_';
            }
            return pokazHaslo;
        }


        static void Aktualizacje(char[] pokazHaslo, string wylosowaneHaslo)
        {
            bool hasloOdgadniete = false;
            int liczbaProb = 5;

            Console.WriteLine($"pozostało szans: {liczbaProb}");

            while (!hasloOdgadniete)
            {
                Console.WriteLine("Aktualne hasło: " + new string(pokazHaslo));
                Console.Write("Podaj literę: ");
                char litera = Console.ReadLine()[0];

                bool literaZgadnieta = false;

                for (int i = 0; i < wylosowaneHaslo.Length; i++)
                {
                    if (wylosowaneHaslo[i] == litera)
                    {
                        pokazHaslo[i] = litera;
                        literaZgadnieta = true;
                    }
                }

                if (literaZgadnieta)
                {
                    Console.WriteLine("Brawo! Zgadłeś literę.");
                }
                else
                {
                    Console.WriteLine("Niepoprawna litera.");
                    liczbaProb--;
                }

                if (new string(pokazHaslo) == wylosowaneHaslo)
                {
                    hasloOdgadniete = true;
                }
            }
        }
    }
}




