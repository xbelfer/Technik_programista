using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesel
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string pesel = "55030101193";

			Console.WriteLine("Wpisz prawidłowy numer pesel (11 cyfr) :");

			pesel = Console.ReadLine();

			char plec = SprawdzPlec(pesel);
			if (plec == 'M')
				Console.WriteLine("To jest numer pesel osoby płci męskiej");
			else if (plec == 'K')
				Console.WriteLine("To jest numer pesel osoby płci żeńskiej");
			else
				Console.WriteLine("Nie można odczytać płci z tego numeru pesel");

			if (SprawdzSumeKontrolna(pesel))
				Console.WriteLine("Suma kontrolna jest zgodna");
			else
				Console.WriteLine("Suma kontrolna się nie zgadza !!!");

			Console.ReadKey();
		}

		/**********************************************************************************
		nazwa metody:			SprawdzPlec
		opis metody:			Metoda ta sprawdza płeć na podstawie numeru pesel przekazanego jako
								argument i zwraca 'M' jeżeli jest to numer mężczyżny lub 'K' jeżeli kobiety
		parametry:				nrPesel - argument typu string przez który przekazujemy numer pesel do sprawdzenia
		zwracany typ i opis:	char przez który zwracamy informację o płci 'M'- mężczyzna, 'K'-kobieta
		autor:					00000000000
		 ************************************************************************************/
		static char SprawdzPlec(string nrPesel)
		{
			char plec = 'M';

			int znaczacaCyfra = Convert.ToInt32(nrPesel[9].ToString());
			if (znaczacaCyfra % 2 == 0)
				plec = 'K';

			return plec;
		}
		static bool SprawdzSumeKontrolna(string nrPesel)
		{

			int S = 0;
			int[] wagi = {1,3,7,9};

			// Można prościej i po kolei sumować ale jak ktoś lubi zgrabny zapis to proszę: 
			for(int i = 0; i < 10; i++)
			{
				S += Convert.ToInt32(nrPesel[i].ToString()) * wagi[i % 4];
			}

			int M = S % 10;
			int R = 0;

			if (M > 0)
				R = 10 - M;

			if (Convert.ToInt32(nrPesel[10].ToString()) == R)
				return true;
			else
				return false;

		}
	}
}
