using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace SiriusQualitysoil_temp.DomainClass
{
    public interface IStrategySiriusQualitysoil_temp : IStrategy
    {
        void Estimate( soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a, soil_tempExogenous ex);

        string TestPreConditions( soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a, soil_tempExogenous ex, string callID);

        string TestPostConditions( soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a, soil_tempExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}