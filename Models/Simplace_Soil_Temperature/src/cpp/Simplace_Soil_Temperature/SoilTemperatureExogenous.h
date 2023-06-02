#ifndef _SoilTemperatureExogenous_
#define _SoilTemperatureExogenous_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SoilTemperatureExogenous
{
    private:
        double iAirTemperatureMax ;
        double iTempMax ;
        double iAirTemperatureMin ;
        double iTempMin ;
        double iGlobalSolarRadiation ;
        double iRadiation ;
        double iRAIN ;
        double iCropResidues ;
        double iPotentialSoilEvaporation ;
        double iLeafAreaIndex ;
        vector<double> SoilTempArray ;
        vector<double> iSoilTempArray ;
        double iSoilWaterContent ;
        double iSoilSurfaceTemperature ;
    public:
        SoilTemperatureExogenous();
        double getiAirTemperatureMax();
        void setiAirTemperatureMax(double _iAirTemperatureMax);
        double getiTempMax();
        void setiTempMax(double _iTempMax);
        double getiAirTemperatureMin();
        void setiAirTemperatureMin(double _iAirTemperatureMin);
        double getiTempMin();
        void setiTempMin(double _iTempMin);
        double getiGlobalSolarRadiation();
        void setiGlobalSolarRadiation(double _iGlobalSolarRadiation);
        double getiRadiation();
        void setiRadiation(double _iRadiation);
        double getiRAIN();
        void setiRAIN(double _iRAIN);
        double getiCropResidues();
        void setiCropResidues(double _iCropResidues);
        double getiPotentialSoilEvaporation();
        void setiPotentialSoilEvaporation(double _iPotentialSoilEvaporation);
        double getiLeafAreaIndex();
        void setiLeafAreaIndex(double _iLeafAreaIndex);
        vector<double> & getSoilTempArray();
        void setSoilTempArray(const vector<double> &  _SoilTempArray);
        vector<double> & getiSoilTempArray();
        void setiSoilTempArray(const vector<double> &  _iSoilTempArray);
        double getiSoilWaterContent();
        void setiSoilWaterContent(double _iSoilWaterContent);
        double getiSoilSurfaceTemperature();
        void setiSoilSurfaceTemperature(double _iSoilSurfaceTemperature);

};
#endif