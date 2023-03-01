
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
    public class SurfaceSWATSoilSWATCComponent : IStrategySurfaceSWATSoilSWATC
    {
        public SurfaceSWATSoilSWATCComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "LagCoefficient");
            _parameters0_0.Add(v1);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd1.PropertyName = "AirTemperatureMinimum";
            pd1.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd2.PropertyName = "GlobalSolarRadiation";
            pd2.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd3.PropertyName = "AboveGroundBiomass";
            pd3.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.AboveGroundBiomass).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.AboveGroundBiomass);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd4.PropertyName = "WaterEquivalentOfSnowPack";
            pd4.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd5.PropertyName = "AirTemperatureMaximum";
            pd5.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd6.PropertyName = "Albedo";
            pd6.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd7.PropertyName = "AirTemperatureAnnualAverage";
            pd7.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd8.PropertyName = "VolumetricWaterContent";
            pd8.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.VolumetricWaterContent).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.VolumetricWaterContent);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd9.PropertyName = "BulkDensity";
            pd9.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.BulkDensity).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.BulkDensity);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd10.PropertyName = "SoilProfileDepth";
            pd10.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilProfileDepth).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilProfileDepth);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd11.PropertyName = "LayerThickness";
            pd11.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.LayerThickness).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.LayerThickness);
            _inputs0_0.Add(pd11);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd12.PropertyName = "SurfaceSoilTemperature";
            pd12.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SurfaceSoilTemperature).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SurfaceSoilTemperature);
            _outputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState);
            pd13.PropertyName = "SoilTemperatureByLayers";
            pd13.PropertyType = (SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers);
            _outputs0_0.Add(pd13);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SurfaceSWATSoilSWATC.Strategies.SurfaceTemperatureSWAT).FullName);
            lAssStrat0_0.Add(typeof(SurfaceSWATSoilSWATC.Strategies.SoilTemperatureSWAT).FullName);
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
            return new List<Type>() {  typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState), typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState), typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate), typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary), typeof(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous)};
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

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _SurfaceTemperatureSWAT.SetParametersDefaultValue();
            _SoilTemperatureSWAT.SetParametersDefaultValue();
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

        public static VarInfo LagCoefficientVarInfo
        {
            get { return SurfaceSWATSoilSWATC.Strategies.SoilTemperatureSWAT.LagCoefficientVarInfo;} 
        }

        public string TestPostConditions(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SurfaceSoilTemperature.CurrentValue=s.SurfaceSoilTemperature;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers.CurrentValue=s.SoilTemperatureByLayers;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r13 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SurfaceSoilTemperature);
                if(r13.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SurfaceSoilTemperature.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers);
                if(r14.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r14);}

                string ret = "";
                ret += _SurfaceTemperatureSWAT.TestPostConditions(s, s1, r, a, ex, " strategy SurfaceSWATSoilSWATC.Strategies.SurfaceSWATSoilSWATC");
                ret += _SoilTemperatureSWAT.TestPostConditions(s, s1, r, a, ex, " strategy SurfaceSWATSoilSWATC.Strategies.SurfaceSWATSoilSWATC");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .SurfaceSWATSoilSWATC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum.CurrentValue=ex.AirTemperatureMinimum;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation.CurrentValue=ex.GlobalSolarRadiation;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.AboveGroundBiomass.CurrentValue=s.AboveGroundBiomass;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack.CurrentValue=ex.WaterEquivalentOfSnowPack;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum.CurrentValue=ex.AirTemperatureMaximum;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo.CurrentValue=ex.Albedo;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage.CurrentValue=ex.AirTemperatureAnnualAverage;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.VolumetricWaterContent.CurrentValue=s.VolumetricWaterContent;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.BulkDensity.CurrentValue=s.BulkDensity;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilProfileDepth.CurrentValue=s.SoilProfileDepth;
                SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.LayerThickness.CurrentValue=s.LayerThickness;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
                if(r1.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
                if(r2.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.AboveGroundBiomass);
                if(r3.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.AboveGroundBiomass.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack);
                if(r4.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
                if(r5.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo);
                if(r6.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage);
                if(r7.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.VolumetricWaterContent);
                if(r8.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.VolumetricWaterContent.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.BulkDensity);
                if(r9.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.BulkDensity.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilProfileDepth);
                if(r10.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.SoilProfileDepth.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.LayerThickness);
                if(r11.ApplicableVarInfoValueTypes.Contains( SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCStateVarInfo.LayerThickness.ValueType)){prc.AddCondition(r11);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LagCoefficient")));
                string ret = "";
                ret += _SurfaceTemperatureSWAT.TestPreConditions(s, s1, r, a, ex, " strategy SurfaceSWATSoilSWATC.Strategies.SurfaceSWATSoilSWATC");
                ret += _SoilTemperatureSWAT.TestPreConditions(s, s1, r, a, ex, " strategy SurfaceSWATSoilSWATC.Strategies.SurfaceSWATSoilSWATC");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .SurfaceSWATSoilSWATC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
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

        private void CalculateModel(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        SurfaceTemperatureSWAT _SurfaceTemperatureSWAT = new SurfaceTemperatureSWAT();
        SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

        private void EstimateOfAssociatedClasses(SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex)
        {
            _surfacetemperatureswat.Estimate(s,s1, r, a, ex);
            _soiltemperatureswat.Estimate(s,s1, r, a, ex);
        }

        public SurfaceSWATSoilSWATCComponent(SurfaceSWATSoilSWATCComponent toCopy): this() // copy constructor 
        {
                LagCoefficient = toCopy.LagCoefficient;
        }
    }
}