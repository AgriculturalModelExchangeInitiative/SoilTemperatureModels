#include "SnowCoverCalculator.h"
#include "STMPsimCalculator.h"
using namespace std;

class SoilTemperatureComponent
{
    private:
        double cCarbonContent ;
        vector<double> cSoilLayerDepth ;
        double cFirstDayMeanTemp ;
        double cAverageGroundTemperature ;
        double cAverageBulkDensity ;
        double cDampingDepth ;
    public:
        SoilTemperatureComponent();
        SoilTemperatureComponent(SoilTemperatureComponent& copy);
        void  Calculate_Model(SoilTemperatureState& s, SoilTemperatureState& s1, SoilTemperatureRate& r, SoilTemperatureAuxiliary& a, SoilTemperatureExogenous& ex);
        void  Init(SoilTemperatureState& s,SoilTemperatureState& s1, SoilTemperatureRate& r, SoilTemperatureAuxiliary& a, SoilTemperatureExogenous& ex);
        double getcCarbonContent();
        void setcCarbonContent(double _cCarbonContent);
        vector<double> & getcSoilLayerDepth();
        void setcSoilLayerDepth(const vector<double> &  _cSoilLayerDepth);
        double getcFirstDayMeanTemp();
        void setcFirstDayMeanTemp(double _cFirstDayMeanTemp);
        double getcAverageGroundTemperature();
        void setcAverageGroundTemperature(double _cAverageGroundTemperature);
        double getcAverageBulkDensity();
        void setcAverageBulkDensity(double _cAverageBulkDensity);
        double getcDampingDepth();
        void setcDampingDepth(double _cDampingDepth);

        SnowCoverCalculator _SnowCoverCalculator;
        STMPsimCalculator _STMPsimCalculator;

};