#include "SurfacePartonSoilSWATCComponent.h"

    SurfacePartonSoilSWATCComponent::SurfacePartonSoilSWATCComponent()
    {
           
    }
    

double SurfacePartonSoilSWATCComponent::getAirTemperatureAnnualAverage() {return this-> AirTemperatureAnnualAverage; }
vector<double> & SurfacePartonSoilSWATCComponent::getBulkDensity() {return this-> BulkDensity; }
vector<double> & SurfacePartonSoilSWATCComponent::getLayerThickness() {return this-> LayerThickness; }
double SurfacePartonSoilSWATCComponent::getLagCoefficient() {return this-> LagCoefficient; }
double SurfacePartonSoilSWATCComponent::getSoilProfileDepth() {return this-> SoilProfileDepth; }

void SurfacePartonSoilSWATCComponent::setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage)
{
    _SoilTemperatureSWAT.setAirTemperatureAnnualAverage(_AirTemperatureAnnualAverage);
}
void SurfacePartonSoilSWATCComponent::setBulkDensity(const vector<double> & _BulkDensity)
{
    _SoilTemperatureSWAT.setBulkDensity(_BulkDensity);
}
void SurfacePartonSoilSWATCComponent::setLayerThickness(const vector<double> & _LayerThickness)
{
    _SoilTemperatureSWAT.setLayerThickness(_LayerThickness);
}
void SurfacePartonSoilSWATCComponent::setLagCoefficient(double _LagCoefficient)
{
    _SoilTemperatureSWAT.setLagCoefficient(_LagCoefficient);
}
void SurfacePartonSoilSWATCComponent::setSoilProfileDepth(double _SoilProfileDepth)
{
    _SoilTemperatureSWAT.setSoilProfileDepth(_SoilProfileDepth);
}
void SurfacePartonSoilSWATCComponent::Calculate_Model(SurfacePartonSoilSWATCState& s, SurfacePartonSoilSWATCState& s1, SurfacePartonSoilSWATCRate& r, SurfacePartonSoilSWATCAuxiliary& a, SurfacePartonSoilSWATCExogenous& ex)
{
    _SurfaceTemperatureParton.Calculate_Model(s, s1, r, a, ex);
    _SoilTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
}
SurfacePartonSoilSWATCComponent::SurfacePartonSoilSWATCComponent(SurfacePartonSoilSWATCComponent& toCopy)
{
    AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
    
        for (int i = 0; i < toCopy.getBulkDensity().size(); i++)
        {
            BulkDensity[i] = toCopy.getBulkDensity()[i];
        }
    
    
        for (int i = 0; i < toCopy.getLayerThickness().size(); i++)
        {
            LayerThickness[i] = toCopy.getLayerThickness()[i];
        }
    
    LagCoefficient = toCopy.getLagCoefficient();
    SoilProfileDepth = toCopy.getSoilProfileDepth();
}