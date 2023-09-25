MODULE layers_temp_mod
   IMPLICIT NONE
CONTAINS
   !%%CyML Model Begin%%
   SUBROUTINE model_layers_temp(temp_profile, &
                               layer_thick, &
                               layer_temp)

      IMPLICIT NONE

      REAL, INTENT(IN)    ::  temp_profile(:)
      INTEGER, INTENT(IN) ::  layer_thick(:)
      REAL, allocatable, INTENT(OUT)   ::  layer_temp(:)

      !%%CyML Description Begin%%
      !- Name: layers_temp -Version: 1.0, -Time step: 1
      !- Description:
      !            * Title: layers mean temperature model
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract: Calculates soil layers mean temperature
      !- inputs:
      !            * name: temp_profile
      !                          ** description : soil temperature profile
      !                          ** inputtype : variable
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** default : 0.0
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len : 
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
      !            * name: layer_temp
      !                          ** description : soil layers temperature
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** min : -50.0
      !                          ** max : 50.0
      !                          ** unit : degC
      !                          ** uri :
      !                          ** len : 
      !%%CyML Description End%%

      INTEGER :: z
      INTEGER :: layers_nb
      INTEGER, allocatable :: up_depth(:)
      INTEGER, allocatable :: layer_depth(:)
      INTEGER :: depth_value

      !%%CyML Compute Begin%%
      call get_layers_number(layer_thick, layers_nb)

      !if (.NOT. ALLOCATED(layer_temp)) then
        allocate(layer_temp(layers_nb))
      !end if

      !if (.NOT. ALLOCATED(up_depth)) then
        allocate(up_depth(layers_nb + 1))
      !end if
     
      !if (.NOT. ALLOCATED(layer_depth)) then
        allocate(layer_depth(layers_nb))
      !end if

      up_depth = 0
     
     ! Getting layers bottom depth
     CALL layer_thickness2depth(layer_thick, layer_depth)

    
     DO z = 1, layers_nb
      
      depth_value = layer_depth(z)
      up_depth(z+1) = depth_value
     END DO

     ! Calculating layers mean temparature
     DO z = 1, layers_nb
      layer_temp(z) = sum(temp_profile((up_depth(z) + 1):up_depth(z + 1))) / &
                      layer_thick(z)
     END DO 
     !%%CyML Compute End%%
   END SUBROUTINE model_layers_temp
   !%%CyML Model End%%


   SUBROUTINE layer_thickness2depth(layer_thick, layer_depth)

    INTEGER, intent(in)     :: layer_thick(:)
    INTEGER, allocatable, intent(out) :: layer_depth(:)

    INTEGER :: layers_nb, z

    layers_nb = size(layer_thick) 

    !if (.NOT. ALLOCATED(layer_depth)) then
    allocate(layer_depth(layers_nb))
    !end if
    layer_depth = 0

    DO z = 1, layers_nb
       if (layer_thick(z) /= 0) layer_depth(z) = sum(layer_thick(1:z))
    END DO

   END SUBROUTINE layer_thickness2depth

   SUBROUTINE get_soil_depth(layer_thick, soil_depth)
    IMPLICIT NONE

    INTEGER, intent(in)     :: layer_thick(:)
    INTEGER, intent(out)    :: soil_depth
    
    soil_depth = sum(layer_thick)


   END SUBROUTINE get_soil_depth


   SUBROUTINE get_layers_number(layer_thick_or_depth, layers_number)
    IMPLICIT NONE

    INTEGER, intent(in)     :: layer_thick_or_depth(:)
    INTEGER, intent(out)    :: layers_number  
    
    integer :: z

    layers_number = 0
    DO z = 1, size(layer_thick_or_depth)
      IF(layer_thick_or_depth(z) /= 0) layers_number = layers_number + 1
    END DO
    
   END SUBROUTINE get_layers_number
   
END MODULE layers_temp_mod
