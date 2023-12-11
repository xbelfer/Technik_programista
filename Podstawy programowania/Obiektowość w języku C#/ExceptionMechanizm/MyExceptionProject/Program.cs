using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExceptionProject
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				UczenDorosly u1 = new UczenDorosly("Jan", "Kowalski", 12);
			}
			catch (MyException ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.ReadKey();
		}
	}

	public class MyException : Exception
	{
		public MyException(string msg) : base(msg)
		{
		}
	}

	class UczenDorosly
	{
		public string Imie { get; set; }
		public string Nazwisko { get; set; }
		public int Wiek { get; set; }

		public UczenDorosly(string imie, string nazwisko, int wiek)
		{
			Imie = imie;
			Nazwisko = nazwisko;
			if (wiek < 18)
			{
				throw (new MyException("Uczeń musi być pełnoletni"));
			}
			else
			{
				Wiek = wiek;
			}
		}
	}
}
