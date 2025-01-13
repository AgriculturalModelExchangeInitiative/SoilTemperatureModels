using System;
using System.Collections.Generic;
public class SoiltempState 
{
    private double _minTempYesterday;
    private double[] _minSoilTemp;
    private double[] _newTemperature;
    private bool _doInitialisationStuff;
    private double[] _silt;
    private int _numNodes;
    private double[] _morningSoilTemp;
    private double[] _aveSoilTemp;
    private double[] _clay;
    private double[] _soilWater;
    private double[] _thermalConductivity;
    private double _instrumHeight;
    private double[] _aveSoilWater;
    private double[] _carbon;
    private double[] _soilTemp;
    private double[] _thickness;
    private double[] _heatStorage;
    private double _instrumentHeight;
    private double[] _thermalConductance;
    private double _maxTempYesterday;
    private double _boundaryLayerConductance;
    private double _canopyHeight;
    private double _netRadiation;
    private double[] _maxSoilTemp;
    private double[] _volSpecHeatSoil;
    private double[] _rocks;
    private double[] _bulkDensity;
    private int _numLayers;
    private double _airTemperature;
    private double[] _sand;
    private double _timeOfDaySecs;
    private double _internalTimeStep;
    
    /// <summary>
    /// Constructor of the SoiltempState component")
    /// </summary>  
    public SoiltempState() { }
    
    
    public SoiltempState(SoiltempState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            minTempYesterday = toCopy.minTempYesterday;
            minSoilTemp = new double[toCopy.minSoilTemp.Length];
        for (int i = 0; i < toCopy.minSoilTemp.Length; i++)
            { minSoilTemp[i] = toCopy.minSoilTemp[i]; }
    
            newTemperature = new double[toCopy.newTemperature.Length];
        for (int i = 0; i < toCopy.newTemperature.Length; i++)
            { newTemperature[i] = toCopy.newTemperature[i]; }
    
            doInitialisationStuff = toCopy.doInitialisationStuff;
            silt = new double[toCopy.silt.Length];
        for (int i = 0; i < toCopy.silt.Length; i++)
            { silt[i] = toCopy.silt[i]; }
    
            numNodes = toCopy.numNodes;
            morningSoilTemp = new double[toCopy.morningSoilTemp.Length];
        for (int i = 0; i < toCopy.morningSoilTemp.Length; i++)
            { morningSoilTemp[i] = toCopy.morningSoilTemp[i]; }
    
            aveSoilTemp = new double[toCopy.aveSoilTemp.Length];
        for (int i = 0; i < toCopy.aveSoilTemp.Length; i++)
            { aveSoilTemp[i] = toCopy.aveSoilTemp[i]; }
    
            clay = new double[toCopy.clay.Length];
        for (int i = 0; i < toCopy.clay.Length; i++)
            { clay[i] = toCopy.clay[i]; }
    
            soilWater = new double[toCopy.soilWater.Length];
        for (int i = 0; i < toCopy.soilWater.Length; i++)
            { soilWater[i] = toCopy.soilWater[i]; }
    
            thermalConductivity = new double[toCopy.thermalConductivity.Length];
        for (int i = 0; i < toCopy.thermalConductivity.Length; i++)
            { thermalConductivity[i] = toCopy.thermalConductivity[i]; }
    
            instrumHeight = toCopy.instrumHeight;
            aveSoilWater = new double[toCopy.aveSoilWater.Length];
        for (int i = 0; i < toCopy.aveSoilWater.Length; i++)
            { aveSoilWater[i] = toCopy.aveSoilWater[i]; }
    
            carbon = new double[toCopy.carbon.Length];
        for (int i = 0; i < toCopy.carbon.Length; i++)
            { carbon[i] = toCopy.carbon[i]; }
    
            soilTemp = new double[toCopy.soilTemp.Length];
        for (int i = 0; i < toCopy.soilTemp.Length; i++)
            { soilTemp[i] = toCopy.soilTemp[i]; }
    
            thickness = new double[toCopy.thickness.Length];
        for (int i = 0; i < toCopy.thickness.Length; i++)
            { thickness[i] = toCopy.thickness[i]; }
    
            heatStorage = new double[toCopy.heatStorage.Length];
        for (int i = 0; i < toCopy.heatStorage.Length; i++)
            { heatStorage[i] = toCopy.heatStorage[i]; }
    
            instrumentHeight = toCopy.instrumentHeight;
            thermalConductance = new double[toCopy.thermalConductance.Length];
        for (int i = 0; i < toCopy.thermalConductance.Length; i++)
            { thermalConductance[i] = toCopy.thermalConductance[i]; }
    
            maxTempYesterday = toCopy.maxTempYesterday;
            boundaryLayerConductance = toCopy.boundaryLayerConductance;
            canopyHeight = toCopy.canopyHeight;
            netRadiation = toCopy.netRadiation;
            maxSoilTemp = new double[toCopy.maxSoilTemp.Length];
        for (int i = 0; i < toCopy.maxSoilTemp.Length; i++)
            { maxSoilTemp[i] = toCopy.maxSoilTemp[i]; }
    
            volSpecHeatSoil = new double[toCopy.volSpecHeatSoil.Length];
        for (int i = 0; i < toCopy.volSpecHeatSoil.Length; i++)
            { volSpecHeatSoil[i] = toCopy.volSpecHeatSoil[i]; }
    
            rocks = new double[toCopy.rocks.Length];
        for (int i = 0; i < toCopy.rocks.Length; i++)
            { rocks[i] = toCopy.rocks[i]; }
    
            bulkDensity = new double[toCopy.bulkDensity.Length];
        for (int i = 0; i < toCopy.bulkDensity.Length; i++)
            { bulkDensity[i] = toCopy.bulkDensity[i]; }
    
            numLayers = toCopy.numLayers;
            airTemperature = toCopy.airTemperature;
            sand = new double[toCopy.sand.Length];
        for (int i = 0; i < toCopy.sand.Length; i++)
            { sand[i] = toCopy.sand[i]; }
    
            timeOfDaySecs = toCopy.timeOfDaySecs;
            internalTimeStep = toCopy.internalTimeStep;
        }
    }
    public double minTempYesterday
    {
        get { return this._minTempYesterday; }
        set { this._minTempYesterday= value; } 
    }
    public double[] minSoilTemp
    {
        get { return this._minSoilTemp; }
        set { this._minSoilTemp= value; } 
    }
    public double[] newTemperature
    {
        get { return this._newTemperature; }
        set { this._newTemperature= value; } 
    }
    public bool doInitialisationStuff
    {
        get { return this._doInitialisationStuff; }
        set { this._doInitialisationStuff= value; } 
    }
    public double[] silt
    {
        get { return this._silt; }
        set { this._silt= value; } 
    }
    public int numNodes
    {
        get { return this._numNodes; }
        set { this._numNodes= value; } 
    }
    public double[] morningSoilTemp
    {
        get { return this._morningSoilTemp; }
        set { this._morningSoilTemp= value; } 
    }
    public double[] aveSoilTemp
    {
        get { return this._aveSoilTemp; }
        set { this._aveSoilTemp= value; } 
    }
    public double[] clay
    {
        get { return this._clay; }
        set { this._clay= value; } 
    }
    public double[] soilWater
    {
        get { return this._soilWater; }
        set { this._soilWater= value; } 
    }
    public double[] thermalConductivity
    {
        get { return this._thermalConductivity; }
        set { this._thermalConductivity= value; } 
    }
    public double instrumHeight
    {
        get { return this._instrumHeight; }
        set { this._instrumHeight= value; } 
    }
    public double[] aveSoilWater
    {
        get { return this._aveSoilWater; }
        set { this._aveSoilWater= value; } 
    }
    public double[] carbon
    {
        get { return this._carbon; }
        set { this._carbon= value; } 
    }
    public double[] soilTemp
    {
        get { return this._soilTemp; }
        set { this._soilTemp= value; } 
    }
    public double[] thickness
    {
        get { return this._thickness; }
        set { this._thickness= value; } 
    }
    public double[] heatStorage
    {
        get { return this._heatStorage; }
        set { this._heatStorage= value; } 
    }
    public double instrumentHeight
    {
        get { return this._instrumentHeight; }
        set { this._instrumentHeight= value; } 
    }
    public double[] thermalConductance
    {
        get { return this._thermalConductance; }
        set { this._thermalConductance= value; } 
    }
    public double maxTempYesterday
    {
        get { return this._maxTempYesterday; }
        set { this._maxTempYesterday= value; } 
    }
    public double boundaryLayerConductance
    {
        get { return this._boundaryLayerConductance; }
        set { this._boundaryLayerConductance= value; } 
    }
    public double canopyHeight
    {
        get { return this._canopyHeight; }
        set { this._canopyHeight= value; } 
    }
    public double netRadiation
    {
        get { return this._netRadiation; }
        set { this._netRadiation= value; } 
    }
    public double[] maxSoilTemp
    {
        get { return this._maxSoilTemp; }
        set { this._maxSoilTemp= value; } 
    }
    public double[] volSpecHeatSoil
    {
        get { return this._volSpecHeatSoil; }
        set { this._volSpecHeatSoil= value; } 
    }
    public double[] rocks
    {
        get { return this._rocks; }
        set { this._rocks= value; } 
    }
    public double[] bulkDensity
    {
        get { return this._bulkDensity; }
        set { this._bulkDensity= value; } 
    }
    public int numLayers
    {
        get { return this._numLayers; }
        set { this._numLayers= value; } 
    }
    public double airTemperature
    {
        get { return this._airTemperature; }
        set { this._airTemperature= value; } 
    }
    public double[] sand
    {
        get { return this._sand; }
        set { this._sand= value; } 
    }
    public double timeOfDaySecs
    {
        get { return this._timeOfDaySecs; }
        set { this._timeOfDaySecs= value; } 
    }
    public double internalTimeStep
    {
        get { return this._internalTimeStep; }
        set { this._internalTimeStep= value; } 
    }
}