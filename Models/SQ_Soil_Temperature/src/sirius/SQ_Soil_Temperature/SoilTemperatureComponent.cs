
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

using SiriusQualitySoilTemperature.DomainClass;
namespace SiriusQualitySoilTemperature.Strategies
{
    public class SoilTemperatureComponent : IStrategySiriusQualitySoilTemperature
    {
        public SoilTemperatureComponent()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_CalculateSoilTemperature, "lambda_");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_CalculateHourlySoilTemperature, "b");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_CalculateHourlySoilTemperature, "c");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_CalculateHourlySoilTemperature, "a");
            _parameters0_0.Add(v4);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous);
            pd1.PropertyName = "meanTAir";
            pd1.PropertyType = (SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanTAir).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanTAir);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous);
            pd2.PropertyName = "minTAir";
            pd2.PropertyType = (SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.minTAir).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.minTAir);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous);
            pd3.PropertyName = "meanAnnualAirTemp";
            pd3.PropertyType = (SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanAnnualAirTemp).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanAnnualAirTemp);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRate);
            pd4.PropertyName = "heatFlux";
            pd4.PropertyType = (SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRateVarInfo.heatFlux).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRateVarInfo.heatFlux);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous);
            pd5.PropertyName = "maxTAir";
            pd5.PropertyType = (SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.maxTAir).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.maxTAir);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous);
            pd6.PropertyName = "dayLength";
            pd6.PropertyType = (SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.dayLength).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.dayLength);
            _inputs0_0.Add(pd6);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState);
            pd7.PropertyName = "minTSoil";
            pd7.PropertyType = (SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil);
            _outputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState);
            pd8.PropertyName = "deepLayerT";
            pd8.PropertyType = (SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT);
            _outputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState);
            pd9.PropertyName = "maxTSoil";
            pd9.PropertyType = (SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil);
            _outputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState);
            pd10.PropertyName = "hourlySoilT";
            pd10.PropertyType = (SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.hourlySoilT).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.hourlySoilT);
            _outputs0_0.Add(pd10);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SiriusQualitySoilTemperature.Strategies.CalculateSoilTemperature).FullName);
            lAssStrat0_0.Add(typeof(SiriusQualitySoilTemperature.Strategies.CalculateHourlySoilTemperature).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);
            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();
        }

        public string Description
        {
            get { return "Composite Class for soil temperature" ;}
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
            _pd.Add("Creator", "loic.manceau@inra.fr");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "INRA "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState), typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState), typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRate), typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureAuxiliary), typeof(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous)};
        }

        public double lambda_
        {
            get
            {
                 return _CalculateSoilTemperature.lambda_; 
            }
            set
            {
                _CalculateSoilTemperature.lambda_ = value;
            }
        }
        public double b
        {
            get
            {
                 return _CalculateHourlySoilTemperature.b; 
            }
            set
            {
                _CalculateHourlySoilTemperature.b = value;
            }
        }
        public double c
        {
            get
            {
                 return _CalculateHourlySoilTemperature.c; 
            }
            set
            {
                _CalculateHourlySoilTemperature.c = value;
            }
        }
        public double a
        {
            get
            {
                 return _CalculateHourlySoilTemperature.a; 
            }
            set
            {
                _CalculateHourlySoilTemperature.a = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _CalculateSoilTemperature.SetParametersDefaultValue();
            _CalculateHourlySoilTemperature.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            lambda_VarInfo.Name = "lambda_";
            lambda_VarInfo.Description = "Latente heat of water vaporization at 20Â°C";
            lambda_VarInfo.MaxValue = 10;
            lambda_VarInfo.MinValue = 0;
            lambda_VarInfo.DefaultValue = 2.454;
            lambda_VarInfo.Units = "MJ.kg-1";
            lambda_VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            bVarInfo.Name = "b";
            bVarInfo.Description = "Delay between sunrise and time when minimum temperature is reached";
            bVarInfo.MaxValue = 10;
            bVarInfo.MinValue = 0;
            bVarInfo.DefaultValue = 1.81;
            bVarInfo.Units = "Hour";
            bVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            cVarInfo.Name = "c";
            cVarInfo.Description = "Nighttime temperature coefficient";
            cVarInfo.MaxValue = 10;
            cVarInfo.MinValue = 0;
            cVarInfo.DefaultValue = 0.49;
            cVarInfo.Units = "Dpmensionless";
            cVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            aVarInfo.Name = "a";
            aVarInfo.Description = "Delay between sunset and time when maximum temperature is reached";
            aVarInfo.MaxValue = 10;
            aVarInfo.MinValue = 0;
            aVarInfo.DefaultValue = 0.5;
            aVarInfo.Units = "Hour";
            aVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        public static VarInfo lambda_VarInfo
        {
            get { return SiriusQualitySoilTemperature.Strategies.CalculateSoilTemperature.lambda_VarInfo;} 
        }

        public static VarInfo bVarInfo
        {
            get { return SiriusQualitySoilTemperature.Strategies.CalculateHourlySoilTemperature.bVarInfo;} 
        }

        public static VarInfo cVarInfo
        {
            get { return SiriusQualitySoilTemperature.Strategies.CalculateHourlySoilTemperature.cVarInfo;} 
        }

        public static VarInfo aVarInfo
        {
            get { return SiriusQualitySoilTemperature.Strategies.CalculateHourlySoilTemperature.aVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s1,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRate r,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureAuxiliary a,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil.CurrentValue=s.minTSoil;
                SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT.CurrentValue=s.deepLayerT;
                SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil.CurrentValue=s.maxTSoil;
                SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.hourlySoilT.CurrentValue=s.hourlySoilT;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r11 = new RangeBasedCondition(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil);
                if(r11.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT);
                if(r12.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil);
                if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.hourlySoilT);
                if(r14.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperature.DomainClass.SoilTemperatureStateVarInfo.hourlySoilT.ValueType)){prc.AddCondition(r14);}

                string ret = "";
                ret += _CalculateSoilTemperature.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySoilTemperature.Strategies.SoilTemperature");
                ret += _CalculateHourlySoilTemperature.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySoilTemperature.Strategies.SoilTemperature");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.SoilTemperature, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s1,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRate r,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureAuxiliary a,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanTAir.CurrentValue=ex.meanTAir;
                SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.minTAir.CurrentValue=ex.minTAir;
                SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanAnnualAirTemp.CurrentValue=ex.meanAnnualAirTemp;
                SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRateVarInfo.heatFlux.CurrentValue=r.heatFlux;
                SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.maxTAir.CurrentValue=ex.maxTAir;
                SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.dayLength.CurrentValue=ex.dayLength;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanTAir);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanTAir.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.minTAir);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.minTAir.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanAnnualAirTemp);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanAnnualAirTemp.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRateVarInfo.heatFlux);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRateVarInfo.heatFlux.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.maxTAir);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.maxTAir.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.dayLength);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.dayLength.ValueType)){prc.AddCondition(r6);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("lambda_")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("b")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("c")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("a")));
                string ret = "";
                ret += _CalculateSoilTemperature.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySoilTemperature.Strategies.SoilTemperature");
                ret += _CalculateHourlySoilTemperature.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySoilTemperature.Strategies.SoilTemperature");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.SoilTemperature, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s1,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRate r,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureAuxiliary a,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitySoilTemperature, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s1,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRate r,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureAuxiliary a,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        CalculateSoilTemperature _CalculateSoilTemperature = new CalculateSoilTemperature();
        CalculateHourlySoilTemperature _CalculateHourlySoilTemperature = new CalculateHourlySoilTemperature();

        private void EstimateOfAssociatedClasses(SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureState s1,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureRate r,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureAuxiliary a,SiriusQualitySoilTemperature.DomainClass.SoilTemperatureExogenous ex)
        {
            _CalculateSoilTemperature.Estimate(s,s1, r, a, ex);
            _CalculateHourlySoilTemperature.Estimate(s,s1, r, a, ex);
        }

        public SoilTemperatureComponent(SoilTemperatureComponent toCopy): this() // copy constructor 
        {
                lambda_ = toCopy.lambda_;
                b = toCopy.b;
                c = toCopy.c;
                a = toCopy.a;
        }
    }
}