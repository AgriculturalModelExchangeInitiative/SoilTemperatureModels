import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SoilTemperatureCompExogenous
{
    private Double tmin;
    private Double tmax;
    private Double globrad;
    private Double soilCoverage;
    private Double soilSurfaceTemperatureBelowSnow;
    private Boolean hasSnowCover;
    
    public SoilTemperatureCompExogenous() { }
    
    public SoilTemperatureCompExogenous(SoilTemperatureCompExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.tmin = toCopy.gettmin();
            this.tmax = toCopy.gettmax();
            this.globrad = toCopy.getglobrad();
            this.soilCoverage = toCopy.getsoilCoverage();
            this.soilSurfaceTemperatureBelowSnow = toCopy.getsoilSurfaceTemperatureBelowSnow();
            this.hasSnowCover = toCopy.gethasSnowCover();
        }
    }
    public Double gettmin()
    { return tmin; }

    public void settmin(Double _tmin)
    { this.tmin= _tmin; } 
    
    public Double gettmax()
    { return tmax; }

    public void settmax(Double _tmax)
    { this.tmax= _tmax; } 
    
    public Double getglobrad()
    { return globrad; }

    public void setglobrad(Double _globrad)
    { this.globrad= _globrad; } 
    
    public Double getsoilCoverage()
    { return soilCoverage; }

    public void setsoilCoverage(Double _soilCoverage)
    { this.soilCoverage= _soilCoverage; } 
    
    public Double getsoilSurfaceTemperatureBelowSnow()
    { return soilSurfaceTemperatureBelowSnow; }

    public void setsoilSurfaceTemperatureBelowSnow(Double _soilSurfaceTemperatureBelowSnow)
    { this.soilSurfaceTemperatureBelowSnow= _soilSurfaceTemperatureBelowSnow; } 
    
    public Boolean gethasSnowCover()
    { return hasSnowCover; }

    public void sethasSnowCover(Boolean _hasSnowCover)
    { this.hasSnowCover= _hasSnowCover; } 
    
}