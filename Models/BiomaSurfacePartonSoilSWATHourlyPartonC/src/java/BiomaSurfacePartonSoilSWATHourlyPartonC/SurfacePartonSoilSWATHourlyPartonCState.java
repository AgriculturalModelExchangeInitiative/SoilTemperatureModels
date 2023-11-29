import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class SurfacePartonSoilSWATHourlyPartonCState
{
    private Double [] SoilTemperatureByLayers;
    private Double [] HeatCapacity;
    private Double [] ThermalDiffusivity;
    private Double [] SoilTemperatureByLayersHourly;
    
    public SurfacePartonSoilSWATHourlyPartonCState() { }
    
    public SurfacePartonSoilSWATHourlyPartonCState(SurfacePartonSoilSWATHourlyPartonCState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            SoilTemperatureByLayers = new Double[toCopy.getSoilTemperatureByLayers().length];
        for (int i = 0; i < toCopy.getSoilTemperatureByLayers().length; i++)
        {
            SoilTemperatureByLayers[i] = toCopy.getSoilTemperatureByLayers()[i];
        }
            HeatCapacity = new Double[toCopy.getHeatCapacity().length];
        for (int i = 0; i < toCopy.getHeatCapacity().length; i++)
        {
            HeatCapacity[i] = toCopy.getHeatCapacity()[i];
        }
            ThermalDiffusivity = new Double[toCopy.getThermalDiffusivity().length];
        for (int i = 0; i < toCopy.getThermalDiffusivity().length; i++)
        {
            ThermalDiffusivity[i] = toCopy.getThermalDiffusivity()[i];
        }
            SoilTemperatureByLayersHourly = new Double[toCopy.getSoilTemperatureByLayersHourly().length];
        for (int i = 0; i < toCopy.getSoilTemperatureByLayersHourly().length; i++)
        {
            SoilTemperatureByLayersHourly[i] = toCopy.getSoilTemperatureByLayersHourly()[i];
        }
        }
    }
    public Double [] getSoilTemperatureByLayers()
    { return SoilTemperatureByLayers; }

    public void setSoilTemperatureByLayers(Double [] _SoilTemperatureByLayers)
    { this.SoilTemperatureByLayers= _SoilTemperatureByLayers; } 
    
    public Double [] getHeatCapacity()
    { return HeatCapacity; }

    public void setHeatCapacity(Double [] _HeatCapacity)
    { this.HeatCapacity= _HeatCapacity; } 
    
    public Double [] getThermalDiffusivity()
    { return ThermalDiffusivity; }

    public void setThermalDiffusivity(Double [] _ThermalDiffusivity)
    { this.ThermalDiffusivity= _ThermalDiffusivity; } 
    
    public Double [] getSoilTemperatureByLayersHourly()
    { return SoilTemperatureByLayersHourly; }

    public void setSoilTemperatureByLayersHourly(Double [] _SoilTemperatureByLayersHourly)
    { this.SoilTemperatureByLayersHourly= _SoilTemperatureByLayersHourly; } 
    
}