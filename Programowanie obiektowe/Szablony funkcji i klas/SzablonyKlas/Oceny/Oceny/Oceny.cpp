#include <iostream>

using namespace std;

template <class T, int n>
class Oceny {
public:
    T oceny[n];

    T max() {
        T temp = oceny[0];
        for (int i = 0; i < n; i++)
        {
            if (oceny[i] > temp)
                temp = oceny[i];
        }
        return temp;
    }

    T min() {
        T temp = oceny[0];
        for (int i = 0; i < n; i++)
        {
            if (oceny[i] < temp)
                temp = oceny[i];
        }
        return temp;
    }
};




int main()
{
    setlocale(LC_ALL, "");

    Oceny<int, 3> oceny{ 3,4,5 };

    cout << "Najwyższa ocena:" << oceny.max() << endl;
    cout << "Najniższa ocena:" << oceny.min() << endl;

    return 0;
}