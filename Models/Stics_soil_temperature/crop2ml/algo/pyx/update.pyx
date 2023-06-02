cdef int n 
prev_canopy_temp=canopy_temp_avg
n=len(temp_profile)
prev_temp_profile.allocate(n)
prev_temp_profile=temp_profile
