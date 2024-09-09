
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace campbell.DomainClass
                                {
                                    public class campbellExogenousVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _SRAD = new VarInfo();
                                        static VarInfo _TMIN = new VarInfo();
                                        static VarInfo _DOY = new VarInfo();
                                        static VarInfo _SW = new VarInfo();
                                        static VarInfo _EOAD = new VarInfo();
                                        static VarInfo _ESP = new VarInfo();
                                        static VarInfo _TAV = new VarInfo();
                                        static VarInfo _ESAD = new VarInfo();
                                        static VarInfo _canopyHeight = new VarInfo();
                                        static VarInfo _TMAX = new VarInfo();
                                        static VarInfo _ES = new VarInfo();

                                        static campbellExogenousVarInfo()
                                        {
                                            campbellExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "campbellExogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "campbellExogenous";}
                                        }

                                        public static  VarInfo SRAD
                                        {
                                            get { return _SRAD;}
                                        }

                                        public static  VarInfo TMIN
                                        {
                                            get { return _TMIN;}
                                        }

                                        public static  VarInfo DOY
                                        {
                                            get { return _DOY;}
                                        }

                                        public static  VarInfo SW
                                        {
                                            get { return _SW;}
                                        }

                                        public static  VarInfo EOAD
                                        {
                                            get { return _EOAD;}
                                        }

                                        public static  VarInfo ESP
                                        {
                                            get { return _ESP;}
                                        }

                                        public static  VarInfo TAV
                                        {
                                            get { return _TAV;}
                                        }

                                        public static  VarInfo ESAD
                                        {
                                            get { return _ESAD;}
                                        }

                                        public static  VarInfo canopyHeight
                                        {
                                            get { return _canopyHeight;}
                                        }

                                        public static  VarInfo TMAX
                                        {
                                            get { return _TMAX;}
                                        }

                                        public static  VarInfo ES
                                        {
                                            get { return _ES;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _SRAD.Name = "SRAD";
                                            _SRAD.Description = "Radiation";
                                            _SRAD.MaxValue = -1D;
                                            _SRAD.MinValue = 0;
                                            _SRAD.DefaultValue = -1D;
                                            _SRAD.Units = "MJ/m2-day";
                                            _SRAD.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

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
                                            _DOY.MinValue = 0;
                                            _DOY.DefaultValue = 0;
                                            _DOY.Units = "dimensionless";
                                            _DOY.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

                                            _SW.Name = "SW";
                                            _SW.Description = "volumetric water content";
                                            _SW.MaxValue = -1D;
                                            _SW.MinValue = -1D;
                                            _SW.DefaultValue = -1D;
                                            _SW.Units = "cc water / cc soil";
                                            _SW.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _EOAD.Name = "EOAD";
                                            _EOAD.Description = "Potential evapotranspiration";
                                            _EOAD.MaxValue = -1D;
                                            _EOAD.MinValue = 0;
                                            _EOAD.DefaultValue = -1D;
                                            _EOAD.Units = "mm";
                                            _EOAD.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _ESP.Name = "ESP";
                                            _ESP.Description = "Potential evaporation";
                                            _ESP.MaxValue = -1D;
                                            _ESP.MinValue = 0;
                                            _ESP.DefaultValue = -1D;
                                            _ESP.Units = "mm";
                                            _ESP.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _TAV.Name = "TAV";
                                            _TAV.Description = "Average daily Air temperature";
                                            _TAV.MaxValue = 60;
                                            _TAV.MinValue = -60;
                                            _TAV.DefaultValue = -1D;
                                            _TAV.Units = "";
                                            _TAV.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _ESAD.Name = "ESAD";
                                            _ESAD.Description = "Actual evapotranspiration";
                                            _ESAD.MaxValue = -1D;
                                            _ESAD.MinValue = 0;
                                            _ESAD.DefaultValue = -1D;
                                            _ESAD.Units = "mm";
                                            _ESAD.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _canopyHeight.Name = "canopyHeight";
                                            _canopyHeight.Description = "height of canopy above ground";
                                            _canopyHeight.MaxValue = -1D;
                                            _canopyHeight.MinValue = 0;
                                            _canopyHeight.DefaultValue = 0.057;
                                            _canopyHeight.Units = "m";
                                            _canopyHeight.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _TMAX.Name = "TMAX";
                                            _TMAX.Description = "Max daily Air temperature";
                                            _TMAX.MaxValue = 60;
                                            _TMAX.MinValue = -60;
                                            _TMAX.DefaultValue = -1D;
                                            _TMAX.Units = "";
                                            _TMAX.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _ES.Name = "ES";
                                            _ES.Description = "Actual evaporation";
                                            _ES.MaxValue = -1D;
                                            _ES.MinValue = 0;
                                            _ES.DefaultValue = -1D;
                                            _ES.Units = "mm";
                                            _ES.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }