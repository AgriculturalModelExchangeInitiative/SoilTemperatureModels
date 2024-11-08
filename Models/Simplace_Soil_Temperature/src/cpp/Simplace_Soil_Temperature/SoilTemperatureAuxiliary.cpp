#include "SoilTemperatureAuxiliary.h"
using namespace Simplace_Soil_Temperature;

SoilTemperatureAuxiliary::SoilTemperatureAuxiliary() {}

std::vector<double> & SoilTemperatureAuxiliary::getSoilTempArray() { return this->SoilTempArray; }
std::vector<double> & SoilTemperatureAuxiliary::getiSoilTempArray() { return this->iSoilTempArray; }
double SoilTemperatureAuxiliary::getSnowIsolationIndex() { return this->SnowIsolationIndex; }
double SoilTemperatureAuxiliary::getiSoilSurfaceTemperature() { return this->iSoilSurfaceTemperature; }

void SoilTemperatureAuxiliary::setSoilTempArray(std::vector<double> const &_SoilTempArray){
    this->SoilTempArray = _SoilTempArray;
}
void SoilTemperatureAuxiliary::setiSoilTempArray(std::vector<double> const &_iSoilTempArray){
    this->iSoilTempArray = _iSoilTempArray;
}
void SoilTemperatureAuxiliary::setSnowIsolationIndex(double _SnowIsolationIndex) { this->SnowIsolationIndex = _SnowIsolationIndex; }
void SoilTemperatureAuxiliary::setiSoilSurfaceTemperature(double _iSoilSurfaceTemperature) { this->iSoilSurfaceTemperature = _iSoilSurfaceTemperature; }