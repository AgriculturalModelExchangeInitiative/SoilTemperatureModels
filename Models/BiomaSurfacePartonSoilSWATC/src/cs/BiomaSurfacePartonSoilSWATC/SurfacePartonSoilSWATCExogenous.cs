using System;
using System.Collections.Generic;

public class SurfacePartonSoilSWATCExogenous 
{
    private double _DayLength;
    private double _AboveGroundBiomass;
    private double _AirTemperatureMaximum;
    private double _GlobalSolarRadiation;
    private double _AirTemperatureMinimum;
    
        public SurfacePartonSoilSWATCExogenous() { }
    
    
    public SurfacePartonSoilSWATCExogenous(SurfacePartonSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    DayLength = toCopy.DayLength;
    AboveGroundBiomass = toCopy.AboveGroundBiomass;
    AirTemperatureMaximum = toCopy.AirTemperatureMaximum;
    GlobalSolarRadiation = toCopy.GlobalSolarRadiation;
    AirTemperatureMinimum = toCopy.AirTemperatureMinimum;
    }
    }
    public double DayLength
        {
            get { return this._DayLength; }
            set { this._DayLength= value; } 
        }
    public double AboveGroundBiomass
        {
            get { return this._AboveGroundBiomass; }
            set { this._AboveGroundBiomass= value; } 
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
}