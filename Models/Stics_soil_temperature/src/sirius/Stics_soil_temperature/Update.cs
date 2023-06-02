
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
using SiriusQualitysoil_temp.DomainClass;
namespace SiriusQualitysoil_temp.Strategies
{
    public class update : IStrategySiriusQualitysoil_temp
    {
        public update()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitysoil_temp.DomainClass.soil_tempState);
            pd1.PropertyName = "canopy_temp_avg";
            pd1.PropertyType = (SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.canopy_temp_avg).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.canopy_temp_avg);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitysoil_temp.DomainClass.soil_tempState);
            pd2.PropertyName = "temp_profile";
            pd2.PropertyType = (SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile);
            _inputs0_0.Add(pd2);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitysoil_temp.DomainClass.soil_tempState);
            pd3.PropertyName = "prev_temp_profile";
            pd3.PropertyType = (SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile);
            _outputs0_0.Add(pd3);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitysoil_temp.DomainClass.soil_tempExogenous);
            pd4.PropertyName = "prev_canopy_temp";
            pd4.PropertyType = (SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.prev_canopy_temp).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.prev_canopy_temp);
            _outputs0_0.Add(pd4);
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
            return new List<Type>() {  typeof(SiriusQualitysoil_temp.DomainClass.soil_tempState),  typeof(SiriusQualitysoil_temp.DomainClass.soil_tempState), typeof(SiriusQualitysoil_temp.DomainClass.soil_tempRate), typeof(SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary), typeof(SiriusQualitysoil_temp.DomainClass.soil_tempExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.


        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {
        }

        public string TestPostConditions(SiriusQualitysoil_temp.DomainClass.soil_tempState s,SiriusQualitysoil_temp.DomainClass.soil_tempState s1,SiriusQualitysoil_temp.DomainClass.soil_tempRate r,SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary a,SiriusQualitysoil_temp.DomainClass.soil_tempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile.CurrentValue=s.prev_temp_profile;
                SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.prev_canopy_temp.CurrentValue=ex.prev_canopy_temp;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.prev_canopy_temp);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.prev_canopy_temp.ValueType)){prc.AddCondition(r4);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.soil_temp, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitysoil_temp.DomainClass.soil_tempState s,SiriusQualitysoil_temp.DomainClass.soil_tempState s1,SiriusQualitysoil_temp.DomainClass.soil_tempRate r,SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary a,SiriusQualitysoil_temp.DomainClass.soil_tempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.canopy_temp_avg.CurrentValue=s.canopy_temp_avg;
                SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile.CurrentValue=s.temp_profile;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.canopy_temp_avg);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.canopy_temp_avg.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile.ValueType)){prc.AddCondition(r2);}
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.soil_temp, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitysoil_temp.DomainClass.soil_tempState s,SiriusQualitysoil_temp.DomainClass.soil_tempState s1,SiriusQualitysoil_temp.DomainClass.soil_tempRate r,SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary a,SiriusQualitysoil_temp.DomainClass.soil_tempExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitysoil_temp, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualitysoil_temp.DomainClass.soil_tempState s, SiriusQualitysoil_temp.DomainClass.soil_tempState s1, SiriusQualitysoil_temp.DomainClass.soil_tempRate r, SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary a, SiriusQualitysoil_temp.DomainClass.soil_tempExogenous ex)
        {
            double canopy_temp_avg = s.canopy_temp_avg;
            double[] temp_profile = s.temp_profile;
            double[] prev_temp_profile =  new double [1];
            double prev_canopy_temp;
            prev_canopy_temp = canopy_temp_avg;
            prev_temp_profile = new List<double>(temp_profile);
            s.prev_temp_profile= prev_temp_profile;
            ex.prev_canopy_temp= prev_canopy_temp;
        }

    }
}