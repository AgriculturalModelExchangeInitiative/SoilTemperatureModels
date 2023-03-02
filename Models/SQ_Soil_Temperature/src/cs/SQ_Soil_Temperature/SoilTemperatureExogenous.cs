using System;
using System.Collections.Generic;

public class SoilTemperatureExogenous 
{
    private double _meanTAir;
    private double _minTAir;
    private double _maxTAir;
    private double _dayLength;
    
        public SoilTemperatureExogenous() { }
    
    
    public SoilTemperatureExogenous(SoilTemperatureExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _meanTAir = toCopy._meanTAir;
    _minTAir = toCopy._minTAir;
    _maxTAir = toCopy._maxTAir;
    _dayLength = toCopy._dayLength;
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