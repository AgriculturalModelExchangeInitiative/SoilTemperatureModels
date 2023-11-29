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
        std::vector<double> VolumetricWaterContent ;
        double SurfaceTemperatureMinimum ;
        double SurfaceTemperatureMaximum ;
        double SurfaceSoilTemperature ;
    public:
        SurfacePartonSoilSWATCAuxiliary();
        std::vector<double> & getVolumetricWaterContent();
        void setVolumetricWaterContent(const std::vector<double> &  _VolumetricWaterContent);
        double getSurfaceTemperatureMinimum();
        void setSurfaceTemperatureMinimum(double _SurfaceTemperatureMinimum);
        double getSurfaceTemperatureMaximum();
        void setSurfaceTemperatureMaximum(double _SurfaceTemperatureMaximum);
        double getSurfaceSoilTemperature();
        void setSurfaceSoilTemperature(double _SurfaceSoilTemperature);

};
}
