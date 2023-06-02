
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
using STEMP_EPIC_.DomainClass;
namespace STEMP_EPIC_.Strategies
{
    public class STEMP_EPIC : IStrategySTEMP_EPIC_
    {
        public STEMP_EPIC()
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
            v2.Description = "Water simulation control switch (Y or N)";
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
            v4.Description = "Thickness of soil layer NL";
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
            v5.Description = "Cumulative depth in soil layer NL";
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
            v7.Description = "Volumetric soil water content in soil layer NL at lower limit";
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
            v9.Description = "Volumetric soil water content in layer NL";
            v9.Id = 0;
            v9.MaxValue = -1D;
            v9.MinValue = -1D;
            v9.Name = "SW";
            v9.Size = 1;
            v9.Units = "cm3 [water] / cm3 [soil]";
            v9.URL = "";
            v9.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            v9.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _parameters0_0.Add(v9);
            mo0_0.Parameters=_parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd1.PropertyName = "TAMP";
            pd1.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAMP).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAMP);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd2.PropertyName = "RAIN";
            pd2.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.RAIN).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.RAIN);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd3.PropertyName = "TAVG";
            pd3.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAVG).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAVG);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd4.PropertyName = "TMAX";
            pd4.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMAX).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMAX);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd5.PropertyName = "TMIN";
            pd5.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMIN).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMIN);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd6.PropertyName = "TAV";
            pd6.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAV).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAV);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd7.PropertyName = "CUMDPT";
            pd7.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd8.PropertyName = "DSMID";
            pd8.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd9.PropertyName = "TDL";
            pd9.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd10.PropertyName = "TMA";
            pd10.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd11.PropertyName = "NDays";
            pd11.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd12.PropertyName = "WetDay";
            pd12.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd13.PropertyName = "X2_PREV";
            pd13.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd14.PropertyName = "SRFTEMP";
            pd14.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP);
            _inputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd15.PropertyName = "ST";
            pd15.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST);
            _inputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd16.PropertyName = "DEPIR";
            pd16.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.DEPIR).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.DEPIR);
            _inputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd17.PropertyName = "BIOMAS";
            pd17.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.BIOMAS).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.BIOMAS);
            _inputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd18.PropertyName = "MULCHMASS";
            pd18.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.MULCHMASS).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.MULCHMASS);
            _inputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd19.PropertyName = "SNOW";
            pd19.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.SNOW).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.SNOW);
            _inputs0_0.Add(pd19);
            mo0_0.Inputs=_inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd20.PropertyName = "CUMDPT";
            pd20.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT);
            _outputs0_0.Add(pd20);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd21.PropertyName = "DSMID";
            pd21.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID);
            _outputs0_0.Add(pd21);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd22 = new PropertyDescription();
            pd22.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd22.PropertyName = "TDL";
            pd22.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL).ValueType.TypeForCurrentValue;
            pd22.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL);
            _outputs0_0.Add(pd22);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd23 = new PropertyDescription();
            pd23.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd23.PropertyName = "TMA";
            pd23.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA).ValueType.TypeForCurrentValue;
            pd23.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA);
            _outputs0_0.Add(pd23);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd24 = new PropertyDescription();
            pd24.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd24.PropertyName = "NDays";
            pd24.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays).ValueType.TypeForCurrentValue;
            pd24.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays);
            _outputs0_0.Add(pd24);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd25 = new PropertyDescription();
            pd25.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd25.PropertyName = "WetDay";
            pd25.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay).ValueType.TypeForCurrentValue;
            pd25.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay);
            _outputs0_0.Add(pd25);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd26 = new PropertyDescription();
            pd26.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd26.PropertyName = "X2_PREV";
            pd26.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV).ValueType.TypeForCurrentValue;
            pd26.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV);
            _outputs0_0.Add(pd26);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd27 = new PropertyDescription();
            pd27.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd27.PropertyName = "SRFTEMP";
            pd27.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP).ValueType.TypeForCurrentValue;
            pd27.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP);
            _outputs0_0.Add(pd27);
            mo0_0.Outputs=_outputs0_0;PropertyDescription pd28 = new PropertyDescription();
            pd28.DomainClassType = typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd28.PropertyName = "ST";
            pd28.PropertyType = (STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST).ValueType.TypeForCurrentValue;
            pd28.PropertyVarInfo =(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST);
            _outputs0_0.Add(pd28);
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
            get { return "" ;}
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
            _pd.Add("Creator", "Kenneth N. Potter , Jimmy R. Williams ");
            _pd.Add("Date", "");
            _pd.Add("Publisher", "USDA-ARS, USDA-ARS "); 
        }

        private ModellingOptionsManager _modellingOptionsManager;
        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; } 
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() {  typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State),  typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_State), typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Rate), typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Auxiliary), typeof(STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous)};
        }

        // Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

        public int NL
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("NL");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'NL' not found (or found null) in strategy 'STEMP_EPIC'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("NL");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'NL' not found in strategy 'STEMP_EPIC'");
            }
        }
        public string ISWWAT
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("ISWWAT");
                if (vi != null && vi.CurrentValue!=null) return (string)vi.CurrentValue ;
                else throw new Exception("Parameter 'ISWWAT' not found (or found null) in strategy 'STEMP_EPIC'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("ISWWAT");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'ISWWAT' not found in strategy 'STEMP_EPIC'");
            }
        }
        public double[] BD
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("BD");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'BD' not found (or found null) in strategy 'STEMP_EPIC'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("BD");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'BD' not found in strategy 'STEMP_EPIC'");
            }
        }
        public double[] DLAYR
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("DLAYR");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'DLAYR' not found (or found null) in strategy 'STEMP_EPIC'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("DLAYR");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'DLAYR' not found in strategy 'STEMP_EPIC'");
            }
        }
        public double[] DS
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("DS");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'DS' not found (or found null) in strategy 'STEMP_EPIC'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("DS");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'DS' not found in strategy 'STEMP_EPIC'");
            }
        }
        public double[] DUL
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("DUL");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'DUL' not found (or found null) in strategy 'STEMP_EPIC'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("DUL");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'DUL' not found in strategy 'STEMP_EPIC'");
            }
        }
        public double[] LL
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("LL");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'LL' not found (or found null) in strategy 'STEMP_EPIC'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("LL");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'LL' not found in strategy 'STEMP_EPIC'");
            }
        }
        public int NLAYR
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("NLAYR");
                if (vi != null && vi.CurrentValue!=null) return (int)vi.CurrentValue ;
                else throw new Exception("Parameter 'NLAYR' not found (or found null) in strategy 'STEMP_EPIC'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("NLAYR");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'NLAYR' not found in strategy 'STEMP_EPIC'");
            }
        }
        public double[] SW
        {
            get { 
                VarInfo vi= _modellingOptionsManager.GetParameterByName("SW");
                if (vi != null && vi.CurrentValue!=null) return (double[])vi.CurrentValue ;
                else throw new Exception("Parameter 'SW' not found (or found null) in strategy 'STEMP_EPIC'");
            } set {
                VarInfo vi = _modellingOptionsManager.GetParameterByName("SW");
                if (vi != null)  vi.CurrentValue=value;
                else throw new Exception("Parameter 'SW' not found in strategy 'STEMP_EPIC'");
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
            ISWWATVarInfo.Description = "Water simulation control switch (Y or N)";
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
            DLAYRVarInfo.Description = "Thickness of soil layer NL";
            DLAYRVarInfo.MaxValue = -1D;
            DLAYRVarInfo.MinValue = -1D;
            DLAYRVarInfo.DefaultValue = -1D;
            DLAYRVarInfo.Units = "cm";
            DLAYRVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            DSVarInfo.Name = "DS";
            DSVarInfo.Description = "Cumulative depth in soil layer NL";
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
            LLVarInfo.Description = "Volumetric soil water content in soil layer NL at lower limit";
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

            SWVarInfo.Name = "SW";
            SWVarInfo.Description = "Volumetric soil water content in layer NL";
            SWVarInfo.MaxValue = -1D;
            SWVarInfo.MinValue = -1D;
            SWVarInfo.DefaultValue = -1D;
            SWVarInfo.Units = "cm3 [water] / cm3 [soil]";
            SWVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
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

        private static VarInfo _SWVarInfo = new VarInfo();
        public static VarInfo SWVarInfo
        {
            get { return _SWVarInfo;} 
        }

        public string TestPostConditions(STEMP_EPIC_.DomainClass.STEMP_EPIC_State s,STEMP_EPIC_.DomainClass.STEMP_EPIC_State s1,STEMP_EPIC_.DomainClass.STEMP_EPIC_Rate r,STEMP_EPIC_.DomainClass.STEMP_EPIC_Auxiliary a,STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT.CurrentValue=s.CUMDPT;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID.CurrentValue=s.DSMID;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL.CurrentValue=s.TDL;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA.CurrentValue=s.TMA;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays.CurrentValue=s.NDays;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay.CurrentValue=s.WetDay;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV.CurrentValue=s.X2_PREV;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP.CurrentValue=s.SRFTEMP;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST.CurrentValue=s.ST;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r29 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT);
                if(r29.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID);
                if(r30.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL);
                if(r31.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL.ValueType)){prc.AddCondition(r31);}
                RangeBasedCondition r32 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA);
                if(r32.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA.ValueType)){prc.AddCondition(r32);}
                RangeBasedCondition r33 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays);
                if(r33.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays.ValueType)){prc.AddCondition(r33);}
                RangeBasedCondition r34 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay);
                if(r34.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay.ValueType)){prc.AddCondition(r34);}
                RangeBasedCondition r35 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV);
                if(r35.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV.ValueType)){prc.AddCondition(r35);}
                RangeBasedCondition r36 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP);
                if(r36.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP.ValueType)){prc.AddCondition(r36);}
                RangeBasedCondition r37 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST);
                if(r37.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST.ValueType)){prc.AddCondition(r37);}
                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".STEMP_EPIC_, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(STEMP_EPIC_.DomainClass.STEMP_EPIC_State s,STEMP_EPIC_.DomainClass.STEMP_EPIC_State s1,STEMP_EPIC_.DomainClass.STEMP_EPIC_Rate r,STEMP_EPIC_.DomainClass.STEMP_EPIC_Auxiliary a,STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAMP.CurrentValue=ex.TAMP;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.RAIN.CurrentValue=ex.RAIN;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAVG.CurrentValue=ex.TAVG;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMAX.CurrentValue=ex.TMAX;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMIN.CurrentValue=ex.TMIN;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAV.CurrentValue=ex.TAV;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT.CurrentValue=s.CUMDPT;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID.CurrentValue=s.DSMID;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL.CurrentValue=s.TDL;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA.CurrentValue=s.TMA;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays.CurrentValue=s.NDays;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay.CurrentValue=s.WetDay;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV.CurrentValue=s.X2_PREV;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP.CurrentValue=s.SRFTEMP;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST.CurrentValue=s.ST;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.DEPIR.CurrentValue=ex.DEPIR;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.BIOMAS.CurrentValue=ex.BIOMAS;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.MULCHMASS.CurrentValue=ex.MULCHMASS;
                STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.SNOW.CurrentValue=ex.SNOW;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAMP);
                if(r1.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAMP.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.RAIN);
                if(r2.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.RAIN.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAVG);
                if(r3.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAVG.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMAX);
                if(r4.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMAX.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMIN);
                if(r5.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMIN.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAV);
                if(r6.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAV.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT);
                if(r7.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID);
                if(r8.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL);
                if(r9.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA);
                if(r10.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays);
                if(r11.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay);
                if(r12.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV);
                if(r13.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP);
                if(r14.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST);
                if(r15.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST.ValueType)){prc.AddCondition(r15);}
                RangeBasedCondition r16 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.DEPIR);
                if(r16.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.DEPIR.ValueType)){prc.AddCondition(r16);}
                RangeBasedCondition r17 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.BIOMAS);
                if(r17.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.BIOMAS.ValueType)){prc.AddCondition(r17);}
                RangeBasedCondition r18 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.MULCHMASS);
                if(r18.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.MULCHMASS.ValueType)){prc.AddCondition(r18);}
                RangeBasedCondition r19 = new RangeBasedCondition(STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.SNOW);
                if(r19.ApplicableVarInfoValueTypes.Contains( STEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.SNOW.ValueType)){prc.AddCondition(r19);}
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("NL")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ISWWAT")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("BD")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DLAYR")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DS")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DUL")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LL")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("NLAYR")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SW")));
                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in strategy " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = ".STEMP_EPIC_, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(STEMP_EPIC_.DomainClass.STEMP_EPIC_State s,STEMP_EPIC_.DomainClass.STEMP_EPIC_State s1,STEMP_EPIC_.DomainClass.STEMP_EPIC_Rate r,STEMP_EPIC_.DomainClass.STEMP_EPIC_Auxiliary a,STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component STEMP_EPIC_, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        public void Init(STEMP_EPIC_.DomainClass.STEMP_EPIC_State s, STEMP_EPIC_.DomainClass.STEMP_EPIC_State s1, STEMP_EPIC_.DomainClass.STEMP_EPIC_Rate r, STEMP_EPIC_.DomainClass.STEMP_EPIC_Auxiliary a, STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous ex)
        {
            double TAMP = ex.TAMP;
            double RAIN = ex.RAIN;
            double TAVG = ex.TAVG;
            double TMAX = ex.TMAX;
            double TMIN = ex.TMIN;
            double TAV = ex.TAV;
            double DEPIR = ex.DEPIR;
            double BIOMAS = ex.BIOMAS;
            double MULCHMASS = ex.MULCHMASS;
            double SNOW = ex.SNOW;
            double CUMDPT;
            double[] DSMID =  new double [NL];
            double TDL;
            double[] TMA =  new double [5];
            int NDays;
            int[] WetDay =  new int [30];
            double X2_PREV;
            double SRFTEMP;
            double[] ST =  new double [NL];
            CUMDPT = 0.00d;
            DSMID = new double[NL];
            TDL = 0.00d;
            TMA = new double[5];
            NDays = 0;
            WetDay = new int[30];
            X2_PREV = 0.00d;
            SRFTEMP = 0.00d;
            ST = new double[NL];
            int I;
            int L;
            double ABD;
            double B;
            double DP;
            double FX;
            double PESW;
            double TBD;
            double WW;
            double TLL;
            double TSW;
            double X2_AVG;
            double WFT;
            double BCV;
            double CV;
            double BCV1;
            double BCV2;
            double[] SWI =  new double [NL];
            SWI = SW;
            TBD = 0.00d;
            TLL = 0.00d;
            TSW = 0.00d;
            TDL = 0.00d;
            CUMDPT = 0.00d;
            for (L=1 ; L!=NLAYR + 1 ; L+=1)
            {
                DSMID[L - 1] = CUMDPT + (DLAYR[(L - 1)] * 5.00d);
                CUMDPT = CUMDPT + (DLAYR[(L - 1)] * 10.00d);
                TBD = TBD + (BD[(L - 1)] * DLAYR[(L - 1)]);
                TLL = TLL + (LL[(L - 1)] * DLAYR[(L - 1)]);
                TSW = TSW + (SWI[(L - 1)] * DLAYR[(L - 1)]);
                TDL = TDL + (DUL[(L - 1)] * DLAYR[(L - 1)]);
            }
            if (ISWWAT == "Y")
            {
                PESW = Math.Max(0.00d, TSW - TLL);
            }
            else
            {
                PESW = Math.Max(0.00d, TDL - TLL);
            }
            ABD = TBD / DS[(NLAYR - 1)];
            FX = ABD / (ABD + (686.00d * Math.Exp(-(5.630d * ABD))));
            DP = 1000.00d + (2500.00d * FX);
            WW = 0.3560d - (0.1440d * ABD);
            B = Math.Log(500.00d / DP);
            for (I=1 ; I!=5 + 1 ; I+=1)
            {
                TMA[I - 1] = (int)(TAVG * 10000.0d) / 10000.0d;
            }
            X2_AVG = TMA[(1 - 1)] * 5.00d;
            for (L=1 ; L!=NLAYR + 1 ; L+=1)
            {
                ST[L - 1] = TAVG;
            }
            WFT = 0.10d;
            WetDay = new int[30];
            NDays = 0;
            CV = MULCHMASS / 1000.0d;
            BCV1 = CV / (CV + Math.Exp(5.33960d - (2.39510d * CV)));
            BCV2 = SNOW / (SNOW + Math.Exp(2.3030d - (0.21970d * SNOW)));
            BCV = Math.Max(BCV1, BCV2);
            for (I=1 ; I!=8 + 1 ; I+=1)
            {
                Tuple.Create(TMA, SRFTEMP, ST, X2_AVG, X2_PREV) = SOILT_EPIC(NL, B, BCV, CUMDPT, DP, DSMID, NLAYR, PESW, TAV, TAVG, TMAX, TMIN, 0, WFT, WW, TMA, ST, X2_PREV);
            }
            s.CUMDPT= CUMDPT;
            s.DSMID= DSMID;
            s.TDL= TDL;
            s.TMA= TMA;
            s.NDays= NDays;
            s.WetDay= WetDay;
            s.X2_PREV= X2_PREV;
            s.SRFTEMP= SRFTEMP;
            s.ST= ST;
        }

        private void CalculateModel(STEMP_EPIC_.DomainClass.STEMP_EPIC_State s, STEMP_EPIC_.DomainClass.STEMP_EPIC_State s1, STEMP_EPIC_.DomainClass.STEMP_EPIC_Rate r, STEMP_EPIC_.DomainClass.STEMP_EPIC_Auxiliary a, STEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous ex)
        {
            double TAMP = ex.TAMP;
            double RAIN = ex.RAIN;
            double TAVG = ex.TAVG;
            double TMAX = ex.TMAX;
            double TMIN = ex.TMIN;
            double TAV = ex.TAV;
            double CUMDPT = s.CUMDPT;
            double[] DSMID = s.DSMID;
            double TDL = s.TDL;
            double[] TMA = s.TMA;
            int NDays = s.NDays;
            int[] WetDay = s.WetDay;
            double X2_PREV = s.X2_PREV;
            double SRFTEMP = s.SRFTEMP;
            double[] ST = s.ST;
            double DEPIR = ex.DEPIR;
            double BIOMAS = ex.BIOMAS;
            double MULCHMASS = ex.MULCHMASS;
            double SNOW = ex.SNOW;
            int I;
            int L;
            int NWetDays;
            double ABD;
            double B;
            double DP;
            double FX;
            double PESW;
            double TBD;
            double WW;
            double TLL;
            double TSW;
            double X2_AVG;
            double WFT;
            double BCV;
            double CV;
            double BCV1;
            double BCV2;
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
            if (ISWWAT == "Y")
            {
                PESW = Math.Max(0.00d, TSW - TLL);
            }
            else
            {
                PESW = Math.Max(0.00d, TDL - TLL);
            }
            if (NDays == 30)
            {
                for (I=1 ; I!=29 + 1 ; I+=1)
                {
                    WetDay[I - 1] = WetDay[I + 1 - 1];
                }
            }
            else
            {
                NDays = NDays + 1;
            }
            if (RAIN + DEPIR > 1.E-60d)
            {
                WetDay[NDays - 1] = 1;
            }
            else
            {
                WetDay[NDays - 1] = 0;
            }
            NWetDays = WetDay.Sum();
            WFT = (double)(NWetDays) / (double)(NDays);
            CV = (BIOMAS + MULCHMASS) / 1000.0d;
            BCV1 = CV / (CV + Math.Exp(5.33960d - (2.39510d * CV)));
            BCV2 = SNOW / (SNOW + Math.Exp(2.3030d - (0.21970d * SNOW)));
            BCV = Math.Max(BCV1, BCV2);
            Tuple.Create(TMA, SRFTEMP, ST, X2_AVG, X2_PREV) = SOILT_EPIC(NL, B, BCV, CUMDPT, DP, DSMID, NLAYR, PESW, TAV, TAVG, TMAX, TMIN, WetDay[NDays - 1], WFT, WW, TMA, ST, X2_PREV);
            s.CUMDPT= CUMDPT;
            s.DSMID= DSMID;
            s.TDL= TDL;
            s.TMA= TMA;
            s.NDays= NDays;
            s.WetDay= WetDay;
            s.X2_PREV= X2_PREV;
            s.SRFTEMP= SRFTEMP;
            s.ST= ST;
        }

        public static Tuple<double[],double,double[],double,double>  SOILT_EPIC(int NL, double B, double BCV, double CUMDPT, double DP, double[] DSMID, int NLAYR, double PESW, double TAV, double TAVG, double TMAX, double TMIN, int WetDay, double WFT, double WW, double[] TMA, double[] ST, double X2_PREV)
        {
            int K;
            int L;
            double DD;
            double FX;
            double SRFTEMP;
            double WC;
            double ZD;
            double X1;
            double X2;
            double X3;
            double F;
            double X2_AVG;
            double LAG;
            LAG = 0.50d;
            WC = Math.Max(0.010d, PESW) / (WW * CUMDPT) * 10.00d;
            FX = Math.Exp(B * Math.Pow((1.00d - WC) / (1.00d + WC), 2));
            DD = FX * DP;
            if (WetDay > 0)
            {
                X2 = WFT * (TAVG - TMIN) + TMIN;
            }
            else
            {
                X2 = WFT * (TMAX - TAVG) + TAVG + 2.0d;
            }
            TMA[1 - 1] = X2;
            for (K=5 ; K!=2 - 1 ; K+=-1)
            {
                TMA[K - 1] = TMA[K - 1 - 1];
            }
            X2_AVG = TMA.Sum() / 5.00d;
            X3 = (1.0d - BCV) * X2_AVG + (BCV * X2_PREV);
            SRFTEMP = Math.Min(X2_AVG, X3);
            X1 = TAV - X3;
            for (L=1 ; L!=NLAYR + 1 ; L+=1)
            {
                ZD = DSMID[(L - 1)] / DD;
                F = ZD / (ZD + Math.Exp(-.86690d - (2.07750d * ZD)));
                ST[L - 1] = LAG * ST[(L - 1)] + ((1.0d - LAG) * (F * X1 + X3));
            }
            X2_PREV = X2_AVG;
            return Tuple.Create(TMA, SRFTEMP, ST, X2_AVG, X2_PREV);
        }

    }
}