using System;
using System.Collections.Generic;

public class SurfacePartonSoilSWATHourlyPartonCAuxiliary 
{
    private double _AboveGroundBiomass;
    private double[] _Sand;
    private double[] _OrganicMatter;
    private double _SurfaceSoilTemperature;
    private double _SurfaceTemperatureMinimum;
    private double _SurfaceTemperatureMaximum;
    
        public SurfacePartonSoilSWATHourlyPartonCAuxiliary() { }
    
    
    public SurfacePartonSoilSWATHourlyPartonCAuxiliary(SurfacePartonSoilSWATHourlyPartonCAuxiliary toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    AboveGroundBiomass = toCopy.AboveGroundBiomass;
    Sand = new double[toCopy.Sand.Length];
            for (int i = 0; i < toCopy.Sand.Length; i++)
            { Sand[i] = toCopy.Sand[i]; }
    
    OrganicMatter = new double[toCopy.OrganicMatter.Length];
            for (int i = 0; i < toCopy.OrganicMatter.Length; i++)
            { OrganicMatter[i] = toCopy.OrganicMatter[i]; }
    
    SurfaceSoilTemperature = toCopy.SurfaceSoilTemperature;
    SurfaceTemperatureMinimum = toCopy.SurfaceTemperatureMinimum;
    SurfaceTemperatureMaximum = toCopy.SurfaceTemperatureMaximum;
    }
    }
    public double AboveGroundBiomass
        {
            get { return this._AboveGroundBiomass; }
            set { this._AboveGroundBiomass= value; } 
        }
    public double[] Sand
        {
            get { return this._Sand; }
            set { this._Sand= value; } 
        }
    public double[] OrganicMatter
        {
            get { return this._OrganicMatter; }
            set { this._OrganicMatter= value; } 
        }
    public double SurfaceSoilTemperature
        {
            get { return this._SurfaceSoilTemperature; }
            set { this._SurfaceSoilTemperature= value; } 
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