#include "SurfacePartonSoilSWATCExogenous.h"
using namespace BiomaSurfacePartonSoilSWATC;

SurfacePartonSoilSWATCExogenous::SurfacePartonSoilSWATCExogenous() {}

double SurfacePartonSoilSWATCExogenous::getAboveGroundBiomass() { return this->AboveGroundBiomass; }
double SurfacePartonSoilSWATCExogenous::getDayLength() { return this->DayLength; }
double SurfacePartonSoilSWATCExogenous::getAirTemperatureMinimum() { return this->AirTemperatureMinimum; }
double SurfacePartonSoilSWATCExogenous::getGlobalSolarRadiation() { return this->GlobalSolarRadiation; }
double SurfacePartonSoilSWATCExogenous::getAirTemperatureMaximum() { return this->AirTemperatureMaximum; }

void SurfacePartonSoilSWATCExogenous::setAboveGroundBiomass(double _AboveGroundBiomass) { this->AboveGroundBiomass = _AboveGroundBiomass; }
void SurfacePartonSoilSWATCExogenous::setDayLength(double _DayLength) { this->DayLength = _DayLength; }
void SurfacePartonSoilSWATCExogenous::setAirTemperatureMinimum(double _AirTemperatureMinimum) { this->AirTemperatureMinimum = _AirTemperatureMinimum; }
void SurfacePartonSoilSWATCExogenous::setGlobalSolarRadiation(double _GlobalSolarRadiation) { this->GlobalSolarRadiation = _GlobalSolarRadiation; }
void SurfacePartonSoilSWATCExogenous::setAirTemperatureMaximum(double _AirTemperatureMaximum) { this->AirTemperatureMaximum = _AirTemperatureMaximum; }