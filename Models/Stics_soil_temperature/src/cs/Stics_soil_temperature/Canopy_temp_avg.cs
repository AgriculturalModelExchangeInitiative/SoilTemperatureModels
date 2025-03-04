using System;
using System.Collections.Generic;
using System.Linq;
public class Canopy_temp_avg
{
    
    /// <summary>
    /// Constructor of the canopy_temp_avg component")
    /// </summary>  
    public canopy_temp_avg() { }
    
    public void  CalculateModel(soil_tempState s, soil_tempState s1, soil_tempRate r, soil_tempAuxiliary a, soil_tempExogenous ex)
    {
        //- Name: canopy_temp_avg -Version: 1.0, -Time step: 1
        //- Description:
    //            * Title: canopy_temp_avg model
    //            * Authors: None
    //            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    //            * Institution: INRAE
    //            * ExtendedDescription: None
    //            * ShortDescription: None
        //- inputs:
    //            * name: min_canopy_temp
    //                          ** description : current minimum temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 0.0
    //                          ** unit : degC
    //            * name: max_canopy_temp
    //                          ** description : current maximum temperature
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 50.0
    //                          ** min : -50.0
    //                          ** default : 0.0
    //                          ** unit : degC
        //- outputs:
    //            * name: canopy_temp_avg
    //                          ** description : current temperature amplitude
    //                          ** datatype : DOUBLE
    //                          ** variablecategory : state
    //                          ** max : 100.0
    //                          ** min : 0.0
    //                          ** unit : degC
        double min_canopy_temp = ex.min_canopy_temp;
        double max_canopy_temp = ex.max_canopy_temp;
        double canopy_temp_avg;
        canopy_temp_avg = (max_canopy_temp + min_canopy_temp) / 2;
        s.canopy_temp_avg= canopy_temp_avg;
    }
}