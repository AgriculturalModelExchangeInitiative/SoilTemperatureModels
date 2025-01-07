
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "soil_tempState.h"
#include "soil_tempRate.h"
#include "soil_tempAuxiliary.h"
#include "soil_tempExogenous.h"
namespace Stics_soil_temperature {
class layers_temp
{
private:
    std::vector<int> layer_thick;
public:
    layers_temp();

    void Calculate_Model(soil_tempState &s, soil_tempState &s1, soil_tempRate &r, soil_tempAuxiliary &a, soil_tempExogenous &ex);

    int get_layers_number(std::vector<int>  layer_thick_or_depth);

    std::vector<int> layer_thickness2depth(std::vector<int>  layer_thick);

    std::vector<int> & getlayer_thick();
    void setlayer_thick(const std::vector<int> &  _layer_thick);
};
}