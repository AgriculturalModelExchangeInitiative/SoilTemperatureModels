using System;
using System.Collections.Generic;
public class SoilTemperatureCampbellState 
{
    private double[] _soilTemp = new double[NLAYR];
    private double[] _maxSoilTemp = new double[NLAYR];
    private double[] _aveSoilTemp = new double[NLAYR];
    private double[] _morningSoilTemp = new double[NLAYR];
    private double[] _tempNew = new double[NLAYR];
    private double[] _heatCapacity = new double[NLAYR];
    private double[] _thermalConductivity = new double[NLAYR];
    private double[] _thermalConductance = new double[NLAYR];
    private double[] _heatStorage = new double[NLAYR];
    
    /// <summary>
    /// Constructor of the SoilTemperatureCampbellState component")
    /// </summary>  
    public SoilTemperatureCampbellState() { }
    
    
    public SoilTemperatureCampbellState(SoilTemperatureCampbellState toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    soilTemp = new double[NLAYR];
        for (int i = 0; i < NLAYR; i++)
        { soilTemp[i] = toCopy.soilTemp[i]; }
    
    maxSoilTemp = new double[NLAYR];
        for (int i = 0; i < NLAYR; i++)
        { maxSoilTemp[i] = toCopy.maxSoilTemp[i]; }
    
    aveSoilTemp = new double[NLAYR];
        for (int i = 0; i < NLAYR; i++)
        { aveSoilTemp[i] = toCopy.aveSoilTemp[i]; }
    
    morningSoilTemp = new double[NLAYR];
        for (int i = 0; i < NLAYR; i++)
        { morningSoilTemp[i] = toCopy.morningSoilTemp[i]; }
    
    tempNew = new double[NLAYR];
        for (int i = 0; i < NLAYR; i++)
        { tempNew[i] = toCopy.tempNew[i]; }
    
    heatCapacity = new double[NLAYR];
        for (int i = 0; i < NLAYR; i++)
        { heatCapacity[i] = toCopy.heatCapacity[i]; }
    
    thermalConductivity = new double[NLAYR];
        for (int i = 0; i < NLAYR; i++)
        { thermalConductivity[i] = toCopy.thermalConductivity[i]; }
    
    thermalConductance = new double[NLAYR];
        for (int i = 0; i < NLAYR; i++)
        { thermalConductance[i] = toCopy.thermalConductance[i]; }
    
    heatStorage = new double[NLAYR];
        for (int i = 0; i < NLAYR; i++)
        { heatStorage[i] = toCopy.heatStorage[i]; }
    
    }
    }
    public double[] soilTemp
    {
        get { return this._soilTemp; }
        set { this._soilTemp= value; } 
    }
    public double[] maxSoilTemp
    {
        get { return this._maxSoilTemp; }
        set { this._maxSoilTemp= value; } 
    }
    public double[] aveSoilTemp
    {
        get { return this._aveSoilTemp; }
        set { this._aveSoilTemp= value; } 
    }
    public double[] morningSoilTemp
    {
        get { return this._morningSoilTemp; }
        set { this._morningSoilTemp= value; } 
    }
    public double[] tempNew
    {
        get { return this._tempNew; }
        set { this._tempNew= value; } 
    }
    public double[] heatCapacity
    {
        get { return this._heatCapacity; }
        set { this._heatCapacity= value; } 
    }
    public double[] thermalConductivity
    {
        get { return this._thermalConductivity; }
        set { this._thermalConductivity= value; } 
    }
    public double[] thermalConductance
    {
        get { return this._thermalConductance; }
        set { this._thermalConductance= value; } 
    }
    public double[] heatStorage
    {
        get { return this._heatStorage; }
        set { this._heatStorage= value; } 
    }
}