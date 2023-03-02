using System;
using System.Collections.Generic;

public class SoiltempExogenous 
{
    private double _max_temp;
    private double _min_temp;
    private double _prev_canopy_temp;
    private double _min_air_temp;
    
        public SoiltempExogenous() { }
    
    
    public SoiltempExogenous(SoiltempExogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _max_temp = toCopy._max_temp;
    _min_temp = toCopy._min_temp;
    _prev_canopy_temp = toCopy._prev_canopy_temp;
    _min_air_temp = toCopy._min_air_temp;
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
    public double prev_canopy_temp
        {
            get { return this._prev_canopy_temp; }
            set { this._prev_canopy_temp= value; } 
        }
    public double min_air_temp
        {
            get { return this._min_air_temp; }
            set { this._min_air_temp= value; } 
        }
}