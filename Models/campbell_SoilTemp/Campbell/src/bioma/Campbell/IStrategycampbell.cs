using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace campbell.DomainClass
{
    public interface IStrategycampbell : IStrategy
    {
        void Estimate( campbellState s, campbellState s1, campbellRate r, campbellAuxiliary a, campbellExogenous ex);

        string TestPreConditions( campbellState s, campbellState s1, campbellRate r, campbellAuxiliary a, campbellExogenous ex, string callID);

        string TestPostConditions( campbellState s, campbellState s1, campbellRate r, campbellAuxiliary a, campbellExogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}