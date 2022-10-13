MODULE Layerstempmod
   IMPLICIT NONE
CONTAINS
   !%%CyML Model Begin%%
   SUBROUTINE model_layerstemp(tempamp, &
                               thermamp, &
                               layerstemp_t1, &
                               canopytemp_t1, &
                               min_temp, &
                               layerstemp)

      IMPLICIT NONE

      REAL, INTENT(IN)  :: tempamp
      REAL, INTENT(IN)  :: thermamp
      REAL, INTENT(IN)  :: layerstemp_t1(:)
      REAL, INTENT(IN)  :: canopytemp_t1
      REAL, INTENT(IN)  :: min_temp
      REAL, INTENT(OUT) :: layerstemp(size(layerstemp_t1))

      !- Name: Layerstemp -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: layerstemp model
      !            * Authors: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * ExtendedDescription: Calculates soil temperature profile
      !- inputs:
      !            * name: tempamp
      !                          ** description : current temperature amplitude
      !                          ** inputtype : variable
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLE
      !                          ** default : 0.0
      !                          ** min : 0.0
      !                          ** max : 500.0
      !                          ** unit : degC
      !                          ** uri :
      !            * name: thermamp
      !                          ** description : thermal amplitude
      !                          ** inputtype : parameter
      !                          ** parametercategory : constant
      !                          ** datatype : DOUBLE
      !                          ** default :
      !                          ** min :
      !                          ** max :
      !                          ** unit :
      !                          ** uri :
      !            * name: layerstemp_t1
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
      !- outputs:
      !            * name: layerstemp
      !                          ** description : current soil profile temperature (for 1 cm layers)
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLELIST
      !                          ** min : 0.0
      !                          ** max : 500.0
      !                          ** unit : degC
      !                          ** uri :


      INTEGER :: i
      REAL, DIMENSION(size(layerstemp_t1)) :: vexp

      !%%CyML Compute Begin%%
      Do i=1, size(layerstemp_t1)
         vexp(i) = exp(-i*thermamp)
      END DO
      !vexp(:) = exp(-(/(i, i=1, size(layerstemp_t1))/)*thermamp)

      Do i=1, size(layerstemp_t1)
         layerstemp(i) = layerstemp_t1(i) - &
                   vexp(i) * (canopytemp_t1 - min_temp) + &
                   0.1*(canopytemp_t1 - layerstemp_t1(i)) + &
                   (tempamp * vexp(i))/2
      END DO
      !%%CyML Compute End%%
   END SUBROUTINE model_layerstemp
   !%%CyML Model End%%
END MODULE Layerstempmod
