import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class SurfacePartonSoilSWATHourlyPartonCState
{
    private Double [] SoilTemperatureByLayers;
    private Double [] HeatCapacity;
    private Double [] ThermalConductivity;
    private Double [] ThermalDiffusivity;
    private Double [] SoilTemperatureRangeByLayers;
    private Double [] SoilTemperatureMinimum;
    private Double [] SoilTemperatureMaximum;
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
            ThermalConductivity = new Double[toCopy.getThermalConductivity().length];
        for (int i = 0; i < toCopy.getThermalConductivity().length; i++)
        {
            ThermalConductivity[i] = toCopy.getThermalConductivity()[i];
        }
            ThermalDiffusivity = new Double[toCopy.getThermalDiffusivity().length];
        for (int i = 0; i < toCopy.getThermalDiffusivity().length; i++)
        {
            ThermalDiffusivity[i] = toCopy.getThermalDiffusivity()[i];
        }
            SoilTemperatureRangeByLayers = new Double[toCopy.getSoilTemperatureRangeByLayers().length];
        for (int i = 0; i < toCopy.getSoilTemperatureRangeByLayers().length; i++)
        {
            SoilTemperatureRangeByLayers[i] = toCopy.getSoilTemperatureRangeByLayers()[i];
        }
            SoilTemperatureMinimum = new Double[toCopy.getSoilTemperatureMinimum().length];
        for (int i = 0; i < toCopy.getSoilTemperatureMinimum().length; i++)
        {
            SoilTemperatureMinimum[i] = toCopy.getSoilTemperatureMinimum()[i];
        }
            SoilTemperatureMaximum = new Double[toCopy.getSoilTemperatureMaximum().length];
        for (int i = 0; i < toCopy.getSoilTemperatureMaximum().length; i++)
        {
            SoilTemperatureMaximum[i] = toCopy.getSoilTemperatureMaximum()[i];
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
    
    public Double [] getThermalConductivity()
    { return ThermalConductivity; }

    public void setThermalConductivity(Double [] _ThermalConductivity)
    { this.ThermalConductivity= _ThermalConductivity; } 
    
    public Double [] getThermalDiffusivity()
    { return ThermalDiffusivity; }

    public void setThermalDiffusivity(Double [] _ThermalDiffusivity)
    { this.ThermalDiffusivity= _ThermalDiffusivity; } 
    
    public Double [] getSoilTemperatureRangeByLayers()
    { return SoilTemperatureRangeByLayers; }

    public void setSoilTemperatureRangeByLayers(Double [] _SoilTemperatureRangeByLayers)
    { this.SoilTemperatureRangeByLayers= _SoilTemperatureRangeByLayers; } 
    
    public Double [] getSoilTemperatureMinimum()
    { return SoilTemperatureMinimum; }

    public void setSoilTemperatureMinimum(Double [] _SoilTemperatureMinimum)
    { this.SoilTemperatureMinimum= _SoilTemperatureMinimum; } 
    
    public Double [] getSoilTemperatureMaximum()
    { return SoilTemperatureMaximum; }

    public void setSoilTemperatureMaximum(Double [] _SoilTemperatureMaximum)
    { this.SoilTemperatureMaximum= _SoilTemperatureMaximum; } 
    
    public Double [] getSoilTemperatureByLayersHourly()
    { return SoilTemperatureByLayersHourly; }

    public void setSoilTemperatureByLayersHourly(Double [] _SoilTemperatureByLayersHourly)
    { this.SoilTemperatureByLayersHourly= _SoilTemperatureByLayersHourly; } 
    
}