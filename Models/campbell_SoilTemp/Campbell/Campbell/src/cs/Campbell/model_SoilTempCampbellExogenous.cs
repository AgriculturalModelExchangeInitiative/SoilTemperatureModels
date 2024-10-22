using System;
using System.Collections.Generic;

public class Model_SoilTempCampbellExogenous 
{
    private double _T2M;
    private double _TMAX;
    private double _TMIN;
    private double _TAV;
    private double[] _SW;
    private int _DOY;
    private double _canopyHeight;
    private double _SRAD;
    private double _ESP;
    private double _ES;
    private double _EOAD;
    private double _windSpeed;
    
    /// <summary>
    /// Constructor of the model_SoilTempCampbellExogenous component")
    /// </summary>  
    public model_SoilTempCampbellExogenous() { }
    
    
    public model_SoilTempCampbellExogenous(model_SoilTempCampbellExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            T2M = toCopy.T2M;
            TMAX = toCopy.TMAX;
            TMIN = toCopy.TMIN;
            TAV = toCopy.TAV;
            SW = new double[toCopy.SW.Length];
            for (int i = 0; i < toCopy.SW.Length; i++)
                { SW[i] = toCopy.SW[i]; }
    
            DOY = toCopy.DOY;
            canopyHeight = toCopy.canopyHeight;
            SRAD = toCopy.SRAD;
            ESP = toCopy.ESP;
            ES = toCopy.ES;
            EOAD = toCopy.EOAD;
            windSpeed = toCopy.windSpeed;
        }
    }
    public double T2M
    {
        get { return this._T2M; }
        set { this._T2M= value; } 
    }
    public double TMAX
    {
        get { return this._TMAX; }
        set { this._TMAX= value; } 
    }
    public double TMIN
    {
        get { return this._TMIN; }
        set { this._TMIN= value; } 
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
    public int DOY
    {
        get { return this._DOY; }
        set { this._DOY= value; } 
    }
    public double canopyHeight
    {
        get { return this._canopyHeight; }
        set { this._canopyHeight= value; } 
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
    public double windSpeed
    {
        get { return this._windSpeed; }
        set { this._windSpeed= value; } 
    }
}