using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace SiriusQualitymodel_SoilTempCampbell.DomainClass
{
    public interface IStrategySiriusQualitymodel_SoilTempCampbell : IStrategy
    {
        void Estimate( model_SoilTempCampbellState s, model_SoilTempCampbellState s1, model_SoilTempCampbellRate r, model_SoilTempCampbellAuxiliary a, model_SoilTempCampbellExogenous ex);

        string TestPreConditions( model_SoilTempCampbellState s, model_SoilTempCampbellState s1, model_SoilTempCampbellRate r, model_SoilTempCampbellAuxiliary a, model_SoilTempCampbellExogenous ex, string callID);

        string TestPostConditions( model_SoilTempCampbellState s, model_SoilTempCampbellState s1, model_SoilTempCampbellRate r, model_SoilTempCampbellAuxiliary a, model_SoilTempCampbellExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}