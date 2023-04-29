import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfacePartonSoilSWATCExogenous
{
    private Double DayLength;
    private Double AirTemperatureMaximum;
    private Double AirTemperatureMinimum;
    private Double GlobalSolarRadiation;
    private Double AirTemperatureAnnualAverage;
    
    public SurfacePartonSoilSWATCExogenous() { }
    
    public SurfacePartonSoilSWATCExogenous(SurfacePartonSoilSWATCExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.DayLength = toCopy.getDayLength();
            this.AirTemperatureMaximum = toCopy.getAirTemperatureMaximum();
            this.AirTemperatureMinimum = toCopy.getAirTemperatureMinimum();
            this.GlobalSolarRadiation = toCopy.getGlobalSolarRadiation();
            this.AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
        }
    }
    public Double getDayLength()
    { return DayLength; }

    public void setDayLength(Double _DayLength)
    { this.DayLength= _DayLength; } 
    
    public Double getAirTemperatureMaximum()
    { return AirTemperatureMaximum; }

    public void setAirTemperatureMaximum(Double _AirTemperatureMaximum)
    { this.AirTemperatureMaximum= _AirTemperatureMaximum; } 
    
    public Double getAirTemperatureMinimum()
    { return AirTemperatureMinimum; }

    public void setAirTemperatureMinimum(Double _AirTemperatureMinimum)
    { this.AirTemperatureMinimum= _AirTemperatureMinimum; } 
    
    public Double getGlobalSolarRadiation()
    { return GlobalSolarRadiation; }

    public void setGlobalSolarRadiation(Double _GlobalSolarRadiation)
    { this.GlobalSolarRadiation= _GlobalSolarRadiation; } 
    
    public Double getAirTemperatureAnnualAverage()
    { return AirTemperatureAnnualAverage; }

    public void setAirTemperatureAnnualAverage(Double _AirTemperatureAnnualAverage)
    { this.AirTemperatureAnnualAverage= _AirTemperatureAnnualAverage; } 
    
}