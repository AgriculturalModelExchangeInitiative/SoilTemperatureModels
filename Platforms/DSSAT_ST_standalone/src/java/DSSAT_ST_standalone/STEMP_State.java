import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class STEMP_State
{
    private Double [] DSMID;
    private Double [] ST;
    private Double CUMDPT;
    private Double [] TMA;
    private Double SRFTEMP;
    private Double ATOT;
    
    public STEMP_State() { }
    
    public STEMP_State(STEMP_State toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
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
            this.CUMDPT = toCopy.getCUMDPT();
            TMA = new Double[toCopy.getTMA().length];
        for (int i = 0; i < toCopy.getTMA().length; i++)
        {
            TMA[i] = toCopy.getTMA()[i];
        }
            this.SRFTEMP = toCopy.getSRFTEMP();
            this.ATOT = toCopy.getATOT();
        }
    }
    public Double [] getDSMID()
    { return DSMID; }

    public void setDSMID(Double [] _DSMID)
    { this.DSMID= _DSMID; } 
    
    public Double [] getST()
    { return ST; }

    public void setST(Double [] _ST)
    { this.ST= _ST; } 
    
    public Double getCUMDPT()
    { return CUMDPT; }

    public void setCUMDPT(Double _CUMDPT)
    { this.CUMDPT= _CUMDPT; } 
    
    public Double [] getTMA()
    { return TMA; }

    public void setTMA(Double [] _TMA)
    { this.TMA= _TMA; } 
    
    public Double getSRFTEMP()
    { return SRFTEMP; }

    public void setSRFTEMP(Double _SRFTEMP)
    { this.SRFTEMP= _SRFTEMP; } 
    
    public Double getATOT()
    { return ATOT; }

    public void setATOT(Double _ATOT)
    { this.ATOT= _ATOT; } 
    
}