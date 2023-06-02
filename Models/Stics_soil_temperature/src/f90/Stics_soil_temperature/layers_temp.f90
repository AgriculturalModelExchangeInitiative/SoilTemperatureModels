MODULE Layers_tempmod
    USE list_sub
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_layers_temp(temp_profile, &
        layer_thick, &
        layer_temp)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(IN) :: temp_profile
        INTEGER , DIMENSION(: ), INTENT(IN) :: layer_thick
        REAL , DIMENSION(: ), INTENT(OUT) :: layer_temp
        INTEGER:: z
        INTEGER:: layers_nb
        INTEGER, ALLOCATABLE , DIMENSION(:):: up_depth
        INTEGER, ALLOCATABLE , DIMENSION(:):: layer_depth
        INTEGER:: depth_value
        !- Name: layers_temp -Version: 1.0, -Time step: 1
        !- Description:
    !            * Title: layers mean temperature model
    !            * Authors: None
    !            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    !            * Institution: INRAE
    !            * ExtendedDescription: None
    !            * ShortDescription: None
        !- inputs:
    !            * name: temp_profile
    !                          ** description : soil temperature profile
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** default : 0.0
    !                          ** unit : degC
    !            * name: layer_thick
    !                          ** description : layers thickness
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INTARRAY
    !                          ** len : 
    !                          ** max : 
    !                          ** min : 
    !                          ** default : 
    !                          ** unit : cm
        !- outputs:
    !            * name: layer_temp
    !                          ** description : soil layers temperature
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 50.0
    !                          ** min : -50.0
    !                          ** unit : degC
        layers_nb = get_layers_number(layer_thick)
        allocate(layer_temp(layers_nb))
        allocate(up_depth(layers_nb + 1))
        allocate(layer_depth(layers_nb))
        up_depth = 0
        layer_depth = layer_thickness2depth(layer_thick)
        DO z = 1 , layers_nb + 1-1, 1
            depth_value = layer_depth(z - 1+1)
            up_depth(z + 1 - 1+1) = depth_value
        END DO
        DO z = 1 , layers_nb + 1-1, 1
            layer_temp(z - 1+1) = sum(temp_profile((up_depth(z - 1+1) + 1 -  &
                    1):up_depth((z + 1 - 1)+1))) / layer_thick((z - 1)+1)
        END DO
    END SUBROUTINE model_layers_temp

    FUNCTION get_layers_number(layer_thick_or_depth) RESULT(layers_number)
        IMPLICIT NONE
        INTEGER , DIMENSION(: ), INTENT(IN) :: layer_thick_or_depth
        INTEGER:: layers_number
        INTEGER:: i_cyml_r
        INTEGER:: z
        layers_number = 0
        DO z = 1 , SIZE(layer_thick_or_depth) + 1-1, 1
            IF(layer_thick_or_depth(z - 1+1) .NE. 0) THEN
                layers_number = layers_number + 1
            END IF
        END DO
    END FUNCTION get_layers_number

    FUNCTION layer_thickness2depth(layer_thick) RESULT(layer_depth)
        IMPLICIT NONE
        INTEGER , DIMENSION(: ), INTENT(IN) :: layer_thick
        INTEGER, ALLOCATABLE , DIMENSION(:):: layer_depth
        INTEGER:: i_cyml_r
        INTEGER:: layers_nb
        INTEGER:: z
        layers_nb = SIZE(layer_thick)
        allocate(layer_depth(layers_nb))
        layer_depth = 0
        DO z = 1 , layers_nb + 1-1, 1
            IF(layer_thick(z - 1+1) .NE. 0) THEN
                layer_depth(z - 1+1) = sum(layer_thick(1 - 1:z))
            END IF
        END DO
    END FUNCTION layer_thickness2depth

END MODULE
