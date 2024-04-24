#include "SoilTemperatureComponent.h"
using namespace SQ_Soil_Temperature;
SoilTemperatureComponent::SoilTemperatureComponent()
{
       
}


double SoilTemperatureComponent::getlambda_(){ return this->lambda_; }
double SoilTemperatureComponent::getb(){ return this->b; }
double SoilTemperatureComponent::getc(){ return this->c; }
double SoilTemperatureComponent::geta(){ return this->a; }

void SoilTemperatureComponent::setlambda_(double _lambda_)
{
    _CalculateSoilTemperature.setlambda_(_lambda_);
}
void SoilTemperatureComponent::setb(double _b)
{
    _CalculateHourlySoilTemperature.setb(_b);
}
void SoilTemperatureComponent::setc(double _c)
{
    _CalculateHourlySoilTemperature.setc(_c);
}
void SoilTemperatureComponent::seta(double _a)
{
    _CalculateHourlySoilTemperature.seta(_a);
}
void SoilTemperatureComponent::Calculate_Model(SoilTemperatureState &s, SoilTemperatureState &s1, SoilTemperatureRate &r, SoilTemperatureAuxiliary &a, SoilTemperatureExogenous &ex)
{
    _CalculateSoilTemperature.Calculate_Model(s, s1, r, a, ex);
    _CalculateHourlySoilTemperature.Calculate_Model(s, s1, r, a, ex);
}
SoilTemperatureComponent::SoilTemperatureComponent(SoilTemperatureComponent& toCopy)
{
    lambda_ = toCopy.getlambda_();
    b = toCopy.getb();
    c = toCopy.getc();
    a = toCopy.geta();
}