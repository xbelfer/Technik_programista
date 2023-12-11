
#include <iostream>
using namespace std;

template <typename T>
void BubleSort(T *tab, int size)
{
    for (int j = 0; j < size - 1; j++)
    {
        for (int i = 0; i < size - 1; i++)
        {
            if (tab[i] > tab[i + 1])
            {
                T temp = tab[i];
                tab[i] = tab[i+1];
                tab[i + 1] = temp;
            }
        }
    }
}

template <typename T>
void DisplayTab(T* tab, int size)
{
    for (int i = 0; i < size; i++)
    {
        cout << tab[i] << ", ";
    }
    cout << endl;
}



int main()
{
    setlocale(LC_ALL, "");

    int tab[6]{9,4,7,1,6,3};

    DisplayTab<int>(tab, 6);
    BubleSort<int>(tab, 6);
    DisplayTab<int>(tab, 6);

}