using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Samochod> samochody = new List<Samochod>();
            char koniec = 't';
            string marka, model, kolor;
            int rocznik, przebieg;
            double cena;
            int i = 0;

            do
            {
                Console.Clear();
                Console.WriteLine($"Wpisz dane samochodu do tablicy pod index: {i++}");
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

                samochody.Add(new Samochod(marka, model, kolor, przebieg, rocznik, cena));

                Console.WriteLine("Czy chcesz zakończyć wproawdzanie t/n ?");
                koniec = Convert.ToChar(Console.ReadLine());
            } while (koniec != 't');


            for(i = 0; i<samochody.Count; i++)
            {
                Console.WriteLine(samochody[i].PobierzDane());
            }

            Console.ReadKey();
        }
    }
}
