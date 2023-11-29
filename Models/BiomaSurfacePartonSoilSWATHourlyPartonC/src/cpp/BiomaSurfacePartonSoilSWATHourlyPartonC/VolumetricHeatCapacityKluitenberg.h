
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
class VolumetricHeatCapacityKluitenberg
{
    private:
        std::vector<double> Clay ;
        std::vector<double> Silt ;
    public:
        VolumetricHeatCapacityKluitenberg();
        void Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState &s, SurfacePartonSoilSWATHourlyPartonCState &s1, SurfacePartonSoilSWATHourlyPartonCRate &r, SurfacePartonSoilSWATHourlyPartonCAuxiliary &a, SurfacePartonSoilSWATHourlyPartonCExogenous &ex);
        std::vector<double> & getClay();
        void setClay(const std::vector<double> &  _Clay);
        std::vector<double> & getSilt();
        void setSilt(const std::vector<double> &  _Silt);

};
}
