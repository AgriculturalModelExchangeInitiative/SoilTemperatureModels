import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class STEMP_EPIC_Exogenous
{
    private Double RAIN;
    private Double DEPIR;
    private Double TMIN;
    private Double BIOMAS;
    private Double TAMP;
    private Double MULCHMASS;
    private Double TMAX;
    private Double TAV;
    private Double SNOW;
    private Double TAVG;
    
    public STEMP_EPIC_Exogenous() { }
    
    public STEMP_EPIC_Exogenous(STEMP_EPIC_Exogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.RAIN = toCopy.getRAIN();
            this.DEPIR = toCopy.getDEPIR();
            this.TMIN = toCopy.getTMIN();
            this.BIOMAS = toCopy.getBIOMAS();
            this.TAMP = toCopy.getTAMP();
            this.MULCHMASS = toCopy.getMULCHMASS();
            this.TMAX = toCopy.getTMAX();
            this.TAV = toCopy.getTAV();
            this.SNOW = toCopy.getSNOW();
            this.TAVG = toCopy.getTAVG();
        }
    }
    public Double getRAIN()
    { return RAIN; }

    public void setRAIN(Double _RAIN)
    { this.RAIN= _RAIN; } 
    
    public Double getDEPIR()
    { return DEPIR; }

    public void setDEPIR(Double _DEPIR)
    { this.DEPIR= _DEPIR; } 
    
    public Double getTMIN()
    { return TMIN; }

    public void setTMIN(Double _TMIN)
    { this.TMIN= _TMIN; } 
    
    public Double getBIOMAS()
    { return BIOMAS; }

    public void setBIOMAS(Double _BIOMAS)
    { this.BIOMAS= _BIOMAS; } 
    
    public Double getTAMP()
    { return TAMP; }

    public void setTAMP(Double _TAMP)
    { this.TAMP= _TAMP; } 
    
    public Double getMULCHMASS()
    { return MULCHMASS; }

    public void setMULCHMASS(Double _MULCHMASS)
    { this.MULCHMASS= _MULCHMASS; } 
    
    public Double getTMAX()
    { return TMAX; }

    public void setTMAX(Double _TMAX)
    { this.TMAX= _TMAX; } 
    
    public Double getTAV()
    { return TAV; }

    public void setTAV(Double _TAV)
    { this.TAV= _TAV; } 
    
    public Double getSNOW()
    { return SNOW; }

    public void setSNOW(Double _SNOW)
    { this.SNOW= _SNOW; } 
    
    public Double getTAVG()
    { return TAVG; }

    public void setTAVG(Double _TAVG)
    { this.TAVG= _TAVG; } 
    
}