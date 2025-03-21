#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include <numeric>
#include <algorithm>
#include <array>
#include <map>
#include <set>
#include <tuple>
#include "SoilTemperature.h"
using namespace ApsimCampbell;
void SoilTemperature::Init(SoiltempState &s, SoiltempState &s1, SoiltempRate &r, SoiltempAuxiliary &a, SoiltempExogenous &ex)
{
    s.doInitialisationStuff = false;
    s.internalTimeStep = 0.0;
    s.timeOfDaySecs = 0.0;
    s.numNodes = 0;
    s.numLayers = 0;
    s.boundaryLayerConductance = 0.0;
    s.airTemperature = 0.0;
    s.maxTempYesterday = 0.0;
    s.minTempYesterday = 0.0;
    s.instrumentHeight = 0.0;
    s.netRadiation = 0.0;
    s.canopyHeight = 0.0;
    s.instrumHeight = 0.0;
    s.doInitialisationStuff = true;
    s.instrumentHeight = getIniVariables(s.instrumentHeight, s.instrumHeight, defaultInstrumentHeight);
    tie(s.heatStorage, s.minSoilTemp, s.bulkDensity, s.maxSoilTemp, nodeDepth, s.newTemperature, s.soilWater, s.thermalConductance, s.thermalConductivity, s.sand, s.carbon, s.thickness, s.rocks, s.clay, s.soilTemp, s.silt, s.volSpecHeatSoil, s.aveSoilTemp, s.morningSoilTemp, s.numNodes, s.numLayers) = getProfileVariables(s.heatStorage, s.minSoilTemp, s.bulkDensity, s.numNodes, physical_BD, s.maxSoilTemp, ex.waterBalance_SW, ex.organic_Carbon, ex.physical_Rocks, nodeDepth, topsoilNode, s.newTemperature, surfaceNode, s.soilWater, s.thermalConductance, s.thermalConductivity, s.sand, s.carbon, s.thickness, numPhantomNodes, ex.physical_ParticleSizeSand, s.rocks, s.clay, ex.physical_ParticleSizeSilt, airNode, ex.physical_ParticleSizeClay, s.soilTemp, s.numLayers, physical_Thickness, s.silt, s.volSpecHeatSoil, s.aveSoilTemp, s.morningSoilTemp, DepthToConstantTemperature, MissingValue);
    tie(s.newTemperature, s.soilTemp, thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1, soilRoughnessHeight) = readParam(bareSoilRoughness, s.newTemperature, soilRoughnessHeight, s.soilTemp, thermCondPar2, s.numLayers, s.bulkDensity, s.numNodes, thermCondPar3, thermCondPar4, s.clay, thermCondPar1, ex.weather_Tav, ex.clock_Today_DayOfYear, surfaceNode, ex.weather_Amp, s.thickness, weather_Latitude);
    s.InitialValues = pInitialValues;
}
SoilTemperature::SoilTemperature() {}
double SoilTemperature::getweather_Latitude() { return this->weather_Latitude; }
std::vector<double> & SoilTemperature::getphysical_Thickness() { return this->physical_Thickness; }
std::vector<double> & SoilTemperature::getphysical_BD() { return this->physical_BD; }
double SoilTemperature::getps() { return this->ps; }
std::vector<double> & SoilTemperature::getpInitialValues() { return this->pInitialValues; }
double SoilTemperature::getDepthToConstantTemperature() { return this->DepthToConstantTemperature; }
double SoilTemperature::gettimestep() { return this->timestep; }
double SoilTemperature::getlatentHeatOfVapourisation() { return this->latentHeatOfVapourisation; }
double SoilTemperature::getstefanBoltzmannConstant() { return this->stefanBoltzmannConstant; }
int SoilTemperature::getairNode() { return this->airNode; }
int SoilTemperature::getsurfaceNode() { return this->surfaceNode; }
int SoilTemperature::gettopsoilNode() { return this->topsoilNode; }
int SoilTemperature::getnumPhantomNodes() { return this->numPhantomNodes; }
double SoilTemperature::getconstantBoundaryLayerConductance() { return this->constantBoundaryLayerConductance; }
int SoilTemperature::getnumIterationsForBoundaryLayerConductance() { return this->numIterationsForBoundaryLayerConductance; }
double SoilTemperature::getdefaultTimeOfMaximumTemperature() { return this->defaultTimeOfMaximumTemperature; }
double SoilTemperature::getdefaultInstrumentHeight() { return this->defaultInstrumentHeight; }
double SoilTemperature::getbareSoilRoughness() { return this->bareSoilRoughness; }
std::vector<double> & SoilTemperature::getnodeDepth() { return this->nodeDepth; }
std::vector<double> & SoilTemperature::getthermCondPar1() { return this->thermCondPar1; }
std::vector<double> & SoilTemperature::getthermCondPar2() { return this->thermCondPar2; }
std::vector<double> & SoilTemperature::getthermCondPar3() { return this->thermCondPar3; }
std::vector<double> & SoilTemperature::getthermCondPar4() { return this->thermCondPar4; }
double SoilTemperature::getpom() { return this->pom; }
double SoilTemperature::getsoilRoughnessHeight() { return this->soilRoughnessHeight; }
double SoilTemperature::getnu() { return this->nu; }
std::string SoilTemperature::getboundarLayerConductanceSource() { return this->boundarLayerConductanceSource; }
std::string SoilTemperature::getnetRadiationSource() { return this->netRadiationSource; }
double SoilTemperature::getMissingValue() { return this->MissingValue; }
std::vector<std::string> & SoilTemperature::getsoilConstituentNames() { return this->soilConstituentNames; }
void SoilTemperature::setweather_Latitude(double _weather_Latitude) { this->weather_Latitude = _weather_Latitude; }
void SoilTemperature::setphysical_Thickness(std::vector<double> const &_physical_Thickness){
    this->physical_Thickness = _physical_Thickness;
}
void SoilTemperature::setphysical_BD(std::vector<double> const &_physical_BD){
    this->physical_BD = _physical_BD;
}
void SoilTemperature::setps(double _ps) { this->ps = _ps; }
void SoilTemperature::setpInitialValues(std::vector<double> const &_pInitialValues){
    this->pInitialValues = _pInitialValues;
}
void SoilTemperature::setDepthToConstantTemperature(double _DepthToConstantTemperature) { this->DepthToConstantTemperature = _DepthToConstantTemperature; }
void SoilTemperature::settimestep(double _timestep) { this->timestep = _timestep; }
void SoilTemperature::setlatentHeatOfVapourisation(double _latentHeatOfVapourisation) { this->latentHeatOfVapourisation = _latentHeatOfVapourisation; }
void SoilTemperature::setstefanBoltzmannConstant(double _stefanBoltzmannConstant) { this->stefanBoltzmannConstant = _stefanBoltzmannConstant; }
void SoilTemperature::setairNode(int _airNode) { this->airNode = _airNode; }
void SoilTemperature::setsurfaceNode(int _surfaceNode) { this->surfaceNode = _surfaceNode; }
void SoilTemperature::settopsoilNode(int _topsoilNode) { this->topsoilNode = _topsoilNode; }
void SoilTemperature::setnumPhantomNodes(int _numPhantomNodes) { this->numPhantomNodes = _numPhantomNodes; }
void SoilTemperature::setconstantBoundaryLayerConductance(double _constantBoundaryLayerConductance) { this->constantBoundaryLayerConductance = _constantBoundaryLayerConductance; }
void SoilTemperature::setnumIterationsForBoundaryLayerConductance(int _numIterationsForBoundaryLayerConductance) { this->numIterationsForBoundaryLayerConductance = _numIterationsForBoundaryLayerConductance; }
void SoilTemperature::setdefaultTimeOfMaximumTemperature(double _defaultTimeOfMaximumTemperature) { this->defaultTimeOfMaximumTemperature = _defaultTimeOfMaximumTemperature; }
void SoilTemperature::setdefaultInstrumentHeight(double _defaultInstrumentHeight) { this->defaultInstrumentHeight = _defaultInstrumentHeight; }
void SoilTemperature::setbareSoilRoughness(double _bareSoilRoughness) { this->bareSoilRoughness = _bareSoilRoughness; }
void SoilTemperature::setnodeDepth(std::vector<double> const &_nodeDepth){
    this->nodeDepth = _nodeDepth;
}
void SoilTemperature::setthermCondPar1(std::vector<double> const &_thermCondPar1){
    this->thermCondPar1 = _thermCondPar1;
}
void SoilTemperature::setthermCondPar2(std::vector<double> const &_thermCondPar2){
    this->thermCondPar2 = _thermCondPar2;
}
void SoilTemperature::setthermCondPar3(std::vector<double> const &_thermCondPar3){
    this->thermCondPar3 = _thermCondPar3;
}
void SoilTemperature::setthermCondPar4(std::vector<double> const &_thermCondPar4){
    this->thermCondPar4 = _thermCondPar4;
}
void SoilTemperature::setpom(double _pom) { this->pom = _pom; }
void SoilTemperature::setsoilRoughnessHeight(double _soilRoughnessHeight) { this->soilRoughnessHeight = _soilRoughnessHeight; }
void SoilTemperature::setnu(double _nu) { this->nu = _nu; }
void SoilTemperature::setboundarLayerConductanceSource(std::string _boundarLayerConductanceSource) { this->boundarLayerConductanceSource = _boundarLayerConductanceSource; }
void SoilTemperature::setnetRadiationSource(std::string _netRadiationSource) { this->netRadiationSource = _netRadiationSource; }
void SoilTemperature::setMissingValue(double _MissingValue) { this->MissingValue = _MissingValue; }
void SoilTemperature::setsoilConstituentNames(std::vector<std::string> const &_soilConstituentNames){
    this->soilConstituentNames = _soilConstituentNames;
}
void SoilTemperature::Calculate_Model(SoiltempState &s, SoiltempState &s1, SoiltempRate &r, SoiltempAuxiliary &a, SoiltempExogenous &ex)
{
    //- Name: SoilTemperature -Version:  1.0, -Time step:  1
    //- Description:
    //            * Title: SoilTemperature
    //            * Authors: APSIM
    //            * Reference: None
    //            * Institution: APSIM Initiative
    //            * ExtendedDescription:  Soil Temperature 
    //            * ShortDescription: Heat flux and temperatures over the surface and soil profile (based on Campbell, 1985)
    //- inputs:
    //            * name: weather_MinT
    //                          ** description : Minimum temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: weather_MaxT
    //                          ** description : Maximum temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: weather_MeanT
    //                          ** description : Mean temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: weather_Tav
    //                          ** description : Annual average temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: weather_Amp
    //                          ** description : Annual average temperature amplitude
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: weather_AirPressure
    //                          ** description : Air pressure
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : hPa
    //            * name: weather_Wind
    //                          ** description : Wind speed
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : m/s
    //            * name: weather_Latitude
    //                          ** description : Latitude
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : deg
    //            * name: weather_Radn
    //                          ** description : Solar radiation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : MJ/m2/day
    //            * name: clock_Today_DayOfYear
    //                          ** description : Day of year
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : day number
    //            * name: microClimate_CanopyHeight
    //                          ** description : Canopy height
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: physical_Thickness
    //                          ** description : Soil layer thickness
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: physical_BD
    //                          ** description : Bulk density
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : g/cc
    //            * name: ps
    //                          ** description : ps
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: physical_Rocks
    //                          ** description : Rocks
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: physical_ParticleSizeSand
    //                          ** description : Particle size sand
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: physical_ParticleSizeSilt
    //                          ** description : Particle size silt
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: physical_ParticleSizeClay
    //                          ** description : Particle size clay
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: organic_Carbon
    //                          ** description : Total organic carbon
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: waterBalance_SW
    //                          ** description : Volumetric water content
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm/mm
    //            * name: waterBalance_Eos
    //                          ** description : Potential soil evaporation from soil surface
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: waterBalance_Eo
    //                          ** description : Potential soil evapotranspiration from soil surface
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: waterBalance_Es
    //                          ** description : Actual (realised) soil water evaporation
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: waterBalance_Salb
    //                          ** description : Fraction of incoming radiation reflected from bare soil
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 0-1
    //            * name: InitialValues
    //                          ** description : Initial soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: pInitialValues
    //                          ** description : Initial soil temperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: DepthToConstantTemperature
    //                          ** description : Soil depth to constant temperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 10000
    //                          ** unit : mm
    //            * name: timestep
    //                          ** description : Internal time-step (minutes)
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 24.0 * 60.0 * 60.0
    //                          ** unit : minutes
    //            * name: latentHeatOfVapourisation
    //                          ** description : Latent heat of vapourisation for water
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 2465000
    //                          ** unit : miJ/kg
    //            * name: stefanBoltzmannConstant
    //                          ** description : The Stefan-Boltzmann constant
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0000000567
    //                          ** unit : W/m2/K4
    //            * name: airNode
    //                          ** description : The index of the node in the atmosphere (aboveground)
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : 
    //            * name: surfaceNode
    //                          ** description : The index of the node on the soil surface (depth = 0)
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1
    //                          ** unit : 
    //            * name: topsoilNode
    //                          ** description : The index of the first node within the soil (top layer)
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 2
    //                          ** unit : 
    //            * name: numPhantomNodes
    //                          ** description : The number of phantom nodes below the soil profile
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 5
    //                          ** unit : 
    //            * name: constantBoundaryLayerConductance
    //                          ** description : Boundary layer conductance, if constant
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 20
    //                          ** unit : K/W
    //            * name: numIterationsForBoundaryLayerConductance
    //                          ** description : Number of iterations to calculate atmosphere boundary layer conductance
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INT
    //                          ** min : 
    //                          ** default : 1
    //                          ** unit : 
    //            * name: defaultTimeOfMaximumTemperature
    //                          ** description : Time of maximum temperature
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 14.0
    //                          ** unit : minutes
    //            * name: defaultInstrumentHeight
    //                          ** description : Default instrument height
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 1.2
    //                          ** unit : m
    //            * name: bareSoilRoughness
    //                          ** description : Roughness element height of bare soil
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 57
    //                          ** unit : mm
    //            * name: doInitialisationStuff
    //                          ** description : Flag whether initialisation is needed
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : BOOLEAN
    //                          ** max : 
    //                          ** min : 
    //                          ** default : false
    //                          ** unit : mintes
    //            * name: internalTimeStep
    //                          ** description : Internal time-step
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : sec
    //            * name: timeOfDaySecs
    //                          ** description : Time of day from midnight
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : sec
    //            * name: numNodes
    //                          ** description : Number of nodes over the soil profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : 
    //            * name: numLayers
    //                          ** description : Number of layers in the soil profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : INT
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : 
    //            * name: nodeDepth
    //                          ** description : Depths of nodes
    //                          ** inputtype : parameter
    //                          ** parametercategory : private
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: thermCondPar1
    //                          ** description : Parameter 1 for computing thermal conductivity of soil solids
    //                          ** inputtype : parameter
    //                          ** parametercategory : private
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: thermCondPar2
    //                          ** description : Parameter 2 for computing thermal conductivity of soil solids
    //                          ** inputtype : parameter
    //                          ** parametercategory : private
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: thermCondPar3
    //                          ** description : Parameter 3 for computing thermal conductivity of soil solids
    //                          ** inputtype : parameter
    //                          ** parametercategory : private
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: thermCondPar4
    //                          ** description : Parameter 4 for computing thermal conductivity of soil solids
    //                          ** inputtype : parameter
    //                          ** parametercategory : private
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: volSpecHeatSoil
    //                          ** description : Volumetric specific heat over the soil profile
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : J/K/m3
    //            * name: soilTemp
    //                          ** description : Soil temperature over the soil profile at morning
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: morningSoilTemp
    //                          ** description : Soil temperature over the soil profile at morning
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: heatStorage
    //                          ** description : CP, heat storage between nodes
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : J/K
    //            * name: thermalConductance
    //                          ** description : K, conductance of element between nodes
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : W/K
    //            * name: thermalConductivity
    //                          ** description : Thermal conductivity
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : W.m/K
    //            * name: boundaryLayerConductance
    //                          ** description : Average daily atmosphere boundary layer conductance
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : 
    //            * name: newTemperature
    //                          ** description : Soil temperature at the end of this iteration
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: airTemperature
    //                          ** description : Air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : oC
    //            * name: maxTempYesterday
    //                          ** description : Yesterday's maximum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : oC
    //            * name: minTempYesterday
    //                          ** description : Yesterday's minimum daily air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : oC
    //            * name: soilWater
    //                          ** description : Volumetric water content of each soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm3/mm3
    //            * name: minSoilTemp
    //                          ** description : Minimum soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: maxSoilTemp
    //                          ** description : Maximum soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: aveSoilTemp
    //                          ** description : average soil temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: aveSoilWater
    //                          ** description : Average soil temperaturer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : oC
    //            * name: thickness
    //                          ** description : Thickness of each soil, includes phantom layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : mm
    //            * name: bulkDensity
    //                          ** description : Soil bulk density, includes phantom layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : g/cm3
    //            * name: rocks
    //                          ** description : Volumetric fraction of rocks in each soil laye
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: carbon
    //                          ** description : Volumetric fraction of carbon (CHECK, OM?) in each soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: sand
    //                          ** description : Volumetric fraction of sand in each soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: pom
    //                          ** description : Particle density of organic matter
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : Mg/m3
    //            * name: silt
    //                          ** description : Volumetric fraction of silt in each soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: clay
    //                          ** description : Volumetric fraction of clay in each soil layer
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : %
    //            * name: soilRoughnessHeight
    //                          ** description : Height of soil roughness
    //                          ** inputtype : parameter
    //                          ** parametercategory : private
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: instrumentHeight
    //                          ** description : Height of instruments above soil surface
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: netRadiation
    //                          ** description : Net radiation per internal time-step
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : MJ
    //            * name: canopyHeight
    //                          ** description : Height of canopy above ground
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: instrumHeight
    //                          ** description : Height of instruments above ground
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0
    //                          ** unit : mm
    //            * name: nu
    //                          ** description : Forward/backward differencing coefficient
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.6
    //                          ** unit : 0-1
    //            * name: boundarLayerConductanceSource
    //                          ** description : Flag whether boundary layer conductance is calculated or gotten from inpu
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : STRING
    //                          ** max : 
    //                          ** min : 
    //                          ** default : calc
    //                          ** unit : 
    //            * name: netRadiationSource
    //                          ** description : Flag whether net radiation is calculated or gotten from input
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : STRING
    //                          ** max : 
    //                          ** min : 
    //                          ** default : calc
    //                          ** unit : m
    //            * name: MissingValue
    //                          ** description : missing value
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 99999
    //                          ** unit : m
    //            * name: soilConstituentNames
    //                          ** description : soilConstituentNames
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : STRINGARRAY
    //                          ** len : 8
    //                          ** max : 
    //                          ** min : 
    //                          ** default : ["Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"]
    //                          ** unit : m
    //- outputs:
    //            * name: heatStorage
    //                          ** description : CP, heat storage between nodes
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : J/K
    //            * name: instrumentHeight
    //                          ** description : Height of instruments above soil surface
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : mm
    //            * name: canopyHeight
    //                          ** description : Height of canopy above ground
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : mm
    //            * name: minSoilTemp
    //                          ** description : Minimum soil temperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: maxSoilTemp
    //                          ** description : Maximum soil temperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: aveSoilTemp
    //                          ** description : average soil temperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: volSpecHeatSoil
    //                          ** description : Volumetric specific heat over the soil profile
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : J/K/m3
    //            * name: soilTemp
    //                          ** description : Soil temperature over the soil profile at morning
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: morningSoilTemp
    //                          ** description : Soil temperature over the soil profile at morning
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: newTemperature
    //                          ** description : Soil temperature at the end of this iteration
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: thermalConductivity
    //                          ** description : Thermal conductivity
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : W.m/K
    //            * name: thermalConductance
    //                          ** description : K, conductance of element between nodes
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : W/K
    //            * name: boundaryLayerConductance
    //                          ** description : Average daily atmosphere boundary layer conductance
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: soilWater
    //                          ** description : Volumetric water content of each soil layer
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : mm3/mm3
    //            * name: doInitialisationStuff
    //                          ** description : Flag whether initialisation is needed
    //                          ** variablecategory : state
    //                          ** datatype : BOOLEAN
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : 
    //            * name: maxTempYesterday
    //                          ** description : Yesterday's maximum daily air temperature (oC)
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: minTempYesterday
    //                          ** description : Yesterday's minimum daily air temperature (oC)
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 
    //                          ** unit : oC
    //                          ** min : 
    //            * name: airTemperature
    //                          ** description : Air temperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    //            * name: internalTimeStep
    //                          ** description : Internal time-step
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : sec
    //            * name: timeOfDaySecs
    //                          ** description : Time of day from midnight
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : sec
    //            * name: netRadiation
    //                          ** description : Net radiation per internal time-step
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : MJ
    //            * name: InitialValues
    //                          ** description : Initial soil temperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : oC
    int i;
    tie(s.soilWater, s.instrumentHeight, s.canopyHeight) = getOtherVariables(s.numLayers, s.numNodes, s.soilWater, s.instrumentHeight, soilRoughnessHeight, ex.waterBalance_SW, ex.microClimate_CanopyHeight, s.canopyHeight);
    if (s.doInitialisationStuff)
    {
        if (ValuesInArray(s.InitialValues, MissingValue))
        {
            s.soilTemp = std::move(std::vector<double>(s.numNodes + 1 + 1, 0.0));
            for (int _i=topsoilNode, _k=0; _i < (topsoilNode + int(s.InitialValues.size())) && _k < (0 + int(s.InitialValues.size())); _i++, _k++) {
                s.soilTemp[_i] = s.InitialValues[_k];
            }
        }
        else
        {
            s.soilTemp = calcSoilTemperature(s.soilTemp, ex.weather_Tav, ex.clock_Today_DayOfYear, surfaceNode, s.numNodes, ex.weather_Amp, s.thickness, weather_Latitude);
            s.InitialValues = std::move(std::vector<double>(s.numLayers, 0.0));
            for (int _i=0, _k=topsoilNode; _i < (0 + s.numLayers) && _k < (topsoilNode + s.numLayers); _i++, _k++) {
                s.InitialValues[_i] = s.soilTemp[_k];
            }
        }
        s.soilTemp[airNode] = ex.weather_MeanT;
        s.soilTemp[surfaceNode] = calcSurfaceTemperature(ex.weather_MeanT, ex.weather_MaxT, ex.waterBalance_Salb, ex.weather_Radn);
        for (i=s.numNodes + 1 ; i!=int(s.soilTemp.size()) ; i+=1)
        {
            s.soilTemp[i] = ex.weather_Tav;
        }for (int _i=0, _k=0; _i < (0 + int(s.soilTemp.size())) && _k < s.soilTemp.size(); _i++, _k++) {
        s.newTemperature[_i] = s.soilTemp[_k];
        }
        s.maxTempYesterday = ex.weather_MaxT;
        s.minTempYesterday = ex.weather_MinT;
        s.doInitialisationStuff = false;
    }
    tie(s.minSoilTemp, s.maxSoilTemp, s.soilTemp, s.newTemperature, s.thermalConductivity, s.aveSoilTemp, s.morningSoilTemp, s.volSpecHeatSoil, s.heatStorage, s.thermalConductance, s.timeOfDaySecs, s.netRadiation, s.airTemperature, s.internalTimeStep, s.minTempYesterday, s.boundaryLayerConductance, s.maxTempYesterday) = doProcess(s.timeOfDaySecs, s.netRadiation, s.minSoilTemp, s.maxSoilTemp, numIterationsForBoundaryLayerConductance, timestep, s.boundaryLayerConductance, s.maxTempYesterday, airNode, s.soilTemp, s.airTemperature, s.newTemperature, ex.weather_MaxT, s.internalTimeStep, boundarLayerConductanceSource, s.thermalConductivity, s.minTempYesterday, s.aveSoilTemp, s.morningSoilTemp, ex.weather_MeanT, constantBoundaryLayerConductance, ex.weather_MinT, ex.clock_Today_DayOfYear, ex.weather_Radn, weather_Latitude, soilConstituentNames, s.numNodes, s.volSpecHeatSoil, s.soilWater, nodeDepth, s.thickness, surfaceNode, MissingValue, s.carbon, s.bulkDensity, pom, s.rocks, s.sand, ps, s.silt, s.clay, defaultTimeOfMaximumTemperature, ex.waterBalance_Eo, ex.waterBalance_Eos, ex.waterBalance_Salb, stefanBoltzmannConstant, ex.weather_AirPressure, ex.weather_Wind, s.instrumentHeight, s.canopyHeight, s.heatStorage, netRadiationSource, latentHeatOfVapourisation, ex.waterBalance_Es, s.thermalConductance, nu);
}
double SoilTemperature::getIniVariables(double instrumentHeight, double instrumHeight, double defaultInstrumentHeight)
{
    if (instrumHeight > 0.00001)
    {
        instrumentHeight = instrumHeight;
    }
    else
    {
        instrumentHeight = defaultInstrumentHeight;
    }
    return instrumentHeight;
}
std::tuple<std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,int,int> SoilTemperature::getProfileVariables(std::vector<double> heatStorage, std::vector<double> minSoilTemp, std::vector<double> bulkDensity, int numNodes, std::vector<double> physical_BD, std::vector<double> maxSoilTemp, std::vector<double> waterBalance_SW, std::vector<double> organic_Carbon, std::vector<double> physical_Rocks, std::vector<double> nodeDepth, int topsoilNode, std::vector<double> newTemperature, int surfaceNode, std::vector<double> soilWater, std::vector<double> thermalConductance, std::vector<double> thermalConductivity, std::vector<double> sand, std::vector<double> carbon, std::vector<double> thickness, int numPhantomNodes, std::vector<double> physical_ParticleSizeSand, std::vector<double> rocks, std::vector<double> clay, std::vector<double> physical_ParticleSizeSilt, int airNode, std::vector<double> physical_ParticleSizeClay, std::vector<double> soilTemp, int numLayers, std::vector<double> physical_Thickness, std::vector<double> silt, std::vector<double> volSpecHeatSoil, std::vector<double> aveSoilTemp, std::vector<double> morningSoilTemp, double DepthToConstantTemperature, double MissingValue)
{
    int layer;
    int node;
    int i;
    double belowProfileDepth;
    double thicknessForPhantomNodes;
    int firstPhantomNode;
    std::vector<double> oldDepth;
    std::vector<double> oldBulkDensity;
    std::vector<double> oldSoilWater;
    numLayers = int(physical_Thickness.size());
    numNodes = numLayers + numPhantomNodes;
    thickness = std::move(std::vector<double>(numLayers + numPhantomNodes + 1, 0.0));
    for (int _i=1, _k=0; _i < (1 + int(physical_Thickness.size())) && _k < physical_Thickness.size(); _i++, _k++) {
    thickness[_i] = physical_Thickness[_k];
    }
    belowProfileDepth = std::max(DepthToConstantTemperature - Sum(thickness, 1, numLayers, MissingValue), 1000.0);
    thicknessForPhantomNodes = belowProfileDepth * 2.0 / numPhantomNodes;
    firstPhantomNode = numLayers;
    for (i=firstPhantomNode ; i!=firstPhantomNode + numPhantomNodes ; i+=1)
    {
        thickness[i] = thicknessForPhantomNodes;
    }
    oldDepth = nodeDepth;
    nodeDepth = std::move(std::vector<double>(numNodes + 1 + 1, 0.0));
    if (true)
    {
        for (int _i=0, _k=0; _i < (std::min(numNodes + 1 + 1, int(oldDepth.size()))) && _k < (std::min(numNodes + 1 + 1, int(oldDepth.size()))); _i++, _k++) {
            nodeDepth[_i] = oldDepth[_k];
        }
    }
    nodeDepth[airNode] = 0.0;
    nodeDepth[surfaceNode] = 0.0;
    nodeDepth[topsoilNode] = 0.5 * thickness[1] / 1000.0;
    for (node=topsoilNode ; node!=numNodes + 1 ; node+=1)
    {
        nodeDepth[node + 1] = (Sum(thickness, 1, node - 1, MissingValue) + (0.5 * thickness[node])) / 1000.0;
    }
    oldBulkDensity = bulkDensity;
    bulkDensity = std::move(std::vector<double>(numLayers + 1 + numPhantomNodes, 0.0));
    if (true)
    {
        for (int _i=0, _k=0; _i < (std::min(numLayers + 1 + numPhantomNodes, int(oldBulkDensity.size()))) && _k < (std::min(numLayers + 1 + numPhantomNodes, int(oldBulkDensity.size()))); _i++, _k++) {
            bulkDensity[_i] = oldBulkDensity[_k];
        }
    }for (int _i=1, _k=0; _i < (1 + int(physical_BD.size())) && _k < physical_BD.size(); _i++, _k++) {
    bulkDensity[_i] = physical_BD[_k];
    }
    bulkDensity[numNodes] = bulkDensity[numLayers];
    for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
    {
        bulkDensity[layer] = bulkDensity[numLayers];
    }
    oldSoilWater = soilWater;
    soilWater = std::move(std::vector<double>(numLayers + 1 + numPhantomNodes, 0.0));
    if (true)
    {
        for (int _i=0, _k=0; _i < (std::min(numLayers + 1 + numPhantomNodes, int(oldSoilWater.size()))) && _k < (std::min(numLayers + 1 + numPhantomNodes, int(oldSoilWater.size()))); _i++, _k++) {
            soilWater[_i] = oldSoilWater[_k];
        }
    }
    if (true)
    {
        for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
        {
            soilWater[layer] = Divide(waterBalance_SW[(layer - 1)] * thickness[(layer - 1)], thickness[layer], float(0));
        }
        for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
        {
            soilWater[layer] = soilWater[numLayers];
        }
    }carbon = std::move(std::vector<double>(numLayers + 1 + numPhantomNodes, 0.0));
    for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
    {
        carbon[layer] = organic_Carbon[layer - 1];
    }
    for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
    {
        carbon[layer] = carbon[numLayers];
    }rocks = std::move(std::vector<double>(numLayers + 1 + numPhantomNodes, 0.0));
    for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
    {
        rocks[layer] = physical_Rocks[layer - 1];
    }
    for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
    {
        rocks[layer] = rocks[numLayers];
    }sand = std::move(std::vector<double>(numLayers + 1 + numPhantomNodes, 0.0));
    for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
    {
        sand[layer] = physical_ParticleSizeSand[layer - 1];
    }
    for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
    {
        sand[layer] = sand[numLayers];
    }silt = std::move(std::vector<double>(numLayers + 1 + numPhantomNodes, 0.0));
    for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
    {
        silt[layer] = physical_ParticleSizeSilt[layer - 1];
    }
    for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
    {
        silt[layer] = silt[numLayers];
    }clay = std::move(std::vector<double>(numLayers + 1 + numPhantomNodes, 0.0));
    for (layer=1 ; layer!=numLayers + 1 ; layer+=1)
    {
        clay[layer] = physical_ParticleSizeClay[layer - 1];
    }
    for (layer=numLayers + 1 ; layer!=numLayers + numPhantomNodes + 1 ; layer+=1)
    {
        clay[layer] = clay[numLayers];
    }maxSoilTemp = std::move(std::vector<double>(numLayers + 1 + numPhantomNodes, 0.0));
    minSoilTemp = std::move(std::vector<double>(numLayers + 1 + numPhantomNodes, 0.0));
    aveSoilTemp = std::move(std::vector<double>(numLayers + 1 + numPhantomNodes, 0.0));
    volSpecHeatSoil = std::move(std::vector<double>(numNodes + 1, 0.0));
    soilTemp = std::move(std::vector<double>(numNodes + 1 + 1, 0.0));
    morningSoilTemp = std::move(std::vector<double>(numNodes + 1 + 1, 0.0));
    newTemperature = std::move(std::vector<double>(numNodes + 1 + 1, 0.0));
    thermalConductivity = std::move(std::vector<double>(numNodes + 1, 0.0));
    heatStorage = std::move(std::vector<double>(numNodes + 1, 0.0));
    thermalConductance = std::move(std::vector<double>(numNodes + 1 + 1, 0.0));
    return make_tuple(heatStorage, minSoilTemp, bulkDensity, maxSoilTemp, nodeDepth, newTemperature, soilWater, thermalConductance, thermalConductivity, sand, carbon, thickness, rocks, clay, soilTemp, silt, volSpecHeatSoil, aveSoilTemp, morningSoilTemp, numNodes, numLayers);
}
std::tuple<std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> > SoilTemperature::doThermalConductivityCoeffs(std::vector<double> thermCondPar2, int numLayers, std::vector<double> bulkDensity, int numNodes, std::vector<double> thermCondPar3, std::vector<double> thermCondPar4, std::vector<double> clay, std::vector<double> thermCondPar1)
{
    int layer;
    std::vector<double> oldGC1;
    std::vector<double> oldGC2;
    std::vector<double> oldGC3;
    std::vector<double> oldGC4;
    int element;
    oldGC1 = thermCondPar1;
    thermCondPar1 = std::move(std::vector<double>(numNodes + 1, 0.0));
    if (true)
    {
        for (int _i=0, _k=0; _i < (std::min(numNodes + 1, int(oldGC1.size()))) && _k < (std::min(numNodes + 1, int(oldGC1.size()))); _i++, _k++) {
            thermCondPar1[_i] = oldGC1[_k];
        }
    }
    oldGC2 = thermCondPar2;
    thermCondPar2 = std::move(std::vector<double>(numNodes + 1, 0.0));
    if (true)
    {
        for (int _i=0, _k=0; _i < (std::min(numNodes + 1, int(oldGC2.size()))) && _k < (std::min(numNodes + 1, int(oldGC2.size()))); _i++, _k++) {
            thermCondPar2[_i] = oldGC2[_k];
        }
    }
    oldGC3 = thermCondPar3;
    thermCondPar3 = std::move(std::vector<double>(numNodes + 1, 0.0));
    if (true)
    {
        for (int _i=0, _k=0; _i < (std::min(numNodes + 1, int(oldGC3.size()))) && _k < (std::min(numNodes + 1, int(oldGC3.size()))); _i++, _k++) {
            thermCondPar3[_i] = oldGC3[_k];
        }
    }
    oldGC4 = thermCondPar4;
    thermCondPar4 = std::move(std::vector<double>(numNodes + 1, 0.0));
    if (true)
    {
        for (int _i=0, _k=0; _i < (std::min(numNodes + 1, int(oldGC4.size()))) && _k < (std::min(numNodes + 1, int(oldGC4.size()))); _i++, _k++) {
            thermCondPar4[_i] = oldGC4[_k];
        }
    }
    for (layer=1 ; layer!=numLayers + 1 + 1 ; layer+=1)
    {
        element = layer;
        thermCondPar1[element] = 0.65 - (0.78 * bulkDensity[layer]) + (0.6 * std::pow(bulkDensity[layer], 2));
        thermCondPar2[element] = 1.06 * bulkDensity[layer];
        thermCondPar3[element] = 1.0 + Divide(2.6, std::sqrt(clay[layer]), float(0));
        thermCondPar4[element] = 0.03 + (0.1 * std::pow(bulkDensity[layer], 2));
    }
    return make_tuple(thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1);
}
std::tuple<std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,double> SoilTemperature::readParam(double bareSoilRoughness, std::vector<double> newTemperature, double soilRoughnessHeight, std::vector<double> soilTemp, std::vector<double> thermCondPar2, int numLayers, std::vector<double> bulkDensity, int numNodes, std::vector<double> thermCondPar3, std::vector<double> thermCondPar4, std::vector<double> clay, std::vector<double> thermCondPar1, double weather_Tav, int clock_Today_DayOfYear, int surfaceNode, double weather_Amp, std::vector<double> thickness, double weather_Latitude)
{
    tie(thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1) = doThermalConductivityCoeffs(thermCondPar2, numLayers, bulkDensity, numNodes, thermCondPar3, thermCondPar4, clay, thermCondPar1);
    soilTemp = calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude);
    for (int _i=0, _k=0; _i < (0 + int(soilTemp.size())) && _k < soilTemp.size(); _i++, _k++) {
    newTemperature[_i] = soilTemp[_k];
    }
    soilRoughnessHeight = bareSoilRoughness;
    return make_tuple(newTemperature, soilTemp, thermCondPar2, thermCondPar3, thermCondPar4, thermCondPar1, soilRoughnessHeight);
}
std::tuple<std::vector<double> ,double,double> SoilTemperature::getOtherVariables(int numLayers, int numNodes, std::vector<double> soilWater, double instrumentHeight, double soilRoughnessHeight, std::vector<double> waterBalance_SW, double microClimate_CanopyHeight, double canopyHeight)
{
    for (int _i=1, _k=0; _i < (1 + int(waterBalance_SW.size())) && _k < waterBalance_SW.size(); _i++, _k++) {
    soilWater[_i] = waterBalance_SW[_k];
    }
    soilWater[numNodes] = soilWater[numLayers];
    canopyHeight = std::max(microClimate_CanopyHeight, soilRoughnessHeight) / 1000.0;
    instrumentHeight = std::max(instrumentHeight, canopyHeight + 0.5);
    return make_tuple(soilWater, instrumentHeight, canopyHeight);
}
double SoilTemperature::volumetricFractionOrganicMatter(int layer, std::vector<double> carbon, std::vector<double> bulkDensity, double pom)
{
    return carbon[layer] / 100.0 * 2.5 * bulkDensity[layer] / pom;
}
double SoilTemperature::volumetricFractionRocks(int layer, std::vector<double> rocks)
{
    return rocks[layer] / 100.0;
}
double SoilTemperature::volumetricFractionIce(int layer)
{
    return 0.0;
}
double SoilTemperature::volumetricFractionWater(int layer, std::vector<double> soilWater, std::vector<double> carbon, std::vector<double> bulkDensity, double pom)
{
    return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom)) * soilWater[layer];
}
double SoilTemperature::volumetricFractionClay(int layer, std::vector<double> bulkDensity, double ps, std::vector<double> clay, std::vector<double> carbon, double pom, std::vector<double> rocks)
{
    return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * clay[layer] / 100.0 * bulkDensity[layer] / ps;
}
double SoilTemperature::volumetricFractionSilt(int layer, std::vector<double> bulkDensity, std::vector<double> silt, double ps, std::vector<double> carbon, double pom, std::vector<double> rocks)
{
    return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * silt[layer] / 100.0 * bulkDensity[layer] / ps;
}
double SoilTemperature::volumetricFractionSand(int layer, std::vector<double> bulkDensity, std::vector<double> sand, double ps, std::vector<double> carbon, double pom, std::vector<double> rocks)
{
    return (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * sand[layer] / 100.0 * bulkDensity[layer] / ps;
}
double SoilTemperature::kelvinT(double celciusT)
{
    double celciusToKelvin;
    celciusToKelvin = 273.18;
    return celciusT + celciusToKelvin;
}
double SoilTemperature::Divide(double value1, double value2, double errVal)
{
    if (value2 != float(0))
    {
        return value1 / value2;
    }
    return errVal;
}
double SoilTemperature::Sum(std::vector<double> values, int startIndex, int endIndex, double MissingValue)
{
    double value;
    double result;
    int index;
    result = 0.0;
    index = -1;
    for(const auto& value_cyml : values)
    {
        value = value_cyml;
        index = index + 1;
        if (index >= startIndex && value != MissingValue)
        {
            result = result + value;
        }
        if (index == endIndex)
        {
            break;
        }
    }
    return result;
}
double SoilTemperature::volumetricSpecificHeat(std::string name, int layer)
{
    double specificHeatRocks;
    double specificHeatOM;
    double specificHeatSand;
    double specificHeatSilt;
    double specificHeatClay;
    double specificHeatWater;
    double specificHeatIce;
    double specificHeatAir;
    double result;
    specificHeatRocks = 7.7;
    specificHeatOM = 0.25;
    specificHeatSand = 7.7;
    specificHeatSilt = 2.74;
    specificHeatClay = 2.92;
    specificHeatWater = 0.57;
    specificHeatIce = 2.18;
    specificHeatAir = 0.025;
    result = 0.0;
    if (name == "Rocks")
    {
        result = specificHeatRocks;
    }
    else if ( name == "OrganicMatter")
    {
        result = specificHeatOM;
    }
    else if ( name == "Sand")
    {
        result = specificHeatSand;
    }
    else if ( name == "Silt")
    {
        result = specificHeatSilt;
    }
    else if ( name == "Clay")
    {
        result = specificHeatClay;
    }
    else if ( name == "Water")
    {
        result = specificHeatWater;
    }
    else if ( name == "Ice")
    {
        result = specificHeatIce;
    }
    else if ( name == "Air")
    {
        result = specificHeatAir;
    }
    return result;
}
double SoilTemperature::volumetricFractionAir(int layer, std::vector<double> rocks, std::vector<double> carbon, std::vector<double> bulkDensity, double pom, std::vector<double> sand, double ps, std::vector<double> silt, std::vector<double> clay, std::vector<double> soilWater)
{
    return 1.0 - volumetricFractionRocks(layer, rocks) - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks) - volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks) - volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks) - volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) - volumetricFractionIce(layer);
}
double SoilTemperature::airDensity(double temperature, double AirPressure)
{
    double MWair;
    double RGAS;
    double HPA2PA;
    MWair = 0.02897;
    RGAS = 8.3143;
    HPA2PA = 100.0;
    return Divide(MWair * AirPressure * HPA2PA, kelvinT(temperature) * RGAS, 0.0);
}
double SoilTemperature::longWaveRadn(double emissivity, double tDegC, double stefanBoltzmannConstant)
{
    return stefanBoltzmannConstant * emissivity * std::pow(kelvinT(tDegC), 4);
}
std::vector<double>  SoilTemperature::mapLayer2Node(std::vector<double> layerArray, std::vector<double> nodeArray, std::vector<double> nodeDepth, int numNodes, std::vector<double> thickness, int surfaceNode, double MissingValue)
{
    int node;
    int layer;
    double depthLayerAbove;
    double d1;
    double d2;
    double dSum;
    for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
    {
        layer = node - 1;
        depthLayerAbove = layer >= 1 ? Sum(thickness, 1, layer, MissingValue) : 0.0;
        d1 = depthLayerAbove - (nodeDepth[node] * 1000.0);
        d2 = nodeDepth[(node + 1)] * 1000.0 - depthLayerAbove;
        dSum = d1 + d2;
        nodeArray[node] = Divide(layerArray[layer] * d1, dSum, float(0)) + Divide(layerArray[(layer + 1)] * d2, dSum, float(0));
    }
    return nodeArray;
}
double SoilTemperature::ThermalConductance(std::string name, int layer, std::vector<double> rocks, std::vector<double> bulkDensity, std::vector<double> sand, double ps, std::vector<double> carbon, double pom, std::vector<double> silt, std::vector<double> clay)
{
    double thermalConductanceRocks;
    double thermalConductanceOM;
    double thermalConductanceSand;
    double thermalConductanceSilt;
    double thermalConductanceClay;
    double thermalConductanceWater;
    double thermalConductanceIce;
    double thermalConductanceAir;
    double result;
    thermalConductanceRocks = 0.182;
    thermalConductanceOM = 2.50;
    thermalConductanceSand = 0.182;
    thermalConductanceSilt = 2.39;
    thermalConductanceClay = 1.39;
    thermalConductanceWater = 4.18;
    thermalConductanceIce = 1.73;
    thermalConductanceAir = 0.0012;
    result = 0.0;
    if (name == "Rocks")
    {
        result = thermalConductanceRocks;
    }
    else if ( name == "OrganicMatter")
    {
        result = thermalConductanceOM;
    }
    else if ( name == "Sand")
    {
        result = thermalConductanceSand;
    }
    else if ( name == "Silt")
    {
        result = thermalConductanceSilt;
    }
    else if ( name == "Clay")
    {
        result = thermalConductanceClay;
    }
    else if ( name == "Water")
    {
        result = thermalConductanceWater;
    }
    else if ( name == "Ice")
    {
        result = thermalConductanceIce;
    }
    else if ( name == "Air")
    {
        result = thermalConductanceAir;
    }
    else if ( name == "Minerals")
    {
        result = std::pow(thermalConductanceRocks, volumetricFractionRocks(layer, rocks)) * std::pow(thermalConductanceSand, volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + std::pow(thermalConductanceSilt, volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + std::pow(thermalConductanceClay, volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks));
    }
    result = volumetricSpecificHeat(name, layer);
    return result;
}
double SoilTemperature::shapeFactor(std::string name, int layer, std::vector<double> soilWater, std::vector<double> carbon, std::vector<double> bulkDensity, double pom, std::vector<double> rocks, std::vector<double> sand, double ps, std::vector<double> silt, std::vector<double> clay)
{
    double shapeFactorRocks;
    double shapeFactorOM;
    double shapeFactorSand;
    double shapeFactorSilt;
    double shapeFactorClay;
    double shapeFactorWater;
    double result;
    shapeFactorRocks = 0.182;
    shapeFactorOM = 0.5;
    shapeFactorSand = 0.182;
    shapeFactorSilt = 0.125;
    shapeFactorClay = 0.007755;
    shapeFactorWater = 1.0;
    result = 0.0;
    if (name == "Rocks")
    {
        result = shapeFactorRocks;
    }
    else if ( name == "OrganicMatter")
    {
        result = shapeFactorOM;
    }
    else if ( name == "Sand")
    {
        result = shapeFactorSand;
    }
    else if ( name == "Silt")
    {
        result = shapeFactorSilt;
    }
    else if ( name == "Clay")
    {
        result = shapeFactorClay;
    }
    else if ( name == "Water")
    {
        result = shapeFactorWater;
    }
    else if ( name == "Ice")
    {
        result = 0.333 - (0.333 * volumetricFractionIce(layer) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)));
        return result;
    }
    else if ( name == "Air")
    {
        result = 0.333 - (0.333 * volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)));
        return result;
    }
    else if ( name == "Minerals")
    {
        result = shapeFactorRocks * volumetricFractionRocks(layer, rocks) + (shapeFactorSand * volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + (shapeFactorSilt * volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + (shapeFactorClay * volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks));
    }
    result = volumetricSpecificHeat(name, layer);
    return result;
}
std::tuple<std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,double> SoilTemperature::doUpdate(int numInterationsPerDay, double timeOfDaySecs, double boundaryLayerConductance, std::vector<double> minSoilTemp, int airNode, std::vector<double> soilTemp, std::vector<double> newTemperature, int numNodes, int surfaceNode, double internalTimeStep, std::vector<double> maxSoilTemp, std::vector<double> aveSoilTemp, std::vector<double> thermalConductivity)
{
    int node;
    for (int _i=0, _k=0; _i < (0 + int(newTemperature.size())) && _k < newTemperature.size(); _i++, _k++) {
    soilTemp[_i] = newTemperature[_k];
    }
    if (timeOfDaySecs < (internalTimeStep * 1.2))
    {
        for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
        {
            minSoilTemp[node] = soilTemp[node];
            maxSoilTemp[node] = soilTemp[node];
        }
    }
    for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
    {
        if (soilTemp[node] < minSoilTemp[node])
        {
            minSoilTemp[node] = soilTemp[node];
        }
        else if ( soilTemp[node] > maxSoilTemp[node])
        {
            maxSoilTemp[node] = soilTemp[node];
        }
        aveSoilTemp[node] = aveSoilTemp[node] + Divide(soilTemp[node], float(numInterationsPerDay), float(0));
    }
    boundaryLayerConductance = boundaryLayerConductance + Divide(thermalConductivity[airNode], float(numInterationsPerDay), float(0));
    return make_tuple(minSoilTemp, soilTemp, maxSoilTemp, aveSoilTemp, boundaryLayerConductance);
}
std::tuple<std::vector<double> ,std::vector<double> ,std::vector<double> > SoilTemperature::doThomas(std::vector<double> newTemps, double netRadiation, std::vector<double> heatStorage, double waterBalance_Eos, int numNodes, double timestep, std::string netRadiationSource, double latentHeatOfVapourisation, std::vector<double> nodeDepth, double waterBalance_Es, int airNode, std::vector<double> soilTemp, int surfaceNode, double internalTimeStep, std::vector<double> thermalConductance, std::vector<double> thermalConductivity, double nu, std::vector<double> volSpecHeatSoil)
{
    int node;
    std::vector<double> a(numNodes + 1 + 1);
    std::vector<double> b(numNodes + 1);
    std::vector<double> c(numNodes + 1);
    std::vector<double> d(numNodes + 1);
    double volumeOfSoilAtNode;
    double elementLength;
    double g;
    double sensibleHeatFlux;
    double radnNet;
    double latentHeatFlux;
    double soilSurfaceHeatFlux;
    thermalConductance[airNode] = thermalConductivity[airNode];
    for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
    {
        volumeOfSoilAtNode = 0.5 * (nodeDepth[node + 1] - nodeDepth[node - 1]);
        heatStorage[node] = Divide(volSpecHeatSoil[node] * volumeOfSoilAtNode, internalTimeStep, float(0));
        elementLength = nodeDepth[node + 1] - nodeDepth[node];
        thermalConductance[node] = Divide(thermalConductivity[node], elementLength, float(0));
    }
    g = 1 - nu;
    for (node=surfaceNode ; node!=numNodes + 1 ; node+=1)
    {
        c[node] = -nu * thermalConductance[node];
        a[node + 1] = c[node];
        b[node] = nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node];
        d[node] = g * thermalConductance[(node - 1)] * soilTemp[(node - 1)] + ((heatStorage[node] - (g * (thermalConductance[node] + thermalConductance[node - 1]))) * soilTemp[node]) + (g * thermalConductance[node] * soilTemp[(node + 1)]);
    }
    a[surfaceNode] = 0.0;
    sensibleHeatFlux = nu * thermalConductance[airNode] * newTemps[airNode];
    radnNet = 0.0;
    if (netRadiationSource == "calc")
    {
        radnNet = Divide(netRadiation * 1000000.0, internalTimeStep, float(0));
    }
    else if ( netRadiationSource == "eos")
    {
        radnNet = Divide(waterBalance_Eos * latentHeatOfVapourisation, timestep, float(0));
    }
    latentHeatFlux = Divide(waterBalance_Es * latentHeatOfVapourisation, timestep, float(0));
    soilSurfaceHeatFlux = sensibleHeatFlux + radnNet - latentHeatFlux;
    d[surfaceNode] = d[surfaceNode] + soilSurfaceHeatFlux;
    d[numNodes] = d[numNodes] + (nu * thermalConductance[numNodes] * newTemps[(numNodes + 1)]);
    for (node=surfaceNode ; node!=numNodes - 1 + 1 ; node+=1)
    {
        c[node] = Divide(c[node], b[node], float(0));
        d[node] = Divide(d[node], b[node], float(0));
        b[node + 1] = b[node + 1] - (a[(node + 1)] * c[node]);
        d[node + 1] = d[node + 1] - (a[(node + 1)] * d[node]);
    }
    newTemps[numNodes] = Divide(d[numNodes], b[numNodes], float(0));
    for (node=numNodes - 1 ; node!=surfaceNode - 1 ; node+=-1)
    {
        newTemps[node] = d[node] - (c[node] * newTemps[(node + 1)]);
    }
    return make_tuple(newTemps, heatStorage, thermalConductance);
}
std::tuple<double,std::vector<double> > SoilTemperature::getBoundaryLayerConductance(std::vector<double> TNew_zb, double weather_AirPressure, double stefanBoltzmannConstant, double waterBalance_Eos, double weather_Wind, double airTemperature, int surfaceNode, double waterBalance_Eo, double instrumentHeight, double canopyHeight)
{
    int iteration;
    double vonKarmanConstant;
    double gravitationalConstant;
    double specificHeatOfAir;
    double surfaceEmissivity;
    double SpecificHeatAir;
    double roughnessFactorMomentum;
    double roughnessFactorHeat;
    double d;
    double surfaceTemperature;
    double diffusePenetrationConstant;
    double radiativeConductance;
    double frictionVelocity;
    double boundaryLayerCond;
    double stabilityParammeter;
    double stabilityCorrectionMomentum;
    double stabilityCorrectionHeat;
    double heatFluxDensity;
    vonKarmanConstant = 0.41;
    gravitationalConstant = 9.8;
    specificHeatOfAir = 1010.0;
    surfaceEmissivity = 0.98;
    SpecificHeatAir = specificHeatOfAir * airDensity(airTemperature, weather_AirPressure);
    roughnessFactorMomentum = 0.13 * canopyHeight;
    roughnessFactorHeat = 0.2 * roughnessFactorMomentum;
    d = 0.77 * canopyHeight;
    surfaceTemperature = TNew_zb[surfaceNode];
    diffusePenetrationConstant = std::max(0.1, waterBalance_Eos) / std::max(0.1, waterBalance_Eo);
    radiativeConductance = 4.0 * stefanBoltzmannConstant * surfaceEmissivity * diffusePenetrationConstant * std::pow(kelvinT(airTemperature), 3);
    frictionVelocity = 0.0;
    boundaryLayerCond = 0.0;
    stabilityParammeter = 0.0;
    stabilityCorrectionMomentum = 0.0;
    stabilityCorrectionHeat = 0.0;
    heatFluxDensity = 0.0;
    for (iteration=1 ; iteration!=3 + 1 ; iteration+=1)
    {
        frictionVelocity = Divide(weather_Wind * vonKarmanConstant, std::log(Divide(instrumentHeight - d + roughnessFactorMomentum, roughnessFactorMomentum, float(0))) + stabilityCorrectionMomentum, float(0));
        boundaryLayerCond = Divide(SpecificHeatAir * vonKarmanConstant * frictionVelocity, std::log(Divide(instrumentHeight - d + roughnessFactorHeat, roughnessFactorHeat, float(0))) + stabilityCorrectionHeat, float(0));
        boundaryLayerCond = boundaryLayerCond + radiativeConductance;
        heatFluxDensity = boundaryLayerCond * (surfaceTemperature - airTemperature);
        stabilityParammeter = Divide(-vonKarmanConstant * instrumentHeight * gravitationalConstant * heatFluxDensity, SpecificHeatAir * kelvinT(airTemperature) * std::pow(frictionVelocity, 3.0), float(0));
        if (stabilityParammeter > 0.0)
        {
            stabilityCorrectionHeat = 4.7 * stabilityParammeter;
            stabilityCorrectionMomentum = stabilityCorrectionHeat;
        }
        else
        {
            stabilityCorrectionHeat = -2.0 * std::log((1.0 + std::sqrt(1.0 - (16.0 * stabilityParammeter))) / 2.0);
            stabilityCorrectionMomentum = 0.6 * stabilityCorrectionHeat;
        }
    }
    return make_tuple(boundaryLayerCond, TNew_zb);
}
double SoilTemperature::interpolateNetRadiation(double solarRadn, double cloudFr, double cva, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, std::vector<double> soilTemp, double airTemperature, int surfaceNode, double internalTimeStep, double stefanBoltzmannConstant)
{
    double surfaceEmissivity;
    double w2MJ;
    double emissivityAtmos;
    double PenetrationConstant;
    double lwRinSoil;
    double lwRoutSoil;
    double lwRnetSoil;
    double swRin;
    double swRout;
    double swRnetSoil;
    surfaceEmissivity = 0.96;
    w2MJ = internalTimeStep / 1000000.0;
    emissivityAtmos = (1 - (0.84 * cloudFr)) * 0.58 * std::pow(cva, 1.0 / 7.0) + (0.84 * cloudFr);
    PenetrationConstant = Divide(std::max(0.1, waterBalance_Eos), std::max(0.1, waterBalance_Eo), float(0));
    lwRinSoil = longWaveRadn(emissivityAtmos, airTemperature, stefanBoltzmannConstant) * PenetrationConstant * w2MJ;
    lwRoutSoil = longWaveRadn(surfaceEmissivity, soilTemp[surfaceNode], stefanBoltzmannConstant) * PenetrationConstant * w2MJ;
    lwRnetSoil = lwRinSoil - lwRoutSoil;
    swRin = solarRadn;
    swRout = waterBalance_Salb * solarRadn;
    swRnetSoil = (swRin - swRout) * PenetrationConstant;
    return swRnetSoil + lwRnetSoil;
}
double SoilTemperature::interpolateTemperature(double timeHours, double minTempYesterday, double maxTempYesterday, double weather_MeanT, double weather_MaxT, double weather_MinT, double defaultTimeOfMaximumTemperature)
{
    double time;
    double maxT_time;
    double minT_time;
    double midnightT;
    double tScale;
    double currentTemperature;
    time = timeHours / 24.0;
    maxT_time = defaultTimeOfMaximumTemperature / 24.0;
    minT_time = maxT_time - 0.5;
    if (time < minT_time)
    {
        midnightT = std::sin((0.0 + 0.25 - maxT_time) * 2.0 * M_PI) * (maxTempYesterday - minTempYesterday) / 2.0 + ((maxTempYesterday + minTempYesterday) / 2.0);
        tScale = (minT_time - time) / minT_time;
        if (tScale > 1.0)
        {
            tScale = 1.0;
        }
        else if ( tScale < float(0))
        {
            tScale = float(0);
        }
        currentTemperature = weather_MinT + (tScale * (midnightT - weather_MinT));
        return currentTemperature;
    }
    else
    {
        currentTemperature = std::sin((time + 0.25 - maxT_time) * 2.0 * M_PI) * (weather_MaxT - weather_MinT) / 2.0 + weather_MeanT;
        return currentTemperature;
    }
}
std::vector<double>  SoilTemperature::doThermalConductivity(std::vector<std::string> soilConstituentNames, int numNodes, std::vector<double> soilWater, std::vector<double> thermalConductivity, std::vector<double> carbon, std::vector<double> bulkDensity, double pom, std::vector<double> rocks, std::vector<double> sand, double ps, std::vector<double> silt, std::vector<double> clay, std::vector<double> nodeDepth, std::vector<double> thickness, int surfaceNode, double MissingValue)
{
    int node;
    std::string constituentName;
    std::vector<double> thermCondLayers(numNodes + 1);
    double numerator;
    double denominator;
    double shapeFactorConstituent;
    double thermalConductanceConstituent;
    double thermalConductanceWater;
    double k;
    for (node=1 ; node!=numNodes + 1 ; node+=1)
    {
        numerator = 0.0;
        denominator = 0.0;
        for(const auto& constituentName_cyml : soilConstituentNames)
        {
            constituentName = constituentName_cyml;
            shapeFactorConstituent = shapeFactor(constituentName, node, soilWater, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay);
            thermalConductanceConstituent = ThermalConductance(constituentName, node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay);
            thermalConductanceWater = ThermalConductance("Water", node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay);
            k = 2.0 / 3.0 * std::pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))), -1) + (1.0 / 3.0 * std::pow((1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1 - (2 * shapeFactorConstituent)))), -1));
            numerator = numerator + (thermalConductanceConstituent * soilWater[node] * k);
            denominator = denominator + (soilWater[node] * k);
        }
        thermCondLayers[node] = numerator / denominator;
    }
    thermalConductivity = mapLayer2Node(thermCondLayers, thermalConductivity, nodeDepth, numNodes, thickness, surfaceNode, MissingValue);
    return thermalConductivity;
}
std::vector<double>  SoilTemperature::doVolumetricSpecificHeat(std::vector<std::string> soilConstituentNames, int numNodes, std::vector<double> volSpecHeatSoil, std::vector<double> soilWater, std::vector<double> nodeDepth, std::vector<double> thickness, int surfaceNode, double MissingValue)
{
    int node;
    std::string constituentName;
    std::vector<double> volspecHeatSoil_(numNodes + 1);
    for (node=1 ; node!=numNodes + 1 ; node+=1)
    {
        volspecHeatSoil_[node] = float(0);
        for(const auto& constituentName_cyml : soilConstituentNames)
        {
            constituentName = constituentName_cyml;
            if (!(std::set<std::string>({"Minerals"}).count(constituentName) > 0))
            {
                volspecHeatSoil_[node] = volspecHeatSoil_[node] + (volumetricSpecificHeat(constituentName, node) * 1000000.0 * soilWater[node]);
            }
        }
    }
    volSpecHeatSoil = mapLayer2Node(volspecHeatSoil_, volSpecHeatSoil, nodeDepth, numNodes, thickness, surfaceNode, MissingValue);
    return volSpecHeatSoil;
}
std::vector<double>  SoilTemperature::Zero(std::vector<double> arr)
{
    int i;
    if (true)
    {
        for (i=0 ; i!=int(arr.size()) ; i+=1)
        {
            arr[i] = float(0);
        }
    }
    return arr;
}
std::tuple<std::vector<double> ,double,double> SoilTemperature::doNetRadiation(std::vector<double> solarRadn, double cloudFr, double cva, int ITERATIONSperDAY, double weather_MinT, int clock_Today_DayOfYear, double weather_Radn, double weather_Latitude)
{
    int timestepNumber;
    double TSTEPS2RAD;
    double solarConstant;
    double solarDeclination;
    double cD;
    std::vector<double> m1(ITERATIONSperDAY + 1);
    double m1Tot;
    double psr;
    double fr;
    TSTEPS2RAD = Divide(2.0 * M_PI, float(ITERATIONSperDAY), float(0));
    solarConstant = 1360.0;
    solarDeclination = 0.3985 * std::sin((4.869 + (clock_Today_DayOfYear * 2.0 * M_PI / 365.25) + (0.03345 * std::sin((6.224 + (clock_Today_DayOfYear * 2.0 * M_PI / 365.25))))));
    cD = std::sqrt(1.0 - (solarDeclination * solarDeclination));
    m1Tot = 0.0;
    for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
    {
        m1[timestepNumber] = (solarDeclination * std::sin(weather_Latitude * M_PI / 180.0) + (cD * std::cos(weather_Latitude * M_PI / 180.0) * std::cos(TSTEPS2RAD * (timestepNumber - (ITERATIONSperDAY / 2.0))))) * 24.0 / ITERATIONSperDAY;
        if (m1[timestepNumber] > 0.0)
        {
            m1Tot = m1Tot + m1[timestepNumber];
        }
        else
        {
            m1[timestepNumber] = 0.0;
        }
    }
    psr = m1Tot * solarConstant * 3600.0 / 1000000.0;
    fr = Divide(std::max(weather_Radn, 0.1), psr, float(0));
    cloudFr = 2.33 - (3.33 * fr);
    cloudFr = std::min(std::max(cloudFr, 0.0), 1.0);
    for (timestepNumber=1 ; timestepNumber!=ITERATIONSperDAY + 1 ; timestepNumber+=1)
    {
        solarRadn[timestepNumber] = std::max(weather_Radn, 0.1) * Divide(m1[timestepNumber], m1Tot, float(0));
    }
    cva = std::exp((31.3716 - (6014.79 / kelvinT(weather_MinT)) - (0.00792495 * kelvinT(weather_MinT)))) / kelvinT(weather_MinT);
    return make_tuple(solarRadn, cloudFr, cva);
}
std::tuple<std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,double,double,double,double,double,double,double> SoilTemperature::doProcess(double timeOfDaySecs, double netRadiation, std::vector<double> minSoilTemp, std::vector<double> maxSoilTemp, int numIterationsForBoundaryLayerConductance, double timestep, double boundaryLayerConductance, double maxTempYesterday, int airNode, std::vector<double> soilTemp, double airTemperature, std::vector<double> newTemperature, double weather_MaxT, double internalTimeStep, std::string boundarLayerConductanceSource, std::vector<double> thermalConductivity, double minTempYesterday, std::vector<double> aveSoilTemp, std::vector<double> morningSoilTemp, double weather_MeanT, double constantBoundaryLayerConductance, double weather_MinT, int clock_Today_DayOfYear, double weather_Radn, double weather_Latitude, std::vector<std::string> soilConstituentNames, int numNodes, std::vector<double> volSpecHeatSoil, std::vector<double> soilWater, std::vector<double> nodeDepth, std::vector<double> thickness, int surfaceNode, double MissingValue, std::vector<double> carbon, std::vector<double> bulkDensity, double pom, std::vector<double> rocks, std::vector<double> sand, double ps, std::vector<double> silt, std::vector<double> clay, double defaultTimeOfMaximumTemperature, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, double stefanBoltzmannConstant, double weather_AirPressure, double weather_Wind, double instrumentHeight, double canopyHeight, std::vector<double> heatStorage, std::string netRadiationSource, double latentHeatOfVapourisation, double waterBalance_Es, std::vector<double> thermalConductance, double nu)
{
    int timeStepIteration;
    int iteration;
    int interactionsPerDay;
    double cva;
    double cloudFr;
    std::vector<double> solarRadn(49);
    interactionsPerDay = 48;
    cva = 0.0;
    cloudFr = 0.0;
    tie(solarRadn, cloudFr, cva) = doNetRadiation(solarRadn, cloudFr, cva, interactionsPerDay, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude);
    minSoilTemp = Zero(minSoilTemp);
    maxSoilTemp = Zero(maxSoilTemp);
    aveSoilTemp = Zero(aveSoilTemp);
    boundaryLayerConductance = 0.0;
    internalTimeStep = std::round(timestep / interactionsPerDay);
    volSpecHeatSoil = doVolumetricSpecificHeat(soilConstituentNames, numNodes, volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue);
    thermalConductivity = doThermalConductivity(soilConstituentNames, numNodes, soilWater, thermalConductivity, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, nodeDepth, thickness, surfaceNode, MissingValue);
    for (timeStepIteration=1 ; timeStepIteration!=interactionsPerDay + 1 ; timeStepIteration+=1)
    {
        timeOfDaySecs = internalTimeStep * float(timeStepIteration);
        if (timestep < (24.0 * 60.0 * 60.0))
        {
            airTemperature = weather_MeanT;
        }
        else
        {
            airTemperature = interpolateTemperature(timeOfDaySecs / 3600.0, minTempYesterday, maxTempYesterday, weather_MeanT, weather_MaxT, weather_MinT, defaultTimeOfMaximumTemperature);
        }
        newTemperature[airNode] = airTemperature;
        netRadiation = interpolateNetRadiation(solarRadn[timeStepIteration], cloudFr, cva, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, soilTemp, airTemperature, surfaceNode, internalTimeStep, stefanBoltzmannConstant);
        if (boundarLayerConductanceSource == "constant")
        {
            thermalConductivity[airNode] = constantBoundaryLayerConductance;
        }
        else if ( boundarLayerConductanceSource == "calc")
        {
            tie(thermalConductivity[airNode], newTemperature) = getBoundaryLayerConductance(newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight);
            for (iteration=1 ; iteration!=numIterationsForBoundaryLayerConductance + 1 ; iteration+=1)
            {
                tie(newTemperature, heatStorage, thermalConductance) = doThomas(newTemperature, netRadiation, heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, thermalConductance, thermalConductivity, nu, volSpecHeatSoil);
                tie(thermalConductivity[airNode], newTemperature) = getBoundaryLayerConductance(newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight);
            }
        }
        tie(newTemperature, heatStorage, thermalConductance) = doThomas(newTemperature, netRadiation, heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, thermalConductance, thermalConductivity, nu, volSpecHeatSoil);
        tie(minSoilTemp, soilTemp, maxSoilTemp, aveSoilTemp, boundaryLayerConductance) = doUpdate(interactionsPerDay, timeOfDaySecs, boundaryLayerConductance, minSoilTemp, airNode, soilTemp, newTemperature, numNodes, surfaceNode, internalTimeStep, maxSoilTemp, aveSoilTemp, thermalConductivity);
        if (std::abs(timeOfDaySecs - (5.0 * 3600.0)) <= (std::min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001))
        {
            for (int _i=0, _k=0; _i < (0 + int(soilTemp.size())) && _k < soilTemp.size(); _i++, _k++) {
            morningSoilTemp[_i] = soilTemp[_k];
            }
        }
    }
    minTempYesterday = weather_MinT;
    maxTempYesterday = weather_MaxT;
    return make_tuple(minSoilTemp, maxSoilTemp, soilTemp, newTemperature, thermalConductivity, aveSoilTemp, morningSoilTemp, volSpecHeatSoil, heatStorage, thermalConductance, timeOfDaySecs, netRadiation, airTemperature, internalTimeStep, minTempYesterday, boundaryLayerConductance, maxTempYesterday);
}
std::vector<double>  SoilTemperature::ToCumThickness(std::vector<double> Thickness)
{
    int Layer;
    std::vector<double> CumThickness(int(Thickness.size()));
    if (int(Thickness.size()) > 0)
    {
        CumThickness[0] = Thickness[0];
        for (Layer=1 ; Layer!=int(Thickness.size()) ; Layer+=1)
        {
            CumThickness[Layer] = Thickness[Layer] + CumThickness[Layer - 1];
        }
    }
    return CumThickness;
}
std::vector<double>  SoilTemperature::calcSoilTemperature(std::vector<double> soilTempIO, double weather_Tav, int clock_Today_DayOfYear, int surfaceNode, int numNodes, double weather_Amp, std::vector<double> thickness, double weather_Latitude)
{
    int nodes;
    std::vector<double> cumulativeDepth;
    double w;
    double dh;
    double zd;
    double offset;
    std::vector<double> soilTemp(numNodes + 1 + 1);
    cumulativeDepth = ToCumThickness(thickness);
    w = 2 * M_PI / (365.25 * 24 * 3600);
    dh = 0.6;
    zd = std::sqrt(2 * dh / w);
    offset = 0.25;
    if (weather_Latitude > 0.0)
    {
        offset = -0.25;
    }
    for (nodes=1 ; nodes!=numNodes + 1 ; nodes+=1)
    {
        soilTemp[nodes] = weather_Tav + (weather_Amp * std::exp(-1 * cumulativeDepth[nodes] / zd) * std::sin(((clock_Today_DayOfYear / 365.0 + offset) * 2.0 * M_PI - (cumulativeDepth[nodes] / zd))));
    }for (int _i=surfaceNode, _k=0; _i < (surfaceNode + numNodes) && _k < (0 + numNodes); _i++, _k++) {
        soilTempIO[_i] = soilTemp[_k];
    }
    return soilTempIO;
}
double SoilTemperature::calcSurfaceTemperature(double weather_MeanT, double weather_MaxT, double waterBalance_Salb, double weather_Radn)
{
    double surfaceT;
    surfaceT = (1.0 - waterBalance_Salb) * (weather_MeanT + ((weather_MaxT - weather_MeanT) * std::sqrt(std::max(weather_Radn, 0.1) * 23.8846 / 800.0))) + (waterBalance_Salb * weather_MeanT);
    return surfaceT;
}
bool SoilTemperature::ValuesInArray(std::vector<double> Values, double MissingValue)
{
    double Value;
    if (true)
    {
        for(const auto& Value_cyml : Values)
        {
            Value = Value_cyml;
            if (Value != MissingValue && !std::isnan(Value))
            {
                return true;
            }
        }
    }
    return false;
}