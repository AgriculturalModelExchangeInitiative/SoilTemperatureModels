using System;
using System.Collections.Generic;

public class SurfacePartonSoilSWATCExogenous 
{
    private double _GlobalSolarRadiation;
    private double _AirTemperatureMinimum;
    private double _DayLength;
    private double _AirTemperatureMaximum;
    private double _AirTemperatureAnnualAverage;
    
        public SurfacePartonSoilSWATCExogenous() { }
    
    
    public SurfacePartonSoilSWATCExogenous(SurfacePartonSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _GlobalSolarRadiation = toCopy._GlobalSolarRadiation;
    _AirTemperatureMinimum = toCopy._AirTemperatureMinimum;
    _DayLength = toCopy._DayLength;
    _AirTemperatureMaximum = toCopy._AirTemperatureMaximum;
    _AirTemperatureAnnualAverage = toCopy._AirTemperatureAnnualAverage;
    }
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
}