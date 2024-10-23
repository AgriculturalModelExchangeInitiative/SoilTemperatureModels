#include "soil_tempState.h"
using namespace Stics_soil_temperature;

soil_tempState::soil_tempState() {}

std::vector<double> & soil_tempState::getprev_temp_profile() { return this->prev_temp_profile; }
double soil_tempState::getprev_canopy_temp() { return this->prev_canopy_temp; }
double soil_tempState::gettemp_amp() { return this->temp_amp; }
std::vector<double> & soil_tempState::gettemp_profile() { return this->temp_profile; }
std::vector<double> & soil_tempState::getlayer_temp() { return this->layer_temp; }
double soil_tempState::getcanopy_temp_avg() { return this->canopy_temp_avg; }

void soil_tempState::setprev_temp_profile(std::vector<double> const &_prev_temp_profile){
    this->prev_temp_profile = _prev_temp_profile;
}
void soil_tempState::setprev_canopy_temp(double _prev_canopy_temp) { this->prev_canopy_temp = _prev_canopy_temp; }
void soil_tempState::settemp_amp(double _temp_amp) { this->temp_amp = _temp_amp; }
void soil_tempState::settemp_profile(std::vector<double> const &_temp_profile){
    this->temp_profile = _temp_profile;
}
void soil_tempState::setlayer_temp(std::vector<double> const &_layer_temp){
    this->layer_temp = _layer_temp;
}
void soil_tempState::setcanopy_temp_avg(double _canopy_temp_avg) { this->canopy_temp_avg = _canopy_temp_avg; }