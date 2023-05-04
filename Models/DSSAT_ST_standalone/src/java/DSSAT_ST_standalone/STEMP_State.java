import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class STEMP_State
{
    private Double SRFTEMP;
    private Double HDAY;
    private Double [] TMA;
    private Double CUMDPT;
    private Double ATOT;
    private Double TDL;
    private Double [] DSMID;
    private Double [] ST;
    
    public STEMP_State() { }
    
    public STEMP_State(STEMP_State toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.SRFTEMP = toCopy.getSRFTEMP();
            this.HDAY = toCopy.getHDAY();
            TMA = new Double[5];
        for (int i = 0; i < 5; i++)
        {
            TMA[i] = toCopy.getTMA()[i];
        }
            this.CUMDPT = toCopy.getCUMDPT();
            this.ATOT = toCopy.getATOT();
            this.TDL = toCopy.getTDL();
            DSMID = new Double[toCopy.getDSMID().length];
        for (int i = 0; i < toCopy.getDSMID().length; i++)
        {
            DSMID[i] = toCopy.getDSMID()[i];
        }
            ST = new Double[toCopy.getST().length];
        for (int i = 0; i < toCopy.getST().length; i++)
        {
            ST[i] = toCopy.getST()[i];
        }
        }
    }
    public Double getSRFTEMP()
    { return SRFTEMP; }

    public void setSRFTEMP(Double _SRFTEMP)
    { this.SRFTEMP= _SRFTEMP; } 
    
    public Double getHDAY()
    { return HDAY; }

    public void setHDAY(Double _HDAY)
    { this.HDAY= _HDAY; } 
    
    public Double [] getTMA()
    { return TMA; }

    public void setTMA(Double [] _TMA)
    { this.TMA= _TMA; } 
    
    public Double getCUMDPT()
    { return CUMDPT; }

    public void setCUMDPT(Double _CUMDPT)
    { this.CUMDPT= _CUMDPT; } 
    
    public Double getATOT()
    { return ATOT; }

    public void setATOT(Double _ATOT)
    { this.ATOT= _ATOT; } 
    
    public Double getTDL()
    { return TDL; }

    public void setTDL(Double _TDL)
    { this.TDL= _TDL; } 
    
    public Double [] getDSMID()
    { return DSMID; }

    public void setDSMID(Double [] _DSMID)
    { this.DSMID= _DSMID; } 
    
    public Double [] getST()
    { return ST; }

    public void setST(Double [] _ST)
    { this.ST= _ST; } 
    
}