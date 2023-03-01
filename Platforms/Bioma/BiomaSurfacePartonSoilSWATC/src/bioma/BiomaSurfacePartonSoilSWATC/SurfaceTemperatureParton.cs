
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
    public class SurfaceTemperatureParton : IStrategySurfacePartonSoilSWATC
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
            pd1.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd1.PropertyName = "AboveGroundBiomass";
            pd1.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd2.PropertyName = "GlobalSolarRadiation";
            pd2.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd3.PropertyName = "AirTemperatureMinimum";
            pd3.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary);
            pd4.PropertyName = "SurfaceTemperatureMaximum";
            pd4.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd5.PropertyName = "DayLength";
            pd5.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary);
            pd6.PropertyName = "SurfaceTemperatureMinimum";
            pd6.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous);
            pd7.PropertyName = "AirTemperatureMaximum";
            pd7.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
            _inputs0_0.Add(pd7);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState);
            pd8.PropertyName = "SurfaceSoilTemperature";
            pd8.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature);
            _outputs0_0.Add(pd8);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary);
            pd9.PropertyName = "SurfaceTemperatureMaximum";
            pd9.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
            _outputs0_0.Add(pd9);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary);
            pd10.PropertyName = "SurfaceTemperatureMinimum";
            pd10.PropertyType = (SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
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
            return new List<Type>() {  typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState),  typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState), typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate), typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary), typeof(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.


        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {
        }

        public string TestPostConditions(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature.CurrentValue=s.SurfaceSoilTemperature;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum.CurrentValue=a.SurfaceTemperatureMaximum;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum.CurrentValue=a.SurfaceTemperatureMinimum;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r8 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature);
                if(r8.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.SurfaceSoilTemperature.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
                if(r9.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
                if(r10.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum.ValueType)){prc.AddCondition(r10);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".SurfacePartonSoilSWATC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a,SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass.CurrentValue=s.AboveGroundBiomass;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation.CurrentValue=ex.GlobalSolarRadiation;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum.CurrentValue=ex.AirTemperatureMinimum;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum.CurrentValue=a.SurfaceTemperatureMaximum;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength.CurrentValue=ex.DayLength;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum.CurrentValue=a.SurfaceTemperatureMinimum;
                SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum.CurrentValue=ex.AirTemperatureMaximum;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass);
                if(r1.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCStateVarInfo.AboveGroundBiomass.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
                if(r2.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.GlobalSolarRadiation.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
                if(r3.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMinimum.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum);
                if(r4.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMaximum.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength);
                if(r5.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.DayLength.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum);
                if(r6.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliaryVarInfo.SurfaceTemperatureMinimum.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
                if(r7.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenousVarInfo.AirTemperatureMaximum.ValueType)){prc.AddCondition(r7);}
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".SurfacePartonSoilSWATC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
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

        private void CalculateModel(SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s, SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCState s1, SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCRate r, SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCAuxiliary a, SurfacePartonSoilSWATC.DomainClass.SurfacePartonSoilSWATCExogenous ex)
        {
            double AboveGroundBiomass = s.AboveGroundBiomass;
            double GlobalSolarRadiation = ex.GlobalSolarRadiation;
            double AirTemperatureMinimum = ex.AirTemperatureMinimum;
            double SurfaceTemperatureMaximum = a.SurfaceTemperatureMaximum;
            double DayLength = ex.DayLength;
            double SurfaceTemperatureMinimum = a.SurfaceTemperatureMinimum;
            double AirTemperatureMaximum = ex.AirTemperatureMaximum;
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
            a.SurfaceTemperatureMaximum= SurfaceTemperatureMaximum;
            a.SurfaceTemperatureMinimum= SurfaceTemperatureMinimum;
            s.SurfaceSoilTemperature= SurfaceSoilTemperature;
        }

    }
}