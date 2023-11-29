using System;
using System.Collections.Generic;

public class SurfaceSWATSoilSWATCAuxiliary 
{
    private double _AboveGroundBiomass;
    private double[] _VolumetricWaterContent;
    private double _SurfaceSoilTemperature;
    
        public SurfaceSWATSoilSWATCAuxiliary() { }
    
    
    public SurfaceSWATSoilSWATCAuxiliary(SurfaceSWATSoilSWATCAuxiliary toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    AboveGroundBiomass = toCopy.AboveGroundBiomass;
    VolumetricWaterContent = new double[toCopy.VolumetricWaterContent.Length];
            for (int i = 0; i < toCopy.VolumetricWaterContent.Length; i++)
            { VolumetricWaterContent[i] = toCopy.VolumetricWaterContent[i]; }
    
    SurfaceSoilTemperature = toCopy.SurfaceSoilTemperature;
    }
    }
    public double AboveGroundBiomass
        {
            get { return this._AboveGroundBiomass; }
            set { this._AboveGroundBiomass= value; } 
        }
    public double[] VolumetricWaterContent
        {
            get { return this._VolumetricWaterContent; }
            set { this._VolumetricWaterContent= value; } 
        }
    public double SurfaceSoilTemperature
        {
            get { return this._SurfaceSoilTemperature; }
            set { this._SurfaceSoilTemperature= value; } 
        }
}