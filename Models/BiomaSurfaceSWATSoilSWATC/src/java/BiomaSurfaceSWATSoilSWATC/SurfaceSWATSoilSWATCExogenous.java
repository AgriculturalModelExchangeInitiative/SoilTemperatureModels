import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfaceSWATSoilSWATCExogenous
{
    private Double GlobalSolarRadiation;
    private Double AirTemperatureMaximum;
    private Double AirTemperatureMinimum;
    private Double Albedo;
    private Double WaterEquivalentOfSnowPack;
    private Double AirTemperatureAnnualAverage;
    
    public SurfaceSWATSoilSWATCExogenous() { }
    
    public SurfaceSWATSoilSWATCExogenous(SurfaceSWATSoilSWATCExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.GlobalSolarRadiation = toCopy.getGlobalSolarRadiation();
            this.AirTemperatureMaximum = toCopy.getAirTemperatureMaximum();
            this.AirTemperatureMinimum = toCopy.getAirTemperatureMinimum();
            this.Albedo = toCopy.getAlbedo();
            this.WaterEquivalentOfSnowPack = toCopy.getWaterEquivalentOfSnowPack();
            this.AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
        }
    }
    public Double getGlobalSolarRadiation()
    { return GlobalSolarRadiation; }

    public void setGlobalSolarRadiation(Double _GlobalSolarRadiation)
    { this.GlobalSolarRadiation= _GlobalSolarRadiation; } 
    
    public Double getAirTemperatureMaximum()
    { return AirTemperatureMaximum; }

    public void setAirTemperatureMaximum(Double _AirTemperatureMaximum)
    { this.AirTemperatureMaximum= _AirTemperatureMaximum; } 
    
    public Double getAirTemperatureMinimum()
    { return AirTemperatureMinimum; }

    public void setAirTemperatureMinimum(Double _AirTemperatureMinimum)
    { this.AirTemperatureMinimum= _AirTemperatureMinimum; } 
    
    public Double getAlbedo()
    { return Albedo; }

    public void setAlbedo(Double _Albedo)
    { this.Albedo= _Albedo; } 
    
    public Double getWaterEquivalentOfSnowPack()
    { return WaterEquivalentOfSnowPack; }

    public void setWaterEquivalentOfSnowPack(Double _WaterEquivalentOfSnowPack)
    { this.WaterEquivalentOfSnowPack= _WaterEquivalentOfSnowPack; } 
    
    public Double getAirTemperatureAnnualAverage()
    { return AirTemperatureAnnualAverage; }

    public void setAirTemperatureAnnualAverage(Double _AirTemperatureAnnualAverage)
    { this.AirTemperatureAnnualAverage= _AirTemperatureAnnualAverage; } 
    
}