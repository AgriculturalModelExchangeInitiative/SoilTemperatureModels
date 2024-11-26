
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SurfacePartonSoilSWATCState.h"
#include "SurfacePartonSoilSWATCRate.h"
#include "SurfacePartonSoilSWATCAuxiliary.h"
#include "SurfacePartonSoilSWATCExogenous.h"
namespace BiomaSurfacePartonSoilSWATC {
class SoilTemperatureSWAT
{
private:
    std::vector<double> LayerThickness;
    double LagCoefficient{0.8};
    double AirTemperatureAnnualAverage{15};
    std::vector<double> BulkDensity;
    double SoilProfileDepth{3};
public:
    SoilTemperatureSWAT();

    void Calculate_Model(SurfacePartonSoilSWATCState &s, SurfacePartonSoilSWATCState &s1, SurfacePartonSoilSWATCRate &r, SurfacePartonSoilSWATCAuxiliary &a, SurfacePartonSoilSWATCExogenous &ex);

    void Init(SurfacePartonSoilSWATCState &s, SurfacePartonSoilSWATCState &s1, SurfacePartonSoilSWATCRate &r, SurfacePartonSoilSWATCAuxiliary &a, SurfacePartonSoilSWATCExogenous &ex);

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