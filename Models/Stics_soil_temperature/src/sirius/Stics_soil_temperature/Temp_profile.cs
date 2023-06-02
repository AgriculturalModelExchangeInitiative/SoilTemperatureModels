
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
    public class temp_profile : IStrategySiriusQualitysoil_temp
    {
        public temp_profile()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 0.0;
            v1.Description = "Mean temperature on first day";
            v1.Id = 0;
            v1.MaxValue = 100.0;
            v1.MinValue = 0.0;
            v1.Name = "air_temp_day1";
            v1.Size = 1;
            v1.Units = "degC";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = -1D;
            v2.Description = "layers thickness";
            v2.Id = 0;
            v2.MaxValue = -1D;
            v2.MinValue = -1D;
            v2.Name = "layer_thick";
            v2.Size = 1;
            v2.Units = "cm";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayInteger");
            _parameters0_0.Add(v2);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitysoil_temp.DomainClass.soil_tempExogenous);
            pd1.PropertyName = "temp_amp";
            pd1.PropertyType = (SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.temp_amp).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.temp_amp);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitysoil_temp.DomainClass.soil_tempExogenous);
            pd2.PropertyName = "therm_amp";
            pd2.PropertyType = (SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.therm_amp).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.therm_amp);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitysoil_temp.DomainClass.soil_tempState);
            pd3.PropertyName = "prev_temp_profile";
            pd3.PropertyType = (SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitysoil_temp.DomainClass.soil_tempState);
            pd4.PropertyName = "prev_canopy_temp";
            pd4.PropertyType = (SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_canopy_temp).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_canopy_temp);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitysoil_temp.DomainClass.soil_tempExogenous);
            pd5.PropertyName = "min_air_temp";
            pd5.PropertyType = (SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.min_air_temp).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.min_air_temp);
            _inputs0_0.Add(pd5);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitysoil_temp.DomainClass.soil_tempState);
            pd6.PropertyName = "temp_profile";
            pd6.PropertyType = (SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile);
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

        public double air_temp_day1
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("air_temp_day1");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'air_temp_day1' not found (or found null) in strategy 'temp_profile'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("air_temp_day1");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'air_temp_day1' not found in strategy 'temp_profile'");
            }
        }
        public int[] layer_thick
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("layer_thick");
                if (vi != null && vi.CurrentValue!=null) return (int[])vi.CurrentValue ;
                else throw new Exception("Parameter 'layer_thick' not found (or found null) in strategy 'temp_profile'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("layer_thick");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'layer_thick' not found in strategy 'temp_profile'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            air_temp_day1VarInfo.Name = "air_temp_day1";
            air_temp_day1VarInfo.Description = "Mean temperature on first day";
            air_temp_day1VarInfo.MaxValue = 100.0;
            air_temp_day1VarInfo.MinValue = 0.0;
            air_temp_day1VarInfo.DefaultValue = 0.0;
            air_temp_day1VarInfo.Units = "degC";
            air_temp_day1VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            layer_thickVarInfo.Name = "layer_thick";
            layer_thickVarInfo.Description = "layers thickness";
            layer_thickVarInfo.MaxValue = -1D;
            layer_thickVarInfo.MinValue = -1D;
            layer_thickVarInfo.DefaultValue = -1D;
            layer_thickVarInfo.Units = "cm";
            layer_thickVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayInteger");
        }

        private static VarInfo _air_temp_day1VarInfo = new VarInfo();
        public static VarInfo air_temp_day1VarInfo
        {
            get { return _air_temp_day1VarInfo;} 
        }

        private static VarInfo _layer_thickVarInfo = new VarInfo();
        public static VarInfo layer_thickVarInfo
        {
            get { return _layer_thickVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitysoil_temp.DomainClass.soil_tempState s,SiriusQualitysoil_temp.DomainClass.soil_tempState s1,SiriusQualitysoil_temp.DomainClass.soil_tempRate r,SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary a,SiriusQualitysoil_temp.DomainClass.soil_tempExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile.CurrentValue=s.temp_profile;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.temp_profile.ValueType)){prc.AddCondition(r8);}
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
                SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.temp_amp.CurrentValue=ex.temp_amp;
                SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.therm_amp.CurrentValue=ex.therm_amp;
                SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile.CurrentValue=s.prev_temp_profile;
                SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_canopy_temp.CurrentValue=s.prev_canopy_temp;
                SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.min_air_temp.CurrentValue=ex.min_air_temp;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.temp_amp);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.temp_amp.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.therm_amp);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.therm_amp.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_temp_profile.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_canopy_temp);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitysoil_temp.DomainClass.soil_tempStateVarInfo.prev_canopy_temp.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.min_air_temp);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitysoil_temp.DomainClass.soil_tempExogenousVarInfo.min_air_temp.ValueType)){prc.AddCondition(r5);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("air_temp_day1")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("layer_thick")));
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

        public void Init(SiriusQualitysoil_temp.DomainClass.soil_tempState s, SiriusQualitysoil_temp.DomainClass.soil_tempState s1, SiriusQualitysoil_temp.DomainClass.soil_tempRate r, SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary a, SiriusQualitysoil_temp.DomainClass.soil_tempExogenous ex)
        {
            double temp_amp;
            double therm_amp;
            double min_air_temp;
            double[] prev_temp_profile ;
            double prev_canopy_temp;
            prev_canopy_temp = 0.00d;
            int soil_depth;
            soil_depth = layer_thick.Sum();
            prev_temp_profile = new double[ soil_depth];
            for (var i = 0; i < soil_depth; i++){prev_temp_profile.Add(air_temp_day1);}
            prev_canopy_temp = air_temp_day1;
            s.prev_temp_profile= prev_temp_profile;
            s.prev_canopy_temp= prev_canopy_temp;
        }

        private void CalculateModel(SiriusQualitysoil_temp.DomainClass.soil_tempState s, SiriusQualitysoil_temp.DomainClass.soil_tempState s1, SiriusQualitysoil_temp.DomainClass.soil_tempRate r, SiriusQualitysoil_temp.DomainClass.soil_tempAuxiliary a, SiriusQualitysoil_temp.DomainClass.soil_tempExogenous ex)
        {
            double temp_amp = ex.temp_amp;
            double therm_amp = ex.therm_amp;
            double[] prev_temp_profile = s.prev_temp_profile;
            double prev_canopy_temp = s.prev_canopy_temp;
            double min_air_temp = ex.min_air_temp;
            double[] temp_profile ;
            int z;
            int n;
            List<double> vexp = new List<double>();
            n = prev_temp_profile.Length;
            temp_profile = new double[ n];
            vexp = new List<double>(n);
            for (z=1 ; z!=n + 1 ; z+=1)
            {
                vexp[z - 1] = Math.Exp(-(z * therm_amp));
            }
            for (z=1 ; z!=n + 1 ; z+=1)
            {
                temp_profile[z - 1] = prev_temp_profile[z - 1] - (vexp[(z - 1)] * (prev_canopy_temp - min_air_temp)) + (0.10d * (prev_canopy_temp - prev_temp_profile[z - 1])) + (temp_amp * vexp[(z - 1)] / 2);
            }
            s.temp_profile= temp_profile;
        }

    }
}