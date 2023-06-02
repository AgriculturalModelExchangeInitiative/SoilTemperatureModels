import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Update
{
    
    public Update() { }
    public void  Calculate_Model(soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a,  soil_tempExogenous ex)
    {
        //- Name: update -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: update soil temp model
    //            * Authors: None
    //            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    //            * Institution: INRAE
    //            * ExtendedDescription: None
    //            * ShortDescription: None
        //- inputs:
    //            * name: canopy_temp_avg
    //                          ** description : current temperature amplitude
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 100.0
    //                          ** min : 0.0
    //                          ** default : 
    //                          ** unit : degC
    //            * name: temp_profile
    //                          ** description : current soil profile temperature 
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLEARRAY
    //                          ** len : 
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 
    //                          ** unit : degC
        //- outputs:
    //            * name: prev_temp_profile
    //                          ** description : previous soil temperature profile 
    //                          ** datatype : DOUBLEARRAY
    //                          ** variablecategory : state
    //                          ** len : 1
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** unit : degC
    //            * name: prev_canopy_temp
    //                          ** description : previous crop temperature
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : exogenous
    //                          ** max : 50.0
    //                          ** min : 0.0
    //                          ** unit : degC
        Double canopy_temp_avg = s.getcanopy_temp_avg();
        Double [] temp_profile = s.gettemp_profile();
        Double[] prev_temp_profile =  new Double [1];
        Double prev_canopy_temp;
        prev_canopy_temp = canopy_temp_avg;
        prev_temp_profile = new ArrayList<>(temp_profile);
        s.setprev_temp_profile(prev_temp_profile);
        ex.setprev_canopy_temp(prev_canopy_temp);
    }
}