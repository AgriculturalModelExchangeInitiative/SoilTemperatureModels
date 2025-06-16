def ValuesInArray(floatarray Values,
         float MissingValue):
    cdef float Value 
    if Values is not None:
        for Value in Values:
            if Value != MissingValue and not isnan(Value):
                return True
    return False