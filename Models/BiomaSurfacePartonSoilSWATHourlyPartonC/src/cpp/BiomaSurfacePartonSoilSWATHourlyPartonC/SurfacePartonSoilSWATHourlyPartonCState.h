#ifndef _SurfacePartonSoilSWATHourlyPartonCState_
#define _SurfacePartonSoilSWATHourlyPartonCState_
#define _USE_MATH_DEFINES
#include <cmath>
#include <iostream>
# include<vector>
# include<string>
using namespace std;
class SurfacePartonSoilSWATHourlyPartonCState
{
    private:
        double AboveGroundBiomass ;
        vector<double> VolumetricWaterContent ;
        vector<double> BulkDensity ;
        vector<double> LayerThickness ;
        double SoilProfileDepth ;
        vector<double> Sand ;
        vector<double> OrganicMatter ;
        vector<double> Clay ;
        vector<double> Silt ;
        double SurfaceSoilTemperature ;
        vector<double> SoilTemperatureByLayers ;
        vector<double> HeatCapacity ;
        vector<double> ThermalConductivity ;
        vector<double> ThermalDiffusivity ;
        vector<double> SoilTemperatureRangeByLayers ;
        vector<double> SoilTemperatureMinimum ;
        vector<double> SoilTemperatureMaximum ;
        vector<double> SoilTemperatureByLayersHourly ;
    public:
        SurfacePartonSoilSWATHourlyPartonCState();
        double getAboveGroundBiomass();
        void setAboveGroundBiomass(double _AboveGroundBiomass);
        vector<double> & getVolumetricWaterContent();
        void setVolumetricWaterContent(vector<double>  _VolumetricWaterContent);
        vector<double> & getBulkDensity();
        void setBulkDensity(vector<double>  _BulkDensity);
        vector<double> & getLayerThickness();
        void setLayerThickness(vector<double>  _LayerThickness);
        double getSoilProfileDepth();
        void setSoilProfileDepth(double _SoilProfileDepth);
        vector<double> & getSand();
        void setSand(vector<double>  _Sand);
        vector<double> & getOrganicMatter();
        void setOrganicMatter(vector<double>  _OrganicMatter);
        vector<double> & getClay();
        void setClay(vector<double>  _Clay);
        vector<double> & getSilt();
        void setSilt(vector<double>  _Silt);
        double getSurfaceSoilTemperature();
        void setSurfaceSoilTemperature(double _SurfaceSoilTemperature);
        vector<double> & getSoilTemperatureByLayers();
        void setSoilTemperatureByLayers(vector<double>  _SoilTemperatureByLayers);
        vector<double> & getHeatCapacity();
        void setHeatCapacity(vector<double>  _HeatCapacity);
        vector<double> & getThermalConductivity();
        void setThermalConductivity(vector<double>  _ThermalConductivity);
        vector<double> & getThermalDiffusivity();
        void setThermalDiffusivity(vector<double>  _ThermalDiffusivity);
        vector<double> & getSoilTemperatureRangeByLayers();
        void setSoilTemperatureRangeByLayers(vector<double>  _SoilTemperatureRangeByLayers);
        vector<double> & getSoilTemperatureMinimum();
        void setSoilTemperatureMinimum(vector<double>  _SoilTemperatureMinimum);
        vector<double> & getSoilTemperatureMaximum();
        void setSoilTemperatureMaximum(vector<double>  _SoilTemperatureMaximum);
        vector<double> & getSoilTemperatureByLayersHourly();
        void setSoilTemperatureByLayersHourly(vector<double>  _SoilTemperatureByLayersHourly);

};
#endif