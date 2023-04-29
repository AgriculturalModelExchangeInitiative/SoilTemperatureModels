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
        double AirTemperatureMaximum ;
        double AirTemperatureMinimum ;
        double GlobalSolarRadiation ;
        double AirTemperatureAnnualAverage ;
    public:
        SurfacePartonSoilSWATCExogenous();
        double getDayLength();
        void setDayLength(double _DayLength);
        double getAirTemperatureMaximum();
        void setAirTemperatureMaximum(double _AirTemperatureMaximum);
        double getAirTemperatureMinimum();
        void setAirTemperatureMinimum(double _AirTemperatureMinimum);
        double getGlobalSolarRadiation();
        void setGlobalSolarRadiation(double _GlobalSolarRadiation);
        double getAirTemperatureAnnualAverage();
        void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage);

};
#endif