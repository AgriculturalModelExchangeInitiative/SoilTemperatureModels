#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include <numeric>
#include <algorithm>
#include <array>
#include <map>
#include <tuple>
#include "CalculateSoilTemperature.h"
using namespace SQ_Soil_Temperature;
void CalculateSoilTemperature::Init(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a, SoilTemperatureExogenous &ex)
{
    s.deepLayerT = 20.0;
    s.deepLayerT = ex.meanAnnualAirTemp;
}
CalculateSoilTemperature::CalculateSoilTemperature() {}
double CalculateSoilTemperature::getlambda_() { return this->lambda_; }
void CalculateSoilTemperature::setlambda_(double _lambda_) { this->lambda_ = _lambda_; }
void CalculateSoilTemperature::Calculate_Model(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a, SoilTemperatureExogenous &ex)
{
    //- Name: CalculateSoilTemperature -Version: 001, -Time step: 1
    //- Description:
    //            * Title: CalculateSoilTemperature model
    //            * Authors: loic.manceau@inra.fr
    //            * Reference: ('http://biomamodelling.org',)
    //            * Institution: INRA
    //            * ExtendedDescription: Calculation of minimum and maximum Soil temperature, Further used in shoot temperature estimate.
    //            * ShortDescription: None
    //- inputs:
    //            * name: meanTAir
    //                          ** description : Mean Air Temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 22
    //                          ** unit : Â°C
    //            * name: minTAir
    //                          ** description : Minimum Air Temperature from Weather files
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 20
    //                          ** unit : Â°C
    //            * name: lambda_
    //                          ** description : Latente heat of water vaporization at 20Â°C
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 10
    //                          ** min : 0
    //                          ** default : 2.454
    //                          ** unit : MJ.kg-1
    //            * name: deepLayerT
    //                          ** description : Temperature of the last soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 20
    //                          ** unit : Â°C
    //            * name: meanAnnualAirTemp
    //                          ** description : Annual Mean Air Temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 22
    //                          ** unit : Â°C
    //            * name: heatFlux
    //                          ** description : Soil Heat Flux from Energy Balance Component
    //                          ** inputtype : variable
    //                          ** variablecategory : rate
    //                          ** datatype : DOUBLE
    //                          ** max : 100
    //                          ** min : 0
    //                          ** default : 50
    //                          ** unit : g m-2 d-1
    //            * name: maxTAir
    //                          ** description : Maximum Air Temperature from Weather Files
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 80
    //                          ** min : -30
    //                          ** default : 25
    //                          ** unit : Â°C
    //- outputs:
    //            * name: minTSoil
    //                          ** description : Minimum Soil Temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 80
    //                          ** min : -30
    //                          ** unit : Â°C
    //            * name: deepLayerT
    //                          ** description : Temperature of the last soil layer
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 80
    //                          ** min : -30
    //                          ** unit : Â°C
    //            * name: maxTSoil
    //                          ** description : Maximum Soil Temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 80
    //                          ** min : -30
    //                          ** unit : Â°C
    double tmp;
    tmp = ex.meanAnnualAirTemp;
    if (ex.maxTAir == float(-999) && ex.minTAir == float(999))
    {
        s.minTSoil = float(999);
        s.maxTSoil = float(-999);
        s.deepLayerT = 0.0;
    }
    else
    {
        s.minTSoil = SoilMinimumTemperature(ex.maxTAir, ex.meanTAir, ex.minTAir, r.heatFlux, lambda_, s.deepLayerT);
        s.maxTSoil = SoilMaximumTemperature(ex.maxTAir, ex.meanTAir, ex.minTAir, r.heatFlux, lambda_, s.deepLayerT);
        s.deepLayerT = UpdateTemperature(s.minTSoil, s.maxTSoil, s.deepLayerT);
    }
}
double CalculateSoilTemperature::SoilTempB(double weatherMinTemp, double deepTemperature)
{
    return (weatherMinTemp + deepTemperature) / 2.0;
}
double CalculateSoilTemperature::SoilTempA(double weatherMaxTemp, double weatherMeanTemp, double soilHeatFlux, double lambda_)
{
    double TempAdjustment;
    double SoilAvailableEnergy;
    TempAdjustment = weatherMeanTemp < 8.0 ? -0.5 * weatherMeanTemp + 4.0 : float(0);
    SoilAvailableEnergy = soilHeatFlux * lambda_ / 1000;
    double result;
    result = weatherMaxTemp + (11.2 * (1.0 - std::exp(-0.07 * (SoilAvailableEnergy - 5.5)))) + TempAdjustment;
    return result;
}
double CalculateSoilTemperature::SoilMinimumTemperature(double weatherMaxTemp, double weatherMeanTemp, double weatherMinTemp, double soilHeatFlux, double lambda_, double deepTemperature)
{
    return std::min(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature));
}
double CalculateSoilTemperature::SoilMaximumTemperature(double weatherMaxTemp, double weatherMeanTemp, double weatherMinTemp, double soilHeatFlux, double lambda_, double deepTemperature)
{
    return std::max(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature));
}
double CalculateSoilTemperature::UpdateTemperature(double minSoilTemp, double maxSoilTemp, double Temperature)
{
    double meanTemp;
    meanTemp = (minSoilTemp + maxSoilTemp) / 2.0;
    Temperature = (9.0 * Temperature + meanTemp) / 10.0;
    return Temperature;
}