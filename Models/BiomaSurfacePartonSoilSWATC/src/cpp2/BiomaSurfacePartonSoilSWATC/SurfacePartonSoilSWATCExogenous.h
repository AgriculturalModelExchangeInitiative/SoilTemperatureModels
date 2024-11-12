#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace BiomaSurfacePartonSoilSWATC {
struct SurfacePartonSoilSWATCExogenous
{
    double DayLength{10};
    double GlobalSolarRadiation{15};
    double AboveGroundBiomass{3};
    double AirTemperatureMinimum{5};
    double AirTemperatureMaximum{15};
    std::vector<double> VolumetricWaterContent;
};
}