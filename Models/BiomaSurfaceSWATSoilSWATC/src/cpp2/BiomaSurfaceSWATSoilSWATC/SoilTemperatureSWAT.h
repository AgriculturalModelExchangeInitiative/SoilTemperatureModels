
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SurfaceSWATSoilSWATCState.h"
#include "SurfaceSWATSoilSWATCRate.h"
#include "SurfaceSWATSoilSWATCAuxiliary.h"
#include "SurfaceSWATSoilSWATCExogenous.h"
namespace BiomaSurfaceSWATSoilSWATC {
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

    void Calculate_Model(SurfaceSWATSoilSWATCState &s, SurfaceSWATSoilSWATCState &s1, SurfaceSWATSoilSWATCRate &r, SurfaceSWATSoilSWATCAuxiliary &a, SurfaceSWATSoilSWATCExogenous &ex);

    void Init(SurfaceSWATSoilSWATCState &s, SurfaceSWATSoilSWATCState &s1, SurfaceSWATSoilSWATCRate &r, SurfaceSWATSoilSWATCAuxiliary &a, SurfaceSWATSoilSWATCExogenous &ex);

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