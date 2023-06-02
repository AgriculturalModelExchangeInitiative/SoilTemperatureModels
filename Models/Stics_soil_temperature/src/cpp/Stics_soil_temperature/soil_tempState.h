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
        vector<double> prev_temp_profile ;
        double prev_canopy_temp ;
        double temp_amp ;
        vector<double> temp_profile ;
        vector<double> layer_temp ;
        double canopy_temp_avg ;
    public:
        soil_tempState();
        vector<double> & getprev_temp_profile();
        void setprev_temp_profile(const vector<double> &  _prev_temp_profile);
        double getprev_canopy_temp();
        void setprev_canopy_temp(double _prev_canopy_temp);
        double gettemp_amp();
        void settemp_amp(double _temp_amp);
        vector<double> & gettemp_profile();
        void settemp_profile(const vector<double> &  _temp_profile);
        vector<double> & getlayer_temp();
        void setlayer_temp(const vector<double> &  _layer_temp);
        double getcanopy_temp_avg();
        void setcanopy_temp_avg(double _canopy_temp_avg);

};
#endif