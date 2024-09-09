
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace campbell.DomainClass
                                {
                                    public class campbellStateVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _soilTemp = new VarInfo();
                                        static VarInfo _maxTempYesterday = new VarInfo();
                                        static VarInfo _minTempYesterday = new VarInfo();
                                        static VarInfo _maxSoilTemp = new VarInfo();
                                        static VarInfo _aveSoilTemp = new VarInfo();
                                        static VarInfo _morningSoilTemp = new VarInfo();
                                        static VarInfo _tempNew = new VarInfo();
                                        static VarInfo _heatCapacity = new VarInfo();
                                        static VarInfo _thermalCondPar1 = new VarInfo();
                                        static VarInfo _thermalCondPar2 = new VarInfo();
                                        static VarInfo _thermalCondPar3 = new VarInfo();
                                        static VarInfo _thermalCondPar4 = new VarInfo();
                                        static VarInfo _thermalConductivity = new VarInfo();
                                        static VarInfo _thermalConductance = new VarInfo();
                                        static VarInfo _heatStorage = new VarInfo();
                                        static VarInfo _airPressure = new VarInfo();

                                        static campbellStateVarInfo()
                                        {
                                            campbellStateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "campbellState Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "campbellState";}
                                        }

                                        public static  VarInfo soilTemp
                                        {
                                            get { return _soilTemp;}
                                        }

                                        public static  VarInfo maxTempYesterday
                                        {
                                            get { return _maxTempYesterday;}
                                        }

                                        public static  VarInfo minTempYesterday
                                        {
                                            get { return _minTempYesterday;}
                                        }

                                        public static  VarInfo maxSoilTemp
                                        {
                                            get { return _maxSoilTemp;}
                                        }

                                        public static  VarInfo aveSoilTemp
                                        {
                                            get { return _aveSoilTemp;}
                                        }

                                        public static  VarInfo morningSoilTemp
                                        {
                                            get { return _morningSoilTemp;}
                                        }

                                        public static  VarInfo tempNew
                                        {
                                            get { return _tempNew;}
                                        }

                                        public static  VarInfo heatCapacity
                                        {
                                            get { return _heatCapacity;}
                                        }

                                        public static  VarInfo thermalCondPar1
                                        {
                                            get { return _thermalCondPar1;}
                                        }

                                        public static  VarInfo thermalCondPar2
                                        {
                                            get { return _thermalCondPar2;}
                                        }

                                        public static  VarInfo thermalCondPar3
                                        {
                                            get { return _thermalCondPar3;}
                                        }

                                        public static  VarInfo thermalCondPar4
                                        {
                                            get { return _thermalCondPar4;}
                                        }

                                        public static  VarInfo thermalConductivity
                                        {
                                            get { return _thermalConductivity;}
                                        }

                                        public static  VarInfo thermalConductance
                                        {
                                            get { return _thermalConductance;}
                                        }

                                        public static  VarInfo heatStorage
                                        {
                                            get { return _heatStorage;}
                                        }

                                        public static  VarInfo airPressure
                                        {
                                            get { return _airPressure;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _soilTemp.Name = "soilTemp";
                                            _soilTemp.Description = "Temperature at end of last time-step within a day - midnight in layers";
                                            _soilTemp.MaxValue = -1D;
                                            _soilTemp.MinValue = -1D;
                                            _soilTemp.DefaultValue = -1D;
                                            _soilTemp.Units = "degC";
                                            _soilTemp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _maxTempYesterday.Name = "maxTempYesterday";
                                            _maxTempYesterday.Description = "Max temperature at previous day";
                                            _maxTempYesterday.MaxValue = 60.;
                                            _maxTempYesterday.MinValue = -60.;
                                            _maxTempYesterday.DefaultValue = -1D;
                                            _maxTempYesterday.Units = "degC";
                                            _maxTempYesterday.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _minTempYesterday.Name = "minTempYesterday";
                                            _minTempYesterday.Description = "Min temperature at previous day";
                                            _minTempYesterday.MaxValue = 60.;
                                            _minTempYesterday.MinValue = -60.;
                                            _minTempYesterday.DefaultValue = -1D;
                                            _minTempYesterday.Units = "degC";
                                            _minTempYesterday.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _maxSoilTemp.Name = "maxSoilTemp";
                                            _maxSoilTemp.Description = "Maximum soil temperature in layers";
                                            _maxSoilTemp.MaxValue = -1D;
                                            _maxSoilTemp.MinValue = -1D;
                                            _maxSoilTemp.DefaultValue = -1D;
                                            _maxSoilTemp.Units = "degC";
                                            _maxSoilTemp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _aveSoilTemp.Name = "aveSoilTemp";
                                            _aveSoilTemp.Description = "Temperature averaged over all time-steps within a day in layers.";
                                            _aveSoilTemp.MaxValue = -1D;
                                            _aveSoilTemp.MinValue = -1D;
                                            _aveSoilTemp.DefaultValue = -1D;
                                            _aveSoilTemp.Units = "degC";
                                            _aveSoilTemp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _morningSoilTemp.Name = "morningSoilTemp";
                                            _morningSoilTemp.Description = "Temperature  in the morning in layers.";
                                            _morningSoilTemp.MaxValue = -1D;
                                            _morningSoilTemp.MinValue = -1D;
                                            _morningSoilTemp.DefaultValue = -1D;
                                            _morningSoilTemp.Units = "degC";
                                            _morningSoilTemp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _tempNew.Name = "tempNew";
                                            _tempNew.Description = "Soil temperature at the end of one iteration";
                                            _tempNew.MaxValue = -1D;
                                            _tempNew.MinValue = -1D;
                                            _tempNew.DefaultValue = -1D;
                                            _tempNew.Units = "degC";
                                            _tempNew.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _heatCapacity.Name = "heatCapacity";
                                            _heatCapacity.Description = "Heat Capacity in layers";
                                            _heatCapacity.MaxValue = -1D;
                                            _heatCapacity.MinValue = -1D;
                                            _heatCapacity.DefaultValue = -1D;
                                            _heatCapacity.Units = "J/m3/K/s";
                                            _heatCapacity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _thermalCondPar1.Name = "thermalCondPar1";
                                            _thermalCondPar1.Description = "thermal conductivity coeff in layers";
                                            _thermalCondPar1.MaxValue = -1D;
                                            _thermalCondPar1.MinValue = -1D;
                                            _thermalCondPar1.DefaultValue = -1D;
                                            _thermalCondPar1.Units = "(W/m2/K)";
                                            _thermalCondPar1.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _thermalCondPar2.Name = "thermalCondPar2";
                                            _thermalCondPar2.Description = "thermal conductivity coeff in layers";
                                            _thermalCondPar2.MaxValue = -1D;
                                            _thermalCondPar2.MinValue = -1D;
                                            _thermalCondPar2.DefaultValue = -1D;
                                            _thermalCondPar2.Units = "(W/m2/K)";
                                            _thermalCondPar2.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _thermalCondPar3.Name = "thermalCondPar3";
                                            _thermalCondPar3.Description = "thermal conductivity coeff in layers";
                                            _thermalCondPar3.MaxValue = -1D;
                                            _thermalCondPar3.MinValue = -1D;
                                            _thermalCondPar3.DefaultValue = -1D;
                                            _thermalCondPar3.Units = "(W/m2/K)";
                                            _thermalCondPar3.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _thermalCondPar4.Name = "thermalCondPar4";
                                            _thermalCondPar4.Description = "thermal conductivity coeff in layers";
                                            _thermalCondPar4.MaxValue = -1D;
                                            _thermalCondPar4.MinValue = -1D;
                                            _thermalCondPar4.DefaultValue = -1D;
                                            _thermalCondPar4.Units = "(W/m2/K)";
                                            _thermalCondPar4.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _thermalConductivity.Name = "thermalConductivity";
                                            _thermalConductivity.Description = "thermal conductivity in layers";
                                            _thermalConductivity.MaxValue = -1D;
                                            _thermalConductivity.MinValue = -1D;
                                            _thermalConductivity.DefaultValue = -1D;
                                            _thermalConductivity.Units = "(W/m2/K)";
                                            _thermalConductivity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _thermalConductance.Name = "thermalConductance";
                                            _thermalConductance.Description = "Thermal conductance between layers";
                                            _thermalConductance.MaxValue = -1D;
                                            _thermalConductance.MinValue = -1D;
                                            _thermalConductance.DefaultValue = -1D;
                                            _thermalConductance.Units = "";
                                            _thermalConductance.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _heatStorage.Name = "heatStorage";
                                            _heatStorage.Description = "Heat storage between layers (internal)";
                                            _heatStorage.MaxValue = -1D;
                                            _heatStorage.MinValue = -1D;
                                            _heatStorage.DefaultValue = -1D;
                                            _heatStorage.Units = "J/s/K";
                                            _heatStorage.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _airPressure.Name = "airPressure";
                                            _airPressure.Description = "Air pressure";
                                            _airPressure.MaxValue = -1D;
                                            _airPressure.MinValue = -1D;
                                            _airPressure.DefaultValue = -1D;
                                            _airPressure.Units = "hPa";
                                            _airPressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }