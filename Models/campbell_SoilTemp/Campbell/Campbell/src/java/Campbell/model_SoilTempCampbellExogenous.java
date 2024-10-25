import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class Model_SoilTempCampbellExogenous
{
    private double T2M;
    private double TMAX;
    private double TMIN;
    private Integer DOY;
    private double airPressure;
    private double canopyHeight;
    private double SRAD;
    private double ESP;
    private double ES;
    private double EOAD;
    private double windSpeed;
    
    public Model_SoilTempCampbellExogenous() { }
    
    public Model_SoilTempCampbellExogenous(Model_SoilTempCampbellExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.T2M = toCopy.getT2M();
            this.TMAX = toCopy.getTMAX();
            this.TMIN = toCopy.getTMIN();
            this.DOY = toCopy.getDOY();
            this.airPressure = toCopy.getairPressure();
            this.canopyHeight = toCopy.getcanopyHeight();
            this.SRAD = toCopy.getSRAD();
            this.ESP = toCopy.getESP();
            this.ES = toCopy.getES();
            this.EOAD = toCopy.getEOAD();
            this.windSpeed = toCopy.getwindSpeed();
        }
    }
    public double getT2M()
    { return T2M; }

    public void setT2M(double _T2M)
    { this.T2M= _T2M; } 
    
    public double getTMAX()
    { return TMAX; }

    public void setTMAX(double _TMAX)
    { this.TMAX= _TMAX; } 
    
    public double getTMIN()
    { return TMIN; }

    public void setTMIN(double _TMIN)
    { this.TMIN= _TMIN; } 
    
    public Integer getDOY()
    { return DOY; }

    public void setDOY(Integer _DOY)
    { this.DOY= _DOY; } 
    
    public double getairPressure()
    { return airPressure; }

    public void setairPressure(double _airPressure)
    { this.airPressure= _airPressure; } 
    
    public double getcanopyHeight()
    { return canopyHeight; }

    public void setcanopyHeight(double _canopyHeight)
    { this.canopyHeight= _canopyHeight; } 
    
    public double getSRAD()
    { return SRAD; }

    public void setSRAD(double _SRAD)
    { this.SRAD= _SRAD; } 
    
    public double getESP()
    { return ESP; }

    public void setESP(double _ESP)
    { this.ESP= _ESP; } 
    
    public double getES()
    { return ES; }

    public void setES(double _ES)
    { this.ES= _ES; } 
    
    public double getEOAD()
    { return EOAD; }

    public void setEOAD(double _EOAD)
    { this.EOAD= _EOAD; } 
    
    public double getwindSpeed()
    { return windSpeed; }

    public void setwindSpeed(double _windSpeed)
    { this.windSpeed= _windSpeed; } 
    
}