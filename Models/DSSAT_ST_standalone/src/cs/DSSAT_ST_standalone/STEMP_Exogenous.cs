using System;
using System.Collections.Generic;

public class STEMP_Exogenous 
{
    private double _TAVG;
    private double _TMAX;
    private double _TAV;
    private double _TAMP;
    private int _DOY;
    private double _SRAD;
    
        public STEMP_Exogenous() { }
    
    
    public STEMP_Exogenous(STEMP_Exogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _TAVG = toCopy._TAVG;
    _TMAX = toCopy._TMAX;
    _TAV = toCopy._TAV;
    _TAMP = toCopy._TAMP;
    _DOY = toCopy._DOY;
    _SRAD = toCopy._SRAD;
    }
    }
    public double TAVG
        {
            get { return this._TAVG; }
            set { this._TAVG= value; } 
        }
    public double TMAX
        {
            get { return this._TMAX; }
            set { this._TMAX= value; } 
        }
    public double TAV
        {
            get { return this._TAV; }
            set { this._TAV= value; } 
        }
    public double TAMP
        {
            get { return this._TAMP; }
            set { this._TAMP= value; } 
        }
    public int DOY
        {
            get { return this._DOY; }
            set { this._DOY= value; } 
        }
    public double SRAD
        {
            get { return this._SRAD; }
            set { this._SRAD= value; } 
        }
}