using System;
using System.Collections.Generic;

public class STEMP_Exogenous 
{
    private double _TMAX;
    private double _SRAD;
    private double _TAMP;
    private double _TAVG;
    private double _TAV;
    private int _DOY;
    
        public STEMP_Exogenous() { }
    
    
    public STEMP_Exogenous(STEMP_Exogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    TMAX = toCopy.TMAX;
    SRAD = toCopy.SRAD;
    TAMP = toCopy.TAMP;
    TAVG = toCopy.TAVG;
    TAV = toCopy.TAV;
    DOY = toCopy.DOY;
    }
    }
    public double TMAX
        {
            get { return this._TMAX; }
            set { this._TMAX= value; } 
        }
    public double SRAD
        {
            get { return this._SRAD; }
            set { this._SRAD= value; } 
        }
    public double TAMP
        {
            get { return this._TAMP; }
            set { this._TAMP= value; } 
        }
    public double TAVG
        {
            get { return this._TAVG; }
            set { this._TAVG= value; } 
        }
    public double TAV
        {
            get { return this._TAV; }
            set { this._TAV= value; } 
        }
    public int DOY
        {
            get { return this._DOY; }
            set { this._DOY= value; } 
        }
}