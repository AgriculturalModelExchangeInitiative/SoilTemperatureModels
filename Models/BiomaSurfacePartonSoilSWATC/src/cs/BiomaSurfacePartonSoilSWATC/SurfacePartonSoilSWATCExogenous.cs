using System;
using System.Collections.Generic;

public class SurfacePartonSoilSWATCExogenous 
{
    private double _DayLength;
    private double _GlobalSolarRadiation;
    private double _AboveGroundBiomass;
    private double _AirTemperatureMinimum;
    private double _AirTemperatureMaximum;
    private double[] _VolumetricWaterContent;
    
        public SurfacePartonSoilSWATCExogenous() { }
    
    
    public SurfacePartonSoilSWATCExogenous(SurfacePartonSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    DayLength = toCopy.DayLength;
    GlobalSolarRadiation = toCopy.GlobalSolarRadiation;
    AboveGroundBiomass = toCopy.AboveGroundBiomass;
    AirTemperatureMinimum = toCopy.AirTemperatureMinimum;
    AirTemperatureMaximum = toCopy.AirTemperatureMaximum;
    VolumetricWaterContent = new double[toCopy.VolumetricWaterContent.Length];
            for (int i = 0; i < toCopy.VolumetricWaterContent.Length; i++)
            { VolumetricWaterContent[i] = toCopy.VolumetricWaterContent[i]; }
    
    }
    }
    public double DayLength
        {
            get { return this._DayLength; }
            set { this._DayLength= value; } 
        }
    public double GlobalSolarRadiation
        {
            get { return this._GlobalSolarRadiation; }
            set { this._GlobalSolarRadiation= value; } 
        }
    public double AboveGroundBiomass
        {
            get { return this._AboveGroundBiomass; }
            set { this._AboveGroundBiomass= value; } 
        }
    public double AirTemperatureMinimum
        {
            get { return this._AirTemperatureMinimum; }
            set { this._AirTemperatureMinimum= value; } 
        }
    public double AirTemperatureMaximum
        {
            get { return this._AirTemperatureMaximum; }
            set { this._AirTemperatureMaximum= value; } 
        }
    public double[] VolumetricWaterContent
        {
            get { return this._VolumetricWaterContent; }
            set { this._VolumetricWaterContent= value; } 
        }
}