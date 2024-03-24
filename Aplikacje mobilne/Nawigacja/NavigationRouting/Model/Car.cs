using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationRouting.Model
{
	public class Car
	{
		public string Marka { get; set; }
		public string Model { get; set; }
		public int Przebieg {  get; set; }
		public int Cena { get; set; }

		public Car(string marka, string model, int przebieg, int cena)
		{
			Marka = marka;
			Model = model;
			Przebieg = przebieg;
			Cena = cena;
		}
	}
}
