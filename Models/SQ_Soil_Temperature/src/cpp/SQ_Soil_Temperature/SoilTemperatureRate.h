#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace SQ_Soil_Temperature {
class SoilTemperatureRate
{
    private:
        double heatFlux ;
    public:
        SoilTemperatureRate();
        double getheatFlux();
        void setheatFlux(double _heatFlux);

};
}
