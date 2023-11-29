import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfaceSWATSoilSWATCExogenous
{
    private Double Albedo;
    private Double AirTemperatureMinimum;
    private Double WaterEquivalentOfSnowPack;
    private Double GlobalSolarRadiation;
    private Double AirTemperatureMaximum;
    
    public SurfaceSWATSoilSWATCExogenous() { }
    
    public SurfaceSWATSoilSWATCExogenous(SurfaceSWATSoilSWATCExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.Albedo = toCopy.getAlbedo();
            this.AirTemperatureMinimum = toCopy.getAirTemperatureMinimum();
            this.WaterEquivalentOfSnowPack = toCopy.getWaterEquivalentOfSnowPack();
            this.GlobalSolarRadiation = toCopy.getGlobalSolarRadiation();
            this.AirTemperatureMaximum = toCopy.getAirTemperatureMaximum();
        }
    }
    public Double getAlbedo()
    { return Albedo; }

    public void setAlbedo(Double _Albedo)
    { this.Albedo= _Albedo; } 
    
    public Double getAirTemperatureMinimum()
    { return AirTemperatureMinimum; }

    public void setAirTemperatureMinimum(Double _AirTemperatureMinimum)
    { this.AirTemperatureMinimum= _AirTemperatureMinimum; } 
    
    public Double getWaterEquivalentOfSnowPack()
    { return WaterEquivalentOfSnowPack; }

    public void setWaterEquivalentOfSnowPack(Double _WaterEquivalentOfSnowPack)
    { this.WaterEquivalentOfSnowPack= _WaterEquivalentOfSnowPack; } 
    
    public Double getGlobalSolarRadiation()
    { return GlobalSolarRadiation; }

    public void setGlobalSolarRadiation(Double _GlobalSolarRadiation)
    { this.GlobalSolarRadiation= _GlobalSolarRadiation; } 
    
    public Double getAirTemperatureMaximum()
    { return AirTemperatureMaximum; }

    public void setAirTemperatureMaximum(Double _AirTemperatureMaximum)
    { this.AirTemperatureMaximum= _AirTemperatureMaximum; } 
    
}