#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace Monica_SoilTemp {
class SoilTemperatureCompExogenous
{
    private:
        double tmin ;
        double tmax ;
        double globrad ;
        double soilCoverage ;
        double soilSurfaceTemperatureBelowSnow ;
        bool hasSnowCover ;
    public:
        SoilTemperatureCompExogenous();
        double gettmin();
        void settmin(double _tmin);
        double gettmax();
        void settmax(double _tmax);
        double getglobrad();
        void setglobrad(double _globrad);
        double getsoilCoverage();
        void setsoilCoverage(double _soilCoverage);
        double getsoilSurfaceTemperatureBelowSnow();
        void setsoilSurfaceTemperatureBelowSnow(double _soilSurfaceTemperatureBelowSnow);
        bool gethasSnowCover();
        void sethasSnowCover(bool _hasSnowCover);

};
}
