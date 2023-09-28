#include "SoilTemperatureCompExogenous.h"
using namespace Monica_SoilTemp;


SoilTemperatureCompExogenous::SoilTemperatureCompExogenous() {}

double SoilTemperatureCompExogenous::gettmin() { return this->tmin; }
double SoilTemperatureCompExogenous::gettmax() { return this->tmax; }
double SoilTemperatureCompExogenous::getglobrad() { return this->globrad; }
double SoilTemperatureCompExogenous::getsoilCoverage() { return this->soilCoverage; }
double SoilTemperatureCompExogenous::getsoilSurfaceTemperatureBelowSnow() { return this->soilSurfaceTemperatureBelowSnow; }
bool SoilTemperatureCompExogenous::gethasSnowCover() { return this->hasSnowCover; }

void SoilTemperatureCompExogenous::settmin(double _tmin) { this->tmin = _tmin; }
void SoilTemperatureCompExogenous::settmax(double _tmax) { this->tmax = _tmax; }
void SoilTemperatureCompExogenous::setglobrad(double _globrad) { this->globrad = _globrad; }
void SoilTemperatureCompExogenous::setsoilCoverage(double _soilCoverage) { this->soilCoverage = _soilCoverage; }
void SoilTemperatureCompExogenous::setsoilSurfaceTemperatureBelowSnow(double _soilSurfaceTemperatureBelowSnow) { this->soilSurfaceTemperatureBelowSnow = _soilSurfaceTemperatureBelowSnow; }
void SoilTemperatureCompExogenous::sethasSnowCover(bool _hasSnowCover) { this->hasSnowCover = _hasSnowCover; }