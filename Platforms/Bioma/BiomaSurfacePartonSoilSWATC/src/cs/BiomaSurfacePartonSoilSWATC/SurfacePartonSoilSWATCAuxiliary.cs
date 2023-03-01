using System;
using System.Collections.Generic;

public class SurfacePartonSoilSWATCAuxiliary 
{
    private double _SurfaceTemperatureMaximum;
    private double _SurfaceTemperatureMinimum;
    
        public SurfacePartonSoilSWATCAuxiliary() { }
    
    
    public SurfacePartonSoilSWATCAuxiliary(SurfacePartonSoilSWATCAuxiliary toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _SurfaceTemperatureMaximum = toCopy._SurfaceTemperatureMaximum;
    _SurfaceTemperatureMinimum = toCopy._SurfaceTemperatureMinimum;
    }
    }
    public double SurfaceTemperatureMaximum
        {
            get { return this._SurfaceTemperatureMaximum; }
            set { this._SurfaceTemperatureMaximum= value; } 
        }
    public double SurfaceTemperatureMinimum
        {
            get { return this._SurfaceTemperatureMinimum; }
            set { this._SurfaceTemperatureMinimum= value; } 
        }
}