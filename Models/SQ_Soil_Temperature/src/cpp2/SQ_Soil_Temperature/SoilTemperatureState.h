#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace SQ_Soil_Temperature {
struct SoilTemperatureState
{
    double minTSoil{0.0};
    double deepLayerT{0.0};
    double maxTSoil{0.0};
    std::vector<double> hourlySoilT;
};
}