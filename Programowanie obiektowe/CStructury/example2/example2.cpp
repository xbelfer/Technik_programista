#include <iostream>
using namespace std;

struct Uczen {
    char imie[30];
    char nazwisko[30];
    char klasa[10];
    double srednia;
};

void dodajUcznia(struct Uczen *wsk);
void wyswietlUcznia(struct Uczen* wsk);

int main()
{
    setlocale(LC_ALL, "");

    Uczen uczniowie[4];
    double maxSr;
    int iMax;

    //dodajUcznia(&u1);
    //wyswietlUcznia(&u1);

    for (int i = 0; i < 4; i++)
    {
        dodajUcznia(&uczniowie[i]);
    }

    maxSr = uczniowie[0].srednia;
    iMax = 0;

    for (int i = 1; i < 4; i++)
    {
        if (uczniowie[i].srednia > maxSr)
        {
            maxSr = uczniowie[i].srednia;
            iMax = i;
        }
    }

    cout << "Uczeń o największej średniej" << endl;
    wyswietlUcznia(&uczniowie[iMax]);

}

void dodajUcznia(struct Uczen* wsk)
{
    cout << "Wpisz imie ucznia:" << endl;
    cin >> wsk->imie;
    cout << "Wpisz nazwisko ucznia: " << endl;
    cin >> wsk->nazwisko;
    cout << "Wpisz klasę:" << endl;
    cin >> wsk->klasa;
    cout << "Wpisz średnią ucznia:" << endl;
    cin >> wsk->srednia;
}
void wyswietlUcznia(struct Uczen* wsk)
{
    cout << "Dane ucznia:" << endl;
    cout << "Imie: " << wsk->imie << endl;
    cout << "Nazwisko: " << wsk->nazwisko << endl;
    cout << "Klasa: " << wsk->klasa << endl;
    cout << "Srednia: " << wsk->srednia << endl;
}