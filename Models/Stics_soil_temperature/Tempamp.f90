MODULE temp_amp_mod
   IMPLICIT NONE
CONTAINS
   !%%CyML Model Begin%%
   SUBROUTINE model_temp_amp(min_temp, &
                            max_temp, &
                            temp_amp)
      IMPLICIT NONE

      REAL, INTENT(IN) :: min_temp
      REAL, INTENT(IN) :: max_temp
      REAL, INTENT(OUT) :: temp_amp

      !%%CyML Description Begin%%
      !- Name: temp_amp -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: temp_amp model
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract: Calculates temperature amplitude
      !- inputs:
      !            * name: min_temp
      !                          ** description : current minimum temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : exogenous
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !            * name: max_temp
      !                          ** description : current maximum temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : exogenous
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !- outputs:
      !            * name: temp_amp
      !                          ** description : current temperature amplitude
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLE
      !                          ** min : 0.0
      !                          ** max : 100.0
      !                          ** unit : degC
      !                          ** uri :
      !%%CyML Description End%%

      !%%CyML Compute Begin%%
      temp_amp = max_temp - min_temp
      !%%CyML Compute End%%

   END SUBROUTINE model_temp_amp
   !%%CyML Model End%%
END MODULE temp_amp_mod
