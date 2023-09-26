#include "SoilTemperatureCompExogenous.h"

SoilTemperatureCompExogenous::SoilTemperatureCompExogenous() { }

double SoilTemperatureCompExogenous::gettmin() {return this-> tmin; }
double SoilTemperatureCompExogenous::gettmax() {return this-> tmax; }
double SoilTemperatureCompExogenous::getglobrad() {return this-> globrad; }

void SoilTemperatureCompExogenous::settmin(double _tmin) { this->tmin = _tmin; }
void SoilTemperatureCompExogenous::settmax(double _tmax) { this->tmax = _tmax; }
void SoilTemperatureCompExogenous::setglobrad(double _globrad) { this->globrad = _globrad; }