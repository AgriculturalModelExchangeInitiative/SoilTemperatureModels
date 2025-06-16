#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace Simplace_Soil_Temperature {
struct SoilTemperatureRate
{
    double rSnowWaterContentRate{0.0};
    double rSoilSurfaceTemperatureRate{0.0};
    int rAgeOfSnowRate{0};
};
}