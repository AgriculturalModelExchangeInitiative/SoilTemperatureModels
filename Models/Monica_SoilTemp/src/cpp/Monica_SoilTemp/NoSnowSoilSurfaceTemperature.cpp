#ifndef _NOSNOWSOILSURFACETEMPERATURE_
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
#include "Nosnowsoilsurfacetemperature.h"
using namespace std;

Nosnowsoilsurfacetemperature::Nosnowsoilsurfacetemperature() { }
double Nosnowsoilsurfacetemperature::getdampingFactor() {return this-> dampingFactor; }
void Nosnowsoilsurfacetemperature::setdampingFactor(double _dampingFactor) { this->dampingFactor = _dampingFactor; }
void Nosnowsoilsurfacetemperature::Calculate_Model(SoiltemperatureState& s, SoiltemperatureState& s1, SoiltemperatureRate& r, SoiltemperatureAuxiliary& a, SoiltemperatureExogenous& ex)
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
    //                          ** max : 70
    //                          ** min : -50
    //                          ** default : 
    //                          ** unit : °C
    //            * name: tmax
    //                          ** description : the days max air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 70
    //                          ** min : -50
    //                          ** default : 
    //                          ** unit : °C
    //            * name: globrad
    //                          ** description : the days global radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 30
    //                          ** min : 0
    //                          ** default : 0
    //                          ** unit : MJ/m**2/d
    //            * name: soilCoverage
    //                          ** description : soilCoverage
    //                          ** inputtype : variable
    //                          ** variablecategory : state
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
    //            * name: prevDaySoilSurfaceTemperature
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
    double soilCoverage = s.getsoilCoverage();
    double prevDaySoilSurfaceTemperature = s.getprevDaySoilSurfaceTemperature();
    double soilSurfaceTemperature;
    globrad = max(8.33, globrad);
    double shadingCoefficient;
    shadingCoefficient = 0.1 + (soilCoverage * dampingFactor + ((1 - soilCoverage) * (1 - dampingFactor)));
    soilSurfaceTemperature = (1.0 - shadingCoefficient) * (tmin + ((tmax - tmin) * pow(0.03 * globrad, 0.5))) + (shadingCoefficient * prevDaySoilSurfaceTemperature);
    if (soilSurfaceTemperature < 0.0)
    {
        soilSurfaceTemperature = soilSurfaceTemperature * 0.5;
    }
    s.setsoilSurfaceTemperature(soilSurfaceTemperature);
}
#endif