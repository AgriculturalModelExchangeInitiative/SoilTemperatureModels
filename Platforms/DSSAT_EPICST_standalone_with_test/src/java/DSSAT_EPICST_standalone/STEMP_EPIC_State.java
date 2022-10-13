import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class STEMP_EPIC_State
{
    private Double CUMDPT;
    private Double [] DSMID;
    private Double [] TMA;
    private Integer NDays;
    private Integer [] WetDay;
    private Double TDL;
    private Double [] ST;
    private Double X2_PREV;
    private Double SRFTEMP;
    
    public STEMP_EPIC_State() { }
    
    public STEMP_EPIC_State(STEMP_EPIC_State toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.CUMDPT = toCopy.getCUMDPT();
            DSMID = new Double[toCopy.getDSMID().length];
        for (int i = 0; i < toCopy.getDSMID().length; i++)
        {
            DSMID[i] = toCopy.getDSMID()[i];
        }
            TMA = new Double[5];
        for (int i = 0; i < 5; i++)
        {
            TMA[i] = toCopy.getTMA()[i];
        }
            this.NDays = toCopy.getNDays();
            WetDay = new Integer[30];
        for (int i = 0; i < 30; i++)
        {
            WetDay[i] = toCopy.getWetDay()[i];
        }
            this.TDL = toCopy.getTDL();
            ST = new Double[toCopy.getST().length];
        for (int i = 0; i < toCopy.getST().length; i++)
        {
            ST[i] = toCopy.getST()[i];
        }
            this.X2_PREV = toCopy.getX2_PREV();
            this.SRFTEMP = toCopy.getSRFTEMP();
        }
    }
    public Double getCUMDPT()
    { return CUMDPT; }

    public void setCUMDPT(Double _CUMDPT)
    { this.CUMDPT= _CUMDPT; } 
    
    public Double [] getDSMID()
    { return DSMID; }

    public void setDSMID(Double [] _DSMID)
    { this.DSMID= _DSMID; } 
    
    public Double [] getTMA()
    { return TMA; }

    public void setTMA(Double [] _TMA)
    { this.TMA= _TMA; } 
    
    public Integer getNDays()
    { return NDays; }

    public void setNDays(Integer _NDays)
    { this.NDays= _NDays; } 
    
    public Integer [] getWetDay()
    { return WetDay; }

    public void setWetDay(Integer [] _WetDay)
    { this.WetDay= _WetDay; } 
    
    public Double getTDL()
    { return TDL; }

    public void setTDL(Double _TDL)
    { this.TDL= _TDL; } 
    
    public Double [] getST()
    { return ST; }

    public void setST(Double [] _ST)
    { this.ST= _ST; } 
    
    public Double getX2_PREV()
    { return X2_PREV; }

    public void setX2_PREV(Double _X2_PREV)
    { this.X2_PREV= _X2_PREV; } 
    
    public Double getSRFTEMP()
    { return SRFTEMP; }

    public void setSRFTEMP(Double _SRFTEMP)
    { this.SRFTEMP= _SRFTEMP; } 
    
}