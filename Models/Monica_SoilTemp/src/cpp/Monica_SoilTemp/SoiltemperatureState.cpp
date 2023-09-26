#include "SoiltemperatureState.h"
SoiltemperatureState::SoiltemperatureState() { }

double SoiltemperatureState::getsoilCoverage() {return this-> soilCoverage; }
double SoiltemperatureState::getprevDaySoilSurfaceTemperature() {return this-> prevDaySoilSurfaceTemperature; }
double SoiltemperatureState::getsoilSurfaceTemperatureBelowSnow() {return this-> soilSurfaceTemperatureBelowSnow; }
bool SoiltemperatureState::gethasSnowCover() {return this-> hasSnowCover; }
vector<double>& SoiltemperatureState::getprevDaySoilTemperature() {return this-> prevDaySoilTemperature; }
vector<double>& SoiltemperatureState::getV() {return this-> V; }
vector<double>& SoiltemperatureState::getB() {return this-> B; }
vector<double>& SoiltemperatureState::getvolumeMatrix() {return this-> volumeMatrix; }
vector<double>& SoiltemperatureState::getvolumeMatrixOld() {return this-> volumeMatrixOld; }
vector<double>& SoiltemperatureState::getmatrixPrimaryDiagonal() {return this-> matrixPrimaryDiagonal; }
vector<double>& SoiltemperatureState::getmatrixSecondaryDiagonal() {return this-> matrixSecondaryDiagonal; }
vector<double>& SoiltemperatureState::getheatConductivity() {return this-> heatConductivity; }
vector<double>& SoiltemperatureState::getheatConductivityMean() {return this-> heatConductivityMean; }
vector<double>& SoiltemperatureState::getheatCapacity() {return this-> heatCapacity; }
vector<double>& SoiltemperatureState::getsolution() {return this-> solution; }
vector<double>& SoiltemperatureState::getmatrixDiagonal() {return this-> matrixDiagonal; }
vector<double>& SoiltemperatureState::getmatrixLowerTriangle() {return this-> matrixLowerTriangle; }
vector<double>& SoiltemperatureState::getheatFlow() {return this-> heatFlow; }
double SoiltemperatureState::getsoilSurfaceTemperature() {return this-> soilSurfaceTemperature; }
vector<double>& SoiltemperatureState::getsoilTemperature() {return this-> soilTemperature; }
double SoiltemperatureState::getnoSnowSoilSurfaceTemperature() {return this-> noSnowSoilSurfaceTemperature; }

void SoiltemperatureState::setsoilCoverage(double _soilCoverage) { this->soilCoverage = _soilCoverage; }
void SoiltemperatureState::setprevDaySoilSurfaceTemperature(double _prevDaySoilSurfaceTemperature) { this->prevDaySoilSurfaceTemperature = _prevDaySoilSurfaceTemperature; }
void SoiltemperatureState::setsoilSurfaceTemperatureBelowSnow(double _soilSurfaceTemperatureBelowSnow) { this->soilSurfaceTemperatureBelowSnow = _soilSurfaceTemperatureBelowSnow; }
void SoiltemperatureState::sethasSnowCover(bool _hasSnowCover) { this->hasSnowCover = _hasSnowCover; }
void SoiltemperatureState::setprevDaySoilTemperature(vector<double> _prevDaySoilTemperature){
    this->prevDaySoilTemperature = _prevDaySoilTemperature;
}
void SoiltemperatureState::setV(vector<double> _V){
    this->V = _V;
}
void SoiltemperatureState::setB(vector<double> _B){
    this->B = _B;
}
void SoiltemperatureState::setvolumeMatrix(vector<double> _volumeMatrix){
    this->volumeMatrix = _volumeMatrix;
}
void SoiltemperatureState::setvolumeMatrixOld(vector<double> _volumeMatrixOld){
    this->volumeMatrixOld = _volumeMatrixOld;
}
void SoiltemperatureState::setmatrixPrimaryDiagonal(vector<double> _matrixPrimaryDiagonal){
    this->matrixPrimaryDiagonal = _matrixPrimaryDiagonal;
}
void SoiltemperatureState::setmatrixSecondaryDiagonal(vector<double> _matrixSecondaryDiagonal){
    this->matrixSecondaryDiagonal = _matrixSecondaryDiagonal;
}
void SoiltemperatureState::setheatConductivity(vector<double> _heatConductivity){
    this->heatConductivity = _heatConductivity;
}
void SoiltemperatureState::setheatConductivityMean(vector<double> _heatConductivityMean){
    this->heatConductivityMean = _heatConductivityMean;
}
void SoiltemperatureState::setheatCapacity(vector<double> _heatCapacity){
    this->heatCapacity = _heatCapacity;
}
void SoiltemperatureState::setsolution(vector<double> _solution){
    this->solution = _solution;
}
void SoiltemperatureState::setmatrixDiagonal(vector<double> _matrixDiagonal){
    this->matrixDiagonal = _matrixDiagonal;
}
void SoiltemperatureState::setmatrixLowerTriangle(vector<double> _matrixLowerTriangle){
    this->matrixLowerTriangle = _matrixLowerTriangle;
}
void SoiltemperatureState::setheatFlow(vector<double> _heatFlow){
    this->heatFlow = _heatFlow;
}
void SoiltemperatureState::setsoilSurfaceTemperature(double _soilSurfaceTemperature) { this->soilSurfaceTemperature = _soilSurfaceTemperature; }
void SoiltemperatureState::setsoilTemperature(vector<double> _soilTemperature){
    this->soilTemperature = _soilTemperature;
}
void SoiltemperatureState::setnoSnowSoilSurfaceTemperature(double _noSnowSoilSurfaceTemperature) { this->noSnowSoilSurfaceTemperature = _noSnowSoilSurfaceTemperature; }