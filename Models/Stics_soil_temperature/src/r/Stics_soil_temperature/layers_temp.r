library(gsubfn)

model_layers_temp <- function (temp_profile,
         layer_thick){
    #'- Name: layers_temp -Version: 1.0, -Time step: 1
    #'- Description:
    #'            * Title: layers mean temperature model
    #'            * Authors: None
    #'            * Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    #'            * Institution: INRAE
    #'            * ExtendedDescription: None
    #'            * ShortDescription: None
    #'- inputs:
    #'            * name: temp_profile
    #'                          ** description : soil temperature profile
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 50.0
    #'                          ** min : -50.0
    #'                          ** default : 0.0
    #'                          ** unit : degC
    #'            * name: layer_thick
    #'                          ** description : layers thickness
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : INTARRAY
    #'                          ** len : 
    #'                          ** max : 
    #'                          ** min : 
    #'                          ** default : 
    #'                          ** unit : cm
    #'- outputs:
    #'            * name: layer_temp
    #'                          ** description : soil layers temperature
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 50.0
    #'                          ** min : -50.0
    #'                          ** unit : degC
    layer_temp<- vector()
    up_depth <- vector()
    layer_depth <- vector()
    layers_nb <- get_layers_number(layer_thick)
    layer_temp <- vector(, layers_nb)
    up_depth <- vector(, layers_nb + 1)
    layer_depth <- vector(, layers_nb)
    up_depth <- c(0) * (layers_nb + 1)
    layer_depth <- layer_thickness2depth(layer_thick)
    for( z in seq(1, layers_nb + 1-1, 1)){
        depth_value <- layer_depth[z - 1+1]
        up_depth[z + 1 - 1+1] <- depth_value
    }
    for( z in seq(1, layers_nb + 1-1, 1)){
        layer_temp[z - 1+1] <- sum(temp_profile[(up_depth[z - 1+1] + 1 - 1):up_depth[(z + 1 - 1)+1]]) / layer_thick[(z - 1)+1]
    }
    return (list('layer_temp' = layer_temp))
}

get_layers_number <- function (layer_thick_or_depth){
    layers_number <- 0
    for( z in seq(1, length(layer_thick_or_depth) + 1-1, 1)){
        if (layer_thick_or_depth[z - 1+1] != 0)
        {
            layers_number <- layers_number + 1
        }
    }
    return( layers_number)
}

layer_thickness2depth <- function (layer_thick){
    layer_depth <- vector()
    layers_nb <- length(layer_thick)
    layer_depth <- vector(, layers_nb)
    layer_depth <- c(0) * layers_nb
    for( z in seq(1, layers_nb + 1-1, 1)){
        if (layer_thick[z - 1+1] != 0)
        {
            layer_depth[z - 1+1] <- sum(layer_thick[1 - 1:z])
        }
    }
    return( layer_depth)
}