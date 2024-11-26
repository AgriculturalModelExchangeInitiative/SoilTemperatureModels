#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace Simplace_Soil_Temperature {
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
        double iSoilWaterContent ;
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
        double getiSoilWaterContent();
        void setiSoilWaterContent(double _iSoilWaterContent);

};
}
