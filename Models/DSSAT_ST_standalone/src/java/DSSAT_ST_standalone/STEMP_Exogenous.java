import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class STEMP_Exogenous
{
    private Double TMAX;
    private Double SRAD;
    private Double TAMP;
    private Double TAVG;
    private Double TAV;
    private Integer DOY;
    
    public STEMP_Exogenous() { }
    
    public STEMP_Exogenous(STEMP_Exogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.TMAX = toCopy.getTMAX();
            this.SRAD = toCopy.getSRAD();
            this.TAMP = toCopy.getTAMP();
            this.TAVG = toCopy.getTAVG();
            this.TAV = toCopy.getTAV();
            this.DOY = toCopy.getDOY();
        }
    }
    public Double getTMAX()
    { return TMAX; }

    public void setTMAX(Double _TMAX)
    { this.TMAX= _TMAX; } 
    
    public Double getSRAD()
    { return SRAD; }

    public void setSRAD(Double _SRAD)
    { this.SRAD= _SRAD; } 
    
    public Double getTAMP()
    { return TAMP; }

    public void setTAMP(Double _TAMP)
    { this.TAMP= _TAMP; } 
    
    public Double getTAVG()
    { return TAVG; }

    public void setTAVG(Double _TAVG)
    { this.TAVG= _TAVG; } 
    
    public Double getTAV()
    { return TAV; }

    public void setTAV(Double _TAV)
    { this.TAV= _TAV; } 
    
    public Integer getDOY()
    { return DOY; }

    public void setDOY(Integer _DOY)
    { this.DOY= _DOY; } 
    
}