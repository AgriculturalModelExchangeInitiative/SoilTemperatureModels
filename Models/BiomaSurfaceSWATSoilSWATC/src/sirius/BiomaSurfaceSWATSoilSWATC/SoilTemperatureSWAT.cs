
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
using SiriusQualitySurfaceSWATSoilSWATC.DomainClass;
namespace SiriusQualitySurfaceSWATSoilSWATC.Strategies
{
    public class SoilTemperatureSWAT : IStrategySiriusQualitySurfaceSWATSoilSWATC
    {
        public SoilTemperatureSWAT()
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
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 0.8;
            v2.Description = "Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature";
            v2.Id = 0;
            v2.MaxValue = 1;
            v2.MinValue = 0;
            v2.Name = "LagCoefficient";
            v2.Size = 1;
            v2.Units = "dimensionless";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = 15;
            v3.Description = "Annual average air temperature";
            v3.Id = 0;
            v3.MaxValue = 50;
            v3.MinValue = -40;
            v3.Name = "AirTemperatureAnnualAverage";
            v3.Size = 1;
            v3.Units = "degC";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v3);
            VarInfo v4 = new VarInfo();
            v4.DefaultValue = -1D;
            v4.Description = "Bulk density";
            v4.Id = 0;
            v4.MaxValue = -1D;
            v4.MinValue = -1D;
            v4.Name = "BulkDensity";
            v4.Size = 1;
            v4.Units = "t m-3";
            v4.URL = "";
            v4.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v4.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v4);
            VarInfo v5 = new VarInfo();
            v5.DefaultValue = 3;
            v5.Description = "Soil profile depth";
            v5.Id = 0;
            v5.MaxValue = 50;
            v5.MinValue = 0;
            v5.Name = "SoilProfileDepth";
            v5.Size = 1;
            v5.Units = "m";
            v5.URL = "";
            v5.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v5.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v5);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd1.PropertyName = "VolumetricWaterContent";
            pd1.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.VolumetricWaterContent).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.VolumetricWaterContent);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary);
            pd2.PropertyName = "SurfaceSoilTemperature";
            pd2.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd3.PropertyName = "SoilTemperatureByLayers";
            pd3.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd4.PropertyName = "SoilTemperatureByLayers";
            pd4.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers);
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
            return new List<Type>() {  typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState),  typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState), typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate), typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary), typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double[] LayerThickness
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("LayerThickness");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'LayerThickness' not found (or found null) in strategy 'SoilTemperatureSWAT'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("LayerThickness");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'LayerThickness' not found in strategy 'SoilTemperatureSWAT'");
            }
        }
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
        public double AirTemperatureAnnualAverage
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("AirTemperatureAnnualAverage");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'AirTemperatureAnnualAverage' not found (or found null) in strategy 'SoilTemperatureSWAT'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("AirTemperatureAnnualAverage");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'AirTemperatureAnnualAverage' not found in strategy 'SoilTemperatureSWAT'");
            }
        }
        public double[] BulkDensity
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("BulkDensity");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'BulkDensity' not found (or found null) in strategy 'SoilTemperatureSWAT'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("BulkDensity");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'BulkDensity' not found in strategy 'SoilTemperatureSWAT'");
            }
        }
        public double SoilProfileDepth
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("SoilProfileDepth");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'SoilProfileDepth' not found (or found null) in strategy 'SoilTemperatureSWAT'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("SoilProfileDepth");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'SoilProfileDepth' not found in strategy 'SoilTemperatureSWAT'");
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

            LagCoefficientVarInfo.Name = "LagCoefficient";
            LagCoefficientVarInfo.Description = "Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature";
            LagCoefficientVarInfo.MaxValue = 1;
            LagCoefficientVarInfo.MinValue = 0;
            LagCoefficientVarInfo.DefaultValue = 0.8;
            LagCoefficientVarInfo.Units = "dimensionless";
            LagCoefficientVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            AirTemperatureAnnualAverageVarInfo.Name = "AirTemperatureAnnualAverage";
            AirTemperatureAnnualAverageVarInfo.Description = "Annual average air temperature";
            AirTemperatureAnnualAverageVarInfo.MaxValue = 50;
            AirTemperatureAnnualAverageVarInfo.MinValue = -40;
            AirTemperatureAnnualAverageVarInfo.DefaultValue = 15;
            AirTemperatureAnnualAverageVarInfo.Units = "degC";
            AirTemperatureAnnualAverageVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            BulkDensityVarInfo.Name = "BulkDensity";
            BulkDensityVarInfo.Description = "Bulk density";
            BulkDensityVarInfo.MaxValue = -1D;
            BulkDensityVarInfo.MinValue = -1D;
            BulkDensityVarInfo.DefaultValue = -1D;
            BulkDensityVarInfo.Units = "t m-3";
            BulkDensityVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            SoilProfileDepthVarInfo.Name = "SoilProfileDepth";
            SoilProfileDepthVarInfo.Description = "Soil profile depth";
            SoilProfileDepthVarInfo.MaxValue = 50;
            SoilProfileDepthVarInfo.MinValue = 0;
            SoilProfileDepthVarInfo.DefaultValue = 3;
            SoilProfileDepthVarInfo.Units = "m";
            SoilProfileDepthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _LayerThicknessVarInfo = new VarInfo();
        public static VarInfo LayerThicknessVarInfo
        {
            get { return _LayerThicknessVarInfo;} 
        }

        private static VarInfo _LagCoefficientVarInfo = new VarInfo();
        public static VarInfo LagCoefficientVarInfo
        {
            get { return _LagCoefficientVarInfo;} 
        }

        private static VarInfo _AirTemperatureAnnualAverageVarInfo = new VarInfo();
        public static VarInfo AirTemperatureAnnualAverageVarInfo
        {
            get { return _AirTemperatureAnnualAverageVarInfo;} 
        }

        private static VarInfo _BulkDensityVarInfo = new VarInfo();
        public static VarInfo BulkDensityVarInfo
        {
            get { return _BulkDensityVarInfo;} 
        }

        private static VarInfo _SoilProfileDepthVarInfo = new VarInfo();
        public static VarInfo SoilProfileDepthVarInfo
        {
            get { return _SoilProfileDepthVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers.CurrentValue=s.SoilTemperatureByLayers;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r9);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.SurfaceSWATSoilSWATC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.VolumetricWaterContent.CurrentValue=ex.VolumetricWaterContent;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature.CurrentValue=a.SurfaceSoilTemperature;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers.CurrentValue=s.SoilTemperatureByLayers;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.VolumetricWaterContent);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.VolumetricWaterContent.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r3);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LayerThickness")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LagCoefficient")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("AirTemperatureAnnualAverage")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("BulkDensity")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SoilProfileDepth")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.SurfaceSWATSoilSWATC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitySurfaceSWATSoilSWATC, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        public void Init(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s, SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1, SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r, SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a, SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex)
        {
            double[] VolumetricWaterContent;
            double[] SoilTemperatureByLayers ;
            int i;
            SoilTemperatureByLayers = new double[LayerThickness.Length];
            for (i=0 ; i!=LayerThickness.Length ; i+=1)
            {
                SoilTemperatureByLayers[i] = (double)(15);
            }
            s.SoilTemperatureByLayers= SoilTemperatureByLayers;
        }

        private void CalculateModel(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s, SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1, SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r, SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a, SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex)
        {
            double[] VolumetricWaterContent = ex.VolumetricWaterContent;
            double SurfaceSoilTemperature = a.SurfaceSoilTemperature;
            double[] SoilTemperatureByLayers = s.SoilTemperatureByLayers;
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