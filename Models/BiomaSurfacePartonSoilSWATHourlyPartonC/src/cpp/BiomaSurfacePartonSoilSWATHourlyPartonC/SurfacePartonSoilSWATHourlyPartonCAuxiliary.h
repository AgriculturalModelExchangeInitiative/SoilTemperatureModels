#ifndef _SurfacePartonSoilSWATHourlyPartonCAuxiliary_
#define _SurfacePartonSoilSWATHourlyPartonCAuxiliary_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SurfacePartonSoilSWATHourlyPartonCAuxiliary
{
    private:
        double SurfaceTemperatureMinimum ;
        double SurfaceTemperatureMaximum ;
    public:
        SurfacePartonSoilSWATHourlyPartonCAuxiliary();
        double getSurfaceTemperatureMinimum();
        void setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum);
        double getSurfaceTemperatureMaximum();
        void setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum);

};
#endif