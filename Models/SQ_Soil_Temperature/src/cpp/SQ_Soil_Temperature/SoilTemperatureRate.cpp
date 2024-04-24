#include "SoilTemperatureRate.h"
using namespace SQ_Soil_Temperature;

SoilTemperatureRate::SoilTemperatureRate() {}

double SoilTemperatureRate::getheatFlux() { return this->heatFlux; }

void SoilTemperatureRate::setheatFlux(double _heatFlux) { this->heatFlux = _heatFlux; }