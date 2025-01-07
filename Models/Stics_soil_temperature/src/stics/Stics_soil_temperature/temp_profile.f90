MODULE Temp_profilemod
    USE list_sub
    IMPLICIT NONE
CONTAINS

    SUBROUTINE init_temp_profile(min_air_temp, &
        air_temp_day1, &
        layer_thick, &
        temp_amp, &
        prev_temp_profile, &
        prev_canopy_temp)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: min_air_temp
        REAL, INTENT(IN) :: air_temp_day1
        INTEGER , DIMENSION(: ), INTENT(IN) :: layer_thick
        REAL, INTENT(OUT) :: temp_amp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: prev_temp_profile
        REAL, INTENT(OUT) :: prev_canopy_temp
        INTEGER:: soil_depth
        temp_amp = 0.0
        
        !deallocate(prev_temp_profile)

        prev_canopy_temp = 0.0
        soil_depth = sum(layer_thick)
        allocate(prev_temp_profile(soil_depth))
        prev_temp_profile = air_temp_day1
        prev_canopy_temp = air_temp_day1
    END SUBROUTINE init_temp_profile

    SUBROUTINE model_temp_profile(temp_amp, &
        prev_temp_profile, &
        prev_canopy_temp, &
        min_air_temp, &
        air_temp_day1, &
        layer_thick, &
        temp_profile)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: temp_amp
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(IN) :: prev_temp_profile
        REAL, INTENT(IN) :: prev_canopy_temp
        REAL, INTENT(IN) :: min_air_temp
        REAL, INTENT(IN) :: air_temp_day1
        INTEGER , DIMENSION(: ), INTENT(IN) :: layer_thick
        REAL, ALLOCATABLE , DIMENSION(:), INTENT(OUT) :: temp_profile
        INTEGER:: z
        INTEGER:: n
        REAL, ALLOCATABLE , DIMENSION(:):: vexp
        REAL:: therm_diff
        REAL:: temp_freq
        REAL:: therm_amp
        therm_diff = 5.37e-3
        temp_freq = 7.272e-5
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
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 100.0
    !                          ** min : 0.0
    !                          ** default : 0.0
    !                          ** unit : degC
    !            * name: prev_temp_profile
    !                          ** description : previous soil temperature profile (for 1 cm layers)
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLELIST
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** default : 
    !                          ** unit : degC
    !            * name: prev_canopy_temp
    !                          ** description : previous crop temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
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
    !            * name: air_temp_day1
    !                          ** description : Mean temperature on first day
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 100.0
    !                          ** min : 0.0
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
        !- outputs:
    !            * name: temp_profile
    !                          ** description : current soil profile temperature (for 1 cm layers)
    !                          ** datatype : DOUBLELIST
    !                          ** variablecategory : state
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** unit : degC
        n = SIZE(prev_temp_profile)
        allocate(temp_profile(n))
        allocate(vexp(n))
        therm_amp = SQRT(temp_freq / 2 / therm_diff)
        DO z = 1 , n + 1-1, 1
            vexp(z - 1+1) = EXP(-z * therm_amp)
        END DO
        DO z = 1 , n + 1-1, 1
            temp_profile(z - 1+1) = prev_temp_profile(z - 1+1) - (vexp((z - 1)+1)  &
                    * (prev_canopy_temp - min_air_temp)) + (0.1 * (prev_canopy_temp -  &
                    prev_temp_profile(z - 1+1))) + (temp_amp * vexp((z - 1)+1) / 2)
        END DO
    END SUBROUTINE model_temp_profile

END MODULE
