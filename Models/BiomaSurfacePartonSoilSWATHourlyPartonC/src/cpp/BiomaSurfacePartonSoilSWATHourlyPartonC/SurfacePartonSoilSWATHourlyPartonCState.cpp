#include "SurfacePartonSoilSWATHourlyPartonCState.h"
SurfacePartonSoilSWATHourlyPartonCState::SurfacePartonSoilSWATHourlyPartonCState() { }

double SurfacePartonSoilSWATHourlyPartonCState::getAboveGroundBiomass() {return this-> AboveGroundBiomass; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getVolumetricWaterContent() {return this-> VolumetricWaterContent; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getBulkDensity() {return this-> BulkDensity; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getLayerThickness() {return this-> LayerThickness; }
double SurfacePartonSoilSWATHourlyPartonCState::getSoilProfileDepth() {return this-> SoilProfileDepth; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSand() {return this-> Sand; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getOrganicMatter() {return this-> OrganicMatter; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getClay() {return this-> Clay; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSilt() {return this-> Silt; }
double SurfacePartonSoilSWATHourlyPartonCState::getSurfaceSoilTemperature() {return this-> SurfaceSoilTemperature; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSoilTemperatureByLayers() {return this-> SoilTemperatureByLayers; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getHeatCapacity() {return this-> HeatCapacity; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getThermalConductivity() {return this-> ThermalConductivity; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getThermalDiffusivity() {return this-> ThermalDiffusivity; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSoilTemperatureRangeByLayers() {return this-> SoilTemperatureRangeByLayers; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSoilTemperatureMinimum() {return this-> SoilTemperatureMinimum; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSoilTemperatureMaximum() {return this-> SoilTemperatureMaximum; }
vector<double> & SurfacePartonSoilSWATHourlyPartonCState::getSoilTemperatureByLayersHourly() {return this-> SoilTemperatureByLayersHourly; }

void SurfacePartonSoilSWATHourlyPartonCState::setAboveGroundBiomass(double _AboveGroundBiomass) { this->AboveGroundBiomass = _AboveGroundBiomass; }
void SurfacePartonSoilSWATHourlyPartonCState::setVolumetricWaterContent(vector<double>  _VolumetricWaterContent){
    this->VolumetricWaterContent = _VolumetricWaterContent;
}
void SurfacePartonSoilSWATHourlyPartonCState::setBulkDensity(vector<double>  _BulkDensity){
    this->BulkDensity = _BulkDensity;
}
void SurfacePartonSoilSWATHourlyPartonCState::setLayerThickness(vector<double>  _LayerThickness){
    this->LayerThickness = _LayerThickness;
}
void SurfacePartonSoilSWATHourlyPartonCState::setSoilProfileDepth(double _SoilProfileDepth) { this->SoilProfileDepth = _SoilProfileDepth; }
void SurfacePartonSoilSWATHourlyPartonCState::setSand(vector<double>  _Sand){
    this->Sand = _Sand;
}
void SurfacePartonSoilSWATHourlyPartonCState::setOrganicMatter(vector<double>  _OrganicMatter){
    this->OrganicMatter = _OrganicMatter;
}
void SurfacePartonSoilSWATHourlyPartonCState::setClay(vector<double>  _Clay){
    this->Clay = _Clay;
}
void SurfacePartonSoilSWATHourlyPartonCState::setSilt(vector<double>  _Silt){
    this->Silt = _Silt;
}
void SurfacePartonSoilSWATHourlyPartonCState::setSurfaceSoilTemperature(double _SurfaceSoilTemperature) { this->SurfaceSoilTemperature = _SurfaceSoilTemperature; }
void SurfacePartonSoilSWATHourlyPartonCState::setSoilTemperatureByLayers(vector<double>  _SoilTemperatureByLayers){
    this->SoilTemperatureByLayers = _SoilTemperatureByLayers;
}
void SurfacePartonSoilSWATHourlyPartonCState::setHeatCapacity(vector<double>  _HeatCapacity){
    this->HeatCapacity = _HeatCapacity;
}
void SurfacePartonSoilSWATHourlyPartonCState::setThermalConductivity(vector<double>  _ThermalConductivity){
    this->ThermalConductivity = _ThermalConductivity;
}
void SurfacePartonSoilSWATHourlyPartonCState::setThermalDiffusivity(vector<double>  _ThermalDiffusivity){
    this->ThermalDiffusivity = _ThermalDiffusivity;
}
void SurfacePartonSoilSWATHourlyPartonCState::setSoilTemperatureRangeByLayers(vector<double>  _SoilTemperatureRangeByLayers){
    this->SoilTemperatureRangeByLayers = _SoilTemperatureRangeByLayers;
}
void SurfacePartonSoilSWATHourlyPartonCState::setSoilTemperatureMinimum(vector<double>  _SoilTemperatureMinimum){
    this->SoilTemperatureMinimum = _SoilTemperatureMinimum;
}
void SurfacePartonSoilSWATHourlyPartonCState::setSoilTemperatureMaximum(vector<double>  _SoilTemperatureMaximum){
    this->SoilTemperatureMaximum = _SoilTemperatureMaximum;
}
void SurfacePartonSoilSWATHourlyPartonCState::setSoilTemperatureByLayersHourly(vector<double>  _SoilTemperatureByLayersHourly){
    this->SoilTemperatureByLayersHourly = _SoilTemperatureByLayersHourly;
}