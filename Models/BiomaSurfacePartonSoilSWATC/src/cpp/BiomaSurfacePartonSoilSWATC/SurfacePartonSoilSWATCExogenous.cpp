#include "SurfacePartonSoilSWATCExogenous.h"
SurfacePartonSoilSWATCExogenous::SurfacePartonSoilSWATCExogenous() { }

double SurfacePartonSoilSWATCExogenous::getDayLength() {return this-> DayLength; }
double SurfacePartonSoilSWATCExogenous::getAirTemperatureMaximum() {return this-> AirTemperatureMaximum; }
double SurfacePartonSoilSWATCExogenous::getAirTemperatureMinimum() {return this-> AirTemperatureMinimum; }
double SurfacePartonSoilSWATCExogenous::getGlobalSolarRadiation() {return this-> GlobalSolarRadiation; }
double SurfacePartonSoilSWATCExogenous::getAirTemperatureAnnualAverage() {return this-> AirTemperatureAnnualAverage; }

void SurfacePartonSoilSWATCExogenous::setDayLength(double _DayLength) { this->DayLength = _DayLength; }
void SurfacePartonSoilSWATCExogenous::setAirTemperatureMaximum(double _AirTemperatureMaximum) { this->AirTemperatureMaximum = _AirTemperatureMaximum; }
void SurfacePartonSoilSWATCExogenous::setAirTemperatureMinimum(double _AirTemperatureMinimum) { this->AirTemperatureMinimum = _AirTemperatureMinimum; }
void SurfacePartonSoilSWATCExogenous::setGlobalSolarRadiation(double _GlobalSolarRadiation) { this->GlobalSolarRadiation = _GlobalSolarRadiation; }
void SurfacePartonSoilSWATCExogenous::setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage) { this->AirTemperatureAnnualAverage = _AirTemperatureAnnualAverage; }