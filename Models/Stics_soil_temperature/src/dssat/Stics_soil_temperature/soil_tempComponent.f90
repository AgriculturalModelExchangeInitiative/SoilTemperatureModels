MODULE Soil_tempmod
    USE Temp_ampmod
    USE Temp_profilemod
    USE Layers_tempmod
    USE Canopy_temp_avgmod
    USE Updatemod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_soil_temp(max_temp, &
        min_temp, &
        layer_thick, &
        min_air_temp, &
        air_temp_day1, &
        min_canopy_temp, &
        max_canopy_temp, &
        temp_amp, &
        temp_profile, &
        layer_temp, &
        canopy_temp_avg, &
        prev_canopy_temp, &
        prev_temp_profile)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: max_temp
        REAL, INTENT(IN) :: min_temp
        INTEGER , DIMENSION(: ), INTENT(IN) :: layer_thick
        REAL, INTENT(IN) :: min_air_temp
        REAL, INTENT(IN) :: air_temp_day1
        REAL, INTENT(IN) :: min_canopy_temp
        REAL, INTENT(IN) :: max_canopy_temp
        REAL, INTENT(OUT) :: temp_amp
        REAL , DIMENSION(: ), INTENT(OUT) :: prev_temp_profile
        REAL, INTENT(OUT) :: prev_canopy_temp
        REAL , DIMENSION(: ), INTENT(OUT) :: temp_profile
        REAL , DIMENSION(: ), INTENT(OUT) :: layer_temp
        REAL, INTENT(OUT) :: canopy_temp_avg
        !- Name: soil_temp -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: soil temperature model
    !            * Authors: None
    !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    !            * Institution: INRAE
    !            * ExtendedDescription: None
    !            * ShortDescription: None
        !- inputs:
    !            * name: max_temp
    !                          ** description : current maximum temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** default : 0.0
    !                          ** unit : degC
    !            * name: min_temp
    !                          ** description : current minimum temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** default : 0.0
    !                          ** unit : degC
    !            * name: layer_thick
    !                          ** description : layers thickness
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INTARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm
    !            * name: min_air_temp
    !                          ** description : current minimum air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** default : 
    !                          ** unit : degC
    !            * name: air_temp_day1
    !                          ** description : Mean temperature on first day
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 100.0
    !                          ** min : 0.0
    !                          ** default : 0.0
    !                          ** unit : degC
    !            * name: min_canopy_temp
    !                          ** description : current minimum temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** default : 0.0
    !                          ** unit : degC
    !            * name: max_canopy_temp
    !                          ** description : current maximum temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** default : 0.0
    !                          ** unit : degC
        !- outputs:
    !            * name: temp_amp
    !                          ** description : current temperature amplitude
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 100.0
    !                          ** min : 0.0
    !                          ** unit : degC
    !            * name: temp_profile
    !                          ** description : current soil profile temperature 
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** unit : degC
    !            * name: layer_temp
    !                          ** description : soil layers temperature
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** unit : degC
    !            * name: canopy_temp_avg
    !                          ** description : current temperature amplitude
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 100.0
    !                          ** min : 0.0
    !                          ** unit : degC
    !            * name: prev_canopy_temp
    !                          ** description : previous crop temperature
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : exogenous
    !                          ** max : 50.0
    !                          ** min : 0.0
    !                          ** unit : degC
    !            * name: prev_temp_profile
    !                          ** description : previous soil temperature profile 
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 1
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** unit : degC
        call model_temp_amp(min_temp, max_temp,temp_amp)
        call model_canopy_temp_avg(min_canopy_temp,  &
                max_canopy_temp,canopy_temp_avg)
        call model_temp_profile(temp_amp, prev_temp_profile,  &
                prev_canopy_temp, min_air_temp, air_temp_day1,  &
                layer_thick,temp_profile)
        call model_layers_temp(temp_profile, layer_thick,layer_temp)
        call model_update(canopy_temp_avg,  &
                temp_profile,prev_canopy_temp,prev_temp_profile)
    END SUBROUTINE model_soil_temp

END MODULE
