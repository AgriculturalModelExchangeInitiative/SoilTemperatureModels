#include "SurfacePartonSoilSWATHourlyPartonCExogenous.h"
using namespace BiomaSurfacePartonSoilSWATHourlyPartonC;

SurfacePartonSoilSWATHourlyPartonCExogenous::SurfacePartonSoilSWATHourlyPartonCExogenous() {}

double SurfacePartonSoilSWATHourlyPartonCExogenous::getAirTemperatureMinimum() { return this->AirTemperatureMinimum; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getDayLength() { return this->DayLength; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getGlobalSolarRadiation() { return this->GlobalSolarRadiation; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getAirTemperatureMaximum() { return this->AirTemperatureMaximum; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCExogenous::getVolumetricWaterContent() { return this->VolumetricWaterContent; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getHourOfSunset() { return this->HourOfSunset; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getHourOfSunrise() { return this->HourOfSunrise; }

void SurfacePartonSoilSWATHourlyPartonCExogenous::setAirTemperatureMinimum(double _AirTemperatureMinimum) { this->AirTemperatureMinimum = _AirTemperatureMinimum; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setDayLength(double _DayLength) { this->DayLength = _DayLength; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setGlobalSolarRadiation(double _GlobalSolarRadiation) { this->GlobalSolarRadiation = _GlobalSolarRadiation; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setAirTemperatureMaximum(double _AirTemperatureMaximum) { this->AirTemperatureMaximum = _AirTemperatureMaximum; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setVolumetricWaterContent(std::vector<double> const &_VolumetricWaterContent){
    this->VolumetricWaterContent = _VolumetricWaterContent;
}
void SurfacePartonSoilSWATHourlyPartonCExogenous::setHourOfSunset(double _HourOfSunset) { this->HourOfSunset = _HourOfSunset; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setHourOfSunrise(double _HourOfSunrise) { this->HourOfSunrise = _HourOfSunrise; }