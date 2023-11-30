#include <iostream>
#include <cmath>
using namespace std;

template <class T>

class Oceny {
public:
    Oceny()
    {
        cout << "konstruktor klasy ogólnej...." << endl;
    }

    T wyklad, cwiczenia, laboratorium, seminarium;

    T srednia() {
        return (wyklad + cwiczenia + laboratorium + seminarium) / 4;
    }
};

template <> class
Oceny<double> {
public:
    Oceny()
    {
        cout << "konstruktor klasy specjalizowanej...." << endl;
    }

    double wyklad, cwiczenia, laboratorium, seminarium;

    double srednia() {
        return (round(wyklad) + round(cwiczenia) + round(laboratorium) + round(seminarium)) / 4;
    }
};
int main()
{
    setlocale(LC_ALL, "");

    Oceny<int> oceny1 = Oceny<int>();

    oceny1.wyklad = 3;
    oceny1.cwiczenia = 4;
    oceny1.laboratorium = 5;
    oceny1.seminarium = 3;

    cout << "Średnia ocen semestralnych:" << oceny1.srednia() << endl;

    Oceny<double> oceny2 = Oceny<double>();

    oceny2.wyklad = 3.0;
    oceny2.cwiczenia = 4.0;
    oceny2.laboratorium = 5.0;
    oceny2.seminarium = 3.0;

    cout << "Średnia ocen semestralnych:" << oceny2.srednia() << endl;
}
