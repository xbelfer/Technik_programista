using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teksty
{
	/*****************************************************************************************************
	 * klasa:	Przybornik
	 * opis:	Klasa ta jest klasą narzędziową, posiada metody operujące na tekstach. Jedna z metod 
	 *			zlicza ilość wystąpień samogłosek w tekście a druga metoda eliminuje powtórzenia znaków
	 *			występujące po sobie
	 * metody:  PoliczSamogloski - oczekuje jako argumentu ciągu znakowego typu string i zwraca wartość całkowitą 
	 *			reprezentującą ilość samogłosek w tym ciągu
	 *			UsunPowtorzeniaZnakow - oczekuje jako argumentu ciągu znakowego typu string i zwraca zmodyfikowany
	 *			łańcuch typu string w którym wyeliminowano powtórzenia znaków
	 * autor:	00000000000
	 ****************************************************************************************************/
	public class Przybornik
	{
		public static int PoliczSamogloski(string inputTxt)
		{
			string samogloski = "aąeęiouóyAĄEĘIOUÓY";
			int licznikSamoglosek = 0;

			if(string.IsNullOrEmpty(inputTxt))
				return 0;

			for(int i = 0; i<inputTxt.Length; i++)
			{
				if (samogloski.Contains(inputTxt[i]))
					++licznikSamoglosek;
			}

			return licznikSamoglosek;
		}

		public static string UsunPowtorzeniaZnakow(string inputTxt)
		{
			string retTxt = "";

			if (string.IsNullOrEmpty(inputTxt))
				return inputTxt;

			retTxt += inputTxt[0];
			for (int i = 1; i<inputTxt.Length; i++)
			{
				if (inputTxt[i] == inputTxt[i - 1])
					continue;
				retTxt += inputTxt[i];
			}
			return retTxt;
		}
	}
}
