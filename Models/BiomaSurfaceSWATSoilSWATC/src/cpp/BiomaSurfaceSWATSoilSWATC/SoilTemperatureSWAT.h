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
class SoilTemperatureSWAT
{
    private:
        double LagCoefficient ;
    public:
        SoilTemperatureSWAT();
        void  Calculate_Model(SurfaceSWATSoilSWATCState& s, SurfaceSWATSoilSWATCState& s1, SurfaceSWATSoilSWATCRate& r, SurfaceSWATSoilSWATCAuxiliary& a, SurfaceSWATSoilSWATCExogenous& ex);
        double getLagCoefficient();
        void setLagCoefficient(double _LagCoefficient);

};