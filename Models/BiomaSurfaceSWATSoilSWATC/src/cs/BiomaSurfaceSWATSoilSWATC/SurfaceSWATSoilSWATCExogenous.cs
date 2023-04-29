using System;
using System.Collections.Generic;

public class SurfaceSWATSoilSWATCExogenous 
{
    private double _GlobalSolarRadiation;
    private double _AirTemperatureMaximum;
    private double _AirTemperatureMinimum;
    private double _Albedo;
    private double _WaterEquivalentOfSnowPack;
    private double _AirTemperatureAnnualAverage;
    
        public SurfaceSWATSoilSWATCExogenous() { }
    
    
    public SurfaceSWATSoilSWATCExogenous(SurfaceSWATSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _GlobalSolarRadiation = toCopy._GlobalSolarRadiation;
    _AirTemperatureMaximum = toCopy._AirTemperatureMaximum;
    _AirTemperatureMinimum = toCopy._AirTemperatureMinimum;
    _Albedo = toCopy._Albedo;
    _WaterEquivalentOfSnowPack = toCopy._WaterEquivalentOfSnowPack;
    _AirTemperatureAnnualAverage = toCopy._AirTemperatureAnnualAverage;
    }
    }
    public double GlobalSolarRadiation
        {
            get { return this._GlobalSolarRadiation; }
            set { this._GlobalSolarRadiation= value; } 
        }
    public double AirTemperatureMaximum
        {
            get { return this._AirTemperatureMaximum; }
            set { this._AirTemperatureMaximum= value; } 
        }
    public double AirTemperatureMinimum
        {
            get { return this._AirTemperatureMinimum; }
            set { this._AirTemperatureMinimum= value; } 
        }
    public double Albedo
        {
            get { return this._Albedo; }
            set { this._Albedo= value; } 
        }
    public double WaterEquivalentOfSnowPack
        {
            get { return this._WaterEquivalentOfSnowPack; }
            set { this._WaterEquivalentOfSnowPack= value; } 
        }
    public double AirTemperatureAnnualAverage
        {
            get { return this._AirTemperatureAnnualAverage; }
            set { this._AirTemperatureAnnualAverage= value; } 
        }
}