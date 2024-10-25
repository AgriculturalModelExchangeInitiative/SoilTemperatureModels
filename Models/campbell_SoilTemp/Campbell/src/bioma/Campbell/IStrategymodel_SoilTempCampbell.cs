using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace Model_SoilTempCampbell.DomainClass
{
    public interface IStrategyModel_SoilTempCampbell : IStrategy
    {
        void Estimate( Model_SoilTempCampbellState s, Model_SoilTempCampbellState s1, Model_SoilTempCampbellRate r, Model_SoilTempCampbellAuxiliary a, Model_SoilTempCampbellExogenous ex);

        string TestPreConditions( Model_SoilTempCampbellState s, Model_SoilTempCampbellState s1, Model_SoilTempCampbellRate r, Model_SoilTempCampbellAuxiliary a, Model_SoilTempCampbellExogenous ex, string callID);

        string TestPostConditions( Model_SoilTempCampbellState s, Model_SoilTempCampbellState s1, Model_SoilTempCampbellRate r, Model_SoilTempCampbellAuxiliary a, Model_SoilTempCampbellExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}