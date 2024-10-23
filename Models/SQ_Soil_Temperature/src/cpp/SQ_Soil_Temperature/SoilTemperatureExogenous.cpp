#include "SoilTemperatureExogenous.h"
using namespace SQ_Soil_Temperature;


SoilTemperatureExogenous::SoilTemperatureExogenous() {}

double SoilTemperatureExogenous::getmeanTAir() { return this->meanTAir; }
double SoilTemperatureExogenous::getminTAir() { return this->minTAir; }
double SoilTemperatureExogenous::getmeanAnnualAirTemp() { return this->meanAnnualAirTemp; }
double SoilTemperatureExogenous::getmaxTAir() { return this->maxTAir; }
double SoilTemperatureExogenous::getdayLength() { return this->dayLength; }

void SoilTemperatureExogenous::setmeanTAir(double _meanTAir) { this->meanTAir = _meanTAir; }
void SoilTemperatureExogenous::setminTAir(double _minTAir) { this->minTAir = _minTAir; }
void SoilTemperatureExogenous::setmeanAnnualAirTemp(double _meanAnnualAirTemp) { this->meanAnnualAirTemp = _meanAnnualAirTemp; }
void SoilTemperatureExogenous::setmaxTAir(double _maxTAir) { this->maxTAir = _maxTAir; }
void SoilTemperatureExogenous::setdayLength(double _dayLength) { this->dayLength = _dayLength; }