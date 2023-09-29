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
#include "frost_calc_thaw_depth.h"
using namespace Monica_SoilTemp;
frost_calc_thaw_depth::frost_calc_thaw_depth() {}
double frost_calc_thaw_depth::getheat_conductivity_unfrozen() { return this->heat_conductivity_unfrozen; }
void frost_calc_thaw_depth::setheat_conductivity_unfrozen(double _heat_conductivity_unfrozen) { this->heat_conductivity_unfrozen = _heat_conductivity_unfrozen; }
void frost_calc_thaw_depth::Calculate_Model(SoilTemperatureCompState &s, SoilTemperatureCompState &s1, SoilTemperatureCompRate &r, SoilTemperatureCompAuxiliary &a, SoilTemperatureCompExogenous &ex)
{
    //- Name: frost_calc_thaw_depth -Version: 1, -Time step: 1
    //- Description:
    //            * Title: Calculate frost thaw depth
    //            * Authors: Michael Berg-Mohnicke
    //            * Reference: None
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: None
    //            * ShortDescription: Calculate frost thaw depth
    //- inputs:
    //            * name: temperature_under_snow
    //                          ** description : current temperature_under_snow
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : °C
    //            * name: heat_conductivity_unfrozen
    //                          ** description : heat_conductivity_unfrozen
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: mean_field_capacity
    //                          ** description : mean_field_capacity
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : fraction
    //            * name: frost_depth
    //                          ** description : frost_depth
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : m
    //            * name: thaw_depth
    //                          ** description : thaw_depth
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : m
    //- outputs:
    //            * name: thaw_depth
    //                          ** description : new thaw_depth
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : m
    double temperature_under_snow = ex.gettemperature_under_snow();
    double mean_field_capacity = ex.getmean_field_capacity();
    double frost_depth = s.getfrost_depth();
    double thaw_depth = s.getthaw_depth();
    double thaw_helper1;
    if (temperature_under_snow < 0.0)
    {
        thaw_helper1 = temperature_under_snow * -1.0;
    }
    else
    {
        thaw_helper1 = temperature_under_snow;
    }
    double thaw_helper2;
    if (frost_depth == 0.0)
    {
        thaw_helper2 = 0.0;
    }
    else
    {
        thaw_helper2 = std::sqrt(2.0 * heat_conductivity_unfrozen * thaw_helper1 / (1000.0 * 79.0 * (mean_field_capacity * 100.0) / 100.0));
    }
    double thaw_helper3;
    if (temperature_under_snow < 0.0)
    {
        thaw_helper3 = thaw_helper2 * -1.0;
    }
    else
    {
        thaw_helper3 = thaw_helper2;
    }
    double thaw_helper4;
    thaw_helper4 = thaw_depth + thaw_helper3;
    if (thaw_helper4 < 0.0)
    {
        thaw_depth = 0.0;
    }
    else
    {
        thaw_depth = thaw_helper4;
    }
    s.setthaw_depth(thaw_depth);
}