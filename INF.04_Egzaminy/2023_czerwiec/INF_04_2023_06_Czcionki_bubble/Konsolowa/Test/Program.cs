using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();
			int[] liczby = new int[100];
			for (int i = 0; i < liczby.Length; i++)
			{
				liczby[i] = rnd.Next(0,1001);
			}

			Console.WriteLine("Tablica przed sortowaniem:");
			for (int i = 0; i < liczby.Length; i++)
			{
				Console.Write($"{liczby[i]}, ");
			}
			Console.WriteLine();

			BubbleSort(liczby);
			Console.WriteLine("Tablica po sortowaniu:");
			for (int i = 0; i < liczby.Length; i++)
			{
				Console.Write($"{liczby[i]}, ");
			}
			Console.WriteLine();
			Console.ReadKey();

		}

		static void BubbleSort(int[] tab)
		{
			int size = tab.Length;

			for (int j = 0; j < size - 1; j++)
			{
				for (int i = 0; i < size - 1; i++)
				{
					if(tab[i+1] < tab[i])
					{
						int tmp = tab[i];
						tab[i] = tab[i+1];
						tab[i+1] = tmp;
					}
				}
			}
		}
	}
}
