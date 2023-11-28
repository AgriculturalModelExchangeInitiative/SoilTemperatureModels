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
        vector<double> LayerThickness ;
        double LagCoefficient ;
        double AirTemperatureAnnualAverage ;
        vector<double> BulkDensity ;
        double SoilProfileDepth ;
    public:
        SoilTemperatureSWAT();
        void  Calculate_Model(SurfacePartonSoilSWATCState& s, SurfacePartonSoilSWATCState& s1, SurfacePartonSoilSWATCRate& r, SurfacePartonSoilSWATCAuxiliary& a, SurfacePartonSoilSWATCExogenous& ex);
        vector<double> & getLayerThickness();
        void setLayerThickness(const vector<double> &  _LayerThickness);
        double getLagCoefficient();
        void setLagCoefficient(double _LagCoefficient);
        double getAirTemperatureAnnualAverage();
        void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage);
        vector<double> & getBulkDensity();
        void setBulkDensity(const vector<double> &  _BulkDensity);
        double getSoilProfileDepth();
        void setSoilProfileDepth(double _SoilProfileDepth);

};