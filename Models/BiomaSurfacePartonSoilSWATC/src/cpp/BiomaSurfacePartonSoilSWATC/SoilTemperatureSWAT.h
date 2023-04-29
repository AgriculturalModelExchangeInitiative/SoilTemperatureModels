#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SurfacePartonSoilSWATCState.h"
#include "SurfacePartonSoilSWATCRate.h"
#include "SurfacePartonSoilSWATCAuxiliary.h"
#include "SurfacePartonSoilSWATCExogenous.h"
using namespace std;
class SoilTemperatureSWAT
{
    private:
        double LagCoefficient ;
    public:
        SoilTemperatureSWAT();
        void  Calculate_Model(SurfacePartonSoilSWATCState& s, SurfacePartonSoilSWATCState& s1, SurfacePartonSoilSWATCRate& r, SurfacePartonSoilSWATCAuxiliary& a, SurfacePartonSoilSWATCExogenous& ex);
        double getLagCoefficient();
        void setLagCoefficient(double _LagCoefficient);

};