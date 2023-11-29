using System;
using System.Collections.Generic;

public class SurfaceSWATSoilSWATCExogenous 
{
    private double _Albedo;
    private double _AirTemperatureMinimum;
    private double _WaterEquivalentOfSnowPack;
    private double _GlobalSolarRadiation;
    private double _AirTemperatureMaximum;
    
        public SurfaceSWATSoilSWATCExogenous() { }
    
    
    public SurfaceSWATSoilSWATCExogenous(SurfaceSWATSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    Albedo = toCopy.Albedo;
    AirTemperatureMinimum = toCopy.AirTemperatureMinimum;
    WaterEquivalentOfSnowPack = toCopy.WaterEquivalentOfSnowPack;
    GlobalSolarRadiation = toCopy.GlobalSolarRadiation;
    AirTemperatureMaximum = toCopy.AirTemperatureMaximum;
    }
    }
    public double Albedo
        {
            get { return this._Albedo; }
            set { this._Albedo= value; } 
        }
    public double AirTemperatureMinimum
        {
            get { return this._AirTemperatureMinimum; }
            set { this._AirTemperatureMinimum= value; } 
        }
    public double WaterEquivalentOfSnowPack
        {
            get { return this._WaterEquivalentOfSnowPack; }
            set { this._WaterEquivalentOfSnowPack= value; } 
        }
    public double GlobalSolarRadiation
        {
            get { return this._GlobalSolarRadiation; }
            set { this._GlobalSolarRadiation= value; } 
        }
    public double AirTemperatureMaximum
        {
            get { return this._AirTemperatureMaximum; }
            set { this._AirTemperatureMaximum= value; } 
        }
}