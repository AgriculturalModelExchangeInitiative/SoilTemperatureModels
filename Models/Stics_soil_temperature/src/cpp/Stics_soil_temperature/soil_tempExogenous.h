#pragma once
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
#include <vector>
#include <string>
namespace Stics_soil_temperature {
class soil_tempExogenous
{
    private:
        double min_temp ;
        double max_temp ;
        double min_air_temp ;
        double min_canopy_temp ;
        double max_canopy_temp ;
    public:
        soil_tempExogenous();
        double getmin_temp();
        void setmin_temp(double _min_temp);
        double getmax_temp();
        void setmax_temp(double _max_temp);
        double getmin_air_temp();
        void setmin_air_temp(double _min_air_temp);
        double getmin_canopy_temp();
        void setmin_canopy_temp(double _min_canopy_temp);
        double getmax_canopy_temp();
        void setmax_canopy_temp(double _max_canopy_temp);

};
}
