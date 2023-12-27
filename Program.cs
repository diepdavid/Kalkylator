namespace Kalkylator
{
    internal class Program
    {
        static List<string> uträkningsHistorik = new List<string>();

        static void Main(string[] args)
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

                string uträkning = $"{tal1} {matteOperator} {tal2} = {resultat}";
                uträkningsHistorik.Add(uträkning);

                Console.WriteLine(uträkning);
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

        static double KalkylatorUträkning(double tal1, double tal2, char mathOperator)
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

        static void VisaResultat()
        {
            Console.WriteLine("Tidigare resultat: ");
            foreach (string uträkning in uträkningsHistorik)
            {
                Console.WriteLine(uträkning);
            }
        }

    }
}
