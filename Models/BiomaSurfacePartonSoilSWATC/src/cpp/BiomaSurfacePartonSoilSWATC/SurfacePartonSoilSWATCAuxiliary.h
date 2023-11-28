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
        vector<double> VolumetricWaterContent ;
        double SurfaceTemperatureMinimum ;
        double SurfaceTemperatureMaximum ;
        double SurfaceSoilTemperature ;
    public:
        SurfacePartonSoilSWATCAuxiliary();
        vector<double> & getVolumetricWaterContent();
        void setVolumetricWaterContent(const vector<double> &  _VolumetricWaterContent);
        double getSurfaceTemperatureMinimum();
        void setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum);
        double getSurfaceTemperatureMaximum();
        void setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum);
        double getSurfaceSoilTemperature();
        void setSurfaceSoilTemperature(double _SurfaceSoilTemperature);

};
#endif