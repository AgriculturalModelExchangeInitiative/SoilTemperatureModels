#include "SurfacePartonSoilSWATCState.h"
SurfacePartonSoilSWATCState::SurfacePartonSoilSWATCState() { }

vector<double> & SurfacePartonSoilSWATCState::getSoilTemperatureByLayers() {return this-> SoilTemperatureByLayers; }

void SurfacePartonSoilSWATCState::setSoilTemperatureByLayers(vector<double> const & _SoilTemperatureByLayers){
    this->SoilTemperatureByLayers = _SoilTemperatureByLayers;
}