#include "SurfaceSWATSoilSWATCAuxiliary.h"
using namespace BiomaSurfaceSWATSoilSWATC;


SurfaceSWATSoilSWATCAuxiliary::SurfaceSWATSoilSWATCAuxiliary() {}

double SurfaceSWATSoilSWATCAuxiliary::getAboveGroundBiomass() { return this->AboveGroundBiomass; }
std::vector<double> & SurfaceSWATSoilSWATCAuxiliary::getVolumetricWaterContent() { return this->VolumetricWaterContent; }
double SurfaceSWATSoilSWATCAuxiliary::getSurfaceSoilTemperature() { return this->SurfaceSoilTemperature; }

void SurfaceSWATSoilSWATCAuxiliary::setAboveGroundBiomass(double _AboveGroundBiomass) { this->AboveGroundBiomass = _AboveGroundBiomass; }
void SurfaceSWATSoilSWATCAuxiliary::setVolumetricWaterContent(std::vector<double> const &_VolumetricWaterContent){
    this->VolumetricWaterContent = _VolumetricWaterContent;
}
void SurfaceSWATSoilSWATCAuxiliary::setSurfaceSoilTemperature(double _SurfaceSoilTemperature) { this->SurfaceSoilTemperature = _SurfaceSoilTemperature; }