using System;
using System.Collections.Generic;

public class SoiltempAuxiliary 
{
    private double _therm_diff;
    private double _temp_wave_freq;
    
        public SoiltempAuxiliary() { }
    
    
    public SoiltempAuxiliary(SoiltempAuxiliary toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _therm_diff = toCopy._therm_diff;
    _temp_wave_freq = toCopy._temp_wave_freq;
    }
    }
    public double therm_diff
        {
            get { return this._therm_diff; }
            set { this._therm_diff= value; } 
        }
    public double temp_wave_freq
        {
            get { return this._temp_wave_freq; }
            set { this._temp_wave_freq= value; } 
        }
}