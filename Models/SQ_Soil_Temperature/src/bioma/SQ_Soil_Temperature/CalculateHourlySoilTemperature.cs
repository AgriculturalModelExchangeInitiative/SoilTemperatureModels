
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
    public class CalculateHourlySoilTemperature : IStrategySoilTemperature
    {
        public CalculateHourlySoilTemperature()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = 1.81;
            v1.Description = "Delay between sunrise and time when minimum temperature is reached";
            v1.Id = 0;
            v1.MaxValue = 10;
            v1.MinValue = 0;
            v1.Name = "b";
            v1.Size = 1;
            v1.Units = "Hour";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = 0.5;
            v2.Description = "Delay between sunset and time when maximum temperature is reached";
            v2.Id = 0;
            v2.MaxValue = 10;
            v2.MinValue = 0;
            v2.Name = "a";
            v2.Size = 1;
            v2.Units = "Hour";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = 0.49;
            v3.Description = "Nighttime temperature coefficient";
            v3.Id = 0;
            v3.MaxValue = 10;
            v3.MinValue = 0;
            v3.Name = "c";
            v3.Size = 1;
            v3.Units = "Dpmensionless";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v3);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureState);
            pd1.PropertyName = "minTSoil";
            pd1.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureExogenous);
            pd2.PropertyName = "dayLength";
            pd2.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.dayLength).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.dayLength);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureState);
            pd3.PropertyName = "maxTSoil";
            pd3.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil);
            _inputs0_0.Add(pd3);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SoilTemperature.DomainClass.SoilTemperatureState);
            pd4.PropertyName = "hourlySoilT";
            pd4.PropertyType = (SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.hourlySoilT).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.hourlySoilT);
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
            get { return "Calculate Soil temperature on a hourly basis.Parton, W.J. and Logan, J.A., 1981. A model for diurnal variation in soil and air temperature. Agric. Meteorol., 23: 205-216" ;}
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

        public double b
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("b");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'b' not found (or found null) in strategy 'CalculateHourlySoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("b");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'b' not found in strategy 'CalculateHourlySoilTemperature'");
            }
        }
        public double a
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("a");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'a' not found (or found null) in strategy 'CalculateHourlySoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("a");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'a' not found in strategy 'CalculateHourlySoilTemperature'");
            }
        }
        public double c
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("c");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'c' not found (or found null) in strategy 'CalculateHourlySoilTemperature'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("c");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'c' not found in strategy 'CalculateHourlySoilTemperature'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            bVarInfo.Name = "b";
            bVarInfo.Description = "Delay between sunrise and time when minimum temperature is reached";
            bVarInfo.MaxValue = 10;
            bVarInfo.MinValue = 0;
            bVarInfo.DefaultValue = 1.81;
            bVarInfo.Units = "Hour";
            bVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            aVarInfo.Name = "a";
            aVarInfo.Description = "Delay between sunset and time when maximum temperature is reached";
            aVarInfo.MaxValue = 10;
            aVarInfo.MinValue = 0;
            aVarInfo.DefaultValue = 0.5;
            aVarInfo.Units = "Hour";
            aVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            cVarInfo.Name = "c";
            cVarInfo.Description = "Nighttime temperature coefficient";
            cVarInfo.MaxValue = 10;
            cVarInfo.MinValue = 0;
            cVarInfo.DefaultValue = 0.49;
            cVarInfo.Units = "Dpmensionless";
            cVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _bVarInfo = new VarInfo();
        public static VarInfo bVarInfo
        {
            get { return _bVarInfo;} 
        }

        private static VarInfo _aVarInfo = new VarInfo();
        public static VarInfo aVarInfo
        {
            get { return _aVarInfo;} 
        }

        private static VarInfo _cVarInfo = new VarInfo();
        public static VarInfo cVarInfo
        {
            get { return _cVarInfo;} 
        }

        public string TestPostConditions(SoilTemperature.DomainClass.SoilTemperatureState s,SoilTemperature.DomainClass.SoilTemperatureState s1,SoilTemperature.DomainClass.SoilTemperatureRate r,SoilTemperature.DomainClass.SoilTemperatureAuxiliary a,SoilTemperature.DomainClass.SoilTemperatureExogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.hourlySoilT.CurrentValue=s.hourlySoilT;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r7 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.hourlySoilT);
                if(r7.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.hourlySoilT.ValueType)){prc.AddCondition(r7);}
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
                SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil.CurrentValue=s.minTSoil;
                SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.dayLength.CurrentValue=ex.dayLength;
                SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil.CurrentValue=s.maxTSoil;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil);
                if(r1.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.minTSoil.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.dayLength);
                if(r2.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureExogenousVarInfo.dayLength.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil);
                if(r3.ApplicableVarInfoValueTypes.Contains( SoilTemperature.DomainClass.SoilTemperatureStateVarInfo.maxTSoil.ValueType)){prc.AddCondition(r3);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("b")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("a")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("c")));
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
            double minTSoil = s.minTSoil;
            double dayLength = ex.dayLength;
            double maxTSoil = s.maxTSoil;
            double[] hourlySoilT =  new double [24];
            int i;
            if (maxTSoil == (double)(-999) && minTSoil == (double)(999))
            {
                for (i=0 ; i!=12 ; i+=1)
                {
                    hourlySoilT[i] = (double)(999);
                }
                for (i=12 ; i!=24 ; i+=1)
                {
                    hourlySoilT[i] = (double)(-999);
                }
            }
            else
            {
                for (i=0 ; i!=24 ; i+=1)
                {
                    hourlySoilT[i] = 0.00d;
                }
                hourlySoilT = getHourlySoilSurfaceTemperature(maxTSoil, minTSoil, dayLength, b, a, c);
            }
            s.hourlySoilT= hourlySoilT;
        }

        public static double[] getHourlySoilSurfaceTemperature(double TMax, double TMin, double ady, double b, double a, double c)
        {
            int i;
            double[] result =  new double [24];
            double ahou;
            double ani;
            double bb;
            double be;
            double bbd;
            double ddy;
            double tsn;
            ahou = Math.PI * (ady / 24.00d);
            ani = 24 - ady;
            bb = 12 - (ady / 2) + c;
            be = 12 + (ady / 2);
            for (i=0 ; i!=24 ; i+=1)
            {
                if (i >= (int)(bb) && i <= (int)(be))
                {
                    result[i] = (TMax - TMin) * Math.Sin(3.140d * (i - bb) / (ady + (2 * a))) + TMin;
                }
                else
                {
                    if (i > (int)(be))
                    {
                        bbd = i - be;
                    }
                    else
                    {
                        bbd = 24 + be + i;
                    }
                    ddy = ady - c;
                    tsn = (TMax - TMin) * Math.Sin(3.140d * ddy / (ady + (2 * a))) + TMin;
                    result[i] = TMin + ((tsn - TMin) * Math.Exp(-b * bbd / ani));
                }
            }
            return result;
        }

    }
}