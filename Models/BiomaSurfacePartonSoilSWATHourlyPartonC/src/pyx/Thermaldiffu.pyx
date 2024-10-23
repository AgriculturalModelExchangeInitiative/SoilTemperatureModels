import numpy
from math import *

def model_thermaldiffu(float ThermalDiffusivity[],
                       float ThermalConductivity[],
                       float HeatCapacity[],
                       int layersNumber):
    """
    ThermalDiffu model
    Author: simone.bregaglio
    Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    Institution: University Of Milan
    ExtendedDescription: Strategy for the calculation of thermal diffusitivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series
    ShortDescription: Strategy for the calculation of thermal diffusitivity
    """

    cdef int i 
    for i in range(0 , layersNumber , 1):
        ThermalDiffusivity[i]=ThermalConductivity[i] / HeatCapacity[i] / 100
    return  ThermalDiffusivity



