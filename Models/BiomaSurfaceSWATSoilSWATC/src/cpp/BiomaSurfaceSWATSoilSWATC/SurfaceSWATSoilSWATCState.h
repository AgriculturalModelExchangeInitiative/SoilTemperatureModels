#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace BiomaSurfaceSWATSoilSWATC {
class SurfaceSWATSoilSWATCState
{
    private:
        std::vector<double> SoilTemperatureByLayers ;
    public:
        SurfaceSWATSoilSWATCState();
        std::vector<double> & getSoilTemperatureByLayers();
        void setSoilTemperatureByLayers(const std::vector<double> &  _SoilTemperatureByLayers);

};
}
