def doVolumetricSpecificHeat(floatarray soilW,
         floatarray bulkDensity,
         int numLayers):
    cdef float SPECIFICbd = 2.65
    cdef float volSpecHeatClay = 2.39e6
    cdef float volSpecHeatWater = 4.18e6
    cdef float volSpecHeatSoil[]
    cdef int layer 
    for layer in range(1 , numLayers + 1 , 1):
        cdef float solidity = bulkDensity[layer] / SPECIFICbd
        volSpecHeatSoil[layer]=volSpecHeatClay * solidity + (volSpecHeatWater * soilW[layer])
    volSpecHeatSoil[0]=volSpecHeatSoil[1]
    return volSpecHeatSoil
