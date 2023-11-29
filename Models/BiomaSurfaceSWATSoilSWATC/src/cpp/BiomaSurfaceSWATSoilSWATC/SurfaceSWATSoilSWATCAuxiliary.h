#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace BiomaSurfaceSWATSoilSWATC {
class SurfaceSWATSoilSWATCAuxiliary
{
    private:
        double AboveGroundBiomass ;
        std::vector<double> VolumetricWaterContent ;
        double SurfaceSoilTemperature ;
    public:
        SurfaceSWATSoilSWATCAuxiliary();
        double getAboveGroundBiomass();
        void setAboveGroundBiomass(double _AboveGroundBiomass);
        std::vector<double> & getVolumetricWaterContent();
        void setVolumetricWaterContent(const std::vector<double> &  _VolumetricWaterContent);
        double getSurfaceSoilTemperature();
        void setSurfaceSoilTemperature(double _SurfaceSoilTemperature);

};
}
