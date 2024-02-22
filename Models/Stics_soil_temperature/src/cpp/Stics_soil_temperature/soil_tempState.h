#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include<vector>
#include<string>
namespace Stics_soil_temperature {
class soil_tempState
{
    private:
        std::vector<double> prev_temp_profile ;
        double prev_canopy_temp ;
        double temp_amp ;
        std::vector<double> temp_profile ;
        std::vector<double> layer_temp ;
        double canopy_temp_avg ;
    public:
        soil_tempState();
        std::vector<double>& getprev_temp_profile();
        void setprev_temp_profile(const std::vector<double>&  _prev_temp_profile);
        double getprev_canopy_temp();
        void setprev_canopy_temp(double _prev_canopy_temp);
        double gettemp_amp();
        void settemp_amp(double _temp_amp);
        std::vector<double>& gettemp_profile();
        void settemp_profile(const std::vector<double>&  _temp_profile);
        std::vector<double>& getlayer_temp();
        void setlayer_temp(const std::vector<double>&  _layer_temp);
        double getcanopy_temp_avg();
        void setcanopy_temp_avg(double _canopy_temp_avg);

};
}
