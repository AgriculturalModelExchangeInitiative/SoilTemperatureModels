#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SurfaceSWATSoilSWATCState.h"
#include "SurfaceSWATSoilSWATCRate.h"
#include "SurfaceSWATSoilSWATCAuxiliary.h"
#include "SurfaceSWATSoilSWATCExogenous.h"
using namespace std;
class SurfaceTemperatureSWAT
{
    private:
    public:
        SurfaceTemperatureSWAT();
        void  Calculate_Model(SurfaceSWATSoilSWATCState& s, SurfaceSWATSoilSWATCState& s1, SurfaceSWATSoilSWATCRate& r, SurfaceSWATSoilSWATCAuxiliary& a, SurfaceSWATSoilSWATCExogenous& ex);

};