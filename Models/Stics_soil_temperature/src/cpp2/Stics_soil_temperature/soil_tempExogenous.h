#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace Stics_soil_temperature {
struct soil_tempExogenous
{
    double min_temp{0.0};
    double max_temp{0.0};
    double min_air_temp{0.0};
    double min_canopy_temp{0.0};
    double max_canopy_temp{0.0};
};
}