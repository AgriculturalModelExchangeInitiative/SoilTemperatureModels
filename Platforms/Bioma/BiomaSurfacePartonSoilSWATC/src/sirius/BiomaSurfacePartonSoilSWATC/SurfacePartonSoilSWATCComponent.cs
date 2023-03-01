
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

using SiriusQualitySurfacePartonSoilSWATC.DomainClass;
namespace SiriusQualitySurfacePartonSoilSWATC.Strategies
{
    public class SurfacePartonSoilSWATCComponent : IStrategySiriusQualitySurfacePartonSoilSWATC
    {
        public SurfacePartonSoilSWATCComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_SoilTemperatureSWAT, "LagCoefficient");
            _parameters0_0.Add(v1);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd1.PropertyName = "GlobalSolarRadiation";
            pd1.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd2.PropertyName = "AboveGroundBiomass";
            pd2.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd3.PropertyName = "AirTemperatureMaximum";
            pd3.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd4.PropertyName = "AirTemperatureMinimum";
            pd4.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd5.PropertyName = "DayLength";
            pd5.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd6.PropertyName = "AirTemperatureAnnualAverage";
            pd6.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd7.PropertyName = "SoilProfileDepth";
            pd7.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilProfileDepth).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilProfileDepth);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd8.PropertyName = "BulkDensity";
            pd8.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.BulkDensity).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.BulkDensity);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd9.PropertyName = "VolumetricWaterContent";
            pd9.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.VolumetricWaterContent).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.VolumetricWaterContent);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd10.PropertyName = "LayerThickness";
            pd10.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.LayerThickness).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.LayerThickness);
            _inputs0_0.Add(pd10);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary);
            pd11.PropertyName = "SurfaceTemperatureMaximum";
            pd11.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
            _outputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary);
            pd12.PropertyName = "SurfaceTemperatureMinimum";
            pd12.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
            _outputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd13.PropertyName = "SurfaceSoilTemperature";
            pd13.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature);
            _outputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd14.PropertyName = "SoilTemperatureByLayers";
            pd14.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilTemperatureByLayers);
            _outputs0_0.Add(pd14);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SiriusQualitySurfacePartonSoilSWATC.Strategies.SurfaceTemperatureParton).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualitySurfacePartonSoilSWATC.Strategies.SoilTemperatureSWAT).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();
        }

        public string Description
        {
            get { return "Composite strategy for the calculation of surface temperature with Parton's method and soil temperature with SWAT method. Parton, W. J. 1984. Predicting soil temperatures in a shortgrass steppe. Soil Science 138:93-101. and Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf.  Composite strategy. See also references of the associated strategies." ;}
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
            return new List<Type>() {  typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState), typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState), typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate), typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary), typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous)};
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
            _SurfaceTemperatureParton.SetParametersDefaultValue();
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
            get { return SiriusQualitySurfacePartonSoilSWATC.Strategies.SoilTemperatureSWAT.LagCoefficientVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum.CurrentValue=a.SurfaceTemperatureMaximum;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum.CurrentValue=a.SurfaceTemperatureMinimum;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature.CurrentValue=s.SurfaceSoilTemperature;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilTemperatureByLayers.CurrentValue=s.SoilTemperatureByLayers;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r12 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
                if(r12.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
                if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature);
                if(r14.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilTemperatureByLayers);
                if(r15.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r15);}

                string ret = "";
                ret += _SurfaceTemperatureParton.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATC.Strategies.SurfacePartonSoilSWATC");
                ret += _SoilTemperatureSWAT.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATC.Strategies.SurfacePartonSoilSWATC");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.SurfacePartonSoilSWATC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation.CurrentValue=ex.GlobalSolarRadiation;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass.CurrentValue=s.AboveGroundBiomass;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum.CurrentValue=ex.AirTemperatureMaximum;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum.CurrentValue=ex.AirTemperatureMinimum;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength.CurrentValue=ex.DayLength;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage.CurrentValue=ex.AirTemperatureAnnualAverage;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilProfileDepth.CurrentValue=s.SoilProfileDepth;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.BulkDensity.CurrentValue=s.BulkDensity;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.VolumetricWaterContent.CurrentValue=s.VolumetricWaterContent;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.LayerThickness.CurrentValue=s.LayerThickness;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilProfileDepth);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilProfileDepth.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.BulkDensity);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.BulkDensity.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.VolumetricWaterContent);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.VolumetricWaterContent.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.LayerThickness);
                if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.LayerThickness.ValueType)){prc.AddCondition(r10);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LagCoefficient")));
                string ret = "";
                ret += _SurfaceTemperatureParton.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATC.Strategies.SurfacePartonSoilSWATC");
                ret += _SoilTemperatureSWAT.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySurfacePartonSoilSWATC.Strategies.SurfacePartonSoilSWATC");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.SurfacePartonSoilSWATC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitySurfacePartonSoilSWATC, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        SurfaceTemperatureParton _SurfaceTemperatureParton = new SurfaceTemperatureParton();
        SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

        private void EstimateOfAssociatedClasses(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex)
        {
            _SurfaceTemperatureParton.Estimate(s,s1, r, a, ex);
            _SoilTemperatureSWAT.Estimate(s,s1, r, a, ex);
        }

        public SurfacePartonSoilSWATCComponent(SurfacePartonSoilSWATCComponent toCopy): this() // copy constructor 
        {
                LagCoefficient = toCopy.LagCoefficient;
        }
    }
}