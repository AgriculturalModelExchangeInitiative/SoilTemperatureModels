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
      REAL, INTENT(IN)  :: prev_temp_profile(:)
      REAL, INTENT(IN)  :: prev_canopy_temp
      REAL, INTENT(IN)  :: min_air_temp
      REAL, allocatable, INTENT(OUT) :: temp_profile(:)

      !- Name: temp_profile -Version: 1.0, -Time step: 1
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
      !                          ** len : 
      !            * name: prev_canopy_temp
      !                          ** description : previous crop temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLE
      !                          ** default :
      !                          ** min : 0.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
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
      REAL, allocatable :: vexp(:)

      

      !%%CyML Compute Begin%%
      n = size(prev_temp_profile)

      !if (.NOT. ALLOCATED(temp_profile)) then
         allocate(temp_profile(n))
      !end if
      
      !if (.NOT. ALLOCATED(vexp)) then
         allocate(vexp(n))
      !end if

      DO z=1, n
         vexp(z) = exp(-z*therm_amp)
      END DO

      DO z=1, n
         temp_profile(z) = prev_temp_profile(z) - &
                           vexp(z) * (prev_canopy_temp - min_air_temp) + &
                           0.1*(prev_canopy_temp - prev_temp_profile(z)) + &
                           (temp_amp * vexp(z))/2
      END DO
      
      !%%CyML Compute End%%
   END SUBROUTINE model_temp_profile


   
   SUBROUTINE init_temp_profile(air_temp_day1, layer_thick, &
                                prev_temp_profile, prev_canopy_temp)
      
      real, intent(IN) :: air_temp_day1
      INTEGER, INTENT(IN) ::  layer_thick(:)
      real, intent(OUT) :: prev_canopy_temp
      real, allocatable, intent(OUT) :: prev_temp_profile(:)
      

      !%%CyML Init Begin%%       
      integer :: soil_depth  
      soil_depth = sum(layer_thick)
      allocate(prev_temp_profile(soil_depth))
      prev_temp_profile = air_temp_day1
      prev_canopy_temp = air_temp_day1
      !%%CyML Init End%% 
   END SUBROUTINE
   
   !%%CyML Model End%%
END MODULE temp_profile_mod

