def Zero(floatlist arr):
    cdef int I = 0
    for I in range(0 , len(arr) , 1):
        arr[I]=0.
    return arr
