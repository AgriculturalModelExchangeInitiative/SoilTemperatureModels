#include "SurfacePartonSoilSWATCComponent.h"

    SurfacePartonSoilSWATCComponent::SurfacePartonSoilSWATCComponent()
    {
           
    }
    

double SurfacePartonSoilSWATCComponent::getLagCoefficient() {return this-> LagCoefficient; }

void SurfacePartonSoilSWATCComponent::setLagCoefficient(double _LagCoefficient)
{
    _SoilTemperatureSWAT.setLagCoefficient(_LagCoefficient);
}
void SurfacePartonSoilSWATCComponent::Calculate_Model(SurfacePartonSoilSWATCState& s, SurfacePartonSoilSWATCState& s1, SurfacePartonSoilSWATCRate& r, SurfacePartonSoilSWATCAuxiliary& a, SurfacePartonSoilSWATCExogenous& ex)
{
    _SurfaceTemperatureParton.Calculate_Model(s, s1, r, a, ex);
    _SoilTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
}
SurfacePartonSoilSWATCComponent::SurfacePartonSoilSWATCComponent(const SurfacePartonSoilSWATCComponent& toCopy)
{
    LagCoefficient = toCopy.LagCoefficient;
}