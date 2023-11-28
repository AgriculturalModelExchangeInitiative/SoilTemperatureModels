#include "SurfacePartonSoilSWATCExogenous.h"
SurfacePartonSoilSWATCExogenous::SurfacePartonSoilSWATCExogenous() { }

double SurfacePartonSoilSWATCExogenous::getDayLength() {return this-> DayLength; }
double SurfacePartonSoilSWATCExogenous::getAboveGroundBiomass() {return this-> AboveGroundBiomass; }
double SurfacePartonSoilSWATCExogenous::getAirTemperatureMaximum() {return this-> AirTemperatureMaximum; }
double SurfacePartonSoilSWATCExogenous::getGlobalSolarRadiation() {return this-> GlobalSolarRadiation; }
double SurfacePartonSoilSWATCExogenous::getAirTemperatureMinimum() {return this-> AirTemperatureMinimum; }

void SurfacePartonSoilSWATCExogenous::setDayLength(double _DayLength) { this->DayLength = _DayLength; }
void SurfacePartonSoilSWATCExogenous::setAboveGroundBiomass(double _AboveGroundBiomass) { this->AboveGroundBiomass = _AboveGroundBiomass; }
void SurfacePartonSoilSWATCExogenous::setAirTemperatureMaximum(double _AirTemperatureMaximum) { this->AirTemperatureMaximum = _AirTemperatureMaximum; }
void SurfacePartonSoilSWATCExogenous::setGlobalSolarRadiation(double _GlobalSolarRadiation) { this->GlobalSolarRadiation = _GlobalSolarRadiation; }
void SurfacePartonSoilSWATCExogenous::setAirTemperatureMinimum(double _AirTemperatureMinimum) { this->AirTemperatureMinimum = _AirTemperatureMinimum; }