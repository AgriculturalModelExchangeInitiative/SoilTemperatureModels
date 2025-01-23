using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// state variables class of the Soiltemp component
/// </summary>
public class SoiltempState
{
    private double _netRadiation;
    private double[] _aveSoilWater;
    private double[] _bulkDensity;
    private double _internalTimeStep;
    private double[] _thermalConductance;
    private double[] _thickness;
    private bool _doInitialisationStuff;
    private double _maxTempYesterday;
    private double _timeOfDaySecs;
    private int _numNodes;
    private double[] _soilWater;
    private double[] _clay;
    private double[] _soilTemp;
    private double[] _silt;
    private double _instrumentHeight;
    private double[] _sand;
    private int _numLayers;
    private double[] _volSpecHeatSoil;
    private double _instrumHeight;
    private double _canopyHeight;
    private double[] _heatStorage;
    private double[] _minSoilTemp;
    private double[] _maxSoilTemp;
    private double[] _newTemperature;
    private double _airTemperature;
    private double[] _thermalConductivity;
    private double _minTempYesterday;
    private double[] _carbon;
    private double[] _rocks;
    private double[] _InitialValues;
    private double _boundaryLayerConductance;
    private double[] _aveSoilTemp;
    private double[] _morningSoilTemp;

    /// <summary>
    /// Constructor SoiltempState domain class
    /// </summary>
    public SoiltempState() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public SoiltempState(SoiltempState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            netRadiation = toCopy.netRadiation;
            aveSoilWater = new double[toCopy.aveSoilWater.Length];
        for (int i = 0; i < toCopy.aveSoilWater.Length; i++)
            { aveSoilWater[i] = toCopy.aveSoilWater[i]; }
    
            bulkDensity = new double[toCopy.bulkDensity.Length];
        for (int i = 0; i < toCopy.bulkDensity.Length; i++)
            { bulkDensity[i] = toCopy.bulkDensity[i]; }
    
            internalTimeStep = toCopy.internalTimeStep;
            thermalConductance = new double[toCopy.thermalConductance.Length];
        for (int i = 0; i < toCopy.thermalConductance.Length; i++)
            { thermalConductance[i] = toCopy.thermalConductance[i]; }
    
            thickness = new double[toCopy.thickness.Length];
        for (int i = 0; i < toCopy.thickness.Length; i++)
            { thickness[i] = toCopy.thickness[i]; }
    
            doInitialisationStuff = toCopy.doInitialisationStuff;
            maxTempYesterday = toCopy.maxTempYesterday;
            timeOfDaySecs = toCopy.timeOfDaySecs;
            numNodes = toCopy.numNodes;
            soilWater = new double[toCopy.soilWater.Length];
        for (int i = 0; i < toCopy.soilWater.Length; i++)
            { soilWater[i] = toCopy.soilWater[i]; }
    
            clay = new double[toCopy.clay.Length];
        for (int i = 0; i < toCopy.clay.Length; i++)
            { clay[i] = toCopy.clay[i]; }
    
            soilTemp = new double[toCopy.soilTemp.Length];
        for (int i = 0; i < toCopy.soilTemp.Length; i++)
            { soilTemp[i] = toCopy.soilTemp[i]; }
    
            silt = new double[toCopy.silt.Length];
        for (int i = 0; i < toCopy.silt.Length; i++)
            { silt[i] = toCopy.silt[i]; }
    
            instrumentHeight = toCopy.instrumentHeight;
            sand = new double[toCopy.sand.Length];
        for (int i = 0; i < toCopy.sand.Length; i++)
            { sand[i] = toCopy.sand[i]; }
    
            numLayers = toCopy.numLayers;
            volSpecHeatSoil = new double[toCopy.volSpecHeatSoil.Length];
        for (int i = 0; i < toCopy.volSpecHeatSoil.Length; i++)
            { volSpecHeatSoil[i] = toCopy.volSpecHeatSoil[i]; }
    
            instrumHeight = toCopy.instrumHeight;
            canopyHeight = toCopy.canopyHeight;
            heatStorage = new double[toCopy.heatStorage.Length];
        for (int i = 0; i < toCopy.heatStorage.Length; i++)
            { heatStorage[i] = toCopy.heatStorage[i]; }
    
            minSoilTemp = new double[toCopy.minSoilTemp.Length];
        for (int i = 0; i < toCopy.minSoilTemp.Length; i++)
            { minSoilTemp[i] = toCopy.minSoilTemp[i]; }
    
            maxSoilTemp = new double[toCopy.maxSoilTemp.Length];
        for (int i = 0; i < toCopy.maxSoilTemp.Length; i++)
            { maxSoilTemp[i] = toCopy.maxSoilTemp[i]; }
    
            newTemperature = new double[toCopy.newTemperature.Length];
        for (int i = 0; i < toCopy.newTemperature.Length; i++)
            { newTemperature[i] = toCopy.newTemperature[i]; }
    
            airTemperature = toCopy.airTemperature;
            thermalConductivity = new double[toCopy.thermalConductivity.Length];
        for (int i = 0; i < toCopy.thermalConductivity.Length; i++)
            { thermalConductivity[i] = toCopy.thermalConductivity[i]; }
    
            minTempYesterday = toCopy.minTempYesterday;
            carbon = new double[toCopy.carbon.Length];
        for (int i = 0; i < toCopy.carbon.Length; i++)
            { carbon[i] = toCopy.carbon[i]; }
    
            rocks = new double[toCopy.rocks.Length];
        for (int i = 0; i < toCopy.rocks.Length; i++)
            { rocks[i] = toCopy.rocks[i]; }
    
            InitialValues = new double[toCopy.InitialValues.Length];
        for (int i = 0; i < toCopy.InitialValues.Length; i++)
            { InitialValues[i] = toCopy.InitialValues[i]; }
    
            boundaryLayerConductance = toCopy.boundaryLayerConductance;
            aveSoilTemp = new double[toCopy.aveSoilTemp.Length];
        for (int i = 0; i < toCopy.aveSoilTemp.Length; i++)
            { aveSoilTemp[i] = toCopy.aveSoilTemp[i]; }
    
            morningSoilTemp = new double[toCopy.morningSoilTemp.Length];
        for (int i = 0; i < toCopy.morningSoilTemp.Length; i++)
            { morningSoilTemp[i] = toCopy.morningSoilTemp[i]; }
    
        }
    }

    /// <summary>
    /// Gets and sets the Net radiation per internal time-step
    /// </summary>
    [Description("Net radiation per internal time-step")] 
    [Units("MJ")] 
    public double netRadiation
    {
        get { return this._netRadiation; }
        set { this._netRadiation= value; } 
    }

    /// <summary>
    /// Gets and sets the Average soil temperaturer
    /// </summary>
    [Description("Average soil temperaturer")] 
    [Units("oC")] 
    public double[] aveSoilWater
    {
        get { return this._aveSoilWater; }
        set { this._aveSoilWater= value; } 
    }

    /// <summary>
    /// Gets and sets the Soil bulk density, includes phantom layer
    /// </summary>
    [Description("Soil bulk density, includes phantom layer")] 
    [Units("g/cm3")] 
    public double[] bulkDensity
    {
        get { return this._bulkDensity; }
        set { this._bulkDensity= value; } 
    }

    /// <summary>
    /// Gets and sets the Internal time-step
    /// </summary>
    [Description("Internal time-step")] 
    [Units("sec")] 
    public double internalTimeStep
    {
        get { return this._internalTimeStep; }
        set { this._internalTimeStep= value; } 
    }

    /// <summary>
    /// Gets and sets the K, conductance of element between nodes
    /// </summary>
    [Description("K, conductance of element between nodes")] 
    [Units("W/K")] 
    public double[] thermalConductance
    {
        get { return this._thermalConductance; }
        set { this._thermalConductance= value; } 
    }

    /// <summary>
    /// Gets and sets the Thickness of each soil, includes phantom layer
    /// </summary>
    [Description("Thickness of each soil, includes phantom layer")] 
    [Units("mm")] 
    public double[] thickness
    {
        get { return this._thickness; }
        set { this._thickness= value; } 
    }

    /// <summary>
    /// Gets and sets the Flag whether initialisation is needed
    /// </summary>
    [Description("Flag whether initialisation is needed")] 
    [Units("mintes")] 
    public bool doInitialisationStuff
    {
        get { return this._doInitialisationStuff; }
        set { this._doInitialisationStuff= value; } 
    }

    /// <summary>
    /// Gets and sets the Yesterday's maximum daily air temperature
    /// </summary>
    [Description("Yesterday's maximum daily air temperature")] 
    [Units("oC")] 
    public double maxTempYesterday
    {
        get { return this._maxTempYesterday; }
        set { this._maxTempYesterday= value; } 
    }

    /// <summary>
    /// Gets and sets the Time of day from midnight
    /// </summary>
    [Description("Time of day from midnight")] 
    [Units("sec")] 
    public double timeOfDaySecs
    {
        get { return this._timeOfDaySecs; }
        set { this._timeOfDaySecs= value; } 
    }

    /// <summary>
    /// Gets and sets the Number of nodes over the soil profile
    /// </summary>
    [Description("Number of nodes over the soil profile")] 
    [Units("")] 
    public int numNodes
    {
        get { return this._numNodes; }
        set { this._numNodes= value; } 
    }

    /// <summary>
    /// Gets and sets the Volumetric water content of each soil layer
    /// </summary>
    [Description("Volumetric water content of each soil layer")] 
    [Units("mm3/mm3")] 
    public double[] soilWater
    {
        get { return this._soilWater; }
        set { this._soilWater= value; } 
    }

    /// <summary>
    /// Gets and sets the Volumetric fraction of clay in each soil layer
    /// </summary>
    [Description("Volumetric fraction of clay in each soil layer")] 
    [Units("%")] 
    public double[] clay
    {
        get { return this._clay; }
        set { this._clay= value; } 
    }

    /// <summary>
    /// Gets and sets the Soil temperature over the soil profile at morning
    /// </summary>
    [Description("Soil temperature over the soil profile at morning")] 
    [Units("oC")] 
    public double[] soilTemp
    {
        get { return this._soilTemp; }
        set { this._soilTemp= value; } 
    }

    /// <summary>
    /// Gets and sets the Volumetric fraction of silt in each soil layer
    /// </summary>
    [Description("Volumetric fraction of silt in each soil layer")] 
    [Units("%")] 
    public double[] silt
    {
        get { return this._silt; }
        set { this._silt= value; } 
    }

    /// <summary>
    /// Gets and sets the Height of instruments above soil surface
    /// </summary>
    [Description("Height of instruments above soil surface")] 
    [Units("mm")] 
    public double instrumentHeight
    {
        get { return this._instrumentHeight; }
        set { this._instrumentHeight= value; } 
    }

    /// <summary>
    /// Gets and sets the Volumetric fraction of sand in each soil layer
    /// </summary>
    [Description("Volumetric fraction of sand in each soil layer")] 
    [Units("%")] 
    public double[] sand
    {
        get { return this._sand; }
        set { this._sand= value; } 
    }

    /// <summary>
    /// Gets and sets the Number of layers in the soil profile
    /// </summary>
    [Description("Number of layers in the soil profile")] 
    [Units("")] 
    public int numLayers
    {
        get { return this._numLayers; }
        set { this._numLayers= value; } 
    }

    /// <summary>
    /// Gets and sets the Volumetric specific heat over the soil profile
    /// </summary>
    [Description("Volumetric specific heat over the soil profile")] 
    [Units("J/K/m3")] 
    public double[] volSpecHeatSoil
    {
        get { return this._volSpecHeatSoil; }
        set { this._volSpecHeatSoil= value; } 
    }

    /// <summary>
    /// Gets and sets the Height of instruments above ground
    /// </summary>
    [Description("Height of instruments above ground")] 
    [Units("mm")] 
    public double instrumHeight
    {
        get { return this._instrumHeight; }
        set { this._instrumHeight= value; } 
    }

    /// <summary>
    /// Gets and sets the Height of canopy above ground
    /// </summary>
    [Description("Height of canopy above ground")] 
    [Units("mm")] 
    public double canopyHeight
    {
        get { return this._canopyHeight; }
        set { this._canopyHeight= value; } 
    }

    /// <summary>
    /// Gets and sets the CP, heat storage between nodes
    /// </summary>
    [Description("CP, heat storage between nodes")] 
    [Units("J/K")] 
    public double[] heatStorage
    {
        get { return this._heatStorage; }
        set { this._heatStorage= value; } 
    }

    /// <summary>
    /// Gets and sets the Minimum soil temperature
    /// </summary>
    [Description("Minimum soil temperature")] 
    [Units("oC")] 
    public double[] minSoilTemp
    {
        get { return this._minSoilTemp; }
        set { this._minSoilTemp= value; } 
    }

    /// <summary>
    /// Gets and sets the Maximum soil temperature
    /// </summary>
    [Description("Maximum soil temperature")] 
    [Units("oC")] 
    public double[] maxSoilTemp
    {
        get { return this._maxSoilTemp; }
        set { this._maxSoilTemp= value; } 
    }

    /// <summary>
    /// Gets and sets the Soil temperature at the end of this iteration
    /// </summary>
    [Description("Soil temperature at the end of this iteration")] 
    [Units("oC")] 
    public double[] newTemperature
    {
        get { return this._newTemperature; }
        set { this._newTemperature= value; } 
    }

    /// <summary>
    /// Gets and sets the Air temperature
    /// </summary>
    [Description("Air temperature")] 
    [Units("oC")] 
    public double airTemperature
    {
        get { return this._airTemperature; }
        set { this._airTemperature= value; } 
    }

    /// <summary>
    /// Gets and sets the Thermal conductivity
    /// </summary>
    [Description("Thermal conductivity")] 
    [Units("W.m/K")] 
    public double[] thermalConductivity
    {
        get { return this._thermalConductivity; }
        set { this._thermalConductivity= value; } 
    }

    /// <summary>
    /// Gets and sets the Yesterday's minimum daily air temperature
    /// </summary>
    [Description("Yesterday's minimum daily air temperature")] 
    [Units("oC")] 
    public double minTempYesterday
    {
        get { return this._minTempYesterday; }
        set { this._minTempYesterday= value; } 
    }

    /// <summary>
    /// Gets and sets the Volumetric fraction of carbon (CHECK, OM?) in each soil layer
    /// </summary>
    [Description("Volumetric fraction of carbon (CHECK, OM?) in each soil layer")] 
    [Units("%")] 
    public double[] carbon
    {
        get { return this._carbon; }
        set { this._carbon= value; } 
    }

    /// <summary>
    /// Gets and sets the Volumetric fraction of rocks in each soil laye
    /// </summary>
    [Description("Volumetric fraction of rocks in each soil laye")] 
    [Units("%")] 
    public double[] rocks
    {
        get { return this._rocks; }
        set { this._rocks= value; } 
    }

    /// <summary>
    /// Gets and sets the Initial soil temperature
    /// </summary>
    [Description("Initial soil temperature")] 
    [Units("oC")] 
    public double[] InitialValues
    {
        get { return this._InitialValues; }
        set { this._InitialValues= value; } 
    }

    /// <summary>
    /// Gets and sets the Average daily atmosphere boundary layer conductance
    /// </summary>
    [Description("Average daily atmosphere boundary layer conductance")] 
    [Units("")] 
    public double boundaryLayerConductance
    {
        get { return this._boundaryLayerConductance; }
        set { this._boundaryLayerConductance= value; } 
    }

    /// <summary>
    /// Gets and sets the average soil temperature
    /// </summary>
    [Description("average soil temperature")] 
    [Units("oC")] 
    public double[] aveSoilTemp
    {
        get { return this._aveSoilTemp; }
        set { this._aveSoilTemp= value; } 
    }

    /// <summary>
    /// Gets and sets the Soil temperature over the soil profile at morning
    /// </summary>
    [Description("Soil temperature over the soil profile at morning")] 
    [Units("oC")] 
    public double[] morningSoilTemp
    {
        get { return this._morningSoilTemp; }
        set { this._morningSoilTemp= value; } 
    }

}