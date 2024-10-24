
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace model_SoilTempCampbell.DomainClass
                                {
                                    public class model_SoilTempCampbellExogenousVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _THICK = new VarInfo();
                                        static VarInfo _BD = new VarInfo();
                                        static VarInfo _SLCARB = new VarInfo();
                                        static VarInfo _CLAY = new VarInfo();
                                        static VarInfo _SLROCK = new VarInfo();
                                        static VarInfo _SLSILT = new VarInfo();
                                        static VarInfo _SLSAND = new VarInfo();
                                        static VarInfo _SW = new VarInfo();
                                        static VarInfo _T2M = new VarInfo();
                                        static VarInfo _TMAX = new VarInfo();
                                        static VarInfo _TMIN = new VarInfo();
                                        static VarInfo _TAV = new VarInfo();
                                        static VarInfo _DOY = new VarInfo();
                                        static VarInfo _airPressure = new VarInfo();
                                        static VarInfo _canopyHeight = new VarInfo();
                                        static VarInfo _SRAD = new VarInfo();
                                        static VarInfo _ESP = new VarInfo();
                                        static VarInfo _ES = new VarInfo();
                                        static VarInfo _EOAD = new VarInfo();
                                        static VarInfo _windSpeed = new VarInfo();

                                        static model_SoilTempCampbellExogenousVarInfo()
                                        {
                                            model_SoilTempCampbellExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "model_SoilTempCampbellExogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "model_SoilTempCampbellExogenous";}
                                        }

                                        public static  VarInfo THICK
                                        {
                                            get { return _THICK;}
                                        }

                                        public static  VarInfo BD
                                        {
                                            get { return _BD;}
                                        }

                                        public static  VarInfo SLCARB
                                        {
                                            get { return _SLCARB;}
                                        }

                                        public static  VarInfo CLAY
                                        {
                                            get { return _CLAY;}
                                        }

                                        public static  VarInfo SLROCK
                                        {
                                            get { return _SLROCK;}
                                        }

                                        public static  VarInfo SLSILT
                                        {
                                            get { return _SLSILT;}
                                        }

                                        public static  VarInfo SLSAND
                                        {
                                            get { return _SLSAND;}
                                        }

                                        public static  VarInfo SW
                                        {
                                            get { return _SW;}
                                        }

                                        public static  VarInfo T2M
                                        {
                                            get { return _T2M;}
                                        }

                                        public static  VarInfo TMAX
                                        {
                                            get { return _TMAX;}
                                        }

                                        public static  VarInfo TMIN
                                        {
                                            get { return _TMIN;}
                                        }

                                        public static  VarInfo TAV
                                        {
                                            get { return _TAV;}
                                        }

                                        public static  VarInfo DOY
                                        {
                                            get { return _DOY;}
                                        }

                                        public static  VarInfo airPressure
                                        {
                                            get { return _airPressure;}
                                        }

                                        public static  VarInfo canopyHeight
                                        {
                                            get { return _canopyHeight;}
                                        }

                                        public static  VarInfo SRAD
                                        {
                                            get { return _SRAD;}
                                        }

                                        public static  VarInfo ESP
                                        {
                                            get { return _ESP;}
                                        }

                                        public static  VarInfo ES
                                        {
                                            get { return _ES;}
                                        }

                                        public static  VarInfo EOAD
                                        {
                                            get { return _EOAD;}
                                        }

                                        public static  VarInfo windSpeed
                                        {
                                            get { return _windSpeed;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _THICK.Name = "THICK";
                                            _THICK.Description = "Soil layer depths as THICKApsim of layers";
                                            _THICK.MaxValue = -1D;
                                            _THICK.MinValue = -1D;
                                            _THICK.DefaultValue = -1D;
                                            _THICK.Units = "mm";
                                            _THICK.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _BD.Name = "BD";
                                            _BD.Description = "bd (soil bulk density)";
                                            _BD.MaxValue = -1D;
                                            _BD.MinValue = -1D;
                                            _BD.DefaultValue = -1D;
                                            _BD.Units = "g/cm3             uri :";
                                            _BD.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SLCARB.Name = "SLCARB";
                                            _SLCARB.Description = "Volumetric fraction of organic matter in the soil";
                                            _SLCARB.MaxValue = -1D;
                                            _SLCARB.MinValue = -1D;
                                            _SLCARB.DefaultValue = -1D;
                                            _SLCARB.Units = "";
                                            _SLCARB.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _CLAY.Name = "CLAY";
                                            _CLAY.Description = "Proportion of CLAYApsim in each layer of profile";
                                            _CLAY.MaxValue = -1D;
                                            _CLAY.MinValue = -1D;
                                            _CLAY.DefaultValue = -1D;
                                            _CLAY.Units = "";
                                            _CLAY.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SLROCK.Name = "SLROCK";
                                            _SLROCK.Description = "Volumetric fraction of SLROCKApsim in the soil";
                                            _SLROCK.MaxValue = -1D;
                                            _SLROCK.MinValue = -1D;
                                            _SLROCK.DefaultValue = -1D;
                                            _SLROCK.Units = "";
                                            _SLROCK.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SLSILT.Name = "SLSILT";
                                            _SLSILT.Description = "Volumetric fraction of SLSILTApsim in the soil";
                                            _SLSILT.MaxValue = -1D;
                                            _SLSILT.MinValue = -1D;
                                            _SLSILT.DefaultValue = -1D;
                                            _SLSILT.Units = "";
                                            _SLSILT.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SLSAND.Name = "SLSAND";
                                            _SLSAND.Description = "Volumetric fraction of SLSANDApsim in the soil";
                                            _SLSAND.MaxValue = -1D;
                                            _SLSAND.MinValue = -1D;
                                            _SLSAND.DefaultValue = -1D;
                                            _SLSAND.Units = "";
                                            _SLSAND.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SW.Name = "SW";
                                            _SW.Description = "volumetric water content";
                                            _SW.MaxValue = -1D;
                                            _SW.MinValue = -1D;
                                            _SW.DefaultValue = -1D;
                                            _SW.Units = "cc water / cc soil";
                                            _SW.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _T2M.Name = "T2M";
                                            _T2M.Description = "Mean daily Air temperature";
                                            _T2M.MaxValue = 60;
                                            _T2M.MinValue = -60;
                                            _T2M.DefaultValue = -1D;
                                            _T2M.Units = "";
                                            _T2M.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _TMAX.Name = "TMAX";
                                            _TMAX.Description = "Max daily Air temperature";
                                            _TMAX.MaxValue = 60;
                                            _TMAX.MinValue = -60;
                                            _TMAX.DefaultValue = -1D;
                                            _TMAX.Units = "";
                                            _TMAX.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _TMIN.Name = "TMIN";
                                            _TMIN.Description = "Min daily Air temperature";
                                            _TMIN.MaxValue = 60;
                                            _TMIN.MinValue = -60;
                                            _TMIN.DefaultValue = -1D;
                                            _TMIN.Units = "";
                                            _TMIN.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _TAV.Name = "TAV";
                                            _TAV.Description = "Average daily Air temperature";
                                            _TAV.MaxValue = 60;
                                            _TAV.MinValue = -60;
                                            _TAV.DefaultValue = -1D;
                                            _TAV.Units = "";
                                            _TAV.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _DOY.Name = "DOY";
                                            _DOY.Description = "Day of year";
                                            _DOY.MaxValue = 366;
                                            _DOY.MinValue = 1;
                                            _DOY.DefaultValue = 1;
                                            _DOY.Units = "dimensionless";
                                            _DOY.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

                                            _airPressure.Name = "airPressure";
                                            _airPressure.Description = "Air pressure";
                                            _airPressure.MaxValue = -1D;
                                            _airPressure.MinValue = -1D;
                                            _airPressure.DefaultValue = 1010;
                                            _airPressure.Units = "hPA";
                                            _airPressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _canopyHeight.Name = "canopyHeight";
                                            _canopyHeight.Description = "height of canopy above ground";
                                            _canopyHeight.MaxValue = -1D;
                                            _canopyHeight.MinValue = 0;
                                            _canopyHeight.DefaultValue = 0.057;
                                            _canopyHeight.Units = "m";
                                            _canopyHeight.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _SRAD.Name = "SRAD";
                                            _SRAD.Description = "Solar radiation";
                                            _SRAD.MaxValue = -1D;
                                            _SRAD.MinValue = 0;
                                            _SRAD.DefaultValue = -1D;
                                            _SRAD.Units = "MJ/m2";
                                            _SRAD.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _ESP.Name = "ESP";
                                            _ESP.Description = "Potential evaporation";
                                            _ESP.MaxValue = -1D;
                                            _ESP.MinValue = 0;
                                            _ESP.DefaultValue = -1D;
                                            _ESP.Units = "mm";
                                            _ESP.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _ES.Name = "ES";
                                            _ES.Description = "Actual evaporation";
                                            _ES.MaxValue = -1D;
                                            _ES.MinValue = 0;
                                            _ES.DefaultValue = -1D;
                                            _ES.Units = "mm";
                                            _ES.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _EOAD.Name = "EOAD";
                                            _EOAD.Description = "Potential evapotranspiration";
                                            _EOAD.MaxValue = -1D;
                                            _EOAD.MinValue = 0;
                                            _EOAD.DefaultValue = -1D;
                                            _EOAD.Units = "mm";
                                            _EOAD.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _windSpeed.Name = "windSpeed";
                                            _windSpeed.Description = "Speed of wind";
                                            _windSpeed.MaxValue = -1D;
                                            _windSpeed.MinValue = 0.0;
                                            _windSpeed.DefaultValue = 3.0;
                                            _windSpeed.Units = "m/s";
                                            _windSpeed.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }