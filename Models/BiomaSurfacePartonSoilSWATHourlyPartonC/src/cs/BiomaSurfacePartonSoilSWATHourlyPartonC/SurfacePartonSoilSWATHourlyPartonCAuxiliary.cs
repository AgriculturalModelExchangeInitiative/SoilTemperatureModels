using System;
using System.Collections.Generic;

public class SurfacePartonSoilSWATHourlyPartonCAuxiliary 
{
    private double _SurfaceTemperatureMinimum;
    private double _SurfaceTemperatureMaximum;
    
        public SurfacePartonSoilSWATHourlyPartonCAuxiliary() { }
    
    
    public SurfacePartonSoilSWATHourlyPartonCAuxiliary(SurfacePartonSoilSWATHourlyPartonCAuxiliary toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _SurfaceTemperatureMinimum = toCopy._SurfaceTemperatureMinimum;
    _SurfaceTemperatureMaximum = toCopy._SurfaceTemperatureMaximum;
    }
    }
    public double SurfaceTemperatureMinimum
        {
            get { return this._SurfaceTemperatureMinimum; }
            set { this._SurfaceTemperatureMinimum= value; } 
        }
    public double SurfaceTemperatureMaximum
        {
            get { return this._SurfaceTemperatureMaximum; }
            set { this._SurfaceTemperatureMaximum= value; } 
        }
}