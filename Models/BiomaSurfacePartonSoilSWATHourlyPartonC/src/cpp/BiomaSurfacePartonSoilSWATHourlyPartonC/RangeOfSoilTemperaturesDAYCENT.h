
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SurfacePartonSoilSWATHourlyPartonCState.h"
#include "SurfacePartonSoilSWATHourlyPartonCRate.h"
#include "SurfacePartonSoilSWATHourlyPartonCAuxiliary.h"
#include "SurfacePartonSoilSWATHourlyPartonCExogenous.h"
namespace BiomaSurfacePartonSoilSWATHourlyPartonC {
class RangeOfSoilTemperaturesDAYCENT
{
    private:
        std::vector<double> LayerThickness ;
    public:
        RangeOfSoilTemperaturesDAYCENT();
        void Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState &s, SurfacePartonSoilSWATHourlyPartonCState &s1, SurfacePartonSoilSWATHourlyPartonCRate &r, SurfacePartonSoilSWATHourlyPartonCAuxiliary &a, SurfacePartonSoilSWATHourlyPartonCExogenous &ex);
        std::vector<double> & getLayerThickness();
        void setLayerThickness(const std::vector<double> &  _LayerThickness);

};
}
