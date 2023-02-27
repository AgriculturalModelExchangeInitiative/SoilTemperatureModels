import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class STEMP_EPIC_State
{
    private Double [] ST;
    private Integer [] WetDay;
    private Double X2_PREV;
    private Double SRFTEMP;
    private Double [] DSMID;
    private Integer NDays;
    private Double [] TMA;
    private Double CUMDPT;
    private Double TDL;
    
    public STEMP_EPIC_State() { }
    
    public STEMP_EPIC_State(STEMP_EPIC_State toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            ST = new Double[toCopy.getST().length];
        for (int i = 0; i < toCopy.getST().length; i++)
        {
            ST[i] = toCopy.getST()[i];
        }
            WetDay = new Integer[30];
        for (int i = 0; i < 30; i++)
        {
            WetDay[i] = toCopy.getWetDay()[i];
        }
            this.X2_PREV = toCopy.getX2_PREV();
            this.SRFTEMP = toCopy.getSRFTEMP();
            DSMID = new Double[toCopy.getDSMID().length];
        for (int i = 0; i < toCopy.getDSMID().length; i++)
        {
            DSMID[i] = toCopy.getDSMID()[i];
        }
            this.NDays = toCopy.getNDays();
            TMA = new Double[5];
        for (int i = 0; i < 5; i++)
        {
            TMA[i] = toCopy.getTMA()[i];
        }
            this.CUMDPT = toCopy.getCUMDPT();
            this.TDL = toCopy.getTDL();
        }
    }
    public Double [] getST()
    { return ST; }

    public void setST(Double [] _ST)
    { this.ST= _ST; } 
    
    public Integer [] getWetDay()
    { return WetDay; }

    public void setWetDay(Integer [] _WetDay)
    { this.WetDay= _WetDay; } 
    
    public Double getX2_PREV()
    { return X2_PREV; }

    public void setX2_PREV(Double _X2_PREV)
    { this.X2_PREV= _X2_PREV; } 
    
    public Double getSRFTEMP()
    { return SRFTEMP; }

    public void setSRFTEMP(Double _SRFTEMP)
    { this.SRFTEMP= _SRFTEMP; } 
    
    public Double [] getDSMID()
    { return DSMID; }

    public void setDSMID(Double [] _DSMID)
    { this.DSMID= _DSMID; } 
    
    public Integer getNDays()
    { return NDays; }

    public void setNDays(Integer _NDays)
    { this.NDays= _NDays; } 
    
    public Double [] getTMA()
    { return TMA; }

    public void setTMA(Double [] _TMA)
    { this.TMA= _TMA; } 
    
    public Double getCUMDPT()
    { return CUMDPT; }

    public void setCUMDPT(Double _CUMDPT)
    { this.CUMDPT= _CUMDPT; } 
    
    public Double getTDL()
    { return TDL; }

    public void setTDL(Double _TDL)
    { this.TDL= _TDL; } 
    
}