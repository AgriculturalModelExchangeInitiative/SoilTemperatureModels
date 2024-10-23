using System;
using System.Collections.Generic;
public class STEMP_State 
{
    private double _HDAY;
    private double _SRFTEMP;
    private double[] _ST = new double[NL];
    private double[] _TMA = new double[5];
    private double _TDL;
    private double _CUMDPT;
    private double _ATOT;
    private double[] _DSMID = new double[NL];
    
        public STEMP_State() { }
    
    
    public STEMP_State(STEMP_State toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    HDAY = toCopy.HDAY;
    SRFTEMP = toCopy.SRFTEMP;
    ST = new double[NL];
            for (int i = 0; i < NL; i++)
            { ST[i] = toCopy.ST[i]; }
    
    TMA = new double[5];
            for (int i = 0; i < 5; i++)
            { TMA[i] = toCopy.TMA[i]; }
    
    TDL = toCopy.TDL;
    CUMDPT = toCopy.CUMDPT;
    ATOT = toCopy.ATOT;
    DSMID = new double[NL];
            for (int i = 0; i < NL; i++)
            { DSMID[i] = toCopy.DSMID[i]; }
    
    }
    }
    public double HDAY
        {
            get { return this._HDAY; }
            set { this._HDAY= value; } 
        }
    public double SRFTEMP
        {
            get { return this._SRFTEMP; }
            set { this._SRFTEMP= value; } 
        }
    public double[] ST
        {
            get { return this._ST; }
            set { this._ST= value; } 
        }
    public double[] TMA
        {
            get { return this._TMA; }
            set { this._TMA= value; } 
        }
    public double TDL
        {
            get { return this._TDL; }
            set { this._TDL= value; } 
        }
    public double CUMDPT
        {
            get { return this._CUMDPT; }
            set { this._CUMDPT= value; } 
        }
    public double ATOT
        {
            get { return this._ATOT; }
            set { this._ATOT= value; } 
        }
    public double[] DSMID
        {
            get { return this._DSMID; }
            set { this._DSMID= value; } 
        }
}