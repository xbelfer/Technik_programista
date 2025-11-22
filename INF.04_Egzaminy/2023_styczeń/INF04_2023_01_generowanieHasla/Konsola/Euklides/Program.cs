using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euklides
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int a, b, nwd;

			try
			{
				Console.WriteLine("Program obliczający NWD");
				Console.WriteLine("Wpisz pierwszą liczbę:");
				a = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Wpisz drugą liczbę:");
				b = Convert.ToInt32(Console.ReadLine());
				nwd = EuklidesNWD(a, b);
				Console.WriteLine($"NWD z liczb {a} i {b} = {nwd}");
				Console.ReadKey();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		/*******************************************************************************
		nazwa funkcji:		 EuklidesNWD
		opis funkcji:		 Funkcja oblicza największy wspólny dzielnik z liczb całkowitych
							 przekazanych przez argument
		parametry:			 a int pierwszy liczba z której wyznaczane jest NWD
							 b int druga liczba z której wyznaczane jest NWD

		zwracany typ i opis: int zwracany jest największy wspólny dzielnik z liczb a i b
		autor:				 00000000000
		 *********************************************************************************/
		static int EuklidesNWD(int a, int b)
		{
			while (a != b)
			{
				if (a > b)
					a = a - b;
				else
					b = b - a;
			}

			return a;
		}
	}
}
