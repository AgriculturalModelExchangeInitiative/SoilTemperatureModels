#include "SurfacePartonSoilSWATHourlyPartonCExogenous.h"
using namespace BiomaSurfacePartonSoilSWATHourlyPartonC;

SurfacePartonSoilSWATHourlyPartonCExogenous::SurfacePartonSoilSWATHourlyPartonCExogenous() {}

double SurfacePartonSoilSWATHourlyPartonCExogenous::getAirTemperatureMaximum() { return this->AirTemperatureMaximum; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getGlobalSolarRadiation() { return this->GlobalSolarRadiation; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getAirTemperatureMinimum() { return this->AirTemperatureMinimum; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getDayLength() { return this->DayLength; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getHourOfSunrise() { return this->HourOfSunrise; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getHourOfSunset() { return this->HourOfSunset; }

void SurfacePartonSoilSWATHourlyPartonCExogenous::setAirTemperatureMaximum(double _AirTemperatureMaximum) { this->AirTemperatureMaximum = _AirTemperatureMaximum; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setGlobalSolarRadiation(double _GlobalSolarRadiation) { this->GlobalSolarRadiation = _GlobalSolarRadiation; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setAirTemperatureMinimum(double _AirTemperatureMinimum) { this->AirTemperatureMinimum = _AirTemperatureMinimum; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setDayLength(double _DayLength) { this->DayLength = _DayLength; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setHourOfSunrise(double _HourOfSunrise) { this->HourOfSunrise = _HourOfSunrise; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setHourOfSunset(double _HourOfSunset) { this->HourOfSunset = _HourOfSunset; }