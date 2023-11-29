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
#include "HourlySoilTemperaturesPartonLogan.h"
using namespace BiomaSurfacePartonSoilSWATHourlyPartonC;
HourlySoilTemperaturesPartonLogan::HourlySoilTemperaturesPartonLogan() {}
void HourlySoilTemperaturesPartonLogan::Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState &s, SurfacePartonSoilSWATHourlyPartonCState &s1, SurfacePartonSoilSWATHourlyPartonCRate &r, SurfacePartonSoilSWATHourlyPartonCAuxiliary &a, SurfacePartonSoilSWATHourlyPartonCExogenous &ex)
{
    //- Name: HourlySoilTemperaturesPartonLogan -Version: 001, -Time step: 1
    //- Description:
    //            * Title: HourlySoilTemperaturesPartonLogan model
    //            * Authors: simone.bregaglio
    //            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    //            * Institution: University Of Milan
    //            * ExtendedDescription: Strategy for the calculation of hourly soil temperature. Reference: Parton, W.J.  and  Logan, J.A.,  1981. A model for diurnal variation  in soil  and  air temperature. Agric. Meteorol., 23: 205-216.
    //            * ShortDescription: Strategy for the calculation of hourly soil temperature
    //- inputs:
    //            * name: SoilTemperatureByLayersHourly
    //                          ** description : Hourly soil temperature by layers
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 50
    //                          ** min : -50
    //                          ** default : 15
    //                          ** unit : degC
    //            * name: HourOfSunrise
    //                          ** description : Hour of sunrise
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 6
    //                          ** unit : h
    //            * name: HourOfSunset
    //                          ** description : Hour of sunset
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 17
    //                          ** unit : h
    //            * name: DayLength
    //                          ** description : Length of the day
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 24
    //                          ** min : 0
    //                          ** default : 10
    //                          ** unit : h
    //            * name: SoilTemperatureMinimum
    //                          ** description : Minimum soil temperature by layers
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 15
    //                          ** unit : degC
    //            * name: SoilTemperatureMaximum
    //                          ** description : Maximum soil temperature by layers
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 60
    //                          ** min : -60
    //                          ** default : 15
    //                          ** unit : degC
    //- outputs:
    //            * name: SoilTemperatureByLayersHourly
    //                          ** description : Hourly soil temperature by layers
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 50
    //                          ** min : -50
    //                          ** unit : degC
    std::vector<double> & SoilTemperatureByLayersHourly = s.getSoilTemperatureByLayersHourly();
    double HourOfSunrise = ex.getHourOfSunrise();
    double HourOfSunset = ex.getHourOfSunset();
    double DayLength = ex.getDayLength();
    std::vector<double> & SoilTemperatureMinimum = a.getSoilTemperatureMinimum();
    std::vector<double> & SoilTemperatureMaximum = a.getSoilTemperatureMaximum();
    int h;
    int i;
    double TemperatureAtSunset;
    for (i=0 ; i!=SoilTemperatureMinimum.size() ; i+=1)
    {
        for (h=0 ; h!=24 ; h+=1)
        {
            if (h >= int(HourOfSunrise) && h <= int(HourOfSunset))
            {
                SoilTemperatureByLayersHourly[i * 24 + h] = SoilTemperatureMinimum[i] + ((SoilTemperatureMaximum[i] - SoilTemperatureMinimum[i]) * std::sin(M_PI * (h - 12 + (DayLength / 2)) / (DayLength + (2 * 1.8))));
            }
        }
        TemperatureAtSunset = SoilTemperatureByLayersHourly[i + int(HourOfSunset)];
        for (h=0 ; h!=24 ; h+=1)
        {
            if (h > int(HourOfSunset))
            {
                SoilTemperatureByLayersHourly[i + h] = (SoilTemperatureMinimum[i] - (TemperatureAtSunset * std::exp(-(24 - DayLength) / 2.2)) + ((TemperatureAtSunset - SoilTemperatureMinimum[i]) * std::exp(-(h - HourOfSunset) / 2.2))) / (1 - std::exp(-(24 - DayLength) / 2.2));
            }
            else if ( h <= int(HourOfSunrise))
            {
                SoilTemperatureByLayersHourly[i + h] = (SoilTemperatureMinimum[i] - (TemperatureAtSunset * std::exp(-(24 - DayLength) / 2.2)) + ((TemperatureAtSunset - SoilTemperatureMinimum[i]) * std::exp(-(h + 24 - HourOfSunset) / 2.2))) / (1 - std::exp(-(24 - DayLength) / 2.2));
            }
        }
    }
    s.setSoilTemperatureByLayersHourly(SoilTemperatureByLayersHourly);
}