import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SoilTemperatureExogenous
{
    private Double meanTAir;
    private Double minTAir;
    private Double maxTAir;
    private Double dayLength;
    
    public SoilTemperatureExogenous() { }
    
    public SoilTemperatureExogenous(SoilTemperatureExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.meanTAir = toCopy.getmeanTAir();
            this.minTAir = toCopy.getminTAir();
            this.maxTAir = toCopy.getmaxTAir();
            this.dayLength = toCopy.getdayLength();
        }
    }
    public Double getmeanTAir()
    { return meanTAir; }

    public void setmeanTAir(Double _meanTAir)
    { this.meanTAir= _meanTAir; } 
    
    public Double getminTAir()
    { return minTAir; }

    public void setminTAir(Double _minTAir)
    { this.minTAir= _minTAir; } 
    
    public Double getmaxTAir()
    { return maxTAir; }

    public void setmaxTAir(Double _maxTAir)
    { this.maxTAir= _maxTAir; } 
    
    public Double getdayLength()
    { return dayLength; }

    public void setdayLength(Double _dayLength)
    { this.dayLength= _dayLength; } 
    
}