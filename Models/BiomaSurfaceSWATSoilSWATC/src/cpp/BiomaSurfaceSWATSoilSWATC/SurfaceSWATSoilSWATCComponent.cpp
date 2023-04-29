#include "SurfaceSWATSoilSWATCComponent.h"

    SurfaceSWATSoilSWATCComponent::SurfaceSWATSoilSWATCComponent()
    {
           
    }
    

double SurfaceSWATSoilSWATCComponent::getLagCoefficient() {return this-> LagCoefficient; }

void SurfaceSWATSoilSWATCComponent::setLagCoefficient(double _LagCoefficient)
{
    _SoilTemperatureSWAT.setLagCoefficient(_LagCoefficient);
}
void SurfaceSWATSoilSWATCComponent::Calculate_Model(SurfaceSWATSoilSWATCState& s, SurfaceSWATSoilSWATCState& s1, SurfaceSWATSoilSWATCRate& r, SurfaceSWATSoilSWATCAuxiliary& a, SurfaceSWATSoilSWATCExogenous& ex)
{
    _SurfaceTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
    _SoilTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
}
SurfaceSWATSoilSWATCComponent::SurfaceSWATSoilSWATCComponent(const SurfaceSWATSoilSWATCComponent& toCopy)
{
    LagCoefficient = toCopy.LagCoefficient;
}