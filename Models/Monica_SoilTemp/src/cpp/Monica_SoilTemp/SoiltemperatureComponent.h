#include "Soiltemperature.h"
#include "Nosnowsoilsurfacetemperature.h"
#include "Withsnowsoilsurfacetemperature.h"
using namespace std;

class SoiltemperatureComponent
{
    private:
        double dampingFactor;
        double timeStep;
        double soilMoistureConst;
        double baseTemp;
        double initialSurfaceTemp;
        double densityAir;
        double specificHeatCapacityAir;
        double densityHumus;
        double specificHeatCapacityHumus;
        double densityWater;
        double specificHeatCapacityWater;
        double quartzRawDensity;
        double specificHeatCapacityQuartz;
        double nTau;
        double soilAlbedo;
        int noOfTempLayers;
        int noOfSoilLayers;
        vector<double> layerThickness;
        vector<double> soilBulkDensity;
        vector<double> saturation;
        vector<double> soilOrganicMatter;
    public:
        SoiltemperatureComponent();
        SoiltemperatureComponent(const SoiltemperatureComponent& copy);
        void  Calculate_Model(SoiltemperatureState& s, SoiltemperatureState& s1, SoiltemperatureRate& r, SoiltemperatureAuxiliary& a, SoiltemperatureExogenous& ex);
        void  Init(SoiltemperatureState& s,SoiltemperatureState& s1, SoiltemperatureRate& r, SoiltemperatureAuxiliary& a, SoiltemperatureExogenous& ex);
        double getdampingFactor();
        void setdampingFactor(double _dampingFactor);
        double gettimeStep();
        void settimeStep(double _timeStep);
        double getsoilMoistureConst();
        void setsoilMoistureConst(double _soilMoistureConst);
        double getbaseTemp();
        void setbaseTemp(double _baseTemp);
        double getinitialSurfaceTemp();
        void setinitialSurfaceTemp(double _initialSurfaceTemp);
        double getdensityAir();
        void setdensityAir(double _densityAir);
        double getspecificHeatCapacityAir();
        void setspecificHeatCapacityAir(double _specificHeatCapacityAir);
        double getdensityHumus();
        void setdensityHumus(double _densityHumus);
        double getspecificHeatCapacityHumus();
        void setspecificHeatCapacityHumus(double _specificHeatCapacityHumus);
        double getdensityWater();
        void setdensityWater(double _densityWater);
        double getspecificHeatCapacityWater();
        void setspecificHeatCapacityWater(double _specificHeatCapacityWater);
        double getquartzRawDensity();
        void setquartzRawDensity(double _quartzRawDensity);
        double getspecificHeatCapacityQuartz();
        void setspecificHeatCapacityQuartz(double _specificHeatCapacityQuartz);
        double getnTau();
        void setnTau(double _nTau);
        double getsoilAlbedo();
        void setsoilAlbedo(double _soilAlbedo);
        int getnoOfTempLayers();
        void setnoOfTempLayers(int _noOfTempLayers);
        int getnoOfSoilLayers();
        void setnoOfSoilLayers(int _noOfSoilLayers);
        vector<double>& getlayerThickness();
        void setlayerThickness(vector<double> _layerThickness);
        vector<double>& getsoilBulkDensity();
        void setsoilBulkDensity(vector<double> _soilBulkDensity);
        vector<double>& getsaturation();
        void setsaturation(vector<double> _saturation);
        vector<double>& getsoilOrganicMatter();
        void setsoilOrganicMatter(vector<double> _soilOrganicMatter);

        Soiltemperature _Soiltemperature;
        Nosnowsoilsurfacetemperature _Nosnowsoilsurfacetemperature;
        Withsnowsoilsurfacetemperature _Withsnowsoilsurfacetemperature;

};