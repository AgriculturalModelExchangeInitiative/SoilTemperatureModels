public class STEMP_EPIC_Component
{
    
    public STEMP_EPIC_Component() { }

    STEMP_EPIC _STEMP_EPIC = new STEMP_EPIC();

    public Double [] getDLAYR()
    { return _Stemp_epic.getDLAYR(); }
    public void setDLAYR(Double [] DLAYR)
    { _Stemp_epic.setDLAYR(DLAYR); } 

    public Double [] getSW()
    { return _Stemp_epic.getSW(); }
    public void setSW(Double [] SW)
    { _Stemp_epic.setSW(SW); } 

    public Double [] getBD()
    { return _Stemp_epic.getBD(); }
    public void setBD(Double [] BD)
    { _Stemp_epic.setBD(BD); } 

    public String getISWWAT()
    { return _Stemp_epic.getISWWAT(); }
    public void setISWWAT(String ISWWAT)
    { _Stemp_epic.setISWWAT(ISWWAT); } 

    public Double [] getDS()
    { return _Stemp_epic.getDS(); }
    public void setDS(Double [] DS)
    { _Stemp_epic.setDS(DS); } 

    public Double [] getDUL()
    { return _Stemp_epic.getDUL(); }
    public void setDUL(Double [] DUL)
    { _Stemp_epic.setDUL(DUL); } 

    public Double [] getLL()
    { return _Stemp_epic.getLL(); }
    public void setLL(Double [] LL)
    { _Stemp_epic.setLL(LL); } 

    public Integer getNL()
    { return _Stemp_epic.getNL(); }
    public void setNL(Integer NL)
    { _Stemp_epic.setNL(NL); } 

    public Integer getNLAYR()
    { return _Stemp_epic.getNLAYR(); }
    public void setNLAYR(Integer NLAYR)
    { _Stemp_epic.setNLAYR(NLAYR); } 
    public void  Calculate_stemp_epic_(STEMP_EPIC_State s, STEMP_EPIC_State s1, STEMP_EPIC_Rate r, STEMP_EPIC_Auxiliary a, STEMP_EPIC_Exogenous ex)
    {
        _Stemp_epic.Calculate_stemp_epic(s, s1, r, a, ex);
    }
    private Double [] DLAYR;
    private Double [] SW;
    private Double [] BD;
    private String ISWWAT;
    private Double [] DS;
    private Double [] DUL;
    private Double [] LL;
    private Integer NL;
    private Integer NLAYR;
    public STEMP_EPIC_Component(STEMP_EPIC_Component toCopy) // copy constructor 
    {
        
        for (int i = 0; i < toCopy.getDLAYR().length; i++)
        {
            DLAYR[i] = toCopy.getDLAYR()[i];
        }
        
        for (int i = 0; i < toCopy.getSW().length; i++)
        {
            SW[i] = toCopy.getSW()[i];
        }
        
        for (int i = 0; i < toCopy.getBD().length; i++)
        {
            BD[i] = toCopy.getBD()[i];
        }
        this.ISWWAT = toCopy.getISWWAT();
        
        for (int i = 0; i < toCopy.getDS().length; i++)
        {
            DS[i] = toCopy.getDS()[i];
        }
        
        for (int i = 0; i < toCopy.getDUL().length; i++)
        {
            DUL[i] = toCopy.getDUL()[i];
        }
        
        for (int i = 0; i < toCopy.getLL().length; i++)
        {
            LL[i] = toCopy.getLL()[i];
        }
        this.NL = toCopy.getNL();
        this.NLAYR = toCopy.getNLAYR();

    }
}