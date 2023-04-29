using System;
using System.Collections.Generic;
public class SurfacePartonSoilSWATHourlyPartonCState 
{
    private double _AboveGroundBiomass;
    private double[] _VolumetricWaterContent;
    private double[] _BulkDensity;
    private double[] _LayerThickness;
    private double _SoilProfileDepth;
    private double[] _Sand;
    private double[] _OrganicMatter;
    private double[] _Clay;
    private double[] _Silt;
    private double _SurfaceSoilTemperature;
    private double[] _SoilTemperatureByLayers;
    private double[] _HeatCapacity;
    private double[] _ThermalConductivity;
    private double[] _ThermalDiffusivity;
    private double[] _SoilTemperatureRangeByLayers;
    private double[] _SoilTemperatureMinimum;
    private double[] _SoilTemperatureMaximum;
    private double[] _SoilTemperatureByLayersHourly;
    
        public SurfacePartonSoilSWATHourlyPartonCState() { }
    
    
    public SurfacePartonSoilSWATHourlyPartonCState(SurfacePartonSoilSWATHourlyPartonCState toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _AboveGroundBiomass = toCopy._AboveGroundBiomass;
    VolumetricWaterContent = new double[toCopy._VolumetricWaterContent.Length];
            for (int i = 0; i < toCopy._VolumetricWaterContent.Length; i++)
            { _VolumetricWaterContent[i] = toCopy._VolumetricWaterContent[i]; }
    
    BulkDensity = new double[toCopy._BulkDensity.Length];
            for (int i = 0; i < toCopy._BulkDensity.Length; i++)
            { _BulkDensity[i] = toCopy._BulkDensity[i]; }
    
    LayerThickness = new double[toCopy._LayerThickness.Length];
            for (int i = 0; i < toCopy._LayerThickness.Length; i++)
            { _LayerThickness[i] = toCopy._LayerThickness[i]; }
    
    _SoilProfileDepth = toCopy._SoilProfileDepth;
    Sand = new double[toCopy._Sand.Length];
            for (int i = 0; i < toCopy._Sand.Length; i++)
            { _Sand[i] = toCopy._Sand[i]; }
    
    OrganicMatter = new double[toCopy._OrganicMatter.Length];
            for (int i = 0; i < toCopy._OrganicMatter.Length; i++)
            { _OrganicMatter[i] = toCopy._OrganicMatter[i]; }
    
    Clay = new double[toCopy._Clay.Length];
            for (int i = 0; i < toCopy._Clay.Length; i++)
            { _Clay[i] = toCopy._Clay[i]; }
    
    Silt = new double[toCopy._Silt.Length];
            for (int i = 0; i < toCopy._Silt.Length; i++)
            { _Silt[i] = toCopy._Silt[i]; }
    
    _SurfaceSoilTemperature = toCopy._SurfaceSoilTemperature;
    SoilTemperatureByLayers = new double[toCopy._SoilTemperatureByLayers.Length];
            for (int i = 0; i < toCopy._SoilTemperatureByLayers.Length; i++)
            { _SoilTemperatureByLayers[i] = toCopy._SoilTemperatureByLayers[i]; }
    
    HeatCapacity = new double[toCopy._HeatCapacity.Length];
            for (int i = 0; i < toCopy._HeatCapacity.Length; i++)
            { _HeatCapacity[i] = toCopy._HeatCapacity[i]; }
    
    ThermalConductivity = new double[toCopy._ThermalConductivity.Length];
            for (int i = 0; i < toCopy._ThermalConductivity.Length; i++)
            { _ThermalConductivity[i] = toCopy._ThermalConductivity[i]; }
    
    ThermalDiffusivity = new double[toCopy._ThermalDiffusivity.Length];
            for (int i = 0; i < toCopy._ThermalDiffusivity.Length; i++)
            { _ThermalDiffusivity[i] = toCopy._ThermalDiffusivity[i]; }
    
    SoilTemperatureRangeByLayers = new double[toCopy._SoilTemperatureRangeByLayers.Length];
            for (int i = 0; i < toCopy._SoilTemperatureRangeByLayers.Length; i++)
            { _SoilTemperatureRangeByLayers[i] = toCopy._SoilTemperatureRangeByLayers[i]; }
    
    SoilTemperatureMinimum = new double[toCopy._SoilTemperatureMinimum.Length];
            for (int i = 0; i < toCopy._SoilTemperatureMinimum.Length; i++)
            { _SoilTemperatureMinimum[i] = toCopy._SoilTemperatureMinimum[i]; }
    
    SoilTemperatureMaximum = new double[toCopy._SoilTemperatureMaximum.Length];
            for (int i = 0; i < toCopy._SoilTemperatureMaximum.Length; i++)
            { _SoilTemperatureMaximum[i] = toCopy._SoilTemperatureMaximum[i]; }
    
    SoilTemperatureByLayersHourly = new double[toCopy._SoilTemperatureByLayersHourly.Length];
            for (int i = 0; i < toCopy._SoilTemperatureByLayersHourly.Length; i++)
            { _SoilTemperatureByLayersHourly[i] = toCopy._SoilTemperatureByLayersHourly[i]; }
    
    }
    }
    public double AboveGroundBiomass
        {
            get { return this._AboveGroundBiomass; }
            set { this._AboveGroundBiomass= value; } 
        }
    public double[] VolumetricWaterContent
        {
            get { return this._VolumetricWaterContent; }
            set { this._VolumetricWaterContent= value; } 
        }
    public double[] BulkDensity
        {
            get { return this._BulkDensity; }
            set { this._BulkDensity= value; } 
        }
    public double[] LayerThickness
        {
            get { return this._LayerThickness; }
            set { this._LayerThickness= value; } 
        }
    public double SoilProfileDepth
        {
            get { return this._SoilProfileDepth; }
            set { this._SoilProfileDepth= value; } 
        }
    public double[] Sand
        {
            get { return this._Sand; }
            set { this._Sand= value; } 
        }
    public double[] OrganicMatter
        {
            get { return this._OrganicMatter; }
            set { this._OrganicMatter= value; } 
        }
    public double[] Clay
        {
            get { return this._Clay; }
            set { this._Clay= value; } 
        }
    public double[] Silt
        {
            get { return this._Silt; }
            set { this._Silt= value; } 
        }
    public double SurfaceSoilTemperature
        {
            get { return this._SurfaceSoilTemperature; }
            set { this._SurfaceSoilTemperature= value; } 
        }
    public double[] SoilTemperatureByLayers
        {
            get { return this._SoilTemperatureByLayers; }
            set { this._SoilTemperatureByLayers= value; } 
        }
    public double[] HeatCapacity
        {
            get { return this._HeatCapacity; }
            set { this._HeatCapacity= value; } 
        }
    public double[] ThermalConductivity
        {
            get { return this._ThermalConductivity; }
            set { this._ThermalConductivity= value; } 
        }
    public double[] ThermalDiffusivity
        {
            get { return this._ThermalDiffusivity; }
            set { this._ThermalDiffusivity= value; } 
        }
    public double[] SoilTemperatureRangeByLayers
        {
            get { return this._SoilTemperatureRangeByLayers; }
            set { this._SoilTemperatureRangeByLayers= value; } 
        }
    public double[] SoilTemperatureMinimum
        {
            get { return this._SoilTemperatureMinimum; }
            set { this._SoilTemperatureMinimum= value; } 
        }
    public double[] SoilTemperatureMaximum
        {
            get { return this._SoilTemperatureMaximum; }
            set { this._SoilTemperatureMaximum= value; } 
        }
    public double[] SoilTemperatureByLayersHourly
        {
            get { return this._SoilTemperatureByLayersHourly; }
            set { this._SoilTemperatureByLayersHourly= value; } 
        }
}