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
#include "update.h"
using namespace Stics_soil_temperature;
update::update() {}
void update::Calculate_Model(soil_tempState &s, soil_tempState &s1, soil_tempRate &r, soil_tempAuxiliary &a, soil_tempExogenous &ex)
{
    //- Name: update -Version: 1.0, -Time step: 1
    //- Description:
    //            * Title: update soil temp model
    //            * Authors: None
    //            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    //            * Institution: INRAE
    //            * ExtendedDescription: None
    //            * ShortDescription: None
    //- inputs:
    //            * name: canopy_temp_avg
    //                          ** description : current canopy mean temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 0.0
    //                          ** unit : degC
    //            * name: temp_profile
    //                          ** description : current soil profile temperature (for 1 cm layers)
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 
    //                          ** unit : degC
    //- outputs:
    //            * name: prev_canopy_temp
    //                          ** description : previous crop temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 50.0
    //                          ** min : 0.0
    //                          ** unit : degC
    //            * name: prev_temp_profile
    //                          ** description : previous soil temperature profile (for 1 cm layers)
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** unit : degC
    double canopy_temp_avg = s.getcanopy_temp_avg();
    std::vector<double>& temp_profile = s.gettemp_profile();
    double prev_canopy_temp;
    std::vector<double> prev_temp_profile;
    int n;
    prev_canopy_temp = canopy_temp_avg;
    n = temp_profile.size();
    prev_temp_profile = std::vector<double>(n);
    prev_temp_profile = temp_profile;
    s.setprev_canopy_temp(prev_canopy_temp);
    s.setprev_temp_profile(prev_temp_profile);
}