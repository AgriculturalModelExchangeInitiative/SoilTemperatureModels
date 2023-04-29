#ifndef _SurfaceSWATSoilSWATCExogenous_
#define _SurfaceSWATSoilSWATCExogenous_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SurfaceSWATSoilSWATCExogenous
{
    private:
        double GlobalSolarRadiation ;
        double AirTemperatureMaximum ;
        double AirTemperatureMinimum ;
        double Albedo ;
        double WaterEquivalentOfSnowPack ;
        double AirTemperatureAnnualAverage ;
    public:
        SurfaceSWATSoilSWATCExogenous();
        double getGlobalSolarRadiation();
        void setGlobalSolarRadiation(double _GlobalSolarRadiation);
        double getAirTemperatureMaximum();
        void setAirTemperatureMaximum(double _AirTemperatureMaximum);
        double getAirTemperatureMinimum();
        void setAirTemperatureMinimum(double _AirTemperatureMinimum);
        double getAlbedo();
        void setAlbedo(double _Albedo);
        double getWaterEquivalentOfSnowPack();
        void setWaterEquivalentOfSnowPack(double _WaterEquivalentOfSnowPack);
        double getAirTemperatureAnnualAverage();
        void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage);

};
#endif