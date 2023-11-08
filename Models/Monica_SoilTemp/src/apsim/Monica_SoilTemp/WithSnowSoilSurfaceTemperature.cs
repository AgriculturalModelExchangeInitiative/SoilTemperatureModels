public class Withsnowsoilsurfacetemperature: Model
{
    
        public Withsnowsoilsurfacetemperature() { }
    
    public void  Calculate_withsnowsoilsurfacetemperature(SoiltemperaturecompState s, SoiltemperaturecompState s1, SoiltemperaturecompRate r, SoiltemperaturecompAuxiliary a)
    {
        //- Name: WithSnowSoilSurfaceTemperature -Version: 1, -Time step: 1
        //- Description:
    //            * Title: Soil surface temperature with potential snow cover
    //            * Authors: Michael Berg-Mohnicke
    //            * Reference: None
    //            * Institution: ZALF e.V.
    //            * ExtendedDescription: None
    //            * ShortDescription: It calculates the soil surface temperature taking a potential snow cover into account
    //        
        //- inputs:
    //            * name: noSnowSoilSurfaceTemperature
    //                          ** description : soilSurfaceTemperature without snow
    //                          ** inputtype : variable
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : °C
    //            * name: soilSurfaceTemperatureBelowSnow
    //                          ** description : soilSurfaceTemperature below snow cover
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** default : 0.0
    //                          ** unit : °C
    //            * name: hasSnowCover
    //                          ** description : is soil covered by snow
    //                          ** inputtype : variable
    //                          ** variablecategory : exogenous
    //                          ** datatype : BOOLEAN
    //                          ** max : 
    //                          ** min : 
    //                          ** default : false
    //                          ** unit : dimensionless
        //- outputs:
    //            * name: soilSurfaceTemperature
    //                          ** description : soilSurfaceTemperature
    //                          ** variablecategory : state
    //                          ** datatype : DOUBLE
    //                          ** max : 
    //                          ** min : 
    //                          ** unit : °C
        double noSnowSoilSurfaceTemperature = s.noSnowSoilSurfaceTemperature;
        double soilSurfaceTemperatureBelowSnow;
        bool hasSnowCover;
        double soilSurfaceTemperature;
        if (hasSnowCover)
        {
            soilSurfaceTemperature = soilSurfaceTemperatureBelowSnow;
        }
        else
        {
            soilSurfaceTemperature = noSnowSoilSurfaceTemperature;
        }
        s.soilSurfaceTemperature= soilSurfaceTemperature;
    }
}