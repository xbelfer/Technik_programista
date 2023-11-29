#include <iostream>

using namespace std;

template <class T>
class Prostokat {
public:
    T bok1, bok2;

    T pole()
    {
        return bok1 * bok2;
    }

    T obwod();
};

template <class T>
T Prostokat<T>::obwod()
{
    return 2 * bok1 + 2 * bok2;
}


int main()
{
    setlocale(LC_ALL, "");

    Prostokat<float> prostokat1 { 1, 2 };   

    cout << "Pole wynosi: " << prostokat1.pole() << endl;
    cout << "Obwód wynosi: " << prostokat1.obwod() << endl;

    Prostokat<double> prostokat2{ 1.0, 2.0 };

    cout << "Pole wynosi: " << prostokat2.pole() << endl;
    cout << "Obwód wynosi: " << prostokat2.obwod() << endl;

    return 0;
}
