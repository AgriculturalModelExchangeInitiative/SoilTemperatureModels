import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class SurfacePartonSoilSWATCState
{
    private Double [] SoilTemperatureByLayers;
    
    public SurfacePartonSoilSWATCState() { }
    
    public SurfacePartonSoilSWATCState(SurfacePartonSoilSWATCState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            SoilTemperatureByLayers = new Double[toCopy.getSoilTemperatureByLayers().length];
        for (int i = 0; i < toCopy.getSoilTemperatureByLayers().length; i++)
        {
            SoilTemperatureByLayers[i] = toCopy.getSoilTemperatureByLayers()[i];
        }
        }
    }
    public Double [] getSoilTemperatureByLayers()
    { return SoilTemperatureByLayers; }

    public void setSoilTemperatureByLayers(Double [] _SoilTemperatureByLayers)
    { this.SoilTemperatureByLayers= _SoilTemperatureByLayers; } 
    
}