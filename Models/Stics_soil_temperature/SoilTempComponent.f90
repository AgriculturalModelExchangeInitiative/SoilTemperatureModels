MODULE soil_temp_mod
   USE temp_profile_mod
   USE temp_amp_mod
   USE therm_amp_mod
   IMPLICIT NONE
CONTAINS
   !%%CyML Composition Begin%%
   SUBROUTINE model_soil_temp(prev_temp_profile, &
                             prev_canopy_temp, &
                             min_canopy_temp, &
                             max_canopy_temp, &
                             min_air_temp, &
                             therm_diff, &
                             temp_wave_freq, &
                             temp_profile)

      REAL, INTENT(INOUT)  :: prev_temp_profile(:)
      REAL, INTENT(IN)  :: prev_canopy_temp
      REAL, INTENT(IN)  :: min_canopy_temp
      REAL, INTENT(IN)  :: max_canopy_temp
      REAL, INTENT(IN)  :: min_air_temp
      REAL, INTENT(IN)  :: therm_diff
      REAL, INTENT(IN), OPTIONAL :: temp_wave_freq
      REAL, allocatable, INTENT(OUT) :: temp_profile(:)

      REAL :: temp_amp
      REAL :: therm_amp

      !- Name: Soiltemp -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: soiltemp model
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract: Calculates soil temperature profile
      !- inputs:
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
      !                          ** variablecategory : exogenous
      !                          ** datatype : DOUBLE
      !                          ** default :
      !                          ** min : 0.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len : 1
      !            * name: min_canopy_temp
      !                          ** description : current minimum canopy temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : exogenous
      !                          ** datatype : DOUBLE
      !                          ** default : 
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len : 1
      !            * name: max_canopy_temp
      !                          ** description : current maximum canopy temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : exogenous
      !                          ** datatype : DOUBLE
      !                          ** default : 
      !                          ** min : -50.0
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
      !            * name: therm_diff
      !                          ** description : soil thermal diffusivity
      !                          ** inputtype : parameter
      !                          ** parametercategory : constant
      !                          ** datatype : DOUBLE
      !                          ** default : 5.37e-3
      !                          ** min : 0.0
      !                          ** max : 1.0e-1
      !                          ** unit : cm2 s-1
      !                          ** uri :
      !                          ** len : 1
      !            * name: temp_wave_freq
      !                          ** description : angular frequency of the diurnal temperature sine wave
      !                          ** inputtype : parameter
      !                          ** parametercategory : constant
      !                          ** datatype : DOUBLE
      !                          ** default : 7.272e-5
      !                          ** min : 0.0
      !                          ** max : 
      !                          ** unit : radians s-1
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

      call model_temp_amp(min_canopy_temp, max_canopy_temp, temp_amp)

      call model_therm_amp(therm_diff, temp_wave_freq, therm_amp)
      
      call model_temp_profile(temp_amp, therm_amp, prev_temp_profile, & 
                              prev_canopy_temp, min_air_temp, temp_profile)

   END SUBROUTINE model_soil_temp
   !%%CyML Composition End%%
END MODULE soil_temp_mod
