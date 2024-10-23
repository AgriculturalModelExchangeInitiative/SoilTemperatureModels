
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
using SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass;
namespace SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies
{
    public class RangeOfSoilTemperaturesDAYCENT : IStrategySiriusQualitySurfacePartonSoilSWATHourlyPartonC
    {
        public RangeOfSoilTemperaturesDAYCENT()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = -1D;
            v1.Description = "Soil layer thickness";
            v1.Id = 0;
            v1.MaxValue = -1D;
            v1.MinValue = -1D;
            v1.Name = "LayerThickness";
            v1.Size = 1;
            v1.Units = "m";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd1.PropertyName = "SurfaceTemperatureMinimum";
            pd1.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd2.PropertyName = "ThermalDiffusivity";
            pd2.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalDiffusivity).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalDiffusivity);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd3.PropertyName = "SoilTemperatureByLayers";
            pd3.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureByLayers);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd4.PropertyName = "SurfaceTemperatureMaximum";
            pd4.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd5.PropertyName = "SoilTemperatureRangeByLayers";
            pd5.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd6.PropertyName = "SoilTemperatureMinimum";
            pd6.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd7.PropertyName = "SoilTemperatureMaximum";
            pd7.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum);
            _inputs0_0.Add(pd7);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd8.PropertyName = "SoilTemperatureRangeByLayers";
            pd8.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers);
            _outputs0_0.Add(pd8);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd9.PropertyName = "SoilTemperatureMinimum";
            pd9.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum);
            _outputs0_0.Add(pd9);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd10.PropertyName = "SoilTemperatureMaximum";
            pd10.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum);
            _outputs0_0.Add(pd10);
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
            get { return "Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code" ;}
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
            _pd.Add("Creator", "simone.bregaglio");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "University Of Milan "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState),  typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState), typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate), typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary), typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double[] LayerThickness
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("LayerThickness");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'LayerThickness' not found (or found null) in strategy 'RangeOfSoilTemperaturesDAYCENT'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("LayerThickness");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'LayerThickness' not found in strategy 'RangeOfSoilTemperaturesDAYCENT'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            LayerThicknessVarInfo.Name = "LayerThickness";
            LayerThicknessVarInfo.Description = "Soil layer thickness";
            LayerThicknessVarInfo.MaxValue = -1D;
            LayerThicknessVarInfo.MinValue = -1D;
            LayerThicknessVarInfo.DefaultValue = -1D;
            LayerThicknessVarInfo.Units = "m";
            LayerThicknessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
        }

        private static VarInfo _LayerThicknessVarInfo = new VarInfo();
        public static VarInfo LayerThicknessVarInfo
        {
            get { return _LayerThicknessVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers.CurrentValue=s.SoilTemperatureRangeByLayers;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum.CurrentValue=s.SoilTemperatureMinimum;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum.CurrentValue=s.SoilTemperatureMaximum;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum);
                if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum);
                if(r11.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum.ValueType)){prc.AddCondition(r11);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.SurfacePartonSoilSWATHourlyPartonC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum.CurrentValue=a.SurfaceTemperatureMinimum;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalDiffusivity.CurrentValue=a.ThermalDiffusivity;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureByLayers.CurrentValue=a.SoilTemperatureByLayers;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum.CurrentValue=a.SurfaceTemperatureMaximum;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers.CurrentValue=s.SoilTemperatureRangeByLayers;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum.CurrentValue=s.SoilTemperatureMinimum;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum.CurrentValue=s.SoilTemperatureMaximum;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMinimum.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalDiffusivity);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalDiffusivity.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureByLayers);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.SurfaceTemperatureMaximum.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureRangeByLayers.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMinimum.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.SoilTemperatureMaximum.ValueType)){prc.AddCondition(r7);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LayerThickness")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.SurfacePartonSoilSWATHourlyPartonC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitySurfacePartonSoilSWATHourlyPartonC, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        public void Init(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s, SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1, SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r, SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
        {
            double[] SoilTemperatureRangeByLayers ;
            double[] SoilTemperatureMinimum ;
            double[] SoilTemperatureMaximum ;
            SoilTemperatureRangeByLayers = new double[LayerThickness.Length];
            SoilTemperatureMaximum = new double[LayerThickness.Length];
            SoilTemperatureMinimum = new double[LayerThickness.Length];
            s.SoilTemperatureRangeByLayers= SoilTemperatureRangeByLayers;
            s.SoilTemperatureMinimum= SoilTemperatureMinimum;
            s.SoilTemperatureMaximum= SoilTemperatureMaximum;
        }

        private void CalculateModel(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s, SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1, SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r, SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
        {
            double SurfaceTemperatureMinimum = a.SurfaceTemperatureMinimum;
            double[] ThermalDiffusivity = a.ThermalDiffusivity;
            double[] SoilTemperatureByLayers = a.SoilTemperatureByLayers;
            double SurfaceTemperatureMaximum = a.SurfaceTemperatureMaximum;
            double[] SoilTemperatureRangeByLayers = s.SoilTemperatureRangeByLayers;
            double[] SoilTemperatureMinimum = s.SoilTemperatureMinimum;
            double[] SoilTemperatureMaximum = s.SoilTemperatureMaximum;
            int i;
            double _DepthBottom;
            double _DepthCenterLayer;
            double SurfaceDiurnalRange;
            _DepthBottom = (double)(0);
            _DepthCenterLayer = (double)(0);
            SurfaceDiurnalRange = SurfaceTemperatureMaximum - SurfaceTemperatureMinimum;
            for (i=0 ; i!=SoilTemperatureByLayers.Length ; i+=1)
            {
                if (i == 0)
                {
                    _DepthCenterLayer = LayerThickness[0] * 100 / 2;
                    SoilTemperatureRangeByLayers[0] = SurfaceDiurnalRange * Math.Exp(-_DepthCenterLayer * Math.Pow(0.000050d / ThermalDiffusivity[0], 0.50d));
                    SoilTemperatureMaximum[0] = SoilTemperatureByLayers[0] + (SoilTemperatureRangeByLayers[0] / 2);
                    SoilTemperatureMinimum[0] = SoilTemperatureByLayers[0] - (SoilTemperatureRangeByLayers[0] / 2);
                }
                else
                {
                    _DepthBottom = _DepthBottom + (LayerThickness[(i - 1)] * 100);
                    _DepthCenterLayer = _DepthBottom + (LayerThickness[i] * 100 / 2);
                    SoilTemperatureRangeByLayers[i] = SurfaceDiurnalRange * Math.Exp(-_DepthCenterLayer * Math.Pow(0.000050d / ThermalDiffusivity[i], 0.50d));
                    SoilTemperatureMaximum[i] = SoilTemperatureByLayers[i] + (SoilTemperatureRangeByLayers[i] / 2);
                    SoilTemperatureMinimum[i] = SoilTemperatureByLayers[i] - (SoilTemperatureRangeByLayers[i] / 2);
                }
            }
            s.SoilTemperatureRangeByLayers= SoilTemperatureRangeByLayers;
            s.SoilTemperatureMinimum= SoilTemperatureMinimum;
            s.SoilTemperatureMaximum= SoilTemperatureMaximum;
        }

    }
}