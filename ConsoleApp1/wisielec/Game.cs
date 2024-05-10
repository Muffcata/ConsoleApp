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
            int liczbaSzans = 4;
            Console.WriteLine("Witaj w grze wisielec :)");
            (string wylosowaneHaslo, string wylosowanaDziedzina) = TworzenieRozgrywki();

            Console.WriteLine("Dziedzina: " + wylosowanaDziedzina);

            char[] pokazHaslo = Napisz(wylosowaneHaslo);
            Console.WriteLine();
            Console.WriteLine($"Twoje próby: {liczbaSzans} ");

            while (true)
            {
                // Wypisanie aktualnego stanu ukrytego hasła
                Console.WriteLine("\nHasło: " + new string(pokazHaslo));

                // Wywołanie funkcji Aktualizacje() i aktualizacja ukrytego hasła
                Aktualizacje(pokazHaslo);

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
                pokazHaslo[i] = (wylosowaneHaslo[i] == ' ') ? ' ' : '_';
            }
            return pokazHaslo;

            
        }


        static void Aktualizacje(char[] pokazHaslo)
        {
            Console.WriteLine("Podaj literę jaką chcesz sprawdzić:");
            char literaUzytkownika = Console.ReadKey().KeyChar;
            Console.WriteLine();

            int index = -1;
            for (int i = 0; i < pokazHaslo.Length; i++)
            {
                if (pokazHaslo[i] == '_')
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                pokazHaslo[index] = literaUzytkownika;
            }
        }
    }
}




