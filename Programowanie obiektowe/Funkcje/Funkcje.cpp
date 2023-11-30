#include <iostream>
using namespace std;
//deklaracja funckcji 
// 
// typ_zwaracanej_wartości   nazwa_funkcji(typ arg1, typ arg2 ....);
// 
//- deklaracja kończy się średnikiem np:

bool CzyPierwsza(int x);

int main()
{
	setlocale(LC_ALL, "");
	int a;
	cout << "Wpisz liczbę pierwszą:" << endl;
	cin >> a;
	if (CzyPierwsza(a))
		cout << "Wpisałeś prawidłowo liczbę pierwszą" << endl;
	else
		cout << "To nie jest liczba pierwsza" << endl;
}


//definicja funkcji
// typ_zwaracanej_wartości   nazwa_funkcji(typ arg1, typ arg2 ....)
// {
//		instrukcje_definiujące_funkcję;
// 
//      return wyrażenie   - typ wyrażenia zgodny z typem zwracanej wartości
// }
bool CzyPierwsza(int x)
{
	if (x <= 1) 
		return false;
	if (x == 2)
		return true;
	for (int i = 2; i < x; i++)
	{
		if (x % i == 0)
			return false;
	}
	return true;
}

