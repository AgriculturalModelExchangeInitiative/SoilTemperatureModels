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

        double MSALB;
    int NL;
    double[] LL =  new double [100];
    int NLAYR;
    double[] DS =  new double [100];
    double[] DLAYR =  new double [100];
    string ISWWAT;
    double[] BD =  new double [100];
    double[] SW =  new double [100];
    double XLAT;
    double[] DUL =  new double [100];

    public double SRFTEMP{ get { return s.SRFTEMP;}} 
     
    public double[] ST{ get { return s.ST;}} 
     
    public double[] TMA{ get { return s.TMA;}} 
     
    public double TDL{ get { return s.TDL;}} 
     
    public double CUMDPT{ get { return s.CUMDPT;}} 
     
    public double ATOT{ get { return s.ATOT;}} 
     
    public double[] DSMID{ get { return s.DSMID;}} 
     

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
        setExogenous();
        loadParameters();
        stemp_Component.Init(s, s1, r, a, ex);
    }

    private void loadParameters()
    {
        stemp_Component.MSALB = null; // To be modified
        stemp_Component.NL = null; // To be modified
        stemp_Component.LL = null; // To be modified
        stemp_Component.NLAYR = null; // To be modified
        stemp_Component.DS = null; // To be modified
        stemp_Component.DLAYR = null; // To be modified
        stemp_Component.ISWWAT = 'Y'
        stemp_Component.BD = null; // To be modified
        stemp_Component.SW = null; // To be modified
        stemp_Component.XLAT = null; // To be modified
        stemp_Component.DUL = null; // To be modified
    }

    private void setExogenous()
    {
        ex.TMAX = null; // To be modified
        ex.SRAD = null; // To be modified
        ex.TAMP = null; // To be modified
        ex.TAVG = null; // To be modified
        ex.TAV = null; // To be modified
        ex.DOY = null; // To be modified
    }

    public void EstimateSTEMP_(double TMAX, double SRAD, double TAMP, double TAVG, double TAV, int DOY)
    {
        ex.TMAX = TMAX;
        ex.SRAD = SRAD;
        ex.TAMP = TAMP;
        ex.TAVG = TAVG;
        ex.TAV = TAV;
        ex.DOY = DOY;
        stemp_Component.CalculateModel(s,s1, r, a, ex);
    }

}