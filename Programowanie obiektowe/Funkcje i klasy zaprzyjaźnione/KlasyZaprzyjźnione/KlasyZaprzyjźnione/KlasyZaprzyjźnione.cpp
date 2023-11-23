
#include <iostream>
#define _USE_MATH_DEFINES
#include <cmath>
#include <corecrt_math_defines.h>

using namespace std;

class Promien {
    double r;
public:
    void setR(double r);
    double getR();

    friend class Kolo;
    friend class Kula;
};

void Promien::setR(double r)
{
    this->r = r;
}
double Promien::getR()
{
    return this->r;
}

// definicja klas zaprzyjażnionych które mają dostę do składowych prywatnych klasy z którą są w przyjaźni
class Kolo
{
public:
    double pole(Promien);
    double obwod(Promien);
};

double Kolo::pole(Promien R)
{
    return M_PI * R.r * R.r;
}
double Kolo::obwod(Promien R)
{
    return 2 * M_PI * R.r;
}

int main()
{
    setlocale(LC_ALL,"");
    double promienKola;
    Promien promien;
    Kolo kolo;

    cout << "Podaj promień koła:" << endl;
    cin >> promienKola;
    
    promien.setR(promienKola);
    cout << "Pole koła wynosi:" << kolo.pole(promien) << endl;
    cout << "Obwód koła wynosi:" << kolo.obwod(promien) << endl;
}

