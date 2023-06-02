def get_layers_number(int layer_thick_or_depth[]):
    cdef int layers_number 
    cdef int z 
    layers_number=0
    for z in range(1 , len(layer_thick_or_depth) + 1 , 1):
        #IF(layer_thick_or_depth(z) /= 0.) layers_number = layers_number + 1
        if layer_thick_or_depth[z - 1] != 0:
            layers_number=layers_number + 1
    return layers_number
