public class STEMP_Component
{
    
    public STEMP_Component() { }

    STEMP _STEMP = new STEMP();

    public Double getMSALB()
    { return _STEMP.getMSALB(); }
    public void setMSALB(Double _MSALB){
    _STEMP.setMSALB(_MSALB);
    }

    public Integer getNL()
    { return _STEMP.getNL(); }
    public void setNL(Integer _NL){
    _STEMP.setNL(_NL);
    }

    public Double [] getLL()
    { return _STEMP.getLL(); }
    public void setLL(Double [] _LL){
    _STEMP.setLL(_LL);
    }

    public Integer getNLAYR()
    { return _STEMP.getNLAYR(); }
    public void setNLAYR(Integer _NLAYR){
    _STEMP.setNLAYR(_NLAYR);
    }

    public Double [] getDS()
    { return _STEMP.getDS(); }
    public void setDS(Double [] _DS){
    _STEMP.setDS(_DS);
    }

    public Double [] getDLAYR()
    { return _STEMP.getDLAYR(); }
    public void setDLAYR(Double [] _DLAYR){
    _STEMP.setDLAYR(_DLAYR);
    }

    public String getISWWAT()
    { return _STEMP.getISWWAT(); }
    public void setISWWAT(String _ISWWAT){
    _STEMP.setISWWAT(_ISWWAT);
    }

    public Double [] getBD()
    { return _STEMP.getBD(); }
    public void setBD(Double [] _BD){
    _STEMP.setBD(_BD);
    }

    public Double [] getSW()
    { return _STEMP.getSW(); }
    public void setSW(Double [] _SW){
    _STEMP.setSW(_SW);
    }

    public Double getXLAT()
    { return _STEMP.getXLAT(); }
    public void setXLAT(Double _XLAT){
    _STEMP.setXLAT(_XLAT);
    }

    public Double [] getDUL()
    { return _STEMP.getDUL(); }
    public void setDUL(Double [] _DUL){
    _STEMP.setDUL(_DUL);
    }
    public void  Calculate_Model(STEMP_State s, STEMP_State s1, STEMP_Rate r, STEMP_Auxiliary a, STEMP_Exogenous ex)
    {
        _STEMP.Calculate_Model(s, s1, r, a, ex);
    }
    private Double MSALB;
    private Integer NL;
    private Double [] LL;
    private Integer NLAYR;
    private Double [] DS;
    private Double [] DLAYR;
    private String ISWWAT;
    private Double [] BD;
    private Double [] SW;
    private Double XLAT;
    private Double [] DUL;
    public STEMP_Component(STEMP_Component toCopy) // copy constructor 
    {
        this.MSALB = toCopy.getMSALB();
        this.NL = toCopy.getNL();
        
        for (int i = 0; i < toCopy.getLL().length; i++)
        {
            LL[i] = toCopy.getLL()[i];
        }
        this.NLAYR = toCopy.getNLAYR();
        
        for (int i = 0; i < toCopy.getDS().length; i++)
        {
            DS[i] = toCopy.getDS()[i];
        }
        
        for (int i = 0; i < toCopy.getDLAYR().length; i++)
        {
            DLAYR[i] = toCopy.getDLAYR()[i];
        }
        this.ISWWAT = toCopy.getISWWAT();
        
        for (int i = 0; i < toCopy.getBD().length; i++)
        {
            BD[i] = toCopy.getBD()[i];
        }
        
        for (int i = 0; i < toCopy.getSW().length; i++)
        {
            SW[i] = toCopy.getSW()[i];
        }
        this.XLAT = toCopy.getXLAT();
        
        for (int i = 0; i < toCopy.getDUL().length; i++)
        {
            DUL[i] = toCopy.getDUL()[i];
        }

    }
}