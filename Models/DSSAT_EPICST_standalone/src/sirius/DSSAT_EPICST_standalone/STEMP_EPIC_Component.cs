
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

using SiriusQualitySTEMP_EPIC_.DomainClass;
namespace SiriusQualitySTEMP_EPIC_.Strategies
{
    public class STEMP_EPIC_Component : IStrategySiriusQualitySTEMP_EPIC_
    {
        public STEMP_EPIC_Component()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_STEMP_EPIC, "BD");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_STEMP_EPIC, "DUL");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_STEMP_EPIC, "DS");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_STEMP_EPIC, "DLAYR");
            _parameters0_0.Add(v4);
            VarInfo v5 = new CompositeStrategyVarInfo(_STEMP_EPIC, "LL");
            _parameters0_0.Add(v5);
            VarInfo v6 = new CompositeStrategyVarInfo(_STEMP_EPIC, "SW");
            _parameters0_0.Add(v6);
            VarInfo v7 = new CompositeStrategyVarInfo(_STEMP_EPIC, "NLAYR");
            _parameters0_0.Add(v7);
            VarInfo v8 = new CompositeStrategyVarInfo(_STEMP_EPIC, "NL");
            _parameters0_0.Add(v8);
            VarInfo v9 = new CompositeStrategyVarInfo(_STEMP_EPIC, "ISWWAT");
            _parameters0_0.Add(v9);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd1.PropertyName = "RAIN";
            pd1.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.RAIN).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.RAIN);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd2.PropertyName = "NDays";
            pd2.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd3.PropertyName = "DEPIR";
            pd3.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.DEPIR).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.DEPIR);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd4.PropertyName = "TMIN";
            pd4.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMIN).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMIN);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd5.PropertyName = "WetDay";
            pd5.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd6.PropertyName = "BIOMAS";
            pd6.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.BIOMAS).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.BIOMAS);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd7.PropertyName = "TAMP";
            pd7.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAMP).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAMP);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd8.PropertyName = "MULCHMASS";
            pd8.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.MULCHMASS).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.MULCHMASS);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd9.PropertyName = "TDL";
            pd9.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd10.PropertyName = "X2_PREV";
            pd10.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd11.PropertyName = "DSMID";
            pd11.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd12.PropertyName = "TMAX";
            pd12.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMAX).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMAX);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd13.PropertyName = "TAV";
            pd13.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAV).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAV);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd14.PropertyName = "SNOW";
            pd14.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.SNOW).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.SNOW);
            _inputs0_0.Add(pd14);
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd15.PropertyName = "TMA";
            pd15.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA);
            _inputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous);
            pd16.PropertyName = "TAVG";
            pd16.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAVG).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAVG);
            _inputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd17.PropertyName = "SRFTEMP";
            pd17.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP);
            _inputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd18.PropertyName = "ST";
            pd18.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST);
            _inputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd19.PropertyName = "CUMDPT";
            pd19.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT);
            _inputs0_0.Add(pd19);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd20.PropertyName = "CUMDPT";
            pd20.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT);
            _outputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd21.PropertyName = "DSMID";
            pd21.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID);
            _outputs0_0.Add(pd21);
            PropertyDescription pd22 = new PropertyDescription();
            pd22.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd22.PropertyName = "TDL";
            pd22.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL).ValueType.TypeForCurrentValue;
            pd22.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL);
            _outputs0_0.Add(pd22);
            PropertyDescription pd23 = new PropertyDescription();
            pd23.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd23.PropertyName = "TMA";
            pd23.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA).ValueType.TypeForCurrentValue;
            pd23.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA);
            _outputs0_0.Add(pd23);
            PropertyDescription pd24 = new PropertyDescription();
            pd24.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd24.PropertyName = "NDays";
            pd24.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays).ValueType.TypeForCurrentValue;
            pd24.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays);
            _outputs0_0.Add(pd24);
            PropertyDescription pd25 = new PropertyDescription();
            pd25.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd25.PropertyName = "WetDay";
            pd25.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay).ValueType.TypeForCurrentValue;
            pd25.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay);
            _outputs0_0.Add(pd25);
            PropertyDescription pd26 = new PropertyDescription();
            pd26.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd26.PropertyName = "X2_PREV";
            pd26.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV).ValueType.TypeForCurrentValue;
            pd26.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV);
            _outputs0_0.Add(pd26);
            PropertyDescription pd27 = new PropertyDescription();
            pd27.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd27.PropertyName = "SRFTEMP";
            pd27.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP).ValueType.TypeForCurrentValue;
            pd27.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP);
            _outputs0_0.Add(pd27);
            PropertyDescription pd28 = new PropertyDescription();
            pd28.DomainClassType = typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State);
            pd28.PropertyName = "ST";
            pd28.PropertyType = (SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST).ValueType.TypeForCurrentValue;
            pd28.PropertyVarInfo =(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST);
            _outputs0_0.Add(pd28);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(SiriusQualitySTEMP_EPIC_.Strategies.STEMP_EPIC).FullName);
            mo0_0.AssociatedStrategies = lAssStrat0_0;
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
            return new List<Type>() {  typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State), typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State), typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Rate), typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Auxiliary), typeof(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous)};
        }

        public double[] BD
        {
            get
            {
                 return _STEMP_EPIC.BD; 
            }
            set
            {
                _STEMP_EPIC.BD = value;
            }
        }
        public double[] DUL
        {
            get
            {
                 return _STEMP_EPIC.DUL; 
            }
            set
            {
                _STEMP_EPIC.DUL = value;
            }
        }
        public double[] DS
        {
            get
            {
                 return _STEMP_EPIC.DS; 
            }
            set
            {
                _STEMP_EPIC.DS = value;
            }
        }
        public double[] DLAYR
        {
            get
            {
                 return _STEMP_EPIC.DLAYR; 
            }
            set
            {
                _STEMP_EPIC.DLAYR = value;
            }
        }
        public double[] LL
        {
            get
            {
                 return _STEMP_EPIC.LL; 
            }
            set
            {
                _STEMP_EPIC.LL = value;
            }
        }
        public double[] SW
        {
            get
            {
                 return _STEMP_EPIC.SW; 
            }
            set
            {
                _STEMP_EPIC.SW = value;
            }
        }
        public int NLAYR
        {
            get
            {
                 return _STEMP_EPIC.NLAYR; 
            }
            set
            {
                _STEMP_EPIC.NLAYR = value;
            }
        }
        public int NL
        {
            get
            {
                 return _STEMP_EPIC.NL; 
            }
            set
            {
                _STEMP_EPIC.NL = value;
            }
        }
        public string ISWWAT
        {
            get
            {
                 return _STEMP_EPIC.ISWWAT; 
            }
            set
            {
                _STEMP_EPIC.ISWWAT = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _STEMP_EPIC.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            BDVarInfo.Name = "BD";
            BDVarInfo.Description = "Bulk density, soil layer NL";
            BDVarInfo.MaxValue = -1D;
            BDVarInfo.MinValue = -1D;
            BDVarInfo.DefaultValue = -1D;
            BDVarInfo.Units = "g [soil] / cm3 [soil]";
            BDVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            DULVarInfo.Name = "DUL";
            DULVarInfo.Description = "Volumetric soil water content at Drained Upper Limit in soil layer L";
            DULVarInfo.MaxValue = -1D;
            DULVarInfo.MinValue = -1D;
            DULVarInfo.DefaultValue = -1D;
            DULVarInfo.Units = "cm3[water]/cm3[soil]";
            DULVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            DSVarInfo.Name = "DS";
            DSVarInfo.Description = "Cumulative depth in soil layer NL";
            DSVarInfo.MaxValue = -1D;
            DSVarInfo.MinValue = -1D;
            DSVarInfo.DefaultValue = -1D;
            DSVarInfo.Units = "cm";
            DSVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            DLAYRVarInfo.Name = "DLAYR";
            DLAYRVarInfo.Description = "Thickness of soil layer NL";
            DLAYRVarInfo.MaxValue = -1D;
            DLAYRVarInfo.MinValue = -1D;
            DLAYRVarInfo.DefaultValue = -1D;
            DLAYRVarInfo.Units = "cm";
            DLAYRVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            LLVarInfo.Name = "LL";
            LLVarInfo.Description = "Volumetric soil water content in soil layer NL at lower limit";
            LLVarInfo.MaxValue = -1D;
            LLVarInfo.MinValue = -1D;
            LLVarInfo.DefaultValue = -1D;
            LLVarInfo.Units = "cm3 [water] / cm3 [soil]";
            LLVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            SWVarInfo.Name = "SW";
            SWVarInfo.Description = "Volumetric soil water content in layer NL";
            SWVarInfo.MaxValue = -1D;
            SWVarInfo.MinValue = -1D;
            SWVarInfo.DefaultValue = -1D;
            SWVarInfo.Units = "cm3 [water] / cm3 [soil]";
            SWVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            NLAYRVarInfo.Name = "NLAYR";
            NLAYRVarInfo.Description = "Actual number of soil layers";
            NLAYRVarInfo.MaxValue = -1D;
            NLAYRVarInfo.MinValue = -1D;
            NLAYRVarInfo.DefaultValue = -1D;
            NLAYRVarInfo.Units = "dimensionless";
            NLAYRVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

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
        }

        public static VarInfo BDVarInfo
        {
            get { return SiriusQualitySTEMP_EPIC_.Strategies.STEMP_EPIC.BDVarInfo;} 
        }

        public static VarInfo DULVarInfo
        {
            get { return SiriusQualitySTEMP_EPIC_.Strategies.STEMP_EPIC.DULVarInfo;} 
        }

        public static VarInfo DSVarInfo
        {
            get { return SiriusQualitySTEMP_EPIC_.Strategies.STEMP_EPIC.DSVarInfo;} 
        }

        public static VarInfo DLAYRVarInfo
        {
            get { return SiriusQualitySTEMP_EPIC_.Strategies.STEMP_EPIC.DLAYRVarInfo;} 
        }

        public static VarInfo LLVarInfo
        {
            get { return SiriusQualitySTEMP_EPIC_.Strategies.STEMP_EPIC.LLVarInfo;} 
        }

        public static VarInfo SWVarInfo
        {
            get { return SiriusQualitySTEMP_EPIC_.Strategies.STEMP_EPIC.SWVarInfo;} 
        }

        public static VarInfo NLAYRVarInfo
        {
            get { return SiriusQualitySTEMP_EPIC_.Strategies.STEMP_EPIC.NLAYRVarInfo;} 
        }

        public static VarInfo NLVarInfo
        {
            get { return SiriusQualitySTEMP_EPIC_.Strategies.STEMP_EPIC.NLVarInfo;} 
        }

        public static VarInfo ISWWATVarInfo
        {
            get { return SiriusQualitySTEMP_EPIC_.Strategies.STEMP_EPIC.ISWWATVarInfo;} 
        }

        public string TestPostConditions(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State s,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State s1,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Rate r,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Auxiliary a,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT.CurrentValue=s.CUMDPT;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID.CurrentValue=s.DSMID;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL.CurrentValue=s.TDL;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA.CurrentValue=s.TMA;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays.CurrentValue=s.NDays;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay.CurrentValue=s.WetDay;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV.CurrentValue=s.X2_PREV;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP.CurrentValue=s.SRFTEMP;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST.CurrentValue=s.ST;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r29 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT);
                if(r29.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID);
                if(r30.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL);
                if(r31.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL.ValueType)){prc.AddCondition(r31);}
                RangeBasedCondition r32 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA);
                if(r32.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA.ValueType)){prc.AddCondition(r32);}
                RangeBasedCondition r33 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays);
                if(r33.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays.ValueType)){prc.AddCondition(r33);}
                RangeBasedCondition r34 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay);
                if(r34.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay.ValueType)){prc.AddCondition(r34);}
                RangeBasedCondition r35 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV);
                if(r35.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV.ValueType)){prc.AddCondition(r35);}
                RangeBasedCondition r36 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP);
                if(r36.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP.ValueType)){prc.AddCondition(r36);}
                RangeBasedCondition r37 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST);
                if(r37.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST.ValueType)){prc.AddCondition(r37);}

                string ret = "";
                ret += _STEMP_EPIC.TestPostConditions(s, s1, r, a, ex, " strategy SiriusQualitySTEMP_EPIC_.Strategies.STEMP_EPIC_");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.STEMP_EPIC_, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State s,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State s1,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Rate r,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Auxiliary a,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.RAIN.CurrentValue=ex.RAIN;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays.CurrentValue=s.NDays;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.DEPIR.CurrentValue=ex.DEPIR;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMIN.CurrentValue=ex.TMIN;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay.CurrentValue=s.WetDay;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.BIOMAS.CurrentValue=ex.BIOMAS;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAMP.CurrentValue=ex.TAMP;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.MULCHMASS.CurrentValue=ex.MULCHMASS;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL.CurrentValue=s.TDL;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV.CurrentValue=s.X2_PREV;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID.CurrentValue=s.DSMID;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMAX.CurrentValue=ex.TMAX;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAV.CurrentValue=ex.TAV;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.SNOW.CurrentValue=ex.SNOW;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA.CurrentValue=s.TMA;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAVG.CurrentValue=ex.TAVG;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP.CurrentValue=s.SRFTEMP;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST.CurrentValue=s.ST;
                SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT.CurrentValue=s.CUMDPT;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.RAIN);
                if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.RAIN.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays);
                if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.NDays.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.DEPIR);
                if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.DEPIR.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMIN);
                if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMIN.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay);
                if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.WetDay.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.BIOMAS);
                if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.BIOMAS.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAMP);
                if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAMP.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.MULCHMASS);
                if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.MULCHMASS.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL);
                if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TDL.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV);
                if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.X2_PREV.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID);
                if(r11.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.DSMID.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMAX);
                if(r12.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TMAX.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAV);
                if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAV.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.SNOW);
                if(r14.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.SNOW.ValueType)){prc.AddCondition(r14);}
                RangeBasedCondition r15 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA);
                if(r15.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.TMA.ValueType)){prc.AddCondition(r15);}
                RangeBasedCondition r16 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAVG);
                if(r16.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_ExogenousVarInfo.TAVG.ValueType)){prc.AddCondition(r16);}
                RangeBasedCondition r17 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP);
                if(r17.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.SRFTEMP.ValueType)){prc.AddCondition(r17);}
                RangeBasedCondition r18 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST);
                if(r18.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.ST.ValueType)){prc.AddCondition(r18);}
                RangeBasedCondition r19 = new RangeBasedCondition(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT);
                if(r19.ApplicableVarInfoValueTypes.Contains( SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_StateVarInfo.CUMDPT.ValueType)){prc.AddCondition(r19);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("BD")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DUL")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DS")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DLAYR")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LL")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SW")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("NLAYR")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("NL")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ISWWAT")));
                string ret = "";
                ret += _STEMP_EPIC.TestPreConditions(s, s1, r, a, ex, " strategy SiriusQualitySTEMP_EPIC_.Strategies.STEMP_EPIC_");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component SiriusQuality.STEMP_EPIC_, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State s,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State s1,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Rate r,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Auxiliary a,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component SiriusQualitySTEMP_EPIC_, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State s,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State s1,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Rate r,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Auxiliary a,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        STEMP_EPIC _STEMP_EPIC = new STEMP_EPIC();

        private void EstimateOfAssociatedClasses(SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State s,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_State s1,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Rate r,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Auxiliary a,SiriusQualitySTEMP_EPIC_.DomainClass.STEMP_EPIC_Exogenous ex)
        {
            _STEMP_EPIC.Estimate(s,s1, r, a, ex);
        }

        public STEMP_EPIC_Component(STEMP_EPIC_Component toCopy): this() // copy constructor 
        {
                
            for (int i = 0; i < NL; i++)
            { BD[i] = toCopy.BD[i]; }
    
                
            for (int i = 0; i < NL; i++)
            { DUL[i] = toCopy.DUL[i]; }
    
                
            for (int i = 0; i < NL; i++)
            { DS[i] = toCopy.DS[i]; }
    
                
            for (int i = 0; i < NL; i++)
            { DLAYR[i] = toCopy.DLAYR[i]; }
    
                
            for (int i = 0; i < NL; i++)
            { LL[i] = toCopy.LL[i]; }
    
                
            for (int i = 0; i < NL; i++)
            { SW[i] = toCopy.SW[i]; }
    
                NLAYR = toCopy.NLAYR;
                NL = toCopy.NL;
                ISWWAT = toCopy.ISWWAT;
        }
    }
}