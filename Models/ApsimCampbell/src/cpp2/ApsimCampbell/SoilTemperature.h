
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SoiltempState.h"
#include "SoiltempRate.h"
#include "SoiltempAuxiliary.h"
#include "SoiltempExogenous.h"
namespace ApsimCampbell {
class SoilTemperature
{
private:
    double weather_Latitude{0.0};
    std::vector<double> physical_Thickness;
    std::vector<double> physical_BD;
    double ps{0.0};
    std::vector<double> pInitialValues;
    double DepthToConstantTemperature{10000};
    double timestep{24.0 * 60.0 * 60.0};
    double latentHeatOfVapourisation{2465000};
    double stefanBoltzmannConstant{0.0000000567};
    int airNode{0};
    int surfaceNode{1};
    int topsoilNode{2};
    int numPhantomNodes{5};
    double constantBoundaryLayerConductance{20};
    int numIterationsForBoundaryLayerConductance{1};
    double defaultTimeOfMaximumTemperature{14.0};
    double defaultInstrumentHeight{1.2};
    double bareSoilRoughness{57};
    std::vector<double> nodeDepth;
    std::vector<double> thermCondPar1;
    std::vector<double> thermCondPar2;
    std::vector<double> thermCondPar3;
    std::vector<double> thermCondPar4;
    double pom{0.0};
    double soilRoughnessHeight{0};
    double nu{0.6};
    std::string boundarLayerConductanceSource{"calc"};
    std::string netRadiationSource{"calc"};
    double MissingValue{99999};
    std::vector<std::string> soilConstituentNames;
public:
    SoilTemperature();

    void Calculate_Model(SoiltempState &s, SoiltempState &s1, SoiltempRate &r, SoiltempAuxiliary &a, SoiltempExogenous &ex);

    void Init(SoiltempState &s, SoiltempState &s1, SoiltempRate &r, SoiltempAuxiliary &a, SoiltempExogenous &ex);

    double getIniVariables(double instrumentHeight, double instrumHeight, double defaultInstrumentHeight);

    std::tuple<std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,int,int> getProfileVariables(std::vector<double>  heatStorage, std::vector<double>  minSoilTemp, std::vector<double>  bulkDensity, int numNodes, std::vector<double>  physical_BD, std::vector<double>  maxSoilTemp, std::vector<double>  waterBalance_SW, std::vector<double>  organic_Carbon, std::vector<double>  physical_Rocks, std::vector<double>  nodeDepth, int topsoilNode, std::vector<double>  newTemperature, int surfaceNode, std::vector<double>  soilWater, std::vector<double>  thermalConductance, std::vector<double>  thermalConductivity, std::vector<double>  sand, std::vector<double>  carbon, std::vector<double>  thickness, int numPhantomNodes, std::vector<double>  physical_ParticleSizeSand, std::vector<double>  rocks, std::vector<double>  clay, std::vector<double>  physical_ParticleSizeSilt, int airNode, std::vector<double>  physical_ParticleSizeClay, std::vector<double>  soilTemp, int numLayers, std::vector<double>  physical_Thickness, std::vector<double>  silt, std::vector<double>  volSpecHeatSoil, std::vector<double>  aveSoilTemp, std::vector<double>  morningSoilTemp, double DepthToConstantTemperature, double MissingValue);

    std::tuple<std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> > doThermalConductivityCoeffs(std::vector<double>  thermCondPar2, int numLayers, std::vector<double>  bulkDensity, int numNodes, std::vector<double>  thermCondPar3, std::vector<double>  thermCondPar4, std::vector<double>  clay, std::vector<double>  thermCondPar1);

    std::tuple<std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,double> readParam(double bareSoilRoughness, std::vector<double>  newTemperature, double soilRoughnessHeight, std::vector<double>  soilTemp, std::vector<double>  thermCondPar2, int numLayers, std::vector<double>  bulkDensity, int numNodes, std::vector<double>  thermCondPar3, std::vector<double>  thermCondPar4, std::vector<double>  clay, std::vector<double>  thermCondPar1, double weather_Tav, int clock_Today_DayOfYear, int surfaceNode, double weather_Amp, std::vector<double>  thickness, double weather_Latitude);

    std::tuple<std::vector<double> ,double,double> getOtherVariables(int numLayers, int numNodes, std::vector<double>  soilWater, double instrumentHeight, double soilRoughnessHeight, std::vector<double>  waterBalance_SW, double microClimate_CanopyHeight, double canopyHeight);

    double volumetricFractionOrganicMatter(int layer, std::vector<double>  carbon, std::vector<double>  bulkDensity, double pom);

    double volumetricFractionRocks(int layer, std::vector<double>  rocks);

    double volumetricFractionIce(int layer);

    double volumetricFractionWater(int layer, std::vector<double>  soilWater, std::vector<double>  carbon, std::vector<double>  bulkDensity, double pom);

    double volumetricFractionClay(int layer, std::vector<double>  bulkDensity, double ps, std::vector<double>  clay, std::vector<double>  carbon, double pom, std::vector<double>  rocks);

    double volumetricFractionSilt(int layer, std::vector<double>  bulkDensity, std::vector<double>  silt, double ps, std::vector<double>  carbon, double pom, std::vector<double>  rocks);

    double volumetricFractionSand(int layer, std::vector<double>  bulkDensity, std::vector<double>  sand, double ps, std::vector<double>  carbon, double pom, std::vector<double>  rocks);

    double kelvinT(double celciusT);

    double Divide(double value1, double value2, double errVal);

    double Sum(std::vector<double>  values, int startIndex, int endIndex, double MissingValue);

    double volumetricSpecificHeat(std::string name, int layer);

    double volumetricFractionAir(int layer, std::vector<double>  rocks, std::vector<double>  carbon, std::vector<double>  bulkDensity, double pom, std::vector<double>  sand, double ps, std::vector<double>  silt, std::vector<double>  clay, std::vector<double>  soilWater);

    double airDensity(double temperature, double AirPressure);

    double longWaveRadn(double emissivity, double tDegC, double stefanBoltzmannConstant);

    std::vector<double>  mapLayer2Node(std::vector<double>  layerArray, std::vector<double>  nodeArray, std::vector<double>  nodeDepth, int numNodes, std::vector<double>  thickness, int surfaceNode, double MissingValue);

    double ThermalConductance(std::string name, int layer, std::vector<double>  rocks, std::vector<double>  bulkDensity, std::vector<double>  sand, double ps, std::vector<double>  carbon, double pom, std::vector<double>  silt, std::vector<double>  clay);

    double shapeFactor(std::string name, int layer, std::vector<double>  soilWater, std::vector<double>  carbon, std::vector<double>  bulkDensity, double pom, std::vector<double>  rocks, std::vector<double>  sand, double ps, std::vector<double>  silt, std::vector<double>  clay);

    std::tuple<std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,double> doUpdate(int numInterationsPerDay, double timeOfDaySecs, double boundaryLayerConductance, std::vector<double>  minSoilTemp, int airNode, std::vector<double>  soilTemp, std::vector<double>  newTemperature, int numNodes, int surfaceNode, double internalTimeStep, std::vector<double>  maxSoilTemp, std::vector<double>  aveSoilTemp, std::vector<double>  thermalConductivity);

    std::tuple<std::vector<double> ,std::vector<double> ,std::vector<double> > doThomas(std::vector<double>  newTemps, double netRadiation, std::vector<double>  heatStorage, double waterBalance_Eos, int numNodes, double timestep, std::string netRadiationSource, double latentHeatOfVapourisation, std::vector<double>  nodeDepth, double waterBalance_Es, int airNode, std::vector<double>  soilTemp, int surfaceNode, double internalTimeStep, std::vector<double>  thermalConductance, std::vector<double>  thermalConductivity, double nu, std::vector<double>  volSpecHeatSoil);

    std::tuple<double,std::vector<double> > getBoundaryLayerConductance(std::vector<double>  TNew_zb, double weather_AirPressure, double stefanBoltzmannConstant, double waterBalance_Eos, double weather_Wind, double airTemperature, int surfaceNode, double waterBalance_Eo, double instrumentHeight, double canopyHeight);

    double interpolateNetRadiation(double solarRadn, double cloudFr, double cva, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, std::vector<double>  soilTemp, double airTemperature, int surfaceNode, double internalTimeStep, double stefanBoltzmannConstant);

    double interpolateTemperature(double timeHours, double minTempYesterday, double maxTempYesterday, double weather_MeanT, double weather_MaxT, double weather_MinT, double defaultTimeOfMaximumTemperature);

    std::vector<double>  doThermalConductivity(std::vector<std::string>  soilConstituentNames, int numNodes, std::vector<double>  soilWater, std::vector<double>  thermalConductivity, std::vector<double>  carbon, std::vector<double>  bulkDensity, double pom, std::vector<double>  rocks, std::vector<double>  sand, double ps, std::vector<double>  silt, std::vector<double>  clay, std::vector<double>  nodeDepth, std::vector<double>  thickness, int surfaceNode, double MissingValue);

    std::vector<double>  doVolumetricSpecificHeat(std::vector<std::string>  soilConstituentNames, int numNodes, std::vector<double>  volSpecHeatSoil, std::vector<double>  soilWater, std::vector<double>  nodeDepth, std::vector<double>  thickness, int surfaceNode, double MissingValue);

    std::vector<double>  Zero(std::vector<double>  arr);

    std::tuple<std::vector<double> ,double,double> doNetRadiation(std::vector<double>  solarRadn, double cloudFr, double cva, int ITERATIONSperDAY, double weather_MinT, int clock_Today_DayOfYear, double weather_Radn, double weather_Latitude);

    std::tuple<std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,std::vector<double> ,double,double,double,double,double,double,double> doProcess(double timeOfDaySecs, double netRadiation, std::vector<double>  minSoilTemp, std::vector<double>  maxSoilTemp, int numIterationsForBoundaryLayerConductance, double timestep, double boundaryLayerConductance, double maxTempYesterday, int airNode, std::vector<double>  soilTemp, double airTemperature, std::vector<double>  newTemperature, double weather_MaxT, double internalTimeStep, std::string boundarLayerConductanceSource, std::vector<double>  thermalConductivity, double minTempYesterday, std::vector<double>  aveSoilTemp, std::vector<double>  morningSoilTemp, double weather_MeanT, double constantBoundaryLayerConductance, double weather_MinT, int clock_Today_DayOfYear, double weather_Radn, double weather_Latitude, std::vector<std::string>  soilConstituentNames, int numNodes, std::vector<double>  volSpecHeatSoil, std::vector<double>  soilWater, std::vector<double>  nodeDepth, std::vector<double>  thickness, int surfaceNode, double MissingValue, std::vector<double>  carbon, std::vector<double>  bulkDensity, double pom, std::vector<double>  rocks, std::vector<double>  sand, double ps, std::vector<double>  silt, std::vector<double>  clay, double defaultTimeOfMaximumTemperature, double waterBalance_Eo, double waterBalance_Eos, double waterBalance_Salb, double stefanBoltzmannConstant, double weather_AirPressure, double weather_Wind, double instrumentHeight, double canopyHeight, std::vector<double>  heatStorage, std::string netRadiationSource, double latentHeatOfVapourisation, double waterBalance_Es, std::vector<double>  thermalConductance, double nu);

    std::vector<double>  ToCumThickness(std::vector<double>  Thickness);

    std::vector<double>  calcSoilTemperature(std::vector<double>  soilTempIO, double weather_Tav, int clock_Today_DayOfYear, int surfaceNode, int numNodes, double weather_Amp, std::vector<double>  thickness, double weather_Latitude);

    double calcSurfaceTemperature(double weather_MeanT, double weather_MaxT, double waterBalance_Salb, double weather_Radn);

    bool ValuesInArray(std::vector<double>  Values, double MissingValue);

    double getweather_Latitude();
    void setweather_Latitude(double _weather_Latitude);

    std::vector<double> & getphysical_Thickness();
    void setphysical_Thickness(const std::vector<double> &  _physical_Thickness);

    std::vector<double> & getphysical_BD();
    void setphysical_BD(const std::vector<double> &  _physical_BD);

    double getps();
    void setps(double _ps);

    std::vector<double> & getpInitialValues();
    void setpInitialValues(const std::vector<double> &  _pInitialValues);

    double getDepthToConstantTemperature();
    void setDepthToConstantTemperature(double _DepthToConstantTemperature);

    double gettimestep();
    void settimestep(double _timestep);

    double getlatentHeatOfVapourisation();
    void setlatentHeatOfVapourisation(double _latentHeatOfVapourisation);

    double getstefanBoltzmannConstant();
    void setstefanBoltzmannConstant(double _stefanBoltzmannConstant);

    int getairNode();
    void setairNode(int _airNode);

    int getsurfaceNode();
    void setsurfaceNode(int _surfaceNode);

    int gettopsoilNode();
    void settopsoilNode(int _topsoilNode);

    int getnumPhantomNodes();
    void setnumPhantomNodes(int _numPhantomNodes);

    double getconstantBoundaryLayerConductance();
    void setconstantBoundaryLayerConductance(double _constantBoundaryLayerConductance);

    int getnumIterationsForBoundaryLayerConductance();
    void setnumIterationsForBoundaryLayerConductance(int _numIterationsForBoundaryLayerConductance);

    double getdefaultTimeOfMaximumTemperature();
    void setdefaultTimeOfMaximumTemperature(double _defaultTimeOfMaximumTemperature);

    double getdefaultInstrumentHeight();
    void setdefaultInstrumentHeight(double _defaultInstrumentHeight);

    double getbareSoilRoughness();
    void setbareSoilRoughness(double _bareSoilRoughness);

    std::vector<double> & getnodeDepth();
    void setnodeDepth(const std::vector<double> &  _nodeDepth);

    std::vector<double> & getthermCondPar1();
    void setthermCondPar1(const std::vector<double> &  _thermCondPar1);

    std::vector<double> & getthermCondPar2();
    void setthermCondPar2(const std::vector<double> &  _thermCondPar2);

    std::vector<double> & getthermCondPar3();
    void setthermCondPar3(const std::vector<double> &  _thermCondPar3);

    std::vector<double> & getthermCondPar4();
    void setthermCondPar4(const std::vector<double> &  _thermCondPar4);

    double getpom();
    void setpom(double _pom);

    double getsoilRoughnessHeight();
    void setsoilRoughnessHeight(double _soilRoughnessHeight);

    double getnu();
    void setnu(double _nu);

    std::string getboundarLayerConductanceSource();
    void setboundarLayerConductanceSource(std::string _boundarLayerConductanceSource);

    std::string getnetRadiationSource();
    void setnetRadiationSource(std::string _netRadiationSource);

    double getMissingValue();
    void setMissingValue(double _MissingValue);

    std::vector<std::string> & getsoilConstituentNames();
    void setsoilConstituentNames(const std::vector<std::string> &  _soilConstituentNames);
};
}