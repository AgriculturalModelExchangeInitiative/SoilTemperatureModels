import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class STEMP_Exogenous
{
    private Double TAVG;
    private Double TMAX;
    private Double TAV;
    private Double TAMP;
    private Integer DOY;
    private Double SRAD;
    
    public STEMP_Exogenous() { }
    
    public STEMP_Exogenous(STEMP_Exogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.TAVG = toCopy.getTAVG();
            this.TMAX = toCopy.getTMAX();
            this.TAV = toCopy.getTAV();
            this.TAMP = toCopy.getTAMP();
            this.DOY = toCopy.getDOY();
            this.SRAD = toCopy.getSRAD();
        }
    }
    public Double getTAVG()
    { return TAVG; }

    public void setTAVG(Double _TAVG)
    { this.TAVG= _TAVG; } 
    
    public Double getTMAX()
    { return TMAX; }

    public void setTMAX(Double _TMAX)
    { this.TMAX= _TMAX; } 
    
    public Double getTAV()
    { return TAV; }

    public void setTAV(Double _TAV)
    { this.TAV= _TAV; } 
    
    public Double getTAMP()
    { return TAMP; }

    public void setTAMP(Double _TAMP)
    { this.TAMP= _TAMP; } 
    
    public Integer getDOY()
    { return DOY; }

    public void setDOY(Integer _DOY)
    { this.DOY= _DOY; } 
    
    public Double getSRAD()
    { return SRAD; }

    public void setSRAD(Double _SRAD)
    { this.SRAD= _SRAD; } 
    
}