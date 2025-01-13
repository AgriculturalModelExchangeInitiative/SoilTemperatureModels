using System;
using System.Collections.Generic;

public class SoiltempExogenous 
{
    private double _weather_MaxT;
    private double[] _waterBalance_SW;
    private int _clock_Today_DayOfYear;
    private double _weather_Radn;
    private double _microClimate_CanopyHeight;
    private double _weather_Latitude;
    private double _weather_MeanT;
    private double[] _physical_Rocks;
    private double _waterBalance_Eo;
    private double _timestep;
    private double _weather_MinT;
    private double[] _organic_Carbon;
    private double _weather_Tav;
    private double[] _physical_ParticleSizeSand;
    private double _weather_AirPressure;
    private double _waterBalance_Eos;
    private double _waterBalance_Es;
    private double _waterBalance_Salb;
    private double[] _physical_ParticleSizeSilt;
    private double _weather_Wind;
    private double _weather_Amp;
    private double[] _physical_ParticleSizeClay;
    
    /// <summary>
    /// Constructor of the SoiltempExogenous component")
    /// </summary>  
    public SoiltempExogenous() { }
    
    
    public SoiltempExogenous(SoiltempExogenous toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            weather_MaxT = toCopy.weather_MaxT;
            waterBalance_SW = new double[toCopy.waterBalance_SW.Length];
        for (int i = 0; i < toCopy.waterBalance_SW.Length; i++)
            { waterBalance_SW[i] = toCopy.waterBalance_SW[i]; }
    
            clock_Today_DayOfYear = toCopy.clock_Today_DayOfYear;
            weather_Radn = toCopy.weather_Radn;
            microClimate_CanopyHeight = toCopy.microClimate_CanopyHeight;
            weather_Latitude = toCopy.weather_Latitude;
            weather_MeanT = toCopy.weather_MeanT;
            physical_Rocks = new double[toCopy.physical_Rocks.Length];
        for (int i = 0; i < toCopy.physical_Rocks.Length; i++)
            { physical_Rocks[i] = toCopy.physical_Rocks[i]; }
    
            waterBalance_Eo = toCopy.waterBalance_Eo;
            timestep = toCopy.timestep;
            weather_MinT = toCopy.weather_MinT;
            organic_Carbon = new double[toCopy.organic_Carbon.Length];
        for (int i = 0; i < toCopy.organic_Carbon.Length; i++)
            { organic_Carbon[i] = toCopy.organic_Carbon[i]; }
    
            weather_Tav = toCopy.weather_Tav;
            physical_ParticleSizeSand = new double[toCopy.physical_ParticleSizeSand.Length];
        for (int i = 0; i < toCopy.physical_ParticleSizeSand.Length; i++)
            { physical_ParticleSizeSand[i] = toCopy.physical_ParticleSizeSand[i]; }
    
            weather_AirPressure = toCopy.weather_AirPressure;
            waterBalance_Eos = toCopy.waterBalance_Eos;
            waterBalance_Es = toCopy.waterBalance_Es;
            waterBalance_Salb = toCopy.waterBalance_Salb;
            physical_ParticleSizeSilt = new double[toCopy.physical_ParticleSizeSilt.Length];
        for (int i = 0; i < toCopy.physical_ParticleSizeSilt.Length; i++)
            { physical_ParticleSizeSilt[i] = toCopy.physical_ParticleSizeSilt[i]; }
    
            weather_Wind = toCopy.weather_Wind;
            weather_Amp = toCopy.weather_Amp;
            physical_ParticleSizeClay = new double[toCopy.physical_ParticleSizeClay.Length];
        for (int i = 0; i < toCopy.physical_ParticleSizeClay.Length; i++)
            { physical_ParticleSizeClay[i] = toCopy.physical_ParticleSizeClay[i]; }
    
        }
    }
    public double weather_MaxT
    {
        get { return this._weather_MaxT; }
        set { this._weather_MaxT= value; } 
    }
    public double[] waterBalance_SW
    {
        get { return this._waterBalance_SW; }
        set { this._waterBalance_SW= value; } 
    }
    public int clock_Today_DayOfYear
    {
        get { return this._clock_Today_DayOfYear; }
        set { this._clock_Today_DayOfYear= value; } 
    }
    public double weather_Radn
    {
        get { return this._weather_Radn; }
        set { this._weather_Radn= value; } 
    }
    public double microClimate_CanopyHeight
    {
        get { return this._microClimate_CanopyHeight; }
        set { this._microClimate_CanopyHeight= value; } 
    }
    public double weather_Latitude
    {
        get { return this._weather_Latitude; }
        set { this._weather_Latitude= value; } 
    }
    public double weather_MeanT
    {
        get { return this._weather_MeanT; }
        set { this._weather_MeanT= value; } 
    }
    public double[] physical_Rocks
    {
        get { return this._physical_Rocks; }
        set { this._physical_Rocks= value; } 
    }
    public double waterBalance_Eo
    {
        get { return this._waterBalance_Eo; }
        set { this._waterBalance_Eo= value; } 
    }
    public double timestep
    {
        get { return this._timestep; }
        set { this._timestep= value; } 
    }
    public double weather_MinT
    {
        get { return this._weather_MinT; }
        set { this._weather_MinT= value; } 
    }
    public double[] organic_Carbon
    {
        get { return this._organic_Carbon; }
        set { this._organic_Carbon= value; } 
    }
    public double weather_Tav
    {
        get { return this._weather_Tav; }
        set { this._weather_Tav= value; } 
    }
    public double[] physical_ParticleSizeSand
    {
        get { return this._physical_ParticleSizeSand; }
        set { this._physical_ParticleSizeSand= value; } 
    }
    public double weather_AirPressure
    {
        get { return this._weather_AirPressure; }
        set { this._weather_AirPressure= value; } 
    }
    public double waterBalance_Eos
    {
        get { return this._waterBalance_Eos; }
        set { this._waterBalance_Eos= value; } 
    }
    public double waterBalance_Es
    {
        get { return this._waterBalance_Es; }
        set { this._waterBalance_Es= value; } 
    }
    public double waterBalance_Salb
    {
        get { return this._waterBalance_Salb; }
        set { this._waterBalance_Salb= value; } 
    }
    public double[] physical_ParticleSizeSilt
    {
        get { return this._physical_ParticleSizeSilt; }
        set { this._physical_ParticleSizeSilt= value; } 
    }
    public double weather_Wind
    {
        get { return this._weather_Wind; }
        set { this._weather_Wind= value; } 
    }
    public double weather_Amp
    {
        get { return this._weather_Amp; }
        set { this._weather_Amp= value; } 
    }
    public double[] physical_ParticleSizeClay
    {
        get { return this._physical_ParticleSizeClay; }
        set { this._physical_ParticleSizeClay= value; } 
    }
}