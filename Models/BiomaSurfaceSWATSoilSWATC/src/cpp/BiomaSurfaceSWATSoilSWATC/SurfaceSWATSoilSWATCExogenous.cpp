#include "SurfaceSWATSoilSWATCExogenous.h"

SurfaceSWATSoilSWATCExogenous::SurfaceSWATSoilSWATCExogenous() { }

double SurfaceSWATSoilSWATCExogenous::getGlobalSolarRadiation() {return this-> GlobalSolarRadiation; }
double SurfaceSWATSoilSWATCExogenous::getAirTemperatureMaximum() {return this-> AirTemperatureMaximum; }
double SurfaceSWATSoilSWATCExogenous::getAirTemperatureMinimum() {return this-> AirTemperatureMinimum; }
double SurfaceSWATSoilSWATCExogenous::getAlbedo() {return this-> Albedo; }
double SurfaceSWATSoilSWATCExogenous::getWaterEquivalentOfSnowPack() {return this-> WaterEquivalentOfSnowPack; }
double SurfaceSWATSoilSWATCExogenous::getAirTemperatureAnnualAverage() {return this-> AirTemperatureAnnualAverage; }

void SurfaceSWATSoilSWATCExogenous::setGlobalSolarRadiation(double _GlobalSolarRadiation) { this->GlobalSolarRadiation = _GlobalSolarRadiation; }
void SurfaceSWATSoilSWATCExogenous::setAirTemperatureMaximum(double _AirTemperatureMaximum) { this->AirTemperatureMaximum = _AirTemperatureMaximum; }
void SurfaceSWATSoilSWATCExogenous::setAirTemperatureMinimum(double _AirTemperatureMinimum) { this->AirTemperatureMinimum = _AirTemperatureMinimum; }
void SurfaceSWATSoilSWATCExogenous::setAlbedo(double _Albedo) { this->Albedo = _Albedo; }
void SurfaceSWATSoilSWATCExogenous::setWaterEquivalentOfSnowPack(double _WaterEquivalentOfSnowPack) { this->WaterEquivalentOfSnowPack = _WaterEquivalentOfSnowPack; }
void SurfaceSWATSoilSWATCExogenous::setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage) { this->AirTemperatureAnnualAverage = _AirTemperatureAnnualAverage; }