using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablicaObiektoSamochod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Samochod[] samochody = new Samochod[4];

            string marka, model, kolor;
            int rocznik, przebieg;
            double cena;

            for(int i = 0;  i < samochody.Length; i++)
            {
                Console.WriteLine($"Wpisz dane samochodu do tablicy pod index: {i}");
                Console.WriteLine("Wpisz markę:");
                marka = Console.ReadLine();
                Console.WriteLine("Wpisz model:");
                model = Console.ReadLine();
                Console.WriteLine("Wpisz kolor:");
                kolor = Console.ReadLine();
                Console.WriteLine("Wpisz rocznik:");
                rocznik = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Wpisz przebieg:");
                przebieg = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Wpisz cenę:");
                cena = Convert.ToDouble(Console.ReadLine());

                samochody[i] = new Samochod(marka, model, kolor, przebieg, rocznik, cena);
                Console.Clear();
            }

            for(int i=0; i < samochody.Length; i++)
            {
                Console.WriteLine($"Samochód o indeksie {i}");
                Console.WriteLine(samochody[i].PobierzDane());
            }

            //Poszukiwanie samochodu o najniższej cenie
            Samochod samochodMinCena = samochody[0];

            for(int i = 1; i < samochody.Length; i++)
            {
                if (samochody[i].Cena < samochodMinCena.Cena)
                {
                    samochodMinCena = samochody[i];
                }
            }

            Console.WriteLine("Samochód o najniższej cenie:");
            Console.WriteLine(samochodMinCena.PobierzDane());
            Console.ReadKey();

        }
    }
}
