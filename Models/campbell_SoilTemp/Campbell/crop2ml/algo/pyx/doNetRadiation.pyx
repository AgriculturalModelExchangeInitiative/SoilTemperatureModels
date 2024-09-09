def doNetRadiation(floatarray solarRadn,
         float cloudFr,
         float cva,
         int ITERATIONSperDAY,
         int doy,
         float rad,
         float tmin,
         float latitude):
    cdef float DAYSinYear = 365.25
    cdef float DAYhrs = 24.0
    cdef float MIN2SEC = 60.0
    cdef float HR2MIN = 60.0
    cdef float SEC2HR = 1.0 / (HR2MIN * MIN2SEC)
    cdef float DAYmins = DAYhrs * HR2MIN
    cdef float DAYsecs = DAYmins * MIN2SEC
    cdef float PA2HPA = 1.0 / 100.0
    cdef float MJ2J = 1000000.0
    cdef float J2MJ = 1.0 / MJ2J
    cdef float DEG2RAD = pi / 180.0
    cdef float DOY2RAD = DEG2RAD * 360.0 / DAYSinYear
    cdef float TSTEPS2RAD = Divide(DEG2RAD * 360., float(ITERATIONSperDAY), 0.0)
    cdef float SOLARconst = 1360.0
    cdef float solarDeclination = 0.3985 * sin((4.869 + (doy * DOY2RAD) + (0.03345 * sin((6.224 + (doy * DOY2RAD))))))
    cdef float cD = sqrt(1.0 - (solarDeclination * solarDeclination))
    cdef float m1[]
    cdef float m1Tot = 0.0
    cdef float W2MJ 
    cdef float psr 
    cdef int timestepNumber = 1
    for timestepNumber in range(1 , ITERATIONSperDAY + 1 , 1):
        m1[timestepNumber]=(solarDeclination * sin(latitude * DEG2RAD) + (cD * cos(latitude * DEG2RAD) * cos(TSTEPS2RAD * (float(timestepNumber) - (float(ITERATIONSperDAY) / 2.0))))) * 24.0 / float(ITERATIONSperDAY)
        if m1[timestepNumber] > 0.0:
            m1Tot=m1Tot + m1[timestepNumber]
        else:
            m1[timestepNumber]=0.0
    W2MJ=HR2MIN * MIN2SEC * J2MJ
    psr=m1Tot * SOLARconst * W2MJ
    cdef float fr 
    fr=Divide(max(rad, 0.1), psr, 0.0)
    cloudFr=2.33 - (3.33 * fr)
    if cloudFr < 0.0:
        cloudFr=0.0
    elif cloudFr > 1.0:
        cloudFr=1.0
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
    return celciusT + ZEROTkelvin
