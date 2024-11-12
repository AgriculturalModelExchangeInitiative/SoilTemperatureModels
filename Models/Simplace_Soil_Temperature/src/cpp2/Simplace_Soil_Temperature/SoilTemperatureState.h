#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace Simplace_Soil_Temperature {
struct SoilTemperatureState
{
    double pInternalAlbedo{0.0};
    double SnowWaterContent{0.0};
    double SoilSurfaceTemperature{0.0};
    int AgeOfSnow{0};
    std::vector<double> rSoilTempArrayRate;
    std::vector<double> pSoilLayerDepth;
    std::vector<double> SoilTempArray;
};
}