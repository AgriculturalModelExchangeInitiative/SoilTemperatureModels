
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SoilTemperature.DomainClass
{
    public class SoilTemperatureStateVarInfo : IVarInfoClass
    {
        static VarInfo _deepLayerT = new VarInfo();
        static VarInfo _maxTSoil = new VarInfo();
        static VarInfo _minTSoil = new VarInfo();
        static VarInfo _hourlySoilT = new VarInfo();

        static SoilTemperatureStateVarInfo()
        {
            SoilTemperatureStateVarInfo.DescribeVariables();
        }

        public virtual string Description
        {
            get { return "SoilTemperatureState Domain class of the component";}
        }

        public string URL
        {
            get { return "http://" ;}
        }

        public string DomainClassOfReference
        {
            get { return "SoilTemperatureState";}
        }

        public static  VarInfo deepLayerT
        {
            get { return _deepLayerT;}
        }

        public static  VarInfo maxTSoil
        {
            get { return _maxTSoil;}
        }

        public static  VarInfo minTSoil
        {
            get { return _minTSoil;}
        }

        public static  VarInfo hourlySoilT
        {
            get { return _hourlySoilT;}
        }

        static void DescribeVariables()
        {
            _deepLayerT.Name = "deepLayerT";
            _deepLayerT.Description = "Temperature of the last soil layer";
            _deepLayerT.MaxValue = 80;
            _deepLayerT.MinValue = -30;
            _deepLayerT.DefaultValue = -1D;
            _deepLayerT.Units = "°C";
            _deepLayerT.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _maxTSoil.Name = "maxTSoil";
            _maxTSoil.Description = "Maximum Soil Temperature";
            _maxTSoil.MaxValue = 80;
            _maxTSoil.MinValue = -30;
            _maxTSoil.DefaultValue = -1D;
            _maxTSoil.Units = "°C";
            _maxTSoil.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _minTSoil.Name = "minTSoil";
            _minTSoil.Description = "Minimum Soil Temperature";
            _minTSoil.MaxValue = 80;
            _minTSoil.MinValue = -30;
            _minTSoil.DefaultValue = -1D;
            _minTSoil.Units = "°C";
            _minTSoil.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

            _hourlySoilT.Name = "hourlySoilT";
            _hourlySoilT.Description = "Hourly Soil Temperature";
            _hourlySoilT.MaxValue = -1D;
            _hourlySoilT.MinValue = -1D;
            _hourlySoilT.DefaultValue = -1D;
            _hourlySoilT.Units = "°C";
            _hourlySoilT.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

        }

    }
}