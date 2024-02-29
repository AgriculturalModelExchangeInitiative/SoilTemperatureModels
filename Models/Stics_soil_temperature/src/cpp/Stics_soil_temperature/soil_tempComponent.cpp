#include "soil_tempComponent.h"
using namespace Stics_soil_temperature;
soil_tempComponent::soil_tempComponent()
{
       
}


double soil_tempComponent::getair_temp_day1(){ return this->air_temp_day1; }
std::vector<int> & soil_tempComponent::getlayer_thick(){ return this->layer_thick; }

void soil_tempComponent::setair_temp_day1(double _air_temp_day1)
{
    _Temp_profile.setair_temp_day1(_air_temp_day1);
}
void soil_tempComponent::setlayer_thick(const std::vector<int> & _layer_thick)
{
    _Temp_profile.setlayer_thick(_layer_thick);
    _Layers_temp.setlayer_thick(_layer_thick);
}
void soil_tempComponent::Calculate_Model(soil_tempState &s, soil_tempState &s1, soil_tempRate &r, soil_tempAuxiliary &a, soil_tempExogenous &ex)
{
    _Temp_amp.Calculate_Model(s, s1, r, a, ex);
    _Canopy_temp_avg.Calculate_Model(s, s1, r, a, ex);
    _Temp_profile.Calculate_Model(s, s1, r, a, ex);
    _Layers_temp.Calculate_Model(s, s1, r, a, ex);
    _Update.Calculate_Model(s, s1, r, a, ex);
}
soil_tempComponent::soil_tempComponent(soil_tempComponent& toCopy)
{
    air_temp_day1 = toCopy.getair_temp_day1();
    for (int i = 0; i < toCopy.getlayer_thick().size(); i++)
{
    layer_thick[i] = toCopy.getlayer_thick()[i];
}

}