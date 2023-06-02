#include "soil_tempExogenous.h"
soil_tempExogenous::soil_tempExogenous() { }

double soil_tempExogenous::getmin_temp() {return this-> min_temp; }
double soil_tempExogenous::getmax_temp() {return this-> max_temp; }
double soil_tempExogenous::getmin_air_temp() {return this-> min_air_temp; }
double soil_tempExogenous::getmin_canopy_temp() {return this-> min_canopy_temp; }
double soil_tempExogenous::getmax_canopy_temp() {return this-> max_canopy_temp; }
double soil_tempExogenous::getprev_canopy_temp() {return this-> prev_canopy_temp; }

void soil_tempExogenous::setmin_temp(double _min_temp) { this->min_temp = _min_temp; }
void soil_tempExogenous::setmax_temp(double _max_temp) { this->max_temp = _max_temp; }
void soil_tempExogenous::setmin_air_temp(double _min_air_temp) { this->min_air_temp = _min_air_temp; }
void soil_tempExogenous::setmin_canopy_temp(double _min_canopy_temp) { this->min_canopy_temp = _min_canopy_temp; }
void soil_tempExogenous::setmax_canopy_temp(double _max_canopy_temp) { this->max_canopy_temp = _max_canopy_temp; }
void soil_tempExogenous::setprev_canopy_temp(double _prev_canopy_temp) { this->prev_canopy_temp = _prev_canopy_temp; }