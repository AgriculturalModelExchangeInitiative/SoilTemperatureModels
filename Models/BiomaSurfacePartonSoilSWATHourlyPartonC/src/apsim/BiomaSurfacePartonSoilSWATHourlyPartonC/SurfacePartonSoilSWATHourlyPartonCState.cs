using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// state variables class of the SurfacePartonSoilSWATHourlyPartonC component
/// </summary>
public class SurfacePartonSoilSWATHourlyPartonCState
{
    private double[] _SoilTemperatureByLayers;
    private double[] _HeatCapacity;
    private double[] _ThermalConductivity;
    private double[] _ThermalDiffusivity;
    private double[] _SoilTemperatureRangeByLayers;
    private double[] _SoilTemperatureMinimum;
    private double[] _SoilTemperatureMaximum;
    private double[] _SoilTemperatureByLayersHourly;

    /// <summary>
    /// Constructor SurfacePartonSoilSWATHourlyPartonCState domain class
    /// </summary>
    public SurfacePartonSoilSWATHourlyPartonCState() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public SurfacePartonSoilSWATHourlyPartonCState(SurfacePartonSoilSWATHourlyPartonCState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            SoilTemperatureByLayers = new double[toCopy.SoilTemperatureByLayers.Length];
            for (int i = 0; i < toCopy.SoilTemperatureByLayers.Length; i++)
                { SoilTemperatureByLayers[i] = toCopy.SoilTemperatureByLayers[i]; }
    
            HeatCapacity = new double[toCopy.HeatCapacity.Length];
            for (int i = 0; i < toCopy.HeatCapacity.Length; i++)
                { HeatCapacity[i] = toCopy.HeatCapacity[i]; }
    
            ThermalConductivity = new double[toCopy.ThermalConductivity.Length];
            for (int i = 0; i < toCopy.ThermalConductivity.Length; i++)
                { ThermalConductivity[i] = toCopy.ThermalConductivity[i]; }
    
            ThermalDiffusivity = new double[toCopy.ThermalDiffusivity.Length];
            for (int i = 0; i < toCopy.ThermalDiffusivity.Length; i++)
                { ThermalDiffusivity[i] = toCopy.ThermalDiffusivity[i]; }
    
            SoilTemperatureRangeByLayers = new double[toCopy.SoilTemperatureRangeByLayers.Length];
            for (int i = 0; i < toCopy.SoilTemperatureRangeByLayers.Length; i++)
                { SoilTemperatureRangeByLayers[i] = toCopy.SoilTemperatureRangeByLayers[i]; }
    
            SoilTemperatureMinimum = new double[toCopy.SoilTemperatureMinimum.Length];
            for (int i = 0; i < toCopy.SoilTemperatureMinimum.Length; i++)
                { SoilTemperatureMinimum[i] = toCopy.SoilTemperatureMinimum[i]; }
    
            SoilTemperatureMaximum = new double[toCopy.SoilTemperatureMaximum.Length];
            for (int i = 0; i < toCopy.SoilTemperatureMaximum.Length; i++)
                { SoilTemperatureMaximum[i] = toCopy.SoilTemperatureMaximum[i]; }
    
            SoilTemperatureByLayersHourly = new double[toCopy.SoilTemperatureByLayersHourly.Length];
            for (int i = 0; i < toCopy.SoilTemperatureByLayersHourly.Length; i++)
                { SoilTemperatureByLayersHourly[i] = toCopy.SoilTemperatureByLayersHourly[i]; }
    
        }
    }

    /// <summary>
    /// Gets and sets the Soil temperature of each layer
    /// </summary>
    [Description("Soil temperature of each layer")] 
    [Units("degC")] 
    public double[] SoilTemperatureByLayers
    {
        get { return this._SoilTemperatureByLayers; }
        set { this._SoilTemperatureByLayers= value; } 
    }

    /// <summary>
    /// Gets and sets the Volumetric specific heat of soil
    /// </summary>
    [Description("Volumetric specific heat of soil")] 
    [Units("MJ m-3")] 
    public double[] HeatCapacity
    {
        get { return this._HeatCapacity; }
        set { this._HeatCapacity= value; } 
    }

    /// <summary>
    /// Gets and sets the Thermal conductivity of soil layer
    /// </summary>
    [Description("Thermal conductivity of soil layer")] 
    [Units("W m-1 K-1")] 
    public double[] ThermalConductivity
    {
        get { return this._ThermalConductivity; }
        set { this._ThermalConductivity= value; } 
    }

    /// <summary>
    /// Gets and sets the Thermal diffusivity of soil layer
    /// </summary>
    [Description("Thermal diffusivity of soil layer")] 
    [Units("mm s-1")] 
    public double[] ThermalDiffusivity
    {
        get { return this._ThermalDiffusivity; }
        set { this._ThermalDiffusivity= value; } 
    }

    /// <summary>
    /// Gets and sets the Soil temperature range by layers
    /// </summary>
    [Description("Soil temperature range by layers")] 
    [Units("degC")] 
    public double[] SoilTemperatureRangeByLayers
    {
        get { return this._SoilTemperatureRangeByLayers; }
        set { this._SoilTemperatureRangeByLayers= value; } 
    }

    /// <summary>
    /// Gets and sets the Minimum soil temperature by layers
    /// </summary>
    [Description("Minimum soil temperature by layers")] 
    [Units("degC")] 
    public double[] SoilTemperatureMinimum
    {
        get { return this._SoilTemperatureMinimum; }
        set { this._SoilTemperatureMinimum= value; } 
    }

    /// <summary>
    /// Gets and sets the Maximum soil temperature by layers
    /// </summary>
    [Description("Maximum soil temperature by layers")] 
    [Units("degC")] 
    public double[] SoilTemperatureMaximum
    {
        get { return this._SoilTemperatureMaximum; }
        set { this._SoilTemperatureMaximum= value; } 
    }

    /// <summary>
    /// Gets and sets the Hourly soil temperature by layers
    /// </summary>
    [Description("Hourly soil temperature by layers")] 
    [Units("degC")] 
    public double[] SoilTemperatureByLayersHourly
    {
        get { return this._SoilTemperatureByLayersHourly; }
        set { this._SoilTemperatureByLayersHourly= value; } 
    }

}