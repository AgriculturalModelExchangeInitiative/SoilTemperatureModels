using System;
using System.Collections.Generic;
using System.Linq;
public class temp_amp
{
    
        public temp_amp() { }
    
    public void  CalculateModel(SoiltempState s, SoiltempState s1, SoiltempRate r, SoiltempAuxiliary a, SoiltempExogenous ex)
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
        double min_temp = ex.min_temp;
        double max_temp = ex.max_temp;
        double temp_amp;
        temp_amp = max_temp - min_temp;
        s.temp_amp= temp_amp;
    }
}