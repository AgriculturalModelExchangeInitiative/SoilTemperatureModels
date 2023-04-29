#ifndef _SurfacePartonSoilSWATCAuxiliary_
#define _SurfacePartonSoilSWATCAuxiliary_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SurfacePartonSoilSWATCAuxiliary
{
    private:
        double SurfaceTemperatureMinimum ;
        double SurfaceTemperatureMaximum ;
    public:
        SurfacePartonSoilSWATCAuxiliary();
        double getSurfaceTemperatureMinimum();
        void setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum);
        double getSurfaceTemperatureMaximum();
        void setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum);

};
#endif