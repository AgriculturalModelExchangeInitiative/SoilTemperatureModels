import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;

public class campbellAuxiliary
{
    private Double [] minSoilTemp;
    
    public campbellAuxiliary() { }
    
    public campbellAuxiliary(campbellAuxiliary toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            minSoilTemp = new Double[toCopy.getminSoilTemp().length];
        for (int i = 0; i < toCopy.getminSoilTemp().length; i++)
        {
            minSoilTemp[i] = toCopy.getminSoilTemp()[i];
        }
        }
    }
    public Double [] getminSoilTemp()
    { return minSoilTemp; }

    public void setminSoilTemp(Double [] _minSoilTemp)
    { this.minSoilTemp= _minSoilTemp; } 
    
}