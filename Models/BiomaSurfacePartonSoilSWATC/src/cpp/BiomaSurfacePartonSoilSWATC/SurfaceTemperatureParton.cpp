#ifndef _SURFACETEMPERATUREPARTON_
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
using namespace std;

SurfaceTemperatureParton::SurfaceTemperatureParton() { }
void SurfaceTemperatureParton::Calculate_Model(SurfacePartonSoilSWATCState& s, SurfacePartonSoilSWATCState& s1, SurfacePartonSoilSWATCRate& r, SurfacePartonSoilSWATCAuxiliary& a, SurfacePartonSoilSWATCExogenous& ex)
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
    double DayLength = ex.getDayLength();
    double AirTemperatureMaximum = ex.getAirTemperatureMaximum();
    double AirTemperatureMinimum = ex.getAirTemperatureMinimum();
    double AboveGroundBiomass = ex.getAboveGroundBiomass();
    double GlobalSolarRadiation = ex.getGlobalSolarRadiation();
    double SurfaceTemperatureMinimum;
    double SurfaceTemperatureMaximum;
    double SurfaceSoilTemperature;
    double _AGB;
    double _AirTMax;
    double _AirTmin;
    double _SolarRad;
    _AGB = AboveGroundBiomass / 10000;
    _AirTMax = AirTemperatureMaximum;
    _AirTmin = AirTemperatureMinimum;
    _SolarRad = GlobalSolarRadiation;
    if (_AGB > 0.15)
    {
        SurfaceTemperatureMaximum = _AirTMax + ((24 * (1 - exp(-0.038 * _SolarRad)) + (0.35 * _AirTMax)) * (exp(-4.8 * _AGB) - 0.13));
        SurfaceTemperatureMinimum = _AirTmin + (6 * _AGB) - 1.82;
    }
    else
    {
        SurfaceTemperatureMaximum = AirTemperatureMaximum;
        SurfaceTemperatureMinimum = AirTemperatureMinimum;
    }
    SurfaceSoilTemperature = 0.41 * SurfaceTemperatureMaximum + (0.59 * SurfaceTemperatureMinimum);
    if (DayLength != float(0))
    {
        SurfaceSoilTemperature = DayLength / 24 * _AirTMax + ((1 - (DayLength / 24)) * _AirTmin);
    }
    a.setSurfaceTemperatureMinimum(SurfaceTemperatureMinimum);
    a.setSurfaceTemperatureMaximum(SurfaceTemperatureMaximum);
    a.setSurfaceSoilTemperature(SurfaceSoilTemperature);
}
#endif