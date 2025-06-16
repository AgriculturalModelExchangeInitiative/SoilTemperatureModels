#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace Simplace_Soil_Temperature {
struct SoilTemperatureExogenous
{
    double iAirTemperatureMax{0.0};
    double iTempMax{0.0};
    double iAirTemperatureMin{0.0};
    double iTempMin{0.0};
    double iGlobalSolarRadiation{0.0};
    double iRadiation{0.0};
    double iRAIN{0.0};
    double iCropResidues{0.0};
    double iPotentialSoilEvaporation{0.0};
    double iLeafAreaIndex{0.0};
    double iSoilWaterContent{5.0};
};
}