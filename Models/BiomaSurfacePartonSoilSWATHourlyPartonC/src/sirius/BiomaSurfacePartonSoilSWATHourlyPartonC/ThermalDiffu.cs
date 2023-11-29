
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
using SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass;
namespace SiriusQualitySurfacePartonSoilSWATHourlyPartonC.Strategies
{
    public class ThermalDiffu : IStrategySiriusQualitySurfacePartonSoilSWATHourlyPartonC
    {
        public ThermalDiffu()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 10;
            v1.Description = "Number of layersl";
            v1.Id = 0;
            v1.MaxValue = 300;
            v1.MinValue = 0;
            v1.Name = "layersNumber";
            v1.Size = 1;
            v1.Units = "dimensionless";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v1);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd1.PropertyName = "ThermalDiffusivity";
            pd1.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd2.PropertyName = "ThermalConductivity";
            pd2.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd3.PropertyName = "HeatCapacity";
            pd3.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.HeatCapacity).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.HeatCapacity);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd4.PropertyName = "ThermalDiffusivity";
            pd4.PropertyType = (SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity);
            _outputs0_0.Add(pd4);
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
            get { return "Strategy for the calculation of thermal diffusitivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series" ;}
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
            return new List<Type>() {  typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState),  typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState), typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate), typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary), typeof(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public int layersNumber
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("layersNumber");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'layersNumber' not found (or found null) in strategy 'ThermalDiffu'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("layersNumber");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'layersNumber' not found in strategy 'ThermalDiffu'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            layersNumberVarInfo.Name = "layersNumber";
            layersNumberVarInfo.Description = "Number of layersl";
            layersNumberVarInfo.MaxValue = 300;
            layersNumberVarInfo.MinValue = 0;
            layersNumberVarInfo.DefaultValue = 10;
            layersNumberVarInfo.Units = "dimensionless";
            layersNumberVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
        }

        private static VarInfo _layersNumberVarInfo = new VarInfo();
        public static VarInfo layersNumberVarInfo
        {
            get { return _layersNumberVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity.CurrentValue=s.ThermalDiffusivity;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity.ValueType)){prc.AddCondition(r5);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.SurfacePartonSoilSWATHourlyPartonC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity.CurrentValue=s.ThermalDiffusivity;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity.CurrentValue=a.ThermalConductivity;
                SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.HeatCapacity.CurrentValue=a.HeatCapacity;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.ThermalDiffusivity.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.ThermalConductivity.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.HeatCapacity);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.HeatCapacity.ValueType)){prc.AddCondition(r3);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("layersNumber")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.SurfacePartonSoilSWATHourlyPartonC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitySurfacePartonSoilSWATHourlyPartonC, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s, SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1, SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r, SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SiriusQualitySurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
        {
            double[] ThermalDiffusivity = s.ThermalDiffusivity;
            double[] ThermalConductivity = a.ThermalConductivity;
            double[] HeatCapacity = a.HeatCapacity;
            int i;
            for (i=0 ; i!=layersNumber ; i+=1)
            {
                ThermalDiffusivity[i] = ThermalConductivity[i] / HeatCapacity[i] / 100;
            }
            s.ThermalDiffusivity= ThermalDiffusivity;
        }

    }
}