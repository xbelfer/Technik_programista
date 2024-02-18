using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSecondExample.Models
{
	public class Student
	{
		public string Imie { get; set; }
		public string Nazwisko { get; set; }
		public string Klasa { get; set; }
		public double Srednia { get; set; }

		public Student(string imie, string nazwisko, string klasa, double srednia)
		{
			Imie = imie;
			Nazwisko = nazwisko;
			Klasa = klasa;
			Srednia = srednia;
		}

		public string PobierzDane()
		{
			string ret = $"Imie:{Imie}";
			ret += $"\nNazwisko:{Nazwisko}";
			ret += $"\nKlasa:{Klasa}";
			ret += $"\nSrednia:{Srednia.ToString()}";
			return ret;
		}
	}
}
