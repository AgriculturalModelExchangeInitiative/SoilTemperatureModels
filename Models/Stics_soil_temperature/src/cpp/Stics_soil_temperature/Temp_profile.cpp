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
    double min_air_temp = ex.getmin_air_temp();
    double temp_amp = 0.0;
    std::vector<double> prev_temp_profile;
    double prev_canopy_temp;
    prev_temp_profile = std::vector<double>();
    prev_canopy_temp = 0.0;
    int soil_depth;
    soil_depth = accumulate(layer_thick.begin(), layer_thick.end(), decltype(layer_thick)::value_type(0));
    prev_temp_profile = std::vector<double>(soil_depth);
    prev_temp_profile.assign(soil_depth, air_temp_day1);
    prev_canopy_temp = air_temp_day1;
    s.settemp_amp(temp_amp);
    s.setprev_temp_profile(prev_temp_profile);
    s.setprev_canopy_temp(prev_canopy_temp);
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
    //                          ** datatype : DOUBLELIST
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
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** unit : degC
    double temp_amp = s.gettemp_amp();
    std::vector<double>& prev_temp_profile = s.getprev_temp_profile();
    double prev_canopy_temp = s.getprev_canopy_temp();
    double min_air_temp = ex.getmin_air_temp();
    std::vector<double> temp_profile;
    int z;
    int n;
    std::vector<double> vexp;
    double therm_diff = 5.37e-3;
    double temp_freq = 7.272e-5;
    double therm_amp;
    n = prev_temp_profile.size();
    temp_profile = std::vector<double>(n);
    vexp = std::vector<double>(n);
    therm_amp = std::sqrt(temp_freq / 2 / therm_diff);
    for (z=1 ; z!=n + 1 ; z+=1)
    {
        vexp[z - 1] = std::exp(-(z * therm_amp));
    }
    for (z=1 ; z!=n + 1 ; z+=1)
    {
        temp_profile[z - 1] = prev_temp_profile[z - 1] - (vexp[(z - 1)] * (prev_canopy_temp - min_air_temp)) + (0.1 * (prev_canopy_temp - prev_temp_profile[z - 1])) + (temp_amp * vexp[(z - 1)] / 2);
    }
    s.settemp_profile(temp_profile);
}