using System;
using System.Collections.Generic;

public class soil_tempExogenous 
{
    private double _max_temp;
    private double _min_temp;
    private double _min_air_temp;
    private double _min_canopy_temp;
    private double _max_canopy_temp;
    private double _prev_canopy_temp;
    
        public soil_tempExogenous() { }
    
    
    public soil_tempExogenous(soil_tempExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    max_temp = toCopy.max_temp;
    min_temp = toCopy.min_temp;
    min_air_temp = toCopy.min_air_temp;
    min_canopy_temp = toCopy.min_canopy_temp;
    max_canopy_temp = toCopy.max_canopy_temp;
    prev_canopy_temp = toCopy.prev_canopy_temp;
    }
    }
    public double max_temp
        {
            get { return this._max_temp; }
            set { this._max_temp= value; } 
        }
    public double min_temp
        {
            get { return this._min_temp; }
            set { this._min_temp= value; } 
        }
    public double min_air_temp
        {
            get { return this._min_air_temp; }
            set { this._min_air_temp= value; } 
        }
    public double min_canopy_temp
        {
            get { return this._min_canopy_temp; }
            set { this._min_canopy_temp= value; } 
        }
    public double max_canopy_temp
        {
            get { return this._max_canopy_temp; }
            set { this._max_canopy_temp= value; } 
        }
    public double prev_canopy_temp
        {
            get { return this._prev_canopy_temp; }
            set { this._prev_canopy_temp= value; } 
        }
}