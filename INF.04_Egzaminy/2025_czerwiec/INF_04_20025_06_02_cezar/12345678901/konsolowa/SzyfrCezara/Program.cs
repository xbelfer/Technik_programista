using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrCezara
{
	public class Program
	{
		static void Main(string[] args)
		{
			string tekstJawny;
			string tekstZakodowany;
			int klucz;
			KlasaSzyfrCezara klasaSzyfrCezara = new KlasaSzyfrCezara();

			Console.WriteLine("Wpisz tekst do zakodowania:");
			tekstJawny = Console.ReadLine();
			Console.WriteLine("Wpisz klucz kodujący");
			klucz = Convert.ToInt32(Console.ReadLine());

			tekstZakodowany = klasaSzyfrCezara.SzyfrujCezarem(tekstJawny, klucz);

			Console.WriteLine("Zakodowany tekst:");
			Console.WriteLine(tekstZakodowany);

			Console.ReadKey();
		}
	}
}
