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
class NoSnowSoilSurfaceTemperature
{
    private:
        double dampingFactor ;
    public:
        NoSnowSoilSurfaceTemperature();
        void  Calculate_Model(SoilTemperatureCompState& s, SoilTemperatureCompState& s1, SoilTemperatureCompRate& r, SoilTemperatureCompAuxiliary& a, SoilTemperatureCompExogenous& ex);
        void  Init(SoilTemperatureCompState& s,SoilTemperatureCompState& s1, SoilTemperatureCompRate& r, SoilTemperatureCompAuxiliary& a, SoilTemperatureCompExogenous& ex);
        double getdampingFactor();
        void setdampingFactor(double _dampingFactor);

};