using System;
using System.Collections.Generic;

public class soil_tempAuxiliary 
{
    private double _temp_wave_freq;
    private double _therm_diff;
    
        public soil_tempAuxiliary() { }
    
    
    public soil_tempAuxiliary(soil_tempAuxiliary toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    temp_wave_freq = toCopy.temp_wave_freq;
    therm_diff = toCopy.therm_diff;
    }
    }
    public double temp_wave_freq
        {
            get { return this._temp_wave_freq; }
            set { this._temp_wave_freq= value; } 
        }
    public double therm_diff
        {
            get { return this._therm_diff; }
            set { this._therm_diff= value; } 
        }
}