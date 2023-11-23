
#include <iostream>
using namespace std;

template <typename T>
T poleProstokata(T a, T b)
{
    return a * b;
}

template <typename T>
T obwodProstokata(T a, T b)
{
    return 2 * a + 2 * b;
}

int main()
{
    setlocale(LC_ALL, "");

    float bokA = 2.5;
    float bokB = 3.7;

    cout << "Pole prostokąta : " << poleProstokata<int>(bokA, bokB) << endl;
    cout << "Obwód prostokąta:" << obwodProstokata<int>(bokA, bokB) << endl;
    cout << endl;

    cout << "Pole prostokąta : " << poleProstokata(bokA, bokB) << endl;
    cout << "Obwód prostokąta:" << obwodProstokata(bokA, bokB) << endl;

}

