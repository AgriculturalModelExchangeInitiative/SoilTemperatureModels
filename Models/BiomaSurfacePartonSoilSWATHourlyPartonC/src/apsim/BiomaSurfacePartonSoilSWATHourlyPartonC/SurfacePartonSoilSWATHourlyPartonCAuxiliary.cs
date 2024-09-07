using System;
using System.Collections.Generic;
using Models.Core;
namespace Models.Crop2ML;

/// <summary>
/// auxiliary variables class of the SurfacePartonSoilSWATHourlyPartonC component
/// </summary>
public class SurfacePartonSoilSWATHourlyPartonCAuxiliary
{
    private double _AboveGroundBiomass;
    private double[] _Sand;
    private double[] _OrganicMatter;
    private double _SurfaceSoilTemperature;
    private double _SurfaceTemperatureMinimum;
    private double _SurfaceTemperatureMaximum;

    /// <summary>
    /// Constructor SurfacePartonSoilSWATHourlyPartonCAuxiliary domain class
    /// </summary>
    public SurfacePartonSoilSWATHourlyPartonCAuxiliary() { }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="toCopy"></param>
    /// <param name="copyAll"></param>
    public SurfacePartonSoilSWATHourlyPartonCAuxiliary(SurfacePartonSoilSWATHourlyPartonCAuxiliary toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
            AboveGroundBiomass = toCopy.AboveGroundBiomass;
            Sand = new double[toCopy.Sand.Length];
            for (int i = 0; i < toCopy.Sand.Length; i++)
                { Sand[i] = toCopy.Sand[i]; }
    
            OrganicMatter = new double[toCopy.OrganicMatter.Length];
            for (int i = 0; i < toCopy.OrganicMatter.Length; i++)
                { OrganicMatter[i] = toCopy.OrganicMatter[i]; }
    
            SurfaceSoilTemperature = toCopy.SurfaceSoilTemperature;
            SurfaceTemperatureMinimum = toCopy.SurfaceTemperatureMinimum;
            SurfaceTemperatureMaximum = toCopy.SurfaceTemperatureMaximum;
        }
    }

    /// <summary>
    /// Gets and sets the Above ground biomass
    /// </summary>
    [Description("Above ground biomass")] 
    [Units("Kg ha-1")] 
    public double AboveGroundBiomass
    {
        get { return this._AboveGroundBiomass; }
        set { this._AboveGroundBiomass= value; } 
    }

    /// <summary>
    /// Gets and sets the Sand content of soil layer
    /// </summary>
    [Description("Sand content of soil layer")] 
    [Units("")] 
    public double[] Sand
    {
        get { return this._Sand; }
        set { this._Sand= value; } 
    }

    /// <summary>
    /// Gets and sets the Organic matter content of soil layer
    /// </summary>
    [Description("Organic matter content of soil layer")] 
    [Units("")] 
    public double[] OrganicMatter
    {
        get { return this._OrganicMatter; }
        set { this._OrganicMatter= value; } 
    }

    /// <summary>
    /// Gets and sets the Average surface soil temperature
    /// </summary>
    [Description("Average surface soil temperature")] 
    [Units("degC")] 
    public double SurfaceSoilTemperature
    {
        get { return this._SurfaceSoilTemperature; }
        set { this._SurfaceSoilTemperature= value; } 
    }

    /// <summary>
    /// Gets and sets the Minimum surface soil temperature
    /// </summary>
    [Description("Minimum surface soil temperature")] 
    [Units("")] 
    public double SurfaceTemperatureMinimum
    {
        get { return this._SurfaceTemperatureMinimum; }
        set { this._SurfaceTemperatureMinimum= value; } 
    }

    /// <summary>
    /// Gets and sets the Maximum surface soil temperature
    /// </summary>
    [Description("Maximum surface soil temperature")] 
    [Units("degC             */")] 
    public double SurfaceTemperatureMaximum
    {
        get { return this._SurfaceTemperatureMaximum; }
        set { this._SurfaceTemperatureMaximum= value; } 
    }

}