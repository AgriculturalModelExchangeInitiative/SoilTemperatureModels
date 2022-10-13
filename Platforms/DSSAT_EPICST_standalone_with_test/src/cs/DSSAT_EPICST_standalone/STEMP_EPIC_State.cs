using System;
using System.Collections.Generic;
public class STEMP_EPIC_State 
{
    private double _CUMDPT;
    private double[] _DSMID = new double[NL];
    private double[] _TMA = new double[5];
    private int _NDays;
    private int[] _WetDay = new int[30];
    private double _TDL;
    private double[] _ST = new double[NL];
    private double _X2_PREV;
    private double _SRFTEMP;
    
        public STEMP_EPIC_State() { }
    
    
    public STEMP_EPIC_State(STEMP_EPIC_State toCopy, bool copyAll) // copy constructor 
    {
    if (copyAll)
    {
    
    _CUMDPT = toCopy._CUMDPT;
    DSMID = new double[NL];
            for (int i = 0; i < NL; i++)
            { _DSMID[i] = toCopy._DSMID[i]; }
    
    TMA = new double[5];
            for (int i = 0; i < 5; i++)
            { _TMA[i] = toCopy._TMA[i]; }
    
    _NDays = toCopy._NDays;
    WetDay = new int[30];
            for (int i = 0; i < 30; i++)
            { _WetDay[i] = toCopy._WetDay[i]; }
    
    _TDL = toCopy._TDL;
    ST = new double[NL];
            for (int i = 0; i < NL; i++)
            { _ST[i] = toCopy._ST[i]; }
    
    _X2_PREV = toCopy._X2_PREV;
    _SRFTEMP = toCopy._SRFTEMP;
    }
    }
    public double CUMDPT
        {
            get { return this._CUMDPT; }
            set { this._CUMDPT= value; } 
        }
    public double[] DSMID
        {
            get { return this._DSMID; }
            set { this._DSMID= value; } 
        }
    public double[] TMA
        {
            get { return this._TMA; }
            set { this._TMA= value; } 
        }
    public int NDays
        {
            get { return this._NDays; }
            set { this._NDays= value; } 
        }
    public int[] WetDay
        {
            get { return this._WetDay; }
            set { this._WetDay= value; } 
        }
    public double TDL
        {
            get { return this._TDL; }
            set { this._TDL= value; } 
        }
    public double[] ST
        {
            get { return this._ST; }
            set { this._ST= value; } 
        }
    public double X2_PREV
        {
            get { return this._X2_PREV; }
            set { this._X2_PREV= value; } 
        }
    public double SRFTEMP
        {
            get { return this._SRFTEMP; }
            set { this._SRFTEMP= value; } 
        }
}