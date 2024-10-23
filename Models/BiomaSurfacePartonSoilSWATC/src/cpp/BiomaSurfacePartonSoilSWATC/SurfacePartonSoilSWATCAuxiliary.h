#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace BiomaSurfacePartonSoilSWATC {
class SurfacePartonSoilSWATCAuxiliary
{
    private:
        double SurfaceTemperatureMinimum ;
        double SurfaceTemperatureMaximum ;
        double SurfaceSoilTemperature ;
    public:
        SurfacePartonSoilSWATCAuxiliary();
        double getSurfaceTemperatureMinimum();
        void setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum);
        double getSurfaceTemperatureMaximum();
        void setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum);
        double getSurfaceSoilTemperature();
        void setSurfaceSoilTemperature(double _SurfaceSoilTemperature);

};
}
