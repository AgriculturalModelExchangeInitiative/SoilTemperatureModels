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
#include "temp_profile.h"
using namespace Stics_soil_temperature;
void temp_profile::Init(soil_tempState &s, soil_tempState &s1, soil_tempRate &r, soil_tempAuxiliary &a, soil_tempExogenous &ex)
{
    s.temp_amp = 0.0;
    s.prev_canopy_temp = 0.0;
    int soil_depth;
    soil_depth = accumulate(layer_thick.begin(), layer_thick.end(), 0);
    s.prev_temp_profile = std::vector<double> (soil_depth);
    s.prev_temp_profile.assign(soil_depth, air_temp_day1);
    s.prev_canopy_temp = air_temp_day1;
}
temp_profile::temp_profile() {}
double temp_profile::getair_temp_day1() { return this->air_temp_day1; }
std::vector<int> & temp_profile::getlayer_thick() { return this->layer_thick; }
void temp_profile::setair_temp_day1(double _air_temp_day1) { this->air_temp_day1 = _air_temp_day1; }
void temp_profile::setlayer_thick(std::vector<int> const &_layer_thick){
    this->layer_thick = _layer_thick;
}
void temp_profile::Calculate_Model(soil_tempState &s, soil_tempState &s1, soil_tempRate &r, soil_tempAuxiliary &a, soil_tempExogenous &ex)
{
    //- Name: temp_profile -Version: 1.0, -Time step: 1
    //- Description:
    //            * Title: tempprofile model
    //            * Authors: None
    //            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    //            * Institution: INRAE
    //            * ExtendedDescription: None
    //            * ShortDescription: None
    //- inputs:
    //            * name: temp_amp
    //                          ** description : current temperature amplitude
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 100.0
    //                          ** min : 0.0
    //                          ** default : 0.0
    //                          ** unit : degC
    //            * name: prev_temp_profile
    //                          ** description : previous soil temperature profile (for 1 cm layers)
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 
    //                          ** unit : degC
    //            * name: prev_canopy_temp
    //                          ** description : previous crop temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : 0.0
    //                          ** default : 
    //                          ** unit : degC
    //            * name: min_air_temp
    //                          ** description : current minimum air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 
    //                          ** unit : degC
    //            * name: air_temp_day1
    //                          ** description : Mean temperature on first day
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 100.0
    //                          ** min : 0.0
    //                          ** default : 0.0
    //                          ** unit : degC
    //            * name: layer_thick
    //                          ** description : layers thickness
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INTARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : cm
    //- outputs:
    //            * name: temp_profile
    //                          ** description : current soil profile temperature (for 1 cm layers)
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** unit : degC
    int z;
    int n;
    std::vector<double> vexp;
    double therm_diff = 5.37e-3;
    double temp_freq = 7.272e-5;
    double therm_amp;
    n = s.prev_temp_profile.size();
    s.temp_profile = std::vector<double> (n);
    vexp = std::vector<double>(n);
    therm_amp = std::sqrt(temp_freq / 2 / therm_diff);
    for (z=1 ; z!=n + 1 ; z+=1)
    {
        vexp[z - 1] = std::exp(-(z * therm_amp));
    }
    for (z=1 ; z!=n + 1 ; z+=1)
    {
        s.temp_profile[z - 1] = s.prev_temp_profile[z - 1] - (vexp[(z - 1)] * (s.prev_canopy_temp - ex.min_air_temp)) + (0.1 * (s.prev_canopy_temp - s.prev_temp_profile[z - 1])) + (s.temp_amp * vexp[(z - 1)] / 2);
    }
}