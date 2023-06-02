using System;
using System.Collections.Generic;
using System.Linq;
public class update
{
    
        public update() { }
    
    public void  CalculateModel(soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a, soil_tempExogenous ex)
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
        double canopy_temp_avg = s.canopy_temp_avg;
        double[] temp_profile = s.temp_profile;
        double[] prev_temp_profile =  new double [1];
        double prev_canopy_temp;
        prev_canopy_temp = canopy_temp_avg;
        prev_temp_profile = new List<double>(temp_profile);
        s.prev_temp_profile= prev_temp_profile;
        ex.prev_canopy_temp= prev_canopy_temp;
    }
}