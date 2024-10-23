using System;
using System.Collections.Generic;

public class SurfacePartonSoilSWATHourlyPartonCExogenous 
{
    private double _AirTemperatureMinimum;
    private double _DayLength;
    private double _GlobalSolarRadiation;
    private double _AirTemperatureMaximum;
    private double[] _VolumetricWaterContent;
    private double _HourOfSunset;
    private double _HourOfSunrise;
    
        public SurfacePartonSoilSWATHourlyPartonCExogenous() { }
    
    
    public SurfacePartonSoilSWATHourlyPartonCExogenous(SurfacePartonSoilSWATHourlyPartonCExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    AirTemperatureMinimum = toCopy.AirTemperatureMinimum;
    DayLength = toCopy.DayLength;
    GlobalSolarRadiation = toCopy.GlobalSolarRadiation;
    AirTemperatureMaximum = toCopy.AirTemperatureMaximum;
    VolumetricWaterContent = new double[toCopy.VolumetricWaterContent.Length];
            for (int i = 0; i < toCopy.VolumetricWaterContent.Length; i++)
            { VolumetricWaterContent[i] = toCopy.VolumetricWaterContent[i]; }
    
    HourOfSunset = toCopy.HourOfSunset;
    HourOfSunrise = toCopy.HourOfSunrise;
    }
    }
    public double AirTemperatureMinimum
        {
            get { return this._AirTemperatureMinimum; }
            set { this._AirTemperatureMinimum= value; } 
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
    public double HourOfSunset
        {
            get { return this._HourOfSunset; }
            set { this._HourOfSunset= value; } 
        }
    public double HourOfSunrise
        {
            get { return this._HourOfSunrise; }
            set { this._HourOfSunrise= value; } 
        }
}