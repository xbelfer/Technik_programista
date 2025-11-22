using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teksty
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string testowy;

			Console.WriteLine("Aplikacja testująca metody operujące na tekstach");
			Console.WriteLine("Wpisz tekst w którym chcesz policzyć ilość występujących samogłosek:");
			testowy = Console.ReadLine();
			int ileSamoglosek = Przybornik.PoliczSamogloski(testowy);
			Console.WriteLine($"W podanym teście znajduje się {ileSamoglosek} samogłosek");
			Console.WriteLine("Wpisz tekst w którym chcesz wyeliminować powtarzające się po sobie znaki");
			testowy= Console.ReadLine();
			testowy = Przybornik.UsunPowtorzeniaZnakow(testowy);
			Console.WriteLine($"Tekst po wyeliminowaniu powtórzeń: {testowy}");
			Console.ReadKey();
		}
	}
}
