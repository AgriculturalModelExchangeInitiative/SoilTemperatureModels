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
class layers_temp
{
    private:
        vector<int> layer_thick ;
    public:
        layers_temp();
        void  Calculate_Model(soil_tempState& s, soil_tempState& s1, soil_tempRate& r, soil_tempAuxiliary& a, soil_tempExogenous& ex);
        void  Init(soil_tempState& s,soil_tempState& s1, soil_tempRate& r, soil_tempAuxiliary& a, soil_tempExogenous& ex);
        int get_layers_number(vector<int>  layer_thick_or_depth);
        vector<int> layer_thickness2depth(vector<int>  layer_thick);
        vector<int> & getlayer_thick();
        void setlayer_thick(const vector<int> &  _layer_thick);

};