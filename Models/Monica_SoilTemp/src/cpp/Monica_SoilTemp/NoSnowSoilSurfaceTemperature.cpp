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
#include "NoSnowSoilSurfaceTemperature.h"
using namespace Monica_SoilTemp;
NoSnowSoilSurfaceTemperature::NoSnowSoilSurfaceTemperature() {}
double NoSnowSoilSurfaceTemperature::getdampingFactor() { return this->dampingFactor; }
void NoSnowSoilSurfaceTemperature::setdampingFactor(double _dampingFactor) { this->dampingFactor = _dampingFactor; }
void NoSnowSoilSurfaceTemperature::Calculate_Model(SoilTemperatureCompState &s, SoilTemperatureCompState &s1, SoilTemperatureCompRate &r, SoilTemperatureCompAuxiliary &a, SoilTemperatureCompExogenous &ex)
{
    //- Name: NoSnowSoilSurfaceTemperature -Version: 1, -Time step: 1
    //- Description:
    //            * Title: Soil surface temperature
    //            * Authors: Michael Berg-Mohnicke
    //            * Reference: None
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: None
    //            * ShortDescription: It calculates the soil surface temperature without snow cover
    //- inputs:
    //            * name: tmin
    //                          ** description : the days min air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 70.0
    //                          ** min : -50.0
    //                          ** default : 
    //                          ** unit : °C
    //            * name: tmax
    //                          ** description : the days max air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 70.0
    //                          ** min : -50.0
    //                          ** default : 
    //                          ** unit : °C
    //            * name: globrad
    //                          ** description : the days global radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 30.0
    //                          ** min : 0.0
    //                          ** default : 0.0
    //                          ** unit : MJ/m**2/d
    //            * name: soilCoverage
    //                          ** description : soilCoverage
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0.0
    //                          ** default : 0.0
    //                          ** unit : dimensionless
    //            * name: dampingFactor
    //                          ** description : dampingFactor
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.8
    //                          ** unit : dimensionless
    //            * name: soilSurfaceTemperature
    //                          ** description : soilSurfaceTemperature of previous day
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : °C
    //- outputs:
    //            * name: soilSurfaceTemperature
    //                          ** description : soilSurfaceTemperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : °C
    double tmin = ex.gettmin();
    double tmax = ex.gettmax();
    double globrad = ex.getglobrad();
    double soilCoverage = ex.getsoilCoverage();
    double soilSurfaceTemperature = s.getsoilSurfaceTemperature();
    double shadingCoefficient;
    globrad = std::max(8.33, globrad);
    shadingCoefficient = 0.1 + (soilCoverage * dampingFactor + ((1 - soilCoverage) * (1 - dampingFactor)));
    soilSurfaceTemperature = (1.0 - shadingCoefficient) * (tmin + ((tmax - tmin) * std::pow(0.03 * globrad, 0.5))) + (shadingCoefficient * soilSurfaceTemperature);
    if (soilSurfaceTemperature < 0.0)
    {
        soilSurfaceTemperature = soilSurfaceTemperature * 0.5;
    }
    s.setsoilSurfaceTemperature(soilSurfaceTemperature);
}