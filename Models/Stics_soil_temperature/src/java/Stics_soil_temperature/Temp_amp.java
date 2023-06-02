import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
public class Temp_amp
{
    
    public Temp_amp() { }
    public void  Calculate_Model(soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a,  soil_tempExogenous ex)
    {
        //- Name: temp_amp -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: temp_amp model
    //            * Authors: None
    //            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    //            * Institution: INRAE
    //            * ExtendedDescription: None
    //            * ShortDescription: None
        //- inputs:
    //            * name: min_temp
    //                          ** description : current minimum temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 0.0
    //                          ** unit : degC
    //            * name: max_temp
    //                          ** description : current maximum temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 0.0
    //                          ** unit : degC
        //- outputs:
    //            * name: temp_amp
    //                          ** description : current temperature amplitude
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 100.0
    //                          ** min : 0.0
    //                          ** unit : degC
        Double min_temp = ex.getmin_temp();
        Double max_temp = ex.getmax_temp();
        Double temp_amp;
        temp_amp = max_temp - min_temp;
        s.settemp_amp(temp_amp);
    }
}