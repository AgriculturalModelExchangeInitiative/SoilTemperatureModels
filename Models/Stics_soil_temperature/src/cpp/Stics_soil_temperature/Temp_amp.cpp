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
#include "temp_amp.h"
using namespace Stics_soil_temperature;
temp_amp::temp_amp() {}
void temp_amp::Calculate_Model(soil_tempState &s, soil_tempState &s1, soil_tempRate &r, soil_tempAuxiliary &a, soil_tempExogenous &ex)
{
    //- Name: temp_amp -Version: 1.0, -Time step: 1
    //- Description:
    //            * Title: temp_amp model
    //            * Authors: None
    //            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    //            * Institution: INRAE
    //            * ExtendedDescription: None
    //            * ShortDescription: None
    //- inputs:
    //            * name: min_temp
    //                          ** description : current minimum temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 0.0
    //                          ** unit : degC
    //            * name: max_temp
    //                          ** description : current maximum temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 0.0
    //                          ** unit : degC
    //- outputs:
    //            * name: temp_amp
    //                          ** description : current temperature amplitude
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 100.0
    //                          ** min : 0.0
    //                          ** unit : degC
    double min_temp = ex.getmin_temp();
    double max_temp = ex.getmax_temp();
    double temp_amp;
    temp_amp = max_temp - min_temp;
    s.settemp_amp(temp_amp);
}