using System;
using System.Collections.Generic;

public class SoilTemperatureExogenous 
{
    private double _meanTAir;
    private double _minTAir;
    private double _meanAnnualAirTemp;
    private double _maxTAir;
    private double _dayLength;
    
        public SoilTemperatureExogenous() { }
    
    
    public SoilTemperatureExogenous(SoilTemperatureExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    meanTAir = toCopy.meanTAir;
    minTAir = toCopy.minTAir;
    meanAnnualAirTemp = toCopy.meanAnnualAirTemp;
    maxTAir = toCopy.maxTAir;
    dayLength = toCopy.dayLength;
    }
    }
    public double meanTAir
        {
            get { return this._meanTAir; }
            set { this._meanTAir= value; } 
        }
    public double minTAir
        {
            get { return this._minTAir; }
            set { this._minTAir= value; } 
        }
    public double meanAnnualAirTemp
        {
            get { return this._meanAnnualAirTemp; }
            set { this._meanAnnualAirTemp= value; } 
        }
    public double maxTAir
        {
            get { return this._maxTAir; }
            set { this._maxTAir= value; } 
        }
    public double dayLength
        {
            get { return this._dayLength; }
            set { this._dayLength= value; } 
        }
}