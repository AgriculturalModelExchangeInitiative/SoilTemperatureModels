using System;
using System.Collections.Generic;

public class SurfacePartonSoilSWATHourlyPartonCExogenous 
{
    private double _GlobalSolarRadiation;
    private double _DayLength;
    private double _AirTemperatureMinimum;
    private double _AirTemperatureMaximum;
    private double _AirTemperatureAnnualAverage;
    private double _HourOfSunrise;
    private double _HourOfSunset;
    
        public SurfacePartonSoilSWATHourlyPartonCExogenous() { }
    
    
    public SurfacePartonSoilSWATHourlyPartonCExogenous(SurfacePartonSoilSWATHourlyPartonCExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _GlobalSolarRadiation = toCopy._GlobalSolarRadiation;
    _DayLength = toCopy._DayLength;
    _AirTemperatureMinimum = toCopy._AirTemperatureMinimum;
    _AirTemperatureMaximum = toCopy._AirTemperatureMaximum;
    _AirTemperatureAnnualAverage = toCopy._AirTemperatureAnnualAverage;
    _HourOfSunrise = toCopy._HourOfSunrise;
    _HourOfSunset = toCopy._HourOfSunset;
    }
    }
    public double GlobalSolarRadiation
        {
            get { return this._GlobalSolarRadiation; }
            set { this._GlobalSolarRadiation= value; } 
        }
    public double DayLength
        {
            get { return this._DayLength; }
            set { this._DayLength= value; } 
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
    public double AirTemperatureAnnualAverage
        {
            get { return this._AirTemperatureAnnualAverage; }
            set { this._AirTemperatureAnnualAverage= value; } 
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