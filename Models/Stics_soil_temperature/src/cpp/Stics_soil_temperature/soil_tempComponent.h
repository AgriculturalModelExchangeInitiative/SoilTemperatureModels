#include "temp_amp.h"
#include "therm_amp.h"
#include "temp_profile.h"
#include "canopy_temp_avg.h"
#include "layers_temp.h"
#include "update.h"
using namespace std;

class soil_tempComponent
{
    private:
        vector<int> layer_thick ;
        double air_temp_day1 ;
    public:
        soil_tempComponent();
        soil_tempComponent(soil_tempComponent& copy);
        void  Calculate_Model(soil_tempState& s, soil_tempState& s1, soil_tempRate& r, soil_tempAuxiliary& a, soil_tempExogenous& ex);
        void  Init(soil_tempState& s,soil_tempState& s1, soil_tempRate& r, soil_tempAuxiliary& a, soil_tempExogenous& ex);
        vector<int> & getlayer_thick();
        void setlayer_thick(const vector<int> &  _layer_thick);
        double getair_temp_day1();
        void setair_temp_day1(double _air_temp_day1);

        temp_amp _temp_amp;
        therm_amp _therm_amp;
        temp_profile _temp_profile;
        canopy_temp_avg _canopy_temp_avg;
        layers_temp _layers_temp;
        update _update;

};