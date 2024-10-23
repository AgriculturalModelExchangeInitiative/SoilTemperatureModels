
#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
#include "SoilTemperatureState.h"
#include "SoilTemperatureRate.h"
#include "SoilTemperatureAuxiliary.h"
#include "SoilTemperatureExogenous.h"
namespace SQ_Soil_Temperature {
class CalculateSoilTemperature
{
    private:
        double lambda_ ;
    public:
        CalculateSoilTemperature();
        void Calculate_Model(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a, SoilTemperatureExogenous &ex);
        void Init(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a, SoilTemperatureExogenous &ex);
        double SoilTempB(double weatherMinTemp, double deepTemperature);
        double SoilTempA(double weatherMaxTemp, double weatherMeanTemp, double soilHeatFlux, double lambda_);
        double SoilMinimumTemperature(double weatherMaxTemp, double weatherMeanTemp, double weatherMinTemp, double soilHeatFlux, double lambda_, double deepTemperature);
        double SoilMaximumTemperature(double weatherMaxTemp, double weatherMeanTemp, double weatherMinTemp, double soilHeatFlux, double lambda_, double deepTemperature);
        double UpdateTemperature(double minSoilTemp, double maxSoilTemp, double Temperature);
        double getlambda_();
        void setlambda_(double _lambda_);

};
}
