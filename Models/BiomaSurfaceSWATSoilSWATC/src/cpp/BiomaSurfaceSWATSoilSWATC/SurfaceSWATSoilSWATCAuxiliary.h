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
        double SurfaceSoilTemperature ;
    public:
        SurfaceSWATSoilSWATCAuxiliary();
        double getAboveGroundBiomass();
        void setAboveGroundBiomass(double _AboveGroundBiomass);
        double getSurfaceSoilTemperature();
        void setSurfaceSoilTemperature(double _SurfaceSoilTemperature);

};
}
