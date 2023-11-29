
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
using SurfacePartonSoilSWATHourlyPartonC.DomainClass;
namespace SurfacePartonSoilSWATHourlyPartonC.Strategies
{
    public class VolumetricHeatCapacityKluitenberg : IStrategySurfacePartonSoilSWATHourlyPartonC
    {
        public VolumetricHeatCapacityKluitenberg()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = -1D;
            v1.Description = "Clay content of soil layer";
            v1.Id = 0;
            v1.MaxValue = -1D;
            v1.MinValue = -1D;
            v1.Name = "Clay";
            v1.Size = 1;
            v1.Units = "";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = -1D;
            v2.Description = "Silt content of soil layer";
            v2.Id = 0;
            v2.MaxValue = -1D;
            v2.MinValue = -1D;
            v2.Name = "Silt";
            v2.Size = 1;
            v2.Units = "";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v2);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd1.PropertyName = "VolumetricWaterContent";
            pd1.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd2.PropertyName = "Sand";
            pd2.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd3.PropertyName = "BulkDensity";
            pd3.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.BulkDensity).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.BulkDensity);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary);
            pd4.PropertyName = "OrganicMatter";
            pd4.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd5.PropertyName = "HeatCapacity";
            pd5.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity);
            _inputs0_0.Add(pd5);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState);
            pd6.PropertyName = "HeatCapacity";
            pd6.PropertyType = (SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity);
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
            get { return "Strategy for the calculation of soil thermal diffusivity. Reference: J.M.H.Hendrickx, H. Xie, B. Borchers, J.B.J. Harrison, 2008. Global Prediction of Thermal Soil Regimes. SPIE Proceedings Volume 6953 Detection and Sensing of Mines, Explosive Objects, and Obscured Targets XIII." ;}
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
            return new List<Type>() {  typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState),  typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState), typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate), typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary), typeof(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public double[] Clay
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("Clay");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'Clay' not found (or found null) in strategy 'VolumetricHeatCapacityKluitenberg'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("Clay");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'Clay' not found in strategy 'VolumetricHeatCapacityKluitenberg'");
            }
        }
        public double[] Silt
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("Silt");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'Silt' not found (or found null) in strategy 'VolumetricHeatCapacityKluitenberg'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("Silt");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'Silt' not found in strategy 'VolumetricHeatCapacityKluitenberg'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            ClayVarInfo.Name = "Clay";
            ClayVarInfo.Description = "Clay content of soil layer";
            ClayVarInfo.MaxValue = -1D;
            ClayVarInfo.MinValue = -1D;
            ClayVarInfo.DefaultValue = -1D;
            ClayVarInfo.Units = "";
            ClayVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            SiltVarInfo.Name = "Silt";
            SiltVarInfo.Description = "Silt content of soil layer";
            SiltVarInfo.MaxValue = -1D;
            SiltVarInfo.MinValue = -1D;
            SiltVarInfo.DefaultValue = -1D;
            SiltVarInfo.Units = "";
            SiltVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
        }

        private static VarInfo _ClayVarInfo = new VarInfo();
        public static VarInfo ClayVarInfo
        {
            get { return _ClayVarInfo;} 
        }

        private static VarInfo _SiltVarInfo = new VarInfo();
        public static VarInfo SiltVarInfo
        {
            get { return _SiltVarInfo;} 
        }

        public string TestPostConditions(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity.CurrentValue=s.HeatCapacity;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r8 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity);
                if(r8.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity.ValueType)){prc.AddCondition(r8);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".SurfacePartonSoilSWATHourlyPartonC, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent.CurrentValue=a.VolumetricWaterContent;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand.CurrentValue=a.Sand;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.BulkDensity.CurrentValue=a.BulkDensity;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter.CurrentValue=a.OrganicMatter;
                SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity.CurrentValue=s.HeatCapacity;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent);
                if(r1.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.VolumetricWaterContent.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand);
                if(r2.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.Sand.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.BulkDensity);
                if(r3.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.BulkDensity.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter);
                if(r4.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliaryVarInfo.OrganicMatter.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity);
                if(r5.ApplicableVarInfoValueTypes.Contains( SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCStateVarInfo.HeatCapacity.ValueType)){prc.AddCondition(r5);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Clay")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("Silt")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".SurfacePartonSoilSWATHourlyPartonC, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a,SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SurfacePartonSoilSWATHourlyPartonC, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s, SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCState s1, SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCRate r, SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCAuxiliary a, SurfacePartonSoilSWATHourlyPartonC.DomainClass.SurfacePartonSoilSWATHourlyPartonCExogenous ex)
        {
            double[] VolumetricWaterContent = a.VolumetricWaterContent;
            double[] Sand = a.Sand;
            double[] BulkDensity = a.BulkDensity;
            double[] OrganicMatter = a.OrganicMatter;
            double[] HeatCapacity = s.HeatCapacity;
            int i;
            double SandFraction;
            double SiltFraction;
            double ClayFraction;
            double FractionMinerals;
            double OrganicMatterFraction;
            SandFraction = (double)(0);
            SiltFraction = (double)(0);
            ClayFraction = (double)(0);
            FractionMinerals = (double)(0);
            OrganicMatterFraction = (double)(0);
            for (i=0 ; i!=HeatCapacity.Length ; i+=1)
            {
                SandFraction = Sand[i] / (Sand[i] + Silt[i] + Clay[i] + OrganicMatter[i]);
                SiltFraction = Silt[i] / (Sand[i] + Silt[i] + Clay[i] + OrganicMatter[i]);
                ClayFraction = Clay[i] / (Sand[i] + Silt[i] + Clay[i] + OrganicMatter[i]);
                FractionMinerals = SandFraction + SiltFraction + ClayFraction;
                OrganicMatterFraction = OrganicMatter[i] / (Sand[i] + Silt[i] + Clay[i] + OrganicMatter[i]);
                HeatCapacity[i] = BulkDensity[i] * 0.730d * FractionMinerals + (BulkDensity[i] * 1.90d * OrganicMatterFraction) + (4.180d * VolumetricWaterContent[i]);
            }
            s.HeatCapacity= HeatCapacity;
        }

    }
}