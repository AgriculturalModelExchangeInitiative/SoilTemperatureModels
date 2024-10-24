
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace model_SoilTempCampbell.DomainClass
                                {
                                    public class model_SoilTempCampbellStateVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _THICKApsim = new VarInfo();
                                        static VarInfo _DEPTHApsim = new VarInfo();
                                        static VarInfo _BDApsim = new VarInfo();
                                        static VarInfo _CLAYApsim = new VarInfo();
                                        static VarInfo _SWApsim = new VarInfo();
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
                                        static VarInfo _SLCARBApsim = new VarInfo();
                                        static VarInfo _SLROCKApsim = new VarInfo();
                                        static VarInfo _SLSILTApsim = new VarInfo();
                                        static VarInfo _SLSANDApsim = new VarInfo();
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

                                        public static  VarInfo THICKApsim
                                        {
                                            get { return _THICKApsim;}
                                        }

                                        public static  VarInfo DEPTHApsim
                                        {
                                            get { return _DEPTHApsim;}
                                        }

                                        public static  VarInfo BDApsim
                                        {
                                            get { return _BDApsim;}
                                        }

                                        public static  VarInfo CLAYApsim
                                        {
                                            get { return _CLAYApsim;}
                                        }

                                        public static  VarInfo SWApsim
                                        {
                                            get { return _SWApsim;}
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

                                        public static  VarInfo SLCARBApsim
                                        {
                                            get { return _SLCARBApsim;}
                                        }

                                        public static  VarInfo SLROCKApsim
                                        {
                                            get { return _SLROCKApsim;}
                                        }

                                        public static  VarInfo SLSILTApsim
                                        {
                                            get { return _SLSILTApsim;}
                                        }

                                        public static  VarInfo SLSANDApsim
                                        {
                                            get { return _SLSANDApsim;}
                                        }

                                        public static  VarInfo _boundaryLayerConductance
                                        {
                                            get { return __boundaryLayerConductance;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _THICKApsim.Name = "THICKApsim";
                                            _THICKApsim.Description = "APSIM soil layer depths as THICKApsim of layers";
                                            _THICKApsim.MaxValue = -1D;
                                            _THICKApsim.MinValue = -1D;
                                            _THICKApsim.DefaultValue = -1D;
                                            _THICKApsim.Units = "mm";
                                            _THICKApsim.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _DEPTHApsim.Name = "DEPTHApsim";
                                            _DEPTHApsim.Description = "Apsim node depths";
                                            _DEPTHApsim.MaxValue = -1D;
                                            _DEPTHApsim.MinValue = -1D;
                                            _DEPTHApsim.DefaultValue = -1D;
                                            _DEPTHApsim.Units = "m";
                                            _DEPTHApsim.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _BDApsim.Name = "BDApsim";
                                            _BDApsim.Description = "Apsim bd (soil bulk density)";
                                            _BDApsim.MaxValue = -1D;
                                            _BDApsim.MinValue = -1D;
                                            _BDApsim.DefaultValue = -1D;
                                            _BDApsim.Units = "g/cm3             uri :";
                                            _BDApsim.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _CLAYApsim.Name = "CLAYApsim";
                                            _CLAYApsim.Description = "Apsim proportion of CLAYApsim in each layer of profile";
                                            _CLAYApsim.MaxValue = -1D;
                                            _CLAYApsim.MinValue = -1D;
                                            _CLAYApsim.DefaultValue = -1D;
                                            _CLAYApsim.Units = "";
                                            _CLAYApsim.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SWApsim.Name = "SWApsim";
                                            _SWApsim.Description = "Apsim volumetric water content";
                                            _SWApsim.MaxValue = -1D;
                                            _SWApsim.MinValue = -1D;
                                            _SWApsim.DefaultValue = -1D;
                                            _SWApsim.Units = "cc water / cc soil";
                                            _SWApsim.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

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

                                            _SLCARBApsim.Name = "SLCARBApsim";
                                            _SLCARBApsim.Description = "Volumetric fraction of organic matter in the soil";
                                            _SLCARBApsim.MaxValue = -1D;
                                            _SLCARBApsim.MinValue = -1D;
                                            _SLCARBApsim.DefaultValue = -1D;
                                            _SLCARBApsim.Units = "";
                                            _SLCARBApsim.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SLROCKApsim.Name = "SLROCKApsim";
                                            _SLROCKApsim.Description = "Volumetric fraction of SLROCKApsim in the soil";
                                            _SLROCKApsim.MaxValue = -1D;
                                            _SLROCKApsim.MinValue = -1D;
                                            _SLROCKApsim.DefaultValue = -1D;
                                            _SLROCKApsim.Units = "";
                                            _SLROCKApsim.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SLSILTApsim.Name = "SLSILTApsim";
                                            _SLSILTApsim.Description = "Volumetric fraction of SLSILTApsim in the soil";
                                            _SLSILTApsim.MaxValue = -1D;
                                            _SLSILTApsim.MinValue = -1D;
                                            _SLSILTApsim.DefaultValue = -1D;
                                            _SLSILTApsim.Units = "";
                                            _SLSILTApsim.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _SLSANDApsim.Name = "SLSANDApsim";
                                            _SLSANDApsim.Description = "Apsim volumetric fraction of SLSANDApsim in the soil";
                                            _SLSANDApsim.MaxValue = -1D;
                                            _SLSANDApsim.MinValue = -1D;
                                            _SLSANDApsim.DefaultValue = -1D;
                                            _SLSANDApsim.Units = "";
                                            _SLSANDApsim.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

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