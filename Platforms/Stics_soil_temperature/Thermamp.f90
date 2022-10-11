MODULE Thermampmod
   IMPLICIT NONE
CONTAINS
   !%%CyML Model Begin%%
   SUBROUTINE model_thermamp(thermdif, &
                             tempwave_freq, &
                             thermamp)
      IMPLICIT NONE

      REAL, INTENT(IN) :: thermdif
      REAL, INTENT(IN), OPTIONAL :: tempwave_freq
      REAL, INTENT(OUT) :: thermamp

      !- Name: Thermamp -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: thermal amplitude calculation
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract:
      !- inputs:
      !            * name: thermdif
      !                          ** description : soil thermal diffusivity
      !                          ** inputtype : variable
      !                          ** variablecategory : auxiliary
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : 0.0
      !                          ** max : 500.0
      !                          ** unit : cm2 s-1
      !                          ** uri :
      !            * name: tempwave_freq
      !                          ** description : angular frequency of the diurnal sine wave
      !                          ** inputtype : variable
      !                          ** variablecategory : auxiliary
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : 0.0
      !                          ** max : 500.0
      !                          ** unit : radians cm2
      !                          ** uri :
      !- outputs:
      !            * name: thermamp
      !                          ** description : thermal amplitude
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLE
      !                          ** min : 
      !                          ** max : 
      !                          ** unit : 
      !                          ** uri :

      ! 

      REAL :: temp_freq

      !

      !if(.NOT. present(tempwave_freq)) then 
         !temp_freq = 7.272e-5
      !else
      !%%CyML Compute Begin%%
      temp_freq = tempwave_freq
      !end if

      thermamp = sqrt(temp_freq/2/thermdif)
      !%%CyML Compute End%%
   END SUBROUTINE model_thermamp
   !%%CyML Model End%%
END MODULE Thermampmod
