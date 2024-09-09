using System;
using System.Collections.Generic;
public class CampbellState 
{
    private double[] _soilTemp;
    private double _maxTempYesterday;
    private double _minTempYesterday;
    private double[] _maxSoilTemp;
    private double[] _aveSoilTemp;
    private double[] _morningSoilTemp;
    private double[] _tempNew;
    private double[] _heatCapacity;
    private double[] _thermalCondPar1;
    private double[] _thermalCondPar2;
    private double[] _thermalCondPar3;
    private double[] _thermalCondPar4;
    private double[] _thermalConductivity;
    private double[] _thermalConductance;
    private double[] _heatStorage;
    private double _airPressure;
    
    /// <summary>
    /// Constructor of the campbellState component")
    /// </summary>  
    public campbellState() { }
    
    
    public campbellState(campbellState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            soilTemp = new double[toCopy.soilTemp.Length];
            for (int i = 0; i < toCopy.soilTemp.Length; i++)
                { soilTemp[i] = toCopy.soilTemp[i]; }
    
            maxTempYesterday = toCopy.maxTempYesterday;
            minTempYesterday = toCopy.minTempYesterday;
            maxSoilTemp = new double[toCopy.maxSoilTemp.Length];
            for (int i = 0; i < toCopy.maxSoilTemp.Length; i++)
                { maxSoilTemp[i] = toCopy.maxSoilTemp[i]; }
    
            aveSoilTemp = new double[toCopy.aveSoilTemp.Length];
            for (int i = 0; i < toCopy.aveSoilTemp.Length; i++)
                { aveSoilTemp[i] = toCopy.aveSoilTemp[i]; }
    
            morningSoilTemp = new double[toCopy.morningSoilTemp.Length];
            for (int i = 0; i < toCopy.morningSoilTemp.Length; i++)
                { morningSoilTemp[i] = toCopy.morningSoilTemp[i]; }
    
            tempNew = new double[toCopy.tempNew.Length];
            for (int i = 0; i < toCopy.tempNew.Length; i++)
                { tempNew[i] = toCopy.tempNew[i]; }
    
            heatCapacity = new double[toCopy.heatCapacity.Length];
            for (int i = 0; i < toCopy.heatCapacity.Length; i++)
                { heatCapacity[i] = toCopy.heatCapacity[i]; }
    
            thermalCondPar1 = new double[toCopy.thermalCondPar1.Length];
            for (int i = 0; i < toCopy.thermalCondPar1.Length; i++)
                { thermalCondPar1[i] = toCopy.thermalCondPar1[i]; }
    
            thermalCondPar2 = new double[toCopy.thermalCondPar2.Length];
            for (int i = 0; i < toCopy.thermalCondPar2.Length; i++)
                { thermalCondPar2[i] = toCopy.thermalCondPar2[i]; }
    
            thermalCondPar3 = new double[toCopy.thermalCondPar3.Length];
            for (int i = 0; i < toCopy.thermalCondPar3.Length; i++)
                { thermalCondPar3[i] = toCopy.thermalCondPar3[i]; }
    
            thermalCondPar4 = new double[toCopy.thermalCondPar4.Length];
            for (int i = 0; i < toCopy.thermalCondPar4.Length; i++)
                { thermalCondPar4[i] = toCopy.thermalCondPar4[i]; }
    
            thermalConductivity = new double[toCopy.thermalConductivity.Length];
            for (int i = 0; i < toCopy.thermalConductivity.Length; i++)
                { thermalConductivity[i] = toCopy.thermalConductivity[i]; }
    
            thermalConductance = new double[toCopy.thermalConductance.Length];
            for (int i = 0; i < toCopy.thermalConductance.Length; i++)
                { thermalConductance[i] = toCopy.thermalConductance[i]; }
    
            heatStorage = new double[toCopy.heatStorage.Length];
            for (int i = 0; i < toCopy.heatStorage.Length; i++)
                { heatStorage[i] = toCopy.heatStorage[i]; }
    
            airPressure = toCopy.airPressure;
        }
    }
    public double[] soilTemp
    {
        get { return this._soilTemp; }
        set { this._soilTemp= value; } 
    }
    public double maxTempYesterday
    {
        get { return this._maxTempYesterday; }
        set { this._maxTempYesterday= value; } 
    }
    public double minTempYesterday
    {
        get { return this._minTempYesterday; }
        set { this._minTempYesterday= value; } 
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
    public double[] thermalCondPar1
    {
        get { return this._thermalCondPar1; }
        set { this._thermalCondPar1= value; } 
    }
    public double[] thermalCondPar2
    {
        get { return this._thermalCondPar2; }
        set { this._thermalCondPar2= value; } 
    }
    public double[] thermalCondPar3
    {
        get { return this._thermalCondPar3; }
        set { this._thermalCondPar3= value; } 
    }
    public double[] thermalCondPar4
    {
        get { return this._thermalCondPar4; }
        set { this._thermalCondPar4= value; } 
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
    public double airPressure
    {
        get { return this._airPressure; }
        set { this._airPressure= value; } 
    }
}