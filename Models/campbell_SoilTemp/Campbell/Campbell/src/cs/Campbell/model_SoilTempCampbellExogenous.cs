using System;
using System.Collections.Generic;

public class Model_SoilTempCampbellExogenous 
{
    private double[] _THICK;
    private double[] _BD;
    private double[] _SLCARB;
    private double[] _CLAY;
    private double[] _SLROCK;
    private double[] _SLSILT;
    private double[] _SLSAND;
    private double[] _SW;
    private double _T2M;
    private double _TMAX;
    private double _TMIN;
    private double _TAV;
    private int _DOY;
    private double _airPressure;
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
    
            THICK = new double[toCopy.THICK.Length];
            for (int i = 0; i < toCopy.THICK.Length; i++)
                { THICK[i] = toCopy.THICK[i]; }
    
            BD = new double[toCopy.BD.Length];
            for (int i = 0; i < toCopy.BD.Length; i++)
                { BD[i] = toCopy.BD[i]; }
    
            SLCARB = new double[toCopy.SLCARB.Length];
            for (int i = 0; i < toCopy.SLCARB.Length; i++)
                { SLCARB[i] = toCopy.SLCARB[i]; }
    
            CLAY = new double[toCopy.CLAY.Length];
            for (int i = 0; i < toCopy.CLAY.Length; i++)
                { CLAY[i] = toCopy.CLAY[i]; }
    
            SLROCK = new double[toCopy.SLROCK.Length];
            for (int i = 0; i < toCopy.SLROCK.Length; i++)
                { SLROCK[i] = toCopy.SLROCK[i]; }
    
            SLSILT = new double[toCopy.SLSILT.Length];
            for (int i = 0; i < toCopy.SLSILT.Length; i++)
                { SLSILT[i] = toCopy.SLSILT[i]; }
    
            SLSAND = new double[toCopy.SLSAND.Length];
            for (int i = 0; i < toCopy.SLSAND.Length; i++)
                { SLSAND[i] = toCopy.SLSAND[i]; }
    
            SW = new double[toCopy.SW.Length];
            for (int i = 0; i < toCopy.SW.Length; i++)
                { SW[i] = toCopy.SW[i]; }
    
            T2M = toCopy.T2M;
            TMAX = toCopy.TMAX;
            TMIN = toCopy.TMIN;
            TAV = toCopy.TAV;
            DOY = toCopy.DOY;
            airPressure = toCopy.airPressure;
            canopyHeight = toCopy.canopyHeight;
            SRAD = toCopy.SRAD;
            ESP = toCopy.ESP;
            ES = toCopy.ES;
            EOAD = toCopy.EOAD;
            windSpeed = toCopy.windSpeed;
        }
    }
    public double[] THICK
    {
        get { return this._THICK; }
        set { this._THICK= value; } 
    }
    public double[] BD
    {
        get { return this._BD; }
        set { this._BD= value; } 
    }
    public double[] SLCARB
    {
        get { return this._SLCARB; }
        set { this._SLCARB= value; } 
    }
    public double[] CLAY
    {
        get { return this._CLAY; }
        set { this._CLAY= value; } 
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
    public double[] SW
    {
        get { return this._SW; }
        set { this._SW= value; } 
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
    public int DOY
    {
        get { return this._DOY; }
        set { this._DOY= value; } 
    }
    public double airPressure
    {
        get { return this._airPressure; }
        set { this._airPressure= value; } 
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