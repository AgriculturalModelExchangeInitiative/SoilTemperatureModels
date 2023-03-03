
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
using SoilTemperature.DomainClass;
namespace SoilTemperature.Strategies
{
    public class CalculateSoilTemperature : IStrategySoilTemperature
    {
        public CalculateSoilTemperature()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 2.454;
            v1.Description = "Latente heat of water vaporization at 20°C";
            v1.Id = 0;
            v1.MaxValue = 10;
            v1.MinValue = 0;
            v1.Name = "lambda_";
            v1.Size = 1;
            v1.Units = "MJ.kg-1";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureState);
            pd1.PropertyName = "deepLayerT";
            pd1.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureRate);
            pd2.PropertyName = "heatFlux";
            pd2.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureRateVarInfo.heatFlux).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureRateVarInfo.heatFlux);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureExogenous);
            pd3.PropertyName = "meanTAir";
            pd3.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanTAir).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanTAir);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureExogenous);
            pd4.PropertyName = "minTAir";
            pd4.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.minTAir).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.minTAir);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureState);
            pd5.PropertyName = "deepLayerT";
            pd5.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureExogenous);
            pd6.PropertyName = "maxTAir";
            pd6.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.maxTAir).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.maxTAir);
            _inputs0_0.Add(pd6);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureState);
            pd7.PropertyName = "deepLayerT";
            pd7.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT);
            _outputs0_0.Add(pd7);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureState);
            pd8.PropertyName = "maxTSoil";
            pd8.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil);
            _outputs0_0.Add(pd8);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureState);
            pd9.PropertyName = "minTSoil";
            pd9.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil);
            _outputs0_0.Add(pd9);
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
            get { return "Calculation of minimum and maximum Soil temperature, Further used in shoot temperature estimate." ;}
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
            return new List<Type>() {  typeof(SoilTemperature.DomainClass.SoilTemperatureState),  typeof(SoilTemperature.DomainClass.SoilTemperatureState), typeof(SoilTemperature.DomainClass.SoilTemperatureRate), typeof(SoilTemperature.DomainClass.SoilTemperatureAuxiliary), typeof(SoilTemperature.DomainClass.SoilTemperatureExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double lambda_
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("lambda_");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'lambda_' not found (or found null) in strategy 'CalculateSoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("lambda_");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'lambda_' not found in strategy 'CalculateSoilTemperature'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            lambda_VarInfo.Name = "lambda_";
            lambda_VarInfo.Description = "Latente heat of water vaporization at 20°C";
            lambda_VarInfo.MaxValue = 10;
            lambda_VarInfo.MinValue = 0;
            lambda_VarInfo.DefaultValue = 2.454;
            lambda_VarInfo.Units = "MJ.kg-1";
            lambda_VarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _lambda_VarInfo = new VarInfo();
        public static VarInfo lambda_VarInfo
        {
            get { return _lambda_VarInfo;} 
        }

        public string TestPostConditions(SoilTemperature.DomainClass.SoilTemperatureState s,SoilTemperature.DomainClass.SoilTemperatureState s1,SoilTemperature.DomainClass.SoilTemperatureRate r,SoilTemperature.DomainClass.SoilTemperatureAuxiliary a,SoilTemperature.DomainClass.SoilTemperatureExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT_t1.CurrentValue=s.deepLayerT_t1;
                SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil.CurrentValue=s.maxTSoil;
                SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil.CurrentValue=s.minTSoil;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r8 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT_t1);
                if(r8.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT_t1.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil);
                if(r9.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil);
                if(r10.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil.ValueType)){prc.AddCondition(r10);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".SoilTemperature, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SoilTemperature.DomainClass.SoilTemperatureState s,SoilTemperature.DomainClass.SoilTemperatureState s1,SoilTemperature.DomainClass.SoilTemperatureRate r,SoilTemperature.DomainClass.SoilTemperatureAuxiliary a,SoilTemperature.DomainClass.SoilTemperatureExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT.CurrentValue=s.deepLayerT;
                SoilTemperature.DomainClass.SoilTemperatureRateVarInfo.heatFlux.CurrentValue=r.heatFlux;
                SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanTAir.CurrentValue=ex.meanTAir;
                SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.minTAir.CurrentValue=ex.minTAir;
                SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT.CurrentValue=s.deepLayerT;
                SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.maxTAir.CurrentValue=ex.maxTAir;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT);
                if(r1.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureRateVarInfo.heatFlux);
                if(r2.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureRateVarInfo.heatFlux.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanTAir);
                if(r3.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.meanTAir.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.minTAir);
                if(r4.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.minTAir.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT);
                if(r5.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.deepLayerT.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.maxTAir);
                if(r6.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.maxTAir.ValueType)){prc.AddCondition(r6);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("lambda_")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".SoilTemperature, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SoilTemperature.DomainClass.SoilTemperatureState s,SoilTemperature.DomainClass.SoilTemperatureState s1,SoilTemperature.DomainClass.SoilTemperatureRate r,SoilTemperature.DomainClass.SoilTemperatureAuxiliary a,SoilTemperature.DomainClass.SoilTemperatureExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SoilTemperature, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SoilTemperature.DomainClass.SoilTemperatureState s, SoilTemperature.DomainClass.SoilTemperatureState s1, SoilTemperature.DomainClass.SoilTemperatureRate r, SoilTemperature.DomainClass.SoilTemperatureAuxiliary a, SoilTemperature.DomainClass.SoilTemperatureExogenous ex)
        {
            double deepLayerT = s.deepLayerT;
            double heatFlux = r.heatFlux;
            double meanTAir = ex.meanTAir;
            double minTAir = ex.minTAir;
            double deepLayerT_t1 = s1.deepLayerT;
            double maxTAir = ex.maxTAir;
            double maxTSoil;
            double minTSoil;
            if (maxTAir == (double)(-999) && minTAir == (double)(999))
            {
                minTSoil = (double)(999);
                maxTSoil = (double)(-999);
                deepLayerT_t1 = 0.00d;
            }
            else
            {
                minTSoil = SoilMinimumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT);
                maxTSoil = SoilMaximumTemperature(maxTAir, meanTAir, minTAir, heatFlux, lambda_, deepLayerT_t1);
                deepLayerT_t1 = UpdateTemperature(minTSoil, maxTSoil, deepLayerT);
            }
            s.deepLayerT_t1= deepLayerT_t1;
            s.maxTSoil= maxTSoil;
            s.minTSoil= minTSoil;
        }

        public static double SoilTempB(double weatherMinTemp, double deepTemperature)
        {
            return (weatherMinTemp + deepTemperature) / 2.00d;
        }

        public static double SoilTempA(double weatherMaxTemp, double weatherMeanTemp, double soilHeatFlux, double lambda_)
        {
            double TempAdjustment;
            double SoilAvailableEnergy;
            TempAdjustment = weatherMeanTemp < 8.00d ? -0.50d * weatherMeanTemp + 4.00d : (double)(0);
            SoilAvailableEnergy = soilHeatFlux * lambda_ / 1000;
            return weatherMaxTemp + (11.20d * (1.00d - Math.Exp(-0.070d * (SoilAvailableEnergy - 5.50d)))) + TempAdjustment;
        }

        public static double SoilMinimumTemperature(double weatherMaxTemp, double weatherMeanTemp, double weatherMinTemp, double soilHeatFlux, double lambda_, double deepTemperature)
        {
            return Math.Min(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature));
        }

        public static double SoilMaximumTemperature(double weatherMaxTemp, double weatherMeanTemp, double weatherMinTemp, double soilHeatFlux, double lambda_, double deepTemperature)
        {
            return Math.Max(SoilTempA(weatherMaxTemp, weatherMeanTemp, soilHeatFlux, lambda_), SoilTempB(weatherMinTemp, deepTemperature));
        }

        public static double UpdateTemperature(double minSoilTemp, double maxSoilTemp, double Temperature)
        {
            double meanTemp;
            meanTemp = (minSoilTemp + maxSoilTemp) / 2.00d;
            Temperature = (9.00d * Temperature + meanTemp) / 10.00d;
            return Temperature;
        }

    }
}