using System;
using System.Collections.Generic;
using System.Linq;
class STEMP_Wrapper
{
    private STEMP_State s;
    private STEMP_State s1;
    private STEMP_Rate r;
    private STEMP_Auxiliary a;
    private STEMP_Exogenous ex;
    private STEMP_Component stemp_Component;

    public STEMP_Wrapper()
    {
        s = new STEMP_State();
        r = new STEMP_Rate();
        a = new STEMP_Auxiliary();
        ex = new STEMP_Exogenous();
        stemp_Component = new STEMP_Component();
        loadParameters();
    }

        double XLAT;
    string ISWWAT;
    int NLAYR;
    double[] DUL =  new double [100];
    double[] DS =  new double [100];
    double[] LL =  new double [100];
    double[] BD =  new double [100];
    double MSALB;
    int NL;
    double[] DLAYR =  new double [100];
    double[] SW =  new double [100];

    public double SRFTEMP{ get { return s.SRFTEMP;}} 
     
    public double[] TMA{ get { return s.TMA;}} 
     
    public double CUMDPT{ get { return s.CUMDPT;}} 
     
    public double ATOT{ get { return s.ATOT;}} 
     
    public double TDL{ get { return s.TDL;}} 
     
    public double[] DSMID{ get { return s.DSMID;}} 
     
    public double[] ST{ get { return s.ST;}} 
     

    public STEMP_Wrapper(STEMP_Wrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new STEMP_State(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new STEMP_Rate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new STEMP_Auxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new STEMP_Exogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            stemp_Component = (toCopy.stemp_Component != null) ? new STEMP_Component(toCopy.stemp_Component) : null;
        }
    }

    public void Init(){
        stemp_Component.Init(s, r, a);
        loadParameters();
    }

    private void loadParameters()
    {
        stemp_Component.XLAT = XLAT;
        stemp_Component.ISWWAT = ISWWAT;
        stemp_Component.NLAYR = NLAYR;
        stemp_Component.DUL = DUL;
        stemp_Component.DS = DS;
        stemp_Component.LL = LL;
        stemp_Component.BD = BD;
        stemp_Component.MSALB = MSALB;
        stemp_Component.NL = NL;
        stemp_Component.DLAYR = DLAYR;
        stemp_Component.SW = SW;
    }

    public void EstimateSTEMP_(double TAMP, double SRAD, double TAV, double TMAX, double TAVG, int DOY)
    {
        a.TAMP = TAMP;
        a.SRAD = SRAD;
        a.TAV = TAV;
        a.TMAX = TMAX;
        a.TAVG = TAVG;
        a.DOY = DOY;
        stemp_Component.CalculateModel(s,s1, r, a, ex);
    }

}