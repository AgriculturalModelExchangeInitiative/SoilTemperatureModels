import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfacePartonSoilSWATCAuxiliary
{
    private Double SurfaceTemperatureMinimum;
    private Double SurfaceTemperatureMaximum;
    
    public SurfacePartonSoilSWATCAuxiliary() { }
    
    public SurfacePartonSoilSWATCAuxiliary(SurfacePartonSoilSWATCAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.SurfaceTemperatureMinimum = toCopy.getSurfaceTemperatureMinimum();
            this.SurfaceTemperatureMaximum = toCopy.getSurfaceTemperatureMaximum();
        }
    }
    public Double getSurfaceTemperatureMinimum()
    { return SurfaceTemperatureMinimum; }

    public void setSurfaceTemperatureMinimum(Double _SurfaceTemperatureMinimum)
    { this.SurfaceTemperatureMinimum= _SurfaceTemperatureMinimum; } 
    
    public Double getSurfaceTemperatureMaximum()
    { return SurfaceTemperatureMaximum; }

    public void setSurfaceTemperatureMaximum(Double _SurfaceTemperatureMaximum)
    { this.SurfaceTemperatureMaximum= _SurfaceTemperatureMaximum; } 
    
}