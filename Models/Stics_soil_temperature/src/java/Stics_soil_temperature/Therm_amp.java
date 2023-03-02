import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Therm_amp
{
    
    public Therm_amp() { }
    public void  Calculate_therm_amp(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a,  SoiltempExogenous ex)
    {
        //- Name: therm_amp -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: thermal amplitude calculation
    //            * Authors: None
    //            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    //            * Institution: INRAE
    //            * ExtendedDescription: None
    //            * ShortDescription: None
        //- inputs:
    //            * name: therm_diff
    //                          ** description : soil thermal diffusivity
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 1.0e-1
    //                          ** min : 0.0
    //                          ** default : 5.37e-3
    //                          ** unit : cm2 s-1
    //            * name: temp_wave_freq
    //                          ** description : angular frequency of the diurnal temperature sine wave
    //                          ** inputtype : variable
    //                          ** variablecategory : auxiliary
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 0.0
    //                          ** default : 7.272e-5
    //                          ** unit : radians s-1
        //- outputs:
    //            * name: therm_amp
    //                          ** description : thermal amplitude
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : radians cm-2
        Double therm_diff = a.gettherm_diff();
        Double temp_wave_freq = a.gettemp_wave_freq();
        Double therm_amp;
        Double temp_freq;
        temp_freq = temp_wave_freq;
        therm_amp = Math.sqrt(temp_freq / 2 / therm_diff);
        s.settherm_amp(therm_amp);
    }
}