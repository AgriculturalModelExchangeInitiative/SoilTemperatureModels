
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
    public class SurfaceSWATSoilSWATCComponent : IStrategySiriusQualitySurfaceSWATSoilSWATC
    {
        public SurfaceSWATSoilSWATCComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "BulkDensity");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "AirTemperatureAnnualAverage");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "SoilProfileDepth");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "LagCoefficient");
            _parameters0_0.Add(v4);
            VarInfo v5 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "LayerThickness");
            _parameters0_0.Add(v5);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd1.PropertyName = "AirTemperatureMaximum";
            pd1.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd2.PropertyName = "AirTemperatureMinimum";
            pd2.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd3.PropertyName = "GlobalSolarRadiation";
            pd3.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary);
            pd4.PropertyName = "AboveGroundBiomass";
            pd4.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.AboveGroundBiomass).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.AboveGroundBiomass);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd5.PropertyName = "WaterEquivalentOfSnowPack";
            pd5.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd6.PropertyName = "Albedo";
            pd6.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd7.PropertyName = "VolumetricWaterContent";
            pd7.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.VolumetricWaterContent).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.VolumetricWaterContent);
            _inputs0_0.Add(pd7);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary);
            pd8.PropertyName = "SurfaceSoilTemperature";
            pd8.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature);
            _outputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd9.PropertyName = "SoilTemperatureByLayers";
            pd9.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers);
            _outputs0_0.Add(pd9);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SiriusQualitySurfaceSWATSoilSWATC.Strategies.SurfaceTemperatureSWAT).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualitySurfaceSWATSoilSWATC.Strategies.SoilTemperatureSWAT).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();
        }

        public string Description
        {
            get { return "Composite strategy for the calculation of surface and soil temperature with SWAT method. Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf.  Composite strategy. See also references of the associated strategies." ;}
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
            _pd.Add("Publisher", "Universiy Of Milan "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState), typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState), typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate), typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary), typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous)};
        }

        public double[] BulkDensity
        {
            get
            {
                 return _SoilTemperatureSWAT.BulkDensity; 
            }
            set
            {
                _SoilTemperatureSWAT.BulkDensity = value;
            }
        }
        public double AirTemperatureAnnualAverage
        {
            get
            {
                 return _SoilTemperatureSWAT.AirTemperatureAnnualAverage; 
            }
            set
            {
                _SoilTemperatureSWAT.AirTemperatureAnnualAverage = value;
            }
        }
        public double SoilProfileDepth
        {
            get
            {
                 return _SoilTemperatureSWAT.SoilProfileDepth; 
            }
            set
            {
                _SoilTemperatureSWAT.SoilProfileDepth = value;
            }
        }
        public double LagCoefficient
        {
            get
            {
                 return _SoilTemperatureSWAT.LagCoefficient; 
            }
            set
            {
                _SoilTemperatureSWAT.LagCoefficient = value;
            }
        }
        public double[] LayerThickness
        {
            get
            {
                 return _SoilTemperatureSWAT.LayerThickness; 
            }
            set
            {
                _SoilTemperatureSWAT.LayerThickness = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _SurfaceTemperatureSWAT.SetParametersDefaultValue();
            _SoilTemperatureSWAT.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            BulkDensityVarInfo.Name = "BulkDensity";
            BulkDensityVarInfo.Description = "Bulk density";
            BulkDensityVarInfo.MaxValue = -1D;
            BulkDensityVarInfo.MinValue = -1D;
            BulkDensityVarInfo.DefaultValue = -1D;
            BulkDensityVarInfo.Units = "t m-3";
            BulkDensityVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            AirTemperatureAnnualAverageVarInfo.Name = "AirTemperatureAnnualAverage";
            AirTemperatureAnnualAverageVarInfo.Description = "Annual average air temperature";
            AirTemperatureAnnualAverageVarInfo.MaxValue = 50;
            AirTemperatureAnnualAverageVarInfo.MinValue = -40;
            AirTemperatureAnnualAverageVarInfo.DefaultValue = 15;
            AirTemperatureAnnualAverageVarInfo.Units = "degC";
            AirTemperatureAnnualAverageVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            SoilProfileDepthVarInfo.Name = "SoilProfileDepth";
            SoilProfileDepthVarInfo.Description = "Soil profile depth";
            SoilProfileDepthVarInfo.MaxValue = 50;
            SoilProfileDepthVarInfo.MinValue = 0;
            SoilProfileDepthVarInfo.DefaultValue = 3;
            SoilProfileDepthVarInfo.Units = "m";
            SoilProfileDepthVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            LagCoefficientVarInfo.Name = "LagCoefficient";
            LagCoefficientVarInfo.Description = "Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature";
            LagCoefficientVarInfo.MaxValue = 1;
            LagCoefficientVarInfo.MinValue = 0;
            LagCoefficientVarInfo.DefaultValue = 0.8;
            LagCoefficientVarInfo.Units = "dimensionless";
            LagCoefficientVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            LayerThicknessVarInfo.Name = "LayerThickness";
            LayerThicknessVarInfo.Description = "Soil layer thickness";
            LayerThicknessVarInfo.MaxValue = -1D;
            LayerThicknessVarInfo.MinValue = -1D;
            LayerThicknessVarInfo.DefaultValue = -1D;
            LayerThicknessVarInfo.Units = "m";
            LayerThicknessVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
        }

        public static VarInfo BulkDensityVarInfo
        {
            get { return SiriusQualitySurfaceSWATSoilSWATC.Strategies.SoilTemperatureSWAT.BulkDensityVarInfo;} 
        }

        public static VarInfo AirTemperatureAnnualAverageVarInfo
        {
            get { return SiriusQualitySurfaceSWATSoilSWATC.Strategies.SoilTemperatureSWAT.AirTemperatureAnnualAverageVarInfo;} 
        }

        public static VarInfo SoilProfileDepthVarInfo
        {
            get { return SiriusQualitySurfaceSWATSoilSWATC.Strategies.SoilTemperatureSWAT.SoilProfileDepthVarInfo;} 
        }

        public static VarInfo LagCoefficientVarInfo
        {
            get { return SiriusQualitySurfaceSWATSoilSWATC.Strategies.SoilTemperatureSWAT.LagCoefficientVarInfo;} 
        }

        public static VarInfo LayerThicknessVarInfo
        {
            get { return SiriusQualitySurfaceSWATSoilSWATC.Strategies.SoilTemperatureSWAT.LayerThicknessVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature.CurrentValue=a.SurfaceSoilTemperature;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers.CurrentValue=s.SoilTemperatureByLayers;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature);
                if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers);
                if(r14.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r14);}

                string ret = "";
                ret += _SurfaceTemperatureSWAT.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfaceSWATSoilSWATC.Strategies.SurfaceSWATSoilSWATC");
                ret += _SoilTemperatureSWAT.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfaceSWATSoilSWATC.Strategies.SurfaceSWATSoilSWATC");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.SurfaceSWATSoilSWATC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum.CurrentValue=ex.AirTemperatureMaximum;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum.CurrentValue=ex.AirTemperatureMinimum;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation.CurrentValue=ex.GlobalSolarRadiation;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.AboveGroundBiomass.CurrentValue=a.AboveGroundBiomass;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack.CurrentValue=ex.WaterEquivalentOfSnowPack;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo.CurrentValue=ex.Albedo;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.VolumetricWaterContent.CurrentValue=ex.VolumetricWaterContent;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.AboveGroundBiomass);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.AboveGroundBiomass.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.VolumetricWaterContent);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.VolumetricWaterContent.ValueType)){prc.AddCondition(r7);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("BulkDensity")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("AirTemperatureAnnualAverage")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SoilProfileDepth")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LagCoefficient")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LayerThickness")));
                string ret = "";
                ret += _SurfaceTemperatureSWAT.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfaceSWATSoilSWATC.Strategies.SurfaceSWATSoilSWATC");
                ret += _SoilTemperatureSWAT.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfaceSWATSoilSWATC.Strategies.SurfaceSWATSoilSWATC");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.SurfaceSWATSoilSWATC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
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

        private void CalculateModel(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        SurfaceTemperatureSWAT _SurfaceTemperatureSWAT = new SurfaceTemperatureSWAT();
        SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

        private void EstimateOfAssociatedClasses(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex)
        {
            _SurfaceTemperatureSWAT.Estimate(s,s1, r, a, ex);
            _SoilTemperatureSWAT.Estimate(s,s1, r, a, ex);
        }

        public SurfaceSWATSoilSWATCComponent(SurfaceSWATSoilSWATCComponent toCopy): this() // copy constructor 
        {
                
            for (int i = 0; i < toCopy._BulkDensity.Length; i++)
            { BulkDensity[i] = toCopy.BulkDensity[i]; }
    
                AirTemperatureAnnualAverage = toCopy.AirTemperatureAnnualAverage;
                SoilProfileDepth = toCopy.SoilProfileDepth;
                LagCoefficient = toCopy.LagCoefficient;
                
            for (int i = 0; i < toCopy._LayerThickness.Length; i++)
            { LayerThickness[i] = toCopy.LayerThickness[i]; }
    
        }
    }
}