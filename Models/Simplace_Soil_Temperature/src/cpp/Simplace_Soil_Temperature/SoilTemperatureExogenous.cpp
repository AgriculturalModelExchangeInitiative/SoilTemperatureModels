#include "SoilTemperatureExogenous.h"
using namespace Simplace_Soil_Temperature;

SoilTemperatureExogenous::SoilTemperatureExogenous() {}

double SoilTemperatureExogenous::getiAirTemperatureMax() { return this->iAirTemperatureMax; }
double SoilTemperatureExogenous::getiTempMax() { return this->iTempMax; }
double SoilTemperatureExogenous::getiAirTemperatureMin() { return this->iAirTemperatureMin; }
double SoilTemperatureExogenous::getiTempMin() { return this->iTempMin; }
double SoilTemperatureExogenous::getiGlobalSolarRadiation() { return this->iGlobalSolarRadiation; }
double SoilTemperatureExogenous::getiRadiation() { return this->iRadiation; }
double SoilTemperatureExogenous::getiRAIN() { return this->iRAIN; }
double SoilTemperatureExogenous::getiCropResidues() { return this->iCropResidues; }
double SoilTemperatureExogenous::getiPotentialSoilEvaporation() { return this->iPotentialSoilEvaporation; }
double SoilTemperatureExogenous::getiLeafAreaIndex() { return this->iLeafAreaIndex; }
double SoilTemperatureExogenous::getiSoilWaterContent() { return this->iSoilWaterContent; }

void SoilTemperatureExogenous::setiAirTemperatureMax(double _iAirTemperatureMax) { this->iAirTemperatureMax = _iAirTemperatureMax; }
void SoilTemperatureExogenous::setiTempMax(double _iTempMax) { this->iTempMax = _iTempMax; }
void SoilTemperatureExogenous::setiAirTemperatureMin(double _iAirTemperatureMin) { this->iAirTemperatureMin = _iAirTemperatureMin; }
void SoilTemperatureExogenous::setiTempMin(double _iTempMin) { this->iTempMin = _iTempMin; }
void SoilTemperatureExogenous::setiGlobalSolarRadiation(double _iGlobalSolarRadiation) { this->iGlobalSolarRadiation = _iGlobalSolarRadiation; }
void SoilTemperatureExogenous::setiRadiation(double _iRadiation) { this->iRadiation = _iRadiation; }
void SoilTemperatureExogenous::setiRAIN(double _iRAIN) { this->iRAIN = _iRAIN; }
void SoilTemperatureExogenous::setiCropResidues(double _iCropResidues) { this->iCropResidues = _iCropResidues; }
void SoilTemperatureExogenous::setiPotentialSoilEvaporation(double _iPotentialSoilEvaporation) { this->iPotentialSoilEvaporation = _iPotentialSoilEvaporation; }
void SoilTemperatureExogenous::setiLeafAreaIndex(double _iLeafAreaIndex) { this->iLeafAreaIndex = _iLeafAreaIndex; }
void SoilTemperatureExogenous::setiSoilWaterContent(double _iSoilWaterContent) { this->iSoilWaterContent = _iSoilWaterContent; }