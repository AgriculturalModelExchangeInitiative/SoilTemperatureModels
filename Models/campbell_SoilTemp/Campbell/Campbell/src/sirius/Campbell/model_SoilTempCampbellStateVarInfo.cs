
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace SiriusQualitymodel_SoilTempCampbell.DomainClass
                                {
                                    public class model_SoilTempCampbellStateVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _airPressure = new VarInfo();
                                        static VarInfo _soilTemp = new VarInfo();
                                        static VarInfo _newTemperature = new VarInfo();
                                        static VarInfo _minSoilTemp = new VarInfo();
                                        static VarInfo _maxSoilTemp = new VarInfo();
                                        static VarInfo _aveSoilTemp = new VarInfo();
                                        static VarInfo _morningSoilTemp = new VarInfo();
                                        static VarInfo _thermalCondPar1 = new VarInfo();
                                        static VarInfo _thermalCondPar2 = new VarInfo();
                                        static VarInfo _thermalCondPar3 = new VarInfo();
                                        static VarInfo _thermalCondPar4 = new VarInfo();
                                        static VarInfo _thermalConductivity = new VarInfo();
                                        static VarInfo _thermalConductance = new VarInfo();
                                        static VarInfo _heatStorage = new VarInfo();
                                        static VarInfo _volSpecHeatSoil = new VarInfo();
                                        static VarInfo _maxTempYesterday = new VarInfo();
                                        static VarInfo _minTempYesterday = new VarInfo();
                                        static VarInfo _SLCARB = new VarInfo();
                                        static VarInfo _SLROCK = new VarInfo();
                                        static VarInfo _SLSILT = new VarInfo();
                                        static VarInfo _SLSAND = new VarInfo();
                                        static VarInfo __boundaryLayerConductance = new VarInfo();

                                        static model_SoilTempCampbellStateVarInfo()
                                        {
                                            model_SoilTempCampbellStateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "model_SoilTempCampbellState Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "model_SoilTempCampbellState";}
                                        }

                                        public static  VarInfo airPressure
                                        {
                                            get { return _airPressure;}
                                        }

                                        public static  VarInfo soilTemp
                                        {
                                            get { return _soilTemp;}
                                        }

                                        public static  VarInfo newTemperature
                                        {
                                            get { return _newTemperature;}
                                        }

                                        public static  VarInfo minSoilTemp
                                        {
                                            get { return _minSoilTemp;}
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

                                        public static  VarInfo volSpecHeatSoil
                                        {
                                            get { return _volSpecHeatSoil;}
                                        }

                                        public static  VarInfo maxTempYesterday
                                        {
                                            get { return _maxTempYesterday;}
                                        }

                                        public static  VarInfo minTempYesterday
                                        {
                                            get { return _minTempYesterday;}
                                        }

                                        public static  VarInfo SLCARB
                                        {
                                            get { return _SLCARB;}
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

                                        public static  VarInfo _boundaryLayerConductance
                                        {
                                            get { return __boundaryLayerConductance;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _airPressure.Name = "airPressure";
                                            _airPressure.Description = "Air pressure";
                                            _airPressure.MaxValue = -1D;
                                            _airPressure.MinValue = -1D;
                                            _airPressure.DefaultValue = 1010;
                                            _airPressure.Units = "hPA";
                                            _airPressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _soilTemp.Name = "soilTemp";
                                            _soilTemp.Description = "Temperature at end of last time-step within a day - midnight in layers";
                                            _soilTemp.MaxValue = -1D;
                                            _soilTemp.MinValue = -1D;
                                            _soilTemp.DefaultValue = -1D;
                                            _soilTemp.Units = "degC";
                                            _soilTemp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _newTemperature.Name = "newTemperature";
                                            _newTemperature.Description = "Soil temperature at the end of one iteration";
                                            _newTemperature.MaxValue = -1D;
                                            _newTemperature.MinValue = -1D;
                                            _newTemperature.DefaultValue = -1D;
                                            _newTemperature.Units = "degC";
                                            _newTemperature.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _minSoilTemp.Name = "minSoilTemp";
                                            _minSoilTemp.Description = "Minimum soil temperature in layers";
                                            _minSoilTemp.MaxValue = -1D;
                                            _minSoilTemp.MinValue = -1D;
                                            _minSoilTemp.DefaultValue = -1D;
                                            _minSoilTemp.Units = "degC";
                                            _minSoilTemp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

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
                                            _thermalConductance.Units = "(W/m2/K)";
                                            _thermalConductance.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _heatStorage.Name = "heatStorage";
                                            _heatStorage.Description = "Heat storage between layers (internal)";
                                            _heatStorage.MaxValue = -1D;
                                            _heatStorage.MinValue = -1D;
                                            _heatStorage.DefaultValue = -1D;
                                            _heatStorage.Units = "J/s/K";
                                            _heatStorage.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _volSpecHeatSoil.Name = "volSpecHeatSoil";
                                            _volSpecHeatSoil.Description = "Volumetric specific heat over the soil profile";
                                            _volSpecHeatSoil.MaxValue = -1D;
                                            _volSpecHeatSoil.MinValue = -1D;
                                            _volSpecHeatSoil.DefaultValue = -1D;
                                            _volSpecHeatSoil.Units = "J/K/m3";
                                            _volSpecHeatSoil.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _maxTempYesterday.Name = "maxTempYesterday";
                                            _maxTempYesterday.Description = "Air max temperature from previous day";
                                            _maxTempYesterday.MaxValue = 60;
                                            _maxTempYesterday.MinValue = -60;
                                            _maxTempYesterday.DefaultValue = -1D;
                                            _maxTempYesterday.Units = "";
                                            _maxTempYesterday.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _minTempYesterday.Name = "minTempYesterday";
                                            _minTempYesterday.Description = "Air min temperature from previous day";
                                            _minTempYesterday.MaxValue = 60;
                                            _minTempYesterday.MinValue = -60;
                                            _minTempYesterday.DefaultValue = -1D;
                                            _minTempYesterday.Units = "";
                                            _minTempYesterday.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _SLCARB.Name = "SLCARB";
                                            _SLCARB.Description = "Volumetric fraction of organic matter in the soil";
                                            _SLCARB.MaxValue = -1D;
                                            _SLCARB.MinValue = -1D;
                                            _SLCARB.DefaultValue = -1D;
                                            _SLCARB.Units = "";
                                            _SLCARB.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SLROCK.Name = "SLROCK";
                                            _SLROCK.Description = "Volumetric fraction of rocks in the soil";
                                            _SLROCK.MaxValue = -1D;
                                            _SLROCK.MinValue = -1D;
                                            _SLROCK.DefaultValue = -1D;
                                            _SLROCK.Units = "";
                                            _SLROCK.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SLSILT.Name = "SLSILT";
                                            _SLSILT.Description = "Volumetric fraction of silt in the soil";
                                            _SLSILT.MaxValue = -1D;
                                            _SLSILT.MinValue = -1D;
                                            _SLSILT.DefaultValue = -1D;
                                            _SLSILT.Units = "";
                                            _SLSILT.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SLSAND.Name = "SLSAND";
                                            _SLSAND.Description = "Volumetric fraction of sand in the soil";
                                            _SLSAND.MaxValue = -1D;
                                            _SLSAND.MinValue = -1D;
                                            _SLSAND.DefaultValue = -1D;
                                            _SLSAND.Units = "";
                                            _SLSAND.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            __boundaryLayerConductance.Name = "_boundaryLayerConductance";
                                            __boundaryLayerConductance.Description = "Boundary layer conductance";
                                            __boundaryLayerConductance.MaxValue = -1D;
                                            __boundaryLayerConductance.MinValue = -1D;
                                            __boundaryLayerConductance.DefaultValue = -1D;
                                            __boundaryLayerConductance.Units = "K/W";
                                            __boundaryLayerConductance.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                        }

                                    }
                                }