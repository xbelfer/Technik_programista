using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eratostenes
{
	internal class Program
	{
		static void Main(string[] args)
		{
			const int N = 100;
			bool[] liczbyPierwsze = new bool[N + 1];
			
			SitoEratostenesa(liczbyPierwsze);
			Console.WriteLine("Liczby pierwsze:");
			for(int i = 2; i < N + 1; i++)
			{
				if (liczbyPierwsze[i])
				{
					Console.Write($"{i}, ");
				}
			}
			Console.WriteLine();
			Console.ReadKey();
		}

		/*****************************************************************************************************
		nazwa metody:			SitoEratostenesa
		parametry wejściowe:	liczbyPierwsze tablica typu bool w pierwszym etapie wypełniana wartościami true,
								następnie zmieniane na wartość false dla indeksów nie będących liczbą pierwszą.
		wartość zwaracana:		brak
		informacje:				Metoda wykorzystując algorytm sita Eratostenesa wypełnia wartości tablicy typu boo
								wartościami true dla indeksów będących liczbami pierwszymi i wartościami false dla
								indeksów nie będących liczbami pierwszymi.
		autor:					00000000000
		 *******************************************************************************************************/
		static void SitoEratostenesa(bool[] liczbyPierwsze)
		{
			int rozmiar = liczbyPierwsze.Length;

			for (int i = 0; i < rozmiar; i++)
			{
				liczbyPierwsze[i] = true;
			}

			for (int i = 2; i < Math.Sqrt(rozmiar); i++)
			{
				if(liczbyPierwsze[i])
				{
					for (int j = 2 * i; j < rozmiar; j = j + i)
						liczbyPierwsze[j] = false;
				}
			}
		}
	}
}
