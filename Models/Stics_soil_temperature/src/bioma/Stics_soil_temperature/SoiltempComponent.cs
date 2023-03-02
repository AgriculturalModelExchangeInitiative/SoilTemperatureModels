
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
    public class SoiltempComponent : IStrategySoiltemp
    {
        public SoiltempComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd1.PropertyName = "max_temp";
            pd1.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.max_temp).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.max_temp);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd2.PropertyName = "min_temp";
            pd2.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_temp).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_temp);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempAuxiliary);
            pd3.PropertyName = "therm_diff";
            pd3.PropertyType = (Soiltemp.DomainClass.SoiltempAuxiliaryVarInfo.therm_diff).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempAuxiliaryVarInfo.therm_diff);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempAuxiliary);
            pd4.PropertyName = "temp_wave_freq";
            pd4.PropertyType = (Soiltemp.DomainClass.SoiltempAuxiliaryVarInfo.temp_wave_freq).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempAuxiliaryVarInfo.temp_wave_freq);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd5.PropertyName = "prev_temp_profile";
            pd5.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.prev_temp_profile).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.prev_temp_profile);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd6.PropertyName = "prev_canopy_temp";
            pd6.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.prev_canopy_temp).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.prev_canopy_temp);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempExogenous);
            pd7.PropertyName = "min_air_temp";
            pd7.PropertyType = (Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_air_temp).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_air_temp);
            _inputs0_0.Add(pd7);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd8.PropertyName = "temp_amp";
            pd8.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.temp_amp).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.temp_amp);
            _outputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd9.PropertyName = "therm_amp";
            pd9.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.therm_amp).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.therm_amp);
            _outputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(Soiltemp.DomainClass.SoiltempState);
            pd10.PropertyName = "temp_profile";
            pd10.PropertyType = (Soiltemp.DomainClass.SoiltempStateVarInfo.temp_profile).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(Soiltemp.DomainClass.SoiltempStateVarInfo.temp_profile);
            _outputs0_0.Add(pd10);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(Soiltemp.Strategies.temp_amp).FullName);
            lAssStrat0_0.Add(typeof(Soiltemp.Strategies.therm_amp).FullName);
            lAssStrat0_0.Add(typeof(Soiltemp.Strategies.temp_profile).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
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
            return new List<Type>() {  typeof(Soiltemp.DomainClass.SoiltempState), typeof(Soiltemp.DomainClass.SoiltempState), typeof(Soiltemp.DomainClass.SoiltempRate), typeof(Soiltemp.DomainClass.SoiltempAuxiliary), typeof(Soiltemp.DomainClass.SoiltempExogenous)};
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _temp_amp.SetParametersDefaultValue();
            _therm_amp.SetParametersDefaultValue();
            _temp_profile.SetParametersDefaultValue();
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
                Soiltemp.DomainClass.SoiltempStateVarInfo.therm_amp.CurrentValue=s.therm_amp;
                Soiltemp.DomainClass.SoiltempStateVarInfo.temp_profile.CurrentValue=s.temp_profile;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r8 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.temp_amp);
                if(r8.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.temp_amp.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.therm_amp);
                if(r9.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.therm_amp.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.temp_profile);
                if(r10.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.temp_profile.ValueType)){prc.AddCondition(r10);}

                string ret = "";
                ret += _temp_amp.TestPostConditions(s, s1, r, a, ex, " strategy Soiltemp.Strategies.Soiltemp");
                ret += _therm_amp.TestPostConditions(s, s1, r, a, ex, " strategy Soiltemp.Strategies.Soiltemp");
                ret += _temp_profile.TestPostConditions(s, s1, r, a, ex, " strategy Soiltemp.Strategies.Soiltemp");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .Soiltemp, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.max_temp.CurrentValue=ex.max_temp;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_temp.CurrentValue=ex.min_temp;
                Soiltemp.DomainClass.SoiltempAuxiliaryVarInfo.therm_diff.CurrentValue=a.therm_diff;
                Soiltemp.DomainClass.SoiltempAuxiliaryVarInfo.temp_wave_freq.CurrentValue=a.temp_wave_freq;
                Soiltemp.DomainClass.SoiltempStateVarInfo.prev_temp_profile.CurrentValue=s.prev_temp_profile;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.prev_canopy_temp.CurrentValue=ex.prev_canopy_temp;
                Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_air_temp.CurrentValue=ex.min_air_temp;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.max_temp);
                if(r1.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.max_temp.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_temp);
                if(r2.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_temp.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempAuxiliaryVarInfo.therm_diff);
                if(r3.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempAuxiliaryVarInfo.therm_diff.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempAuxiliaryVarInfo.temp_wave_freq);
                if(r4.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempAuxiliaryVarInfo.temp_wave_freq.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempStateVarInfo.prev_temp_profile);
                if(r5.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempStateVarInfo.prev_temp_profile.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.prev_canopy_temp);
                if(r6.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.prev_canopy_temp.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_air_temp);
                if(r7.ApplicableVarInfoValueTypes.Contains( Soiltemp.DomainClass.SoiltempExogenousVarInfo.min_air_temp.ValueType)){prc.AddCondition(r7);}

                string ret = "";
                ret += _temp_amp.TestPreConditions(s, s1, r, a, ex, " strategy Soiltemp.Strategies.Soiltemp");
                ret += _therm_amp.TestPreConditions(s, s1, r, a, ex, " strategy Soiltemp.Strategies.Soiltemp");
                ret += _temp_profile.TestPreConditions(s, s1, r, a, ex, " strategy Soiltemp.Strategies.Soiltemp");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .Soiltemp, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
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

        private void CalculateModel(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        Temp_amp _Temp_amp = new Temp_amp();
        Therm_amp _Therm_amp = new Therm_amp();
        Temp_profile _Temp_profile = new Temp_profile();

        private void EstimateOfAssociatedClasses(Soiltemp.DomainClass.SoiltempState s,Soiltemp.DomainClass.SoiltempState s1,Soiltemp.DomainClass.SoiltempRate r,Soiltemp.DomainClass.SoiltempAuxiliary a,Soiltemp.DomainClass.SoiltempExogenous ex)
        {
            _temp_amp.Estimate(s,s1, r, a, ex);
            _therm_amp.Estimate(s,s1, r, a, ex);
            _temp_profile.Estimate(s,s1, r, a, ex);
        }

        public SoiltempComponent(SoiltempComponent toCopy): this() // copy constructor 
        {
        }
    }
}