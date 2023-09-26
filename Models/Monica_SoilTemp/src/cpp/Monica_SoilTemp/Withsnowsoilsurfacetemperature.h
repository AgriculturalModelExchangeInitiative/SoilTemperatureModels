#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SoilTemperatureCompState.h"
#include "SoilTemperatureCompRate.h"
#include "SoilTemperatureCompAuxiliary.h"
#include "SoilTemperatureCompExogenous.h"
using namespace std;
class WithSnowSoilSurfaceTemperature
{
    private:
    public:
        WithSnowSoilSurfaceTemperature();
        void  Calculate_Model(SoilTemperatureCompState& s, SoilTemperatureCompState& s1, SoilTemperatureCompRate& r, SoilTemperatureCompAuxiliary& a, SoilTemperatureCompExogenous& ex);
        void  Init(SoilTemperatureCompState& s,SoilTemperatureCompState& s1, SoilTemperatureCompRate& r, SoilTemperatureCompAuxiliary& a, SoilTemperatureCompExogenous& ex);

};