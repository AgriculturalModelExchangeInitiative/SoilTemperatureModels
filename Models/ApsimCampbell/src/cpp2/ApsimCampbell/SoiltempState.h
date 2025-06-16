#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace ApsimCampbell {
struct SoiltempState
{
    double netRadiation{0};
    std::vector<double> aveSoilWater;
    std::vector<double> bulkDensity;
    double internalTimeStep{0};
    std::vector<double> thermalConductance;
    std::vector<double> thickness;
    bool doInitialisationStuff{false};
    double maxTempYesterday{0};
    double timeOfDaySecs{0};
    int numNodes{0};
    std::vector<double> soilWater;
    std::vector<double> clay;
    std::vector<double> soilTemp;
    std::vector<double> silt;
    double instrumentHeight{0};
    std::vector<double> sand;
    int numLayers{0};
    std::vector<double> volSpecHeatSoil;
    double instrumHeight{0};
    double canopyHeight{0};
    std::vector<double> heatStorage;
    std::vector<double> minSoilTemp;
    std::vector<double> maxSoilTemp;
    std::vector<double> newTemperature;
    double airTemperature{0};
    std::vector<double> thermalConductivity;
    double minTempYesterday{0};
    std::vector<double> carbon;
    std::vector<double> rocks;
    std::vector<double> InitialValues;
    double boundaryLayerConductance{0};
    std::vector<double> aveSoilTemp;
    std::vector<double> morningSoilTemp;
};
}