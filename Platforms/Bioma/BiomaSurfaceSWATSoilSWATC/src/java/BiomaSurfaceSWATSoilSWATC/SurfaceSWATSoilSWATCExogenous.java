import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfaceSWATSoilSWATCExogenous
{
    private Double AirTemperatureMinimum;
    private Double GlobalSolarRadiation;
    private Double WaterEquivalentOfSnowPack;
    private Double AirTemperatureMaximum;
    private Double Albedo;
    private Double AirTemperatureAnnualAverage;
    
    public SurfaceSWATSoilSWATCExogenous() { }
    
    public SurfaceSWATSoilSWATCExogenous(SurfaceSWATSoilSWATCExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.AirTemperatureMinimum = toCopy.getAirTemperatureMinimum();
            this.GlobalSolarRadiation = toCopy.getGlobalSolarRadiation();
            this.WaterEquivalentOfSnowPack = toCopy.getWaterEquivalentOfSnowPack();
            this.AirTemperatureMaximum = toCopy.getAirTemperatureMaximum();
            this.Albedo = toCopy.getAlbedo();
            this.AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
        }
    }
    public Double getAirTemperatureMinimum()
    { return AirTemperatureMinimum; }

    public void setAirTemperatureMinimum(Double _AirTemperatureMinimum)
    { this.AirTemperatureMinimum= _AirTemperatureMinimum; } 
    
    public Double getGlobalSolarRadiation()
    { return GlobalSolarRadiation; }

    public void setGlobalSolarRadiation(Double _GlobalSolarRadiation)
    { this.GlobalSolarRadiation= _GlobalSolarRadiation; } 
    
    public Double getWaterEquivalentOfSnowPack()
    { return WaterEquivalentOfSnowPack; }

    public void setWaterEquivalentOfSnowPack(Double _WaterEquivalentOfSnowPack)
    { this.WaterEquivalentOfSnowPack= _WaterEquivalentOfSnowPack; } 
    
    public Double getAirTemperatureMaximum()
    { return AirTemperatureMaximum; }

    public void setAirTemperatureMaximum(Double _AirTemperatureMaximum)
    { this.AirTemperatureMaximum= _AirTemperatureMaximum; } 
    
    public Double getAlbedo()
    { return Albedo; }

    public void setAlbedo(Double _Albedo)
    { this.Albedo= _Albedo; } 
    
    public Double getAirTemperatureAnnualAverage()
    { return AirTemperatureAnnualAverage; }

    public void setAirTemperatureAnnualAverage(Double _AirTemperatureAnnualAverage)
    { this.AirTemperatureAnnualAverage= _AirTemperatureAnnualAverage; } 
    
}