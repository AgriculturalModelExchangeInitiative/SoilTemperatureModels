
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace campbell.DomainClass
                                {
                                    public class campbellAuxiliaryVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _minSoilTemp = new VarInfo();

                                        static campbellAuxiliaryVarInfo()
                                        {
                                            campbellAuxiliaryVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "campbellAuxiliary Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "campbellAuxiliary";}
                                        }

                                        public static  VarInfo minSoilTemp
                                        {
                                            get { return _minSoilTemp;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _minSoilTemp.Name = "minSoilTemp";
                                            _minSoilTemp.Description = "Minimum soil temperature in layers";
                                            _minSoilTemp.MaxValue = -1D;
                                            _minSoilTemp.MinValue = -1D;
                                            _minSoilTemp.DefaultValue = -1D;
                                            _minSoilTemp.Units = "degC";
                                            _minSoilTemp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                        }

                                    }
                                }