#include "SoiltemperatureExogenous.h"

SoiltemperatureExogenous::SoiltemperatureExogenous() { }

double SoiltemperatureExogenous::gettmin() {return this-> tmin; }
double SoiltemperatureExogenous::gettmax() {return this-> tmax; }
double SoiltemperatureExogenous::getglobrad() {return this-> globrad; }

void SoiltemperatureExogenous::settmin(double _tmin) { this->tmin = _tmin; }
void SoiltemperatureExogenous::settmax(double _tmax) { this->tmax = _tmax; }
void SoiltemperatureExogenous::setglobrad(double _globrad) { this->globrad = _globrad; }