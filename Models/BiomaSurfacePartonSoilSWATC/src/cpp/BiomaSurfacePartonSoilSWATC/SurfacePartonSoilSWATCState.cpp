#include "SurfacePartonSoilSWATCState.h"
SurfacePartonSoilSWATCState::SurfacePartonSoilSWATCState() { }

double SurfacePartonSoilSWATCState::getAboveGroundBiomass() {return this-> AboveGroundBiomass; }
vector<double> & SurfacePartonSoilSWATCState::getVolumetricWaterContent() {return this-> VolumetricWaterContent; }
vector<double> & SurfacePartonSoilSWATCState::getLayerThickness() {return this-> LayerThickness; }
vector<double> & SurfacePartonSoilSWATCState::getBulkDensity() {return this-> BulkDensity; }
double SurfacePartonSoilSWATCState::getSoilProfileDepth() {return this-> SoilProfileDepth; }
double SurfacePartonSoilSWATCState::getSurfaceSoilTemperature() {return this-> SurfaceSoilTemperature; }
vector<double> & SurfacePartonSoilSWATCState::getSoilTemperatureByLayers() {return this-> SoilTemperatureByLayers; }

void SurfacePartonSoilSWATCState::setAboveGroundBiomass(double _AboveGroundBiomass) { this->AboveGroundBiomass = _AboveGroundBiomass; }
void SurfacePartonSoilSWATCState::setVolumetricWaterContent(vector<double>  _VolumetricWaterContent){
    this->VolumetricWaterContent = _VolumetricWaterContent;
}
void SurfacePartonSoilSWATCState::setLayerThickness(vector<double>  _LayerThickness){
    this->LayerThickness = _LayerThickness;
}
void SurfacePartonSoilSWATCState::setBulkDensity(vector<double>  _BulkDensity){
    this->BulkDensity = _BulkDensity;
}
void SurfacePartonSoilSWATCState::setSoilProfileDepth(double _SoilProfileDepth) { this->SoilProfileDepth = _SoilProfileDepth; }
void SurfacePartonSoilSWATCState::setSurfaceSoilTemperature(double _SurfaceSoilTemperature) { this->SurfaceSoilTemperature = _SurfaceSoilTemperature; }
void SurfacePartonSoilSWATCState::setSoilTemperatureByLayers(vector<double>  _SoilTemperatureByLayers){
    this->SoilTemperatureByLayers = _SoilTemperatureByLayers;
}