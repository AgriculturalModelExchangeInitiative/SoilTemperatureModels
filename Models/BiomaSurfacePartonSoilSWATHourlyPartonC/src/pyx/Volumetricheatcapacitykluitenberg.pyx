import numpy 
from math import *
def model_volumetricheatcapacitykluitenberg(float VolumetricWaterContent[],
                                            float Sand[],
                                            float BulkDensity[],
                                            float OrganicMatter[],
                                            float HeatCapacity[],
                                            float Clay[],
                                            float Silt[]):
    """

    VolumetricHeatCapacityKluitenberg model
    Author: simone.bregaglio@unimi.it
    Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    Institution: University Of Milan
    ExtendedDescription: Strategy for the calculation of soil thermal diffusivity. Reference: J.M.H.Hendrickx, H. Xie, B. Borchers, J.B.J. Harrison, 2008. Global Prediction of Thermal Soil Regimes. SPIE Proceedings Volume 6953 Detection and Sensing of Mines, Explosive Objects, and Obscured Targets XIII.
    ShortDescription: None

    """
    cdef int i 
    cdef float SandFraction 
    cdef float SiltFraction 
    cdef float ClayFraction 
    cdef float FractionMinerals 
    cdef float OrganicMatterFraction 
    SandFraction=float(0)
    SiltFraction=float(0)
    ClayFraction=float(0)
    FractionMinerals=float(0)
    OrganicMatterFraction=float(0)
    for i in range(0 , len(HeatCapacity) , 1):
        SandFraction=Sand[i] / (Sand[i] + Silt[i] + Clay[i] + OrganicMatter[i])
        SiltFraction=Silt[i] / (Sand[i] + Silt[i] + Clay[i] + OrganicMatter[i])
        ClayFraction=Clay[i] / (Sand[i] + Silt[i] + Clay[i] + OrganicMatter[i])
        FractionMinerals=SandFraction + SiltFraction + ClayFraction
        OrganicMatterFraction=OrganicMatter[i] / (Sand[i] + Silt[i] + Clay[i] + OrganicMatter[i])
        HeatCapacity[i]=BulkDensity[i] * 0.73 * FractionMinerals + (BulkDensity[i] * 1.9 * OrganicMatterFraction) + (4.18 * VolumetricWaterContent[i])
    return  HeatCapacity


