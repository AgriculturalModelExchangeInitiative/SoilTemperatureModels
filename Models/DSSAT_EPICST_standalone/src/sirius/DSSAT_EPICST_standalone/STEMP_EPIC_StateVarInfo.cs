
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySTEMP_EPIC_.DomainClass
{
    public class STEMP_EPIC_StateVarInfo : IVarInfoClass
    {
        static VarInfo _NDays = new VarInfo();
        static VarInfo _WetDay = new VarInfo();
        static VarInfo _TDL = new VarInfo();
        static VarInfo _X2_PREV = new VarInfo();
        static VarInfo _DSMID = new VarInfo();
        static VarInfo _TMA = new VarInfo();
        static VarInfo _SRFTEMP = new VarInfo();
        static VarInfo _ST = new VarInfo();
        static VarInfo _CUMDPT = new VarInfo();

        static STEMP_EPIC_StateVarInfo()
        {
            STEMP_EPIC_StateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "STEMP_EPIC_State Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "STEMP_EPIC_State";}
        }

        public static  VarInfo NDays
        {
            get { return _NDays;}
        }

        public static  VarInfo WetDay
        {
            get { return _WetDay;}
        }

        public static  VarInfo TDL
        {
            get { return _TDL;}
        }

        public static  VarInfo X2_PREV
        {
            get { return _X2_PREV;}
        }

        public static  VarInfo DSMID
        {
            get { return _DSMID;}
        }

        public static  VarInfo TMA
        {
            get { return _TMA;}
        }

        public static  VarInfo SRFTEMP
        {
            get { return _SRFTEMP;}
        }

        public static  VarInfo ST
        {
            get { return _ST;}
        }

        public static  VarInfo CUMDPT
        {
            get { return _CUMDPT;}
        }

        static void DescribeVariables()
        {
            _NDays.Name = "NDays";
            _NDays.Description = "Number of days ...";
            _NDays.MaxValue = -1D;
            _NDays.MinValue = -1D;
            _NDays.DefaultValue = -1D;
            _NDays.Units = "day";
            _NDays.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

            _WetDay.Name = "WetDay";
            _WetDay.Description = "Wet Days";
            _WetDay.MaxValue = -1D;
            _WetDay.MinValue = -1D;
            _WetDay.DefaultValue = -1D;
            _WetDay.Units = "day";
            _WetDay.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayInteger");

            _TDL.Name = "TDL";
            _TDL.Description = "Total water content of soil at drained upper limit";
            _TDL.MaxValue = -1D;
            _TDL.MinValue = -1D;
            _TDL.DefaultValue = -1D;
            _TDL.Units = "cm";
            _TDL.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _X2_PREV.Name = "X2_PREV";
            _X2_PREV.Description = "Temperature of soil surface at precedent timestep";
            _X2_PREV.MaxValue = -1D;
            _X2_PREV.MinValue = -1D;
            _X2_PREV.DefaultValue = -1D;
            _X2_PREV.Units = "degC";
            _X2_PREV.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _DSMID.Name = "DSMID";
            _DSMID.Description = "Depth to midpoint of soil layer NL";
            _DSMID.MaxValue = -1D;
            _DSMID.MinValue = -1D;
            _DSMID.DefaultValue = -1D;
            _DSMID.Units = "cm";
            _DSMID.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _TMA.Name = "TMA";
            _TMA.Description = "Array of previous 5 days of average soil temperatures.";
            _TMA.MaxValue = -1D;
            _TMA.MinValue = -1D;
            _TMA.DefaultValue = -1D;
            _TMA.Units = "degC";
            _TMA.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _SRFTEMP.Name = "SRFTEMP";
            _SRFTEMP.Description = "Temperature of soil surface litter";
            _SRFTEMP.MaxValue = -1D;
            _SRFTEMP.MinValue = -1D;
            _SRFTEMP.DefaultValue = -1D;
            _SRFTEMP.Units = "degC";
            _SRFTEMP.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _ST.Name = "ST";
            _ST.Description = "Soil temperature in soil layer NL";
            _ST.MaxValue = -1D;
            _ST.MinValue = -1D;
            _ST.DefaultValue = -1D;
            _ST.Units = "degC";
            _ST.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _CUMDPT.Name = "CUMDPT";
            _CUMDPT.Description = "Cumulative depth of soil profile";
            _CUMDPT.MaxValue = -1D;
            _CUMDPT.MinValue = -1D;
            _CUMDPT.DefaultValue = -1D;
            _CUMDPT.Units = "mm";
            _CUMDPT.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

        }

    }
}