def Zero(floatarray arr):
    cdef int i = 0
    for i in range(0 , len(arr) , 1):
        arr[i]=0.
    return arr
