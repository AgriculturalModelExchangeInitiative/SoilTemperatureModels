#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>

namespace ApsimCampbell {
struct SoiltempExogenous
{
    double waterBalance_Eo{0.0};
    double waterBalance_Salb{0.0};
    std::vector<double> organic_Carbon;
    double waterBalance_Es{0.0};
    double weather_Wind{0.0};
    std::vector<double> physical_ParticleSizeSand;
    double weather_AirPressure{0.0};
    int clock_Today_DayOfYear{0};
    double microClimate_CanopyHeight{0.0};
    double waterBalance_Eos{0.0};
    std::vector<double> waterBalance_SW;
    double weather_Amp{0.0};
    double weather_MinT{0.0};
    double weather_Radn{0.0};
    std::vector<double> physical_Rocks;
    double weather_Tav{0.0};
    double weather_MaxT{0.0};
    double weather_MeanT{0.0};
    std::vector<double> physical_ParticleSizeSilt;
    std::vector<double> physical_ParticleSizeClay;
};
}