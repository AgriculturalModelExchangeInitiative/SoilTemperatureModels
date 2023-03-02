import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SurfacePartonSoilSWATHourlyPartonCExogenous
{
    private Double DayLength;
    private Double AirTemperatureMinimum;
    private Double GlobalSolarRadiation;
    private Double AirTemperatureMaximum;
    private Double AirTemperatureAnnualAverage;
    private Double HourOfSunset;
    private Double HourOfSunrise;
    
    public SurfacePartonSoilSWATHourlyPartonCExogenous() { }
    
    public SurfacePartonSoilSWATHourlyPartonCExogenous(SurfacePartonSoilSWATHourlyPartonCExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.DayLength = toCopy.getDayLength();
            this.AirTemperatureMinimum = toCopy.getAirTemperatureMinimum();
            this.GlobalSolarRadiation = toCopy.getGlobalSolarRadiation();
            this.AirTemperatureMaximum = toCopy.getAirTemperatureMaximum();
            this.AirTemperatureAnnualAverage = toCopy.getAirTemperatureAnnualAverage();
            this.HourOfSunset = toCopy.getHourOfSunset();
            this.HourOfSunrise = toCopy.getHourOfSunrise();
        }
    }
    public Double getDayLength()
    { return DayLength; }

    public void setDayLength(Double _DayLength)
    { this.DayLength= _DayLength; } 
    
    public Double getAirTemperatureMinimum()
    { return AirTemperatureMinimum; }

    public void setAirTemperatureMinimum(Double _AirTemperatureMinimum)
    { this.AirTemperatureMinimum= _AirTemperatureMinimum; } 
    
    public Double getGlobalSolarRadiation()
    { return GlobalSolarRadiation; }

    public void setGlobalSolarRadiation(Double _GlobalSolarRadiation)
    { this.GlobalSolarRadiation= _GlobalSolarRadiation; } 
    
    public Double getAirTemperatureMaximum()
    { return AirTemperatureMaximum; }

    public void setAirTemperatureMaximum(Double _AirTemperatureMaximum)
    { this.AirTemperatureMaximum= _AirTemperatureMaximum; } 
    
    public Double getAirTemperatureAnnualAverage()
    { return AirTemperatureAnnualAverage; }

    public void setAirTemperatureAnnualAverage(Double _AirTemperatureAnnualAverage)
    { this.AirTemperatureAnnualAverage= _AirTemperatureAnnualAverage; } 
    
    public Double getHourOfSunset()
    { return HourOfSunset; }

    public void setHourOfSunset(Double _HourOfSunset)
    { this.HourOfSunset= _HourOfSunset; } 
    
    public Double getHourOfSunrise()
    { return HourOfSunrise; }

    public void setHourOfSunrise(Double _HourOfSunrise)
    { this.HourOfSunrise= _HourOfSunrise; } 
    
}