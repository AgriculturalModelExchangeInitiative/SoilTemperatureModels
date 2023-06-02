cdef int z , n 
cdef floatlist  vexp
cdef float therm_diff = 5.37e-3
cdef float temp_freq = 7.272e-5
cdef float therm_amp 
n=len(prev_temp_profile)
temp_profile.allocate(n)
#if (.NOT. ALLOCATED(temp_profile)) then
vexp.allocate(n)
#end if
#if (.NOT. ALLOCATED(vexp)) then
#end if
therm_amp=sqrt(temp_freq / 2 / therm_diff)
for z in range(1 , n + 1 , 1):
    vexp[z - 1]=exp(-(z * therm_amp))
for z in range(1 , n + 1 , 1):
    temp_profile[z - 1]=prev_temp_profile[z - 1] - (vexp[(z - 1)] * (prev_canopy_temp - min_air_temp)) + (0.1 * (prev_canopy_temp - prev_temp_profile[z - 1])) + (temp_amp * vexp[(z - 1)] / 2)
