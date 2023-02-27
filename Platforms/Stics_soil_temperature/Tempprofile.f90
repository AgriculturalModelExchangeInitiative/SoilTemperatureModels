MODULE temp_profile_mod
   IMPLICIT NONE
CONTAINS
   !%%CyML Model Begin%%
   SUBROUTINE model_temp_profile(temp_amp, &
                               therm_amp, &
                               prev_temp_profile, &
                               prev_canopy_temp, &
                               min_air_temp, &
                               temp_profile)

      IMPLICIT NONE

      REAL, INTENT(IN)  :: temp_amp
      REAL, INTENT(IN)  :: therm_amp
      REAL, INTENT(INOUT)  :: prev_temp_profile(:)
      REAL, INTENT(IN)  :: prev_canopy_temp
      REAL, INTENT(IN)  :: min_air_temp
      REAL, INTENT(OUT) :: temp_profile(size(prev_temp_profile))

      !- Name: Tempprofile -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: tempprofile model
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract: Calculates soil temperature profile
      !- inputs:
      !            * name: temp_amp
      !                          ** description : current temperature amplitude
      !                          ** inputtype : variable
      !                          ** variablecategory : exogenous
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : 0.0
      !                          ** max : 100.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len : 1
      !            * name: therm_amp
      !                          ** description : current thermal amplitude
      !                          ** inputtype : variable
      !                          ** variablecategory : exogenous
      !                          ** datatype : DOUBLE
      !                          ** default :
      !                          ** min :
      !                          ** max :
      !                          ** unit :
      !                          ** uri :
      !                          ** len : 1
      !            * name: prev_temp_profile
      !                          ** description : previous soil temperature profile (for 1 cm layers)
      !                          ** inputtype : variable
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
      !                          ** inputtype : variable
      !                          ** variablecategory : exogenous
      !                          ** datatype : DOUBLE
      !                          ** default :
      !                          ** min : 0.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len : 1
      !            * name: min_air_temp
      !                          ** description : current minimum air temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : exogenous
      !                          ** datatype : DOUBLE
      !                          ** default :
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len : 1
      !- outputs:
      !            * name: temp_profile
      !                          ** description : current soil profile temperature (for 1 cm layers)
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len :


      INTEGER :: z,n
      REAL, DIMENSION(size(prev_temp_profile)) :: vexp

      !%%CyML Compute Begin%%
      n = size(prev_temp_profile)

      DO z=1, n
         vexp(z) = exp(-z*therm_amp)
      END DO

      DO z=1, n
         temp_profile(z) = prev_temp_profile(z) - &
                           vexp(z) * (prev_canopy_temp - min_air_temp) + &
                           0.1*(prev_canopy_temp - prev_temp_profile(z)) + &
                           (temp_amp * vexp(z))/2
      END DO

      ! Updating prev_temp_profile
      prev_temp_profile = temp_profile
      
      !%%CyML Compute End%%
   END SUBROUTINE model_temp_profile
   !%%CyML Model End%%

END MODULE temp_profile_mod
