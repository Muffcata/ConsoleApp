namespace ConsoleApp1.zadanie_1
{
    internal class Przywitanie
    {
        public void PrzywitanieMethod()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.ResetColor();

            Console.WriteLine("Jak masz na imie?");
            Console.ForegroundColor = ConsoleColor.Green;
            string tytul = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine("Jakie masz marzenie?");
            Console.ForegroundColor = ConsoleColor.Green;
            string tytul1 = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine($"Witaj {tytul} Mam nadzieję ze uda Ci się {tytul1}");

            Console.WriteLine("Podaj masę:");
            Console.ForegroundColor = ConsoleColor.Green;
            float weight = float.Parse(Console.ReadLine());
            Console.ResetColor();
            Console.WriteLine("Jaki masz wzrost?");
            Console.ForegroundColor = ConsoleColor.Green;
            float height = float.Parse(Console.ReadLine());
            Console.ResetColor();

            double bmi = weight / Math.Pow(height, 2);
            bmi = Math.Round(bmi, 3);
            Console.WriteLine($"BMI ={bmi}");

        }
    }
}
