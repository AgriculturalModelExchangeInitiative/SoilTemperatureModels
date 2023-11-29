using System;
using System.Collections.Generic;

public class SurfacePartonSoilSWATCAuxiliary 
{
    private double[] _VolumetricWaterContent;
    private double _SurfaceTemperatureMinimum;
    private double _SurfaceTemperatureMaximum;
    private double _SurfaceSoilTemperature;
    
        public SurfacePartonSoilSWATCAuxiliary() { }
    
    
    public SurfacePartonSoilSWATCAuxiliary(SurfacePartonSoilSWATCAuxiliary toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    VolumetricWaterContent = new double[toCopy.VolumetricWaterContent.Length];
            for (int i = 0; i < toCopy.VolumetricWaterContent.Length; i++)
            { VolumetricWaterContent[i] = toCopy.VolumetricWaterContent[i]; }
    
    SurfaceTemperatureMinimum = toCopy.SurfaceTemperatureMinimum;
    SurfaceTemperatureMaximum = toCopy.SurfaceTemperatureMaximum;
    SurfaceSoilTemperature = toCopy.SurfaceSoilTemperature;
    }
    }
    public double[] VolumetricWaterContent
        {
            get { return this._VolumetricWaterContent; }
            set { this._VolumetricWaterContent= value; } 
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