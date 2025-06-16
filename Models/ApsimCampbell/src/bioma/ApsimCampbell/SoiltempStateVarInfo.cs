
using System;
using System.Collections.Generic;
using CRA.ModelLayer.Core;
using System.Reflection;
using CRA.ModelLayer.ParametersManagement;   

namespace Soiltemp.DomainClass
                                {
                                    public class SoiltempStateVarInfo : IVarInfoClass
                                    {
                                        static VarInfo _netRadiation = new VarInfo();
                                        static VarInfo _aveSoilWater = new VarInfo();
                                        static VarInfo _bulkDensity = new VarInfo();
                                        static VarInfo _internalTimeStep = new VarInfo();
                                        static VarInfo _thermalConductance = new VarInfo();
                                        static VarInfo _thickness = new VarInfo();
                                        static VarInfo _doInitialisationStuff = new VarInfo();
                                        static VarInfo _maxTempYesterday = new VarInfo();
                                        static VarInfo _timeOfDaySecs = new VarInfo();
                                        static VarInfo _numNodes = new VarInfo();
                                        static VarInfo _soilWater = new VarInfo();
                                        static VarInfo _clay = new VarInfo();
                                        static VarInfo _soilTemp = new VarInfo();
                                        static VarInfo _silt = new VarInfo();
                                        static VarInfo _instrumentHeight = new VarInfo();
                                        static VarInfo _sand = new VarInfo();
                                        static VarInfo _numLayers = new VarInfo();
                                        static VarInfo _volSpecHeatSoil = new VarInfo();
                                        static VarInfo _instrumHeight = new VarInfo();
                                        static VarInfo _canopyHeight = new VarInfo();
                                        static VarInfo _heatStorage = new VarInfo();
                                        static VarInfo _minSoilTemp = new VarInfo();
                                        static VarInfo _maxSoilTemp = new VarInfo();
                                        static VarInfo _newTemperature = new VarInfo();
                                        static VarInfo _airTemperature = new VarInfo();
                                        static VarInfo _thermalConductivity = new VarInfo();
                                        static VarInfo _minTempYesterday = new VarInfo();
                                        static VarInfo _carbon = new VarInfo();
                                        static VarInfo _rocks = new VarInfo();
                                        static VarInfo _InitialValues = new VarInfo();
                                        static VarInfo _boundaryLayerConductance = new VarInfo();
                                        static VarInfo _aveSoilTemp = new VarInfo();
                                        static VarInfo _morningSoilTemp = new VarInfo();

                                        static SoiltempStateVarInfo()
                                        {
                                            SoiltempStateVarInfo.DescribeVariables();
                                        }

                                        public virtual string Description
                                        {
                                            get { return "SoiltempState Domain class of the component";}
                                        }

                                        public string URL
                                        {
                                            get { return "http://" ;}
                                        }

                                        public string DomainClassOfReference
                                        {
                                            get { return "SoiltempState";}
                                        }

                                        public static  VarInfo netRadiation
                                        {
                                            get { return _netRadiation;}
                                        }

                                        public static  VarInfo aveSoilWater
                                        {
                                            get { return _aveSoilWater;}
                                        }

                                        public static  VarInfo bulkDensity
                                        {
                                            get { return _bulkDensity;}
                                        }

                                        public static  VarInfo internalTimeStep
                                        {
                                            get { return _internalTimeStep;}
                                        }

                                        public static  VarInfo thermalConductance
                                        {
                                            get { return _thermalConductance;}
                                        }

                                        public static  VarInfo thickness
                                        {
                                            get { return _thickness;}
                                        }

                                        public static  VarInfo doInitialisationStuff
                                        {
                                            get { return _doInitialisationStuff;}
                                        }

                                        public static  VarInfo maxTempYesterday
                                        {
                                            get { return _maxTempYesterday;}
                                        }

                                        public static  VarInfo timeOfDaySecs
                                        {
                                            get { return _timeOfDaySecs;}
                                        }

                                        public static  VarInfo numNodes
                                        {
                                            get { return _numNodes;}
                                        }

                                        public static  VarInfo soilWater
                                        {
                                            get { return _soilWater;}
                                        }

                                        public static  VarInfo clay
                                        {
                                            get { return _clay;}
                                        }

                                        public static  VarInfo soilTemp
                                        {
                                            get { return _soilTemp;}
                                        }

                                        public static  VarInfo silt
                                        {
                                            get { return _silt;}
                                        }

                                        public static  VarInfo instrumentHeight
                                        {
                                            get { return _instrumentHeight;}
                                        }

                                        public static  VarInfo sand
                                        {
                                            get { return _sand;}
                                        }

                                        public static  VarInfo numLayers
                                        {
                                            get { return _numLayers;}
                                        }

                                        public static  VarInfo volSpecHeatSoil
                                        {
                                            get { return _volSpecHeatSoil;}
                                        }

                                        public static  VarInfo instrumHeight
                                        {
                                            get { return _instrumHeight;}
                                        }

                                        public static  VarInfo canopyHeight
                                        {
                                            get { return _canopyHeight;}
                                        }

                                        public static  VarInfo heatStorage
                                        {
                                            get { return _heatStorage;}
                                        }

                                        public static  VarInfo minSoilTemp
                                        {
                                            get { return _minSoilTemp;}
                                        }

                                        public static  VarInfo maxSoilTemp
                                        {
                                            get { return _maxSoilTemp;}
                                        }

                                        public static  VarInfo newTemperature
                                        {
                                            get { return _newTemperature;}
                                        }

                                        public static  VarInfo airTemperature
                                        {
                                            get { return _airTemperature;}
                                        }

                                        public static  VarInfo thermalConductivity
                                        {
                                            get { return _thermalConductivity;}
                                        }

                                        public static  VarInfo minTempYesterday
                                        {
                                            get { return _minTempYesterday;}
                                        }

                                        public static  VarInfo carbon
                                        {
                                            get { return _carbon;}
                                        }

                                        public static  VarInfo rocks
                                        {
                                            get { return _rocks;}
                                        }

                                        public static  VarInfo InitialValues
                                        {
                                            get { return _InitialValues;}
                                        }

                                        public static  VarInfo boundaryLayerConductance
                                        {
                                            get { return _boundaryLayerConductance;}
                                        }

                                        public static  VarInfo aveSoilTemp
                                        {
                                            get { return _aveSoilTemp;}
                                        }

                                        public static  VarInfo morningSoilTemp
                                        {
                                            get { return _morningSoilTemp;}
                                        }

                                        static void DescribeVariables()
                                        {
                                            _netRadiation.Name = "netRadiation";
                                            _netRadiation.Description = "Net radiation per internal time-step";
                                            _netRadiation.MaxValue = -1D;
                                            _netRadiation.MinValue = -1D;
                                            _netRadiation.DefaultValue = 0;
                                            _netRadiation.Units = "MJ";
                                            _netRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _aveSoilWater.Name = "aveSoilWater";
                                            _aveSoilWater.Description = "Average soil temperaturer";
                                            _aveSoilWater.MaxValue = -1D;
                                            _aveSoilWater.MinValue = -1D;
                                            _aveSoilWater.DefaultValue = -1D;
                                            _aveSoilWater.Units = "oC";
                                            _aveSoilWater.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _bulkDensity.Name = "bulkDensity";
                                            _bulkDensity.Description = "Soil bulk density, includes phantom layer";
                                            _bulkDensity.MaxValue = -1D;
                                            _bulkDensity.MinValue = -1D;
                                            _bulkDensity.DefaultValue = -1D;
                                            _bulkDensity.Units = "g/cm3";
                                            _bulkDensity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _internalTimeStep.Name = "internalTimeStep";
                                            _internalTimeStep.Description = "Internal time-step";
                                            _internalTimeStep.MaxValue = -1D;
                                            _internalTimeStep.MinValue = -1D;
                                            _internalTimeStep.DefaultValue = 0;
                                            _internalTimeStep.Units = "sec";
                                            _internalTimeStep.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _thermalConductance.Name = "thermalConductance";
                                            _thermalConductance.Description = "K, conductance of element between nodes";
                                            _thermalConductance.MaxValue = -1D;
                                            _thermalConductance.MinValue = -1D;
                                            _thermalConductance.DefaultValue = -1D;
                                            _thermalConductance.Units = "W/K";
                                            _thermalConductance.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _thickness.Name = "thickness";
                                            _thickness.Description = "Thickness of each soil, includes phantom layer";
                                            _thickness.MaxValue = -1D;
                                            _thickness.MinValue = -1D;
                                            _thickness.DefaultValue = -1D;
                                            _thickness.Units = "mm";
                                            _thickness.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _doInitialisationStuff.Name = "doInitialisationStuff";
                                            _doInitialisationStuff.Description = "Flag whether initialisation is needed";
                                            _doInitialisationStuff.MaxValue = -1D;
                                            _doInitialisationStuff.MinValue = -1D;
                                            _doInitialisationStuff.DefaultValue = -1D;
                                            _doInitialisationStuff.Units = "mintes";
                                            _doInitialisationStuff.ValueType = VarInfoValueTypes.GetInstanceForName("Boolean");

                                            _maxTempYesterday.Name = "maxTempYesterday";
                                            _maxTempYesterday.Description = "Yesterday's maximum daily air temperature";
                                            _maxTempYesterday.MaxValue = -1D;
                                            _maxTempYesterday.MinValue = -1D;
                                            _maxTempYesterday.DefaultValue = 0;
                                            _maxTempYesterday.Units = "oC";
                                            _maxTempYesterday.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _timeOfDaySecs.Name = "timeOfDaySecs";
                                            _timeOfDaySecs.Description = "Time of day from midnight";
                                            _timeOfDaySecs.MaxValue = -1D;
                                            _timeOfDaySecs.MinValue = -1D;
                                            _timeOfDaySecs.DefaultValue = 0;
                                            _timeOfDaySecs.Units = "sec";
                                            _timeOfDaySecs.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _numNodes.Name = "numNodes";
                                            _numNodes.Description = "Number of nodes over the soil profile";
                                            _numNodes.MaxValue = -1D;
                                            _numNodes.MinValue = -1D;
                                            _numNodes.DefaultValue = 0;
                                            _numNodes.Units = "";
                                            _numNodes.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

                                            _soilWater.Name = "soilWater";
                                            _soilWater.Description = "Volumetric water content of each soil layer";
                                            _soilWater.MaxValue = -1D;
                                            _soilWater.MinValue = -1D;
                                            _soilWater.DefaultValue = -1D;
                                            _soilWater.Units = "mm3/mm3";
                                            _soilWater.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _clay.Name = "clay";
                                            _clay.Description = "Volumetric fraction of clay in each soil layer";
                                            _clay.MaxValue = -1D;
                                            _clay.MinValue = -1D;
                                            _clay.DefaultValue = -1D;
                                            _clay.Units = "%";
                                            _clay.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _soilTemp.Name = "soilTemp";
                                            _soilTemp.Description = "Soil temperature over the soil profile at morning";
                                            _soilTemp.MaxValue = -1D;
                                            _soilTemp.MinValue = -1D;
                                            _soilTemp.DefaultValue = -1D;
                                            _soilTemp.Units = "oC";
                                            _soilTemp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _silt.Name = "silt";
                                            _silt.Description = "Volumetric fraction of silt in each soil layer";
                                            _silt.MaxValue = -1D;
                                            _silt.MinValue = -1D;
                                            _silt.DefaultValue = -1D;
                                            _silt.Units = "%";
                                            _silt.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _instrumentHeight.Name = "instrumentHeight";
                                            _instrumentHeight.Description = "Height of instruments above soil surface";
                                            _instrumentHeight.MaxValue = -1D;
                                            _instrumentHeight.MinValue = -1D;
                                            _instrumentHeight.DefaultValue = 0;
                                            _instrumentHeight.Units = "mm";
                                            _instrumentHeight.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _sand.Name = "sand";
                                            _sand.Description = "Volumetric fraction of sand in each soil layer";
                                            _sand.MaxValue = -1D;
                                            _sand.MinValue = -1D;
                                            _sand.DefaultValue = -1D;
                                            _sand.Units = "%";
                                            _sand.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _numLayers.Name = "numLayers";
                                            _numLayers.Description = "Number of layers in the soil profile";
                                            _numLayers.MaxValue = -1D;
                                            _numLayers.MinValue = -1D;
                                            _numLayers.DefaultValue = 0;
                                            _numLayers.Units = "";
                                            _numLayers.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");

                                            _volSpecHeatSoil.Name = "volSpecHeatSoil";
                                            _volSpecHeatSoil.Description = "Volumetric specific heat over the soil profile";
                                            _volSpecHeatSoil.MaxValue = -1D;
                                            _volSpecHeatSoil.MinValue = -1D;
                                            _volSpecHeatSoil.DefaultValue = -1D;
                                            _volSpecHeatSoil.Units = "J/K/m3";
                                            _volSpecHeatSoil.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _instrumHeight.Name = "instrumHeight";
                                            _instrumHeight.Description = "Height of instruments above ground";
                                            _instrumHeight.MaxValue = -1D;
                                            _instrumHeight.MinValue = -1D;
                                            _instrumHeight.DefaultValue = 0;
                                            _instrumHeight.Units = "mm";
                                            _instrumHeight.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _canopyHeight.Name = "canopyHeight";
                                            _canopyHeight.Description = "Height of canopy above ground";
                                            _canopyHeight.MaxValue = -1D;
                                            _canopyHeight.MinValue = -1D;
                                            _canopyHeight.DefaultValue = 0;
                                            _canopyHeight.Units = "mm";
                                            _canopyHeight.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _heatStorage.Name = "heatStorage";
                                            _heatStorage.Description = "CP, heat storage between nodes";
                                            _heatStorage.MaxValue = -1D;
                                            _heatStorage.MinValue = -1D;
                                            _heatStorage.DefaultValue = -1D;
                                            _heatStorage.Units = "J/K";
                                            _heatStorage.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _minSoilTemp.Name = "minSoilTemp";
                                            _minSoilTemp.Description = "Minimum soil temperature";
                                            _minSoilTemp.MaxValue = -1D;
                                            _minSoilTemp.MinValue = -1D;
                                            _minSoilTemp.DefaultValue = -1D;
                                            _minSoilTemp.Units = "oC";
                                            _minSoilTemp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _maxSoilTemp.Name = "maxSoilTemp";
                                            _maxSoilTemp.Description = "Maximum soil temperature";
                                            _maxSoilTemp.MaxValue = -1D;
                                            _maxSoilTemp.MinValue = -1D;
                                            _maxSoilTemp.DefaultValue = -1D;
                                            _maxSoilTemp.Units = "oC";
                                            _maxSoilTemp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _newTemperature.Name = "newTemperature";
                                            _newTemperature.Description = "Soil temperature at the end of this iteration";
                                            _newTemperature.MaxValue = -1D;
                                            _newTemperature.MinValue = -1D;
                                            _newTemperature.DefaultValue = -1D;
                                            _newTemperature.Units = "oC";
                                            _newTemperature.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _airTemperature.Name = "airTemperature";
                                            _airTemperature.Description = "Air temperature";
                                            _airTemperature.MaxValue = -1D;
                                            _airTemperature.MinValue = -1D;
                                            _airTemperature.DefaultValue = 0;
                                            _airTemperature.Units = "oC";
                                            _airTemperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _thermalConductivity.Name = "thermalConductivity";
                                            _thermalConductivity.Description = "Thermal conductivity";
                                            _thermalConductivity.MaxValue = -1D;
                                            _thermalConductivity.MinValue = -1D;
                                            _thermalConductivity.DefaultValue = -1D;
                                            _thermalConductivity.Units = "W.m/K";
                                            _thermalConductivity.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _minTempYesterday.Name = "minTempYesterday";
                                            _minTempYesterday.Description = "Yesterday's minimum daily air temperature";
                                            _minTempYesterday.MaxValue = -1D;
                                            _minTempYesterday.MinValue = -1D;
                                            _minTempYesterday.DefaultValue = 0;
                                            _minTempYesterday.Units = "oC";
                                            _minTempYesterday.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _carbon.Name = "carbon";
                                            _carbon.Description = "Volumetric fraction of carbon (CHECK, OM?) in each soil layer";
                                            _carbon.MaxValue = -1D;
                                            _carbon.MinValue = -1D;
                                            _carbon.DefaultValue = -1D;
                                            _carbon.Units = "%";
                                            _carbon.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _rocks.Name = "rocks";
                                            _rocks.Description = "Volumetric fraction of rocks in each soil laye";
                                            _rocks.MaxValue = -1D;
                                            _rocks.MinValue = -1D;
                                            _rocks.DefaultValue = -1D;
                                            _rocks.Units = "%";
                                            _rocks.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _InitialValues.Name = "InitialValues";
                                            _InitialValues.Description = "Initial soil temperature";
                                            _InitialValues.MaxValue = -1D;
                                            _InitialValues.MinValue = -1D;
                                            _InitialValues.DefaultValue = -1D;
                                            _InitialValues.Units = "oC";
                                            _InitialValues.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _boundaryLayerConductance.Name = "boundaryLayerConductance";
                                            _boundaryLayerConductance.Description = "Average daily atmosphere boundary layer conductance";
                                            _boundaryLayerConductance.MaxValue = -1D;
                                            _boundaryLayerConductance.MinValue = -1D;
                                            _boundaryLayerConductance.DefaultValue = 0;
                                            _boundaryLayerConductance.Units = "";
                                            _boundaryLayerConductance.ValueType = VarInfoValueTypes.GetInstanceForName("Double");

                                            _aveSoilTemp.Name = "aveSoilTemp";
                                            _aveSoilTemp.Description = "average soil temperature";
                                            _aveSoilTemp.MaxValue = -1D;
                                            _aveSoilTemp.MinValue = -1D;
                                            _aveSoilTemp.DefaultValue = -1D;
                                            _aveSoilTemp.Units = "oC";
                                            _aveSoilTemp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                            _morningSoilTemp.Name = "morningSoilTemp";
                                            _morningSoilTemp.Description = "Soil temperature over the soil profile at morning";
                                            _morningSoilTemp.MaxValue = -1D;
                                            _morningSoilTemp.MinValue = -1D;
                                            _morningSoilTemp.DefaultValue = -1D;
                                            _morningSoilTemp.Units = "oC";
                                            _morningSoilTemp.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");

                                        }

                                    }
                                }