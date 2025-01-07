#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace BiomaSurfaceSWATSoilSWATC {
struct SurfaceSWATSoilSWATCState
{
    std::vector<double> SoilTemperatureByLayers;
};
}