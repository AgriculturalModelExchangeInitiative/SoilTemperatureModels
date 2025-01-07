#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace Stics_soil_temperature {
struct soil_tempState
{
    std::vector<double> prev_temp_profile;
    double prev_canopy_temp{0.0};
    double temp_amp{0.0};
    std::vector<double> temp_profile;
    std::vector<double> layer_temp;
    double canopy_temp_avg{0.0};
};
}