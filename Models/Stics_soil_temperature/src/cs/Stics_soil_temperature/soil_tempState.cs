using System;
using System.Collections.Generic;
public class Soil_tempState 
{
    private double[] _prev_temp_profile;
    private double _prev_canopy_temp;
    private double _temp_amp;
    private double[] _temp_profile;
    private double[] _layer_temp;
    private double _canopy_temp_avg;
    
    /// <summary>
    /// Constructor of the soil_tempState component")
    /// </summary>  
    public soil_tempState() { }
    
    
    public soil_tempState(soil_tempState toCopy, bool copyAll) // copy constructor 
    {
        if (copyAll)
        {
    
            prev_temp_profile = new double[toCopy.prev_temp_profile.Length];
            for (int i = 0; i < toCopy.prev_temp_profile.Length; i++)
                { prev_temp_profile[i] = toCopy.prev_temp_profile[i]; }
    
            prev_canopy_temp = toCopy.prev_canopy_temp;
            temp_amp = toCopy.temp_amp;
            temp_profile = new double[toCopy.temp_profile.Length];
            for (int i = 0; i < toCopy.temp_profile.Length; i++)
                { temp_profile[i] = toCopy.temp_profile[i]; }
    
            layer_temp = new double[toCopy.layer_temp.Length];
            for (int i = 0; i < toCopy.layer_temp.Length; i++)
                { layer_temp[i] = toCopy.layer_temp[i]; }
    
            canopy_temp_avg = toCopy.canopy_temp_avg;
        }
    }
    public double[] prev_temp_profile
    {
        get { return this._prev_temp_profile; }
        set { this._prev_temp_profile= value; } 
    }
    public double prev_canopy_temp
    {
        get { return this._prev_canopy_temp; }
        set { this._prev_canopy_temp= value; } 
    }
    public double temp_amp
    {
        get { return this._temp_amp; }
        set { this._temp_amp= value; } 
    }
    public double[] temp_profile
    {
        get { return this._temp_profile; }
        set { this._temp_profile= value; } 
    }
    public double[] layer_temp
    {
        get { return this._layer_temp; }
        set { this._layer_temp= value; } 
    }
    public double canopy_temp_avg
    {
        get { return this._canopy_temp_avg; }
        set { this._canopy_temp_avg= value; } 
    }
}