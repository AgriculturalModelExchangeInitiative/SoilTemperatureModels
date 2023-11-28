#ifndef _SurfacePartonSoilSWATCExogenous_
#define _SurfacePartonSoilSWATCExogenous_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SurfacePartonSoilSWATCExogenous
{
    private:
        double DayLength ;
        double AboveGroundBiomass ;
        double AirTemperatureMaximum ;
        double GlobalSolarRadiation ;
        double AirTemperatureMinimum ;
    public:
        SurfacePartonSoilSWATCExogenous();
        double getDayLength();
        void setDayLength(double _DayLength);
        double getAboveGroundBiomass();
        void setAboveGroundBiomass(double _AboveGroundBiomass);
        double getAirTemperatureMaximum();
        void setAirTemperatureMaximum(double _AirTemperatureMaximum);
        double getGlobalSolarRadiation();
        void setGlobalSolarRadiation(double _GlobalSolarRadiation);
        double getAirTemperatureMinimum();
        void setAirTemperatureMinimum(double _AirTemperatureMinimum);

};
#endif