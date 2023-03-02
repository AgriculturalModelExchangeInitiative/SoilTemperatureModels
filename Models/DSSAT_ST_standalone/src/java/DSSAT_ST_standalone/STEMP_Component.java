public class STEMP_Component
{
    
    public STEMP_Component() { }

    STEMP _STEMP = new STEMP();

    public Double [] getDLAYR()
    { return _Stemp.getDLAYR(); }
    public void setDLAYR(Double [] DLAYR)
    { _Stemp.setDLAYR(DLAYR); } 

    public Double [] getSW()
    { return _Stemp.getSW(); }
    public void setSW(Double [] SW)
    { _Stemp.setSW(SW); } 

    public Integer getNLAYR()
    { return _Stemp.getNLAYR(); }
    public void setNLAYR(Integer NLAYR)
    { _Stemp.setNLAYR(NLAYR); } 

    public Double [] getLL()
    { return _Stemp.getLL(); }
    public void setLL(Double [] LL)
    { _Stemp.setLL(LL); } 

    public String getISWWAT()
    { return _Stemp.getISWWAT(); }
    public void setISWWAT(String ISWWAT)
    { _Stemp.setISWWAT(ISWWAT); } 

    public Double [] getDUL()
    { return _Stemp.getDUL(); }
    public void setDUL(Double [] DUL)
    { _Stemp.setDUL(DUL); } 

    public Double [] getBD()
    { return _Stemp.getBD(); }
    public void setBD(Double [] BD)
    { _Stemp.setBD(BD); } 

    public Double [] getDS()
    { return _Stemp.getDS(); }
    public void setDS(Double [] DS)
    { _Stemp.setDS(DS); } 

    public Integer getNL()
    { return _Stemp.getNL(); }
    public void setNL(Integer NL)
    { _Stemp.setNL(NL); } 

    public Double getXLAT()
    { return _Stemp.getXLAT(); }
    public void setXLAT(Double XLAT)
    { _Stemp.setXLAT(XLAT); } 

    public Double getMSALB()
    { return _Stemp.getMSALB(); }
    public void setMSALB(Double MSALB)
    { _Stemp.setMSALB(MSALB); } 
    public void  Calculate_stemp_(STEMP_State s, STEMP_State s1, STEMP_Rate r, STEMP_Auxiliary a, STEMP_Exogenous ex)
    {
        _Stemp.Calculate_stemp(s, s1, r, a, ex);
    }
    private Double [] DLAYR;
    private Double [] SW;
    private Integer NLAYR;
    private Double [] LL;
    private String ISWWAT;
    private Double [] DUL;
    private Double [] BD;
    private Double [] DS;
    private Integer NL;
    private Double XLAT;
    private Double MSALB;
    public STEMP_Component(STEMP_Component toCopy) // copy constructor 
    {
        
        for (int i = 0; i < toCopy.getDLAYR().length; i++)
        {
            DLAYR[i] = toCopy.getDLAYR()[i];
        }
        
        for (int i = 0; i < toCopy.getSW().length; i++)
        {
            SW[i] = toCopy.getSW()[i];
        }
        this.NLAYR = toCopy.getNLAYR();
        
        for (int i = 0; i < toCopy.getLL().length; i++)
        {
            LL[i] = toCopy.getLL()[i];
        }
        this.ISWWAT = toCopy.getISWWAT();
        
        for (int i = 0; i < toCopy.getDUL().length; i++)
        {
            DUL[i] = toCopy.getDUL()[i];
        }
        
        for (int i = 0; i < toCopy.getBD().length; i++)
        {
            BD[i] = toCopy.getBD()[i];
        }
        
        for (int i = 0; i < toCopy.getDS().length; i++)
        {
            DS[i] = toCopy.getDS()[i];
        }
        this.NL = toCopy.getNL();
        this.XLAT = toCopy.getXLAT();
        this.MSALB = toCopy.getMSALB();

    }
}