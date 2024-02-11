using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Nawigacja_Stos.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        public Car() { }
        public Car(int id, string brand, string model, string color, int year, int mileage, double price, string image)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Color = color;
            Year = year;
            Mileage = mileage;
            Price = price;
            Image = image;
        }
    }
}
