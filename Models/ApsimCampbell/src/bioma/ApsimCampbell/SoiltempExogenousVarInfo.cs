
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace Soiltemp.DomainClass
                                {
                                    public class SoiltempExogenousVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _waterBalance_Eo = new VarInfo();
                                        static VarInfo _waterBalance_Salb = new VarInfo();
                                        static VarInfo _organic_Carbon = new VarInfo();
                                        static VarInfo _waterBalance_Es = new VarInfo();
                                        static VarInfo _weather_Wind = new VarInfo();
                                        static VarInfo _physical_ParticleSizeSand = new VarInfo();
                                        static VarInfo _weather_AirPressure = new VarInfo();
                                        static VarInfo _clock_Today_DayOfYear = new VarInfo();
                                        static VarInfo _microClimate_CanopyHeight = new VarInfo();
                                        static VarInfo _waterBalance_Eos = new VarInfo();
                                        static VarInfo _waterBalance_SW = new VarInfo();
                                        static VarInfo _weather_Amp = new VarInfo();
                                        static VarInfo _weather_MinT = new VarInfo();
                                        static VarInfo _weather_Radn = new VarInfo();
                                        static VarInfo _physical_Rocks = new VarInfo();
                                        static VarInfo _weather_Tav = new VarInfo();
                                        static VarInfo _weather_MaxT = new VarInfo();
                                        static VarInfo _weather_MeanT = new VarInfo();
                                        static VarInfo _physical_ParticleSizeSilt = new VarInfo();
                                        static VarInfo _physical_ParticleSizeClay = new VarInfo();

                                        static SoiltempExogenousVarInfo()
                                        {
                                            SoiltempExogenousVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "SoiltempExogenous Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "SoiltempExogenous";}
                                        }

                                        public static  VarInfo waterBalance_Eo
                                        {
                                            get { return _waterBalance_Eo;}
                                        }

                                        public static  VarInfo waterBalance_Salb
                                        {
                                            get { return _waterBalance_Salb;}
                                        }

                                        public static  VarInfo organic_Carbon
                                        {
                                            get { return _organic_Carbon;}
                                        }

                                        public static  VarInfo waterBalance_Es
                                        {
                                            get { return _waterBalance_Es;}
                                        }

                                        public static  VarInfo weather_Wind
                                        {
                                            get { return _weather_Wind;}
                                        }

                                        public static  VarInfo physical_ParticleSizeSand
                                        {
                                            get { return _physical_ParticleSizeSand;}
                                        }

                                        public static  VarInfo weather_AirPressure
                                        {
                                            get { return _weather_AirPressure;}
                                        }

                                        public static  VarInfo clock_Today_DayOfYear
                                        {
                                            get { return _clock_Today_DayOfYear;}
                                        }

                                        public static  VarInfo microClimate_CanopyHeight
                                        {
                                            get { return _microClimate_CanopyHeight;}
                                        }

                                        public static  VarInfo waterBalance_Eos
                                        {
                                            get { return _waterBalance_Eos;}
                                        }

                                        public static  VarInfo waterBalance_SW
                                        {
                                            get { return _waterBalance_SW;}
                                        }

                                        public static  VarInfo weather_Amp
                                        {
                                            get { return _weather_Amp;}
                                        }

                                        public static  VarInfo weather_MinT
                                        {
                                            get { return _weather_MinT;}
                                        }

                                        public static  VarInfo weather_Radn
                                        {
                                            get { return _weather_Radn;}
                                        }

                                        public static  VarInfo physical_Rocks
                                        {
                                            get { return _physical_Rocks;}
                                        }

                                        public static  VarInfo weather_Tav
                                        {
                                            get { return _weather_Tav;}
                                        }

                                        public static  VarInfo weather_MaxT
                                        {
                                            get { return _weather_MaxT;}
                                        }

                                        public static  VarInfo weather_MeanT
                                        {
                                            get { return _weather_MeanT;}
                                        }

                                        public static  VarInfo physical_ParticleSizeSilt
                                        {
                                            get { return _physical_ParticleSizeSilt;}
                                        }

                                        public static  VarInfo physical_ParticleSizeClay
                                        {
                                            get { return _physical_ParticleSizeClay;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _waterBalance_Eo.Name = "waterBalance_Eo";
                                            _waterBalance_Eo.Description = "Potential soil evapotranspiration from soil surface";
                                            _waterBalance_Eo.MaxValue = -1D;
                                            _waterBalance_Eo.MinValue = -1D;
                                            _waterBalance_Eo.DefaultValue = -1D;
                                            _waterBalance_Eo.Units = "mm";
                                            _waterBalance_Eo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _waterBalance_Salb.Name = "waterBalance_Salb";
                                            _waterBalance_Salb.Description = "Fraction of incoming radiation reflected from bare soil";
                                            _waterBalance_Salb.MaxValue = -1D;
                                            _waterBalance_Salb.MinValue = -1D;
                                            _waterBalance_Salb.DefaultValue = -1D;
                                            _waterBalance_Salb.Units = "0-1";
                                            _waterBalance_Salb.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _organic_Carbon.Name = "organic_Carbon";
                                            _organic_Carbon.Description = "Total organic carbon";
                                            _organic_Carbon.MaxValue = -1D;
                                            _organic_Carbon.MinValue = -1D;
                                            _organic_Carbon.DefaultValue = -1D;
                                            _organic_Carbon.Units = "%";
                                            _organic_Carbon.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _waterBalance_Es.Name = "waterBalance_Es";
                                            _waterBalance_Es.Description = "Actual (realised) soil water evaporation";
                                            _waterBalance_Es.MaxValue = -1D;
                                            _waterBalance_Es.MinValue = -1D;
                                            _waterBalance_Es.DefaultValue = -1D;
                                            _waterBalance_Es.Units = "mm";
                                            _waterBalance_Es.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _weather_Wind.Name = "weather_Wind";
                                            _weather_Wind.Description = "Wind speed";
                                            _weather_Wind.MaxValue = -1D;
                                            _weather_Wind.MinValue = -1D;
                                            _weather_Wind.DefaultValue = -1D;
                                            _weather_Wind.Units = "m/s";
                                            _weather_Wind.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _physical_ParticleSizeSand.Name = "physical_ParticleSizeSand";
                                            _physical_ParticleSizeSand.Description = "Particle size sand";
                                            _physical_ParticleSizeSand.MaxValue = -1D;
                                            _physical_ParticleSizeSand.MinValue = -1D;
                                            _physical_ParticleSizeSand.DefaultValue = -1D;
                                            _physical_ParticleSizeSand.Units = "%";
                                            _physical_ParticleSizeSand.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _weather_AirPressure.Name = "weather_AirPressure";
                                            _weather_AirPressure.Description = "Air pressure";
                                            _weather_AirPressure.MaxValue = -1D;
                                            _weather_AirPressure.MinValue = -1D;
                                            _weather_AirPressure.DefaultValue = -1D;
                                            _weather_AirPressure.Units = "hPa";
                                            _weather_AirPressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _clock_Today_DayOfYear.Name = "clock_Today_DayOfYear";
                                            _clock_Today_DayOfYear.Description = "Day of year";
                                            _clock_Today_DayOfYear.MaxValue = -1D;
                                            _clock_Today_DayOfYear.MinValue = -1D;
                                            _clock_Today_DayOfYear.DefaultValue = -1D;
                                            _clock_Today_DayOfYear.Units = "day number";
                                            _clock_Today_DayOfYear.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

                                            _microClimate_CanopyHeight.Name = "microClimate_CanopyHeight";
                                            _microClimate_CanopyHeight.Description = "Canopy height";
                                            _microClimate_CanopyHeight.MaxValue = -1D;
                                            _microClimate_CanopyHeight.MinValue = -1D;
                                            _microClimate_CanopyHeight.DefaultValue = -1D;
                                            _microClimate_CanopyHeight.Units = "mm";
                                            _microClimate_CanopyHeight.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _waterBalance_Eos.Name = "waterBalance_Eos";
                                            _waterBalance_Eos.Description = "Potential soil evaporation from soil surface";
                                            _waterBalance_Eos.MaxValue = -1D;
                                            _waterBalance_Eos.MinValue = -1D;
                                            _waterBalance_Eos.DefaultValue = -1D;
                                            _waterBalance_Eos.Units = "mm";
                                            _waterBalance_Eos.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _waterBalance_SW.Name = "waterBalance_SW";
                                            _waterBalance_SW.Description = "Volumetric water content";
                                            _waterBalance_SW.MaxValue = -1D;
                                            _waterBalance_SW.MinValue = -1D;
                                            _waterBalance_SW.DefaultValue = -1D;
                                            _waterBalance_SW.Units = "mm/mm";
                                            _waterBalance_SW.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _weather_Amp.Name = "weather_Amp";
                                            _weather_Amp.Description = "Annual average temperature amplitude";
                                            _weather_Amp.MaxValue = -1D;
                                            _weather_Amp.MinValue = -1D;
                                            _weather_Amp.DefaultValue = -1D;
                                            _weather_Amp.Units = "oC";
                                            _weather_Amp.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _weather_MinT.Name = "weather_MinT";
                                            _weather_MinT.Description = "Minimum temperature";
                                            _weather_MinT.MaxValue = -1D;
                                            _weather_MinT.MinValue = -1D;
                                            _weather_MinT.DefaultValue = -1D;
                                            _weather_MinT.Units = "oC";
                                            _weather_MinT.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _weather_Radn.Name = "weather_Radn";
                                            _weather_Radn.Description = "Solar radiation";
                                            _weather_Radn.MaxValue = -1D;
                                            _weather_Radn.MinValue = -1D;
                                            _weather_Radn.DefaultValue = -1D;
                                            _weather_Radn.Units = "MJ/m2/day";
                                            _weather_Radn.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _physical_Rocks.Name = "physical_Rocks";
                                            _physical_Rocks.Description = "Rocks";
                                            _physical_Rocks.MaxValue = -1D;
                                            _physical_Rocks.MinValue = -1D;
                                            _physical_Rocks.DefaultValue = -1D;
                                            _physical_Rocks.Units = "%";
                                            _physical_Rocks.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _weather_Tav.Name = "weather_Tav";
                                            _weather_Tav.Description = "Annual average temperature";
                                            _weather_Tav.MaxValue = -1D;
                                            _weather_Tav.MinValue = -1D;
                                            _weather_Tav.DefaultValue = -1D;
                                            _weather_Tav.Units = "oC";
                                            _weather_Tav.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _weather_MaxT.Name = "weather_MaxT";
                                            _weather_MaxT.Description = "Maximum temperature";
                                            _weather_MaxT.MaxValue = -1D;
                                            _weather_MaxT.MinValue = -1D;
                                            _weather_MaxT.DefaultValue = -1D;
                                            _weather_MaxT.Units = "oC";
                                            _weather_MaxT.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _weather_MeanT.Name = "weather_MeanT";
                                            _weather_MeanT.Description = "Mean temperature";
                                            _weather_MeanT.MaxValue = -1D;
                                            _weather_MeanT.MinValue = -1D;
                                            _weather_MeanT.DefaultValue = -1D;
                                            _weather_MeanT.Units = "oC";
                                            _weather_MeanT.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _physical_ParticleSizeSilt.Name = "physical_ParticleSizeSilt";
                                            _physical_ParticleSizeSilt.Description = "Particle size silt";
                                            _physical_ParticleSizeSilt.MaxValue = -1D;
                                            _physical_ParticleSizeSilt.MinValue = -1D;
                                            _physical_ParticleSizeSilt.DefaultValue = -1D;
                                            _physical_ParticleSizeSilt.Units = "%";
                                            _physical_ParticleSizeSilt.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _physical_ParticleSizeClay.Name = "physical_ParticleSizeClay";
                                            _physical_ParticleSizeClay.Description = "Particle size clay";
                                            _physical_ParticleSizeClay.MaxValue = -1D;
                                            _physical_ParticleSizeClay.MinValue = -1D;
                                            _physical_ParticleSizeClay.DefaultValue = -1D;
                                            _physical_ParticleSizeClay.Units = "%";
                                            _physical_ParticleSizeClay.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                        }

                                    }
                                }