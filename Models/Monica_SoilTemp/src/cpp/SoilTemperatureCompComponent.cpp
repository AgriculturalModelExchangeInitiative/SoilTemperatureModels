#include "SoilTemperatureCompComponent.h"

    SoilTemperatureCompComponent::SoilTemperatureCompComponent()
    {
           
    }
    

double SoilTemperatureCompComponent::getdampingFactor() {return this-> dampingFactor; }
double SoilTemperatureCompComponent::gettimeStep() {return this-> timeStep; }
double SoilTemperatureCompComponent::getsoilMoistureConst() {return this-> soilMoistureConst; }
double SoilTemperatureCompComponent::getbaseTemp() {return this-> baseTemp; }
double SoilTemperatureCompComponent::getinitialSurfaceTemp() {return this-> initialSurfaceTemp; }
double SoilTemperatureCompComponent::getdensityAir() {return this-> densityAir; }
double SoilTemperatureCompComponent::getspecificHeatCapacityAir() {return this-> specificHeatCapacityAir; }
double SoilTemperatureCompComponent::getdensityHumus() {return this-> densityHumus; }
double SoilTemperatureCompComponent::getspecificHeatCapacityHumus() {return this-> specificHeatCapacityHumus; }
double SoilTemperatureCompComponent::getdensityWater() {return this-> densityWater; }
double SoilTemperatureCompComponent::getspecificHeatCapacityWater() {return this-> specificHeatCapacityWater; }
double SoilTemperatureCompComponent::getquartzRawDensity() {return this-> quartzRawDensity; }
double SoilTemperatureCompComponent::getspecificHeatCapacityQuartz() {return this-> specificHeatCapacityQuartz; }
double SoilTemperatureCompComponent::getnTau() {return this-> nTau; }
double SoilTemperatureCompComponent::getsoilAlbedo() {return this-> soilAlbedo; }
int SoilTemperatureCompComponent::getnoOfTempLayers() {return this-> noOfTempLayers; }
int SoilTemperatureCompComponent::getnoOfSoilLayers() {return this-> noOfSoilLayers; }
vector<double>& SoilTemperatureCompComponent::getlayerThickness() {return this-> layerThickness; }
vector<double>& SoilTemperatureCompComponent::getsoilBulkDensity() {return this-> soilBulkDensity; }
vector<double>& SoilTemperatureCompComponent::getsaturation() {return this-> saturation; }
vector<double>& SoilTemperatureCompComponent::getsoilOrganicMatter() {return this-> soilOrganicMatter; }

void SoilTemperatureCompComponent::setdampingFactor(double _dampingFactor)
{
    _NoSnowSoilSurfaceTemperature.setdampingFactor(_dampingFactor);
}
void SoilTemperatureCompComponent::settimeStep(double _timeStep)
{
    _SoilTemperature.settimeStep(_timeStep);
}
void SoilTemperatureCompComponent::setsoilMoistureConst(double _soilMoistureConst)
{
    _SoilTemperature.setsoilMoistureConst(_soilMoistureConst);
}
void SoilTemperatureCompComponent::setbaseTemp(double _baseTemp)
{
    _SoilTemperature.setbaseTemp(_baseTemp);
}
void SoilTemperatureCompComponent::setinitialSurfaceTemp(double _initialSurfaceTemp)
{
    _SoilTemperature.setinitialSurfaceTemp(_initialSurfaceTemp);
}
void SoilTemperatureCompComponent::setdensityAir(double _densityAir)
{
    _SoilTemperature.setdensityAir(_densityAir);
}
void SoilTemperatureCompComponent::setspecificHeatCapacityAir(double _specificHeatCapacityAir)
{
    _SoilTemperature.setspecificHeatCapacityAir(_specificHeatCapacityAir);
}
void SoilTemperatureCompComponent::setdensityHumus(double _densityHumus)
{
    _SoilTemperature.setdensityHumus(_densityHumus);
}
void SoilTemperatureCompComponent::setspecificHeatCapacityHumus(double _specificHeatCapacityHumus)
{
    _SoilTemperature.setspecificHeatCapacityHumus(_specificHeatCapacityHumus);
}
void SoilTemperatureCompComponent::setdensityWater(double _densityWater)
{
    _SoilTemperature.setdensityWater(_densityWater);
}
void SoilTemperatureCompComponent::setspecificHeatCapacityWater(double _specificHeatCapacityWater)
{
    _SoilTemperature.setspecificHeatCapacityWater(_specificHeatCapacityWater);
}
void SoilTemperatureCompComponent::setquartzRawDensity(double _quartzRawDensity)
{
    _SoilTemperature.setquartzRawDensity(_quartzRawDensity);
}
void SoilTemperatureCompComponent::setspecificHeatCapacityQuartz(double _specificHeatCapacityQuartz)
{
    _SoilTemperature.setspecificHeatCapacityQuartz(_specificHeatCapacityQuartz);
}
void SoilTemperatureCompComponent::setnTau(double _nTau)
{
    _SoilTemperature.setnTau(_nTau);
}
void SoilTemperatureCompComponent::setsoilAlbedo(double _soilAlbedo)
{
    _SoilTemperature.setsoilAlbedo(_soilAlbedo);
}
void SoilTemperatureCompComponent::setnoOfTempLayers(int _noOfTempLayers)
{
    _SoilTemperature.setnoOfTempLayers(_noOfTempLayers);
}
void SoilTemperatureCompComponent::setnoOfSoilLayers(int _noOfSoilLayers)
{
    _SoilTemperature.setnoOfSoilLayers(_noOfSoilLayers);
}
void SoilTemperatureCompComponent::setlayerThickness(vector<double>& _layerThickness)
{
    _SoilTemperature.setlayerThickness(_layerThickness);
}
void SoilTemperatureCompComponent::setsoilBulkDensity(vector<double>& _soilBulkDensity)
{
    _SoilTemperature.setsoilBulkDensity(_soilBulkDensity);
}
void SoilTemperatureCompComponent::setsaturation(vector<double>& _saturation)
{
    _SoilTemperature.setsaturation(_saturation);
}
void SoilTemperatureCompComponent::setsoilOrganicMatter(vector<double>& _soilOrganicMatter)
{
    _SoilTemperature.setsoilOrganicMatter(_soilOrganicMatter);
}
void SoilTemperatureCompComponent::Calculate_Model(SoilTemperatureCompState& s, SoilTemperatureCompState& s1, SoilTemperatureCompRate& r, SoilTemperatureCompAuxiliary& a, SoilTemperatureCompExogenous& ex)
{
    s.soilTemperature = s.prevDaySoilTemperature;
    _nosnowsoilsurfacetemperature.Calculate_Model(s, s1, r, a, ex);
    s.noSnowSoilSurfaceTemperature = s.soilSurfaceTemperature;
    _withsnowsoilsurfacetemperature.Calculate_Model(s, s1, r, a, ex);
    _soiltemperature.Calculate_Model(s, s1, r, a, ex);
    s.soilTemperature = newSoilTemperature;
}
SoilTemperatureCompComponent::SoilTemperatureCompComponent(const SoilTemperatureCompComponent& toCopy)
{
    dampingFactor = toCopy.dampingFactor;
    timeStep = toCopy.timeStep;
    soilMoistureConst = toCopy.soilMoistureConst;
    baseTemp = toCopy.baseTemp;
    initialSurfaceTemp = toCopy.initialSurfaceTemp;
    densityAir = toCopy.densityAir;
    specificHeatCapacityAir = toCopy.specificHeatCapacityAir;
    densityHumus = toCopy.densityHumus;
    specificHeatCapacityHumus = toCopy.specificHeatCapacityHumus;
    densityWater = toCopy.densityWater;
    specificHeatCapacityWater = toCopy.specificHeatCapacityWater;
    quartzRawDensity = toCopy.quartzRawDensity;
    specificHeatCapacityQuartz = toCopy.specificHeatCapacityQuartz;
    nTau = toCopy.nTau;
    soilAlbedo = toCopy.soilAlbedo;
    noOfTempLayers = toCopy.noOfTempLayers;
    noOfSoilLayers = toCopy.noOfSoilLayers;
    
        for (int i = 0; i < toCopy.layerThickness.Count; i++)
        {
            layerThickness.Add(toCopy.layerThickness[i]);
        }
    
    
        for (int i = 0; i < toCopy.soilBulkDensity.Count; i++)
        {
            soilBulkDensity.Add(toCopy.soilBulkDensity[i]);
        }
    
    
        for (int i = 0; i < toCopy.saturation.Count; i++)
        {
            saturation.Add(toCopy.saturation[i]);
        }
    
    
        for (int i = 0; i < toCopy.soilOrganicMatter.Count; i++)
        {
            soilOrganicMatter.Add(toCopy.soilOrganicMatter[i]);
        }
    
}