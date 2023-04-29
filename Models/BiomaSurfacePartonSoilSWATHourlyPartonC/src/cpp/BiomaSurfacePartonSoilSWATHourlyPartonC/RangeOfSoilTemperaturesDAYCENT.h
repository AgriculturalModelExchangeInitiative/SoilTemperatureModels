#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SurfacePartonSoilSWATHourlyPartonCState.h"
#include "SurfacePartonSoilSWATHourlyPartonCRate.h"
#include "SurfacePartonSoilSWATHourlyPartonCAuxiliary.h"
#include "SurfacePartonSoilSWATHourlyPartonCExogenous.h"
using namespace std;
class RangeOfSoilTemperaturesDAYCENT
{
    private:
    public:
        RangeOfSoilTemperaturesDAYCENT();
        void  Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState& s, SurfacePartonSoilSWATHourlyPartonCState& s1, SurfacePartonSoilSWATHourlyPartonCRate& r, SurfacePartonSoilSWATHourlyPartonCAuxiliary& a, SurfacePartonSoilSWATHourlyPartonCExogenous& ex);

};