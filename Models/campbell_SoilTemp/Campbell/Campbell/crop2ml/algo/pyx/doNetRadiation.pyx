def doNetRadiation(floatarray solarRadn,
         float cloudFr,
         float cva,
         int ITERATIONSperDAY,
         int doy,
         float rad,
         float tmin,
         float latitude):
    cdef float piVal = 3.141592653589793
    cdef float TSTEPS2RAD = 1.0
    cdef float SOLARconst = 1.0
    cdef float solarDeclination = 1.0
    cdef float m1[]
    m1=[0.] * (ITERATIONSperDAY + 1)
    TSTEPS2RAD=Divide(2.0 * piVal, float(ITERATIONSperDAY), 0.0)
    SOLARconst=1360.0
    solarDeclination=0.3985 * sin((4.869 + (doy * 2.0 * piVal / 365.25) + (0.03345 * sin((6.224 + (doy * 2.0 * piVal / 365.25))))))
    cdef float cD = sqrt(1.0 - (solarDeclination * solarDeclination))
    cdef float m1Tot = 0.0
    cdef float psr 
    cdef int timestepNumber = 1
    cdef float fr 
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        m1[timestepNumber]=(solarDeclination * sin(latitude * piVal / 180.0) + (cD * cos(latitude * piVal / 180.0) * cos(TSTEPS2RAD * (float(timestepNumber) - (float(ITERATIONSperDAY) / 2.0))))) * 24.0 / float(ITERATIONSperDAY)
        if m1[timestepNumber] > 0.0:
            m1Tot=m1Tot + m1[timestepNumber]
        else:
            m1[timestepNumber]=0.0
    psr=m1Tot * SOLARconst * 3600.0 / 1000000.0
    fr=Divide(max(rad, 0.1), psr, 0.0)
    cloudFr=2.33 - (3.33 * fr)
    cloudFr=min(max(cloudFr, 0.0), 1.0)
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        solarRadn[timestepNumber]=max(rad, 0.1) * Divide(m1[timestepNumber], m1Tot, 0.0)
    cdef float kelvinTemp = kelvinT(tmin)
    cva=exp((31.3716 - (6014.79 / kelvinTemp) - (0.00792495 * kelvinTemp))) / kelvinTemp
    return (solarRadn, cloudFr, cva)

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue

def kelvinT(float celciusT):
    cdef float ZEROTkelvin = 273.18
    cdef float res = celciusT + ZEROTkelvin
    return res
