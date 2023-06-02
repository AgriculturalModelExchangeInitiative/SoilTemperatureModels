import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class soil_tempExogenous
{
    private Double min_temp;
    private Double max_temp;
    private Double min_air_temp;
    private Double min_canopy_temp;
    private Double max_canopy_temp;
    
    public soil_tempExogenous() { }
    
    public soil_tempExogenous(soil_tempExogenous toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.min_temp = toCopy.getmin_temp();
            this.max_temp = toCopy.getmax_temp();
            this.min_air_temp = toCopy.getmin_air_temp();
            this.min_canopy_temp = toCopy.getmin_canopy_temp();
            this.max_canopy_temp = toCopy.getmax_canopy_temp();
        }
    }
    public Double getmin_temp()
    { return min_temp; }

    public void setmin_temp(Double _min_temp)
    { this.min_temp= _min_temp; } 
    
    public Double getmax_temp()
    { return max_temp; }

    public void setmax_temp(Double _max_temp)
    { this.max_temp= _max_temp; } 
    
    public Double getmin_air_temp()
    { return min_air_temp; }

    public void setmin_air_temp(Double _min_air_temp)
    { this.min_air_temp= _min_air_temp; } 
    
    public Double getmin_canopy_temp()
    { return min_canopy_temp; }

    public void setmin_canopy_temp(Double _min_canopy_temp)
    { this.min_canopy_temp= _min_canopy_temp; } 
    
    public Double getmax_canopy_temp()
    { return max_canopy_temp; }

    public void setmax_canopy_temp(Double _max_canopy_temp)
    { this.max_canopy_temp= _max_canopy_temp; } 
    
}