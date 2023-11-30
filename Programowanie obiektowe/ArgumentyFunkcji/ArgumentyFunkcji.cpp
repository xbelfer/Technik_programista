#include <iostream>
using namespace std;

void Testowa(int x);
void Testowa2(int* x);

int main()
{
	setlocale(LC_ALL, "");
	int a = 5;

	cout << "1. a = " << a << endl;
	Testowa(a);
	cout << "2. a = " << a << endl;
	Testowa2(&a);
	cout << "3. a = " << a << endl;

}

/* Wjęzyku c++ argumenty do funkcji są domyślnie przekazywane przez wartość.
*  Dlatego zmienne z którymi są wywoływane funkcje (jako arguementy) nie są modyfikowane
*  wewnątrz tej funkcji.
*/
void Testowa(int x)
{
	cout << "1. x = " << x << endl;
	x = x + 3;
	cout << "2. x = " << x << endl;
}

/* Aby zmodyfikować zmienną przekazaną jako argument musimy przekazać ją jako adres i funkcja
 operując na zmiennej wskaźnikowej może zmodyfikować tą zmienną z którą funkcja została wywołana*/

void Testowa2(int* x)
{
	cout << "1. *x = " << *x << endl;
	*x = *x + 3;
	cout << "2. *x = " << *x << endl;
}


