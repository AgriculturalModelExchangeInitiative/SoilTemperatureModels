using System;
using System.Collections.Generic;

public class SurfacePartonSoilSWATCExogenous 
{
    private double _AboveGroundBiomass;
    private double _DayLength;
    private double _AirTemperatureMinimum;
    private double _GlobalSolarRadiation;
    private double _AirTemperatureMaximum;
    
        public SurfacePartonSoilSWATCExogenous() { }
    
    
    public SurfacePartonSoilSWATCExogenous(SurfacePartonSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    AboveGroundBiomass = toCopy.AboveGroundBiomass;
    DayLength = toCopy.DayLength;
    AirTemperatureMinimum = toCopy.AirTemperatureMinimum;
    GlobalSolarRadiation = toCopy.GlobalSolarRadiation;
    AirTemperatureMaximum = toCopy.AirTemperatureMaximum;
    }
    }
    public double AboveGroundBiomass
        {
            get { return this._AboveGroundBiomass; }
            set { this._AboveGroundBiomass= value; } 
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