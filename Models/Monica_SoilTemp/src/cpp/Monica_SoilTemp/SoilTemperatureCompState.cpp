#include "SoilTemperatureCompState.h"
using namespace Monica_SoilTemp;

SoilTemperatureCompState::SoilTemperatureCompState() {}

double SoilTemperatureCompState::getsoilCoverage() { return this->soilCoverage; }
double SoilTemperatureCompState::getprevDaySoilSurfaceTemperature() { return this->prevDaySoilSurfaceTemperature; }
double SoilTemperatureCompState::getsoilSurfaceTemperatureBelowSnow() { return this->soilSurfaceTemperatureBelowSnow; }
bool SoilTemperatureCompState::gethasSnowCover() { return this->hasSnowCover; }
std::vector<double> & SoilTemperatureCompState::getprevDaySoilTemperature() { return this->prevDaySoilTemperature; }
std::vector<double> & SoilTemperatureCompState::getsoilTemperature() { return this->soilTemperature; }
std::vector<double> & SoilTemperatureCompState::getV() { return this->V; }
std::vector<double> & SoilTemperatureCompState::getB() { return this->B; }
std::vector<double> & SoilTemperatureCompState::getvolumeMatrix() { return this->volumeMatrix; }
std::vector<double> & SoilTemperatureCompState::getvolumeMatrixOld() { return this->volumeMatrixOld; }
std::vector<double> & SoilTemperatureCompState::getmatrixPrimaryDiagonal() { return this->matrixPrimaryDiagonal; }
std::vector<double> & SoilTemperatureCompState::getmatrixSecondaryDiagonal() { return this->matrixSecondaryDiagonal; }
std::vector<double> & SoilTemperatureCompState::getheatConductivity() { return this->heatConductivity; }
std::vector<double> & SoilTemperatureCompState::getheatConductivityMean() { return this->heatConductivityMean; }
std::vector<double> & SoilTemperatureCompState::getheatCapacity() { return this->heatCapacity; }
std::vector<double> & SoilTemperatureCompState::getsolution() { return this->solution; }
std::vector<double> & SoilTemperatureCompState::getmatrixDiagonal() { return this->matrixDiagonal; }
std::vector<double> & SoilTemperatureCompState::getmatrixLowerTriangle() { return this->matrixLowerTriangle; }
std::vector<double> & SoilTemperatureCompState::getheatFlow() { return this->heatFlow; }
double SoilTemperatureCompState::getsoilSurfaceTemperature() { return this->soilSurfaceTemperature; }
double SoilTemperatureCompState::getnoSnowSoilSurfaceTemperature() { return this->noSnowSoilSurfaceTemperature; }

void SoilTemperatureCompState::setsoilCoverage(double _soilCoverage) { this->soilCoverage = _soilCoverage; }
void SoilTemperatureCompState::setprevDaySoilSurfaceTemperature(double _prevDaySoilSurfaceTemperature) { this->prevDaySoilSurfaceTemperature = _prevDaySoilSurfaceTemperature; }
void SoilTemperatureCompState::setsoilSurfaceTemperatureBelowSnow(double _soilSurfaceTemperatureBelowSnow) { this->soilSurfaceTemperatureBelowSnow = _soilSurfaceTemperatureBelowSnow; }
void SoilTemperatureCompState::sethasSnowCover(bool _hasSnowCover) { this->hasSnowCover = _hasSnowCover; }
void SoilTemperatureCompState::setprevDaySoilTemperature(std::vector<double> const &_prevDaySoilTemperature){
    this->prevDaySoilTemperature = _prevDaySoilTemperature;
}
void SoilTemperatureCompState::setsoilTemperature(std::vector<double> const &_soilTemperature){
    this->soilTemperature = _soilTemperature;
}
void SoilTemperatureCompState::setV(std::vector<double> const &_V){
    this->V = _V;
}
void SoilTemperatureCompState::setB(std::vector<double> const &_B){
    this->B = _B;
}
void SoilTemperatureCompState::setvolumeMatrix(std::vector<double> const &_volumeMatrix){
    this->volumeMatrix = _volumeMatrix;
}
void SoilTemperatureCompState::setvolumeMatrixOld(std::vector<double> const &_volumeMatrixOld){
    this->volumeMatrixOld = _volumeMatrixOld;
}
void SoilTemperatureCompState::setmatrixPrimaryDiagonal(std::vector<double> const &_matrixPrimaryDiagonal){
    this->matrixPrimaryDiagonal = _matrixPrimaryDiagonal;
}
void SoilTemperatureCompState::setmatrixSecondaryDiagonal(std::vector<double> const &_matrixSecondaryDiagonal){
    this->matrixSecondaryDiagonal = _matrixSecondaryDiagonal;
}
void SoilTemperatureCompState::setheatConductivity(std::vector<double> const &_heatConductivity){
    this->heatConductivity = _heatConductivity;
}
void SoilTemperatureCompState::setheatConductivityMean(std::vector<double> const &_heatConductivityMean){
    this->heatConductivityMean = _heatConductivityMean;
}
void SoilTemperatureCompState::setheatCapacity(std::vector<double> const &_heatCapacity){
    this->heatCapacity = _heatCapacity;
}
void SoilTemperatureCompState::setsolution(std::vector<double> const &_solution){
    this->solution = _solution;
}
void SoilTemperatureCompState::setmatrixDiagonal(std::vector<double> const &_matrixDiagonal){
    this->matrixDiagonal = _matrixDiagonal;
}
void SoilTemperatureCompState::setmatrixLowerTriangle(std::vector<double> const &_matrixLowerTriangle){
    this->matrixLowerTriangle = _matrixLowerTriangle;
}
void SoilTemperatureCompState::setheatFlow(std::vector<double> const &_heatFlow){
    this->heatFlow = _heatFlow;
}
void SoilTemperatureCompState::setsoilSurfaceTemperature(double _soilSurfaceTemperature) { this->soilSurfaceTemperature = _soilSurfaceTemperature; }
void SoilTemperatureCompState::setnoSnowSoilSurfaceTemperature(double _noSnowSoilSurfaceTemperature) { this->noSnowSoilSurfaceTemperature = _noSnowSoilSurfaceTemperature; }