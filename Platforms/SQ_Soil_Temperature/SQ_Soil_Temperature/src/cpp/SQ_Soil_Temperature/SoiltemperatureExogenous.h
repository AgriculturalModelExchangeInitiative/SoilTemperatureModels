#ifndef _SoiltemperatureExogenous_
#define _SoiltemperatureExogenous_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SoiltemperatureExogenous
{
    private:
        double meanTAir;
        double minTAir;
        double maxTAir;
        double dayLength;
    public:
        SoiltemperatureExogenous();
        double getmeanTAir();
        void setmeanTAir(double _meanTAir);
        double getminTAir();
        void setminTAir(double _minTAir);
        double getmaxTAir();
        void setmaxTAir(double _maxTAir);
        double getdayLength();
        void setdayLength(double _dayLength);

};
#endif