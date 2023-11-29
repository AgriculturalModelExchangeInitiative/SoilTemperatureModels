#include "SurfaceSWATSoilSWATCExogenous.h"
using namespace BiomaSurfaceSWATSoilSWATC;

SurfaceSWATSoilSWATCExogenous::SurfaceSWATSoilSWATCExogenous() {}

double SurfaceSWATSoilSWATCExogenous::getAlbedo() { return this->Albedo; }
double SurfaceSWATSoilSWATCExogenous::getAirTemperatureMinimum() { return this->AirTemperatureMinimum; }
double SurfaceSWATSoilSWATCExogenous::getWaterEquivalentOfSnowPack() { return this->WaterEquivalentOfSnowPack; }
double SurfaceSWATSoilSWATCExogenous::getGlobalSolarRadiation() { return this->GlobalSolarRadiation; }
double SurfaceSWATSoilSWATCExogenous::getAirTemperatureMaximum() { return this->AirTemperatureMaximum; }

void SurfaceSWATSoilSWATCExogenous::setAlbedo(double _Albedo) { this->Albedo = _Albedo; }
void SurfaceSWATSoilSWATCExogenous::setAirTemperatureMinimum(double _AirTemperatureMinimum) { this->AirTemperatureMinimum = _AirTemperatureMinimum; }
void SurfaceSWATSoilSWATCExogenous::setWaterEquivalentOfSnowPack(double _WaterEquivalentOfSnowPack) { this->WaterEquivalentOfSnowPack = _WaterEquivalentOfSnowPack; }
void SurfaceSWATSoilSWATCExogenous::setGlobalSolarRadiation(double _GlobalSolarRadiation) { this->GlobalSolarRadiation = _GlobalSolarRadiation; }
void SurfaceSWATSoilSWATCExogenous::setAirTemperatureMaximum(double _AirTemperatureMaximum) { this->AirTemperatureMaximum = _AirTemperatureMaximum; }