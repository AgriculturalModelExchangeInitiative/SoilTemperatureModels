import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Temp_profile
{
    public void Init(soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a,  soil_tempExogenous ex)
    {
        Double min_air_temp = ex.getmin_air_temp();
        Double temp_amp = 0.0;
        Double[] prev_temp_profile ;
        Double prev_canopy_temp;
        prev_canopy_temp = 0.0d;
        Integer soil_depth;
        soil_depth = Arrays.stream(layer_thick).mapToInt(Integer::intValue).sum();
        prev_temp_profile = new Double [soil_depth];
        prev_temp_profile = new ArrayList<>(Arrays.asList(air_temp_day1)) * soil_depth;
        prev_canopy_temp = air_temp_day1;
        s.settemp_amp(temp_amp);
        s.setprev_temp_profile(prev_temp_profile);
        s.setprev_canopy_temp(prev_canopy_temp);
    }
    private Double air_temp_day1;
    public Double getair_temp_day1()
    { return air_temp_day1; }

    public void setair_temp_day1(Double _air_temp_day1)
    { this.air_temp_day1= _air_temp_day1; } 
    
    private Integer [] layer_thick;
    public Integer [] getlayer_thick()
    { return layer_thick; }

    public void setlayer_thick(Integer [] _layer_thick)
    { this.layer_thick= _layer_thick; } 
    
    public Temp_profile() { }
    public void  Calculate_Model(soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a,  soil_tempExogenous ex)
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
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 100.0
    //                          ** min : 0.0
    //                          ** default : 0.0
    //                          ** unit : degC
    //            * name: prev_temp_profile
    //                          ** description : previous soil temperature profile 
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 
    //                          ** unit : degC
    //            * name: prev_canopy_temp
    //                          ** description : previous crop temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : state
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
    //            * name: air_temp_day1
    //                          ** description : Mean temperature on first day
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : DOUBLE
    //                          ** max : 100.0
    //                          ** min : 0.0
    //                          ** default : 0.0
    //                          ** unit : degC
    //            * name: layer_thick
    //                          ** description : layers thickness
    //                          ** inputtype : parameter
    //                          ** parametercategory : constant
    //                          ** datatype : INTARRAY
    //                          ** len : 
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 
    //                          ** unit : cm
        //- outputs:
    //            * name: temp_profile
    //                          ** description : current soil profile temperature 
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** unit : degC
        Double temp_amp = s.gettemp_amp();
        Double [] prev_temp_profile = s.getprev_temp_profile();
        Double prev_canopy_temp = s.getprev_canopy_temp();
        Double min_air_temp = ex.getmin_air_temp();
        Double[] temp_profile ;
        Integer z;
        Integer n;
        List<Double> vexp = new ArrayList<>(Arrays.asList());
        Double therm_diff = 5.37e-3;
        Double temp_freq = 7.272e-5;
        Double therm_amp;
        n = prev_temp_profile.length;
        temp_profile = new Double [n];
        vexp = new Double [n];
        therm_amp = Math.sqrt(temp_freq / 2 / therm_diff);
        for (z=1 ; z!=n + 1 ; z+=1)
        {
            vexp.set(z - 1,Math.exp(-(z * therm_amp)));
        }
        for (z=1 ; z!=n + 1 ; z+=1)
        {
            temp_profile[z - 1] = prev_temp_profile[z - 1] - (vexp.get((z - 1)) * (prev_canopy_temp - min_air_temp)) + (0.1d * (prev_canopy_temp - prev_temp_profile[z - 1])) + (temp_amp * vexp.get((z - 1)) / 2);
        }
        s.settemp_profile(temp_profile);
    }
}