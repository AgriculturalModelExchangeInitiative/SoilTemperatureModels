import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class STEMP_Exogenous
{
    private double TMAX;
    private double SRAD;
    private double TAMP;
    private double TAVG;
    private double TAV;
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
    public double getTMAX()
    { return TMAX; }

    public void setTMAX(double _TMAX)
    { this.TMAX= _TMAX; } 
    
    public double getSRAD()
    { return SRAD; }

    public void setSRAD(double _SRAD)
    { this.SRAD= _SRAD; } 
    
    public double getTAMP()
    { return TAMP; }

    public void setTAMP(double _TAMP)
    { this.TAMP= _TAMP; } 
    
    public double getTAVG()
    { return TAVG; }

    public void setTAVG(double _TAVG)
    { this.TAVG= _TAVG; } 
    
    public double getTAV()
    { return TAV; }

    public void setTAV(double _TAV)
    { this.TAV= _TAV; } 
    
    public Integer getDOY()
    { return DOY; }

    public void setDOY(Integer _DOY)
    { this.DOY= _DOY; } 
    
}