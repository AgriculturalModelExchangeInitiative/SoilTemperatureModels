import numpy 
from math import *
def model_thermaldiffu(float ThermalDiffusivity[],
                       float ThermalConductivity[],
                       float HeatCapacity[]):
    """

    ThermalDiffu model
    Author: simone.bregaglio@unimi.it
    Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    Institution: University Of Milan
    ExtendedDescription: Strategy for the calculation of thermal diffusitivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series #5: Madison, Wisconsin. p. 1209-1226. Diekkruger, B. (1996) SIMULAT - Ein Modellsystem zur Berechnung der Wasser- und Stoffdynamik landwirtschaftlich genutzter Standorte (SIMULAT - a model system for the calculation of water and matter dynamics on agricultural sites, in German). In: Wasser- und Stoffdynamik in AgrarÃ´kosystemen, Sonderf.
    ShortDescription: None

    """
    cdef int i 
    for i in range(0 , len(ThermalDiffusivity) , 1):
        ThermalDiffusivity[i]=ThermalConductivity[i] / HeatCapacity[i] / 100
    return  ThermalDiffusivity


