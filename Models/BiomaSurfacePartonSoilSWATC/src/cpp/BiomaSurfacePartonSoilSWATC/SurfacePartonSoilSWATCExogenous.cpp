#include "SurfacePartonSoilSWATCExogenous.h"
using namespace BiomaSurfacePartonSoilSWATC;

SurfacePartonSoilSWATCExogenous::SurfacePartonSoilSWATCExogenous() {}

double SurfacePartonSoilSWATCExogenous::getDayLength() { return this->DayLength; }
double SurfacePartonSoilSWATCExogenous::getGlobalSolarRadiation() { return this->GlobalSolarRadiation; }
double SurfacePartonSoilSWATCExogenous::getAboveGroundBiomass() { return this->AboveGroundBiomass; }
double SurfacePartonSoilSWATCExogenous::getAirTemperatureMinimum() { return this->AirTemperatureMinimum; }
double SurfacePartonSoilSWATCExogenous::getAirTemperatureMaximum() { return this->AirTemperatureMaximum; }
std::vector<double> & SurfacePartonSoilSWATCExogenous::getVolumetricWaterContent() { return this->VolumetricWaterContent; }

void SurfacePartonSoilSWATCExogenous::setDayLength(double _DayLength) { this->DayLength = _DayLength; }
void SurfacePartonSoilSWATCExogenous::setGlobalSolarRadiation(double _GlobalSolarRadiation) { this->GlobalSolarRadiation = _GlobalSolarRadiation; }
void SurfacePartonSoilSWATCExogenous::setAboveGroundBiomass(double _AboveGroundBiomass) { this->AboveGroundBiomass = _AboveGroundBiomass; }
void SurfacePartonSoilSWATCExogenous::setAirTemperatureMinimum(double _AirTemperatureMinimum) { this->AirTemperatureMinimum = _AirTemperatureMinimum; }
void SurfacePartonSoilSWATCExogenous::setAirTemperatureMaximum(double _AirTemperatureMaximum) { this->AirTemperatureMaximum = _AirTemperatureMaximum; }
void SurfacePartonSoilSWATCExogenous::setVolumetricWaterContent(std::vector<double> const &_VolumetricWaterContent){
    this->VolumetricWaterContent = _VolumetricWaterContent;
}