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
