import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class SoiltempState
{
    private Double [] prev_temp_profile;
    private Double temp_amp;
    private Double therm_amp;
    private Double [] temp_profile;
    
    public SoiltempState() { }
    
    public SoiltempState(SoiltempState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            prev_temp_profile = new Double[1];
        for (int i = 0; i < 1; i++)
        {
            prev_temp_profile[i] = toCopy.getprev_temp_profile()[i];
        }
            this.temp_amp = toCopy.gettemp_amp();
            this.therm_amp = toCopy.gettherm_amp();
            temp_profile = new Double[toCopy.gettemp_profile().length];
        for (int i = 0; i < toCopy.gettemp_profile().length; i++)
        {
            temp_profile[i] = toCopy.gettemp_profile()[i];
        }
        }
    }
    public Double [] getprev_temp_profile()
    { return prev_temp_profile; }

    public void setprev_temp_profile(Double [] _prev_temp_profile)
    { this.prev_temp_profile= _prev_temp_profile; } 
    
    public Double gettemp_amp()
    { return temp_amp; }

    public void settemp_amp(Double _temp_amp)
    { this.temp_amp= _temp_amp; } 
    
    public Double gettherm_amp()
    { return therm_amp; }

    public void settherm_amp(Double _therm_amp)
    { this.therm_amp= _therm_amp; } 
    
    public Double [] gettemp_profile()
    { return temp_profile; }

    public void settemp_profile(Double [] _temp_profile)
    { this.temp_profile= _temp_profile; } 
    
}