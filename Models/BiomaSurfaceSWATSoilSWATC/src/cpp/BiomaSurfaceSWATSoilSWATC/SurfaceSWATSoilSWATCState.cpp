#include "SurfaceSWATSoilSWATCState.h"
SurfaceSWATSoilSWATCState::SurfaceSWATSoilSWATCState() { }

double SurfaceSWATSoilSWATCState::getAboveGroundBiomass() {return this-> AboveGroundBiomass; }
vector<double> & SurfaceSWATSoilSWATCState::getBulkDensity() {return this-> BulkDensity; }
vector<double> & SurfaceSWATSoilSWATCState::getLayerThickness() {return this-> LayerThickness; }
vector<double> & SurfaceSWATSoilSWATCState::getVolumetricWaterContent() {return this-> VolumetricWaterContent; }
double SurfaceSWATSoilSWATCState::getSoilProfileDepth() {return this-> SoilProfileDepth; }
double SurfaceSWATSoilSWATCState::getSurfaceSoilTemperature() {return this-> SurfaceSoilTemperature; }
vector<double> & SurfaceSWATSoilSWATCState::getSoilTemperatureByLayers() {return this-> SoilTemperatureByLayers; }

void SurfaceSWATSoilSWATCState::setAboveGroundBiomass(double _AboveGroundBiomass) { this->AboveGroundBiomass = _AboveGroundBiomass; }
void SurfaceSWATSoilSWATCState::setBulkDensity(vector<double>  _BulkDensity){
    this->BulkDensity = _BulkDensity;
}
void SurfaceSWATSoilSWATCState::setLayerThickness(vector<double>  _LayerThickness){
    this->LayerThickness = _LayerThickness;
}
void SurfaceSWATSoilSWATCState::setVolumetricWaterContent(vector<double>  _VolumetricWaterContent){
    this->VolumetricWaterContent = _VolumetricWaterContent;
}
void SurfaceSWATSoilSWATCState::setSoilProfileDepth(double _SoilProfileDepth) { this->SoilProfileDepth = _SoilProfileDepth; }
void SurfaceSWATSoilSWATCState::setSurfaceSoilTemperature(double _SurfaceSoilTemperature) { this->SurfaceSoilTemperature = _SurfaceSoilTemperature; }
void SurfaceSWATSoilSWATCState::setSoilTemperatureByLayers(vector<double>  _SoilTemperatureByLayers){
    this->SoilTemperatureByLayers = _SoilTemperatureByLayers;
}