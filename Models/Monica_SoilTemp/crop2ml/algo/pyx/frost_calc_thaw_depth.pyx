cdef float thaw_helper1
if temperature_under_snow < 0.0:
    thaw_helper1 = temperature_under_snow * -1.0
else:
    thaw_helper1 = temperature_under_snow

cdef float thaw_helper2
if frost_depth == 0.0:
    thaw_helper2 = 0.0
else:
    # @todo Claas: check that heat conductivity is in correct unit!
    thaw_helper2 = sqrt(2.0 * heat_conductivity_unfrozen * thaw_helper1
                        / (1000.0 * 79.0 * (mean_field_capacity * 100.0) / 100.0))

cdef float thaw_helper3
if temperature_under_snow < 0.0:
    thaw_helper3 = thaw_helper2 * -1.0
else:
    thaw_helper3 = thaw_helper2

cdef float thaw_helper4
thaw_helper4 = thaw_depth + thaw_helper3

if thaw_helper4 < 0.0:
    thaw_depth = 0.0
else:
    thaw_depth = thaw_helper4
