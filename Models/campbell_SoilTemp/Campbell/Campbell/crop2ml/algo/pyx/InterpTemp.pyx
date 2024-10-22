def InterpTemp(float time_hours,
         float tmax,
         float tmin,
         float t2m,
         float max_temp_yesterday,
         float min_temp_yesterday):
    cdef float defaultTimeOfMaximumTemperature = 14.0
    cdef float midnight_temp 
    cdef float t_scale 
    cdef float _pi = 3.141592653589793
    cdef float time = time_hours / 24.0
    cdef float max_t_time = defaultTimeOfMaximumTemperature / 24.0
    cdef float min_t_time = max_t_time - 0.5
    cdef float current_temp = 0.0
    if time < min_t_time:
        midnight_temp=sin((0.0 + 0.25 - max_t_time) * 2.0 * _pi) * (max_temp_yesterday - min_temp_yesterday) / 2.0 + ((max_temp_yesterday + min_temp_yesterday) / 2.0)
        t_scale=(min_t_time - time) / min_t_time
        if t_scale > 1.0:
            t_scale=1.0
        elif t_scale < 0.0:
            t_scale=0.0
        current_temp=tmin + (t_scale * (midnight_temp - tmin))
        return current_temp
    else:
        current_temp=sin((time + 0.25 - max_t_time) * 2.0 * _pi) * (tmax - tmin) / 2.0 + t2m
        return current_temp
    return current_temp
