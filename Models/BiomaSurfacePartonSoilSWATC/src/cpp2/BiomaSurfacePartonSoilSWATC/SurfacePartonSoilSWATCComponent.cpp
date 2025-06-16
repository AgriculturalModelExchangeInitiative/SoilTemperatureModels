#include "SurfacePartonSoilSWATCComponent.h"
using namespace BiomaSurfacePartonSoilSWATC;
SurfacePartonSoilSWATCComponent::SurfacePartonSoilSWATCComponent()
{
       
}


std::vector<double> & SurfacePartonSoilSWATCComponent::getLayerThickness(){ return this->LayerThickness; }
std::vector<double> & SurfacePartonSoilSWATCComponent::getBulkDensity(){ return this->BulkDensity; }
double SurfacePartonSoilSWATCComponent::getSoilProfileDepth(){ return this->SoilProfileDepth; }
double SurfacePartonSoilSWATCComponent::getAirTemperatureAnnualAverage(){ return this->AirTemperatureAnnualAverage; }
double SurfacePartonSoilSWATCComponent::getLagCoefficient(){ return this->LagCoefficient; }

void SurfacePartonSoilSWATCComponent::setLayerThickness(const std::vector<double> & _LayerThickness)
{
    _SoilTemperatureSWAT.setLayerThickness(_LayerThickness);
}
void SurfacePartonSoilSWATCComponent::setBulkDensity(const std::vector<double> & _BulkDensity)
{
    _SoilTemperatureSWAT.setBulkDensity(_BulkDensity);
}
void SurfacePartonSoilSWATCComponent::setSoilProfileDepth(double _SoilProfileDepth)
{
    _SoilTemperatureSWAT.setSoilProfileDepth(_SoilProfileDepth);
}
void SurfacePartonSoilSWATCComponent::setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage)
{
    _SoilTemperatureSWAT.setAirTemperatureAnnualAverage(_AirTemperatureAnnualAverage);
}
void SurfacePartonSoilSWATCComponent::setLagCoefficient(double _LagCoefficient)
{
    _SoilTemperatureSWAT.setLagCoefficient(_LagCoefficient);
}
void SurfacePartonSoilSWATCComponent::Calculate_Model(SurfacePartonSoilSWATCState &s, SurfacePartonSoilSWATCState &s1, SurfacePartonSoilSWATCRate &r, SurfacePartonSoilSWATCAuxiliary &a, SurfacePartonSoilSWATCExogenous &ex)
{
    _SurfaceTemperatureParton.Calculate_Model(s, s1, r, a, ex);
    _SoilTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
}
SurfacePartonSoilSWATCComponent::SurfacePartonSoilSWATCComponent(SurfacePartonSoilSWATCComponent& toCopy)
{
    for (int i = 0; i < toCopy.getLayerThickness().size(); i++)
{
    LayerThickness[i] = toCopy.getLayerThickness()[i];
}

    for (int i = 0; i < toCopy.getBulkDensity().size(); i++)
{
    BulkDensity[i] = toCopy.getBulkDensity()[i];
}

    SoilProfileDepth = toCopy.getSoilProfileDepth();
    AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
    LagCoefficient = toCopy.getLagCoefficient();
}