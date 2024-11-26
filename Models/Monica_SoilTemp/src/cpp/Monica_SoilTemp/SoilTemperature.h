
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SoilTemperatureCompState.h"
#include "SoilTemperatureCompRate.h"
#include "SoilTemperatureCompAuxiliary.h"
#include "SoilTemperatureCompExogenous.h"
namespace Monica_SoilTemp {
class SoilTemperature
{
    private:
        int noOfSoilLayers ;
        int noOfTempLayers ;
        int noOfTempLayersPlus1 ;
        double timeStep ;
        std::vector<double> soilMoistureConst ;
        double baseTemp ;
        double initialSurfaceTemp ;
        double densityAir ;
        double specificHeatCapacityAir ;
        double densityHumus ;
        double specificHeatCapacityHumus ;
        double densityWater ;
        double specificHeatCapacityWater ;
        double quartzRawDensity ;
        double specificHeatCapacityQuartz ;
        double nTau ;
        std::vector<double> layerThickness ;
        std::vector<double> soilBulkDensity ;
        std::vector<double> saturation ;
        std::vector<double> soilOrganicMatter ;
    public:
        SoilTemperature();
        void Calculate_Model(SoilTemperatureCompState &s, SoilTemperatureCompState &s1, SoilTemperatureCompRate &r, SoilTemperatureCompAuxiliary &a, SoilTemperatureCompExogenous &ex);
        void Init(SoilTemperatureCompState &s, SoilTemperatureCompState &s1, SoilTemperatureCompRate &r, SoilTemperatureCompAuxiliary &a, SoilTemperatureCompExogenous &ex);
        int getnoOfSoilLayers();
        void setnoOfSoilLayers(int _noOfSoilLayers);
        int getnoOfTempLayers();
        void setnoOfTempLayers(int _noOfTempLayers);
        int getnoOfTempLayersPlus1();
        void setnoOfTempLayersPlus1(int _noOfTempLayersPlus1);
        double gettimeStep();
        void settimeStep(double _timeStep);
        std::vector<double> & getsoilMoistureConst();
        void setsoilMoistureConst(const std::vector<double> &  _soilMoistureConst);
        double getbaseTemp();
        void setbaseTemp(double _baseTemp);
        double getinitialSurfaceTemp();
        void setinitialSurfaceTemp(double _initialSurfaceTemp);
        double getdensityAir();
        void setdensityAir(double _densityAir);
        double getspecificHeatCapacityAir();
        void setspecificHeatCapacityAir(double _specificHeatCapacityAir);
        double getdensityHumus();
        void setdensityHumus(double _densityHumus);
        double getspecificHeatCapacityHumus();
        void setspecificHeatCapacityHumus(double _specificHeatCapacityHumus);
        double getdensityWater();
        void setdensityWater(double _densityWater);
        double getspecificHeatCapacityWater();
        void setspecificHeatCapacityWater(double _specificHeatCapacityWater);
        double getquartzRawDensity();
        void setquartzRawDensity(double _quartzRawDensity);
        double getspecificHeatCapacityQuartz();
        void setspecificHeatCapacityQuartz(double _specificHeatCapacityQuartz);
        double getnTau();
        void setnTau(double _nTau);
        std::vector<double> & getlayerThickness();
        void setlayerThickness(const std::vector<double> &  _layerThickness);
        std::vector<double> & getsoilBulkDensity();
        void setsoilBulkDensity(const std::vector<double> &  _soilBulkDensity);
        std::vector<double> & getsaturation();
        void setsaturation(const std::vector<double> &  _saturation);
        std::vector<double> & getsoilOrganicMatter();
        void setsoilOrganicMatter(const std::vector<double> &  _soilOrganicMatter);

};
}
