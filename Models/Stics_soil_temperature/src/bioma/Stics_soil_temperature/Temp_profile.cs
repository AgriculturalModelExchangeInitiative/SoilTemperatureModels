
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
    public class temp_profile : IStrategySoiltemp
    {
        public temp_profile()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd1.PropertyName = "temp_amp";
            pd1.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.temp_amp).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.temp_amp);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd2.PropertyName = "therm_amp";
            pd2.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.therm_amp).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.therm_amp);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd3.PropertyName = "prev_temp_profile";
            pd3.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.prev_temp_profile).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.prev_temp_profile);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd4.PropertyName = "prev_canopy_temp";
            pd4.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.prev_canopy_temp).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.prev_canopy_temp);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd5.PropertyName = "min_air_temp";
            pd5.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_air_temp).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_air_temp);
            _inputs0_0.Add(pd5);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd6.PropertyName = "temp_profile";
            pd6.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.temp_profile).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.temp_profile);
            _outputs0_0.Add(pd6);
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
                Soiltemp.DomainClass.SoiltempStateVarInfo.temp_profile.CurrentValue=s.temp_profile;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r6 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.temp_profile);
                if(r6.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.temp_profile.ValueType)){prc.AddCondition(r6);}
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
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.temp_amp.CurrentValue=ex.temp_amp;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.therm_amp.CurrentValue=ex.therm_amp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.prev_temp_profile.CurrentValue=s.prev_temp_profile;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.prev_canopy_temp.CurrentValue=ex.prev_canopy_temp;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_air_temp.CurrentValue=ex.min_air_temp;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.temp_amp);
                if(r1.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.temp_amp.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.therm_amp);
                if(r2.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.therm_amp.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.prev_temp_profile);
                if(r3.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.prev_temp_profile.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.prev_canopy_temp);
                if(r4.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.prev_canopy_temp.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_air_temp);
                if(r5.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_air_temp.ValueType)){prc.AddCondition(r5);}
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
            double temp_amp = ex.temp_amp;
            double therm_amp = ex.therm_amp;
            double[] prev_temp_profile = s.prev_temp_profile;
            double prev_canopy_temp = ex.prev_canopy_temp;
            double min_air_temp = ex.min_air_temp;
            double[] temp_profile ;
            int z;
            int n;
            double[] vexp ;
            n = prev_temp_profile.Length;
            temp_profile = new double[ n];
            vexp = new double[ n];
            for (z=1 ; z!=n + 1 ; z+=1)
            {
                vexp[z - 1] = Math.Exp(-(z * therm_amp));
            }
            for (z=1 ; z!=n + 1 ; z+=1)
            {
                temp_profile[z - 1] = prev_temp_profile[z - 1] - (vexp[(z - 1)] * (prev_canopy_temp - min_air_temp)) + (0.10d * (prev_canopy_temp - prev_temp_profile[z - 1])) + (temp_amp * vexp[(z - 1)] / 2);
            }
            prev_temp_profile = temp_profile;
            s.temp_profile= temp_profile;
        }

    }
}