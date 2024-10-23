#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace BiomaSurfacePartonSoilSWATC {
class SurfacePartonSoilSWATCState
{
    private:
        std::vector<double> SoilTemperatureByLayers ;
    public:
        SurfacePartonSoilSWATCState();
        std::vector<double> & getSoilTemperatureByLayers();
        void setSoilTemperatureByLayers(const std::vector<double> &  _SoilTemperatureByLayers);

};
}
