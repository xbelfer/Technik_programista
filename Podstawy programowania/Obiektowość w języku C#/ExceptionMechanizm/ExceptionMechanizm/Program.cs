 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionMechanizm
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int x, y, z;

			try
			{
				Console.WriteLine("Wpisz liczbę całkowitą x:");
				x = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Wpisz liczbę całkowitą y:");
				y = Convert.ToInt32(Console.ReadLine());

				z = x / y;
				Console.WriteLine($"Wynik dzielenia {x}/{y} = {z}");

			}
			catch (FormatException ex)
			{
				Console.WriteLine($"Musisz wprowadzić liczby całkowite: {ex.Message}");
			}
			catch (DivideByZeroException ex)
			{
				Console.WriteLine($"Nie wolno dzielić przez zero: {ex.Message}");
			}

			Console.ReadKey();
		}
	}
}
