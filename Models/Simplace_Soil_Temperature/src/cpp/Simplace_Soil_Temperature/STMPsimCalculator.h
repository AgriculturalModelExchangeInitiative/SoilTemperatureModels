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
class STMPsimCalculator
{
    private:
        vector<double> cSoilLayerDepth ;
        double cFirstDayMeanTemp ;
        double cAVT ;
        double cABD ;
        double cDampingDepth ;
    public:
        STMPsimCalculator();
        void  Calculate_Model(SoilTemperatureState& s, SoilTemperatureState& s1, SoilTemperatureRate& r, SoilTemperatureAuxiliary& a, SoilTemperatureExogenous& ex);
        void  Init(SoilTemperatureState& s,SoilTemperatureState& s1, SoilTemperatureRate& r, SoilTemperatureAuxiliary& a, SoilTemperatureExogenous& ex);
        vector<double> & getcSoilLayerDepth();
        void setcSoilLayerDepth(const vector<double> &  _cSoilLayerDepth);
        double getcFirstDayMeanTemp();
        void setcFirstDayMeanTemp(double _cFirstDayMeanTemp);
        double getcAVT();
        void setcAVT(double _cAVT);
        double getcABD();
        void setcABD(double _cABD);
        double getcDampingDepth();
        void setcDampingDepth(double _cDampingDepth);

};