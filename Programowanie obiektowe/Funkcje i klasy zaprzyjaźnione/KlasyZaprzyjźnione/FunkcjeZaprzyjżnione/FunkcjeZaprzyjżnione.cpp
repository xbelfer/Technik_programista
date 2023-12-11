
#include <iostream>
#include <string>


using namespace std;
class Pracownik;

string infoPracownik(const Pracownik *pr);

class Pracownik
{
private: 
    string imie;
    string nazwisko;
    string stanowisko;
    int placa;
public:
    Pracownik(string imie, string nazwisko, string stanowisko, int placa)
    {
        this->imie = imie;
        this->nazwisko = nazwisko;
        this->stanowisko = stanowisko;
        this->placa = placa;
    }
    friend string infoPracownik(const Pracownik *pr);
};

string infoPracownik(const Pracownik *pr)
{
    string ret = "\nImie: " + pr->imie;
    ret += "\nNazwisko: " + pr->nazwisko;
    ret += "\nStanowisko: " + pr->stanowisko;
    ret += "\nPłaca: " + to_string(pr->placa);
    return ret;
}

int main()
{
    setlocale(LC_ALL, "");
    Pracownik p1("Jan", "Kowalski", "magazynier", 2400);

    cout<<infoPracownik(&p1);
}

