
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SurfaceSWATSoilSWATCState.h"
#include "SurfaceSWATSoilSWATCRate.h"
#include "SurfaceSWATSoilSWATCAuxiliary.h"
#include "SurfaceSWATSoilSWATCExogenous.h"
namespace BiomaSurfaceSWATSoilSWATC {
class SurfaceTemperatureSWAT
{
    private:
    public:
        SurfaceTemperatureSWAT();
        void Calculate_Model(SurfaceSWATSoilSWATCState &s, SurfaceSWATSoilSWATCState &s1, SurfaceSWATSoilSWATCRate &r, SurfaceSWATSoilSWATCAuxiliary &a, SurfaceSWATSoilSWATCExogenous &ex);

};
}
