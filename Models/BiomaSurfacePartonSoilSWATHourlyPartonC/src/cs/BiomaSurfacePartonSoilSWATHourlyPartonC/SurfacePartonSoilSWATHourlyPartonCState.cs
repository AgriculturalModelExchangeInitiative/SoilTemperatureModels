using System;
using System.Collections.Generic;
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
    
        public SurfacePartonSoilSWATHourlyPartonCState() { }
    
    
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