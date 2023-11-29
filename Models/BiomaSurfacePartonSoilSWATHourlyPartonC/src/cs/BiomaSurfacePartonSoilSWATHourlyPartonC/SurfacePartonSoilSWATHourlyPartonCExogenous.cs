using System;
using System.Collections.Generic;

public class SurfacePartonSoilSWATHourlyPartonCExogenous 
{
    private double _AirTemperatureMaximum;
    private double _GlobalSolarRadiation;
    private double _AirTemperatureMinimum;
    private double _DayLength;
    private double _HourOfSunrise;
    private double _HourOfSunset;
    
        public SurfacePartonSoilSWATHourlyPartonCExogenous() { }
    
    
    public SurfacePartonSoilSWATHourlyPartonCExogenous(SurfacePartonSoilSWATHourlyPartonCExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    AirTemperatureMaximum = toCopy.AirTemperatureMaximum;
    GlobalSolarRadiation = toCopy.GlobalSolarRadiation;
    AirTemperatureMinimum = toCopy.AirTemperatureMinimum;
    DayLength = toCopy.DayLength;
    HourOfSunrise = toCopy.HourOfSunrise;
    HourOfSunset = toCopy.HourOfSunset;
    }
    }
    public double AirTemperatureMaximum
        {
            get { return this._AirTemperatureMaximum; }
            set { this._AirTemperatureMaximum= value; } 
        }
    public double GlobalSolarRadiation
        {
            get { return this._GlobalSolarRadiation; }
            set { this._GlobalSolarRadiation= value; } 
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
    public double HourOfSunrise
        {
            get { return this._HourOfSunrise; }
            set { this._HourOfSunrise= value; } 
        }
    public double HourOfSunset
        {
            get { return this._HourOfSunset; }
            set { this._HourOfSunset= value; } 
        }
}