using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// exogenous variables class of the Model_SoilTempCampbell component
/// </summary>
public class Model_SoilTempCampbellExogenous
{
    private double _T2M;
    private double _TMAX;
    private double _TMIN;
    private int _DOY;
    private double _airPressure;
    private double _canopyHeight;
    private double _SRAD;
    private double _ESP;
    private double _ES;
    private double _EOAD;
    private double _windSpeed;

    /// <summary>
    /// Constructor Model_SoilTempCampbellExogenous domain class
    /// </summary>
    public Model_SoilTempCampbellExogenous() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public Model_SoilTempCampbellExogenous(Model_SoilTempCampbellExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            T2M = toCopy.T2M;
            TMAX = toCopy.TMAX;
            TMIN = toCopy.TMIN;
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

    /// <summary>
    /// Gets and sets the Mean daily Air temperature
    /// </summary>
    [Description("Mean daily Air temperature")] 
    [Units("")] 
    public double T2M
    {
        get { return this._T2M; }
        set { this._T2M= value; } 
    }

    /// <summary>
    /// Gets and sets the Max daily Air temperature
    /// </summary>
    [Description("Max daily Air temperature")] 
    [Units("")] 
    public double TMAX
    {
        get { return this._TMAX; }
        set { this._TMAX= value; } 
    }

    /// <summary>
    /// Gets and sets the Min daily Air temperature
    /// </summary>
    [Description("Min daily Air temperature")] 
    [Units("")] 
    public double TMIN
    {
        get { return this._TMIN; }
        set { this._TMIN= value; } 
    }

    /// <summary>
    /// Gets and sets the Day of year
    /// </summary>
    [Description("Day of year")] 
    [Units("dimensionless")] 
    public int DOY
    {
        get { return this._DOY; }
        set { this._DOY= value; } 
    }

    /// <summary>
    /// Gets and sets the Air pressure
    /// </summary>
    [Description("Air pressure")] 
    [Units("hPA")] 
    public double airPressure
    {
        get { return this._airPressure; }
        set { this._airPressure= value; } 
    }

    /// <summary>
    /// Gets and sets the height of canopy above ground
    /// </summary>
    [Description("height of canopy above ground")] 
    [Units("m")] 
    public double canopyHeight
    {
        get { return this._canopyHeight; }
        set { this._canopyHeight= value; } 
    }

    /// <summary>
    /// Gets and sets the Solar radiation
    /// </summary>
    [Description("Solar radiation")] 
    [Units("MJ/m2")] 
    public double SRAD
    {
        get { return this._SRAD; }
        set { this._SRAD= value; } 
    }

    /// <summary>
    /// Gets and sets the Potential evaporation
    /// </summary>
    [Description("Potential evaporation")] 
    [Units("mm")] 
    public double ESP
    {
        get { return this._ESP; }
        set { this._ESP= value; } 
    }

    /// <summary>
    /// Gets and sets the Actual evaporation
    /// </summary>
    [Description("Actual evaporation")] 
    [Units("mm")] 
    public double ES
    {
        get { return this._ES; }
        set { this._ES= value; } 
    }

    /// <summary>
    /// Gets and sets the Potential evapotranspiration
    /// </summary>
    [Description("Potential evapotranspiration")] 
    [Units("mm")] 
    public double EOAD
    {
        get { return this._EOAD; }
        set { this._EOAD= value; } 
    }

    /// <summary>
    /// Gets and sets the Speed of wind
    /// </summary>
    [Description("Speed of wind")] 
    [Units("m/s")] 
    public double windSpeed
    {
        get { return this._windSpeed; }
        set { this._windSpeed= value; } 
    }

}