using System;
using System.Collections.Generic;

public class STEMP_EPIC_Exogenous 
{
    private double _SNOW;
    private double _TMAX;
    private double _BIOMAS;
    private double _TAV;
    private double _TMIN;
    private double _TAMP;
    private double _RAIN;
    private double _TAVG;
    private double _DEPIR;
    private double _MULCHMASS;
    
        public STEMP_EPIC_Exogenous() { }
    
    
    public STEMP_EPIC_Exogenous(STEMP_EPIC_Exogenous toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _SNOW = toCopy._SNOW;
    _TMAX = toCopy._TMAX;
    _BIOMAS = toCopy._BIOMAS;
    _TAV = toCopy._TAV;
    _TMIN = toCopy._TMIN;
    _TAMP = toCopy._TAMP;
    _RAIN = toCopy._RAIN;
    _TAVG = toCopy._TAVG;
    _DEPIR = toCopy._DEPIR;
    _MULCHMASS = toCopy._MULCHMASS;
    }
    }
    public double SNOW
        {
            get { return this._SNOW; }
            set { this._SNOW= value; } 
        }
    public double TMAX
        {
            get { return this._TMAX; }
            set { this._TMAX= value; } 
        }
    public double BIOMAS
        {
            get { return this._BIOMAS; }
            set { this._BIOMAS= value; } 
        }
    public double TAV
        {
            get { return this._TAV; }
            set { this._TAV= value; } 
        }
    public double TMIN
        {
            get { return this._TMIN; }
            set { this._TMIN= value; } 
        }
    public double TAMP
        {
            get { return this._TAMP; }
            set { this._TAMP= value; } 
        }
    public double RAIN
        {
            get { return this._RAIN; }
            set { this._RAIN= value; } 
        }
    public double TAVG
        {
            get { return this._TAVG; }
            set { this._TAVG= value; } 
        }
    public double DEPIR
        {
            get { return this._DEPIR; }
            set { this._DEPIR= value; } 
        }
    public double MULCHMASS
        {
            get { return this._MULCHMASS; }
            set { this._MULCHMASS= value; } 
        }
}