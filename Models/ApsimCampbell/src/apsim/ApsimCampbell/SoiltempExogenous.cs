using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// exogenous variables class of the Soiltemp component
/// </summary>
public class SoiltempExogenous
{
    private double _waterBalance_Eo;
    private double _waterBalance_Salb;
    private double[] _organic_Carbon;
    private double _waterBalance_Es;
    private double _weather_Wind;
    private double[] _physical_ParticleSizeSand;
    private double _weather_AirPressure;
    private int _clock_Today_DayOfYear;
    private double _microClimate_CanopyHeight;
    private double _waterBalance_Eos;
    private double[] _waterBalance_SW;
    private double _weather_Amp;
    private double _weather_MinT;
    private double _weather_Radn;
    private double[] _physical_Rocks;
    private double _weather_Tav;
    private double _weather_MaxT;
    private double _weather_MeanT;
    private double[] _physical_ParticleSizeSilt;
    private double[] _physical_ParticleSizeClay;

    /// <summary>
    /// Constructor SoiltempExogenous domain class
    /// </summary>
    public SoiltempExogenous() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public SoiltempExogenous(SoiltempExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            waterBalance_Eo = toCopy.waterBalance_Eo;
            waterBalance_Salb = toCopy.waterBalance_Salb;
            organic_Carbon = new double[toCopy.organic_Carbon.Length];
        for (int i = 0; i < toCopy.organic_Carbon.Length; i++)
            { organic_Carbon[i] = toCopy.organic_Carbon[i]; }
    
            waterBalance_Es = toCopy.waterBalance_Es;
            weather_Wind = toCopy.weather_Wind;
            physical_ParticleSizeSand = new double[toCopy.physical_ParticleSizeSand.Length];
        for (int i = 0; i < toCopy.physical_ParticleSizeSand.Length; i++)
            { physical_ParticleSizeSand[i] = toCopy.physical_ParticleSizeSand[i]; }
    
            weather_AirPressure = toCopy.weather_AirPressure;
            clock_Today_DayOfYear = toCopy.clock_Today_DayOfYear;
            microClimate_CanopyHeight = toCopy.microClimate_CanopyHeight;
            waterBalance_Eos = toCopy.waterBalance_Eos;
            waterBalance_SW = new double[toCopy.waterBalance_SW.Length];
        for (int i = 0; i < toCopy.waterBalance_SW.Length; i++)
            { waterBalance_SW[i] = toCopy.waterBalance_SW[i]; }
    
            weather_Amp = toCopy.weather_Amp;
            weather_MinT = toCopy.weather_MinT;
            weather_Radn = toCopy.weather_Radn;
            physical_Rocks = new double[toCopy.physical_Rocks.Length];
        for (int i = 0; i < toCopy.physical_Rocks.Length; i++)
            { physical_Rocks[i] = toCopy.physical_Rocks[i]; }
    
            weather_Tav = toCopy.weather_Tav;
            weather_MaxT = toCopy.weather_MaxT;
            weather_MeanT = toCopy.weather_MeanT;
            physical_ParticleSizeSilt = new double[toCopy.physical_ParticleSizeSilt.Length];
        for (int i = 0; i < toCopy.physical_ParticleSizeSilt.Length; i++)
            { physical_ParticleSizeSilt[i] = toCopy.physical_ParticleSizeSilt[i]; }
    
            physical_ParticleSizeClay = new double[toCopy.physical_ParticleSizeClay.Length];
        for (int i = 0; i < toCopy.physical_ParticleSizeClay.Length; i++)
            { physical_ParticleSizeClay[i] = toCopy.physical_ParticleSizeClay[i]; }
    
        }
    }

    /// <summary>
    /// Gets and sets the Potential soil evapotranspiration from soil surface
    /// </summary>
    [Description("Potential soil evapotranspiration from soil surface")] 
    [Units("mm")] 
    public double waterBalance_Eo
    {
        get { return this._waterBalance_Eo; }
        set { this._waterBalance_Eo= value; } 
    }

    /// <summary>
    /// Gets and sets the Fraction of incoming radiation reflected from bare soil
    /// </summary>
    [Description("Fraction of incoming radiation reflected from bare soil")] 
    [Units("0-1")] 
    public double waterBalance_Salb
    {
        get { return this._waterBalance_Salb; }
        set { this._waterBalance_Salb= value; } 
    }

    /// <summary>
    /// Gets and sets the Total organic carbon
    /// </summary>
    [Description("Total organic carbon")] 
    [Units("%")] 
    public double[] organic_Carbon
    {
        get { return this._organic_Carbon; }
        set { this._organic_Carbon= value; } 
    }

    /// <summary>
    /// Gets and sets the Actual (realised) soil water evaporation
    /// </summary>
    [Description("Actual (realised) soil water evaporation")] 
    [Units("mm")] 
    public double waterBalance_Es
    {
        get { return this._waterBalance_Es; }
        set { this._waterBalance_Es= value; } 
    }

    /// <summary>
    /// Gets and sets the Wind speed
    /// </summary>
    [Description("Wind speed")] 
    [Units("m/s")] 
    public double weather_Wind
    {
        get { return this._weather_Wind; }
        set { this._weather_Wind= value; } 
    }

    /// <summary>
    /// Gets and sets the Particle size sand
    /// </summary>
    [Description("Particle size sand")] 
    [Units("%")] 
    public double[] physical_ParticleSizeSand
    {
        get { return this._physical_ParticleSizeSand; }
        set { this._physical_ParticleSizeSand= value; } 
    }

    /// <summary>
    /// Gets and sets the Air pressure
    /// </summary>
    [Description("Air pressure")] 
    [Units("hPa")] 
    public double weather_AirPressure
    {
        get { return this._weather_AirPressure; }
        set { this._weather_AirPressure= value; } 
    }

    /// <summary>
    /// Gets and sets the Day of year
    /// </summary>
    [Description("Day of year")] 
    [Units("day number")] 
    public int clock_Today_DayOfYear
    {
        get { return this._clock_Today_DayOfYear; }
        set { this._clock_Today_DayOfYear= value; } 
    }

    /// <summary>
    /// Gets and sets the Canopy height
    /// </summary>
    [Description("Canopy height")] 
    [Units("mm")] 
    public double microClimate_CanopyHeight
    {
        get { return this._microClimate_CanopyHeight; }
        set { this._microClimate_CanopyHeight= value; } 
    }

    /// <summary>
    /// Gets and sets the Potential soil evaporation from soil surface
    /// </summary>
    [Description("Potential soil evaporation from soil surface")] 
    [Units("mm")] 
    public double waterBalance_Eos
    {
        get { return this._waterBalance_Eos; }
        set { this._waterBalance_Eos= value; } 
    }

    /// <summary>
    /// Gets and sets the Volumetric water content
    /// </summary>
    [Description("Volumetric water content")] 
    [Units("mm/mm")] 
    public double[] waterBalance_SW
    {
        get { return this._waterBalance_SW; }
        set { this._waterBalance_SW= value; } 
    }

    /// <summary>
    /// Gets and sets the Annual average temperature amplitude
    /// </summary>
    [Description("Annual average temperature amplitude")] 
    [Units("oC")] 
    public double weather_Amp
    {
        get { return this._weather_Amp; }
        set { this._weather_Amp= value; } 
    }

    /// <summary>
    /// Gets and sets the Minimum temperature
    /// </summary>
    [Description("Minimum temperature")] 
    [Units("oC")] 
    public double weather_MinT
    {
        get { return this._weather_MinT; }
        set { this._weather_MinT= value; } 
    }

    /// <summary>
    /// Gets and sets the Solar radiation
    /// </summary>
    [Description("Solar radiation")] 
    [Units("MJ/m2/day")] 
    public double weather_Radn
    {
        get { return this._weather_Radn; }
        set { this._weather_Radn= value; } 
    }

    /// <summary>
    /// Gets and sets the Rocks
    /// </summary>
    [Description("Rocks")] 
    [Units("%")] 
    public double[] physical_Rocks
    {
        get { return this._physical_Rocks; }
        set { this._physical_Rocks= value; } 
    }

    /// <summary>
    /// Gets and sets the Annual average temperature
    /// </summary>
    [Description("Annual average temperature")] 
    [Units("oC")] 
    public double weather_Tav
    {
        get { return this._weather_Tav; }
        set { this._weather_Tav= value; } 
    }

    /// <summary>
    /// Gets and sets the Maximum temperature
    /// </summary>
    [Description("Maximum temperature")] 
    [Units("oC")] 
    public double weather_MaxT
    {
        get { return this._weather_MaxT; }
        set { this._weather_MaxT= value; } 
    }

    /// <summary>
    /// Gets and sets the Mean temperature
    /// </summary>
    [Description("Mean temperature")] 
    [Units("oC")] 
    public double weather_MeanT
    {
        get { return this._weather_MeanT; }
        set { this._weather_MeanT= value; } 
    }

    /// <summary>
    /// Gets and sets the Particle size silt
    /// </summary>
    [Description("Particle size silt")] 
    [Units("%")] 
    public double[] physical_ParticleSizeSilt
    {
        get { return this._physical_ParticleSizeSilt; }
        set { this._physical_ParticleSizeSilt= value; } 
    }

    /// <summary>
    /// Gets and sets the Particle size clay
    /// </summary>
    [Description("Particle size clay")] 
    [Units("%")] 
    public double[] physical_ParticleSizeClay
    {
        get { return this._physical_ParticleSizeClay; }
        set { this._physical_ParticleSizeClay= value; } 
    }

}