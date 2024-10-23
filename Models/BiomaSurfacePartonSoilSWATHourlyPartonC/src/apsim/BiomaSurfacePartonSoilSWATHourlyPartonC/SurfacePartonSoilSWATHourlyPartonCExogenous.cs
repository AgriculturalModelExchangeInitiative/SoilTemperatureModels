using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// exogenous variables class of the SurfacePartonSoilSWATHourlyPartonC component
/// </summary>
public class SurfacePartonSoilSWATHourlyPartonCExogenous
{
    private double _AirTemperatureMinimum;
    private double _DayLength;
    private double _GlobalSolarRadiation;
    private double _AirTemperatureMaximum;
    private double[] _VolumetricWaterContent;
    private double _HourOfSunset;
    private double _HourOfSunrise;

    /// <summary>
    /// Constructor SurfacePartonSoilSWATHourlyPartonCExogenous domain class
    /// </summary>
    public SurfacePartonSoilSWATHourlyPartonCExogenous() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public SurfacePartonSoilSWATHourlyPartonCExogenous(SurfacePartonSoilSWATHourlyPartonCExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            AirTemperatureMinimum = toCopy.AirTemperatureMinimum;
            DayLength = toCopy.DayLength;
            GlobalSolarRadiation = toCopy.GlobalSolarRadiation;
            AirTemperatureMaximum = toCopy.AirTemperatureMaximum;
            VolumetricWaterContent = new double[toCopy.VolumetricWaterContent.Length];
            for (int i = 0; i < toCopy.VolumetricWaterContent.Length; i++)
                { VolumetricWaterContent[i] = toCopy.VolumetricWaterContent[i]; }
    
            HourOfSunset = toCopy.HourOfSunset;
            HourOfSunrise = toCopy.HourOfSunrise;
        }
    }

    /// <summary>
    /// Gets and sets the Minimum daily air temperature
    /// </summary>
    [Description("Minimum daily air temperature")] 
    [Units("degC")] 
    public double AirTemperatureMinimum
    {
        get { return this._AirTemperatureMinimum; }
        set { this._AirTemperatureMinimum= value; } 
    }

    /// <summary>
    /// Gets and sets the Length of the day
    /// </summary>
    [Description("Length of the day")] 
    [Units("h")] 
    public double DayLength
    {
        get { return this._DayLength; }
        set { this._DayLength= value; } 
    }

    /// <summary>
    /// Gets and sets the Daily global solar radiation
    /// </summary>
    [Description("Daily global solar radiation")] 
    [Units("Mj m-2 d-1")] 
    public double GlobalSolarRadiation
    {
        get { return this._GlobalSolarRadiation; }
        set { this._GlobalSolarRadiation= value; } 
    }

    /// <summary>
    /// Gets and sets the Maximum daily air temperature
    /// </summary>
    [Description("Maximum daily air temperature")] 
    [Units("degC")] 
    public double AirTemperatureMaximum
    {
        get { return this._AirTemperatureMaximum; }
        set { this._AirTemperatureMaximum= value; } 
    }

    /// <summary>
    /// Gets and sets the Volumetric soil water content
    /// </summary>
    [Description("Volumetric soil water content")] 
    [Units("m3 m-3")] 
    public double[] VolumetricWaterContent
    {
        get { return this._VolumetricWaterContent; }
        set { this._VolumetricWaterContent= value; } 
    }

    /// <summary>
    /// Gets and sets the Hour of sunset
    /// </summary>
    [Description("Hour of sunset")] 
    [Units("h")] 
    public double HourOfSunset
    {
        get { return this._HourOfSunset; }
        set { this._HourOfSunset= value; } 
    }

    /// <summary>
    /// Gets and sets the Hour of sunrise
    /// </summary>
    [Description("Hour of sunrise")] 
    [Units("h")] 
    public double HourOfSunrise
    {
        get { return this._HourOfSunrise; }
        set { this._HourOfSunrise= value; } 
    }

}