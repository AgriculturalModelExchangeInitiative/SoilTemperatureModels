using System;
using System.Collections.Generic;

public class SurfaceSWATSoilSWATCAuxiliary 
{
    private double _AboveGroundBiomass;
    private double _SurfaceSoilTemperature;
    
        public SurfaceSWATSoilSWATCAuxiliary() { }
    
    
    public SurfaceSWATSoilSWATCAuxiliary(SurfaceSWATSoilSWATCAuxiliary toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    AboveGroundBiomass = toCopy.AboveGroundBiomass;
    SurfaceSoilTemperature = toCopy.SurfaceSoilTemperature;
    }
    }
    public double AboveGroundBiomass
        {
            get { return this._AboveGroundBiomass; }
            set { this._AboveGroundBiomass= value; } 
        }
    public double SurfaceSoilTemperature
        {
            get { return this._SurfaceSoilTemperature; }
            set { this._SurfaceSoilTemperature= value; } 
        }
}