using System;
using System.Collections.Generic;

public class CampbellExogenous 
{
    private double _SRAD;
    private double _TMIN;
    private int _DOY;
    private double[] _SW;
    private double _EOAD;
    private double _ESP;
    private double _TAV;
    private double _ESAD;
    private double _canopyHeight;
    private double _TMAX;
    private double _ES;
    
    /// <summary>
    /// Constructor of the campbellExogenous component")
    /// </summary>  
    public campbellExogenous() { }
    
    
    public campbellExogenous(campbellExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            SRAD = toCopy.SRAD;
            TMIN = toCopy.TMIN;
            DOY = toCopy.DOY;
            SW = new double[toCopy.SW.Length];
            for (int i = 0; i < toCopy.SW.Length; i++)
                { SW[i] = toCopy.SW[i]; }
    
            EOAD = toCopy.EOAD;
            ESP = toCopy.ESP;
            TAV = toCopy.TAV;
            ESAD = toCopy.ESAD;
            canopyHeight = toCopy.canopyHeight;
            TMAX = toCopy.TMAX;
            ES = toCopy.ES;
        }
    }
    public double SRAD
    {
        get { return this._SRAD; }
        set { this._SRAD= value; } 
    }
    public double TMIN
    {
        get { return this._TMIN; }
        set { this._TMIN= value; } 
    }
    public int DOY
    {
        get { return this._DOY; }
        set { this._DOY= value; } 
    }
    public double[] SW
    {
        get { return this._SW; }
        set { this._SW= value; } 
    }
    public double EOAD
    {
        get { return this._EOAD; }
        set { this._EOAD= value; } 
    }
    public double ESP
    {
        get { return this._ESP; }
        set { this._ESP= value; } 
    }
    public double TAV
    {
        get { return this._TAV; }
        set { this._TAV= value; } 
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
    public double TMAX
    {
        get { return this._TMAX; }
        set { this._TMAX= value; } 
    }
    public double ES
    {
        get { return this._ES; }
        set { this._ES= value; } 
    }
}