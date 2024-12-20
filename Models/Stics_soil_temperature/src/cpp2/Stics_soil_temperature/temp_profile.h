
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
class temp_profile
{
private:
    double air_temp_day1{0.0};
    std::vector<int> layer_thick;
public:
    temp_profile();

    void Calculate_Model(soil_tempState &s, soil_tempState &s1, soil_tempRate &r, soil_tempAuxiliary &a, soil_tempExogenous &ex);

    void Init(soil_tempState &s, soil_tempState &s1, soil_tempRate &r, soil_tempAuxiliary &a, soil_tempExogenous &ex);

    double getair_temp_day1();
    void setair_temp_day1(double _air_temp_day1);

    std::vector<int> & getlayer_thick();
    void setlayer_thick(const std::vector<int> &  _layer_thick);
};
}