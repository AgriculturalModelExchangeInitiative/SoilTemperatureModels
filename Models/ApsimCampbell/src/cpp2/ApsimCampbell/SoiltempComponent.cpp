#include "SoiltempComponent.h"
using namespace ApsimCampbell;
SoiltempComponent::SoiltempComponent()
{
       
}


std::vector<double> & SoiltempComponent::getthermCondPar1(){ return this->thermCondPar1; }
int SoiltempComponent::gettopsoilNode(){ return this->topsoilNode; }
int SoiltempComponent::getsurfaceNode(){ return this->surfaceNode; }
int SoiltempComponent::getnumPhantomNodes(){ return this->numPhantomNodes; }
std::vector<std::string> & SoiltempComponent::getsoilConstituentNames(){ return this->soilConstituentNames; }
std::vector<double> & SoiltempComponent::getphysical_Thickness(){ return this->physical_Thickness; }
double SoiltempComponent::getMissingValue(){ return this->MissingValue; }
double SoiltempComponent::gettimestep(){ return this->timestep; }
double SoiltempComponent::getsoilRoughnessHeight(){ return this->soilRoughnessHeight; }
int SoiltempComponent::getnumIterationsForBoundaryLayerConductance(){ return this->numIterationsForBoundaryLayerConductance; }
double SoiltempComponent::getdefaultTimeOfMaximumTemperature(){ return this->defaultTimeOfMaximumTemperature; }
double SoiltempComponent::getpom(){ return this->pom; }
double SoiltempComponent::getDepthToConstantTemperature(){ return this->DepthToConstantTemperature; }
double SoiltempComponent::getconstantBoundaryLayerConductance(){ return this->constantBoundaryLayerConductance; }
std::vector<double> & SoiltempComponent::getthermCondPar4(){ return this->thermCondPar4; }
std::vector<double> & SoiltempComponent::getnodeDepth(){ return this->nodeDepth; }
double SoiltempComponent::getnu(){ return this->nu; }
std::vector<double> & SoiltempComponent::getpInitialValues(){ return this->pInitialValues; }
double SoiltempComponent::getps(){ return this->ps; }
std::string SoiltempComponent::getnetRadiationSource(){ return this->netRadiationSource; }
int SoiltempComponent::getairNode(){ return this->airNode; }
double SoiltempComponent::getbareSoilRoughness(){ return this->bareSoilRoughness; }
std::vector<double> & SoiltempComponent::getthermCondPar2(){ return this->thermCondPar2; }
double SoiltempComponent::getdefaultInstrumentHeight(){ return this->defaultInstrumentHeight; }
std::vector<double> & SoiltempComponent::getphysical_BD(){ return this->physical_BD; }
double SoiltempComponent::getlatentHeatOfVapourisation(){ return this->latentHeatOfVapourisation; }
double SoiltempComponent::getweather_Latitude(){ return this->weather_Latitude; }
double SoiltempComponent::getstefanBoltzmannConstant(){ return this->stefanBoltzmannConstant; }
std::string SoiltempComponent::getboundarLayerConductanceSource(){ return this->boundarLayerConductanceSource; }
std::vector<double> & SoiltempComponent::getthermCondPar3(){ return this->thermCondPar3; }

void SoiltempComponent::setthermCondPar1(const std::vector<double> & _thermCondPar1)
{
    _SoilTemperature.setthermCondPar1(_thermCondPar1);
}
void SoiltempComponent::settopsoilNode(int _topsoilNode)
{
    _SoilTemperature.settopsoilNode(_topsoilNode);
}
void SoiltempComponent::setsurfaceNode(int _surfaceNode)
{
    _SoilTemperature.setsurfaceNode(_surfaceNode);
}
void SoiltempComponent::setnumPhantomNodes(int _numPhantomNodes)
{
    _SoilTemperature.setnumPhantomNodes(_numPhantomNodes);
}
void SoiltempComponent::setsoilConstituentNames(const std::vector<std::string> & _soilConstituentNames)
{
    _SoilTemperature.setsoilConstituentNames(_soilConstituentNames);
}
void SoiltempComponent::setphysical_Thickness(const std::vector<double> & _physical_Thickness)
{
    _SoilTemperature.setphysical_Thickness(_physical_Thickness);
}
void SoiltempComponent::setMissingValue(double _MissingValue)
{
    _SoilTemperature.setMissingValue(_MissingValue);
}
void SoiltempComponent::settimestep(double _timestep)
{
    _SoilTemperature.settimestep(_timestep);
}
void SoiltempComponent::setsoilRoughnessHeight(double _soilRoughnessHeight)
{
    _SoilTemperature.setsoilRoughnessHeight(_soilRoughnessHeight);
}
void SoiltempComponent::setnumIterationsForBoundaryLayerConductance(int _numIterationsForBoundaryLayerConductance)
{
    _SoilTemperature.setnumIterationsForBoundaryLayerConductance(_numIterationsForBoundaryLayerConductance);
}
void SoiltempComponent::setdefaultTimeOfMaximumTemperature(double _defaultTimeOfMaximumTemperature)
{
    _SoilTemperature.setdefaultTimeOfMaximumTemperature(_defaultTimeOfMaximumTemperature);
}
void SoiltempComponent::setpom(double _pom)
{
    _SoilTemperature.setpom(_pom);
}
void SoiltempComponent::setDepthToConstantTemperature(double _DepthToConstantTemperature)
{
    _SoilTemperature.setDepthToConstantTemperature(_DepthToConstantTemperature);
}
void SoiltempComponent::setconstantBoundaryLayerConductance(double _constantBoundaryLayerConductance)
{
    _SoilTemperature.setconstantBoundaryLayerConductance(_constantBoundaryLayerConductance);
}
void SoiltempComponent::setthermCondPar4(const std::vector<double> & _thermCondPar4)
{
    _SoilTemperature.setthermCondPar4(_thermCondPar4);
}
void SoiltempComponent::setnodeDepth(const std::vector<double> & _nodeDepth)
{
    _SoilTemperature.setnodeDepth(_nodeDepth);
}
void SoiltempComponent::setnu(double _nu)
{
    _SoilTemperature.setnu(_nu);
}
void SoiltempComponent::setpInitialValues(const std::vector<double> & _pInitialValues)
{
    _SoilTemperature.setpInitialValues(_pInitialValues);
}
void SoiltempComponent::setps(double _ps)
{
    _SoilTemperature.setps(_ps);
}
void SoiltempComponent::setnetRadiationSource(std::string _netRadiationSource)
{
    _SoilTemperature.setnetRadiationSource(_netRadiationSource);
}
void SoiltempComponent::setairNode(int _airNode)
{
    _SoilTemperature.setairNode(_airNode);
}
void SoiltempComponent::setbareSoilRoughness(double _bareSoilRoughness)
{
    _SoilTemperature.setbareSoilRoughness(_bareSoilRoughness);
}
void SoiltempComponent::setthermCondPar2(const std::vector<double> & _thermCondPar2)
{
    _SoilTemperature.setthermCondPar2(_thermCondPar2);
}
void SoiltempComponent::setdefaultInstrumentHeight(double _defaultInstrumentHeight)
{
    _SoilTemperature.setdefaultInstrumentHeight(_defaultInstrumentHeight);
}
void SoiltempComponent::setphysical_BD(const std::vector<double> & _physical_BD)
{
    _SoilTemperature.setphysical_BD(_physical_BD);
}
void SoiltempComponent::setlatentHeatOfVapourisation(double _latentHeatOfVapourisation)
{
    _SoilTemperature.setlatentHeatOfVapourisation(_latentHeatOfVapourisation);
}
void SoiltempComponent::setweather_Latitude(double _weather_Latitude)
{
    _SoilTemperature.setweather_Latitude(_weather_Latitude);
}
void SoiltempComponent::setstefanBoltzmannConstant(double _stefanBoltzmannConstant)
{
    _SoilTemperature.setstefanBoltzmannConstant(_stefanBoltzmannConstant);
}
void SoiltempComponent::setboundarLayerConductanceSource(std::string _boundarLayerConductanceSource)
{
    _SoilTemperature.setboundarLayerConductanceSource(_boundarLayerConductanceSource);
}
void SoiltempComponent::setthermCondPar3(const std::vector<double> & _thermCondPar3)
{
    _SoilTemperature.setthermCondPar3(_thermCondPar3);
}
void SoiltempComponent::Calculate_Model(SoiltempState &s, SoiltempState &s1, SoiltempRate &r, SoiltempAuxiliary &a, SoiltempExogenous &ex)
{
    _SoilTemperature.Calculate_Model(s, s1, r, a, ex);
}
SoiltempComponent::SoiltempComponent(SoiltempComponent& toCopy)
{
    for (int i = 0; i < toCopy.getthermCondPar1().size(); i++)
{
    thermCondPar1[i] = toCopy.getthermCondPar1()[i];
}

    topsoilNode = toCopy.gettopsoilNode();
    surfaceNode = toCopy.getsurfaceNode();
    numPhantomNodes = toCopy.getnumPhantomNodes();
    for (int i = 0; i < 8; i++)
{
    soilConstituentNames[i] = toCopy.getsoilConstituentNames()[i];
}

    for (int i = 0; i < toCopy.getphysical_Thickness().size(); i++)
{
    physical_Thickness[i] = toCopy.getphysical_Thickness()[i];
}

    MissingValue = toCopy.getMissingValue();
    timestep = toCopy.gettimestep();
    soilRoughnessHeight = toCopy.getsoilRoughnessHeight();
    numIterationsForBoundaryLayerConductance = toCopy.getnumIterationsForBoundaryLayerConductance();
    defaultTimeOfMaximumTemperature = toCopy.getdefaultTimeOfMaximumTemperature();
    pom = toCopy.getpom();
    DepthToConstantTemperature = toCopy.getDepthToConstantTemperature();
    constantBoundaryLayerConductance = toCopy.getconstantBoundaryLayerConductance();
    for (int i = 0; i < toCopy.getthermCondPar4().size(); i++)
{
    thermCondPar4[i] = toCopy.getthermCondPar4()[i];
}

    for (int i = 0; i < toCopy.getnodeDepth().size(); i++)
{
    nodeDepth[i] = toCopy.getnodeDepth()[i];
}

    nu = toCopy.getnu();
    for (int i = 0; i < toCopy.getpInitialValues().size(); i++)
{
    pInitialValues[i] = toCopy.getpInitialValues()[i];
}

    ps = toCopy.getps();
    netRadiationSource = toCopy.getnetRadiationSource();
    airNode = toCopy.getairNode();
    bareSoilRoughness = toCopy.getbareSoilRoughness();
    for (int i = 0; i < toCopy.getthermCondPar2().size(); i++)
{
    thermCondPar2[i] = toCopy.getthermCondPar2()[i];
}

    defaultInstrumentHeight = toCopy.getdefaultInstrumentHeight();
    for (int i = 0; i < toCopy.getphysical_BD().size(); i++)
{
    physical_BD[i] = toCopy.getphysical_BD()[i];
}

    latentHeatOfVapourisation = toCopy.getlatentHeatOfVapourisation();
    weather_Latitude = toCopy.getweather_Latitude();
    stefanBoltzmannConstant = toCopy.getstefanBoltzmannConstant();
    boundarLayerConductanceSource = toCopy.getboundarLayerConductanceSource();
    for (int i = 0; i < toCopy.getthermCondPar3().size(); i++)
{
    thermCondPar3[i] = toCopy.getthermCondPar3()[i];
}

}


void SoiltempComponent::Init(SoiltempState &s, SoiltempState &s1, SoiltempRate &r, SoiltempAuxiliary &a, SoiltempExogenous &ex)
{
    _SoilTemperature.Init(s, s1, r, a, ex);
}
