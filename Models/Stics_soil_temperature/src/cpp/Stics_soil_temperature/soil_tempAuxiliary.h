#ifndef _soil_tempAuxiliary_
#define _soil_tempAuxiliary_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class soil_tempAuxiliary
{
    private:
        double temp_wave_freq ;
        double therm_diff ;
    public:
        soil_tempAuxiliary();
        double gettemp_wave_freq();
        void settemp_wave_freq(double _temp_wave_freq);
        double gettherm_diff();
        void settherm_diff(double _therm_diff);

};
#endif