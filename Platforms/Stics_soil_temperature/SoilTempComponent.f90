MODULE Soiltempmod
   USE Layerstempmod
   USE Tempampmod
   USE Thermampmod
   IMPLICIT NONE
CONTAINS
   !%%CyML Composition Begin%%
   SUBROUTINE model_soiltemp(soiltemp_t1, &
                             canopytemp_t1, &
                             min_temp, &
                             max_temp, &
                             thermdif, &
                             tempwave_freq, &
                             soiltemp)

      REAL, INTENT(IN)  :: soiltemp_t1(:)
      REAL, INTENT(IN)  :: canopytemp_t1
      REAL, INTENT(IN)  :: min_temp
      REAL, INTENT(IN)  :: max_temp
      REAL, INTENT(IN)  :: thermdif
      REAL, INTENT(IN), OPTIONAL :: tempwave_freq
      REAL, INTENT(OUT) :: soiltemp(size(soiltemp_t1))

      REAL :: tempamp
      REAL :: thermamp

      !- Name: Soiltemp -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: soiltemp model
      !            * Authors: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * ShortDescription: Calculates soil temperature profile
      !- inputs:
      !            * name: soiltemp_t1
      !                          ** description : previous soil temperature profile (for 1 cm layers)
      !                          ** inputtype : variable
      !                          ** variablecategory : auxiliary
      !                          ** datatype : DOUBLELIST
      !                          ** default : 0.0
      !                          ** min : 0.0
      !                          ** max : 500.0
      !                          ** unit : degC
      !                          ** uri :
      !            * name: canopytemp_t1
      !                          ** description : previous crop temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : auxiliary
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : 0.0
      !                          ** max : 500.0
      !                          ** unit : degC
      !                          ** uri :
      !            * name: min_temp
      !                          ** description : current minimum air temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : auxiliary
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : 0.0
      !                          ** max : 500.0
      !                          ** unit : degC
      !                          ** uri :
      !            * name: max_temp
      !                          ** description : current maximum air temperature
      !                          ** inputtype : variable
      !                          ** variablecategory : auxiliary
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : 0.0
      !                          ** max : 500.0
      !                          ** unit : degC
      !                          ** uri :
      !            * name: tempwave_freq
      !                          ** description : angular frequency of the diurnal sine wave
      !                          ** inputtype : variable
      !                          ** variablecategory : parameter
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : 0.0
      !                          ** max : 500.0
      !                          ** unit : radians cm2
      !                          ** uri :
      !- outputs:
      !            * name: soiltemp
      !                          ** description : current soil profile temperature (for 1 cm layers)
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLELIST
      !                          ** min : 0.0
      !                          ** max : 500.0
      !                          ** unit : degC
      !                          ** uri :

      call model_tempamp(min_temp, max_temp, tempamp)

      call model_thermamp(thermdif, tempwave_freq, thermamp)

      call model_layerstemp(tempamp, thermamp, soiltemp_t1, canopytemp_t1, &
                            min_temp, soiltemp)
      
   END SUBROUTINE model_soiltemp
   !%%CyML Composition End%%
END MODULE
