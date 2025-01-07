#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace SQ_Soil_Temperature {
struct SoilTemperatureExogenous
{
    double meanTAir{22};
    double minTAir{20};
    double meanAnnualAirTemp{22};
    double maxTAir{25};
    double dayLength{12};
};
}