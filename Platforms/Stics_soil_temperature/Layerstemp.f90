MODULE layers_temp_mod
   IMPLICIT NONE
CONTAINS
   !%%CyML Model Begin%%
   SUBROUTINE model_layers_temp(temp_profile, &
                               layer_thick, &
                               layer_temp)

      IMPLICIT NONE

      REAL, INTENT(IN)    ::  temp_profile(:)
      REAL, INTENT(IN) ::  layer_thick(:)
      REAL, INTENT(OUT)   ::  layer_temp(size(layer_thick))

      !- Name: Layerstemp -Version: 1.0, -Time step: 1
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
      !                          ** datatype : DOUBLEARRAY
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

      INTEGER :: z
      INTEGER :: layers_nb
      INTEGER :: up_depth(size(layer_thick) + 1) 
      REAL :: layer_depth(size(layer_thick))
      REAL :: soil_depth

      !%%CyML Compute Begin%%
      layers_nb = size(layer_thick)
     
      up_depth = 0
     
     ! Getting layers bottom depth
     CALL layer_thickness2depth(layer_thick, layer_depth)
     up_depth(2:(layers_nb + 1)) = int(layer_depth)

     ! Getting soil depth
     CALL get_soil_depth(layer_thick, soil_depth)

     ! Checking temp profile and soil depth consistency
   !   if (.NOT. size(temp_profile) .EQ. int(soil_depth)) then
   !      print *, ""
   !      print *, "Temperature profile for elemental layers: ", size(temp_profile)
   !      print *, "is not consistent with soil elemental"
   !      print *, "layers number (or depth):", int(soil_depth)
   !      print *, ""
   !      call exit(9)
   !   end if

     DO z = 1, layers_nb
      layer_temp(z) = sum(temp_profile((up_depth(z) + 1):up_depth(z + 1))) / &
                      layer_thick(z)
     END DO 
     !%%CyML Compute End%%
   END SUBROUTINE model_layers_temp
   !%%CyML Model End%%


   !%%CyML Model Begin%%
   SUBROUTINE layer_thickness2depth(layer_thick, layer_depth)
      IMPLICIT NONE
  
      REAL, intent(in)     :: layer_thick(:)
      REAL, intent(out) :: layer_depth(size(layer_thick))
      !- Name: Layer thickness to depth -Version: 1.0, -Time step: 
      !- Description:
      !            * Title: layers thickness conversion to bottom depth
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract: Calculates soil layers bottom depth
      !- inputs:
      !            * name: layer_thick
      !                          ** description : layers thickness
      !                          ** inputtype : variable
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** default : 0.0
      !                          ** min : 
      !                          ** max :
      !                          ** unit : cm
      !                          ** uri :
      !                          ** len : 
      !- outputs:
      !            * name: layer_depth
      !                          ** description : soil layers depth
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** min :
      !                          ** max :
      !                          ** unit : cm
      !                          ** uri :
      !                          ** len : 
      INTEGER :: layers_nb, z

      !%%CyML Compute Begin%%
      layers_nb = size(layer_thick) 
  
      DO z = 1, layers_nb
         layer_depth(z) = sum(layer_thick(1:z))
      END DO
      !%%CyML Compute End%%

    END SUBROUTINE layer_thickness2depth
    !%%CyML Model End%%


    !%%CyML Model Begin%%
    SUBROUTINE layer_depth2thickness(layer_depth, layer_thick)
      IMPLICIT NONE
  
      REAL, intent(in)     :: layer_depth(:)        
      REAL, intent(out) :: layer_thick(size(layer_depth))
      !- Name: Layer depth to thickness  -Version: 1.0, -Time step: 
      !- Description:
      !            * Title: layers bottom depth  conversion to thickness 
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract: Calculates soil layers thickness
      !- inputs:
      !            * name: layer_depth 
      !                          ** description : soil layers depth
      !                          ** inputtype : variable
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** default : 0.0
      !                          ** min : 
      !                          ** max :
      !                          ** unit : cm
      !                          ** uri :
      !                          ** len : 
      !- outputs:
      !            * name: layer_thick
      !                          ** description : layers thickness 
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** min :
      !                          ** max :
      !                          ** unit : cm
      !                          ** uri :
      !                          ** len : 
      INTEGER :: layers_nb, z

      !%%CyML Compute Begin%%
      layers_nb = size(layer_depth)

      layer_thick(1) = layer_depth(1)

      DO z = 2, layers_nb
         layer_thick(z) = layer_depth(z)-layer_depth(z-1)
         IF (layer_thick(z) < 0) layer_thick(z) = 0.
      END DO

      ! if a layer depth is 0
      !WHERE (layer_thick < 0)
      !   layer_thick = 0
      !END WHERE
      
      !%%CyML Compute End%%

    END SUBROUTINE layer_depth2thickness
    !%%CyML Model End%%


    !%%CyML Model Begin%%
    SUBROUTINE get_soil_depth(layer_thick, soil_depth_out)
      IMPLICIT NONE
  
      REAL, intent(in)     :: layer_thick(:)
      REAL, intent(out)    :: soil_depth_out
      !- Name: Soil depth  -Version: 1.0, -Time step: 
      !- Description:
      !            * Title: layers thickness conversion to soil depth 
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract: Calculates soil depth
      !- inputs:
      !            * name: layer_thick 
      !                          ** description : layers thickness
      !                          ** inputtype : variable
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** default : 0.0
      !                          ** min : 
      !                          ** max :
      !                          ** unit : cm
      !                          ** uri :
      !                          ** len : 
      !- outputs:
      !            * name: soil_depth_out
      !                          ** description :  soil depth
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** min :
      !                          ** max :
      !                          ** unit : cm
      !                          ** uri :
      !                          ** len : 
      !%%CyML Compute Begin%%
      soil_depth_out = sum(layer_thick)
      !%%CyML Compute End%%

    END SUBROUTINE get_soil_depth
    !%%CyML Model End%%


    !%%CyML Model Begin%%
    SUBROUTINE get_layers_number(layer_thick_or_depth, layers_number)
      IMPLICIT NONE
  
      REAL, intent(in)     :: layer_thick_or_depth(:)
      INTEGER, intent(out)    :: layers_number  
      !- Name: Layer number  -Version: 1.0, -Time step: 
      !- Description:
      !            * Title: layers number 
      !            * Author: STICS
      !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
      !            * Institution: INRAE
      !            * Abstract: Calculates layers number from thickness/depth
      !- inputs:
      !            * name: layer_thick_or_depth 
      !                          ** description : layers number
      !                          ** inputtype : variable
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** default :
      !                          ** min : 
      !                          ** max :
      !                          ** unit : cm
      !                          ** uri :
      !                          ** len : 
      !- outputs:
      !            * name: layers_number
      !                          ** description :  layers number
      !                          ** variablecategory : state
      !                          ** datatype : DOUBLEARRAY
      !                          ** min :
      !                          ** max :
      !                          ** unit : 
      !                          ** uri :
      !                          ** len : 
      
      !%%CyML Compute Begin%%
      layers_number = count(layer_thick_or_depth/=0.)
      !%%CyML Compute End%%

    END SUBROUTINE get_layers_number
    !%%CyML Model End%%
END MODULE layers_temp_mod
