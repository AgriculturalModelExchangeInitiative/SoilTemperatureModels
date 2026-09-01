import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class STEMP_State
{
    private double HDAY;
    private double SRFTEMP;
    private Double [] ST;
    private Double [] TMA;
    private double TDL;
    private double CUMDPT;
    private double ATOT;
    private Double [] DSMID;
    
    public STEMP_State() { }
    
    public STEMP_State(STEMP_State toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.HDAY = toCopy.getHDAY();
            this.SRFTEMP = toCopy.getSRFTEMP();
            ST = new Double[toCopy.getST().length];
        for (int i = 0; i < toCopy.getST().length; i++)
        {
            ST[i] = toCopy.getST()[i];
        }
            TMA = new Double[5];
        for (int i = 0; i < 5; i++)
        {
            TMA[i] = toCopy.getTMA()[i];
        }
            this.TDL = toCopy.getTDL();
            this.CUMDPT = toCopy.getCUMDPT();
            this.ATOT = toCopy.getATOT();
            DSMID = new Double[toCopy.getDSMID().length];
        for (int i = 0; i < toCopy.getDSMID().length; i++)
        {
            DSMID[i] = toCopy.getDSMID()[i];
        }
        }
    }
    public double getHDAY()
    { return HDAY; }

    public void setHDAY(double _HDAY)
    { this.HDAY= _HDAY; } 
    
    public double getSRFTEMP()
    { return SRFTEMP; }

    public void setSRFTEMP(double _SRFTEMP)
    { this.SRFTEMP= _SRFTEMP; } 
    
    public Double [] getST()
    { return ST; }

    public void setST(Double [] _ST)
    { this.ST= _ST; } 
    
    public Double [] getTMA()
    { return TMA; }

    public void setTMA(Double [] _TMA)
    { this.TMA= _TMA; } 
    
    public double getTDL()
    { return TDL; }

    public void setTDL(double _TDL)
    { this.TDL= _TDL; } 
    
    public double getCUMDPT()
    { return CUMDPT; }

    public void setCUMDPT(double _CUMDPT)
    { this.CUMDPT= _CUMDPT; } 
    
    public double getATOT()
    { return ATOT; }

    public void setATOT(double _ATOT)
    { this.ATOT= _ATOT; } 
    
    public Double [] getDSMID()
    { return DSMID; }

    public void setDSMID(Double [] _DSMID)
    { this.DSMID= _DSMID; } 
    
}