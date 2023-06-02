#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "soil_tempState.h"
#include "soil_tempRate.h"
#include "soil_tempAuxiliary.h"
#include "soil_tempExogenous.h"
using namespace std;
class update
{
    private:
    public:
        update();
        void  Calculate_Model(soil_tempState& s, soil_tempState& s1, soil_tempRate& r, soil_tempAuxiliary& a, soil_tempExogenous& ex);
        void  Init(soil_tempState& s,soil_tempState& s1, soil_tempRate& r, soil_tempAuxiliary& a, soil_tempExogenous& ex);

};