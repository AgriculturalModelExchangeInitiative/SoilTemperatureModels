import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SoilTemperatureRate
{
    private Double heatFlux;
    
    public SoilTemperatureRate() { }
    
    public SoilTemperatureRate(SoilTemperatureRate toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.heatFlux = toCopy.getheatFlux();
        }
    }
    public Double getheatFlux()
    { return heatFlux; }

    public void setheatFlux(Double _heatFlux)
    { this.heatFlux= _heatFlux; } 
    
}