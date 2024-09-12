using System;
using System.Collections.Generic;

public class CampbellExogenous 
{
    private double _ESP;
    private double _windSpeed;
    private int _DOY;
    private double[] _SW;
    private double _canopyHeight;
    private double _TMIN;
    private double _TMAX;
    private double _TAV;
    private double _ES;
    private double _EOAD;
    private double _T2M;
    private double _SRAD;
    
    /// <summary>
    /// Constructor of the campbellExogenous component")
    /// </summary>  
    public campbellExogenous() { }
    
    
    public campbellExogenous(campbellExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            ESP = toCopy.ESP;
            windSpeed = toCopy.windSpeed;
            DOY = toCopy.DOY;
            SW = new double[toCopy.SW.Length];
            for (int i = 0; i < toCopy.SW.Length; i++)
                { SW[i] = toCopy.SW[i]; }
    
            canopyHeight = toCopy.canopyHeight;
            TMIN = toCopy.TMIN;
            TMAX = toCopy.TMAX;
            TAV = toCopy.TAV;
            ES = toCopy.ES;
            EOAD = toCopy.EOAD;
            T2M = toCopy.T2M;
            SRAD = toCopy.SRAD;
        }
    }
    public double ESP
    {
        get { return this._ESP; }
        set { this._ESP= value; } 
    }
    public double windSpeed
    {
        get { return this._windSpeed; }
        set { this._windSpeed= value; } 
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
    public double canopyHeight
    {
        get { return this._canopyHeight; }
        set { this._canopyHeight= value; } 
    }
    public double TMIN
    {
        get { return this._TMIN; }
        set { this._TMIN= value; } 
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
    public double ES
    {
        get { return this._ES; }
        set { this._ES= value; } 
    }
    public double EOAD
    {
        get { return this._EOAD; }
        set { this._EOAD= value; } 
    }
    public double T2M
    {
        get { return this._T2M; }
        set { this._T2M= value; } 
    }
    public double SRAD
    {
        get { return this._SRAD; }
        set { this._SRAD= value; } 
    }
}