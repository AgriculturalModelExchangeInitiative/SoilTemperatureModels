#include "SurfacePartonSoilSWATHourlyPartonCComponent.h"

    SurfacePartonSoilSWATHourlyPartonCComponent::SurfacePartonSoilSWATHourlyPartonCComponent()
    {
           
    }
    

double SurfacePartonSoilSWATHourlyPartonCComponent::getLagCoefficient() {return this-> LagCoefficient; }

void SurfacePartonSoilSWATHourlyPartonCComponent::setLagCoefficient(double _LagCoefficient)
{
    _SoilTemperatureSWAT.setLagCoefficient(_LagCoefficient);
}
void SurfacePartonSoilSWATHourlyPartonCComponent::Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState& s, SurfacePartonSoilSWATHourlyPartonCState& s1, SurfacePartonSoilSWATHourlyPartonCRate& r, SurfacePartonSoilSWATHourlyPartonCAuxiliary& a, SurfacePartonSoilSWATHourlyPartonCExogenous& ex)
{
    _SurfaceTemperatureParton.Calculate_Model(s, s1, r, a, ex);
    _VolumetricHeatCapacityKluitenberg.Calculate_Model(s, s1, r, a, ex);
    _ThermalConductivitySIMULAT.Calculate_Model(s, s1, r, a, ex);
    _SoilTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
    _ThermalDiffu.Calculate_Model(s, s1, r, a, ex);
    _RangeOfSoilTemperaturesDAYCENT.Calculate_Model(s, s1, r, a, ex);
    _HourlySoilTemperaturesPartonLogan.Calculate_Model(s, s1, r, a, ex);
}
SurfacePartonSoilSWATHourlyPartonCComponent::SurfacePartonSoilSWATHourlyPartonCComponent(const SurfacePartonSoilSWATHourlyPartonCComponent& toCopy)
{
    LagCoefficient = toCopy.LagCoefficient;
}