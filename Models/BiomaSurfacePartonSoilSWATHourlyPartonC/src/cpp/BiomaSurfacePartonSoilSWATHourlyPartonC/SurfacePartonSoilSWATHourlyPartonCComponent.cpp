#include "SurfacePartonSoilSWATHourlyPartonCComponent.h"
using namespace BiomaSurfacePartonSoilSWATHourlyPartonC;
SurfacePartonSoilSWATHourlyPartonCComponent::SurfacePartonSoilSWATHourlyPartonCComponent()
{
       
}


std::vector<double> & SurfacePartonSoilSWATHourlyPartonCComponent::getBulkDensity(){ return this->BulkDensity; }
double SurfacePartonSoilSWATHourlyPartonCComponent::getSoilProfileDepth(){ return this->SoilProfileDepth; }
double SurfacePartonSoilSWATHourlyPartonCComponent::getAirTemperatureAnnualAverage(){ return this->AirTemperatureAnnualAverage; }
double SurfacePartonSoilSWATHourlyPartonCComponent::getLagCoefficient(){ return this->LagCoefficient; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCComponent::getLayerThickness(){ return this->LayerThickness; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCComponent::getClay(){ return this->Clay; }
std::vector<double> & SurfacePartonSoilSWATHourlyPartonCComponent::getSilt(){ return this->Silt; }
int SurfacePartonSoilSWATHourlyPartonCComponent::getlayersNumber(){ return this->layersNumber; }

void SurfacePartonSoilSWATHourlyPartonCComponent::setBulkDensity(const std::vector<double> & _BulkDensity)
{
    _SoilTemperatureSWAT.setBulkDensity(_BulkDensity);
    _VolumetricHeatCapacityKluitenberg.setBulkDensity(_BulkDensity);
    _ThermalConductivitySIMULAT.setBulkDensity(_BulkDensity);
}
void SurfacePartonSoilSWATHourlyPartonCComponent::setSoilProfileDepth(double _SoilProfileDepth)
{
    _SoilTemperatureSWAT.setSoilProfileDepth(_SoilProfileDepth);
}
void SurfacePartonSoilSWATHourlyPartonCComponent::setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage)
{
    _SoilTemperatureSWAT.setAirTemperatureAnnualAverage(_AirTemperatureAnnualAverage);
}
void SurfacePartonSoilSWATHourlyPartonCComponent::setLagCoefficient(double _LagCoefficient)
{
    _SoilTemperatureSWAT.setLagCoefficient(_LagCoefficient);
}
void SurfacePartonSoilSWATHourlyPartonCComponent::setLayerThickness(const std::vector<double> & _LayerThickness)
{
    _SoilTemperatureSWAT.setLayerThickness(_LayerThickness);
    _RangeOfSoilTemperaturesDAYCENT.setLayerThickness(_LayerThickness);
}
void SurfacePartonSoilSWATHourlyPartonCComponent::setClay(const std::vector<double> & _Clay)
{
    _VolumetricHeatCapacityKluitenberg.setClay(_Clay);
    _ThermalConductivitySIMULAT.setClay(_Clay);
}
void SurfacePartonSoilSWATHourlyPartonCComponent::setSilt(const std::vector<double> & _Silt)
{
    _VolumetricHeatCapacityKluitenberg.setSilt(_Silt);
}
void SurfacePartonSoilSWATHourlyPartonCComponent::setlayersNumber(int _layersNumber)
{
    _ThermalDiffu.setlayersNumber(_layersNumber);
}
void SurfacePartonSoilSWATHourlyPartonCComponent::Calculate_Model(SurfacePartonSoilSWATHourlyPartonCState &s, SurfacePartonSoilSWATHourlyPartonCState &s1, SurfacePartonSoilSWATHourlyPartonCRate &r, SurfacePartonSoilSWATHourlyPartonCAuxiliary &a, SurfacePartonSoilSWATHourlyPartonCExogenous &ex)
{
    _SurfaceTemperatureParton.Calculate_Model(s, s1, r, a, ex);
    _VolumetricHeatCapacityKluitenberg.Calculate_Model(s, s1, r, a, ex);
    _ThermalConductivitySIMULAT.Calculate_Model(s, s1, r, a, ex);
    _SoilTemperatureSWAT.Calculate_Model(s, s1, r, a, ex);
    _ThermalDiffu.Calculate_Model(s, s1, r, a, ex);
    _RangeOfSoilTemperaturesDAYCENT.Calculate_Model(s, s1, r, a, ex);
    _HourlySoilTemperaturesPartonLogan.Calculate_Model(s, s1, r, a, ex);
}
SurfacePartonSoilSWATHourlyPartonCComponent::SurfacePartonSoilSWATHourlyPartonCComponent(SurfacePartonSoilSWATHourlyPartonCComponent& toCopy)
{
    for (int i = 0; i < toCopy.getBulkDensity().size(); i++)
{
    BulkDensity[i] = toCopy.getBulkDensity()[i];
}

    SoilProfileDepth = toCopy.getSoilProfileDepth();
    AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
    LagCoefficient = toCopy.getLagCoefficient();
    for (int i = 0; i < toCopy.getLayerThickness().size(); i++)
{
    LayerThickness[i] = toCopy.getLayerThickness()[i];
}

    for (int i = 0; i < toCopy.getClay().size(); i++)
{
    Clay[i] = toCopy.getClay()[i];
}

    for (int i = 0; i < toCopy.getSilt().size(); i++)
{
    Silt[i] = toCopy.getSilt()[i];
}

    layersNumber = toCopy.getlayersNumber();
}