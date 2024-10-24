import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class model_SoilTempCampbellExogenous
{
    private Double [] THICK;
    private Double [] BD;
    private Double [] SLCARB;
    private Double [] CLAY;
    private Double [] SLROCK;
    private Double [] SLSILT;
    private Double [] SLSAND;
    private Double [] SW;
    private double T2M;
    private double TMAX;
    private double TMIN;
    private double TAV;
    private Integer DOY;
    private double airPressure;
    private double canopyHeight;
    private double SRAD;
    private double ESP;
    private double ES;
    private double EOAD;
    private double windSpeed;
    
    public model_SoilTempCampbellExogenous() { }
    
    public model_SoilTempCampbellExogenous(model_SoilTempCampbellExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            THICK = new Double[toCopy.getTHICK().length];
        for (int i = 0; i < toCopy.getTHICK().length; i++)
        {
            THICK[i] = toCopy.getTHICK()[i];
        }
            BD = new Double[toCopy.getBD().length];
        for (int i = 0; i < toCopy.getBD().length; i++)
        {
            BD[i] = toCopy.getBD()[i];
        }
            SLCARB = new Double[toCopy.getSLCARB().length];
        for (int i = 0; i < toCopy.getSLCARB().length; i++)
        {
            SLCARB[i] = toCopy.getSLCARB()[i];
        }
            CLAY = new Double[toCopy.getCLAY().length];
        for (int i = 0; i < toCopy.getCLAY().length; i++)
        {
            CLAY[i] = toCopy.getCLAY()[i];
        }
            SLROCK = new Double[toCopy.getSLROCK().length];
        for (int i = 0; i < toCopy.getSLROCK().length; i++)
        {
            SLROCK[i] = toCopy.getSLROCK()[i];
        }
            SLSILT = new Double[toCopy.getSLSILT().length];
        for (int i = 0; i < toCopy.getSLSILT().length; i++)
        {
            SLSILT[i] = toCopy.getSLSILT()[i];
        }
            SLSAND = new Double[toCopy.getSLSAND().length];
        for (int i = 0; i < toCopy.getSLSAND().length; i++)
        {
            SLSAND[i] = toCopy.getSLSAND()[i];
        }
            SW = new Double[toCopy.getSW().length];
        for (int i = 0; i < toCopy.getSW().length; i++)
        {
            SW[i] = toCopy.getSW()[i];
        }
            this.T2M = toCopy.getT2M();
            this.TMAX = toCopy.getTMAX();
            this.TMIN = toCopy.getTMIN();
            this.TAV = toCopy.getTAV();
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
    public Double [] getTHICK()
    { return THICK; }

    public void setTHICK(Double [] _THICK)
    { this.THICK= _THICK; } 
    
    public Double [] getBD()
    { return BD; }

    public void setBD(Double [] _BD)
    { this.BD= _BD; } 
    
    public Double [] getSLCARB()
    { return SLCARB; }

    public void setSLCARB(Double [] _SLCARB)
    { this.SLCARB= _SLCARB; } 
    
    public Double [] getCLAY()
    { return CLAY; }

    public void setCLAY(Double [] _CLAY)
    { this.CLAY= _CLAY; } 
    
    public Double [] getSLROCK()
    { return SLROCK; }

    public void setSLROCK(Double [] _SLROCK)
    { this.SLROCK= _SLROCK; } 
    
    public Double [] getSLSILT()
    { return SLSILT; }

    public void setSLSILT(Double [] _SLSILT)
    { this.SLSILT= _SLSILT; } 
    
    public Double [] getSLSAND()
    { return SLSAND; }

    public void setSLSAND(Double [] _SLSAND)
    { this.SLSAND= _SLSAND; } 
    
    public Double [] getSW()
    { return SW; }

    public void setSW(Double [] _SW)
    { this.SW= _SW; } 
    
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
    
    public double getTAV()
    { return TAV; }

    public void setTAV(double _TAV)
    { this.TAV= _TAV; } 
    
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