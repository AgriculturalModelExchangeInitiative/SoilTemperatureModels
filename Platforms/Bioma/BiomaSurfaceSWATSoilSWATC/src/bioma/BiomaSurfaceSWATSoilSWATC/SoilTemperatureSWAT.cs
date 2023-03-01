
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
using SurfaceSWATSoilSWATC.DomainClass;
namespace SurfaceSWATSoilSWATC.Strategies
{
    public class SoilTemperatureSWAT : IStrategySurfaceSWATSoilSWATC
    {
        public SoilTemperatureSWAT()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 0.8;
            v1.Description = "Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature";
            v1.Id = 0;
            v1.MaxValue = 1;
            v1.MinValue = 0;
            v1.Name = "LagCoefficient";
            v1.Size = 1;
            v1.Units = "dimensionless";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd1.PropertyName = "SoilTemperatureByLayers";
            pd1.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd2.PropertyName = "AirTemperatureAnnualAverage";
            pd2.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd3.PropertyName = "VolumetricWaterContent";
            pd3.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.VolumetricWaterContent).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.VolumetricWaterContent);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd4.PropertyName = "BulkDensity";
            pd4.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.BulkDensity).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.BulkDensity);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd5.PropertyName = "SoilProfileDepth";
            pd5.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilProfileDepth).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilProfileDepth);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd6.PropertyName = "LayerThickness";
            pd6.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.LayerThickness).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.LayerThickness);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd7.PropertyName = "SurfaceSoilTemperature";
            pd7.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SurfaceSoilTemperature).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SurfaceSoilTemperature);
            _inputs0_0.Add(pd7);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd8.PropertyName = "SoilTemperatureByLayers";
            pd8.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers);
            _outputs0_0.Add(pd8);
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
            get { return "Strategy for the calculation of soil temperature with SWAT method. Reference: Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf" ;}
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
            _pd.Add("Creator", "simone.bregaglio@unimi.it");
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
            return new List<Type>() {  typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState),  typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState), typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate), typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary), typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double LagCoefficient
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("LagCoefficient");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'LagCoefficient' not found (or found null) in strategy 'SoilTemperatureSWAT'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("LagCoefficient");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'LagCoefficient' not found in strategy 'SoilTemperatureSWAT'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            LagCoefficientVarInfo.Name = "LagCoefficient";
            LagCoefficientVarInfo.Description = "Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature";
            LagCoefficientVarInfo.MaxValue = 1;
            LagCoefficientVarInfo.MinValue = 0;
            LagCoefficientVarInfo.DefaultValue = 0.8;
            LagCoefficientVarInfo.Units = "dimensionless";
            LagCoefficientVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _LagCoefficientVarInfo = new VarInfo();
        public static VarInfo LagCoefficientVarInfo
        {
            get { return _LagCoefficientVarInfo;} 
        }

        public string TestPostConditions(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers.CurrentValue=s.SoilTemperatureByLayers;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r9 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers);
                if(r9.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r9);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".SurfaceSWATSoilSWATC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers.CurrentValue=s.SoilTemperatureByLayers;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage.CurrentValue=ex.AirTemperatureAnnualAverage;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.VolumetricWaterContent.CurrentValue=s.VolumetricWaterContent;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.BulkDensity.CurrentValue=s.BulkDensity;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilProfileDepth.CurrentValue=s.SoilProfileDepth;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.LayerThickness.CurrentValue=s.LayerThickness;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SurfaceSoilTemperature.CurrentValue=s.SurfaceSoilTemperature;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers);
                if(r1.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage);
                if(r2.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.VolumetricWaterContent);
                if(r3.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.VolumetricWaterContent.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.BulkDensity);
                if(r4.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.BulkDensity.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilProfileDepth);
                if(r5.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilProfileDepth.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.LayerThickness);
                if(r6.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.LayerThickness.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SurfaceSoilTemperature);
                if(r7.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SurfaceSoilTemperature.ValueType)){prc.AddCondition(r7);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LagCoefficient")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".SurfaceSWATSoilSWATC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SurfaceSWATSoilSWATC, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s, SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1, SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r, SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a, SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex)
        {
            double[] SoilTemperatureByLayers = s.SoilTemperatureByLayers;
            double AirTemperatureAnnualAverage = ex.AirTemperatureAnnualAverage;
            double[] VolumetricWaterContent = s.VolumetricWaterContent;
            double[] BulkDensity = s.BulkDensity;
            double SoilProfileDepth = s.SoilProfileDepth;
            double[] LayerThickness = s.LayerThickness;
            double SurfaceSoilTemperature = s.SurfaceSoilTemperature;
            int i;
            double _SoilProfileDepthmm;
            double _TotalWaterContentmm;
            double _MaximumDumpingDepth;
            double _DumpingDepth;
            double _ScalingFactor;
            double _DepthBottom;
            double _RatioCenter;
            double _DepthFactor;
            double _DepthCenterLayer;
            _SoilProfileDepthmm = SoilProfileDepth * 1000;
            _TotalWaterContentmm = (double)(0);
            for (i=0 ; i!=LayerThickness.Length ; i+=1)
            {
                _TotalWaterContentmm = _TotalWaterContentmm + (VolumetricWaterContent[i] * LayerThickness[i]);
            }
            _TotalWaterContentmm = _TotalWaterContentmm * 1000;
            _MaximumDumpingDepth = (double)(0);
            _DumpingDepth = (double)(0);
            _ScalingFactor = (double)(0);
            _DepthBottom = (double)(0);
            _RatioCenter = (double)(0);
            _DepthFactor = (double)(0);
            _DepthCenterLayer = LayerThickness[0] * 1000 / 2;
            _MaximumDumpingDepth = 1000 + (2500 * BulkDensity[0] / (BulkDensity[0] + (686 * Math.Exp(-5.630d * BulkDensity[0]))));
            _ScalingFactor = _TotalWaterContentmm / ((0.3560d - (0.1440d * BulkDensity[0])) * _SoilProfileDepthmm);
            _DumpingDepth = _MaximumDumpingDepth * Math.Exp(Math.Log(500 / _MaximumDumpingDepth) * Math.Pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2));
            _RatioCenter = _DepthCenterLayer / _DumpingDepth;
            _DepthFactor = _RatioCenter / (_RatioCenter + Math.Exp(-0.8670d - (2.0780d * _RatioCenter)));
            SoilTemperatureByLayers[0] = LagCoefficient * SoilTemperatureByLayers[0] + ((1 - LagCoefficient) * (_DepthFactor * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) + SurfaceSoilTemperature));
            for (i=1 ; i!=LayerThickness.Length ; i+=1)
            {
                _DepthBottom = _DepthBottom + (LayerThickness[(i - 1)] * 1000);
                _DepthCenterLayer = _DepthBottom + (LayerThickness[i] * 1000 / 2);
                _MaximumDumpingDepth = 1000 + (2500 * BulkDensity[i] / (BulkDensity[i] + (686 * Math.Exp(-5.630d * BulkDensity[i]))));
                _ScalingFactor = _TotalWaterContentmm / ((0.3560d - (0.1440d * BulkDensity[i])) * _SoilProfileDepthmm);
                _DumpingDepth = _MaximumDumpingDepth * Math.Exp(Math.Log(500 / _MaximumDumpingDepth) * Math.Pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2));
                _RatioCenter = _DepthCenterLayer / _DumpingDepth;
                _DepthFactor = _RatioCenter / (_RatioCenter + Math.Exp(-0.8670d - (2.0780d * _RatioCenter)));
                SoilTemperatureByLayers[i] = LagCoefficient * SoilTemperatureByLayers[i] + ((1 - LagCoefficient) * (_DepthFactor * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) + SurfaceSoilTemperature));
            }
            s.SoilTemperatureByLayers= SoilTemperatureByLayers;
        }

    }
}