import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Temp_profile
{
    
    public Temp_profile() { }
    public void  Calculate_temp_profile(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a,  SoiltempExogenous ex)
    {
        //- Name: temp_profile -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: tempprofile model
    //            * Authors: None
    //            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    //            * Institution: INRAE
    //            * ExtendedDescription: None
    //            * ShortDescription: None
        //- inputs:
    //            * name: temp_amp
    //                          ** description : current temperature amplitude
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 100.0
    //                          ** min : 0.0
    //                          ** default : 0.0
    //                          ** unit : degC
    //            * name: therm_amp
    //                          ** description : current thermal amplitude
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : 
    //            * name: prev_temp_profile
    //                          ** description : previous soil temperature profile 
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 1
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 
    //                          ** unit : degC
    //            * name: prev_canopy_temp
    //                          ** description : previous crop temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : 0.0
    //                          ** default : 
    //                          ** unit : degC
    //            * name: min_air_temp
    //                          ** description : current minimum air temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 
    //                          ** unit : degC
        //- outputs:
    //            * name: temp_profile
    //                          ** description : current soil profile temperature 
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** unit : degC
        Double temp_amp = ex.gettemp_amp();
        Double therm_amp = ex.gettherm_amp();
        Double [] prev_temp_profile = s.getprev_temp_profile();
        Double prev_canopy_temp = ex.getprev_canopy_temp();
        Double min_air_temp = ex.getmin_air_temp();
        Double[] temp_profile ;
        Integer z;
        Integer n;
        Double[] vexp ;
        n = prev_temp_profile.length;
        temp_profile = new Double [n];
        vexp = new Double [n];
        for (z=1 ; z!=n + 1 ; z+=1)
        {
            vexp[z - 1] = Math.exp(-(z * therm_amp));
        }
        for (z=1 ; z!=n + 1 ; z+=1)
        {
            temp_profile[z - 1] = prev_temp_profile[z - 1] - (vexp[(z - 1)] * (prev_canopy_temp - min_air_temp)) + (0.1d * (prev_canopy_temp - prev_temp_profile[z - 1])) + (temp_amp * vexp[(z - 1)] / 2);
        }
        prev_temp_profile = temp_profile;
        s.settemp_profile(temp_profile);
    }
}