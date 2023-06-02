MODULE soil_temp_mod
   USE temp_profile_mod
   USE temp_amp_mod
   USE therm_amp_mod
   USE canopy_temp_avg_mod
   USE layers_temp_mod
   USE update_mod
   IMPLICIT NONE
CONTAINS
   !%%CyML Composition Begin%%
   SUBROUTINE model_soil_temp(prev_temp_profile, &
                             prev_canopy_temp, &
                             min_canopy_temp, &
                             max_canopy_temp, &
                             min_air_temp, &
                             layer_thick, &
                             temp_profile, &
                             layer_temp) 

      REAL, allocatable, INTENT(INOUT)  :: prev_temp_profile(:)
      REAL, INTENT(INOUT)  :: prev_canopy_temp
      REAL, INTENT(IN)  :: min_canopy_temp
      REAL, INTENT(IN)  :: max_canopy_temp
      REAL, INTENT(IN)  :: min_air_temp
      integer, INTENT(IN) :: layer_thick(:)
      REAL, allocatable, INTENT(OUT) :: temp_profile(:)
      real, allocatable, INTENT(OUT)  :: layer_temp(:)

      REAL :: temp_amp
      REAL :: therm_amp
      REAL :: canopy_temp_avg

      


      !- Name: soil_temp -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: soil temperature model
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
      !            * name: layer_thick
      !                          ** description : layers thickness 
      !                          ** inputtype : parameter
      !                          ** parametercategory : constant
      !                          ** datatype : INTARRAY
      !                          ** default :
      !                          ** min :
      !                          ** max : 
      !                          ** unit : cm
      !                          ** uri :
      !                          ** len :
      !- outputs:
      !            * name: prev_temp_profile
      !                          ** description : previous soil temperature profile (for 1 cm layers)
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len :
      !            * name: prev_canopy_temp
      !                          ** description : previous crop temperature
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLE
      !                          ** min : 0.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len : 1  
      !            * name: temp_profile
      !                          ** description : current soil profile temperature (for 1 cm layers)
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len :
      !            * name: layer_temp
      !                          ** description : current layers mean temperature
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len :

      call model_temp_amp(min_canopy_temp, max_canopy_temp, temp_amp)

      !call model_therm_amp(therm_diff, temp_freq, therm_amp)
      
      !call model_temp_profile(temp_amp, therm_amp, prev_temp_profile, & 
      !                        prev_canopy_temp, min_air_temp, temp_profile)
      call model_temp_profile(temp_amp, prev_temp_profile, & 
                              prev_canopy_temp, min_air_temp, temp_profile)

      call model_layers_temp(temp_profile, &
                             layer_thick, layer_temp)
			      
      call model_canopy_temp_avg(min_canopy_temp, max_canopy_temp, &
                                 canopy_temp_avg)

      call model_update(canopy_temp_avg, temp_profile,  &
                        prev_canopy_temp, prev_temp_profile)

   END SUBROUTINE model_soil_temp
   !%%CyML Composition End%%
END MODULE soil_temp_mod
