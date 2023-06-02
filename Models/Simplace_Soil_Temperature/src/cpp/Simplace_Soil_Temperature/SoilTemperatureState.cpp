#include "SoilTemperatureState.h"
SoilTemperatureState::SoilTemperatureState() { }

double SoilTemperatureState::getAlbedo() {return this-> Albedo; }
double SoilTemperatureState::getSnowWaterContent() {return this-> SnowWaterContent; }
double SoilTemperatureState::getSoilSurfaceTemperature() {return this-> SoilSurfaceTemperature; }
int SoilTemperatureState::getAgeOfSnow() {return this-> AgeOfSnow; }
vector<double> & SoilTemperatureState::getrSoilTempArrayRate() {return this-> rSoilTempArrayRate; }
vector<double> & SoilTemperatureState::getpSoilLayerDepth() {return this-> pSoilLayerDepth; }
vector<double> & SoilTemperatureState::getSoilTempArray() {return this-> SoilTempArray; }

void SoilTemperatureState::setAlbedo(double _Albedo) { this->Albedo = _Albedo; }
void SoilTemperatureState::setSnowWaterContent(double _SnowWaterContent) { this->SnowWaterContent = _SnowWaterContent; }
void SoilTemperatureState::setSoilSurfaceTemperature(double _SoilSurfaceTemperature) { this->SoilSurfaceTemperature = _SoilSurfaceTemperature; }
void SoilTemperatureState::setAgeOfSnow(int _AgeOfSnow) { this->AgeOfSnow = _AgeOfSnow; }
void SoilTemperatureState::setrSoilTempArrayRate(vector<double> const & _rSoilTempArrayRate){
    this->rSoilTempArrayRate = _rSoilTempArrayRate;
}
void SoilTemperatureState::setpSoilLayerDepth(vector<double> const & _pSoilLayerDepth){
    this->pSoilLayerDepth = _pSoilLayerDepth;
}
void SoilTemperatureState::setSoilTempArray(vector<double> const & _SoilTempArray){
    this->SoilTempArray = _SoilTempArray;
}