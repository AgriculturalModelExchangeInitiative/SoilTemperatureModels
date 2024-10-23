
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySTEMP_.DomainClass
{
    public class STEMP_StateVarInfo : IVarInfoClass
    {
        static VarInfo _HDAY = new VarInfo();
        static VarInfo _SRFTEMP = new VarInfo();
        static VarInfo _ST = new VarInfo();
        static VarInfo _TMA = new VarInfo();
        static VarInfo _TDL = new VarInfo();
        static VarInfo _CUMDPT = new VarInfo();
        static VarInfo _ATOT = new VarInfo();
        static VarInfo _DSMID = new VarInfo();

        static STEMP_StateVarInfo()
        {
            STEMP_StateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "STEMP_State Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "STEMP_State";}
        }

        public static  VarInfo HDAY
        {
            get { return _HDAY;}
        }

        public static  VarInfo SRFTEMP
        {
            get { return _SRFTEMP;}
        }

        public static  VarInfo ST
        {
            get { return _ST;}
        }

        public static  VarInfo TMA
        {
            get { return _TMA;}
        }

        public static  VarInfo TDL
        {
            get { return _TDL;}
        }

        public static  VarInfo CUMDPT
        {
            get { return _CUMDPT;}
        }

        public static  VarInfo ATOT
        {
            get { return _ATOT;}
        }

        public static  VarInfo DSMID
        {
            get { return _DSMID;}
        }

        static void DescribeVariables()
        {
            _HDAY.Name = "HDAY";
            _HDAY.Description = "Haverst day";
            _HDAY.MaxValue = -1D;
            _HDAY.MinValue = -1D;
            _HDAY.DefaultValue = -1D;
            _HDAY.Units = "day";
            _HDAY.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SRFTEMP.Name = "SRFTEMP";
            _SRFTEMP.Description = "Temperature of soil surface litter";
            _SRFTEMP.MaxValue = -1D;
            _SRFTEMP.MinValue = -1D;
            _SRFTEMP.DefaultValue = -1D;
            _SRFTEMP.Units = "degC";
            _SRFTEMP.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _ST.Name = "ST";
            _ST.Description = "Soil temperature in soil layer L";
            _ST.MaxValue = -1D;
            _ST.MinValue = -1D;
            _ST.DefaultValue = -1D;
            _ST.Units = "degC";
            _ST.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _TMA.Name = "TMA";
            _TMA.Description = "Array of previous 5 days of average soil temperatures";
            _TMA.MaxValue = -1D;
            _TMA.MinValue = -1D;
            _TMA.DefaultValue = -1D;
            _TMA.Units = "degC";
            _TMA.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

            _TDL.Name = "TDL";
            _TDL.Description = "Total water content of soil at drained upper limit";
            _TDL.MaxValue = -1D;
            _TDL.MinValue = -1D;
            _TDL.DefaultValue = -1D;
            _TDL.Units = "cm";
            _TDL.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _CUMDPT.Name = "CUMDPT";
            _CUMDPT.Description = "Cumulative depth of soil profile";
            _CUMDPT.MaxValue = -1D;
            _CUMDPT.MinValue = -1D;
            _CUMDPT.DefaultValue = -1D;
            _CUMDPT.Units = "mm";
            _CUMDPT.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _ATOT.Name = "ATOT";
            _ATOT.Description = "Sum of TMA array (last 5 days soil temperature)";
            _ATOT.MaxValue = -1D;
            _ATOT.MinValue = -1D;
            _ATOT.DefaultValue = -1D;
            _ATOT.Units = "degC";
            _ATOT.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _DSMID.Name = "DSMID";
            _DSMID.Description = "Depth to midpoint of soil layer L";
            _DSMID.MaxValue = -1D;
            _DSMID.MinValue = -1D;
            _DSMID.DefaultValue = -1D;
            _DSMID.Units = "cm";
            _DSMID.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

        }

    }
}