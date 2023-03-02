import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class SoiltempAuxiliary
{
    private Double therm_diff;
    private Double temp_wave_freq;
    
    public SoiltempAuxiliary() { }
    
    public SoiltempAuxiliary(SoiltempAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.therm_diff = toCopy.gettherm_diff();
            this.temp_wave_freq = toCopy.gettemp_wave_freq();
        }
    }
    public Double gettherm_diff()
    { return therm_diff; }

    public void settherm_diff(Double _therm_diff)
    { this.therm_diff= _therm_diff; } 
    
    public Double gettemp_wave_freq()
    { return temp_wave_freq; }

    public void settemp_wave_freq(Double _temp_wave_freq)
    { this.temp_wave_freq= _temp_wave_freq; } 
    
}