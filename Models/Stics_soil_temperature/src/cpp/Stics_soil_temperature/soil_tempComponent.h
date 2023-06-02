#include "temp_amp.h"
#include "temp_profile.h"
#include "layers_temp.h"
#include "canopy_temp_avg.h"
#include "update.h"
using namespace std;

class soil_tempComponent
{
    private:
        double air_temp_day1 ;
        vector<int> layer_thick ;
    public:
        soil_tempComponent();
        soil_tempComponent(soil_tempComponent& copy);
        void  Calculate_Model(soil_tempState& s, soil_tempState& s1, soil_tempRate& r, soil_tempAuxiliary& a, soil_tempExogenous& ex);
        void  Init(soil_tempState& s,soil_tempState& s1, soil_tempRate& r, soil_tempAuxiliary& a, soil_tempExogenous& ex);
        double getair_temp_day1();
        void setair_temp_day1(double _air_temp_day1);
        vector<int> & getlayer_thick();
        void setlayer_thick(const vector<int> &  _layer_thick);

        temp_amp _temp_amp;
        temp_profile _temp_profile;
        layers_temp _layers_temp;
        canopy_temp_avg _canopy_temp_avg;
        update _update;

};