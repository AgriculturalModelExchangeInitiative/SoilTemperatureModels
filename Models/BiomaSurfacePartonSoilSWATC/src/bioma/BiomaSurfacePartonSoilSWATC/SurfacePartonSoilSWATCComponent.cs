
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

using SurfacePartonSoilSWATC.DomainClass;
namespace SurfacePartonSoilSWATC.Strategies
{
    public class SurfacePartonSoilSWATCComponent : IStrategySurfacePartonSoilSWATC
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
            pd1.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd1.PropertyName = "DayLength";
            pd1.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd2.PropertyName = "AirTemperatureMaximum";
            pd2.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd3.PropertyName = "AirTemperatureMinimum";
            pd3.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd4.PropertyName = "AboveGroundBiomass";
            pd4.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd5.PropertyName = "GlobalSolarRadiation";
            pd5.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd6.PropertyName = "VolumetricWaterContent";
            pd6.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.VolumetricWaterContent).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.VolumetricWaterContent);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd7.PropertyName = "LayerThickness";
            pd7.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.LayerThickness).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.LayerThickness);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd8.PropertyName = "AirTemperatureAnnualAverage";
            pd8.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd9.PropertyName = "BulkDensity";
            pd9.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.BulkDensity).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.BulkDensity);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd10.PropertyName = "SoilProfileDepth";
            pd10.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilProfileDepth).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilProfileDepth);
            _inputs0_0.Add(pd10);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary);
            pd11.PropertyName = "SurfaceTemperatureMinimum";
            pd11.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
            _outputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary);
            pd12.PropertyName = "SurfaceTemperatureMaximum";
            pd12.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
            _outputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd13.PropertyName = "SurfaceSoilTemperature";
            pd13.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature);
            _outputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd14.PropertyName = "SoilTemperatureByLayers";
            pd14.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilTemperatureByLayers);
            _outputs0_0.Add(pd14);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SurfacePartonSoilSWATC.Strategies.SurfaceTemperatureParton).FullName);
            lAssStrat0_0.Add(typeof(SurfacePartonSoilSWATC.Strategies.SoilTemperatureSWAT).FullName);
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
            return new List<Type>() {  typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState), typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState), typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate), typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary), typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous)};
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
            get { return SurfacePartonSoilSWATC.Strategies.SoilTemperatureSWAT.LagCoefficientVarInfo;} 
        }

        public string TestPostConditions(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum.CurrentValue=a.SurfaceTemperatureMinimum;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum.CurrentValue=a.SurfaceTemperatureMaximum;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature.CurrentValue=s.SurfaceSoilTemperature;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilTemperatureByLayers.CurrentValue=s.SoilTemperatureByLayers;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r12 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
                if(r12.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
                if(r13.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature);
                if(r14.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilTemperatureByLayers);
                if(r15.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r15);}

                string ret = "";
                ret += _SurfaceTemperatureParton.TestPostConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATC.Strategies.SurfacePartonSoilSWATC");
                ret += _SoilTemperatureSWAT.TestPostConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATC.Strategies.SurfacePartonSoilSWATC");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .SurfacePartonSoilSWATC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength.CurrentValue=ex.DayLength;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum.CurrentValue=ex.AirTemperatureMaximum;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum.CurrentValue=ex.AirTemperatureMinimum;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass.CurrentValue=s.AboveGroundBiomass;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation.CurrentValue=ex.GlobalSolarRadiation;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.VolumetricWaterContent.CurrentValue=s.VolumetricWaterContent;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.LayerThickness.CurrentValue=s.LayerThickness;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage.CurrentValue=ex.AirTemperatureAnnualAverage;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.BulkDensity.CurrentValue=s.BulkDensity;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilProfileDepth.CurrentValue=s.SoilProfileDepth;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength);
                if(r1.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
                if(r2.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
                if(r3.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass);
                if(r4.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
                if(r5.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.VolumetricWaterContent);
                if(r6.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.VolumetricWaterContent.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.LayerThickness);
                if(r7.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.LayerThickness.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage);
                if(r8.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureAnnualAverage.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.BulkDensity);
                if(r9.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.BulkDensity.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilProfileDepth);
                if(r10.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SoilProfileDepth.ValueType)){prc.AddCondition(r10);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LagCoefficient")));
                string ret = "";
                ret += _SurfaceTemperatureParton.TestPreConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATC.Strategies.SurfacePartonSoilSWATC");
                ret += _SoilTemperatureSWAT.TestPreConditions(s, s1, r, a, ex, " strategy SurfacePartonSoilSWATC.Strategies.SurfacePartonSoilSWATC");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .SurfacePartonSoilSWATC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SurfacePartonSoilSWATC, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        SurfaceTemperatureParton _SurfaceTemperatureParton = new SurfaceTemperatureParton();
        SoilTemperatureSWAT _SoilTemperatureSWAT = new SoilTemperatureSWAT();

        private void EstimateOfAssociatedClasses(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex)
        {
            _surfacetemperatureparton.Estimate(s,s1, r, a, ex);
            _soiltemperatureswat.Estimate(s,s1, r, a, ex);
        }

        public SurfacePartonSoilSWATCComponent(SurfacePartonSoilSWATCComponent toCopy): this() // copy constructor 
        {
                LagCoefficient = toCopy.LagCoefficient;
        }
    }
}