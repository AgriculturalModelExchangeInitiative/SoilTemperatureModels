using System;
using System.Collections.Generic;

public class SoilTemperatureRate 
{
    private double _heatFlux;
    
        public SoilTemperatureRate() { }
    
    
    public SoilTemperatureRate(SoilTemperatureRate toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    heatFlux = toCopy.heatFlux;
    }
    }
    public double heatFlux
        {
            get { return this._heatFlux; }
            set { this._heatFlux= value; } 
        }
}