#ifndef _SoilTemperatureCompExogenous_
#define _SoilTemperatureCompExogenous_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SoilTemperatureCompExogenous
{
    private:
        double tmin ;
        double tmax ;
        double globrad ;
    public:
        SoilTemperatureCompExogenous();
        double gettmin();
        void settmin(double _tmin);
        double gettmax();
        void settmax(double _tmax);
        double getglobrad();
        void setglobrad(double _globrad);

};
#endif