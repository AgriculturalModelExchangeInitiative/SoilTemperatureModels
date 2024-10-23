#include "SoilTemperatureState.h"
using namespace SQ_Soil_Temperature;

SoilTemperatureState::SoilTemperatureState() {}

double SoilTemperatureState::getminTSoil() { return this->minTSoil; }
double SoilTemperatureState::getdeepLayerT() { return this->deepLayerT; }
double SoilTemperatureState::getmaxTSoil() { return this->maxTSoil; }
std::vector<double> & SoilTemperatureState::gethourlySoilT() { return this->hourlySoilT; }

void SoilTemperatureState::setminTSoil(double _minTSoil) { this->minTSoil = _minTSoil; }
void SoilTemperatureState::setdeepLayerT(double _deepLayerT) { this->deepLayerT = _deepLayerT; }
void SoilTemperatureState::setmaxTSoil(double _maxTSoil) { this->maxTSoil = _maxTSoil; }
void SoilTemperatureState::sethourlySoilT(std::vector<double> const &_hourlySoilT){
    this->hourlySoilT = _hourlySoilT;
}