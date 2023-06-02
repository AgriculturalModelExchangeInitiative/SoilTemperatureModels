#ifndef _SoilTemperatureState_
#define _SoilTemperatureState_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SoilTemperatureState
{
    private:
        double Albedo ;
        double SnowWaterContent ;
        double SoilSurfaceTemperature ;
        int AgeOfSnow ;
        vector<double> rSoilTempArrayRate ;
        vector<double> pSoilLayerDepth ;
        vector<double> SoilTempArray ;
    public:
        SoilTemperatureState();
        double getAlbedo();
        void setAlbedo(double _Albedo);
        double getSnowWaterContent();
        void setSnowWaterContent(double _SnowWaterContent);
        double getSoilSurfaceTemperature();
        void setSoilSurfaceTemperature(double _SoilSurfaceTemperature);
        int getAgeOfSnow();
        void setAgeOfSnow(int _AgeOfSnow);
        vector<double> & getrSoilTempArrayRate();
        void setrSoilTempArrayRate(const vector<double> &  _rSoilTempArrayRate);
        vector<double> & getpSoilLayerDepth();
        void setpSoilLayerDepth(const vector<double> &  _pSoilLayerDepth);
        vector<double> & getSoilTempArray();
        void setSoilTempArray(const vector<double> &  _SoilTempArray);

};
#endif