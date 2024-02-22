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
#include "layers_temp.h"
using namespace Stics_soil_temperature;
layers_temp::layers_temp() {}
std::vector<int> & layers_temp::getlayer_thick() { return this->layer_thick; }
void layers_temp::setlayer_thick(std::vector<int> const &_layer_thick){
    this->layer_thick = _layer_thick;
}
void layers_temp::Calculate_Model(soil_tempState &s, soil_tempState &s1, soil_tempRate &r, soil_tempAuxiliary &a, soil_tempExogenous &ex)
{
    //- Name: layers_temp -Version: 1.0, -Time step: 1
    //- Description:
    //            * Title: layers mean temperature model
    //            * Authors: None
    //            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    //            * Institution: INRAE
    //            * ExtendedDescription: None
    //            * ShortDescription: None
    //- inputs:
    //            * name: temp_profile
    //                          ** description : soil temperature profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLELIST
    //                          ** max : 50.0
    //                          ** min : -50.0
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
    //            * name: layer_temp
    //                          ** description : soil layers temperature
    //                          ** datatype : DOUBLELIST
    //                          ** variablecategory : state
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** unit : degC
    std::vector<double>& temp_profile = s.gettemp_profile();
    std::vector<double> layer_temp;
    int z;
    int layers_nb;
    std::vector<int> up_depth;
    std::vector<int> layer_depth;
    int depth_value;
    layers_nb = get_layers_number(layer_thick);
    layer_temp = std::vector<double>(layers_nb);
    up_depth = std::vector<int>(layers_nb + 1);
    layer_depth = std::vector<int>(layers_nb);
    up_depth.assign(layers_nb + 1, 0);
    layer_depth = layer_thickness2depth(layer_thick);
    for (z=1 ; z!=layers_nb + 1 ; z+=1)
    {
        depth_value = layer_depth[z - 1];
        up_depth[z + 1 - 1] = depth_value;
    }
    for (z=1 ; z!=layers_nb + 1 ; z+=1)
    {
        layer_temp[z - 1] = std::accumulate(temp_profile.begin() + (up_depth[z - 1] + 1 - 1),temp_profile.begin() + up_depth[(z + 1 - 1)], 0.0) / layer_thick[(z - 1)];
    }
    s.setlayer_temp(layer_temp);
}
int layers_temp::get_layers_number(std::vector<int> layer_thick_or_depth)
{
    int layers_number;
    int z;
    layers_number = 0;
    for (z=1 ; z!=layer_thick_or_depth.size() + 1 ; z+=1)
    {
        if (layer_thick_or_depth[z - 1] != 0)
        {
            layers_number = layers_number + 1;
        }
    }
    return layers_number;
}
std::vector<int> layers_temp::layer_thickness2depth(std::vector<int> layer_thick)
{
    std::vector<int> layer_depth;
    int layers_nb;
    int z;
    layers_nb = layer_thick.size();
    layer_depth = std::vector<int>(layers_nb);
    layer_depth.assign(layers_nb, 0);
    for (z=1 ; z!=layers_nb + 1 ; z+=1)
    {
        if (layer_thick[z - 1] != 0)
        {
            layer_depth[z - 1] = std::accumulate(layer_thick.begin() + 1 - 1,layer_thick.begin() + z, 0.0);
        }
    }
    return layer_depth;
}