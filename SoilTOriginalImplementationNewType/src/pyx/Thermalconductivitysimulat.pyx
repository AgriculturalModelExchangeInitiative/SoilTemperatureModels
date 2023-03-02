import numpy 
from math import *
def model_thermalconductivitysimulat(float Clay[['array', 'double']],
                                     float VolumetricWaterContent[['array', 'double']],
                                     float BulkDensity[['array', 'double']]):
    """

    ThermalConductivitySIMULAT model
    Author: simone.bregaglio@unimi.it
    Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    Institution: University Of Milan
    ExtendedDescription: Strategy for the calculation of thermal conductivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series #5: Madison, Wisconsin. p. 1209-1226. Diekkruger, B. (1996) SIMULAT - Ein Modellsystem zur Berechnung der Wasser- und Stoffdynamik landwirtschaftlich genutzter Standorte (SIMULAT - a model system for the calculation of water and matter dynamics on agricultural sites, in German). In: Wasser- und Stoffdynamik in AgrarÃ´kosystemen, Sonderf.
    ShortDescription: None

    """
    cdef float ThermalConductivity[['array', 'double']]
    cdef int i 
    cdef float Aterm 
    cdef float Bterm 
    cdef float Cterm 
    cdef float Dterm 
    cdef float Eterm 
    Aterm=float(0)
    Bterm=float(0)
    Cterm=float(0)
    Dterm=float(0)
    Eterm=float(4)
    for i in range(0 , len(VolumetricWaterContent) , 1):
        Aterm=0.65 - (0.78 * BulkDensity[i]) + (0.6 * pow(BulkDensity[i], 2))
        Bterm=1.06 * BulkDensity[i] * VolumetricWaterContent[i]
        Cterm=1 + (2.6 * sqrt(Clay[i] / 100))
        Dterm=0.03 + (0.1 * pow(BulkDensity[i], 2))
        ThermalConductivity[i]=Aterm + (Bterm * VolumetricWaterContent[i]) - ((Aterm - Dterm) * pow(exp(-(Cterm * VolumetricWaterContent[i])), Eterm))
    return  ThermalConductivity


