
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
    public class soil_tempComponent : IStrategysoil_temp
    {
        public soil_tempComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_temp_profile, "layer_thick");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_layers_temp, "layer_thick");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_temp_profile, "air_temp_day1");
            _parameters0_0.Add(v3);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(soil_temp.DomainClass.soil_tempExogenous);
            pd1.PropertyName = "max_temp";
            pd1.PropertyType = (soil_temp.DomainClass.soil_tempExogenousVarInfo.max_temp).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(soil_temp.DomainClass.soil_tempExogenousVarInfo.max_temp);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(soil_temp.DomainClass.soil_tempExogenous);
            pd2.PropertyName = "min_temp";
            pd2.PropertyType = (soil_temp.DomainClass.soil_tempExogenousVarInfo.min_temp).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(soil_temp.DomainClass.soil_tempExogenousVarInfo.min_temp);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(soil_temp.DomainClass.soil_tempExogenous);
            pd3.PropertyName = "min_air_temp";
            pd3.PropertyType = (soil_temp.DomainClass.soil_tempExogenousVarInfo.min_air_temp).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(soil_temp.DomainClass.soil_tempExogenousVarInfo.min_air_temp);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(soil_temp.DomainClass.soil_tempExogenous);
            pd4.PropertyName = "min_canopy_temp";
            pd4.PropertyType = (soil_temp.DomainClass.soil_tempExogenousVarInfo.min_canopy_temp).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(soil_temp.DomainClass.soil_tempExogenousVarInfo.min_canopy_temp);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(soil_temp.DomainClass.soil_tempExogenous);
            pd5.PropertyName = "max_canopy_temp";
            pd5.PropertyType = (soil_temp.DomainClass.soil_tempExogenousVarInfo.max_canopy_temp).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(soil_temp.DomainClass.soil_tempExogenousVarInfo.max_canopy_temp);
            _inputs0_0.Add(pd5);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(soil_temp.DomainClass.soil_tempState);
            pd6.PropertyName = "temp_amp";
            pd6.PropertyType = (soil_temp.DomainClass.soil_tempStateVarInfo.temp_amp).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(soil_temp.DomainClass.soil_tempStateVarInfo.temp_amp);
            _outputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(soil_temp.DomainClass.soil_tempState);
            pd7.PropertyName = "temp_profile";
            pd7.PropertyType = (soil_temp.DomainClass.soil_tempStateVarInfo.temp_profile).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(soil_temp.DomainClass.soil_tempStateVarInfo.temp_profile);
            _outputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(soil_temp.DomainClass.soil_tempState);
            pd8.PropertyName = "layer_temp";
            pd8.PropertyType = (soil_temp.DomainClass.soil_tempStateVarInfo.layer_temp).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(soil_temp.DomainClass.soil_tempStateVarInfo.layer_temp);
            _outputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(soil_temp.DomainClass.soil_tempState);
            pd9.PropertyName = "canopy_temp_avg";
            pd9.PropertyType = (soil_temp.DomainClass.soil_tempStateVarInfo.canopy_temp_avg).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(soil_temp.DomainClass.soil_tempStateVarInfo.canopy_temp_avg);
            _outputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(soil_temp.DomainClass.soil_tempExogenous);
            pd10.PropertyName = "prev_canopy_temp";
            pd10.PropertyType = (soil_temp.DomainClass.soil_tempExogenousVarInfo.prev_canopy_temp).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(soil_temp.DomainClass.soil_tempExogenousVarInfo.prev_canopy_temp);
            _outputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(soil_temp.DomainClass.soil_tempState);
            pd11.PropertyName = "prev_temp_profile";
            pd11.PropertyType = (soil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(soil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile);
            _outputs0_0.Add(pd11);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(soil_temp.Strategies.temp_amp).FullName);
            lAssStrat0_0.Add(typeof(soil_temp.Strategies.temp_profile).FullName);
            lAssStrat0_0.Add(typeof(soil_temp.Strategies.layers_temp).FullName);
            lAssStrat0_0.Add(typeof(soil_temp.Strategies.canopy_temp_avg).FullName);
            lAssStrat0_0.Add(typeof(soil_temp.Strategies.update).FullName);
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
            return new List<Type>() {  typeof(soil_temp.DomainClass.soil_tempState), typeof(soil_temp.DomainClass.soil_tempState), typeof(soil_temp.DomainClass.soil_tempRate), typeof(soil_temp.DomainClass.soil_tempAuxiliary), typeof(soil_temp.DomainClass.soil_tempExogenous)};
        }

        public int[] layer_thick
        {
            get
            {
                 return _temp_profile.layer_thick; 
            }
            set
            {
                _temp_profile.layer_thick = value;
                _layers_temp.layer_thick = value;
            }
        }
        public double air_temp_day1
        {
            get
            {
                 return _temp_profile.air_temp_day1; 
            }
            set
            {
                _temp_profile.air_temp_day1 = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _temp_amp.SetParametersDefaultValue();
            _temp_profile.SetParametersDefaultValue();
            _layers_temp.SetParametersDefaultValue();
            _canopy_temp_avg.SetParametersDefaultValue();
            _update.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            layer_thickVarInfo.Name = "layer_thick";
            layer_thickVarInfo.Description = "layers thickness";
            layer_thickVarInfo.MaxValue = -1D;
            layer_thickVarInfo.MinValue = -1D;
            layer_thickVarInfo.DefaultValue = -1D;
            layer_thickVarInfo.Units = "cm";
            layer_thickVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayInteger");

            air_temp_day1VarInfo.Name = "air_temp_day1";
            air_temp_day1VarInfo.Description = "Mean temperature on first day";
            air_temp_day1VarInfo.MaxValue = 100.0;
            air_temp_day1VarInfo.MinValue = 0.0;
            air_temp_day1VarInfo.DefaultValue = 0.0;
            air_temp_day1VarInfo.Units = "degC";
            air_temp_day1VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        public static VarInfo layer_thickVarInfo
        {
            get { return soil_temp.Strategies.temp_profile.layer_thickVarInfo;} 
        }

        public static VarInfo air_temp_day1VarInfo
        {
            get { return soil_temp.Strategies.temp_profile.air_temp_day1VarInfo;} 
        }

        public string TestPostConditions(soil_temp.DomainClass.soil_tempState s,soil_temp.DomainClass.soil_tempState s1,soil_temp.DomainClass.soil_tempRate r,soil_temp.DomainClass.soil_tempAuxiliary a,soil_temp.DomainClass.soil_tempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                soil_temp.DomainClass.soil_tempStateVarInfo.temp_amp.CurrentValue=s.temp_amp;
                soil_temp.DomainClass.soil_tempStateVarInfo.temp_profile.CurrentValue=s.temp_profile;
                soil_temp.DomainClass.soil_tempStateVarInfo.layer_temp.CurrentValue=s.layer_temp;
                soil_temp.DomainClass.soil_tempStateVarInfo.canopy_temp_avg.CurrentValue=s.canopy_temp_avg;
                soil_temp.DomainClass.soil_tempExogenousVarInfo.prev_canopy_temp.CurrentValue=ex.prev_canopy_temp;
                soil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile.CurrentValue=s.prev_temp_profile;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r8 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempStateVarInfo.temp_amp);
                if(r8.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempStateVarInfo.temp_amp.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempStateVarInfo.temp_profile);
                if(r9.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempStateVarInfo.temp_profile.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempStateVarInfo.layer_temp);
                if(r10.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempStateVarInfo.layer_temp.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempStateVarInfo.canopy_temp_avg);
                if(r11.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempStateVarInfo.canopy_temp_avg.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempExogenousVarInfo.prev_canopy_temp);
                if(r12.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempExogenousVarInfo.prev_canopy_temp.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile);
                if(r13.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile.ValueType)){prc.AddCondition(r13);}

                string ret = "";
                ret += _temp_amp.TestPostConditions(s, s1, r, a, ex, " strategy soil_temp.Strategies.soil_temp");
                ret += _temp_profile.TestPostConditions(s, s1, r, a, ex, " strategy soil_temp.Strategies.soil_temp");
                ret += _layers_temp.TestPostConditions(s, s1, r, a, ex, " strategy soil_temp.Strategies.soil_temp");
                ret += _canopy_temp_avg.TestPostConditions(s, s1, r, a, ex, " strategy soil_temp.Strategies.soil_temp");
                ret += _update.TestPostConditions(s, s1, r, a, ex, " strategy soil_temp.Strategies.soil_temp");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .soil_temp, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(soil_temp.DomainClass.soil_tempState s,soil_temp.DomainClass.soil_tempState s1,soil_temp.DomainClass.soil_tempRate r,soil_temp.DomainClass.soil_tempAuxiliary a,soil_temp.DomainClass.soil_tempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                soil_temp.DomainClass.soil_tempExogenousVarInfo.max_temp.CurrentValue=ex.max_temp;
                soil_temp.DomainClass.soil_tempExogenousVarInfo.min_temp.CurrentValue=ex.min_temp;
                soil_temp.DomainClass.soil_tempExogenousVarInfo.min_air_temp.CurrentValue=ex.min_air_temp;
                soil_temp.DomainClass.soil_tempExogenousVarInfo.min_canopy_temp.CurrentValue=ex.min_canopy_temp;
                soil_temp.DomainClass.soil_tempExogenousVarInfo.max_canopy_temp.CurrentValue=ex.max_canopy_temp;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempExogenousVarInfo.max_temp);
                if(r1.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempExogenousVarInfo.max_temp.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempExogenousVarInfo.min_temp);
                if(r2.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempExogenousVarInfo.min_temp.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempExogenousVarInfo.min_air_temp);
                if(r3.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempExogenousVarInfo.min_air_temp.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempExogenousVarInfo.min_canopy_temp);
                if(r4.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempExogenousVarInfo.min_canopy_temp.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(soil_temp.DomainClass.soil_tempExogenousVarInfo.max_canopy_temp);
                if(r5.ApplicableVarInfoValueTypes.Contains( soil_temp.DomainClass.soil_tempExogenousVarInfo.max_canopy_temp.ValueType)){prc.AddCondition(r5);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("layer_thick")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("air_temp_day1")));
                string ret = "";
                ret += _temp_amp.TestPreConditions(s, s1, r, a, ex, " strategy soil_temp.Strategies.soil_temp");
                ret += _temp_profile.TestPreConditions(s, s1, r, a, ex, " strategy soil_temp.Strategies.soil_temp");
                ret += _layers_temp.TestPreConditions(s, s1, r, a, ex, " strategy soil_temp.Strategies.soil_temp");
                ret += _canopy_temp_avg.TestPreConditions(s, s1, r, a, ex, " strategy soil_temp.Strategies.soil_temp");
                ret += _update.TestPreConditions(s, s1, r, a, ex, " strategy soil_temp.Strategies.soil_temp");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .soil_temp, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
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

        private void CalculateModel(soil_temp.DomainClass.soil_tempState s,soil_temp.DomainClass.soil_tempState s1,soil_temp.DomainClass.soil_tempRate r,soil_temp.DomainClass.soil_tempAuxiliary a,soil_temp.DomainClass.soil_tempExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        Temp_amp _Temp_amp = new Temp_amp();
        Temp_profile _Temp_profile = new Temp_profile();
        Layers_temp _Layers_temp = new Layers_temp();
        Canopy_temp_avg _Canopy_temp_avg = new Canopy_temp_avg();
        Update _Update = new Update();

        private void EstimateOfAssociatedClasses(soil_temp.DomainClass.soil_tempState s,soil_temp.DomainClass.soil_tempState s1,soil_temp.DomainClass.soil_tempRate r,soil_temp.DomainClass.soil_tempAuxiliary a,soil_temp.DomainClass.soil_tempExogenous ex)
        {
            _temp_amp.Estimate(s,s1, r, a, ex);
            _canopy_temp_avg.Estimate(s,s1, r, a, ex);
            _temp_profile.Estimate(s,s1, r, a, ex);
            _layers_temp.Estimate(s,s1, r, a, ex);
            _update.Estimate(s,s1, r, a, ex);
        }

        public soil_tempComponent(soil_tempComponent toCopy): this() // copy constructor 
        {
                
            for (int i = 0; i < toCopy._layer_thick.Length; i++)
            { layer_thick[i] = toCopy.layer_thick[i]; }
    
                air_temp_day1 = toCopy.air_temp_day1;
        }
    }
}