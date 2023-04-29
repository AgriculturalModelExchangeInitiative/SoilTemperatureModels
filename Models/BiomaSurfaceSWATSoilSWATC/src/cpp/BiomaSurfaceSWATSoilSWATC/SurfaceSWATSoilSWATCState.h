#ifndef _SurfaceSWATSoilSWATCState_
#define _SurfaceSWATSoilSWATCState_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SurfaceSWATSoilSWATCState
{
    private:
        double AboveGroundBiomass ;
        vector<double> BulkDensity ;
        vector<double> LayerThickness ;
        vector<double> VolumetricWaterContent ;
        double SoilProfileDepth ;
        double SurfaceSoilTemperature ;
        vector<double> SoilTemperatureByLayers ;
    public:
        SurfaceSWATSoilSWATCState();
        double getAboveGroundBiomass();
        void setAboveGroundBiomass(double _AboveGroundBiomass);
        vector<double> & getBulkDensity();
        void setBulkDensity(vector<double>  _BulkDensity);
        vector<double> & getLayerThickness();
        void setLayerThickness(vector<double>  _LayerThickness);
        vector<double> & getVolumetricWaterContent();
        void setVolumetricWaterContent(vector<double>  _VolumetricWaterContent);
        double getSoilProfileDepth();
        void setSoilProfileDepth(double _SoilProfileDepth);
        double getSurfaceSoilTemperature();
        void setSurfaceSoilTemperature(double _SurfaceSoilTemperature);
        vector<double> & getSoilTemperatureByLayers();
        void setSoilTemperatureByLayers(vector<double>  _SoilTemperatureByLayers);

};
#endif