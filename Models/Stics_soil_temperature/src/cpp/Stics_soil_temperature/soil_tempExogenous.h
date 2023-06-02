#ifndef _soil_tempExogenous_
#define _soil_tempExogenous_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class soil_tempExogenous
{
    private:
        double min_temp ;
        double max_temp ;
        double min_air_temp ;
        double min_canopy_temp ;
        double max_canopy_temp ;
        double prev_canopy_temp ;
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
        double getprev_canopy_temp();
        void setprev_canopy_temp(double _prev_canopy_temp);

};
#endif