library(gsubfn)

#' layers mean temperature model
#'
#' This function compute the layers mean temperature model
#' @param temp_profile (degC) soil temperature profile state (0.0, -50.0-50.0) 
#' @param layer_thick (cm) layers thickness constant (, -) 
#'
#' @return
#' \describe{
#'   \item{layer_temp (degC)}{soil layers temperature state (-50.0-)} 
#' }
#' @export
model_layers_temp <- function (temp_profile,
         layer_thick){
    layer_temp<- vector()
    z <- 0
    layers_nb <- 0
    up_depth <- vector()
    layer_depth <- vector()
    depth_value <- 0
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
        layer_temp[z - 1+1] <- sum(temp_profile[((up_depth[z - 1+1] + 1 - 1) + 1):up_depth[(z + 1 - 1)+1]]) / layer_thick[(z - 1)+1]
    }
    return (list('layer_temp' = layer_temp))
}

get_layers_number <- function (layer_thick_or_depth){
    layers_number <- 0
    z <- 0
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
    layers_nb <- 0
    z <- 0
    layers_nb <- length(layer_thick)
    layer_depth <- vector(, layers_nb)
    layer_depth <- c(0) * layers_nb
    for( z in seq(1, layers_nb + 1-1, 1)){
        if (layer_thick[z - 1+1] != 0)
        {
            layer_depth[z - 1+1] <- sum(layer_thick[(1 - 1 + 1):z])
        }
    }
    return( layer_depth)
}