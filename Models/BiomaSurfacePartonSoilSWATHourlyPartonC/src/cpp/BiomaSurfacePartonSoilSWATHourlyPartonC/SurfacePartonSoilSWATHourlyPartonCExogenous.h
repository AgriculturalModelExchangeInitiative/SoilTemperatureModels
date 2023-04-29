#ifndef _SurfacePartonSoilSWATHourlyPartonCExogenous_
#define _SurfacePartonSoilSWATHourlyPartonCExogenous_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SurfacePartonSoilSWATHourlyPartonCExogenous
{
    private:
        double GlobalSolarRadiation ;
        double DayLength ;
        double AirTemperatureMinimum ;
        double AirTemperatureMaximum ;
        double AirTemperatureAnnualAverage ;
        double HourOfSunrise ;
        double HourOfSunset ;
    public:
        SurfacePartonSoilSWATHourlyPartonCExogenous();
        double getGlobalSolarRadiation();
        void setGlobalSolarRadiation(double _GlobalSolarRadiation);
        double getDayLength();
        void setDayLength(double _DayLength);
        double getAirTemperatureMinimum();
        void setAirTemperatureMinimum(double _AirTemperatureMinimum);
        double getAirTemperatureMaximum();
        void setAirTemperatureMaximum(double _AirTemperatureMaximum);
        double getAirTemperatureAnnualAverage();
        void setAirTemperatureAnnualAverage(double _AirTemperatureAnnualAverage);
        double getHourOfSunrise();
        void setHourOfSunrise(double _HourOfSunrise);
        double getHourOfSunset();
        void setHourOfSunset(double _HourOfSunset);

};
#endif