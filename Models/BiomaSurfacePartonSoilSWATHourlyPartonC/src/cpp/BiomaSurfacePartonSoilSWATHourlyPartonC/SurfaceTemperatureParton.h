
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
class SurfaceTemperatureParton
{
    private:
    public:
        SurfaceTemperatureParton();
        void Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState &s, SurfacePartonSoilSWATHourlyPartonCState &s1, SurfacePartonSoilSWATHourlyPartonCRate &r, SurfacePartonSoilSWATHourlyPartonCAuxiliary &a, SurfacePartonSoilSWATHourlyPartonCExogenous &ex);

};
}
