using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_w_kosci
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int iloscKostek = 0;
			Console.WriteLine("Gra w kości");
			do
			{
				Console.WriteLine("Ile kostek chcesz rzucić? (3 - 10):");
				iloscKostek = Convert.ToInt32(Console.ReadLine());

				if(iloscKostek < 3 || iloscKostek > 10)
				{
					Console.WriteLine("Nie odpowiednia liczba kostek, wybierz jeszcze raz");
				}
			} while (iloscKostek < 3 || iloscKostek > 10);

			//Pętla programowa
			char kolejneLosowanie;
			do
			{
				List<int> wylosowaneLiczby = RzutKostkami(iloscKostek);

				for (int i = 0; i<iloscKostek; i++)
				{
					Console.WriteLine($"Kostka {i+1}: {wylosowaneLiczby[i]}");
				}

				Console.WriteLine($"Liczba uzyskanych punktów: {PoliczPunkty(wylosowaneLiczby)}");

				try
				{
					Console.WriteLine("Jeszcze raz ? (t/n)");
					kolejneLosowanie = Convert.ToChar(Console.ReadLine());
				}
				catch (Exception ex) {
					kolejneLosowanie = 'n';
				}
			} while (kolejneLosowanie == 't');

			Console.WriteLine("Dziękujemy za grę, aby zamknąć aplikację naciśnij dowolny klawisz");
			Console.ReadKey();

		}

		/***************************************************************************
			nazwa:				RzutKostkami
			opis:				Metoda losuje liczby z zakresu 1..6 w ilości przekazanej w parametrze
								metody i zwraca wylosowane liczby w postaci listy
			parametry:			typ int o nazwie iloscKostek przekazuje informację ile wylosować liczb
			zwracany typ i opis:List<int> lista wylosowanych liczb typu int w zakresie 1..6
			autor:				00000000000
		 ****************************************************************************/
		static List<int> RzutKostkami(int iloscKostek)
		{
			List<int> wylosowaneLiczby = new List<int>();
			Random r = new Random();

			for(int i = 0; i < iloscKostek; i++)
			{
				wylosowaneLiczby.Add(r.Next(1,7));
			}
			return wylosowaneLiczby;
		}

		static int PoliczPunkty(List<int> wylosowaneLiczby)
		{
			int sumaPunktow = 0;
			//Tablica pomocnicza w której zlicza się ilość wystąpień danej liczby
			//Rozmiar 7 ponieważ: pomijany będzie index 0, a wykorzystywany index 6
			int[] wielokrotnosci = new int[7];

			//Pętla która zlicza ilość wystąpień danej liczby oczek
			foreach(int x in wylosowaneLiczby)
			{
				++wielokrotnosci[x];
			}
			//Pętla która zlicza sumę oczek jeżeli dana liczba oczek wystąpiła więcej niż raz
			for(int i =1; i<7; i++)
			{
				if (wielokrotnosci[i] > 1)
					sumaPunktow += (i * wielokrotnosci[i]);
			}

			return sumaPunktow;
		}
	}
}
