using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzyfrCezaraApp
{
	public class KlasaSzyfrCezara
	{
		public string SzyfrujCezarem(string tekst, int klucz)
		{
			// Używamy StringBuilder do efektywnego budowania zaszyfrowanego tekstu
			StringBuilder zaszyfrowanyTekst = new StringBuilder();

			// Stałe oparte na założeniach
			const int RozmiarAlfabetu = 26;
			const int KodAsciiA = 97; // 'a' w ASCII

			// Krok 1: Normalizacja klucza
			// Zapewnia, że klucz mieści się w zakresie [0, 25] lub [-25, 0], 
			// co ułatwia obliczenia modulo
			// Jeśli klucz jest np. 27, kluczEfektywny = 1
			// Jeśli klucz jest np. -30, kluczEfektywny = -4
			int kluczEfektywny = klucz % RozmiarAlfabetu;

			// Krok 2: Iteracja po każdym znaku w tekście jawnym
			foreach (char znak in tekst)
			{
				// Sprawdzenie, czy znak jest spacją (założenie: spacja pozostaje bez zmian)
				if (znak == ' ')
				{
					zaszyfrowanyTekst.Append(' ');
					continue;
				}

				// Sprawdzenie, czy znak jest małą literą alfabetu łacińskiego ('a' do 'z')
				if (znak >= 'a' && znak <= 'z')
				{
					// Krok 3: Konwersja litery na indeks (0 dla 'a', 25 dla 'z')
					int indeksPoczatkowy = znak - KodAsciiA;

					// Krok 4: Obliczenie nowego indeksu po przesunięciu
					int indeksPrzesuniety = indeksPoczatkowy + kluczEfektywny;

					// Krok 5: Zastosowanie operacji modulo do zawinięcia (cykliczność)
					// Użycie modulo dla języków programowania, które mogą zwrócić ujemny wynik 
					// dla ujemnej liczby:

					// a) Dla klucza dodatniego (np. k=3):
					// ('x' -> 23) + 3 = 26. (26 % 26) = 0. Indeks 0 to 'a'. OK.

					// b) Dla klucza ujemnego (np. k=-3):
					// ('a' -> 0) + (-3) = -3. W C# -3 % 26 = -3. NIEPOPRAWNE, powinno być 23 ('x').
					// Należy dodać RozmiarAlfabetu, aby wynik był nieujemny przed ostatecznym modulo.

					// Wzór: ((indeks + kluczEfektywny) % RozmiarAlfabetu + RozmiarAlfabetu) % RozmiarAlfabetu
					int indeksZaszyfrowany = (indeksPrzesuniety % RozmiarAlfabetu + RozmiarAlfabetu) % RozmiarAlfabetu;

					// Krok 6: Konwersja zaszyfrowanego indeksu z powrotem na znak ASCII
					char zaszyfrowanyZnak = (char)(indeksZaszyfrowany + KodAsciiA);

					// Dodanie zaszyfrowanego znaku do wyniku
					zaszyfrowanyTekst.Append(zaszyfrowanyZnak);
				}
				else
				{
					// Opcjonalnie: Znak nie jest małą literą ani spacją.
					// Można go pominąć lub zostawić bez zmian, zgodnie z bardziej szczegółowymi założeniami.
					// W tej implementacji, jeśli nie jest małą literą ani spacją, pozostaje niezmieniony.
					zaszyfrowanyTekst.Append(znak);
				}
			}

			// Zwrócenie zaszyfrowanego tekstu jako string
			return zaszyfrowanyTekst.ToString();
		}
	}
}
