
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
using soil_temp.DomainClass;
namespace soil_temp.Strategies
{
    public class temp_amp : IStrategysoil_temp
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
            pd1.DomainClassType = typeof(soil_temp.DomainClass.soil_tempExogenous);
            pd1.PropertyName = "min_temp";
            pd1.PropertyType = (soil_temp.DomainClass.soil_tempExogenousVarInfo.min_temp).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(soil_temp.DomainClass.soil_tempExogenousVarInfo.min_temp);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(soil_temp.DomainClass.soil_tempExogenous);
            pd2.PropertyName = "max_temp";
            pd2.PropertyType = (soil_temp.DomainClass.soil_tempExogenousVarInfo.max_temp).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(soil_temp.DomainClass.soil_tempExogenousVarInfo.max_temp);
            _inputs0_0.Add(pd2);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(soil_temp.DomainClass.soil_tempState);
            pd3.PropertyName = "temp_amp";
            pd3.PropertyType = (soil_temp.DomainClass.soil_tempStateVarInfo.temp_amp).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(soil_temp.DomainClass.soil_tempStateVarInfo.temp_amp);
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
            return new List<Type>() {  typeof(soil_temp.DomainClass.soil_tempState),  typeof(soil_temp.DomainClass.soil_tempState), typeof(soil_temp.DomainClass.soil_tempRate), typeof(soil_temp.DomainClass.soil_tempAuxiliary), typeof(soil_temp.DomainClass.soil_tempExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.


        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {
        }

        public string TestPostConditions(soil_temp.DomainClass.soil_tempState s,soil_temp.DomainClass.soil_tempState s1,soil_temp.DomainClass.soil_tempRate r,soil_temp.DomainClass.soil_tempAuxiliary a,soil_temp.DomainClass.soil_tempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                soil_temp.DomainClass.soil_tempStateVarInfo.temp_amp.CurrentValue=s.temp_amp;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r3 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempStateVarInfo.temp_amp);
                if(r3.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempStateVarInfo.temp_amp.ValueType)){prc.AddCondition(r3);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".soil_temp, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(soil_temp.DomainClass.soil_tempState s,soil_temp.DomainClass.soil_tempState s1,soil_temp.DomainClass.soil_tempRate r,soil_temp.DomainClass.soil_tempAuxiliary a,soil_temp.DomainClass.soil_tempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                soil_temp.DomainClass.soil_tempExogenousVarInfo.min_temp.CurrentValue=ex.min_temp;
                soil_temp.DomainClass.soil_tempExogenousVarInfo.max_temp.CurrentValue=ex.max_temp;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempExogenousVarInfo.min_temp);
                if(r1.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempExogenousVarInfo.min_temp.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempExogenousVarInfo.max_temp);
                if(r2.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempExogenousVarInfo.max_temp.ValueType)){prc.AddCondition(r2);}
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".soil_temp, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(soil_temp.DomainClass.soil_tempState s,soil_temp.DomainClass.soil_tempState s1,soil_temp.DomainClass.soil_tempRate r,soil_temp.DomainClass.soil_tempAuxiliary a,soil_temp.DomainClass.soil_tempExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component soil_temp, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(soil_temp.DomainClass.soil_tempState s, soil_temp.DomainClass.soil_tempState s1, soil_temp.DomainClass.soil_tempRate r, soil_temp.DomainClass.soil_tempAuxiliary a, soil_temp.DomainClass.soil_tempExogenous ex)
        {
            double min_temp = ex.min_temp;
            double max_temp = ex.max_temp;
            double temp_amp;
            temp_amp = max_temp - min_temp;
            s.temp_amp= temp_amp;
        }

    }
}