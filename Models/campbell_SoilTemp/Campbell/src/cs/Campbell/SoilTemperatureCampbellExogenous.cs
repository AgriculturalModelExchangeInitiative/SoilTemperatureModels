using System;
using System.Collections.Generic;

public class SoilTemperatureCampbellExogenous 
{
    private double _EOAD;
    private double _TMAX;
    private double _TAV;
    private double[] _SW = new double[NLAYR];
    private double _ESAD;
    private double _canopyHeight;
    private double _DOY;
    private double _SRAD;
    private double _ESP;
    private double _TMIN;
    
    /// <summary>
    /// Constructor of the SoilTemperatureCampbellExogenous component")
    /// </summary>  
    public SoilTemperatureCampbellExogenous() { }
    
    
    public SoilTemperatureCampbellExogenous(SoilTemperatureCampbellExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    EOAD = toCopy.EOAD;
    TMAX = toCopy.TMAX;
    TAV = toCopy.TAV;
    SW = new double[NLAYR];
        for (int i = 0; i < NLAYR; i++)
        { SW[i] = toCopy.SW[i]; }
    
    ESAD = toCopy.ESAD;
    canopyHeight = toCopy.canopyHeight;
    DOY = toCopy.DOY;
    SRAD = toCopy.SRAD;
    ESP = toCopy.ESP;
    TMIN = toCopy.TMIN;
    }
    }
    public double EOAD
    {
        get { return this._EOAD; }
        set { this._EOAD= value; } 
    }
    public double TMAX
    {
        get { return this._TMAX; }
        set { this._TMAX= value; } 
    }
    public double TAV
    {
        get { return this._TAV; }
        set { this._TAV= value; } 
    }
    public double[] SW
    {
        get { return this._SW; }
        set { this._SW= value; } 
    }
    public double ESAD
    {
        get { return this._ESAD; }
        set { this._ESAD= value; } 
    }
    public double canopyHeight
    {
        get { return this._canopyHeight; }
        set { this._canopyHeight= value; } 
    }
    public double DOY
    {
        get { return this._DOY; }
        set { this._DOY= value; } 
    }
    public double SRAD
    {
        get { return this._SRAD; }
        set { this._SRAD= value; } 
    }
    public double ESP
    {
        get { return this._ESP; }
        set { this._ESP= value; } 
    }
    public double TMIN
    {
        get { return this._TMIN; }
        set { this._TMIN= value; } 
    }
}