using System;
using System.Collections.Generic;
public class STEMP_State 
{
    private double[] _DSMID = new double[NL];
    private double[] _ST = new double[NL];
    private double _CUMDPT;
    private double[] _TMA = new double[NL];
    private double _SRFTEMP;
    private double _ATOT;
    
        public STEMP_State() { }
    
    
    public STEMP_State(STEMP_State toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    DSMID = new double[NL];
            for (int i = 0; i < NL; i++)
            { _DSMID[i] = toCopy._DSMID[i]; }
    
    ST = new double[NL];
            for (int i = 0; i < NL; i++)
            { _ST[i] = toCopy._ST[i]; }
    
    _CUMDPT = toCopy._CUMDPT;
    TMA = new double[NL];
            for (int i = 0; i < NL; i++)
            { _TMA[i] = toCopy._TMA[i]; }
    
    _SRFTEMP = toCopy._SRFTEMP;
    _ATOT = toCopy._ATOT;
    }
    }
    public double[] DSMID
        {
            get { return this._DSMID; }
            set { this._DSMID= value; } 
        }
    public double[] ST
        {
            get { return this._ST; }
            set { this._ST= value; } 
        }
    public double CUMDPT
        {
            get { return this._CUMDPT; }
            set { this._CUMDPT= value; } 
        }
    public double[] TMA
        {
            get { return this._TMA; }
            set { this._TMA= value; } 
        }
    public double SRFTEMP
        {
            get { return this._SRFTEMP; }
            set { this._SRFTEMP= value; } 
        }
    public double ATOT
        {
            get { return this._ATOT; }
            set { this._ATOT= value; } 
        }
}