#include <iostream>
using namespace std;
/*
*  struct Nazwa{
*       typ1  składowa1;
*       typ2  składowa2;
*       ...
*  }
* 
*  Można także strukturę zdefiniować jako nowy typ:
* 
*  typedef struct Nazwa{
*      //definicja struktury
*  } Nazwa_typu;
* 
*  Deklaracja zmiennych strukturalnych:
* 
*  struct Nazwa a,b;  -> w ten sposób w języku C i C++
*  Nazwa c,d;  -> w taki sposób tylko w języku C++
* 
*  Można także połączyć definicje struktury z deklaracją zmiennych strukturalnych np:
* 
*  struct Osoba{
*     char imie[30];
*     char nazwisko[30];
*     int wiek;
*  }o1,o2;
* 
* Odwołania do zmiennych strukturalnych:
* 
* struct Osoba o1;
* 
* o1.imie = "Janek";
* 
* struct Osoba *wsk;
* wsk = &o1;
* 
* wsk->wiek = 18;
* 
*/
int main()
{
    setlocale(LC_ALL, "");

    struct Uczen {
        char imie[30];
        char nazwisko[30];
        char klasa[10];
        double srednia;
    };
    
    struct Uczen u1;
    Uczen u2;
    Uczen* wsk;

    cout << "Wpisz imie ucznia:" << endl;
    cin >> u1.imie;
    cout << "Wpisz nazwisko ucznia: " << endl;
    cin >> u1.nazwisko;
    cout << "Wpisz klasę:" << endl;
    cin >> u1.klasa;
    cout << "Wpisz średnią ucznia:" << endl;
    cin >> u1.srednia;

    wsk = &u1;

    cout << "Dane ucznia:" << endl;
    cout << "Imie: " << wsk->imie << endl;
    cout << "Nazwisko: " << wsk->nazwisko << endl;
    cout << "Klasa: " << wsk->klasa << endl;
    cout << "Srednia: " << wsk->srednia << endl;

}

