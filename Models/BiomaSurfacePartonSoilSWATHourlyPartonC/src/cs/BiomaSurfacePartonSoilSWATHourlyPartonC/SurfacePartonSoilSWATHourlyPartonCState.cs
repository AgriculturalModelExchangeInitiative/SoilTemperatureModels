using System;
using System.Collections.Generic;
public class SurfacePartonSoilSWATHourlyPartonCState 
{
    private double[] _SoilTemperatureByLayers;
    private double[] _HeatCapacity;
    private double[] _ThermalDiffusivity;
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
    
    ThermalDiffusivity = new double[toCopy.ThermalDiffusivity.Length];
            for (int i = 0; i < toCopy.ThermalDiffusivity.Length; i++)
            { ThermalDiffusivity[i] = toCopy.ThermalDiffusivity[i]; }
    
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
    public double[] ThermalDiffusivity
        {
            get { return this._ThermalDiffusivity; }
            set { this._ThermalDiffusivity= value; } 
        }
    public double[] SoilTemperatureByLayersHourly
        {
            get { return this._SoilTemperatureByLayersHourly; }
            set { this._SoilTemperatureByLayersHourly= value; } 
        }
}