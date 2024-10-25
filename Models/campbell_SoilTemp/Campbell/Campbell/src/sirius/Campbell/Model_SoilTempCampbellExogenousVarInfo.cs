
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualityModel_SoilTempCampbell.DomainClass
                                {
                                    public class Model_SoilTempCampbellExogenousVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _T2M = new VarInfo();
                                        static VarInfo _TMAX = new VarInfo();
                                        static VarInfo _TMIN = new VarInfo();
                                        static VarInfo _DOY = new VarInfo();
                                        static VarInfo _airPressure = new VarInfo();
                                        static VarInfo _canopyHeight = new VarInfo();
                                        static VarInfo _SRAD = new VarInfo();
                                        static VarInfo _ESP = new VarInfo();
                                        static VarInfo _ES = new VarInfo();
                                        static VarInfo _EOAD = new VarInfo();
                                        static VarInfo _windSpeed = new VarInfo();

                                        static Model_SoilTempCampbellExogenousVarInfo()
                                        {
                                            Model_SoilTempCampbellExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "Model_SoilTempCampbellExogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "Model_SoilTempCampbellExogenous";}
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