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
#include "SurfaceTemperatureParton.h"
using namespace BiomaSurfacePartonSoilSWATC;
SurfaceTemperatureParton::SurfaceTemperatureParton() {}
void SurfaceTemperatureParton::Calculate_Model(SurfacePartonSoilSWATCState &s, SurfacePartonSoilSWATCState &s1, SurfacePartonSoilSWATCRate &r, SurfacePartonSoilSWATCAuxiliary &a, SurfacePartonSoilSWATCExogenous &ex)
{
    //- Name: SurfaceTemperatureParton -Version: 001, -Time step: 1
    //- Description:
    //            * Title: SurfaceTemperatureParton model
    //            * Authors: simone.bregaglio
    //            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of soil surface temperature with Parton's method. Reference: Parton, W. J. 1984. Predicting soil temperatures in a shortgrass steppe. Soil Science 138:93-101.
    //            * ShortDescription: None
    //- inputs:
    //            * name: DayLength
    //                          ** description : Length of the day
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 10
    //                          ** unit : h
    //            * name: AirTemperatureMaximum
    //                          ** description : Maximum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : -40
    //                          ** default : 15
    //                          ** unit : 
    //            * name: AirTemperatureMinimum
    //                          ** description : Minimum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : -60
    //                          ** default : 5
    //                          ** unit : 
    //            * name: AboveGroundBiomass
    //                          ** description : Above ground biomass
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 60
    //                          ** min : 0
    //                          ** default : 3
    //                          ** unit : Kg ha-1
    //            * name: GlobalSolarRadiation
    //                          ** description : Daily global solar radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50
    //                          ** min : 0
    //                          ** default : 15
    //                          ** unit : Mj m-2 d-1
    //- outputs:
    //            * name: SurfaceTemperatureMinimum
    //                          ** description : Minimum surface soil temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : degC
    //            * name: SurfaceTemperatureMaximum
    //                          ** description : Maximum surface soil temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : degC
    //            * name: SurfaceSoilTemperature
    //                          ** description : Average surface soil temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : auxiliary
    //                          ** max : 60
    //                          ** min : -60
    //                          ** unit : degC
    double _AGB;
    double _AirTMax;
    double _AirTmin;
    double _SolarRad;
    _AGB = ex.AboveGroundBiomass / 10000;
    _AirTMax = ex.AirTemperatureMaximum;
    _AirTmin = ex.AirTemperatureMinimum;
    _SolarRad = ex.GlobalSolarRadiation;
    if (_AGB > 0.15)
    {
        a.SurfaceTemperatureMaximum = _AirTMax + ((24 * (1 - std::exp(-0.038 * _SolarRad)) + (0.35 * _AirTMax)) * (std::exp(-4.8 * _AGB) - 0.13));
        a.SurfaceTemperatureMinimum = _AirTmin + (6 * _AGB) - 1.82;
    }
    else
    {
        a.SurfaceTemperatureMaximum = ex.AirTemperatureMaximum;
        a.SurfaceTemperatureMinimum = ex.AirTemperatureMinimum;
    }
    a.SurfaceSoilTemperature = 0.41 * a.SurfaceTemperatureMaximum + (0.59 * a.SurfaceTemperatureMinimum);
    if (ex.DayLength != float(0))
    {
        a.SurfaceSoilTemperature = ex.DayLength / 24 * _AirTMax + ((1 - (ex.DayLength / 24)) * _AirTmin);
    }
}