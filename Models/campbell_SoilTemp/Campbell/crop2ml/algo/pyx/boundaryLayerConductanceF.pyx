def boundaryLayerConductanceF(floatarray TNew_zb,
         float tMean,
         float potE,
         float potET,
         float airPressure,
         float canopyHeight):
    cdef float VONK = 0.41
    cdef float GRAVITATIONALconst = 9.8
    cdef float CAPP = 1010.0
    cdef float EMISSIVITYsurface = 0.98
    cdef int SURFACEnode = 1
    cdef float STEFAN_BOLTZMANNconst = 5.67e-8
    cdef float windSpeed = 259.2
    cdef float instrumentHeight = 1.2
    cdef float SpecificHeatAir = CAPP * RhoA(tMean, airPressure)
    cdef float RoughnessFacMomentum = 0.13 * canopyHeight
    cdef float RoughnessFacHeat = 0.2 * RoughnessFacMomentum
    cdef float d = 0.77 * canopyHeight
    cdef float SurfaceTemperature = TNew_zb[SURFACEnode]
    cdef float PenetrationConstant = max(0.1, potE) / max(0.1, potET)
    cdef float radiativeConductance = 4.0 * STEFAN_BOLTZMANNconst * EMISSIVITYsurface * PenetrationConstant * pow(kelvinT(tMean), 3)
    cdef float FrictionVelocity = 0.0
    cdef float BoundaryLayerCond = 0.0
    cdef float StabilityParam = 0.0
    cdef float StabilityCorMomentum = 0.0
    cdef float StabilityCorHeat = 0.0
    cdef float HeatFluxDensity = 0.0
    cdef int iteration = 1
    for iteration in range(1 , 4 , 1):
        FrictionVelocity=Divide(windSpeed * VONK, log(Divide(instrumentHeight - d + RoughnessFacMomentum, RoughnessFacMomentum, 0.0)) + StabilityCorMomentum, 0.0)
        BoundaryLayerCond=Divide(SpecificHeatAir * VONK * FrictionVelocity, log(Divide(instrumentHeight - d + RoughnessFacHeat, RoughnessFacHeat, 0.0)) + StabilityCorHeat, 0.0)
        BoundaryLayerCond+=radiativeConductance
        HeatFluxDensity=BoundaryLayerCond * (SurfaceTemperature - tMean)
        StabilityParam=Divide(-VONK * instrumentHeight * GRAVITATIONALconst * HeatFluxDensity, SpecificHeatAir * kelvinT(tMean) * pow(FrictionVelocity, 3), 0.0)
        if StabilityParam > 0.0:
            StabilityCorHeat=4.7 * StabilityParam
            StabilityCorMomentum=StabilityCorHeat
        else:
            StabilityCorHeat=-2.0 * log((1.0 + sqrt(1.0 - (16.0 * StabilityParam))) / 2.0)
            StabilityCorMomentum=0.6 * StabilityCorHeat
    return BoundaryLayerCond

def RhoA(float temperature,
         float AirPressure):
    cdef float MWair = 0.02897
    cdef float RGAS = 8.3143
    cdef float HPA2PA = 100.0
    cdef float kelvinTemp = kelvinT(temperature)
    kelvinTemp=kelvinTemp * RGAS
    cdef float divide1 = MWair * AirPressure * HPA2PA
    cdef float res = Divide(MWair * AirPressure * HPA2PA, kelvinTemp, 0.0)
    return res

def kelvinT(float celciusT):
    cdef float ZEROTkelvin = 273.18
    return celciusT + ZEROTkelvin

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

def Divide(float val1,
         float val2,
         float errVal):
    cdef float returnValue = errVal
    if val2 != 0.0:
        returnValue=val1 / val2
    return returnValue
