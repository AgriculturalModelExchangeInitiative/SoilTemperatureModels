#include "SurfaceSWATSoilSWATCState.h"
using namespace BiomaSurfaceSWATSoilSWATC;

SurfaceSWATSoilSWATCState::SurfaceSWATSoilSWATCState() {}

std::vector<double> & SurfaceSWATSoilSWATCState::getSoilTemperatureByLayers() { return this->SoilTemperatureByLayers; }

void SurfaceSWATSoilSWATCState::setSoilTemperatureByLayers(std::vector<double> const &_SoilTemperatureByLayers){
    this->SoilTemperatureByLayers = _SoilTemperatureByLayers;
}