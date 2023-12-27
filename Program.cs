using System;
using System.Collections.Generic;

namespace Kalkylator
{
    class Kalkylatorn
    {
        private List<string> uträkningsHistorik = new List<string>();

        public void KörKalkylatorn()
        {
            Console.WriteLine("============================");
            Console.WriteLine("Välkommen till Kalkylatorn!");
            Console.WriteLine("============================");

            while (true)
            {
                Console.Write("Ange första talet: ");
                if (!double.TryParse(Console.ReadLine(), out double tal1))
                {
                    Console.WriteLine("Ogiltigt inmatning. Ange ett tal: ");
                    continue;
                }

                Console.Write("Ange en matematisk operation ('+', '-', '*', '/'): ");
                char matteOperator = Console.ReadLine()[0];

                Console.Write("Ange andra talet: ");
                if (!double.TryParse(Console.ReadLine(), out double tal2))
                {
                    Console.WriteLine("Ogiltigt inmatning. Ange ett tal: ");
                    continue;
                }

                if (matteOperator == '/' && tal2 == 0)
                {
                    Console.WriteLine("Ogiltig inmatning. Du kan inte dela med 0");
                    continue;
                }

                double resultat = KalkylatorUträkning(tal1, tal2, matteOperator);
                läggTillHistorik(tal1, tal2, matteOperator, resultat);

                Console.WriteLine($"{tal1} {matteOperator} {tal2} = {resultat}");
                Console.WriteLine();

                Console.WriteLine("Vill du se tidigare resultat? (ja/nej)");
                string inputResultat = Console.ReadLine().ToLower();
                Console.WriteLine();
                if (inputResultat == "ja")
                {
                    VisaResultat();
                    Console.WriteLine();
                }

                Console.WriteLine("Vill du fortsätta med programmet? (ja/nej): ");
                string inputAvsluta = Console.ReadLine().ToLower();
                Console.WriteLine();
                if (inputAvsluta == "nej")
                {
                    return;
                }
            }
        }
        private double KalkylatorUträkning(double tal1, double tal2, char mathOperator)
        {
            switch (mathOperator)
            {
                case '+':
                    return tal1 + tal2;
                case '-':
                    return tal1 - tal2;
                case '*':
                    return tal1 * tal2;
                case '/':
                    return tal1 / tal2;
                default:
                    Console.WriteLine("Ogiltig operation. Försök igen.");
                    return 0;
            }
        }

        private void läggTillHistorik(double tal1, double tal2, char matteOperator, double resultat)
        {
            string uträkning = $"{tal1} {matteOperator} {tal2} = {resultat}";
            uträkningsHistorik.Add(uträkning);
        }

        private void VisaResultat()
        {
            Console.WriteLine("Tidigare resultat: ");
            foreach (string uträkning in uträkningsHistorik)
            {
                Console.WriteLine(uträkning);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Kalkylatorn kalkylator = new Kalkylatorn();
            kalkylator.KörKalkylatorn();
        }
    }
}
