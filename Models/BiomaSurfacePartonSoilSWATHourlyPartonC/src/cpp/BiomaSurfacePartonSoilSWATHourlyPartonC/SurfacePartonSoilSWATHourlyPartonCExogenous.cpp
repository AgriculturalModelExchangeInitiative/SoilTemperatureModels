#include "SurfacePartonSoilSWATHourlyPartonCExogenous.h"
SurfacePartonSoilSWATHourlyPartonCExogenous::SurfacePartonSoilSWATHourlyPartonCExogenous() { }

double SurfacePartonSoilSWATHourlyPartonCExogenous::getGlobalSolarRadiation() {return this-> GlobalSolarRadiation; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getDayLength() {return this-> DayLength; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getAirTemperatureMinimum() {return this-> AirTemperatureMinimum; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getAirTemperatureMaximum() {return this-> AirTemperatureMaximum; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getAirTemperatureAnnualAverage() {return this-> AirTemperatureAnnualAverage; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getHourOfSunrise() {return this-> HourOfSunrise; }
double SurfacePartonSoilSWATHourlyPartonCExogenous::getHourOfSunset() {return this-> HourOfSunset; }

void SurfacePartonSoilSWATHourlyPartonCExogenous::setGlobalSolarRadiation(double _GlobalSolarRadiation) { this->GlobalSolarRadiation = _GlobalSolarRadiation; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setDayLength(double _DayLength) { this->DayLength = _DayLength; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setAirTemperatureMinimum(double _AirTemperatureMinimum) { this->AirTemperatureMinimum = _AirTemperatureMinimum; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setAirTemperatureMaximum(double _AirTemperatureMaximum) { this->AirTemperatureMaximum = _AirTemperatureMaximum; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage) { this->AirTemperatureAnnualAverage = _AirTemperatureAnnualAverage; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setHourOfSunrise(double _HourOfSunrise) { this->HourOfSunrise = _HourOfSunrise; }
void SurfacePartonSoilSWATHourlyPartonCExogenous::setHourOfSunset(double _HourOfSunset) { this->HourOfSunset = _HourOfSunset; }