import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfacePartonSoilSWATCAuxiliary
{
    private Double SurfaceTemperatureMaximum;
    private Double SurfaceTemperatureMinimum;
    
    public SurfacePartonSoilSWATCAuxiliary() { }
    
    public SurfacePartonSoilSWATCAuxiliary(SurfacePartonSoilSWATCAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
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
    
}