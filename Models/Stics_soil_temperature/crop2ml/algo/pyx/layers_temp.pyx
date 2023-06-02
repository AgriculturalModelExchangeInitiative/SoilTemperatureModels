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
