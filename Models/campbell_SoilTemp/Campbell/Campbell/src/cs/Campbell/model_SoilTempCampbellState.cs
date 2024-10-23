using System;
using System.Collections.Generic;
public class Model_SoilTempCampbellState 
{
    private double[] _THICK;
    private double[] _DEPTH;
    private double[] _BD;
    private double[] _CLAY;
    private double[] _SW;
    private double[] _soilTemp;
    private double[] _newTemperature;
    private double[] _minSoilTemp;
    private double[] _maxSoilTemp;
    private double[] _aveSoilTemp;
    private double[] _morningSoilTemp;
    private double[] _thermalCondPar1;
    private double[] _thermalCondPar2;
    private double[] _thermalCondPar3;
    private double[] _thermalCondPar4;
    private double[] _thermalConductivity;
    private double[] _thermalConductance;
    private double[] _heatStorage;
    private double[] _volSpecHeatSoil;
    private double _maxTempYesterday;
    private double _minTempYesterday;
    private double[] _SLCARB;
    private double[] _SLROCK;
    private double[] _SLSILT;
    private double[] _SLSAND;
    private double __boundaryLayerConductance;
    
    /// <summary>
    /// Constructor of the model_SoilTempCampbellState component")
    /// </summary>  
    public model_SoilTempCampbellState() { }
    
    
    public model_SoilTempCampbellState(model_SoilTempCampbellState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            THICK = new double[toCopy.THICK.Length];
            for (int i = 0; i < toCopy.THICK.Length; i++)
                { THICK[i] = toCopy.THICK[i]; }
    
            DEPTH = new double[toCopy.DEPTH.Length];
            for (int i = 0; i < toCopy.DEPTH.Length; i++)
                { DEPTH[i] = toCopy.DEPTH[i]; }
    
            BD = new double[toCopy.BD.Length];
            for (int i = 0; i < toCopy.BD.Length; i++)
                { BD[i] = toCopy.BD[i]; }
    
            CLAY = new double[toCopy.CLAY.Length];
            for (int i = 0; i < toCopy.CLAY.Length; i++)
                { CLAY[i] = toCopy.CLAY[i]; }
    
            SW = new double[toCopy.SW.Length];
            for (int i = 0; i < toCopy.SW.Length; i++)
                { SW[i] = toCopy.SW[i]; }
    
            soilTemp = new double[toCopy.soilTemp.Length];
            for (int i = 0; i < toCopy.soilTemp.Length; i++)
                { soilTemp[i] = toCopy.soilTemp[i]; }
    
            newTemperature = new double[toCopy.newTemperature.Length];
            for (int i = 0; i < toCopy.newTemperature.Length; i++)
                { newTemperature[i] = toCopy.newTemperature[i]; }
    
            minSoilTemp = new double[toCopy.minSoilTemp.Length];
            for (int i = 0; i < toCopy.minSoilTemp.Length; i++)
                { minSoilTemp[i] = toCopy.minSoilTemp[i]; }
    
            maxSoilTemp = new double[toCopy.maxSoilTemp.Length];
            for (int i = 0; i < toCopy.maxSoilTemp.Length; i++)
                { maxSoilTemp[i] = toCopy.maxSoilTemp[i]; }
    
            aveSoilTemp = new double[toCopy.aveSoilTemp.Length];
            for (int i = 0; i < toCopy.aveSoilTemp.Length; i++)
                { aveSoilTemp[i] = toCopy.aveSoilTemp[i]; }
    
            morningSoilTemp = new double[toCopy.morningSoilTemp.Length];
            for (int i = 0; i < toCopy.morningSoilTemp.Length; i++)
                { morningSoilTemp[i] = toCopy.morningSoilTemp[i]; }
    
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
    
            volSpecHeatSoil = new double[toCopy.volSpecHeatSoil.Length];
            for (int i = 0; i < toCopy.volSpecHeatSoil.Length; i++)
                { volSpecHeatSoil[i] = toCopy.volSpecHeatSoil[i]; }
    
            maxTempYesterday = toCopy.maxTempYesterday;
            minTempYesterday = toCopy.minTempYesterday;
            SLCARB = new double[toCopy.SLCARB.Length];
            for (int i = 0; i < toCopy.SLCARB.Length; i++)
                { SLCARB[i] = toCopy.SLCARB[i]; }
    
            SLROCK = new double[toCopy.SLROCK.Length];
            for (int i = 0; i < toCopy.SLROCK.Length; i++)
                { SLROCK[i] = toCopy.SLROCK[i]; }
    
            SLSILT = new double[toCopy.SLSILT.Length];
            for (int i = 0; i < toCopy.SLSILT.Length; i++)
                { SLSILT[i] = toCopy.SLSILT[i]; }
    
            SLSAND = new double[toCopy.SLSAND.Length];
            for (int i = 0; i < toCopy.SLSAND.Length; i++)
                { SLSAND[i] = toCopy.SLSAND[i]; }
    
            _boundaryLayerConductance = toCopy._boundaryLayerConductance;
        }
    }
    public double[] THICK
    {
        get { return this._THICK; }
        set { this._THICK= value; } 
    }
    public double[] DEPTH
    {
        get { return this._DEPTH; }
        set { this._DEPTH= value; } 
    }
    public double[] BD
    {
        get { return this._BD; }
        set { this._BD= value; } 
    }
    public double[] CLAY
    {
        get { return this._CLAY; }
        set { this._CLAY= value; } 
    }
    public double[] SW
    {
        get { return this._SW; }
        set { this._SW= value; } 
    }
    public double[] soilTemp
    {
        get { return this._soilTemp; }
        set { this._soilTemp= value; } 
    }
    public double[] newTemperature
    {
        get { return this._newTemperature; }
        set { this._newTemperature= value; } 
    }
    public double[] minSoilTemp
    {
        get { return this._minSoilTemp; }
        set { this._minSoilTemp= value; } 
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
    public double[] volSpecHeatSoil
    {
        get { return this._volSpecHeatSoil; }
        set { this._volSpecHeatSoil= value; } 
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
    public double[] SLCARB
    {
        get { return this._SLCARB; }
        set { this._SLCARB= value; } 
    }
    public double[] SLROCK
    {
        get { return this._SLROCK; }
        set { this._SLROCK= value; } 
    }
    public double[] SLSILT
    {
        get { return this._SLSILT; }
        set { this._SLSILT= value; } 
    }
    public double[] SLSAND
    {
        get { return this._SLSAND; }
        set { this._SLSAND= value; } 
    }
    public double _boundaryLayerConductance
    {
        get { return this.__boundaryLayerConductance; }
        set { this.__boundaryLayerConductance= value; } 
    }
}