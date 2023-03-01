MODULE therm_amp_mod
   IMPLICIT NONE
CONTAINS
   !%%CyML Model Begin%%
   SUBROUTINE model_therm_amp(therm_diff, &
                             temp_wave_freq, &
                             therm_amp)
      IMPLICIT NONE

      REAL, INTENT(IN) :: therm_diff
      REAL, INTENT(IN), OPTIONAL :: temp_wave_freq
      REAL, INTENT(OUT) :: therm_amp

      !- Name: therm_amp -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: thermal amplitude calculation
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract:
      !- inputs:
      !            * name: therm_diff
      !                          ** description : soil thermal diffusivity
      !                          ** inputtype : variable
      !                          ** variablecategory : auxiliary
      !                          ** datatype : DOUBLE
      !                          ** default : 5.37e-3
      !                          ** min : 0.0
      !                          ** max : 1.0e-1
      !                          ** unit : cm2 s-1
      !                          ** uri :
      !                          ** len : 1
      !            * name: temp_wave_freq
      !                          ** description : angular frequency of the diurnal temperature sine wave
      !                          ** inputtype : variable
      !                          ** variablecategory : auxiliary
      !                          ** datatype : DOUBLE
      !                          ** default : 7.272e-5
      !                          ** min : 0.0
      !                          ** max :
      !                          ** unit : radians s-1
      !                          ** uri :
      !                          ** len : 1
      !- outputs:
      !            * name: therm_amp
      !                          ** description : thermal amplitude
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLE
      !                          ** min : 
      !                          ** max : 
      !                          ** unit : radians cm-2
      !                          ** uri :
      !                          ** len : 1
      ! 

      REAL :: temp_freq

      !if(.NOT. present(temp_wave_freq)) then 
      !   temp_freq = 7.272e-5
      !else
      !%%CyML Compute Begin%%
         temp_freq = temp_wave_freq
      !end if

      therm_amp = sqrt(temp_freq/2/therm_diff)
      !%%CyML Compute End%%
   END SUBROUTINE model_therm_amp
   !%%CyML Model End%%
END MODULE therm_amp_mod
