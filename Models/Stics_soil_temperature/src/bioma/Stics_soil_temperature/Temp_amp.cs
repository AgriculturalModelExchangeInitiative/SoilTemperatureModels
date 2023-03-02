
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using System.Reflection;
using VarInfo=CRA.ModelLayer.Core.VarInfo;
using Preconditions=CRA.ModelLayer.Core.Preconditions;
using CRA.AgroManagement;       
using Soiltemp.DomainClass;
namespace Soiltemp.Strategies
{
    public class temp_amp : IStrategySoiltemp
    {
        public temp_amp()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd1.PropertyName = "min_temp";
            pd1.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_temp).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_temp);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd2.PropertyName = "max_temp";
            pd2.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.max_temp).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.max_temp);
            _inputs0_0.Add(pd2);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd3.PropertyName = "temp_amp";
            pd3.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.temp_amp).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.temp_amp);
            _outputs0_0.Add(pd3);
            mo0_0.Outputs=_outputs0_0;
            //Associated strategies
            List<string> lAssStrat0_0 = new List<string>();
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            //Adding the modeling options to the modeling options manager
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();

        }

        public string Description
        {
            get { return "" ;}
        }

        public string URL
        {
            get { return "" ;}
        }

        public string Domain
        {
            get { return "";}
        }

        public string ModelType
        {
            get { return "";}
        }

        public bool IsContext
        {
            get { return false;}
        }

        public IList<int> TimeStep
        {
            get
            {
                IList<int> ts = new List<int>();
                return ts;
            }
        }

        private  PublisherData _pd;
        public PublisherData PublisherData
        {
            get { return _pd;} 
        }

        private  void SetPublisherData()
        {
            _pd = new CRA.ModelLayer.MetadataTypes.PublisherData();
            _pd.Add("Creator", "None");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "INRAE "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(Soiltemp.DomainClass.SoiltempState),  typeof(Soiltemp.DomainClass.SoiltempState), typeof(Soiltemp.DomainClass.SoiltempRate), typeof(Soiltemp.DomainClass.SoiltempAuxiliary), typeof(Soiltemp.DomainClass.SoiltempExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.


        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {
        }

        public string TestPostConditions(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                Soiltemp.DomainClass.SoiltempStateVarInfo.temp_amp.CurrentValue=s.temp_amp;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r3 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.temp_amp);
                if(r3.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.temp_amp.ValueType)){prc.AddCondition(r3);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".Soiltemp, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_temp.CurrentValue=ex.min_temp;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.max_temp.CurrentValue=ex.max_temp;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_temp);
                if(r1.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_temp.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.max_temp);
                if(r2.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.max_temp.ValueType)){prc.AddCondition(r2);}
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".Soiltemp, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component Soiltemp, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(Soiltemp.DomainClass.SoiltempState s, Soiltemp.DomainClass.SoiltempState s1, Soiltemp.DomainClass.SoiltempRate r, Soiltemp.DomainClass.SoiltempAuxiliary a, Soiltemp.DomainClass.SoiltempExogenous ex)
        {
            double min_temp = ex.min_temp;
            double max_temp = ex.max_temp;
            double temp_amp;
            temp_amp = max_temp - min_temp;
            s.temp_amp= temp_amp;
        }

    }
}