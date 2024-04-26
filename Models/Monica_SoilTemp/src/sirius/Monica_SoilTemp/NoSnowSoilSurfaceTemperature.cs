
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
using SiriusQualitySoilTemperatureComp.DomainClass;
namespace SiriusQualitySoilTemperatureComp.Strategies
{
    public class NoSnowSoilSurfaceTemperature : IStrategySiriusQualitySoilTemperatureComp
    {
        public NoSnowSoilSurfaceTemperature()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 0.8;
            v1.Description = "dampingFactor";
            v1.Id = 0;
            v1.MaxValue = -1D;
            v1.MinValue = -1D;
            v1.Name = "dampingFactor";
            v1.Size = 1;
            v1.Units = "dimensionless";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenous);
            pd1.PropertyName = "tmin";
            pd1.PropertyType = (SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.tmin).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.tmin);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenous);
            pd2.PropertyName = "tmax";
            pd2.PropertyType = (SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.tmax).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.tmax);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenous);
            pd3.PropertyName = "globrad";
            pd3.PropertyType = (SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.globrad).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.globrad);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenous);
            pd4.PropertyName = "soilCoverage";
            pd4.PropertyType = (SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.soilCoverage).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.soilCoverage);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompState);
            pd5.PropertyName = "soilSurfaceTemperature";
            pd5.PropertyType = (SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompStateVarInfo.soilSurfaceTemperature).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompStateVarInfo.soilSurfaceTemperature);
            _inputs0_0.Add(pd5);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompState);
            pd6.PropertyName = "soilSurfaceTemperature";
            pd6.PropertyType = (SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompStateVarInfo.soilSurfaceTemperature).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompStateVarInfo.soilSurfaceTemperature);
            _outputs0_0.Add(pd6);
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
            _pd.Add("Creator", "Michael Berg-Mohnicke");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "ZALF e.V. "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompState),  typeof(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompState), typeof(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompRate), typeof(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompAuxiliary), typeof(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double dampingFactor
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("dampingFactor");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'dampingFactor' not found (or found null) in strategy 'NoSnowSoilSurfaceTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("dampingFactor");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'dampingFactor' not found in strategy 'NoSnowSoilSurfaceTemperature'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            dampingFactorVarInfo.Name = "dampingFactor";
            dampingFactorVarInfo.Description = "dampingFactor";
            dampingFactorVarInfo.MaxValue = -1D;
            dampingFactorVarInfo.MinValue = -1D;
            dampingFactorVarInfo.DefaultValue = 0.8;
            dampingFactorVarInfo.Units = "dimensionless";
            dampingFactorVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _dampingFactorVarInfo = new VarInfo();
        public static VarInfo dampingFactorVarInfo
        {
            get { return _dampingFactorVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompState s,SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompState s1,SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompRate r,SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompAuxiliary a,SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompStateVarInfo.soilSurfaceTemperature.CurrentValue=s.soilSurfaceTemperature;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompStateVarInfo.soilSurfaceTemperature);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompStateVarInfo.soilSurfaceTemperature.ValueType)){prc.AddCondition(r7);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.SoilTemperatureComp, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompState s,SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompState s1,SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompRate r,SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompAuxiliary a,SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.tmin.CurrentValue=ex.tmin;
                SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.tmax.CurrentValue=ex.tmax;
                SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.globrad.CurrentValue=ex.globrad;
                SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.soilCoverage.CurrentValue=ex.soilCoverage;
                SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompStateVarInfo.soilSurfaceTemperature.CurrentValue=s.soilSurfaceTemperature;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.tmin);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.tmin.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.tmax);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.tmax.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.globrad);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.globrad.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.soilCoverage);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenousVarInfo.soilCoverage.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompStateVarInfo.soilSurfaceTemperature);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompStateVarInfo.soilSurfaceTemperature.ValueType)){prc.AddCondition(r5);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("dampingFactor")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.SoilTemperatureComp, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompState s,SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompState s1,SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompRate r,SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompAuxiliary a,SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitySoilTemperatureComp, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompState s, SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompState s1, SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompRate r, SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompAuxiliary a, SiriusQualitySoilTemperatureComp.DomainClass.SoilTemperatureCompExogenous ex)
        {
            double tmin = ex.tmin;
            double tmax = ex.tmax;
            double globrad = ex.globrad;
            double soilCoverage = ex.soilCoverage;
            double soilSurfaceTemperature = s.soilSurfaceTemperature;
            double shadingCoefficient;
            globrad = Math.Max(8.330d, globrad);
            shadingCoefficient = 0.10d + (soilCoverage * dampingFactor + ((1 - soilCoverage) * (1 - dampingFactor)));
            soilSurfaceTemperature = (1.00d - shadingCoefficient) * (tmin + ((tmax - tmin) * Math.Pow(0.030d * globrad, 0.50d))) + (shadingCoefficient * soilSurfaceTemperature);
            if (soilSurfaceTemperature < 0.00d)
            {
                soilSurfaceTemperature = soilSurfaceTemperature * 0.50d;
            }
            s.soilSurfaceTemperature= soilSurfaceTemperature;
        }

    }
}