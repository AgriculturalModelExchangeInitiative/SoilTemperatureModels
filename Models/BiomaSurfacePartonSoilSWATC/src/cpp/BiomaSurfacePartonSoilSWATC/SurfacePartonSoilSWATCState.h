#ifndef _SurfacePartonSoilSWATCState_
#define _SurfacePartonSoilSWATCState_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SurfacePartonSoilSWATCState
{
    private:
        double AboveGroundBiomass ;
        vector<double> VolumetricWaterContent ;
        vector<double> LayerThickness ;
        vector<double> BulkDensity ;
        double SoilProfileDepth ;
        double SurfaceSoilTemperature ;
        vector<double> SoilTemperatureByLayers ;
    public:
        SurfacePartonSoilSWATCState();
        double getAboveGroundBiomass();
        void setAboveGroundBiomass(double _AboveGroundBiomass);
        vector<double> & getVolumetricWaterContent();
        void setVolumetricWaterContent(vector<double>  _VolumetricWaterContent);
        vector<double> & getLayerThickness();
        void setLayerThickness(vector<double>  _LayerThickness);
        vector<double> & getBulkDensity();
        void setBulkDensity(vector<double>  _BulkDensity);
        double getSoilProfileDepth();
        void setSoilProfileDepth(double _SoilProfileDepth);
        double getSurfaceSoilTemperature();
        void setSurfaceSoilTemperature(double _SurfaceSoilTemperature);
        vector<double> & getSoilTemperatureByLayers();
        void setSoilTemperatureByLayers(vector<double>  _SoilTemperatureByLayers);

};
#endif