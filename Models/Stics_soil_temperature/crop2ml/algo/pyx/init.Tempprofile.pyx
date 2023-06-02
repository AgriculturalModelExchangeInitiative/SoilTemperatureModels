cdef int soil_depth 
soil_depth=sum(layer_thick)
prev_temp_profile.allocate(soil_depth)
prev_temp_profile=[air_temp_day1]*(soil_depth)
prev_canopy_temp=air_temp_day1
