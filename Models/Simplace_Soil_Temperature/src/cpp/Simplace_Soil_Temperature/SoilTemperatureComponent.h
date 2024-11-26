#include "SnowCoverCalculator.h"
#include "STMPsimCalculator.h"

namespace Simplace_Soil_Temperature {
class SoilTemperatureComponent
{
    private:
        double cCarbonContent ;
        double cAlbedo ;
        int cInitialAgeOfSnow ;
        double cInitialSnowWaterContent ;
        double cSnowIsolationFactorA ;
        double cSnowIsolationFactorB ;
        std::vector<double> cSoilLayerDepth ;
        double cFirstDayMeanTemp ;
        double cAverageGroundTemperature ;
        double cAverageBulkDensity ;
        double cDampingDepth ;
    public:
        SoilTemperatureComponent();
        SoilTemperatureComponent(SoilTemperatureComponent& copy);
        void Calculate_Model(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a, SoilTemperatureExogenous &ex);
        void Init(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a, SoilTemperatureExogenous &ex);
        double getcCarbonContent();
        void setcCarbonContent(double _cCarbonContent);
        double getcAlbedo();
        void setcAlbedo(double _cAlbedo);
        int getcInitialAgeOfSnow();
        void setcInitialAgeOfSnow(int _cInitialAgeOfSnow);
        double getcInitialSnowWaterContent();
        void setcInitialSnowWaterContent(double _cInitialSnowWaterContent);
        double getcSnowIsolationFactorA();
        void setcSnowIsolationFactorA(double _cSnowIsolationFactorA);
        double getcSnowIsolationFactorB();
        void setcSnowIsolationFactorB(double _cSnowIsolationFactorB);
        std::vector<double> & getcSoilLayerDepth();
        void setcSoilLayerDepth(const std::vector<double> &  _cSoilLayerDepth);
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
}
