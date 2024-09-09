import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class campbellExogenous
{
    private double SRAD;
    private double TMIN;
    private Integer DOY;
    private Double [] SW;
    private double EOAD;
    private double ESP;
    private double TAV;
    private double ESAD;
    private double canopyHeight;
    private double TMAX;
    private double ES;
    
    public campbellExogenous() { }
    
    public campbellExogenous(campbellExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.SRAD = toCopy.getSRAD();
            this.TMIN = toCopy.getTMIN();
            this.DOY = toCopy.getDOY();
            SW = new Double[toCopy.getSW().length];
        for (int i = 0; i < toCopy.getSW().length; i++)
        {
            SW[i] = toCopy.getSW()[i];
        }
            this.EOAD = toCopy.getEOAD();
            this.ESP = toCopy.getESP();
            this.TAV = toCopy.getTAV();
            this.ESAD = toCopy.getESAD();
            this.canopyHeight = toCopy.getcanopyHeight();
            this.TMAX = toCopy.getTMAX();
            this.ES = toCopy.getES();
        }
    }
    public double getSRAD()
    { return SRAD; }

    public void setSRAD(double _SRAD)
    { this.SRAD= _SRAD; } 
    
    public double getTMIN()
    { return TMIN; }

    public void setTMIN(double _TMIN)
    { this.TMIN= _TMIN; } 
    
    public Integer getDOY()
    { return DOY; }

    public void setDOY(Integer _DOY)
    { this.DOY= _DOY; } 
    
    public Double [] getSW()
    { return SW; }

    public void setSW(Double [] _SW)
    { this.SW= _SW; } 
    
    public double getEOAD()
    { return EOAD; }

    public void setEOAD(double _EOAD)
    { this.EOAD= _EOAD; } 
    
    public double getESP()
    { return ESP; }

    public void setESP(double _ESP)
    { this.ESP= _ESP; } 
    
    public double getTAV()
    { return TAV; }

    public void setTAV(double _TAV)
    { this.TAV= _TAV; } 
    
    public double getESAD()
    { return ESAD; }

    public void setESAD(double _ESAD)
    { this.ESAD= _ESAD; } 
    
    public double getcanopyHeight()
    { return canopyHeight; }

    public void setcanopyHeight(double _canopyHeight)
    { this.canopyHeight= _canopyHeight; } 
    
    public double getTMAX()
    { return TMAX; }

    public void setTMAX(double _TMAX)
    { this.TMAX= _TMAX; } 
    
    public double getES()
    { return ES; }

    public void setES(double _ES)
    { this.ES= _ES; } 
    
}