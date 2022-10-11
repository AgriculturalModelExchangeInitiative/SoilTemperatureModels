MODULE Tempampmod
   IMPLICIT NONE
CONTAINS
   !%%CyML Model Begin%%
   SUBROUTINE model_tempamp(min_temp, &
                            max_temp, &
                            tempamp)
      IMPLICIT NONE

      REAL, INTENT(IN) :: min_temp
      REAL, INTENT(IN) :: max_temp
      REAL, INTENT(OUT) :: tempamp

      !- Name: Tempamp -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: Tempamp model
      !            * Authors: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * ExtendedDescription: Calculates temperature amplitude
      !- inputs:
      !            * name: min_temp
      !                          ** description : current minimum temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : auxiliary
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : 0.0
      !                          ** max : 500.0
      !                          ** unit : degC
      !                          ** uri :
      !            * name: max_temp
      !                          ** description : current maximum temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : auxiliary
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : 0.0
      !                          ** max : 100.0
      !                          ** unit : degC
      !                          ** uri :
      !- outputs:
      !            * name: tempamp
      !                          ** description : current temperature amplitude
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLE
      !                          ** min : 0.0
      !                          ** max : 500.0
      !                          ** unit : degC
      !                          ** uri :
      !%%CyML Compute Begin%%
      tempamp = max_temp - min_temp
      !%%CyML Compute End%%
   
   END SUBROUTINE model_tempamp
   !%%CyML Model End%%
END MODULE Tempampmod
