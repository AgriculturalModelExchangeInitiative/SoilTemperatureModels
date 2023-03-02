cdef int i 
cdef int h 
cdef float netRadiation 
cdef float ta 
cdef float Tmax 
cdef float k[]
cdef float kzero 
cdef float am 
cdef int step 
cdef float mc[]
cdef float c1[]
cdef float c2[]
cdef float c3[]
cdef float c4[]
cdef float bd 
cdef float flusso 
cdef float tn[]
cdef float T[]
cdef float a[]
cdef float b[]
cdef float c[]
cdef float d[]
cdef float g 
cdef int lSize 
cdef float depthProfile 
cdef int stratiAgg 
cdef float layTbefore[]
cdef float layBulkDensity[]
cdef float layClay[]
cdef float layLayerThickness[]
cdef float layVolumetricWaterContent[]
cdef float layTemperatureConductance[]
cdef float layHeatCapacity[]
cdef float laySoilTemperatureByLayers[]
cdef float tnzero 
cdef float Tzero 
netRadiation=float(0)
LatentHeatFlux=float(0)
lSize=len(LayerThickness)
depthProfile=float(0)
stratiAgg=0
layTbefore=array('f', [None]*lSize)
for i in range(0 , lSize , 1):
    depthProfile+=LayerThickness[i]
while depthProfile < DepthConstantSoilTemperature:
    stratiAgg=stratiAgg + 1
    depthProfile+=float(1)
layBulkDensity=array('f', [None]*stratiAgg)
layClay=array('f', [None]*stratiAgg)
layLayerThickness=array('f', [None]*stratiAgg)
layVolumetricWaterContent=array('f', [None]*stratiAgg)
layTemperatureConductance=array('f', [None]*stratiAgg)
layHeatCapacity=array('f', [None]*stratiAgg)
laySoilTemperatureByLayers=array('f', [None]*stratiAgg)
for i in range(0 , lSize , 1):
    layTbefore[i]=SoilTemperatureByLayers[i]
for i in range(0 , stratiAgg , 1):
    layVolumetricWaterContent[i]=VolumetricWaterContent[lSize - 1]
    layClay[i]=Clay[(lSize - 1)] / 100
    layBulkDensity[i]=BulkDensity[lSize - 1]
    layTemperatureConductance[i]=TemperatureConductance[lSize - 1]
    layHeatCapacity[i]=HeatCapacity[(lSize - 1)] / 1000
    laySoilTemperatureByLayers[i]=SoilTemperatureByLayers[lSize - 1]
    layLayerThickness[i]=float(1)
mc=array('f', [None]*lSize + stratiAgg)
c1=array('f', [None]*lSize + stratiAgg)
c2=array('f', [None]*lSize + stratiAgg)
c3=array('f', [None]*lSize + stratiAgg)
c4=array('f', [None]*lSize + stratiAgg)
a=array('f', [None]*lSize + 1 + stratiAgg)
b=array('f', [None]*lSize + 1 + stratiAgg)
c=array('f', [None]*lSize + 1 + stratiAgg)
d=array('f', [None]*lSize + 1 + stratiAgg)
k=array('f', [None]*lSize + 1 + stratiAgg)
tn=array('f', [None]*lSize + 1 + stratiAgg)
T=array('f', [None]*lSize + 1 + stratiAgg)
kzero=ThermalK
g=1 - ETA
Tmax=SurfaceTemperatureMaximum
ta=SurfaceSoilTemperature
netRadiation=NetRadiation
am=Tmax - ta
tn[lSize + stratiAgg]=BottomTemperature
for i in range(0 , lSize , 1):
    T[i]=SoilTemperatureByLayers[i]
    tn[i]=SoilTemperatureByLayers[i]
    SoilTemperatureByLayers[i]=float(0)
for i in range(0 , stratiAgg , 1):
    T[i + lSize]=laySoilTemperatureByLayers[i]
    tn[i + lSize]=laySoilTemperatureByLayers[i]
    laySoilTemperatureByLayers[i]=float(0)
Tzero=SoilTemperatureByLayers[0]
tnzero=SoilTemperatureByLayers[0]
for i in range(0 , lSize , 1):
    mc[i]=Clay[i] / 100
    bd=BulkDensity[i]
    c1[i]=0.65 - (0.78 * bd) + (0.6 * bd * bd)
    c2[i]=1.06 * bd
    c3[i]=1 + (2.6 / sqrt(mc[i]))
    c4[i]=0.3 + (0.1 * bd * bd)
for i in range(0 , stratiAgg , 1):
    mc[i]=layClay[i] / 100
    bd=layBulkDensity[i]
    c1[i + lSize]=0.65 - (0.78 * bd) + (0.6 * bd * bd)
    c2[i + lSize]=1.06 * bd
    c3[i + lSize]=1 + (2.6 / sqrt(mc[(i + lSize)]))
    c4[i + lSize]=0.3 + (0.1 * bd * bd)
step=86400 / int(Timestep)
for i in range(0 , lSize , 1):
    if i > 0:
        HeatCapacity[i]=(2400000 * BulkDensity[i] / 2.65 + (4180000 * VolumetricWaterContent[i])) * ((LayerThickness[i - 1] + LayerThickness[i]) / (2 * Timestep))
    else:
        HeatCapacity[i]=(2400000 * BulkDensity[i] / 2.65 + (4180000 * VolumetricWaterContent[i])) * (LayerThickness[i] / (2 * Timestep))
    TemperatureConductance[i]=(c1[i] + (c2[i] * VolumetricWaterContent[i]) - ((c1[i] - c4[i]) * exp(-pow((c3[i] * VolumetricWaterContent[i]), 4)))) / LayerThickness[i]
    k[i]=TemperatureConductance[i]
for i in range(0 , stratiAgg , 1):
    if i > 0:
        layHeatCapacity[i]=(2400000 * layBulkDensity[i] / 2.65 + (4180000 * layVolumetricWaterContent[i])) * ((layLayerThickness[i - 1] + layLayerThickness[i]) / (2 * Timestep))
    else:
        layHeatCapacity[i]=(2400000 * layBulkDensity[i] / 2.65 + (4180000 * layVolumetricWaterContent[i])) * (LayerThickness[(lSize - 1)] / (2 * Timestep))
    layTemperatureConductance[i]=(c1[i + lSize] + (c2[(i + lSize)] * layVolumetricWaterContent[i]) - ((c1[i + lSize] - c4[i + lSize]) * exp(-pow((c3[(i + lSize)] * layVolumetricWaterContent[i]), 4)))) / layLayerThickness[i]
    k[i + lSize]=layTemperatureConductance[i]
for h in range(0 , step , 1):
    tnzero=ta + (am * sin(0.261799 * (h * Timestep / 3600 - (6 * 3600 / Timestep))))
    for i in range(0 , lSize , 1):
        c[i]=-k[i] * ETA
        a[i + 1]=c[i]
        if i > 0:
            b[i]=ETA * (k[i] + k[i - 1]) + HeatCapacity[i]
            d[i]=g * k[(i - 1)] * T[(i - 1)] + ((HeatCapacity[i] - (g * (k[i] + k[i - 1]))) * T[i]) + (g * k[i] * T[(i + 1)])
        else:
            b[i]=ETA * (k[i] + kzero) + HeatCapacity[i]
            d[i]=g * kzero * Tzero + ((HeatCapacity[i] - (g * (k[i] + kzero))) * T[i]) + (g * k[i] * T[(i + 1)])
    for i in range(lSize , lSize + stratiAgg , 1):
        c[i]=-k[i] * ETA
        a[i + 1]=c[i]
        b[i]=ETA * (k[i] + k[i - 1]) + layHeatCapacity[i - lSize]
        d[i]=g * k[(i - 1)] * T[(i - 1)] + ((layHeatCapacity[i - lSize] - (g * (k[i] + k[i - 1]))) * T[i]) + (g * k[i] * T[(i + 1)])
    d[0]=d[0] + (kzero * tnzero * ETA) - netRadiation + LatentHeatFlux
    d[lSize - 1 + stratiAgg]=d[stratiAgg + lSize - 1] + (k[(stratiAgg + lSize - 1)] * ETA * tn[(stratiAgg + lSize)])
    for i in range(0 , lSize - 1 + stratiAgg , 1):
        c[i]=c[i] / b[i]
        d[i]=d[i] / b[i]
        b[i + 1]=b[i + 1] - (a[(i + 1)] * c[i])
        d[i + 1]=d[i + 1] - (a[(i + 1)] * d[i])
    tn[lSize - 1 + stratiAgg]=d[(lSize - 1 + stratiAgg)] / b[(lSize - 1 + stratiAgg)]
    for i in range(lSize - 2 + stratiAgg , -1 , -1):
        tn[i]=d[i] - (c[i] * tn[(i + 1)])
    flusso=kzero * (g * (Tzero - T[0]) + (ETA * (tnzero - tn[0])))
    for i in range(lSize - 1 , -1 , -1):
        T[i]=tn[i]
        SoilTemperatureByLayers[i]=SoilTemperatureByLayers[i] + tn[i]
    for i in range(stratiAgg - 1 , -1 , -1):
        T[i + lSize]=tn[i + lSize]
        laySoilTemperatureByLayers[i]=laySoilTemperatureByLayers[i] + tn[i + lSize]
    T[lSize + stratiAgg]=tn[lSize + stratiAgg]
    Tzero=tnzero
for i in range(0 , lSize , 1):
    SoilTemperatureByLayers[i]=SoilTemperatureByLayers[i] / step
    SoilTemperatureByLayersChange[i]=SoilTemperatureByLayers[i] - layTbefore[i]