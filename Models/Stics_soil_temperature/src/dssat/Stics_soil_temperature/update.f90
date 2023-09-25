MODULE Updatemod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_update(canopy_temp_avg, &
        temp_profile, &
        prev_canopy_temp, &
        prev_temp_profile)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: canopy_temp_avg
        REAL , DIMENSION(: ), INTENT(IN) :: temp_profile
        REAL, INTENT(OUT) :: prev_canopy_temp
        REAL , DIMENSION(1 ), INTENT(OUT) :: prev_temp_profile
        INTEGER:: n
        !- Name: update -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: update soil temp model
    !            * Authors: None
    !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    !            * Institution: INRAE
    !            * ExtendedDescription: None
    !            * ShortDescription: None
        !- inputs:
    !            * name: canopy_temp_avg
    !                          ** description : current canopy mean temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** default : 0.0
    !                          ** unit : degC
    !            * name: temp_profile
    !                          ** description : current soil profile temperature (for 1 cm layers)
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** default : 
    !                          ** unit : degC
        !- outputs:
    !            * name: prev_canopy_temp
    !                          ** description : previous crop temperature
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 50.0
    !                          ** min : 0.0
    !                          ** unit : degC
    !            * name: prev_temp_profile
    !                          ** description : previous soil temperature profile (for 1 cm layers)
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 1
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** unit : degC
        prev_canopy_temp = canopy_temp_avg
        n = SIZE(temp_profile)
        allocate(prev_temp_profile(n))
        prev_temp_profile = temp_profile
    END SUBROUTINE model_update

END MODULE
