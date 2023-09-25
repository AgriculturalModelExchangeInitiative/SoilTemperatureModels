MODULE canopy_temp_avg_mod
   IMPLICIT NONE
CONTAINS
   !%%CyML Model Begin%%
   SUBROUTINE model_canopy_temp_avg(min_canopy_temp, &
                            max_canopy_temp, &
                            canopy_temp_avg)
      IMPLICIT NONE

      REAL, INTENT(IN) :: min_canopy_temp
      REAL, INTENT(IN) :: max_canopy_temp
      REAL, INTENT(OUT) :: canopy_temp_avg
      !%%CyML Description Begin%%
      !- Name: canopy_temp_avg -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: canopy_temp_avg model
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract: Calculates temperature amplitude
      !- inputs:
      !            * name: min_canopy_temp
      !                          ** description : current minimum temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : exogenous
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !            * name: max_canopy_temp
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
      !            * name: canopy_temp_avg
      !                          ** description : current temperature amplitude
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLE
      !                          ** min : 0.0
      !                          ** max : 100.0
      !                          ** unit : degC
      !                          ** uri :
      !%%CyML Description End%%

      !%%CyML Compute Begin%%
      canopy_temp_avg = (max_canopy_temp + min_canopy_temp) / 2
      !%%CyML Compute End%%

   END SUBROUTINE model_canopy_temp_avg
   !%%CyML Model End%%
END MODULE canopy_temp_avg_mod
