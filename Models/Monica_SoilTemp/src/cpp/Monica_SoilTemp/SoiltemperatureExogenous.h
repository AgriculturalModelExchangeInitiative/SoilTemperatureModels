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
        double tmin;
        double tmax;
        double globrad;
    public:
        SoiltemperatureExogenous();
        double gettmin();
        void settmin(double _tmin);
        double gettmax();
        void settmax(double _tmax);
        double getglobrad();
        void setglobrad(double _globrad);

};
#endif