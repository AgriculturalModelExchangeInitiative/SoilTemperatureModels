#include "SurfaceSWATSoilSWATCComponent.h"
using namespace BiomaSurfaceSWATSoilSWATC;
SurfaceSWATSoilSWATCComponent::SurfaceSWATSoilSWATCComponent()
{
       
}


std::vector<double> & SurfaceSWATSoilSWATCComponent::getBulkDensity(){ return this->BulkDensity; }
double SurfaceSWATSoilSWATCComponent::getAirTemperatureAnnualAverage(){ return this->AirTemperatureAnnualAverage; }
double SurfaceSWATSoilSWATCComponent::getSoilProfileDepth(){ return this->SoilProfileDepth; }
double SurfaceSWATSoilSWATCComponent::getLagCoefficient(){ return this->LagCoefficient; }
std::vector<double> & SurfaceSWATSoilSWATCComponent::getLayerThickness(){ return this->LayerThickness; }

void SurfaceSWATSoilSWATCComponent::setBulkDensity(const std::vector<double> & _BulkDensity)
{
    _SoilTemperatureSWAT.setBulkDensity(_BulkDensity);
}
void SurfaceSWATSoilSWATCComponent::setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage)
{
    _SoilTemperatureSWAT.setAirTemperatureAnnualAverage(_AirTemperatureAnnualAverage);
}
void SurfaceSWATSoilSWATCComponent::setSoilProfileDepth(double _SoilProfileDepth)
{
    _SoilTemperatureSWAT.setSoilProfileDepth(_SoilProfileDepth);
}
void SurfaceSWATSoilSWATCComponent::setLagCoefficient(double _LagCoefficient)
{
    _SoilTemperatureSWAT.setLagCoefficient(_LagCoefficient);
}
void SurfaceSWATSoilSWATCComponent::setLayerThickness(const std::vector<double> & _LayerThickness)
{
    _SoilTemperatureSWAT.setLayerThickness(_LayerThickness);
}
void SurfaceSWATSoilSWATCComponent::Calculate_Model(SurfaceSWATSoilSWATCState &s, SurfaceSWATSoilSWATCState &s1, SurfaceSWATSoilSWATCRate &r, SurfaceSWATSoilSWATCAuxiliary &a, SurfaceSWATSoilSWATCExogenous &ex)
{
    _SurfaceTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
    _SoilTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
}
SurfaceSWATSoilSWATCComponent::SurfaceSWATSoilSWATCComponent(SurfaceSWATSoilSWATCComponent& toCopy)
{
    for (int i = 0; i < toCopy.getBulkDensity().size(); i++)
{
    BulkDensity[i] = toCopy.getBulkDensity()[i];
}

    AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
    SoilProfileDepth = toCopy.getSoilProfileDepth();
    LagCoefficient = toCopy.getLagCoefficient();
    for (int i = 0; i < toCopy.getLayerThickness().size(); i++)
{
    LayerThickness[i] = toCopy.getLayerThickness()[i];
}

}