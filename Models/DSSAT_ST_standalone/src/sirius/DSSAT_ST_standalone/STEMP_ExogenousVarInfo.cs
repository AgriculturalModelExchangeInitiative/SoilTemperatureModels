
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitySTEMP_.DomainClass
{
    public class STEMP_ExogenousVarInfo : IVarInfoClass
    {
        static VarInfo _TMAX = new VarInfo();
        static VarInfo _SRAD = new VarInfo();
        static VarInfo _TAMP = new VarInfo();
        static VarInfo _TAVG = new VarInfo();
        static VarInfo _TAV = new VarInfo();
        static VarInfo _DOY = new VarInfo();

        static STEMP_ExogenousVarInfo()
        {
            STEMP_ExogenousVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "STEMP_Exogenous Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "STEMP_Exogenous";}
        }

        public static  VarInfo TMAX
        {
            get { return _TMAX;}
        }

        public static  VarInfo SRAD
        {
            get { return _SRAD;}
        }

        public static  VarInfo TAMP
        {
            get { return _TAMP;}
        }

        public static  VarInfo TAVG
        {
            get { return _TAVG;}
        }

        public static  VarInfo TAV
        {
            get { return _TAV;}
        }

        public static  VarInfo DOY
        {
            get { return _DOY;}
        }

        static void DescribeVariables()
        {
            _TMAX.Name = "TMAX";
            _TMAX.Description = "Maximum daily temperature";
            _TMAX.MaxValue = -1D;
            _TMAX.MinValue = -1D;
            _TMAX.DefaultValue = -1D;
            _TMAX.Units = "degC";
            _TMAX.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _SRAD.Name = "SRAD";
            _SRAD.Description = "Solar radiation";
            _SRAD.MaxValue = -1D;
            _SRAD.MinValue = -1D;
            _SRAD.DefaultValue = -1D;
            _SRAD.Units = "MJ/m2-d";
            _SRAD.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _TAMP.Name = "TAMP";
            _TAMP.Description = "Amplitude of temperature function used to calculate soil temperatures";
            _TAMP.MaxValue = -1D;
            _TAMP.MinValue = -1D;
            _TAMP.DefaultValue = -1D;
            _TAMP.Units = "degC";
            _TAMP.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _TAVG.Name = "TAVG";
            _TAVG.Description = "Average daily temperature";
            _TAVG.MaxValue = -1D;
            _TAVG.MinValue = -1D;
            _TAVG.DefaultValue = -1D;
            _TAVG.Units = "degC";
            _TAVG.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _TAV.Name = "TAV";
            _TAV.Description = "Average annual soil temperature, used with TAMP to calculate soil temperature.";
            _TAV.MaxValue = -1D;
            _TAV.MinValue = -1D;
            _TAV.DefaultValue = -1D;
            _TAV.Units = "degC";
            _TAV.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _DOY.Name = "DOY";
            _DOY.Description = "Current day of simulation";
            _DOY.MaxValue = -1D;
            _DOY.MinValue = -1D;
            _DOY.DefaultValue = -1D;
            _DOY.Units = "d";
            _DOY.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

        }

    }
}