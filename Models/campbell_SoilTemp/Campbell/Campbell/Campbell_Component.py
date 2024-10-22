# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

#%%CyML Model Begin%%
from Campbell.campbell import model_campbell

def model_SoilTempCampbell(NLAYR: int,
    THICK: 'Array[float]',
    DEPTH: 'Array[float]',
    CONSTANT_TEMPdepth:float,
    BD: 'Array[float]',
    T2M: float,
    TMAX: float,
    TMIN: float,
    TAV: float,
    TAMP: float,
    XLAT: float,
    CLAY: 'Array[float]',
    SW: 'Array[float]',
    DOY: int,
    airPressure: float,
    canopyHeight: float,
    SALB: float,
    SRAD: float,
    ESP: float,
    ES: float,
    EOAD: float,  
    soilTemp: 'Array[float]',
    newTemperature: 'Array[float]',
    minSoilTemp: 'Array[float]',
    maxSoilTemp: 'Array[float]',
    aveSoilTemp: 'Array[float]',
    morningSoilTemp: 'Array[float]',
    thermalCondPar1: 'Array[float]',
    thermalCondPar2: 'Array[float]',
    thermalCondPar3: 'Array[float]',
    thermalCondPar4: 'Array[float]',
    thermalConductivity: 'Array[float]',
    thermalConductance: 'Array[float]',
    heatStorage: 'Array[float]',
    volSpecHeatSoil: 'Array[float]',
    maxTempYesterday: float,
    minTempYesterday: float,
    instrumentHeight:float,
    boundaryLayerConductanceSource:str,
    netRadiationSource:str,
    windSpeed:float,
    SLCARB:'Array[float]',
    SLROCK:'Array[float]',
    SLSILT:'Array[float]',
    SLSAND:'Array[float]',
    _boundaryLayerConductance:float
    ):
    """
    - Name: model_SoilTempCampbell
    - Version: 1.0
    - Time step: 1
    - Description:
                * Title: SoilTemperature model from Campbell implemented in APSIM
                * Author: Teiki Raihauti and Christophe Pradal
                * Reference: Campbell model (TODO)
                * Institution: CIRAD and INRAE
                * ExtendedDescription: TODO
                * ShortDescription: TODO
    - inputs: 
        * name: NLAYR
                    ** description : number of soil layers in profile
                    ** inputtype : parameter
                    ** parametercategory : constant
                    ** datatype : INT
                    ** max :
                    ** min : 1
                    ** default : 10
                    ** unit : dimensionless
        * name: THICK
                    ** description : APSIM soil layer depths as thickness of layers
                    ** inputtype : parameter
                    ** parametercategory : constant
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** max :
                    ** min : 1
                    ** default : 50
                    ** unit : mm 
        * name: DEPTH
                    ** description : APSIM node depths
                    ** inputtype : parameter
                    ** parametercategory : constant
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** max :
                    ** min : 
                    ** default : 
                    ** unit : m
        * name: BD
                    ** description : bd (soil bulk density) is name of the APSIM var for bulk density so set bulkDensity = bd later
                    ** inputtype : parameter
                    ** parametercategory : constant
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** max :
                    ** min : 
                    ** default : 1.4
                    ** unit : g/cm3
        * name: T2M
                    ** description : Mean daily Air temperature
                    ** inputtype : variable
                    ** variablecategory : exogenous
                    ** datatype : DOUBLE
                    ** max : 60
                    ** min : -60
                    ** default :
                    ** unit : °C
        * name: TMAX
                    ** description : Max daily Air temperature
                    ** inputtype : variable
                    ** variablecategory : exogenous
                    ** datatype : DOUBLE
                    ** max : 60
                    ** min : -60
                    ** default :
                    ** unit : °C
        * name: TMIN
                    ** description : Min daily Air temperature
                    ** inputtype : variable
                    ** variablecategory : exogenous
                    ** datatype : DOUBLE
                    ** max : 60
                    ** min : -60
                    ** default :
                    ** unit : °C
        * name: TAV
                    ** description : Average daily Air temperature
                    ** inputtype : variable
                    ** variablecategory : exogenous
                    ** datatype : DOUBLE
                    ** max : 60
                    ** min : -60
                    ** default :
                    ** unit : °C
        * name: TAMP
                    ** description : Amplitude air temperature
                    ** inputtype : parameter
                    ** parametercategory : constant
                    ** datatype : DOUBLE
                    ** max : 100
                    ** min : -100
                    ** default :
                    ** unit : °C
        * name: XLAT
                    ** description : Latitude
                    ** inputtype : parameter
                    ** parametercategory : constant
                    ** datatype : DOUBLE
                    ** max : 
                    ** min :
                    ** default :
                    ** unit : °C
        * name: CLAY
                    ** description : Proportion of clay in each layer of profile
                    ** inputtype : parameter
                    ** parametercategory : constant
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** max : 100
                    ** min : 0
                    ** default : 50
                    ** unit : %
        * name: SW
                    ** description : volumetric water content
                    ** inputtype : variable
                    ** variablecategory : exogenous
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** max : 1
                    ** min : 0
                    ** default : 0.5
                    ** unit : cc water / cc soil
        * name: DOY
                    ** description : Day of year
                    ** inputtype : variable
                    ** variablecategory : exogenous
                    ** datatype : INT
                    ** max : 366
                    ** min : 1
                    ** default : 1
                    ** unit : dimensionless
        * name: airPressure
                    ** description : Air pressure
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLE
                    ** max : 
                    ** min : 
                    ** default : 1010
                    ** unit : hPA
        * name: canopyHeight
                    ** description : height of canopy above ground
                    ** inputtype : variable
                    ** variablecategory : exogenous
                    ** datatype : DOUBLE
                    ** max : 
                    ** min : 0
                    ** default : 0.057
                    ** unit : m
        * name: SALB
                    ** description : Soil albedo
                    ** inputtype : parameter
                    ** parametercategory : constant
                    ** datatype : DOUBLE
                    ** max : 1
                    ** min : 0
                    ** default : 
                    ** unit : dimensionless
        * name: SRAD
                    ** description : Solar radiation
                    ** inputtype : variable
                    ** variablecategory : exogenous
                    ** datatype : DOUBLE
                    ** max : 
                    ** min : 0
                    ** default : 
                    ** unit : MJ/m2
        * name: ESP
                    ** description : Potential evaporation
                    ** inputtype : variable
                    ** variablecategory : exogenous
                    ** datatype : DOUBLE
                    ** max : 
                    ** min : 0
                    ** default : 
                    ** unit : mm
        * name: ES
                    ** description : Actual evaporation
                    ** inputtype : variable
                    ** variablecategory : exogenous
                    ** datatype : DOUBLE
                    ** max : 
                    ** min : 0
                    ** default : 
                    ** unit : mm
        * name: EOAD
                    ** description : Potential evapotranspiration
                    ** inputtype : variable
                    ** variablecategory : exogenous
                    ** datatype : DOUBLE
                    ** max : 
                    ** min : 0
                    ** default : 
                    ** unit : mm
        * name: soilTemp
                    ** description :  Temperature at end of last time-step within a day - midnight in layers
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** default :
                    ** min : -60.
                    ** max : 60.
                    ** unit : degC
                    ** uri : 
        * name: newTemperature
                    ** description : Soil temperature at the end of one iteration
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : -60.
                    ** max : 60.
                    ** unit : degC
                    ** uri : 
        * name: minSoilTemp
                    ** description : Minimum soil temperature in layers
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : -60.
                    ** max : 60.
                    ** unit : degC
                    ** uri : 
        * name: maxSoilTemp
                    ** description :  Maximum soil temperature in layers
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : -60.
                    ** max : 60.
                    ** unit : degC
                    ** uri : 
        * name: aveSoilTemp
                    ** description : Temperature averaged over all time-steps within a day in layers.
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : -60.
                    ** max : 60.
                    ** unit : degC
                    ** uri : 
        * name: morningSoilTemp
                    ** description : Temperature  in the morning in layers.
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : -60.
                    ** max : 60.
                    ** unit : degC
                    ** uri : 
        * name: thermalCondPar1
                    ** description : thermal conductivity coeff in layers
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** default : 
                    ** min : 
                    ** max : 
                    ** unit : (W/m2/K)
                    ** uri : 
        * name: thermalCondPar2
                    ** description : thermal conductivity coeff in layers
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** default : 
                    ** min : 
                    ** max : 
                    ** unit : (W/m2/K)
                    ** uri : 
        * name: thermalCondPar3
                    ** description : thermal conductivity coeff in layers
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** default : 
                    ** min : 
                    ** max : 
                    ** unit : (W/m2/K)
                    ** uri : 
        * name: thermalCondPar4
                    ** description : thermal conductivity coeff in layers
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** default : 
                    ** min : 
                    ** max : 
                    ** unit : (W/m2/K)
                    ** uri :
        * name: thermalConductivity
                    ** description : thermal conductivity in layers
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : 
                    ** max : 
                    ** unit : (W/m2/K)
                    ** uri : 
        * name: thermalConductance
                    ** description : Thermal conductance between layers 
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : 
                    ** max : 
                    ** unit : (W/m2/K)
                    ** uri : 
        * name: heatStorage
                    ** description : Heat storage between layers (internal)
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : 
                    ** max : 
                    ** unit : J/s/K
                    ** uri : 
        * name: volSpecHeatSoil
                    ** description : Volumetric specific heat over the soil profile
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : 
                    ** max : 
                    ** unit : J/K/m3
                    ** uri : 
        * name: maxTempYesterday
                    ** description : Air max temperature from previous day
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLE
                    ** default : 
                    ** min : -60
                    ** max : 60
                    ** unit : °C
                    ** uri : 
        * name: minTempYesterday
                    ** description : Air min temperature from previous day
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLE
                    ** default : 
                    ** min : -60
                    ** max : 60
                    ** unit : °C
                    ** uri : 
        * name: instrumentHeight
                    ** description : Default instrument height
                    ** inputtype : parameter
                    ** parametercategory : constant
                    ** datatype : DOUBLE
                    ** default : 1.2
                    ** min : 0
                    ** max : 
                    ** unit : m
                    ** uri : 
        * name: boundarLayerConductanceSource
                    ** description : Flag whether boundary layer conductance is calculated or gotten from input
                    ** inputtype : parameter
                    ** parametercategory : constant
                    ** datatype : STRING
                    ** max : 
                    ** min : 
                    ** default : calc
                    ** unit : dimensionless
        * name: netRadiationSource
                    ** description : Flag whether net radiation is calculated or gotten from input
                    ** inputtype : parameter
                    ** parametercategory : constant
                    ** datatype : STRING
                    ** max : 
                    ** min : 
                    ** default : calc
                    ** unit : dimensionless
        * name: windSpeed
                    ** description : Speed of wind
                    ** inputtype : variable
                    ** variablecategory : exogenous
                    ** datatype : DOUBLE
                    ** default : 3.0
                    ** min : 0.0
                    ** max : 
                    ** unit : m/s
                    ** uri :
        * name: SLCARB
                    ** description : Volumetric fraction of organic matter in the soil
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : 
                    ** max : 
                    ** unit : %
                    ** uri : 
        * name: SLROCK
                    ** description : Volumetric fraction of rocks in the soil
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : 
                    ** max : 
                    ** unit : %
                    ** uri : 
        * name: SLSILT
                    ** description : Volumetric fraction of silt in the soil
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : 
                    ** max : 
                    ** unit : %
                    ** uri : 
        * name: SLSAND
                    ** description : Volumetric fraction of sand in the soil
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLEARRAY
                    ** len : NLAYR
                    ** min : 
                    ** max : 
                    ** unit : %
                    ** uri : 
        * name: _boundaryLayerConductance
                    ** description : Boundary layer conductance
                    ** inputtype : variable
                    ** variablecategory : state
                    ** datatype : DOUBLE
                    ** min : 
                    ** max : 
                    ** unit : K/W
                    ** uri : 
    - outputs: 
                * name: soilTemp
                           ** description :  Temperature at end of last time-step within a day - midnight in layers
                           ** variablecategory : state
                           ** datatype : DOUBLEARRAY
                           ** len : NLAYR
                           ** default :
                           ** min : -60.
                           ** max : 60.
                           ** unit : degC
                           ** uri : 
                * name: newTemperature
                            ** description : Soil temperature at the end of one iteration
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: minSoilTemp
                            ** description : Minimum soil temperature in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: maxSoilTemp
                            ** description :  Maximum soil temperature in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: aveSoilTemp
                            ** description : Temperature averaged over all time-steps within a day in layers.
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: morningSoilTemp
                            ** description : Temperature  in the morning in layers.
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: airPressure
                           ** description : Air pressure
                           ** variablecategory : state
                           ** datatype : DOUBLE
                           ** max : 
                           ** min : 
                           ** default : 1010
                           ** unit : hPA
                * name: thermalCondPar1
                           ** description : thermal conductivity coeff in layers
                           ** variablecategory : state
                           ** datatype : DOUBLEARRAY
                           ** len : NLAYR
                           ** default : 
                           ** min : 
                           ** max : 
                           ** unit : (W/m2/K)
                           ** uri : 
                * name: thermalCondPar2
                           ** description : thermal conductivity coeff in layers
                           ** variablecategory : state
                           ** datatype : DOUBLEARRAY
                           ** len : NLAYR
                           ** default : 
                           ** min : 
                           ** max : 
                           ** unit : (W/m2/K)
                           ** uri : 
                * name: thermalCondPar3
                           ** description : thermal conductivity coeff in layers
                           ** variablecategory : state
                           ** datatype : DOUBLEARRAY
                           ** len : NLAYR
                           ** default : 
                           ** min : 
                           ** max : 
                           ** unit : (W/m2/K)
                           ** uri : 
                * name: thermalCondPar4
                           ** description : thermal conductivity coeff in layers
                           ** variablecategory : state
                           ** datatype : DOUBLEARRAY
                           ** len : NLAYR
                           ** default : 
                           ** min : 
                           ** max : 
                           ** unit : (W/m2/K)
                           ** uri :
                * name: thermalConductivity
                            ** description : thermal conductivity in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : 
                            ** max : 
                            ** unit : (W/m2/K)
                            ** uri : 
                * name: thermalConductance
                            ** description : Thermal conductance between layers 
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : 
                            ** max : 
                            ** unit : (W/m2/K)
                            ** uri : 
                * name: heatStorage
                            ** description : Heat storage between layers (internal)
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : 
                            ** max : 
                            ** unit : J/s/K
                            ** uri : 
                * name: volSpecHeatSoil
                            ** description : Volumetric specific heat over the soil profile
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : 
                            ** max : 
                            ** unit : J/K/m3
                            ** uri : 
                * name: maxTempYesterday
                           ** description : Air max temperature from previous day
                           ** variablecategory : state
                           ** datatype : DOUBLE
                           ** default : 
                           ** min : -60
                           ** max : 60
                           ** unit : °C
                           ** uri : 
                * name: minTempYesterday
                           ** description : Air min temperature from previous day
                           ** variablecategory : state
                           ** datatype : DOUBLE
                           ** default : 
                           ** min : -60
                           ** max : 60
                           ** unit : °C
                           ** uri : 
                * name: SLCARB
                            ** description : Volumetric fraction of organic matter in the soil
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : 
                            ** max : 
                            ** unit : %
                            ** uri : 
                * name: SLROCK
                            ** description : Volumetric fraction of rocks in the soil
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : 
                            ** max : 
                            ** unit : %
                            ** uri : 
                * name: SLSILT
                            ** description : Volumetric fraction of silt in the soil
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : 
                            ** max : 
                            ** unit : %
                            ** uri : 
                * name: SLSAND
                            ** description : Volumetric fraction of sand in the soil
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** len : NLAYR
                            ** min : 
                            ** max : 
                            ** unit : %
                            ** uri : 
                * name: _boundaryLayerConductance
                            ** description : Boundary layer conductance
                            ** variablecategory : state
                            ** datatype : DOUBLE
                            ** min : 
                            ** max : 
                            ** unit : K/W
                            ** uri : 
    """
    #%%CyML Compute Begin%%
    # soilTemp: 'Array[float]' = []
    # minSoilTemp: 'Array[float]' = []
    # maxSoilTemp: 'Array[float]' = []
    # aveSoilTemp: 'Array[float]' = []
    # morningSoilTemp: 'Array[float]' = []
    # newTemperature: 'Array[float]' = []
    # maxTempYesterday: float
    # minTempYesterday: float
    # thermalCondPar1: 'Array[float]' = []
    # thermalCondPar2: 'Array[float]' = []
    # thermalCondPar3: 'Array[float]' = []
    # thermalCondPar4: 'Array[float]' = []
    # thermalConductivity: 'Array[float]' = []
    # thermalConductance: 'Array[float]' = []
    # heatStorage: 'Array[float]' = []
    # volSpecHeatSoil: 'Array[float]' = []
    # boundaryLayerConductance:float
    # thickness: 'Array[float]' = []
    # depth: 'Array[float]' = []
    # bulkDensity: 'Array[float]' = []
    # soilW: 'Array[float]' = []
    # clay: 'Array[float]' = []
    # rocks: 'Array[float]' = []
    # carbon: 'Array[float]' = []
    # silt: 'Array[float]' = []
    # sand: 'Array[float]' = []
    # airPressure:float

    (soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp,
        morningSoilTemp, newTemperature, maxTempYesterday, minTempYesterday, thermalCondPar1, thermalCondPar2, 
        thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, 
        heatStorage, volSpecHeatSoil, _boundaryLayerConductance, THICK, DEPTH, BD, SW, CLAY,
        SLROCK, SLCARB, SLSAND, SLSILT, airPressure) = model_campbell(NLAYR, THICK, DEPTH, CONSTANT_TEMPdepth, BD, 
                                                T2M, TMAX, TMIN, TAV, TAMP, XLAT, 
                                                CLAY, SW, DOY, airPressure, 
                                                canopyHeight, SALB, SRAD, ESP, ES, 
                                                EOAD, soilTemp, newTemperature, minSoilTemp, maxSoilTemp, aveSoilTemp,
                                                morningSoilTemp,thermalCondPar1, thermalCondPar2, thermalCondPar3, 
                                                thermalCondPar4, thermalConductivity, thermalConductance, 
                                                heatStorage, volSpecHeatSoil, maxTempYesterday, minTempYesterday, 
                                                instrumentHeight, boundaryLayerConductanceSource, 
                                                netRadiationSource, windSpeed, SLCARB, SLROCK, SLSILT, SLSAND, _boundaryLayerConductance)

    #%%CyML Compute End%%
    return (soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp,
        morningSoilTemp, newTemperature, maxTempYesterday, minTempYesterday, thermalCondPar1, thermalCondPar2, 
        thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, 
        heatStorage, volSpecHeatSoil, _boundaryLayerConductance, THICK, DEPTH, BD, SW, CLAY,
        SLROCK, SLCARB, SLSAND, SLSILT, airPressure)
#%%CyML Model End%%