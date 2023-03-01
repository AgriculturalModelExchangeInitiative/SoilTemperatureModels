using System;
using System.Collections.Generic;
public class STEMP_EPIC_State 
{
    private int _NDays;
    private double _CUMDPT;
    private double _SRFTEMP;
    private int[] _WetDay = new int[30];
    private double _X2_PREV;
    private double[] _TMA = new double[5];
    private double[] _DSMID = new double[NL];
    private double[] _ST = new double[NL];
    
        public STEMP_EPIC_State() { }
    
    
    public STEMP_EPIC_State(STEMP_EPIC_State toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _NDays = toCopy._NDays;
    _CUMDPT = toCopy._CUMDPT;
    _SRFTEMP = toCopy._SRFTEMP;
    WetDay = new int[30];
            for (int i = 0; i < 30; i++)
            { _WetDay[i] = toCopy._WetDay[i]; }
    
    _X2_PREV = toCopy._X2_PREV;
    TMA = new double[5];
            for (int i = 0; i < 5; i++)
            { _TMA[i] = toCopy._TMA[i]; }
    
    DSMID = new double[NL];
            for (int i = 0; i < NL; i++)
            { _DSMID[i] = toCopy._DSMID[i]; }
    
    ST = new double[NL];
            for (int i = 0; i < NL; i++)
            { _ST[i] = toCopy._ST[i]; }
    
    }
    }
    public int NDays
        {
            get { return this._NDays; }
            set { this._NDays= value; } 
        }
    public double CUMDPT
        {
            get { return this._CUMDPT; }
            set { this._CUMDPT= value; } 
        }
    public double SRFTEMP
        {
            get { return this._SRFTEMP; }
            set { this._SRFTEMP= value; } 
        }
    public int[] WetDay
        {
            get { return this._WetDay; }
            set { this._WetDay= value; } 
        }
    public double X2_PREV
        {
            get { return this._X2_PREV; }
            set { this._X2_PREV= value; } 
        }
    public double[] TMA
        {
            get { return this._TMA; }
            set { this._TMA= value; } 
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
}