#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace BiomaSurfaceSWATSoilSWATC {
struct SurfaceSWATSoilSWATCExogenous
{
    double AirTemperatureMaximum{15};
    double AirTemperatureMinimum{5};
    double GlobalSolarRadiation{15};
    double WaterEquivalentOfSnowPack{10};
    double Albedo{0.2};
    std::vector<double> VolumetricWaterContent;
};
}