MODULE update_mod
   IMPLICIT NONE
CONTAINS
   !%%CyML Model Begin%%
   SUBROUTINE model_update(canopy_temp_avg,temp_profile,  &
                            prev_canopy_temp,prev_temp_profile )
      IMPLICIT NONE

      REAL, INTENT(IN) :: canopy_temp_avg
      REAL, INTENT(OUT)  :: prev_temp_profile(:)
      REAL, INTENT(OUT)  :: prev_canopy_temp
      REAL, allocatable, INTENT(IN) :: temp_profile(:)

      !- Name: update -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: update soil temp model
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract: Update previous state
      !- inputs:
      !            * name: canopy_temp_avg
      !                          ** description : current temperature amplitude
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLE
      !                          ** inputtype: variable
      !                          ** default :
      !                          ** min : 0.0
      !                          ** max : 100.0
      !                          ** unit : degC
      !                          ** uri :
      !            * name: temp_profile
      !                          ** description : current soil profile temperature (for 1 cm layers)
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** inputtype: variable
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** default :
      !                          ** uri :
      !                          ** len :
      !- outputs:
      !            * name: prev_temp_profile
      !                          ** description : previous soil temperature profile (for 1 cm layers)
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** default : 
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len : 1
      !            * name: prev_canopy_temp
      !                          ** description : previous crop temperature
      !                          ** variablecategory : exogenous
      !                          ** datatype : DOUBLE
      !                          ** default :
      !                          ** min : 0.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len : 1

      
      !%%CyML Compute Begin%%
      prev_canopy_temp = canopy_temp_avg 
      prev_temp_profile = temp_profile

      !%%CyML Compute End%%

   END SUBROUTINE model_canopy_temp_avg
   !%%CyML Model End%%
END MODULE canopy_temp_avg_mod
