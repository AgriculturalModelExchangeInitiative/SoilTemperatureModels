#include "SurfacePartonSoilSWATCState.h"
using namespace BiomaSurfacePartonSoilSWATC;

SurfacePartonSoilSWATCState::SurfacePartonSoilSWATCState() {}

std::vector<double> & SurfacePartonSoilSWATCState::getSoilTemperatureByLayers() { return this->SoilTemperatureByLayers; }

void SurfacePartonSoilSWATCState::setSoilTemperatureByLayers(std::vector<double> const &_SoilTemperatureByLayers){
    this->SoilTemperatureByLayers = _SoilTemperatureByLayers;
}