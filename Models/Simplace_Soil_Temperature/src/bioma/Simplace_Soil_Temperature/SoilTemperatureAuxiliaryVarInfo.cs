
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SoilTemperature.DomainClass
                                {
                                    public class SoilTemperatureAuxiliaryVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _SoilTempArray = new VarInfo();
                                        static VarInfo _iSoilTempArray = new VarInfo();
                                        static VarInfo _SnowIsolationIndex = new VarInfo();
                                        static VarInfo _iSoilSurfaceTemperature = new VarInfo();

                                        static SoilTemperatureAuxiliaryVarInfo()
                                        {
                                            SoilTemperatureAuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "SoilTemperatureAuxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "SoilTemperatureAuxiliary";}
                                        }

                                        public static  VarInfo SoilTempArray
                                        {
                                            get { return _SoilTempArray;}
                                        }

                                        public static  VarInfo iSoilTempArray
                                        {
                                            get { return _iSoilTempArray;}
                                        }

                                        public static  VarInfo SnowIsolationIndex
                                        {
                                            get { return _SnowIsolationIndex;}
                                        }

                                        public static  VarInfo iSoilSurfaceTemperature
                                        {
                                            get { return _iSoilSurfaceTemperature;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _SoilTempArray.Name = "SoilTempArray";
                                            _SoilTempArray.Description = "Soil Temp array of last day";
                                            _SoilTempArray.MaxValue = -1D;
                                            _SoilTempArray.MinValue = -1D;
                                            _SoilTempArray.DefaultValue = -1D;
                                            _SoilTempArray.Units = "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius";
                                            _SoilTempArray.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _iSoilTempArray.Name = "iSoilTempArray";
                                            _iSoilTempArray.Description = "Soil Temp array of last day";
                                            _iSoilTempArray.MaxValue = -1D;
                                            _iSoilTempArray.MinValue = -1D;
                                            _iSoilTempArray.DefaultValue = -1D;
                                            _iSoilTempArray.Units = "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius";
                                            _iSoilTempArray.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SnowIsolationIndex.Name = "SnowIsolationIndex";
                                            _SnowIsolationIndex.Description = "Snow isolation index";
                                            _SnowIsolationIndex.MaxValue = 1.0;
                                            _SnowIsolationIndex.MinValue = 0.0;
                                            _SnowIsolationIndex.DefaultValue = -1D;
                                            _SnowIsolationIndex.Units = "http://www.wurvoc.org/vocabularies/om-1.8/one";
                                            _SnowIsolationIndex.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _iSoilSurfaceTemperature.Name = "iSoilSurfaceTemperature";
                                            _iSoilSurfaceTemperature.Description = "Temperature at soil surface";
                                            _iSoilSurfaceTemperature.MaxValue = 20.0;
                                            _iSoilSurfaceTemperature.MinValue = 1.5;
                                            _iSoilSurfaceTemperature.DefaultValue = -1D;
                                            _iSoilSurfaceTemperature.Units = "http://www.wurvoc.org/vocabularies/om-1.8/degree_Celsius";
                                            _iSoilSurfaceTemperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }