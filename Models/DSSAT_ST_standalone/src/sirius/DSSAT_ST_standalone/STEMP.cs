
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
using SiriusQualitySTEMP_.DomainClass;
namespace SiriusQualitySTEMP_.Strategies
{
    public class STEMP : IStrategySiriusQualitySTEMP_
    {
        public STEMP()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new VarInfo();
            v1.DefaultValue = -1D;
            v1.Description = "Number of soil layers";
            v1.Id = 0;
            v1.MaxValue = -1D;
            v1.MinValue = -1D;
            v1.Name = "NL";
            v1.Size = 1;
            v1.Units = "dimensionless";
            v1.URL = "";
            v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v1.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v1);
            VarInfo v2 = new VarInfo();
            v2.DefaultValue = -1D;
            v2.Description = "Water simulation control switch";
            v2.Id = 0;
            v2.MaxValue = -1D;
            v2.MinValue = -1D;
            v2.Name = "ISWWAT";
            v2.Size = 1;
            v2.Units = "dimensionless";
            v2.URL = "";
            v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v2.ValueType = VarInfoValueTypes.GetInstanceForName("String");
            _parameters0_0.Add(v2);
            VarInfo v3 = new VarInfo();
            v3.DefaultValue = -1D;
            v3.Description = "Bulk density, soil layer NL";
            v3.Id = 0;
            v3.MaxValue = -1D;
            v3.MinValue = -1D;
            v3.Name = "BD";
            v3.Size = 1;
            v3.Units = "g [soil] / cm3 [soil]";
            v3.URL = "";
            v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v3.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v3);
            VarInfo v4 = new VarInfo();
            v4.DefaultValue = -1D;
            v4.Description = "Thickness of soil layer L";
            v4.Id = 0;
            v4.MaxValue = -1D;
            v4.MinValue = -1D;
            v4.Name = "DLAYR";
            v4.Size = 1;
            v4.Units = "cm";
            v4.URL = "";
            v4.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v4.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v4);
            VarInfo v5 = new VarInfo();
            v5.DefaultValue = -1D;
            v5.Description = "Cumulative depth in soil layer L";
            v5.Id = 0;
            v5.MaxValue = -1D;
            v5.MinValue = -1D;
            v5.Name = "DS";
            v5.Size = 1;
            v5.Units = "cm";
            v5.URL = "";
            v5.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v5.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v5);
            VarInfo v6 = new VarInfo();
            v6.DefaultValue = -1D;
            v6.Description = "Volumetric soil water content at Drained Upper Limit in soil layer L";
            v6.Id = 0;
            v6.MaxValue = -1D;
            v6.MinValue = -1D;
            v6.Name = "DUL";
            v6.Size = 1;
            v6.Units = "cm3[water]/cm3[soil]";
            v6.URL = "";
            v6.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v6.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v6);
            VarInfo v7 = new VarInfo();
            v7.DefaultValue = -1D;
            v7.Description = "Volumetric soil water content in soil layer L at lower limit";
            v7.Id = 0;
            v7.MaxValue = -1D;
            v7.MinValue = -1D;
            v7.Name = "LL";
            v7.Size = 1;
            v7.Units = "cm3 [water] / cm3 [soil]";
            v7.URL = "";
            v7.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v7.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v7);
            VarInfo v8 = new VarInfo();
            v8.DefaultValue = -1D;
            v8.Description = "Actual number of soil layers";
            v8.Id = 0;
            v8.MaxValue = -1D;
            v8.MinValue = -1D;
            v8.Name = "NLAYR";
            v8.Size = 1;
            v8.Units = "dimensionless";
            v8.URL = "";
            v8.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v8.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _parameters0_0.Add(v8);
            VarInfo v9 = new VarInfo();
            v9.DefaultValue = -1D;
            v9.Description = "Soil albedo with mulch and soil water effects";
            v9.Id = 0;
            v9.MaxValue = -1D;
            v9.MinValue = -1D;
            v9.Name = "MSALB";
            v9.Size = 1;
            v9.Units = "dimensionless";
            v9.URL = "";
            v9.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v9.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v9);
            VarInfo v10 = new VarInfo();
            v10.DefaultValue = -1D;
            v10.Description = "Volumetric soil water content in layer L";
            v10.Id = 0;
            v10.MaxValue = -1D;
            v10.MinValue = -1D;
            v10.Name = "SW";
            v10.Size = 1;
            v10.Units = "cm3 [water] / cm3 [soil]";
            v10.URL = "";
            v10.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v10.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v10);
            VarInfo v11 = new VarInfo();
            v11.DefaultValue = -1D;
            v11.Description = "Latitude";
            v11.Id = 0;
            v11.MaxValue = -1D;
            v11.MinValue = -1D;
            v11.Name = "XLAT";
            v11.Size = 1;
            v11.Units = "degC";
            v11.URL = "";
            v11.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v11.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(v11);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_Exogenous);
            pd1.PropertyName = "SRAD";
            pd1.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.SRAD).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.SRAD);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_Exogenous);
            pd2.PropertyName = "TAVG";
            pd2.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAVG).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAVG);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_Exogenous);
            pd3.PropertyName = "TMAX";
            pd3.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TMAX).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TMAX);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_Exogenous);
            pd4.PropertyName = "TAV";
            pd4.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAV).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAV);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_Exogenous);
            pd5.PropertyName = "TAMP";
            pd5.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAMP).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAMP);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd6.PropertyName = "CUMDPT";
            pd6.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd7.PropertyName = "DSMID";
            pd7.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.DSMID).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.DSMID);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd8.PropertyName = "TDL";
            pd8.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TDL).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TDL);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd9.PropertyName = "TMA";
            pd9.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TMA).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TMA);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd10.PropertyName = "ATOT";
            pd10.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ATOT).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ATOT);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd11.PropertyName = "SRFTEMP";
            pd11.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd12.PropertyName = "ST";
            pd12.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ST).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ST);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_Exogenous);
            pd13.PropertyName = "DOY";
            pd13.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.DOY).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.DOY);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd14.PropertyName = "HDAY";
            pd14.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.HDAY).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.HDAY);
            _inputs0_0.Add(pd14);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd15.PropertyName = "CUMDPT";
            pd15.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT);
            _outputs0_0.Add(pd15);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd16.PropertyName = "DSMID";
            pd16.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.DSMID).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.DSMID);
            _outputs0_0.Add(pd16);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd17.PropertyName = "TDL";
            pd17.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TDL).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TDL);
            _outputs0_0.Add(pd17);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd18.PropertyName = "TMA";
            pd18.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TMA).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TMA);
            _outputs0_0.Add(pd18);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd19.PropertyName = "ATOT";
            pd19.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ATOT).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ATOT);
            _outputs0_0.Add(pd19);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd20.PropertyName = "SRFTEMP";
            pd20.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP);
            _outputs0_0.Add(pd20);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State);
            pd21.PropertyName = "ST";
            pd21.PropertyType = (SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ST).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ST);
            _outputs0_0.Add(pd21);
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
            _pd.Add("Creator", "DSSAT ");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "DSSAT Florida "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State),  typeof(SiriusQualitySTEMP_.DomainClass.STEMP_State), typeof(SiriusQualitySTEMP_.DomainClass.STEMP_Rate), typeof(SiriusQualitySTEMP_.DomainClass.STEMP_Auxiliary), typeof(SiriusQualitySTEMP_.DomainClass.STEMP_Exogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public int NL
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("NL");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'NL' not found (or found null) in strategy 'STEMP'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("NL");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'NL' not found in strategy 'STEMP'");
            }
        }
        public string ISWWAT
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("ISWWAT");
                if (vi != null && vi.CurrentValue!=null) return (string)vi.CurrentValue ;
                else throw new Exception("Parameter 'ISWWAT' not found (or found null) in strategy 'STEMP'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("ISWWAT");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'ISWWAT' not found in strategy 'STEMP'");
            }
        }
        public double[] BD
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("BD");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'BD' not found (or found null) in strategy 'STEMP'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("BD");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'BD' not found in strategy 'STEMP'");
            }
        }
        public double[] DLAYR
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("DLAYR");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'DLAYR' not found (or found null) in strategy 'STEMP'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("DLAYR");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'DLAYR' not found in strategy 'STEMP'");
            }
        }
        public double[] DS
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("DS");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'DS' not found (or found null) in strategy 'STEMP'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("DS");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'DS' not found in strategy 'STEMP'");
            }
        }
        public double[] DUL
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("DUL");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'DUL' not found (or found null) in strategy 'STEMP'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("DUL");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'DUL' not found in strategy 'STEMP'");
            }
        }
        public double[] LL
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("LL");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'LL' not found (or found null) in strategy 'STEMP'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("LL");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'LL' not found in strategy 'STEMP'");
            }
        }
        public int NLAYR
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("NLAYR");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'NLAYR' not found (or found null) in strategy 'STEMP'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("NLAYR");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'NLAYR' not found in strategy 'STEMP'");
            }
        }
        public double MSALB
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("MSALB");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'MSALB' not found (or found null) in strategy 'STEMP'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("MSALB");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'MSALB' not found in strategy 'STEMP'");
            }
        }
        public double[] SW
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("SW");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'SW' not found (or found null) in strategy 'STEMP'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("SW");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'SW' not found in strategy 'STEMP'");
            }
        }
        public double XLAT
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("XLAT");
                if (vi != null && vi.CurrentValue!=null) return (double)vi.CurrentValue ;
                else throw new Exception("Parameter 'XLAT' not found (or found null) in strategy 'STEMP'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("XLAT");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'XLAT' not found in strategy 'STEMP'");
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            NLVarInfo.Name = "NL";
            NLVarInfo.Description = "Number of soil layers";
            NLVarInfo.MaxValue = -1D;
            NLVarInfo.MinValue = -1D;
            NLVarInfo.DefaultValue = -1D;
            NLVarInfo.Units = "dimensionless";
            NLVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            ISWWATVarInfo.Name = "ISWWAT";
            ISWWATVarInfo.Description = "Water simulation control switch";
            ISWWATVarInfo.MaxValue = -1D;
            ISWWATVarInfo.MinValue = -1D;
            ISWWATVarInfo.DefaultValue = -1D;
            ISWWATVarInfo.Units = "dimensionless";
            ISWWATVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("String");

            BDVarInfo.Name = "BD";
            BDVarInfo.Description = "Bulk density, soil layer NL";
            BDVarInfo.MaxValue = -1D;
            BDVarInfo.MinValue = -1D;
            BDVarInfo.DefaultValue = -1D;
            BDVarInfo.Units = "g [soil] / cm3 [soil]";
            BDVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            DLAYRVarInfo.Name = "DLAYR";
            DLAYRVarInfo.Description = "Thickness of soil layer L";
            DLAYRVarInfo.MaxValue = -1D;
            DLAYRVarInfo.MinValue = -1D;
            DLAYRVarInfo.DefaultValue = -1D;
            DLAYRVarInfo.Units = "cm";
            DLAYRVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            DSVarInfo.Name = "DS";
            DSVarInfo.Description = "Cumulative depth in soil layer L";
            DSVarInfo.MaxValue = -1D;
            DSVarInfo.MinValue = -1D;
            DSVarInfo.DefaultValue = -1D;
            DSVarInfo.Units = "cm";
            DSVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            DULVarInfo.Name = "DUL";
            DULVarInfo.Description = "Volumetric soil water content at Drained Upper Limit in soil layer L";
            DULVarInfo.MaxValue = -1D;
            DULVarInfo.MinValue = -1D;
            DULVarInfo.DefaultValue = -1D;
            DULVarInfo.Units = "cm3[water]/cm3[soil]";
            DULVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            LLVarInfo.Name = "LL";
            LLVarInfo.Description = "Volumetric soil water content in soil layer L at lower limit";
            LLVarInfo.MaxValue = -1D;
            LLVarInfo.MinValue = -1D;
            LLVarInfo.DefaultValue = -1D;
            LLVarInfo.Units = "cm3 [water] / cm3 [soil]";
            LLVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            NLAYRVarInfo.Name = "NLAYR";
            NLAYRVarInfo.Description = "Actual number of soil layers";
            NLAYRVarInfo.MaxValue = -1D;
            NLAYRVarInfo.MinValue = -1D;
            NLAYRVarInfo.DefaultValue = -1D;
            NLAYRVarInfo.Units = "dimensionless";
            NLAYRVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            MSALBVarInfo.Name = "MSALB";
            MSALBVarInfo.Description = "Soil albedo with mulch and soil water effects";
            MSALBVarInfo.MaxValue = -1D;
            MSALBVarInfo.MinValue = -1D;
            MSALBVarInfo.DefaultValue = -1D;
            MSALBVarInfo.Units = "dimensionless";
            MSALBVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            SWVarInfo.Name = "SW";
            SWVarInfo.Description = "Volumetric soil water content in layer L";
            SWVarInfo.MaxValue = -1D;
            SWVarInfo.MinValue = -1D;
            SWVarInfo.DefaultValue = -1D;
            SWVarInfo.Units = "cm3 [water] / cm3 [soil]";
            SWVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            XLATVarInfo.Name = "XLAT";
            XLATVarInfo.Description = "Latitude";
            XLATVarInfo.MaxValue = -1D;
            XLATVarInfo.MinValue = -1D;
            XLATVarInfo.DefaultValue = -1D;
            XLATVarInfo.Units = "degC";
            XLATVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        private static VarInfo _NLVarInfo = new VarInfo();
        public static VarInfo NLVarInfo
        {
            get { return _NLVarInfo;} 
        }

        private static VarInfo _ISWWATVarInfo = new VarInfo();
        public static VarInfo ISWWATVarInfo
        {
            get { return _ISWWATVarInfo;} 
        }

        private static VarInfo _BDVarInfo = new VarInfo();
        public static VarInfo BDVarInfo
        {
            get { return _BDVarInfo;} 
        }

        private static VarInfo _DLAYRVarInfo = new VarInfo();
        public static VarInfo DLAYRVarInfo
        {
            get { return _DLAYRVarInfo;} 
        }

        private static VarInfo _DSVarInfo = new VarInfo();
        public static VarInfo DSVarInfo
        {
            get { return _DSVarInfo;} 
        }

        private static VarInfo _DULVarInfo = new VarInfo();
        public static VarInfo DULVarInfo
        {
            get { return _DULVarInfo;} 
        }

        private static VarInfo _LLVarInfo = new VarInfo();
        public static VarInfo LLVarInfo
        {
            get { return _LLVarInfo;} 
        }

        private static VarInfo _NLAYRVarInfo = new VarInfo();
        public static VarInfo NLAYRVarInfo
        {
            get { return _NLAYRVarInfo;} 
        }

        private static VarInfo _MSALBVarInfo = new VarInfo();
        public static VarInfo MSALBVarInfo
        {
            get { return _MSALBVarInfo;} 
        }

        private static VarInfo _SWVarInfo = new VarInfo();
        public static VarInfo SWVarInfo
        {
            get { return _SWVarInfo;} 
        }

        private static VarInfo _XLATVarInfo = new VarInfo();
        public static VarInfo XLATVarInfo
        {
            get { return _XLATVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitySTEMP_.DomainClass.STEMP_State s,SiriusQualitySTEMP_.DomainClass.STEMP_State s1,SiriusQualitySTEMP_.DomainClass.STEMP_Rate r,SiriusQualitySTEMP_.DomainClass.STEMP_Auxiliary a,SiriusQualitySTEMP_.DomainClass.STEMP_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT.CurrentValue=s.CUMDPT;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.DSMID.CurrentValue=s.DSMID;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TDL.CurrentValue=s.TDL;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TMA.CurrentValue=s.TMA;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ATOT.CurrentValue=s.ATOT;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP.CurrentValue=s.SRFTEMP;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ST.CurrentValue=s.ST;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r26 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT);
                if(r26.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.DSMID);
                if(r27.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.DSMID.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TDL);
                if(r28.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TDL.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TMA);
                if(r29.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TMA.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ATOT);
                if(r30.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ATOT.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP);
                if(r31.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP.ValueType)){prc.AddCondition(r31);}
                RangeBasedCondition r32 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ST);
                if(r32.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ST.ValueType)){prc.AddCondition(r32);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.STEMP_, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitySTEMP_.DomainClass.STEMP_State s,SiriusQualitySTEMP_.DomainClass.STEMP_State s1,SiriusQualitySTEMP_.DomainClass.STEMP_Rate r,SiriusQualitySTEMP_.DomainClass.STEMP_Auxiliary a,SiriusQualitySTEMP_.DomainClass.STEMP_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.SRAD.CurrentValue=ex.SRAD;
                SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAVG.CurrentValue=ex.TAVG;
                SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TMAX.CurrentValue=ex.TMAX;
                SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAV.CurrentValue=ex.TAV;
                SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAMP.CurrentValue=ex.TAMP;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT.CurrentValue=s.CUMDPT;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.DSMID.CurrentValue=s.DSMID;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TDL.CurrentValue=s.TDL;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TMA.CurrentValue=s.TMA;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ATOT.CurrentValue=s.ATOT;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP.CurrentValue=s.SRFTEMP;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ST.CurrentValue=s.ST;
                SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.DOY.CurrentValue=ex.DOY;
                SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.HDAY.CurrentValue=s.HDAY;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.SRAD);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.SRAD.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAVG);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAVG.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TMAX);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TMAX.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAV);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAV.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAMP);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.TAMP.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.DSMID);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.DSMID.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TDL);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TDL.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TMA);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.TMA.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ATOT);
                if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ATOT.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP);
                if(r11.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ST);
                if(r12.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.ST.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.DOY);
                if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_ExogenousVarInfo.DOY.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.HDAY);
                if(r14.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_.DomainClass.STEMP_StateVarInfo.HDAY.ValueType)){prc.AddCondition(r14);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("NL")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ISWWAT")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("BD")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DLAYR")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DS")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DUL")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LL")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("NLAYR")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("MSALB")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SW")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("XLAT")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "SiriusQuality.STEMP_, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitySTEMP_.DomainClass.STEMP_State s,SiriusQualitySTEMP_.DomainClass.STEMP_State s1,SiriusQualitySTEMP_.DomainClass.STEMP_Rate r,SiriusQualitySTEMP_.DomainClass.STEMP_Auxiliary a,SiriusQualitySTEMP_.DomainClass.STEMP_Exogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitySTEMP_, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        public void Init(SiriusQualitySTEMP_.DomainClass.STEMP_State s, SiriusQualitySTEMP_.DomainClass.STEMP_State s1, SiriusQualitySTEMP_.DomainClass.STEMP_Rate r, SiriusQualitySTEMP_.DomainClass.STEMP_Auxiliary a, SiriusQualitySTEMP_.DomainClass.STEMP_Exogenous ex)
        {
            double SRAD;
            double TAVG;
            double TMAX;
            double TAV;
            double TAMP;
            int DOY;
            double CUMDPT;
            double[] DSMID =  new double [NL];
            double TDL;
            double[] TMA =  new double [5];
            double ATOT;
            double SRFTEMP;
            double[] ST =  new double [NL];
            double HDAY;
            CUMDPT = 0.00d;
            DSMID = new double[NL];
            TDL = 0.00d;
            TMA = new double[5];
            ATOT = 0.00d;
            SRFTEMP = 0.00d;
            ST = new double[NL];
            HDAY = 0.00d;
            int I;
            int L;
            double ABD;
            double ALBEDO;
            double B;
            double DP;
            double FX;
            double PESW;
            double TBD;
            double WW;
            double TLL;
            double TSW;
            double[] DLI =  new double [NL];
            double[] DSI =  new double [NL];
            double[] SWI =  new double [NL];
            SWI = SW;
            DSI = DS;
            if (XLAT < 0.00d)
            {
                HDAY = 20.00d;
            }
            else
            {
                HDAY = 200.00d;
            }
            TBD = 0.00d;
            TLL = 0.00d;
            TSW = 0.00d;
            TDL = 0.00d;
            CUMDPT = 0.00d;
            for (L=1 ; L!=NLAYR + 1 ; L+=1)
            {
                if (L == 1)
                {
                    DLI[L - 1] = DSI[L - 1];
                }
                else
                {
                    DLI[L - 1] = DSI[L - 1] - DSI[L - 1 - 1];
                }
                DSMID[L - 1] = CUMDPT + (DLI[(L - 1)] * 5.00d);
                CUMDPT = CUMDPT + (DLI[(L - 1)] * 10.00d);
                TBD = TBD + (BD[(L - 1)] * DLI[(L - 1)]);
                TLL = TLL + (LL[(L - 1)] * DLI[(L - 1)]);
                TSW = TSW + (SWI[(L - 1)] * DLI[(L - 1)]);
                TDL = TDL + (DUL[(L - 1)] * DLI[(L - 1)]);
            }
            if (ISWWAT == "Y")
            {
                PESW = Math.Max(0.00d, TSW - TLL);
            }
            else
            {
                PESW = Math.Max(0.00d, TDL - TLL);
            }
            ABD = TBD / DSI[(NLAYR - 1)];
            FX = ABD / (ABD + (686.00d * Math.Exp(-(5.630d * ABD))));
            DP = 1000.00d + (2500.00d * FX);
            WW = 0.3560d - (0.1440d * ABD);
            B = Math.Log(500.00d / DP);
            ALBEDO = MSALB;
            for (I=1 ; I!=5 + 1 ; I+=1)
            {
                TMA[I - 1] = (int)(TAVG * 10000.0d) / 10000.0d;
            }
            ATOT = TMA[(1 - 1)] * 5.00d;
            for (L=1 ; L!=NLAYR + 1 ; L+=1)
            {
                ST[L - 1] = TAVG;
            }
            for (I=1 ; I!=8 + 1 ; I+=1)
            {
                Tuple.Create(ATOT, TMA, SRFTEMP, ST) = SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA);
            }
            s.CUMDPT= CUMDPT;
            s.DSMID= DSMID;
            s.TDL= TDL;
            s.TMA= TMA;
            s.ATOT= ATOT;
            s.SRFTEMP= SRFTEMP;
            s.ST= ST;
            s.HDAY= HDAY;
        }

        private void CalculateModel(SiriusQualitySTEMP_.DomainClass.STEMP_State s, SiriusQualitySTEMP_.DomainClass.STEMP_State s1, SiriusQualitySTEMP_.DomainClass.STEMP_Rate r, SiriusQualitySTEMP_.DomainClass.STEMP_Auxiliary a, SiriusQualitySTEMP_.DomainClass.STEMP_Exogenous ex)
        {
            double SRAD = ex.SRAD;
            double TAVG = ex.TAVG;
            double TMAX = ex.TMAX;
            double TAV = ex.TAV;
            double TAMP = ex.TAMP;
            double CUMDPT = s.CUMDPT;
            double[] DSMID = s.DSMID;
            double TDL = s.TDL;
            double[] TMA = s.TMA;
            double ATOT = s.ATOT;
            double SRFTEMP = s.SRFTEMP;
            double[] ST = s.ST;
            int DOY = ex.DOY;
            double HDAY = s.HDAY;
            int L;
            double ABD;
            double ALBEDO;
            double B;
            double DP;
            double FX;
            double PESW;
            double TBD;
            double WW;
            double TLL;
            double TSW;
            TBD = 0.00d;
            TLL = 0.00d;
            TSW = 0.00d;
            for (L=1 ; L!=NLAYR + 1 ; L+=1)
            {
                TBD = TBD + (BD[(L - 1)] * DLAYR[(L - 1)]);
                TDL = TDL + (DUL[(L - 1)] * DLAYR[(L - 1)]);
                TLL = TLL + (LL[(L - 1)] * DLAYR[(L - 1)]);
                TSW = TSW + (SW[(L - 1)] * DLAYR[(L - 1)]);
            }
            ABD = TBD / DS[(NLAYR - 1)];
            FX = ABD / (ABD + (686.00d * Math.Exp(-(5.630d * ABD))));
            DP = 1000.00d + (2500.00d * FX);
            WW = 0.3560d - (0.1440d * ABD);
            B = Math.Log(500.00d / DP);
            ALBEDO = MSALB;
            if (ISWWAT == "Y")
            {
                PESW = Math.Max(0.00d, TSW - TLL);
            }
            else
            {
                PESW = Math.Max(0.00d, TDL - TLL);
            }
            Tuple.Create(ATOT, TMA, SRFTEMP, ST) = SOILT(NL, ALBEDO, B, CUMDPT, DOY, DP, HDAY, NLAYR, PESW, SRAD, TAMP, TAV, TAVG, TMAX, WW, DSMID, ATOT, TMA);
            s.CUMDPT= CUMDPT;
            s.DSMID= DSMID;
            s.TDL= TDL;
            s.TMA= TMA;
            s.ATOT= ATOT;
            s.SRFTEMP= SRFTEMP;
            s.ST= ST;
        }

        public static Tuple<double,double[],double,double[]>  SOILT(int NL, double ALBEDO, double B, double CUMDPT, int DOY, double DP, double HDAY, int NLAYR, double PESW, double SRAD, double TAMP, double TAV, double TAVG, double TMAX, double WW, double[] DSMID, double ATOT, double[] TMA)
        {
            int K;
            int L;
            double ALX;
            double DD;
            double DT;
            double FX;
            double SRFTEMP;
            double TA;
            double WC;
            double ZD;
            double[] ST =  new double [NL];
            ALX = ((double)(DOY) - HDAY) * 0.01740d;
            ATOT = ATOT - TMA[5 - 1];
            for (K=5 ; K!=2 - 1 ; K+=-1)
            {
                TMA[K - 1] = TMA[K - 1 - 1];
            }
            TMA[1 - 1] = TAVG;
            TMA[1 - 1] = (int)(TMA[(1 - 1)] * 10000.0d) / 10000.0d;
            ATOT = ATOT + TMA[1 - 1];
            WC = Math.Max(0.010d, PESW) / (WW * CUMDPT) * 10.00d;
            FX = Math.Exp(B * Math.Pow((1.00d - WC) / (1.00d + WC), 2));
            DD = FX * DP;
            TA = TAV + (TAMP * Math.Cos(ALX) / 2.00d);
            DT = ATOT / 5.00d - TA;
            for (L=1 ; L!=NLAYR + 1 ; L+=1)
            {
                ZD = -(DSMID[(L - 1)] / DD);
                ST[L - 1] = TAV + ((TAMP / 2.00d * Math.Cos((ALX + ZD)) + DT) * Math.Exp(ZD));
                ST[L - 1] = (int)(ST[(L - 1)] * 1000.0d) / 1000.0d;
            }
            SRFTEMP = TAV + (TAMP / 2.0d * Math.Cos(ALX) + DT);
            return Tuple.Create(ATOT, TMA, SRFTEMP, ST);
        }

    }
}