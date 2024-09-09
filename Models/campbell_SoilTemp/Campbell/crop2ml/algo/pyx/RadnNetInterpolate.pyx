def RadnNetInterpolate(float solarRadn,
         float cloudFr,
         float cva,
         float potE,
         float potET,
         float tMean,
         float albedo,
         float gDt,
         floatarray soilTemp):
    cdef float EMISSIVITYsurface = 0.96
    cdef float MJ2J = 1000000.0
    cdef float J2MJ = 1.0 / MJ2J
    cdef int SURFACEnode = 1
    cdef float w2MJ = gDt * J2MJ
    cdef float emissivityAtmos = (1 - (0.84 * cloudFr)) * 0.58 * pow(cva, 1.0 / 7.0) + (0.84 * cloudFr)
    cdef float PenetrationConstant = Divide(max(0.1, potE), max(0.1, potET), 0.0)
    cdef float lwRinSoil = longWaveRadn(emissivityAtmos, tMean)
    lwRinSoil=lwRinSoil * PenetrationConstant * w2MJ
    cdef float lwRoutSoil = longWaveRadn(EMISSIVITYsurface, soilTemp[SURFACEnode]) * PenetrationConstant * w2MJ
    cdef float lwRnetSoil = lwRinSoil - lwRoutSoil
    cdef float swRin = solarRadn
    cdef float swRout = albedo * solarRadn
    cdef float swRnetSoil = (swRin - swRout) * PenetrationConstant
    return swRnetSoil + lwRnetSoil

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue

def longWaveRadn(float emissivity,
         float tDegC):
    cdef float STEFAN_BOLTZMANNconst = 5.67e-8
    cdef float kelvinTemp = kelvinT(tDegC)
    cdef float res = STEFAN_BOLTZMANNconst * emissivity * pow(kelvinTemp, 4)
    return res
