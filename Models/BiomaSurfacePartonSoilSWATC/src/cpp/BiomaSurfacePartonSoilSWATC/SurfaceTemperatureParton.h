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
class SurfaceTemperatureParton
{
    private:
    public:
        SurfaceTemperatureParton();
        void  Calculate_Model(SurfacePartonSoilSWATCState& s, SurfacePartonSoilSWATCState& s1, SurfacePartonSoilSWATCRate& r, SurfacePartonSoilSWATCAuxiliary& a, SurfacePartonSoilSWATCExogenous& ex);

};