#ifndef _soil_tempState_
#define _soil_tempState_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class soil_tempState
{
    private:
        double temp_amp ;
        double therm_amp ;
        vector<double> temp_profile ;
        double canopy_temp_avg ;
        vector<double> layer_temp ;
        vector<double> prev_temp_profile ;
    public:
        soil_tempState();
        double gettemp_amp();
        void settemp_amp(double _temp_amp);
        double gettherm_amp();
        void settherm_amp(double _therm_amp);
        vector<double> & gettemp_profile();
        void settemp_profile(const vector<double> &  _temp_profile);
        double getcanopy_temp_avg();
        void setcanopy_temp_avg(double _canopy_temp_avg);
        vector<double> & getlayer_temp();
        void setlayer_temp(const vector<double> &  _layer_temp);
        vector<double> & getprev_temp_profile();
        void setprev_temp_profile(const vector<double> &  _prev_temp_profile);

};
#endif