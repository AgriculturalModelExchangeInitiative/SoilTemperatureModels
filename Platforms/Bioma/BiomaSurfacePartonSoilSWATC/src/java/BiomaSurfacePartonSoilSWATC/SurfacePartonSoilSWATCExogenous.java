import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfacePartonSoilSWATCExogenous
{
    private Double GlobalSolarRadiation;
    private Double AirTemperatureMinimum;
    private Double DayLength;
    private Double AirTemperatureMaximum;
    private Double AirTemperatureAnnualAverage;
    
    public SurfacePartonSoilSWATCExogenous() { }
    
    public SurfacePartonSoilSWATCExogenous(SurfacePartonSoilSWATCExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.GlobalSolarRadiation = toCopy.getGlobalSolarRadiation();
            this.AirTemperatureMinimum = toCopy.getAirTemperatureMinimum();
            this.DayLength = toCopy.getDayLength();
            this.AirTemperatureMaximum = toCopy.getAirTemperatureMaximum();
            this.AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
        }
    }
    public Double getGlobalSolarRadiation()
    { return GlobalSolarRadiation; }

    public void setGlobalSolarRadiation(Double _GlobalSolarRadiation)
    { this.GlobalSolarRadiation= _GlobalSolarRadiation; } 
    
    public Double getAirTemperatureMinimum()
    { return AirTemperatureMinimum; }

    public void setAirTemperatureMinimum(Double _AirTemperatureMinimum)
    { this.AirTemperatureMinimum= _AirTemperatureMinimum; } 
    
    public Double getDayLength()
    { return DayLength; }

    public void setDayLength(Double _DayLength)
    { this.DayLength= _DayLength; } 
    
    public Double getAirTemperatureMaximum()
    { return AirTemperatureMaximum; }

    public void setAirTemperatureMaximum(Double _AirTemperatureMaximum)
    { this.AirTemperatureMaximum= _AirTemperatureMaximum; } 
    
    public Double getAirTemperatureAnnualAverage()
    { return AirTemperatureAnnualAverage; }

    public void setAirTemperatureAnnualAverage(Double _AirTemperatureAnnualAverage)
    { this.AirTemperatureAnnualAverage= _AirTemperatureAnnualAverage; } 
    
}