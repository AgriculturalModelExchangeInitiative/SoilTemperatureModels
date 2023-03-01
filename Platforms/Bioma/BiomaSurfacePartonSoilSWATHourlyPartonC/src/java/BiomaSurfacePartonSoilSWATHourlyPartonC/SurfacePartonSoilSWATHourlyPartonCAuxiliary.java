import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfacePartonSoilSWATHourlyPartonCAuxiliary
{
    private Double SurfaceTemperatureMaximum;
    private Double SurfaceTemperatureMinimum;
    private Double SurfaceTemperatureMaximum;
    private Double SurfaceTemperatureMinimum;
    
    public SurfacePartonSoilSWATHourlyPartonCAuxiliary() { }
    
    public SurfacePartonSoilSWATHourlyPartonCAuxiliary(SurfacePartonSoilSWATHourlyPartonCAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.SurfaceTemperatureMaximum = toCopy.getSurfaceTemperatureMaximum();
            this.SurfaceTemperatureMinimum = toCopy.getSurfaceTemperatureMinimum();
            this.SurfaceTemperatureMaximum = toCopy.getSurfaceTemperatureMaximum();
            this.SurfaceTemperatureMinimum = toCopy.getSurfaceTemperatureMinimum();
        }
    }
    public Double getSurfaceTemperatureMaximum()
    { return SurfaceTemperatureMaximum; }

    public void setSurfaceTemperatureMaximum(Double _SurfaceTemperatureMaximum)
    { this.SurfaceTemperatureMaximum= _SurfaceTemperatureMaximum; } 
    
    public Double getSurfaceTemperatureMinimum()
    { return SurfaceTemperatureMinimum; }

    public void setSurfaceTemperatureMinimum(Double _SurfaceTemperatureMinimum)
    { this.SurfaceTemperatureMinimum= _SurfaceTemperatureMinimum; } 
    
    public Double getSurfaceTemperatureMaximum()
    { return SurfaceTemperatureMaximum; }

    public void setSurfaceTemperatureMaximum(Double _SurfaceTemperatureMaximum)
    { this.SurfaceTemperatureMaximum= _SurfaceTemperatureMaximum; } 
    
    public Double getSurfaceTemperatureMinimum()
    { return SurfaceTemperatureMinimum; }

    public void setSurfaceTemperatureMinimum(Double _SurfaceTemperatureMinimum)
    { this.SurfaceTemperatureMinimum= _SurfaceTemperatureMinimum; } 
    
}