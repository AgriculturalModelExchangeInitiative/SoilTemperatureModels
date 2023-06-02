import numpy 
from math import *
def model_layers_temp(float temp_profile[],
                      int layer_thick[]):
    """

    layers mean temperature model
    Author: None
    Reference: doi:http://dx.doi.org/10.1016/j.agrformet.2014.05.002
    Institution: INRAE
    ExtendedDescription: None
    ShortDescription: None

    """
    cdef float layer_temp[]
    cdef int z 
    cdef int layers_nb 
    cdef intlist  up_depth
    cdef intlist  layer_depth
    cdef int depth_value 
    layers_nb=get_layers_number(layer_thick)
    layer_temp.allocate(layers_nb)
    #if (.NOT. ALLOCATED(layer_temp)) then
    up_depth.allocate(layers_nb + 1)
    #end if
    #if (.NOT. ALLOCATED(up_depth)) then
    layer_depth.allocate(layers_nb)
    #end if
    #if (.NOT. ALLOCATED(layer_depth)) then
    #end if
    up_depth=[0]*(layers_nb + 1)
    # Getting layers bottom depth
    layer_depth=layer_thickness2depth(layer_thick)
    for z in range(1 , layers_nb + 1 , 1):
        depth_value=layer_depth[z - 1]
        up_depth[z + 1 - 1]=depth_value
    # Calculating layers mean temparature
    for z in range(1 , layers_nb + 1 , 1):
        layer_temp[z - 1]=sum(temp_profile[(up_depth[z - 1] + 1 - 1):up_depth[(z + 1 - 1)]]) / layer_thick[(z - 1)]
    return  layer_temp


#%%CyML Model End%%

def layer_thickness2depth(int layer_thick[]):
    cdef intlist  layer_depth
    cdef int layers_nb , z 
    layers_nb=len(layer_thick)
    layer_depth.allocate(layers_nb)
    #if (.NOT. ALLOCATED(layer_depth)) then
    #end if
    layer_depth=[0]*(layers_nb)
    for z in range(1 , layers_nb + 1 , 1):
        if layer_thick[z - 1] != 0:
            layer_depth[z - 1]=sum(layer_thick[1 - 1:z])
    return layer_depth



def get_layers_number(int layer_thick_or_depth[]):
    cdef int layers_number 
    cdef int z 
    layers_number=0
    for z in range(1 , len(layer_thick_or_depth) + 1 , 1):
        if layer_thick_or_depth[z - 1] != 0:
            layers_number=layers_number + 1
    return layers_number



