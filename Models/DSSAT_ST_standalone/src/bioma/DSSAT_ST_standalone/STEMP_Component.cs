
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

using STEMP_.DomainClass;
namespace STEMP_.Strategies
{
    public class STEMP_Component : IStrategySTEMP_
    {
        public STEMP_Component()
        {
            ModellingOptions mo0_0 = new ModellingOptions();
            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            VarInfo v1 = new CompositeStrategyVarInfo(_STEMP, "MSALB");
            _parameters0_0.Add(v1);
            VarInfo v2 = new CompositeStrategyVarInfo(_STEMP, "NL");
            _parameters0_0.Add(v2);
            VarInfo v3 = new CompositeStrategyVarInfo(_STEMP, "LL");
            _parameters0_0.Add(v3);
            VarInfo v4 = new CompositeStrategyVarInfo(_STEMP, "NLAYR");
            _parameters0_0.Add(v4);
            VarInfo v5 = new CompositeStrategyVarInfo(_STEMP, "DS");
            _parameters0_0.Add(v5);
            VarInfo v6 = new CompositeStrategyVarInfo(_STEMP, "DLAYR");
            _parameters0_0.Add(v6);
            VarInfo v7 = new CompositeStrategyVarInfo(_STEMP, "ISWWAT");
            _parameters0_0.Add(v7);
            VarInfo v8 = new CompositeStrategyVarInfo(_STEMP, "BD");
            _parameters0_0.Add(v8);
            VarInfo v9 = new CompositeStrategyVarInfo(_STEMP, "SW");
            _parameters0_0.Add(v9);
            VarInfo v10 = new CompositeStrategyVarInfo(_STEMP, "XLAT");
            _parameters0_0.Add(v10);
            VarInfo v11 = new CompositeStrategyVarInfo(_STEMP, "DUL");
            _parameters0_0.Add(v11);
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(STEMP_.DomainClass.STEMP_Exogenous);
            pd1.PropertyName = "TMAX";
            pd1.PropertyType = (STEMP_.DomainClass.STEMP_ExogenousVarInfo.TMAX).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo =(STEMP_.DomainClass.STEMP_ExogenousVarInfo.TMAX);
            _inputs0_0.Add(pd1);
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd2.PropertyName = "HDAY";
            pd2.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.HDAY).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.HDAY);
            _inputs0_0.Add(pd2);
            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd3.PropertyName = "SRFTEMP";
            pd3.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP);
            _inputs0_0.Add(pd3);
            PropertyDescription pd4 = new PropertyDescription();
            pd4.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd4.PropertyName = "ST";
            pd4.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.ST).ValueType.TypeForCurrentValue;
            pd4.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.ST);
            _inputs0_0.Add(pd4);
            PropertyDescription pd5 = new PropertyDescription();
            pd5.DomainClassType = typeof(STEMP_.DomainClass.STEMP_Exogenous);
            pd5.PropertyName = "SRAD";
            pd5.PropertyType = (STEMP_.DomainClass.STEMP_ExogenousVarInfo.SRAD).ValueType.TypeForCurrentValue;
            pd5.PropertyVarInfo =(STEMP_.DomainClass.STEMP_ExogenousVarInfo.SRAD);
            _inputs0_0.Add(pd5);
            PropertyDescription pd6 = new PropertyDescription();
            pd6.DomainClassType = typeof(STEMP_.DomainClass.STEMP_Exogenous);
            pd6.PropertyName = "TAMP";
            pd6.PropertyType = (STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAMP).ValueType.TypeForCurrentValue;
            pd6.PropertyVarInfo =(STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAMP);
            _inputs0_0.Add(pd6);
            PropertyDescription pd7 = new PropertyDescription();
            pd7.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd7.PropertyName = "TMA";
            pd7.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.TMA).ValueType.TypeForCurrentValue;
            pd7.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.TMA);
            _inputs0_0.Add(pd7);
            PropertyDescription pd8 = new PropertyDescription();
            pd8.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd8.PropertyName = "TDL";
            pd8.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.TDL).ValueType.TypeForCurrentValue;
            pd8.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.TDL);
            _inputs0_0.Add(pd8);
            PropertyDescription pd9 = new PropertyDescription();
            pd9.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd9.PropertyName = "CUMDPT";
            pd9.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT).ValueType.TypeForCurrentValue;
            pd9.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT);
            _inputs0_0.Add(pd9);
            PropertyDescription pd10 = new PropertyDescription();
            pd10.DomainClassType = typeof(STEMP_.DomainClass.STEMP_Exogenous);
            pd10.PropertyName = "TAVG";
            pd10.PropertyType = (STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAVG).ValueType.TypeForCurrentValue;
            pd10.PropertyVarInfo =(STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAVG);
            _inputs0_0.Add(pd10);
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd11.PropertyName = "ATOT";
            pd11.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.ATOT).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.ATOT);
            _inputs0_0.Add(pd11);
            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(STEMP_.DomainClass.STEMP_Exogenous);
            pd12.PropertyName = "TAV";
            pd12.PropertyType = (STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAV).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo =(STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAV);
            _inputs0_0.Add(pd12);
            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd13.PropertyName = "DSMID";
            pd13.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.DSMID).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.DSMID);
            _inputs0_0.Add(pd13);
            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(STEMP_.DomainClass.STEMP_Exogenous);
            pd14.PropertyName = "DOY";
            pd14.PropertyType = (STEMP_.DomainClass.STEMP_ExogenousVarInfo.DOY).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo =(STEMP_.DomainClass.STEMP_ExogenousVarInfo.DOY);
            _inputs0_0.Add(pd14);
            mo0_0.Inputs=_inputs0_0;
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd15.PropertyName = "CUMDPT";
            pd15.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT);
            _outputs0_0.Add(pd15);
            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd16.PropertyName = "DSMID";
            pd16.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.DSMID).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.DSMID);
            _outputs0_0.Add(pd16);
            PropertyDescription pd17 = new PropertyDescription();
            pd17.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd17.PropertyName = "TDL";
            pd17.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.TDL).ValueType.TypeForCurrentValue;
            pd17.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.TDL);
            _outputs0_0.Add(pd17);
            PropertyDescription pd18 = new PropertyDescription();
            pd18.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd18.PropertyName = "TMA";
            pd18.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.TMA).ValueType.TypeForCurrentValue;
            pd18.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.TMA);
            _outputs0_0.Add(pd18);
            PropertyDescription pd19 = new PropertyDescription();
            pd19.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd19.PropertyName = "ATOT";
            pd19.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.ATOT).ValueType.TypeForCurrentValue;
            pd19.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.ATOT);
            _outputs0_0.Add(pd19);
            PropertyDescription pd20 = new PropertyDescription();
            pd20.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd20.PropertyName = "SRFTEMP";
            pd20.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP).ValueType.TypeForCurrentValue;
            pd20.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP);
            _outputs0_0.Add(pd20);
            PropertyDescription pd21 = new PropertyDescription();
            pd21.DomainClassType = typeof(STEMP_.DomainClass.STEMP_State);
            pd21.PropertyName = "ST";
            pd21.PropertyType = (STEMP_.DomainClass.STEMP_StateVarInfo.ST).ValueType.TypeForCurrentValue;
            pd21.PropertyVarInfo =(STEMP_.DomainClass.STEMP_StateVarInfo.ST);
            _outputs0_0.Add(pd21);
            mo0_0.Outputs=_outputs0_0;
            List<string> lAssStrat0_0 = new List<string>();
            lAssStrat0_0.Add(typeof(STEMP_.Strategies.STEMP).FullName);
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
            return new List<Type>() {  typeof(STEMP_.DomainClass.STEMP_State), typeof(STEMP_.DomainClass.STEMP_State), typeof(STEMP_.DomainClass.STEMP_Rate), typeof(STEMP_.DomainClass.STEMP_Auxiliary), typeof(STEMP_.DomainClass.STEMP_Exogenous)};
        }

        public double MSALB
        {
            get
            {
                 return _STEMP.MSALB; 
            }
            set
            {
                _STEMP.MSALB = value;
            }
        }
        public int NL
        {
            get
            {
                 return _STEMP.NL; 
            }
            set
            {
                _STEMP.NL = value;
            }
        }
        public double[] LL
        {
            get
            {
                 return _STEMP.LL; 
            }
            set
            {
                _STEMP.LL = value;
            }
        }
        public int NLAYR
        {
            get
            {
                 return _STEMP.NLAYR; 
            }
            set
            {
                _STEMP.NLAYR = value;
            }
        }
        public double[] DS
        {
            get
            {
                 return _STEMP.DS; 
            }
            set
            {
                _STEMP.DS = value;
            }
        }
        public double[] DLAYR
        {
            get
            {
                 return _STEMP.DLAYR; 
            }
            set
            {
                _STEMP.DLAYR = value;
            }
        }
        public string ISWWAT
        {
            get
            {
                 return _STEMP.ISWWAT; 
            }
            set
            {
                _STEMP.ISWWAT = value;
            }
        }
        public double[] BD
        {
            get
            {
                 return _STEMP.BD; 
            }
            set
            {
                _STEMP.BD = value;
            }
        }
        public double[] SW
        {
            get
            {
                 return _STEMP.SW; 
            }
            set
            {
                _STEMP.SW = value;
            }
        }
        public double XLAT
        {
            get
            {
                 return _STEMP.XLAT; 
            }
            set
            {
                _STEMP.XLAT = value;
            }
        }
        public double[] DUL
        {
            get
            {
                 return _STEMP.DUL; 
            }
            set
            {
                _STEMP.DUL = value;
            }
        }

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();
            _STEMP.SetParametersDefaultValue();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {

            MSALBVarInfo.Name = "MSALB";
            MSALBVarInfo.Description = "Soil albedo with mulch and soil water effects";
            MSALBVarInfo.MaxValue = -1D;
            MSALBVarInfo.MinValue = -1D;
            MSALBVarInfo.DefaultValue = -1D;
            MSALBVarInfo.Units = "dimensionless";
            MSALBVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            NLVarInfo.Name = "NL";
            NLVarInfo.Description = "Number of soil layers";
            NLVarInfo.MaxValue = -1D;
            NLVarInfo.MinValue = -1D;
            NLVarInfo.DefaultValue = -1D;
            NLVarInfo.Units = "dimensionless";
            NLVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

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

            DSVarInfo.Name = "DS";
            DSVarInfo.Description = "Cumulative depth in soil layer L";
            DSVarInfo.MaxValue = -1D;
            DSVarInfo.MinValue = -1D;
            DSVarInfo.DefaultValue = -1D;
            DSVarInfo.Units = "cm";
            DSVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            DLAYRVarInfo.Name = "DLAYR";
            DLAYRVarInfo.Description = "Thickness of soil layer L";
            DLAYRVarInfo.MaxValue = -1D;
            DLAYRVarInfo.MinValue = -1D;
            DLAYRVarInfo.DefaultValue = -1D;
            DLAYRVarInfo.Units = "cm";
            DLAYRVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

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

            DULVarInfo.Name = "DUL";
            DULVarInfo.Description = "Volumetric soil water content at Drained Upper Limit in soil layer L";
            DULVarInfo.MaxValue = -1D;
            DULVarInfo.MinValue = -1D;
            DULVarInfo.DefaultValue = -1D;
            DULVarInfo.Units = "cm3[water]/cm3[soil]";
            DULVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
        }

        public static VarInfo MSALBVarInfo
        {
            get { return STEMP_.Strategies.STEMP.MSALBVarInfo;} 
        }

        public static VarInfo NLVarInfo
        {
            get { return STEMP_.Strategies.STEMP.NLVarInfo;} 
        }

        public static VarInfo LLVarInfo
        {
            get { return STEMP_.Strategies.STEMP.LLVarInfo;} 
        }

        public static VarInfo NLAYRVarInfo
        {
            get { return STEMP_.Strategies.STEMP.NLAYRVarInfo;} 
        }

        public static VarInfo DSVarInfo
        {
            get { return STEMP_.Strategies.STEMP.DSVarInfo;} 
        }

        public static VarInfo DLAYRVarInfo
        {
            get { return STEMP_.Strategies.STEMP.DLAYRVarInfo;} 
        }

        public static VarInfo ISWWATVarInfo
        {
            get { return STEMP_.Strategies.STEMP.ISWWATVarInfo;} 
        }

        public static VarInfo BDVarInfo
        {
            get { return STEMP_.Strategies.STEMP.BDVarInfo;} 
        }

        public static VarInfo SWVarInfo
        {
            get { return STEMP_.Strategies.STEMP.SWVarInfo;} 
        }

        public static VarInfo XLATVarInfo
        {
            get { return STEMP_.Strategies.STEMP.XLATVarInfo;} 
        }

        public static VarInfo DULVarInfo
        {
            get { return STEMP_.Strategies.STEMP.DULVarInfo;} 
        }

        public string TestPostConditions(STEMP_.DomainClass.STEMP_State s,STEMP_.DomainClass.STEMP_State s1,STEMP_.DomainClass.STEMP_Rate r,STEMP_.DomainClass.STEMP_Auxiliary a,STEMP_.DomainClass.STEMP_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the outputs to the static VarInfo representing the output properties of the domain classes
                STEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT.CurrentValue=s.CUMDPT;
                STEMP_.DomainClass.STEMP_StateVarInfo.DSMID.CurrentValue=s.DSMID;
                STEMP_.DomainClass.STEMP_StateVarInfo.TDL.CurrentValue=s.TDL;
                STEMP_.DomainClass.STEMP_StateVarInfo.TMA.CurrentValue=s.TMA;
                STEMP_.DomainClass.STEMP_StateVarInfo.ATOT.CurrentValue=s.ATOT;
                STEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP.CurrentValue=s.SRFTEMP;
                STEMP_.DomainClass.STEMP_StateVarInfo.ST.CurrentValue=s.ST;

                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 

                RangeBasedCondition r26 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT);
                if(r26.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT.ValueType)){prc.AddCondition(r26);}
                RangeBasedCondition r27 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.DSMID);
                if(r27.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.DSMID.ValueType)){prc.AddCondition(r27);}
                RangeBasedCondition r28 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.TDL);
                if(r28.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.TDL.ValueType)){prc.AddCondition(r28);}
                RangeBasedCondition r29 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.TMA);
                if(r29.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.TMA.ValueType)){prc.AddCondition(r29);}
                RangeBasedCondition r30 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.ATOT);
                if(r30.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.ATOT.ValueType)){prc.AddCondition(r30);}
                RangeBasedCondition r31 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP);
                if(r31.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP.ValueType)){prc.AddCondition(r31);}
                RangeBasedCondition r32 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.ST);
                if(r32.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.ST.ValueType)){prc.AddCondition(r32);}

                string ret = "";
                ret += _STEMP.TestPostConditions(s, s1, r, a, ex, " strategy STEMP_.Strategies.STEMP_");
                if (ret != "") { pre.TestsOut(ret, true, "   postconditions tests of associated classes"); }

                string postConditionsResult = pre.VerifyPostconditions(prc, callID); if (!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in strategy " + this.GetType().Name); } return postConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .STEMP_, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public string TestPreConditions(STEMP_.DomainClass.STEMP_State s,STEMP_.DomainClass.STEMP_State s1,STEMP_.DomainClass.STEMP_Rate r,STEMP_.DomainClass.STEMP_Auxiliary a,STEMP_.DomainClass.STEMP_Exogenous ex,string callID)
        {
            try
            {
                //Set current values of the inputs to the static VarInfo representing the inputs properties of the domain classes
                STEMP_.DomainClass.STEMP_ExogenousVarInfo.TMAX.CurrentValue=ex.TMAX;
                STEMP_.DomainClass.STEMP_StateVarInfo.HDAY.CurrentValue=s.HDAY;
                STEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP.CurrentValue=s.SRFTEMP;
                STEMP_.DomainClass.STEMP_StateVarInfo.ST.CurrentValue=s.ST;
                STEMP_.DomainClass.STEMP_ExogenousVarInfo.SRAD.CurrentValue=ex.SRAD;
                STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAMP.CurrentValue=ex.TAMP;
                STEMP_.DomainClass.STEMP_StateVarInfo.TMA.CurrentValue=s.TMA;
                STEMP_.DomainClass.STEMP_StateVarInfo.TDL.CurrentValue=s.TDL;
                STEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT.CurrentValue=s.CUMDPT;
                STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAVG.CurrentValue=ex.TAVG;
                STEMP_.DomainClass.STEMP_StateVarInfo.ATOT.CurrentValue=s.ATOT;
                STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAV.CurrentValue=ex.TAV;
                STEMP_.DomainClass.STEMP_StateVarInfo.DSMID.CurrentValue=s.DSMID;
                STEMP_.DomainClass.STEMP_ExogenousVarInfo.DOY.CurrentValue=ex.DOY;
                ConditionsCollection prc = new ConditionsCollection();
                Preconditions pre = new Preconditions(); 
                RangeBasedCondition r1 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_ExogenousVarInfo.TMAX);
                if(r1.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_ExogenousVarInfo.TMAX.ValueType)){prc.AddCondition(r1);}
                RangeBasedCondition r2 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.HDAY);
                if(r2.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.HDAY.ValueType)){prc.AddCondition(r2);}
                RangeBasedCondition r3 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP);
                if(r3.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.SRFTEMP.ValueType)){prc.AddCondition(r3);}
                RangeBasedCondition r4 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.ST);
                if(r4.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.ST.ValueType)){prc.AddCondition(r4);}
                RangeBasedCondition r5 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_ExogenousVarInfo.SRAD);
                if(r5.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_ExogenousVarInfo.SRAD.ValueType)){prc.AddCondition(r5);}
                RangeBasedCondition r6 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAMP);
                if(r6.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAMP.ValueType)){prc.AddCondition(r6);}
                RangeBasedCondition r7 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.TMA);
                if(r7.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.TMA.ValueType)){prc.AddCondition(r7);}
                RangeBasedCondition r8 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.TDL);
                if(r8.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.TDL.ValueType)){prc.AddCondition(r8);}
                RangeBasedCondition r9 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT);
                if(r9.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.CUMDPT.ValueType)){prc.AddCondition(r9);}
                RangeBasedCondition r10 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAVG);
                if(r10.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAVG.ValueType)){prc.AddCondition(r10);}
                RangeBasedCondition r11 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.ATOT);
                if(r11.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.ATOT.ValueType)){prc.AddCondition(r11);}
                RangeBasedCondition r12 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAV);
                if(r12.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_ExogenousVarInfo.TAV.ValueType)){prc.AddCondition(r12);}
                RangeBasedCondition r13 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_StateVarInfo.DSMID);
                if(r13.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_StateVarInfo.DSMID.ValueType)){prc.AddCondition(r13);}
                RangeBasedCondition r14 = new RangeBasedCondition(STEMP_.DomainClass.STEMP_ExogenousVarInfo.DOY);
                if(r14.ApplicableVarInfoValueTypes.Contains( STEMP_.DomainClass.STEMP_ExogenousVarInfo.DOY.ValueType)){prc.AddCondition(r14);}

                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("MSALB")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("NL")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LL")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("NLAYR")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DS")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DLAYR")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("ISWWAT")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("BD")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SW")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("XLAT")));
                prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("DUL")));
                string ret = "";
                ret += _STEMP.TestPreConditions(s, s1, r, a, ex, " strategy STEMP_.Strategies.STEMP_");
                if (ret != "") { pre.TestsOut(ret, true, "   preconditions tests of associated classes"); }

                string preConditionsResult = pre.VerifyPreconditions(prc, callID); if (!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component " + this.GetType().Name); } return preConditionsResult;
            }
            catch (Exception exception)
            {
                string msg = "Component .STEMP_, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, exception);
            }
        }

        public void Estimate(STEMP_.DomainClass.STEMP_State s,STEMP_.DomainClass.STEMP_State s1,STEMP_.DomainClass.STEMP_Rate r,STEMP_.DomainClass.STEMP_Auxiliary a,STEMP_.DomainClass.STEMP_Exogenous ex)
        {
            try
            {
                CalculateModel(s, s1, r, a, ex);
            }
            catch (Exception exception)
            {
                string msg = "Error in component STEMP_, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;
                throw new Exception(msg, exception);
            }
        }

        private void CalculateModel(STEMP_.DomainClass.STEMP_State s,STEMP_.DomainClass.STEMP_State s1,STEMP_.DomainClass.STEMP_Rate r,STEMP_.DomainClass.STEMP_Auxiliary a,STEMP_.DomainClass.STEMP_Exogenous ex)
        {
            EstimateOfAssociatedClasses(s, s1, r, a, ex);
        }

        //Declaration of the associated strategies
        STEMP _STEMP = new STEMP();

        private void EstimateOfAssociatedClasses(STEMP_.DomainClass.STEMP_State s,STEMP_.DomainClass.STEMP_State s1,STEMP_.DomainClass.STEMP_Rate r,STEMP_.DomainClass.STEMP_Auxiliary a,STEMP_.DomainClass.STEMP_Exogenous ex)
        {
            _stemp.Estimate(s,s1, r, a, ex);
        }

        public STEMP_Component(STEMP_Component toCopy): this() // copy constructor 
        {
                MSALB = toCopy.MSALB;
                NL = toCopy.NL;
                
            for (int i = 0; i < NL; i++)
            { LL[i] = toCopy.LL[i]; }
    
                NLAYR = toCopy.NLAYR;
                
            for (int i = 0; i < NL; i++)
            { DS[i] = toCopy.DS[i]; }
    
                
            for (int i = 0; i < NL; i++)
            { DLAYR[i] = toCopy.DLAYR[i]; }
    
                ISWWAT = toCopy.ISWWAT;
                
            for (int i = 0; i < NL; i++)
            { BD[i] = toCopy.BD[i]; }
    
                
            for (int i = 0; i < NL; i++)
            { SW[i] = toCopy.SW[i]; }
    
                XLAT = toCopy.XLAT;
                
            for (int i = 0; i < NL; i++)
            { DUL[i] = toCopy.DUL[i]; }
    
        }
    }
}