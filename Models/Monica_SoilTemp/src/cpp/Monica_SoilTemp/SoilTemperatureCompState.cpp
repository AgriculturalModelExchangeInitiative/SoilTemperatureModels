#include "SoilTemperatureCompState.h"
SoilTemperatureCompState::SoilTemperatureCompState() { }

double SoilTemperatureCompState::getsoilCoverage() {return this-> soilCoverage; }
double SoilTemperatureCompState::getprevDaySoilSurfaceTemperature() {return this-> prevDaySoilSurfaceTemperature; }
double SoilTemperatureCompState::getsoilSurfaceTemperatureBelowSnow() {return this-> soilSurfaceTemperatureBelowSnow; }
bool SoilTemperatureCompState::gethasSnowCover() {return this-> hasSnowCover; }
vector<double>& SoilTemperatureCompState::getprevDaySoilTemperature() {return this-> prevDaySoilTemperature; }
vector<double>& SoilTemperatureCompState::getsoilTemperature() {return this-> soilTemperature; }
vector<double>& SoilTemperatureCompState::getV() {return this-> V; }
vector<double>& SoilTemperatureCompState::getB() {return this-> B; }
vector<double>& SoilTemperatureCompState::getvolumeMatrix() {return this-> volumeMatrix; }
vector<double>& SoilTemperatureCompState::getvolumeMatrixOld() {return this-> volumeMatrixOld; }
vector<double>& SoilTemperatureCompState::getmatrixPrimaryDiagonal() {return this-> matrixPrimaryDiagonal; }
vector<double>& SoilTemperatureCompState::getmatrixSecondaryDiagonal() {return this-> matrixSecondaryDiagonal; }
vector<double>& SoilTemperatureCompState::getheatConductivity() {return this-> heatConductivity; }
vector<double>& SoilTemperatureCompState::getheatConductivityMean() {return this-> heatConductivityMean; }
vector<double>& SoilTemperatureCompState::getheatCapacity() {return this-> heatCapacity; }
vector<double>& SoilTemperatureCompState::getsolution() {return this-> solution; }
vector<double>& SoilTemperatureCompState::getmatrixDiagonal() {return this-> matrixDiagonal; }
vector<double>& SoilTemperatureCompState::getmatrixLowerTriangle() {return this-> matrixLowerTriangle; }
vector<double>& SoilTemperatureCompState::getheatFlow() {return this-> heatFlow; }
double SoilTemperatureCompState::getsoilSurfaceTemperature() {return this-> soilSurfaceTemperature; }
double SoilTemperatureCompState::getnoSnowSoilSurfaceTemperature() {return this-> noSnowSoilSurfaceTemperature; }

void SoilTemperatureCompState::setsoilCoverage(double _soilCoverage) { this->soilCoverage = _soilCoverage; }
void SoilTemperatureCompState::setprevDaySoilSurfaceTemperature(double _prevDaySoilSurfaceTemperature) { this->prevDaySoilSurfaceTemperature = _prevDaySoilSurfaceTemperature; }
void SoilTemperatureCompState::setsoilSurfaceTemperatureBelowSnow(double _soilSurfaceTemperatureBelowSnow) { this->soilSurfaceTemperatureBelowSnow = _soilSurfaceTemperatureBelowSnow; }
void SoilTemperatureCompState::sethasSnowCover(bool _hasSnowCover) { this->hasSnowCover = _hasSnowCover; }
void SoilTemperatureCompState::setprevDaySoilTemperature(vector<double>const & _prevDaySoilTemperature){
    this->prevDaySoilTemperature = _prevDaySoilTemperature;
}
void SoilTemperatureCompState::setsoilTemperature(vector<double>const & _soilTemperature){
    this->soilTemperature = _soilTemperature;
}
void SoilTemperatureCompState::setV(vector<double>const & _V){
    this->V = _V;
}
void SoilTemperatureCompState::setB(vector<double>const & _B){
    this->B = _B;
}
void SoilTemperatureCompState::setvolumeMatrix(vector<double>const & _volumeMatrix){
    this->volumeMatrix = _volumeMatrix;
}
void SoilTemperatureCompState::setvolumeMatrixOld(vector<double>const & _volumeMatrixOld){
    this->volumeMatrixOld = _volumeMatrixOld;
}
void SoilTemperatureCompState::setmatrixPrimaryDiagonal(vector<double>const & _matrixPrimaryDiagonal){
    this->matrixPrimaryDiagonal = _matrixPrimaryDiagonal;
}
void SoilTemperatureCompState::setmatrixSecondaryDiagonal(vector<double>const & _matrixSecondaryDiagonal){
    this->matrixSecondaryDiagonal = _matrixSecondaryDiagonal;
}
void SoilTemperatureCompState::setheatConductivity(vector<double>const & _heatConductivity){
    this->heatConductivity = _heatConductivity;
}
void SoilTemperatureCompState::setheatConductivityMean(vector<double>const & _heatConductivityMean){
    this->heatConductivityMean = _heatConductivityMean;
}
void SoilTemperatureCompState::setheatCapacity(vector<double>const & _heatCapacity){
    this->heatCapacity = _heatCapacity;
}
void SoilTemperatureCompState::setsolution(vector<double>const & _solution){
    this->solution = _solution;
}
void SoilTemperatureCompState::setmatrixDiagonal(vector<double>const & _matrixDiagonal){
    this->matrixDiagonal = _matrixDiagonal;
}
void SoilTemperatureCompState::setmatrixLowerTriangle(vector<double>const & _matrixLowerTriangle){
    this->matrixLowerTriangle = _matrixLowerTriangle;
}
void SoilTemperatureCompState::setheatFlow(vector<double>const & _heatFlow){
    this->heatFlow = _heatFlow;
}
void SoilTemperatureCompState::setsoilSurfaceTemperature(double _soilSurfaceTemperature) { this->soilSurfaceTemperature = _soilSurfaceTemperature; }
void SoilTemperatureCompState::setnoSnowSoilSurfaceTemperature(double _noSnowSoilSurfaceTemperature) { this->noSnowSoilSurfaceTemperature = _noSnowSoilSurfaceTemperature; }