#include <iostream>

using namespace std;

union Towar
{
	float waga;
	int wysokosc;
	int szerokosc;
};

int main()
{
	setlocale(LC_ALL, "");

	union Towar t1;

	t1.waga = 24.5;

	cout << "Waga: " << t1.waga << endl;
	cout << "wysokosc: " << t1.wysokosc << endl;
	cout << "Szerokosc: " << t1.szerokosc << endl;

	t1.wysokosc = 66;

	cout << "Waga: " << t1.waga << endl;
	cout << "wysokosc: " << t1.wysokosc << endl;
	cout << "Szerokosc: " << t1.szerokosc << endl;

	//W unii wszystkie składowe obiektu umieszczane są pod tym samym adresem. 
	//Zatem w każdej chwili dostępna jest tylko jedna składowa.
}
