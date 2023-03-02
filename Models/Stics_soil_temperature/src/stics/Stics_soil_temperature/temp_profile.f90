MODULE Temp_profilemod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_temp_profile(temp_amp, &
        therm_amp, &
        prev_temp_profile, &
        prev_canopy_temp, &
        min_air_temp, &
        temp_profile)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: temp_amp
        REAL, INTENT(IN) :: therm_amp
        REAL , DIMENSION(1 ), INTENT(IN) :: prev_temp_profile
        REAL, INTENT(IN) :: prev_canopy_temp
        REAL, INTENT(IN) :: min_air_temp
        REAL , DIMENSION(: ), INTENT(OUT) :: temp_profile
        INTEGER:: z
        INTEGER:: n
        REAL , DIMENSION(: ), ALLOCATABLE :: vexp
        !- Name: temp_profile -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: tempprofile model
    !            * Authors: None
    !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    !            * Institution: INRAE
    !            * ExtendedDescription: None
    !            * ShortDescription: None
        !- inputs:
    !            * name: temp_amp
    !                          ** description : current temperature amplitude
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 100.0
    !                          ** min : 0.0
    !                          ** default : 0.0
    !                          ** unit : degC
    !            * name: therm_amp
    !                          ** description : current thermal amplitude
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : 
    !            * name: prev_temp_profile
    !                          ** description : previous soil temperature profile 
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 1
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** default : 
    !                          ** unit : degC
    !            * name: prev_canopy_temp
    !                          ** description : previous crop temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50.0
    !                          ** min : 0.0
    !                          ** default : 
    !                          ** unit : degC
    !            * name: min_air_temp
    !                          ** description : current minimum air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** default : 
    !                          ** unit : degC
        !- outputs:
    !            * name: temp_profile
    !                          ** description : current soil profile temperature 
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** unit : degC
        n = SIZE(prev_temp_profile)
        allocate(temp_profile(n))
        allocate(vexp(n))
        DO z = 1 , n + 1-1, 1
            vexp(z - 1+1) = EXP(-z * therm_amp)
        END DO
        DO z = 1 , n + 1-1, 1
            temp_profile(z - 1+1) = prev_temp_profile(z - 1+1) - (vexp((z - 1)+1)  &
                    * (prev_canopy_temp - min_air_temp)) + (0.1 * (prev_canopy_temp -  &
                    prev_temp_profile(z - 1+1))) + (temp_amp * vexp((z - 1)+1) / 2)
        END DO
        prev_temp_profile = temp_profile
    END SUBROUTINE model_temp_profile

END MODULE
