
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
class ThermalConductivitySIMULAT
{
    private:
        std::vector<double> BulkDensity ;
        std::vector<double> Clay ;
    public:
        ThermalConductivitySIMULAT();
        void Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState &s, SurfacePartonSoilSWATHourlyPartonCState &s1, SurfacePartonSoilSWATHourlyPartonCRate &r, SurfacePartonSoilSWATHourlyPartonCAuxiliary &a, SurfacePartonSoilSWATHourlyPartonCExogenous &ex);
        std::vector<double> & getBulkDensity();
        void setBulkDensity(const std::vector<double> &  _BulkDensity);
        std::vector<double> & getClay();
        void setClay(const std::vector<double> &  _Clay);

};
}
