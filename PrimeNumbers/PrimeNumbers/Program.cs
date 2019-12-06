using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vítáme vás u našeho projektu, který rozluští váš vstup zdali je prvočíslo");
            Console.WriteLine("Vaše číslo musí být z množiny kladných celých čísel jinak to nebude prvo číslo");
            Console.WriteLine("Zadejte vaše číslo pro kontrolu zdali je prvočíslo");
            string input = " ";
            int number;
            bool res = true;
            List<int> PrvoCisla = new List<int> { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 197, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 809, 811, 821, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997 };

            do // cyklus který ošetří vstup ať je celočíselný
            {
                input = Console.ReadLine();
                res = int.TryParse(input, out number);
                if (res != true)
                {
                    Console.WriteLine("Zadal jsi špatný vstup prosím zadej číslo");
                }
            }
            while (res != true);

            if (number <= 1000)
            {
                if (number == PrvoCisla.Find(item => item == number)) // Podmínka zjistí zdali prvočíslo do tisíce se nacházází v listu
                {
                    Console.WriteLine("Tvoje číslo " + number + " je prvočíslo");
                }
                else
                    Console.WriteLine("Tvoje číslo " + number + " není prvočíslo");

                Console.WriteLine("K vyřešení bylo použito vyhledávání v listu prvočísel.");
            }
            else
            {
                ErastotenovoSito es = new ErastotenovoSito();
                if(es.JeToPrvoCislo(number)) // Vratí true nebo false o vyřešení čísla
                    Console.WriteLine("Tvoje číslo " + number + " je prvočíslo");
                else
                    Console.WriteLine("Tvoje číslo " + number + " není prvočíslo");

                Console.WriteLine("K vyřešení byla použita metoda Eratosthenova síta.");
            }

            Console.ReadKey();
        }
    }

    public class ErastotenovoSito
    {
        //zjisti, zdali zadane cele cislo je prvo cislo a nasledne vypise pouzitou metodu reseni
        public bool JeToPrvoCislo(int cislo)
        {
            bool jePrvocilo = false;

            List<int> prvoCisla = ListPrvocisel(cislo);
            foreach (int c in prvoCisla)
            {
                if (c == cislo)
                    jePrvocilo = true;
            }

            return jePrvocilo;
        }

        public List<int> ListPrvocisel(int po)
        {
            //vytvorit list cisel mezi 2 - po
            List<int> prvocisla = new List<int>();
            for (int i = 2; i <= po; i++)
                prvocisla.Add(i);

            //nechat pouze prvocisla
            for (int c = 0; c < prvocisla.Count; c++)
            {
                //zkontrolovat deleni pomoci aktualniho cisla
                for (int i = 0; i < prvocisla.Count; i++)
                {
                    if (prvocisla[c] != 0 && prvocisla[c] != prvocisla[i] && (float)prvocisla[i] % (float)prvocisla[c] == 0)
                        prvocisla[i] = 0;
                }
            }

            return prvocisla;
        }
    }
}
