using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablicaObiektoSamochod
{
    public class Samochod
    {
        public string Marka {  get; set; }
        public string Model { get; set; }
        public string Kolor { get; set; }
        public int Przebieg { get; set; }
        public int Rocznik { get; set; }
        public double Cena { get; set; }

        public Samochod(string marka, string model, string kolor, int przebieg, int rocznik,  double cena)
        {
            Marka = marka;
            Model = model;
            Kolor = kolor;
            Przebieg = przebieg;
            Cena = cena;
            Rocznik = rocznik;
        }

        public string PobierzDane()
        {
            string dane;

            dane = $"\nMarka: {Marka}";
            dane += $"\nModel: {Model}";
            dane += $"\nKolor: {Kolor}";
            dane += $"\nPrzebieg: {Przebieg}";
            dane += $"\nRocznik: {Rocznik}";
            dane += $"\nCena: {Cena}";

            return dane;
        }
    }
}
