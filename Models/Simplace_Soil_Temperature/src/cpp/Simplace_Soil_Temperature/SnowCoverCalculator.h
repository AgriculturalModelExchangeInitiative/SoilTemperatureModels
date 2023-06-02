#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SoilTemperatureState.h"
#include "SoilTemperatureRate.h"
#include "SoilTemperatureAuxiliary.h"
#include "SoilTemperatureExogenous.h"
using namespace std;
class SnowCoverCalculator
{
    private:
        double cCarbonContent ;
    public:
        SnowCoverCalculator();
        void  Calculate_Model(SoilTemperatureState& s, SoilTemperatureState& s1, SoilTemperatureRate& r, SoilTemperatureAuxiliary& a, SoilTemperatureExogenous& ex);
        void  Init(SoilTemperatureState& s,SoilTemperatureState& s1, SoilTemperatureRate& r, SoilTemperatureAuxiliary& a, SoilTemperatureExogenous& ex);
        double getcCarbonContent();
        void setcCarbonContent(double _cCarbonContent);

};