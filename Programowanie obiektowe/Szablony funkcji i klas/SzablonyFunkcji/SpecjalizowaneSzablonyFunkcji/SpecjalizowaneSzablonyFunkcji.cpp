#include <iostream>
using namespace std;

template <typename T>
T srednia(T matematyka, T polski, T angielski, T fizyka)
{
    return (matematyka + polski + angielski + fizyka) / 4;
}

template <>
double srednia(double matematyka, double polski, double angielski, double fizyka)
{
    return (round(matematyka) 
            + round(polski)
            + round(angielski) 
            + round(fizyka) ) / 4;
}

template <>
float srednia(float matematyka, float polski, float angielski, float fizyka)
{
    return (round(matematyka)
        + round(polski)
        + round(angielski)
        + round(fizyka)) / 4;
}

int main()
{
    setlocale(LC_ALL, "");

    cout << "1. Średnia z ocen: " << srednia(3, 4, 5, 5) << endl;
    cout << "2. Średnia z ocen: " << srednia<double>(3, 4, 5, 5) << endl;
    cout << "3. Średnia z ocen: " << srednia(3.0, 4.0, 5.0, 5.0) << endl;

}