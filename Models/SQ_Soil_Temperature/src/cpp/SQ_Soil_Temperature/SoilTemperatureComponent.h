#include "CalculateSoilTemperature.h"
#include "CalculateHourlySoilTemperature.h"

namespace SQ_Soil_Temperature {
class SoilTemperatureComponent
{
    private:
        double lambda_ ;
        double b ;
        double c ;
        double a ;
    public:
        SoilTemperatureComponent();
        SoilTemperatureComponent(SoilTemperatureComponent& copy);
        void Calculate_Model(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a, SoilTemperatureExogenous &ex);
        void Init(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a, SoilTemperatureExogenous &ex);
        double getlambda_();
        void setlambda_(double _lambda_);
        double getb();
        void setb(double _b);
        double getc();
        void setc(double _c);
        double geta();
        void seta(double _a);

        CalculateSoilTemperature _CalculateSoilTemperature;
        CalculateHourlySoilTemperature _CalculateHourlySoilTemperature;

};
}
