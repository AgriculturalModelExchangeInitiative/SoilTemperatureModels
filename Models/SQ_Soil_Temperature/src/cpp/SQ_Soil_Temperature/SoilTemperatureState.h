#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace SQ_Soil_Temperature {
class SoilTemperatureState
{
    private:
        double minTSoil ;
        double deepLayerT ;
        double maxTSoil ;
        std::vector<double> hourlySoilT ;
    public:
        SoilTemperatureState();
        double getminTSoil();
        void setminTSoil(double _minTSoil);
        double getdeepLayerT();
        void setdeepLayerT(double _deepLayerT);
        double getmaxTSoil();
        void setmaxTSoil(double _maxTSoil);
        std::vector<double> & gethourlySoilT();
        void sethourlySoilT(const std::vector<double> &  _hourlySoilT);

};
}
