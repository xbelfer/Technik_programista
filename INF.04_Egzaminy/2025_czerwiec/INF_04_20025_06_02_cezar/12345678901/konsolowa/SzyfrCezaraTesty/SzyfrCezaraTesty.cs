using NUnit.Framework;
using SzyfrCezara; 


public class SzyfrCezaraTesty
{
	private KlasaSzyfrCezara _szyfrCezara;

	// Metoda uruchamiana przed każdym testem (lub raz przed wszystkimi w przypadku [OneTimeSetUp])
	[SetUp]
	public void UstawieniaPoczatkowe()
	{
		_szyfrCezara = new KlasaSzyfrCezara();
	}

	// Nr testu: 1
	// Cel: Dane podstawowe (klucz dodatni, wartość mniejsza od długości alfabetu)
	[Test]
	public void Test_01_Szyfrowanie_DanePodstawowe()
	{
		// ARRANGE (Przygotowanie danych)
		string tekstJawny = "abc";
		int klucz = 3;
		string oczekiwanyWynik = "def";

		// ACT (Wykonanie działania)
		string rzeczywistyWynik = _szyfrCezara.SzyfrujCezarem(tekstJawny, klucz);

		// ASSERT (Weryfikacja wyniku)
		Assert.AreEqual(oczekiwanyWynik, rzeczywistyWynik, "Szyfrowanie podstawowe nie działa prawidłowo.");
	}

	// Nr testu: 2
	// Cel: "Zawijanie" (gdy litery w tekście i klucz wychodzą poza alfabet)
	[Test]
	public void Test_02_Szyfrowanie_Zawijanie()
	{
		// ARRANGE
		string tekstJawny = "xyz";
		int klucz = 3;
		string oczekiwanyWynik = "abc";

		// ACT
		string rzeczywistyWynik = _szyfrCezara.SzyfrujCezarem(tekstJawny, klucz);

		// ASSERT
		Assert.AreEqual(oczekiwanyWynik, rzeczywistyWynik, "Zawijanie poza alfabet nie działa prawidłowo.");
	}

	// Nr testu: 3
	// Cel: Odszyfrowanie (klucz ujemny)
	[Test]
	public void Test_03_Odszyfrowanie_KluczUjemny()
	{
		// ARRANGE
		string tekstJawny = "def";
		int klucz = -3;
		string oczekiwanyWynik = "abc";

		// ACT
		string rzeczywistyWynik = _szyfrCezara.SzyfrujCezarem(tekstJawny, klucz);

		// ASSERT
		Assert.AreEqual(oczekiwanyWynik, rzeczywistyWynik, "Odszyfrowanie kluczem ujemnym nie działa prawidłowo.");
	}

	// Nr testu: 4
	// Cel: Klucz większy niż długość alfabetu
	[Test]
	public void Test_04_Szyfrowanie_KluczWiekszyNizRozmiarAlfabetu()
	{
		// ARRANGE
		string tekstJawny = "abc";
		// Klucz 29 jest równoważny kluczowi 3 (29 % 26 = 3)
		int klucz = 29;
		string oczekiwanyWynik = "def";

		// ACT
		string rzeczywistyWynik = _szyfrCezara.SzyfrujCezarem(tekstJawny, klucz);

		// ASSERT
		Assert.AreEqual(oczekiwanyWynik, rzeczywistyWynik, "Obsługa klucza większego niż 26 nie działa prawidłowo.");
	}

	// Nr testu: 5
	// Cel: Spacja w tekście
	[Test]
	public void Test_05_Szyfrowanie_ZeSpacja()
	{
		// ARRANGE
		string tekstJawny = "ab cd";
		int klucz = 2;
		string oczekiwanyWynik = "cd ef";

		// ACT
		string rzeczywistyWynik = _szyfrCezara.SzyfrujCezarem(tekstJawny, klucz);

		// ASSERT
		Assert.AreEqual(oczekiwanyWynik, rzeczywistyWynik, "Obsługa spacji w tekście nie działa prawidłowo.");
	}

	
}
