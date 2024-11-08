#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace Simplace_Soil_Temperature {
class SoilTemperatureAuxiliary
{
    private:
        std::vector<double> SoilTempArray ;
        std::vector<double> iSoilTempArray ;
        double SnowIsolationIndex ;
        double iSoilSurfaceTemperature ;
    public:
        SoilTemperatureAuxiliary();
        std::vector<double> & getSoilTempArray();
        void setSoilTempArray(const std::vector<double> &  _SoilTempArray);
        std::vector<double> & getiSoilTempArray();
        void setiSoilTempArray(const std::vector<double> &  _iSoilTempArray);
        double getSnowIsolationIndex();
        void setSnowIsolationIndex(double _SnowIsolationIndex);
        double getiSoilSurfaceTemperature();
        void setiSoilSurfaceTemperature(double _iSoilSurfaceTemperature);

};
}
