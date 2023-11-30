using System;
using System.Collections.Generic;

public class SurfacePartonSoilSWATCAuxiliary 
{
    private double _SurfaceTemperatureMinimum;
    private double _SurfaceTemperatureMaximum;
    private double _SurfaceSoilTemperature;
    
        public SurfacePartonSoilSWATCAuxiliary() { }
    
    
    public SurfacePartonSoilSWATCAuxiliary(SurfacePartonSoilSWATCAuxiliary toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    SurfaceTemperatureMinimum = toCopy.SurfaceTemperatureMinimum;
    SurfaceTemperatureMaximum = toCopy.SurfaceTemperatureMaximum;
    SurfaceSoilTemperature = toCopy.SurfaceSoilTemperature;
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
    public double SurfaceSoilTemperature
        {
            get { return this._SurfaceSoilTemperature; }
            set { this._SurfaceSoilTemperature= value; } 
        }
}