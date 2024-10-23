#include "SurfaceSWATSoilSWATCAuxiliary.h"
using namespace BiomaSurfaceSWATSoilSWATC;


SurfaceSWATSoilSWATCAuxiliary::SurfaceSWATSoilSWATCAuxiliary() {}

double SurfaceSWATSoilSWATCAuxiliary::getAboveGroundBiomass() { return this->AboveGroundBiomass; }
double SurfaceSWATSoilSWATCAuxiliary::getSurfaceSoilTemperature() { return this->SurfaceSoilTemperature; }

void SurfaceSWATSoilSWATCAuxiliary::setAboveGroundBiomass(double _AboveGroundBiomass) { this->AboveGroundBiomass = _AboveGroundBiomass; }
void SurfaceSWATSoilSWATCAuxiliary::setSurfaceSoilTemperature(double _SurfaceSoilTemperature) { this->SurfaceSoilTemperature = _SurfaceSoilTemperature; }