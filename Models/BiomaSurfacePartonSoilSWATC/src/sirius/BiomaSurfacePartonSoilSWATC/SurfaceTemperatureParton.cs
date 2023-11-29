
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
    public class SurfaceTemperatureParton : IStrategySiriusQualitySurfacePartonSoilSWATC
    {
        public SurfaceTemperatureParton()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd1.PropertyName = "DayLength";
            pd1.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd2.PropertyName = "AirTemperatureMaximum";
            pd2.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd3.PropertyName = "AirTemperatureMinimum";
            pd3.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd4.PropertyName = "AboveGroundBiomass";
            pd4.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AboveGroundBiomass).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AboveGroundBiomass);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd5.PropertyName = "GlobalSolarRadiation";
            pd5.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
            _inputs0_0.Add(pd5);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary);
            pd6.PropertyName = "SurfaceTemperatureMinimum";
            pd6.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
            _outputs0_0.Add(pd6);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary);
            pd7.PropertyName = "SurfaceTemperatureMaximum";
            pd7.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
            _outputs0_0.Add(pd7);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary);
            pd8.PropertyName = "SurfaceSoilTemperature";
            pd8.PropertyType = (SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature);
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
            get { return "Strategy for the calculation of soil surface temperature with Parton's method. Reference: Parton, W. J. 1984. Predicting soil temperatures in a shortgrass steppe. Soil Science 138:93-101." ;}
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
            return new List<Type>() {  typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState),  typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState), typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate), typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary), typeof(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.


        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {
        }

        public string TestPostConditions(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum.CurrentValue=a.SurfaceTemperatureMinimum;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum.CurrentValue=a.SurfaceTemperatureMaximum;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature.CurrentValue=a.SurfaceSoilTemperature;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature.ValueType)){prc.AddCondition(r8);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.SurfacePartonSoilSWATC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength.CurrentValue=ex.DayLength;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum.CurrentValue=ex.AirTemperatureMaximum;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum.CurrentValue=ex.AirTemperatureMinimum;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AboveGroundBiomass.CurrentValue=ex.AboveGroundBiomass;
                SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation.CurrentValue=ex.GlobalSolarRadiation;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AboveGroundBiomass);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AboveGroundBiomass.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation.ValueType)){prc.AddCondition(r5);}
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.SurfacePartonSoilSWATC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
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

        private void CalculateModel(SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s, SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1, SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r, SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a, SiriusQualitySurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex)
        {
            double DayLength = ex.DayLength;
            double AirTemperatureMaximum = ex.AirTemperatureMaximum;
            double AirTemperatureMinimum = ex.AirTemperatureMinimum;
            double AboveGroundBiomass = ex.AboveGroundBiomass;
            double GlobalSolarRadiation = ex.GlobalSolarRadiation;
            double SurfaceTemperatureMinimum;
            double SurfaceTemperatureMaximum;
            double SurfaceSoilTemperature;
            double _AGB;
            double _AirTMax;
            double _AirTmin;
            double _SolarRad;
            _AGB = AboveGroundBiomass / 10000;
            _AirTMax = AirTemperatureMaximum;
            _AirTmin = AirTemperatureMinimum;
            _SolarRad = GlobalSolarRadiation;
            if (_AGB > 0.150d)
            {
                SurfaceTemperatureMaximum = _AirTMax + ((24 * (1 - Math.Exp(-0.0380d * _SolarRad)) + (0.350d * _AirTMax)) * (Math.Exp(-4.80d * _AGB) - 0.130d));
                SurfaceTemperatureMinimum = _AirTmin + (6 * _AGB) - 1.820d;
            }
            else
            {
                SurfaceTemperatureMaximum = AirTemperatureMaximum;
                SurfaceTemperatureMinimum = AirTemperatureMinimum;
            }
            SurfaceSoilTemperature = 0.410d * SurfaceTemperatureMaximum + (0.590d * SurfaceTemperatureMinimum);
            if (DayLength != (double)(0))
            {
                SurfaceSoilTemperature = DayLength / 24 * _AirTMax + ((1 - (DayLength / 24)) * _AirTmin);
            }
            a.SurfaceTemperatureMinimum= SurfaceTemperatureMinimum;
            a.SurfaceTemperatureMaximum= SurfaceTemperatureMaximum;
            a.SurfaceSoilTemperature= SurfaceSoilTemperature;
        }

    }
}