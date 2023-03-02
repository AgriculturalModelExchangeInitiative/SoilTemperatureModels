using System;
using CRA.AgroManagement;
using CRA.ModelLayer.Strategy;
namespace STEMP_.DomainClass
{
    public interface IStrategySTEMP_ : IStrategy
    {
        void Estimate( STEMP_State s, STEMP_State s1, STEMP_Rate r, STEMP_Auxiliary a, STEMP_Exogenous ex);

        string TestPreConditions( STEMP_State s, STEMP_State s1, STEMP_Rate r, STEMP_Auxiliary a, STEMP_Exogenous ex, string callID);

        string TestPostConditions( STEMP_State s, STEMP_State s1, STEMP_Rate r, STEMP_Auxiliary a, STEMP_Exogenous ex, string callID);

        void SetParametersDefaultValue();
    }
}