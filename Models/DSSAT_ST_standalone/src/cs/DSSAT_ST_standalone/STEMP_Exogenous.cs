using System;
using System.Collections.Generic;

public class STEMP_Exogenous 
{
    private double _TAMP;
    private double _SRAD;
    private double _TAV;
    private double _TMAX;
    private double _TAVG;
    private int _DOY;
    
        public STEMP_Exogenous() { }
    
    
    public STEMP_Exogenous(STEMP_Exogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    TAMP = toCopy.TAMP;
    SRAD = toCopy.SRAD;
    TAV = toCopy.TAV;
    TMAX = toCopy.TMAX;
    TAVG = toCopy.TAVG;
    DOY = toCopy.DOY;
    }
    }
    public double TAMP
        {
            get { return this._TAMP; }
            set { this._TAMP= value; } 
        }
    public double SRAD
        {
            get { return this._SRAD; }
            set { this._SRAD= value; } 
        }
    public double TAV
        {
            get { return this._TAV; }
            set { this._TAV= value; } 
        }
    public double TMAX
        {
            get { return this._TMAX; }
            set { this._TMAX= value; } 
        }
    public double TAVG
        {
            get { return this._TAVG; }
            set { this._TAVG= value; } 
        }
    public int DOY
        {
            get { return this._DOY; }
            set { this._DOY= value; } 
        }
}