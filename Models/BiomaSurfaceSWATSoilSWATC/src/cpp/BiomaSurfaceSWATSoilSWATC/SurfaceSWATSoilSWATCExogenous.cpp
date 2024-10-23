#include "SurfaceSWATSoilSWATCExogenous.h"
using namespace BiomaSurfaceSWATSoilSWATC;

SurfaceSWATSoilSWATCExogenous::SurfaceSWATSoilSWATCExogenous() {}

double SurfaceSWATSoilSWATCExogenous::getAirTemperatureMaximum() { return this->AirTemperatureMaximum; }
double SurfaceSWATSoilSWATCExogenous::getAirTemperatureMinimum() { return this->AirTemperatureMinimum; }
double SurfaceSWATSoilSWATCExogenous::getGlobalSolarRadiation() { return this->GlobalSolarRadiation; }
double SurfaceSWATSoilSWATCExogenous::getWaterEquivalentOfSnowPack() { return this->WaterEquivalentOfSnowPack; }
double SurfaceSWATSoilSWATCExogenous::getAlbedo() { return this->Albedo; }
std::vector<double> & SurfaceSWATSoilSWATCExogenous::getVolumetricWaterContent() { return this->VolumetricWaterContent; }

void SurfaceSWATSoilSWATCExogenous::setAirTemperatureMaximum(double _AirTemperatureMaximum) { this->AirTemperatureMaximum = _AirTemperatureMaximum; }
void SurfaceSWATSoilSWATCExogenous::setAirTemperatureMinimum(double _AirTemperatureMinimum) { this->AirTemperatureMinimum = _AirTemperatureMinimum; }
void SurfaceSWATSoilSWATCExogenous::setGlobalSolarRadiation(double _GlobalSolarRadiation) { this->GlobalSolarRadiation = _GlobalSolarRadiation; }
void SurfaceSWATSoilSWATCExogenous::setWaterEquivalentOfSnowPack(double _WaterEquivalentOfSnowPack) { this->WaterEquivalentOfSnowPack = _WaterEquivalentOfSnowPack; }
void SurfaceSWATSoilSWATCExogenous::setAlbedo(double _Albedo) { this->Albedo = _Albedo; }
void SurfaceSWATSoilSWATCExogenous::setVolumetricWaterContent(std::vector<double> const &_VolumetricWaterContent){
    this->VolumetricWaterContent = _VolumetricWaterContent;
}