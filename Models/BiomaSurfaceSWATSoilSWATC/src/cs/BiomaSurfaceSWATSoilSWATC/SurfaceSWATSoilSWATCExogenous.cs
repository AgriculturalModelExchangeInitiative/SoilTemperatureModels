using System;
using System.Collections.Generic;

public class SurfaceSWATSoilSWATCExogenous 
{
    private double _AirTemperatureMinimum;
    private double _GlobalSolarRadiation;
    private double _WaterEquivalentOfSnowPack;
    private double _AirTemperatureMaximum;
    private double _Albedo;
    private double _AirTemperatureAnnualAverage;
    
        public SurfaceSWATSoilSWATCExogenous() { }
    
    
    public SurfaceSWATSoilSWATCExogenous(SurfaceSWATSoilSWATCExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _AirTemperatureMinimum = toCopy._AirTemperatureMinimum;
    _GlobalSolarRadiation = toCopy._GlobalSolarRadiation;
    _WaterEquivalentOfSnowPack = toCopy._WaterEquivalentOfSnowPack;
    _AirTemperatureMaximum = toCopy._AirTemperatureMaximum;
    _Albedo = toCopy._Albedo;
    _AirTemperatureAnnualAverage = toCopy._AirTemperatureAnnualAverage;
    }
    }
    public double AirTemperatureMinimum
        {
            get { return this._AirTemperatureMinimum; }
            set { this._AirTemperatureMinimum= value; } 
        }
    public double GlobalSolarRadiation
        {
            get { return this._GlobalSolarRadiation; }
            set { this._GlobalSolarRadiation= value; } 
        }
    public double WaterEquivalentOfSnowPack
        {
            get { return this._WaterEquivalentOfSnowPack; }
            set { this._WaterEquivalentOfSnowPack= value; } 
        }
    public double AirTemperatureMaximum
        {
            get { return this._AirTemperatureMaximum; }
            set { this._AirTemperatureMaximum= value; } 
        }
    public double Albedo
        {
            get { return this._Albedo; }
            set { this._Albedo= value; } 
        }
    public double AirTemperatureAnnualAverage
        {
            get { return this._AirTemperatureAnnualAverage; }
            set { this._AirTemperatureAnnualAverage= value; } 
        }
}