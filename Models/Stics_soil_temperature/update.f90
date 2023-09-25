MODULE update_mod
   IMPLICIT NONE
CONTAINS
   !%%CyML Model Begin%%
   SUBROUTINE model_update(canopy_temp_avg, &
                           temp_profile, prev_canopy_temp, &
                           prev_temp_profile)
      IMPLICIT NONE

      REAL, INTENT(IN) :: canopy_temp_avg
      REAL, INTENT(IN) :: temp_profile(:)
      REAL, allocatable, INTENT(OUT)  :: prev_temp_profile(:)
      REAL, INTENT(OUT)  :: prev_canopy_temp

      !%%CyML Description Begin%%
      !- Name: update -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: update soil temp model
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract: Update previous state
      !- inputs:
       !            * name: canopy_temp_avg
      !                          ** description : current canopy mean temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min :-50.0
      !                          ** max : 50.0
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
      !            * name: prev_canopy_temp
      !                          ** description : previous crop temperature
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLE
      !                          ** default :
      !                          ** min : 0.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len : 1
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
      !%%CyML Description End%%
      

      INTEGER :: n
      
      !%%CyML Compute Begin%%
      prev_canopy_temp = canopy_temp_avg
      
      n = size(temp_profile)
      allocate(prev_temp_profile(n))
      prev_temp_profile = temp_profile

      !%%CyML Compute End%%

   END SUBROUTINE model_update
   !%%CyML Model End%%
   

END MODULE update_mod 