
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
    public class SurfaceTemperatureSWAT : IStrategySiriusQualitySurfaceSWATSoilSWATC
    {
        public SurfaceTemperatureSWAT()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd1.PropertyName = "GlobalSolarRadiation";
            pd1.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary);
            pd2.PropertyName = "SoilTemperatureByLayers";
            pd2.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SoilTemperatureByLayers).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SoilTemperatureByLayers);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd3.PropertyName = "AirTemperatureMaximum";
            pd3.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd4.PropertyName = "AirTemperatureMinimum";
            pd4.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd5.PropertyName = "Albedo";
            pd5.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary);
            pd6.PropertyName = "AboveGroundBiomass";
            pd6.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.AboveGroundBiomass).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.AboveGroundBiomass);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous);
            pd7.PropertyName = "WaterEquivalentOfSnowPack";
            pd7.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack);
            _inputs0_0.Add(pd7);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary);
            pd8.PropertyName = "SurfaceSoilTemperature";
            pd8.PropertyType = (SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature);
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
            get { return "Strategy for the calculation of surface soil temperature with SWAT method. Reference: Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf" ;}
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


        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {
        }

        public string TestPostConditions(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a,SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature.CurrentValue=a.SurfaceSoilTemperature;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SurfaceSoilTemperature.ValueType)){prc.AddCondition(r8);}
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
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation.CurrentValue=ex.GlobalSolarRadiation;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SoilTemperatureByLayers.CurrentValue=a.SoilTemperatureByLayers;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum.CurrentValue=ex.AirTemperatureMaximum;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum.CurrentValue=ex.AirTemperatureMinimum;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo.CurrentValue=ex.Albedo;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.AboveGroundBiomass.CurrentValue=a.AboveGroundBiomass;
                SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack.CurrentValue=ex.WaterEquivalentOfSnowPack;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.GlobalSolarRadiation.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SoilTemperatureByLayers);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.SoilTemperatureByLayers.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMaximum.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.AirTemperatureMinimum.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.Albedo.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.AboveGroundBiomass);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliaryVarInfo.AboveGroundBiomass.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenousVarInfo.WaterEquivalentOfSnowPack.ValueType)){prc.AddCondition(r7);}
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

        private void CalculateModel(SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s, SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCState s1, SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCRate r, SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCAuxiliary a, SiriusQualitySurfaceSWATSoilSWATC.DomainClass.SurfaceSWATSoilSWATCExogenous ex)
        {
            double GlobalSolarRadiation = ex.GlobalSolarRadiation;
            double[] SoilTemperatureByLayers = a.SoilTemperatureByLayers;
            double AirTemperatureMaximum = ex.AirTemperatureMaximum;
            double AirTemperatureMinimum = ex.AirTemperatureMinimum;
            double Albedo = ex.Albedo;
            double AboveGroundBiomass = a.AboveGroundBiomass;
            double WaterEquivalentOfSnowPack = ex.WaterEquivalentOfSnowPack;
            double SurfaceSoilTemperature;
            double _Tavg;
            double _Hterm;
            double _Tbare;
            double _WeightingCover;
            double _WeightingSnow;
            double _WeightingActual;
            _Tavg = (AirTemperatureMaximum + AirTemperatureMinimum) / 2;
            _Hterm = (GlobalSolarRadiation * (1 - Albedo) - 14) / 20;
            _Tbare = _Tavg + (_Hterm * (AirTemperatureMaximum - AirTemperatureMinimum) / 2);
            _WeightingCover = AboveGroundBiomass / (AboveGroundBiomass + Math.Exp(7.5630d - (0.00012970d * AboveGroundBiomass)));
            _WeightingSnow = WaterEquivalentOfSnowPack / (WaterEquivalentOfSnowPack + Math.Exp(6.0550d - (0.30020d * WaterEquivalentOfSnowPack)));
            _WeightingActual = Math.Max(_WeightingCover, _WeightingSnow);
            SurfaceSoilTemperature = _WeightingActual * SoilTemperatureByLayers[0] + ((1 - _WeightingActual) * _Tbare);
            a.SurfaceSoilTemperature= SurfaceSoilTemperature;
        }

    }
}