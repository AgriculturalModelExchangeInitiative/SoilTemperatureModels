#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace Simplace_Soil_Temperature {
struct SoilTemperatureAuxiliary
{
    std::vector<double> SoilTempArray;
    std::vector<double> iSoilTempArray;
    double SnowIsolationIndex{0.0};
    double iSoilSurfaceTemperature{0.0};
};
}