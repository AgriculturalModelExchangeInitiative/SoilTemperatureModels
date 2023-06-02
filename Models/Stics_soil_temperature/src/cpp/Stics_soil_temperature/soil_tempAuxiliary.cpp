#include "soil_tempAuxiliary.h"

soil_tempAuxiliary::soil_tempAuxiliary() { }

double soil_tempAuxiliary::gettemp_wave_freq() {return this-> temp_wave_freq; }
double soil_tempAuxiliary::gettherm_diff() {return this-> therm_diff; }

void soil_tempAuxiliary::settemp_wave_freq(double _temp_wave_freq) { this->temp_wave_freq = _temp_wave_freq; }
void soil_tempAuxiliary::settherm_diff(double _therm_diff) { this->therm_diff = _therm_diff; }