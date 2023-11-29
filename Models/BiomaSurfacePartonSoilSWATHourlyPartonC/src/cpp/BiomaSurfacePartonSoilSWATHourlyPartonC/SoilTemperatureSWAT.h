
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SurfacePartonSoilSWATHourlyPartonCState.h"
#include "SurfacePartonSoilSWATHourlyPartonCRate.h"
#include "SurfacePartonSoilSWATHourlyPartonCAuxiliary.h"
#include "SurfacePartonSoilSWATHourlyPartonCExogenous.h"
namespace BiomaSurfacePartonSoilSWATHourlyPartonC {
class SoilTemperatureSWAT
{
    private:
        std::vector<double> LayerThickness ;
        double LagCoefficient ;
        double AirTemperatureAnnualAverage ;
        std::vector<double> BulkDensity ;
        double SoilProfileDepth ;
    public:
        SoilTemperatureSWAT();
        void Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState &s, SurfacePartonSoilSWATHourlyPartonCState &s1, SurfacePartonSoilSWATHourlyPartonCRate &r, SurfacePartonSoilSWATHourlyPartonCAuxiliary &a, SurfacePartonSoilSWATHourlyPartonCExogenous &ex);
        std::vector<double> & getLayerThickness();
        void setLayerThickness(const std::vector<double> &  _LayerThickness);
        double getLagCoefficient();
        void setLagCoefficient(double _LagCoefficient);
        double getAirTemperatureAnnualAverage();
        void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage);
        std::vector<double> & getBulkDensity();
        void setBulkDensity(const std::vector<double> &  _BulkDensity);
        double getSoilProfileDepth();
        void setSoilProfileDepth(double _SoilProfileDepth);

};
}
