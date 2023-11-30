using System;
using System.Collections.Generic;

public class SurfaceSWATSoilSWATCExogenous 
{
    private double _AirTemperatureMaximum;
    private double _AirTemperatureMinimum;
    private double _GlobalSolarRadiation;
    private double _WaterEquivalentOfSnowPack;
    private double _Albedo;
    private double[] _VolumetricWaterContent;
    
        public SurfaceSWATSoilSWATCExogenous() { }
    
    
    public SurfaceSWATSoilSWATCExogenous(SurfaceSWATSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    AirTemperatureMaximum = toCopy.AirTemperatureMaximum;
    AirTemperatureMinimum = toCopy.AirTemperatureMinimum;
    GlobalSolarRadiation = toCopy.GlobalSolarRadiation;
    WaterEquivalentOfSnowPack = toCopy.WaterEquivalentOfSnowPack;
    Albedo = toCopy.Albedo;
    VolumetricWaterContent = new double[toCopy.VolumetricWaterContent.Length];
            for (int i = 0; i < toCopy.VolumetricWaterContent.Length; i++)
            { VolumetricWaterContent[i] = toCopy.VolumetricWaterContent[i]; }
    
    }
    }
    public double AirTemperatureMaximum
        {
            get { return this._AirTemperatureMaximum; }
            set { this._AirTemperatureMaximum= value; } 
        }
    public double AirTemperatureMinimum
        {
            get { return this._AirTemperatureMinimum; }
            set { this._AirTemperatureMinimum= value; } 
        }
    public double GlobalSolarRadiation
        {
            get { return this._GlobalSolarRadiation; }
            set { this._GlobalSolarRadiation= value; } 
        }
    public double WaterEquivalentOfSnowPack
        {
            get { return this._WaterEquivalentOfSnowPack; }
            set { this._WaterEquivalentOfSnowPack= value; } 
        }
    public double Albedo
        {
            get { return this._Albedo; }
            set { this._Albedo= value; } 
        }
    public double[] VolumetricWaterContent
        {
            get { return this._VolumetricWaterContent; }
            set { this._VolumetricWaterContent= value; } 
        }
}