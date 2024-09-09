def InterpTemp(float time_hours,
         float tmax,
         float tmin,
         float max_temp_yesterday,
         float min_temp_yesterday):
    cdef float DAYhrs = 24.0
    cdef float time = time_hours / DAYhrs
    cdef float max_t_time = tmax / DAYhrs
    cdef float min_t_time = max_t_time - 0.5
    cdef float current_temp 
    if time < min_t_time:
        cdef float midnight_temp = sin((0.0 + 0.25 - max_t_time) * 2.0 * pi) * (max_temp_yesterday - min_temp_yesterday) / 2.0 + ((max_temp_yesterday + min_temp_yesterday) / 2.0)
        cdef float t_scale = (min_t_time - time) / min_t_time
        t_scale=max(0, min(t_scale, 1))
        current_temp=tmin + (t_scale * (midnight_temp - tmin))
    else:
        current_temp=sin((time + 0.25 - max_t_time) * 2.0 * pi) * (tmax - tmin) / 2.0 + ((tmax + tmin) / 2.0)
    return current_temp
