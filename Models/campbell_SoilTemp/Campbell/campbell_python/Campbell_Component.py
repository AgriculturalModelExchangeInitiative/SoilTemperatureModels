# coding: utf8
from copy import copy
from array import array
from math import *
from typing import *
from datetime import datetime

#%%CyML Model Begin%%
from Campbell.campbell import model_campbell

def model_SoilTempCampbell(NLAYR: int,
                               THICK:'Array[float]',
                               BD: 'Array[float]',
    SLCARB:'Array[float]',
    CLAY: 'Array[float]',
    SLROCK:'Array[float]',
    SLSILT:'Array[float]',
    SLSAND:'Array[float]',
    SW: 'Array[float]',
    THICKApsim: 'Array[float]',
    DEPTHApsim: 'Array[float]',
    CONSTANT_TEMPdepth:float,
    BDApsim: 'Array[float]',
    T2M: float,
    TMAX: float,
    TMIN: float,
    TAV: float,
    TAMP: float,
    XLAT: float,
    CLAYApsim: 'Array[float]',
    SWApsim: 'Array[float]',
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
    SLCARBApsim:'Array[float]',
    SLROCKApsim:'Array[float]',
    SLSILTApsim:'Array[float]',
    SLSANDApsim:'Array[float]',
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
        * name: CONSTANT_TEMPdepth
               ** description : Depth of constant temperature
               ** inputtype : parameter
               ** parametercategory : constant
               ** datatype : DOUBLE
               ** max :
               ** min :
               ** default : 1000.0
               ** unit : mm
         * name: THICK
               ** description : Soil layer depths as THICKApsim of layers
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 1
               ** default : 50
               ** unit : mm
               ** uri :
        * name: THICKApsim
               ** description : APSIM soil layer depths as THICKApsim of layers
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 1
               ** default : 50
               ** unit : mm
               ** uri :
        * name: DEPTH
               ** description : node depths
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 
               ** default : 
               ** unit : m
               ** uri :
        * name: DEPTHApsim
               ** description : Apsim node depths
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 
               ** default : 
               ** unit : m
               ** uri :
        * name: BD
               ** description : bd (soil bulk density) 
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 
               ** default : 1.4
               ** unit : g/cm3
               uri :
        * name: BDApsim
               ** description : Apsim bd (soil bulk density) 
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 
               ** default : 1.4
               ** unit : g/cm3
               uri :
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
               ** description : Proportion of CLAYApsim in each layer of profile
               ** inputtype : variable
               ** variablecategory : exogenous
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max : 100
               ** min : 0
               ** default : 50
               ** unit : %
               ** uri :
        * name: CLAYApsim
               ** description : Apsim proportion of CLAYApsim in each layer of profile
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max : 100
               ** min : 0
               ** default : 50
               ** unit : %
               ** uri :
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
               ** uri :
        * name: SWApsim
               ** description : Apsim volumetric water content
               ** inputtype : variable
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max : 1
               ** min : 0
               ** default : 0.5
               ** unit : cc water / cc soil
               ** uri :
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
               ** variablecategory : exogenous
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
                ** default :
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
                ** default :
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
                ** default :
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
                ** default :
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
                ** default :
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
                ** default :
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
                ** default :
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
                ** default :
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
                ** default :
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
        * name: boundaryLayerConductanceSource
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
                ** variablecategory : exogenous
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLCARBApsim
                ** description : Volumetric fraction of organic matter in the soil
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLROCK
                ** description : Volumetric fraction of SLROCKApsim in the soil
                ** inputtype : variable
                ** variablecategory : exogenous
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLROCKApsim
                ** description : Volumetric fraction of SLROCKApsim in the soil
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLSILT
                ** description : Volumetric fraction of SLSILTApsim in the soil
                ** inputtype : variable
                ** variablecategory : exogenous
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLSILTApsim
                ** description : Volumetric fraction of SLSILTApsim in the soil
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : %
                ** uri :
        * name: SLSAND
                ** description : Volumetric fraction of SLSANDApsim in the soil
                ** inputtype : variable
                ** variablecategory : exogenous
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLSANDApsim
                ** description : Apsim volumetric fraction of SLSANDApsim in the soil
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** default :
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: _boundaryLayerConductance
                ** description : Boundary layer conductance
                ** inputtype : variable
                ** variablecategory : state
                ** datatype : DOUBLE
                ** default :
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
               ** unit : hPA
        * name: thermalCondPar1
               ** description : thermal conductivity coeff in layers
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** min : 
               ** max : 
               ** unit : (W/m2/K)
               ** uri : 
        * name: thermalCondPar2
               ** description : thermal conductivity coeff in layers
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** min : 
               ** max : 
               ** unit : (W/m2/K)
               ** uri : 
        * name: thermalCondPar3
               ** description : thermal conductivity coeff in layers
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** min : 
               ** max : 
               ** unit : (W/m2/K)
               ** uri : 
        * name: thermalCondPar4
               ** description : thermal conductivity coeff in layers
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
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
               ** min : -60
               ** max : 60
               ** unit : °C
               ** uri : 
        * name: minTempYesterday
               ** description : Air min temperature from previous day
               ** variablecategory : state
               ** datatype : DOUBLE
               ** min : -60
               ** max : 60
               ** unit : °C
               ** uri : 
        * name: SLCARBApsim
                ** description : Volumetric fraction of organic matter in the soil
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLROCKApsim
                ** description : Volumetric fraction of SLROCKApsim in the soil
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLSILTApsim
                ** description : Volumetric fraction of SLSILTApsim in the soil
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
        * name: SLSANDApsim
                ** description : Volumetric fraction of SLSANDApsim in the soil
                ** variablecategory : state
                ** datatype : DOUBLEARRAY
                ** len : NLAYR
                ** min : 
                ** max : 
                ** unit : %
                ** uri : 
         * name: THICKApsim
               ** description : APSIM soil layer depths as THICKApsim of layers
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 1
               ** unit : mm
               ** uri :
        * name: DEPTHApsim
               ** description : APSIM node depths
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 
               ** unit : m
               ** uri :
        * name: BDApsim
               ** description : bd (soil bulk density) is name of the APSIM var for bulk density so set BDApsim = bd later
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max :
               ** min : 
               ** unit : g/cm3
               uri :
        * name: CLAYApsim
               ** description : Proportion of CLAYApsim in each layer of profile
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max : 100
               ** min : 0
               ** unit : %
               ** uri :
        * name: SWApsim
               ** description : volumetric water content
               ** variablecategory : state
               ** datatype : DOUBLEARRAY
               ** len : NLAYR
               ** max : 1
               ** min : 0
               ** unit : cc water / cc soil
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

    (soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp,
        morningSoilTemp, newTemperature, maxTempYesterday, minTempYesterday, thermalCondPar1, thermalCondPar2, 
        thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, 
        heatStorage, volSpecHeatSoil, _boundaryLayerConductance, THICKApsim, DEPTHApsim, BDApsim, SWApsim, 
            CLAYApsim, SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim) = model_campbell(NLAYR, THICK, BD,
                                                                                            SLCARB,CLAY,SLROCK,
                                                                                            SLSILT,SLSAND,SW
                                                                                            ,THICKApsim, DEPTHApsim, CONSTANT_TEMPdepth, BDApsim, 
                                                T2M, TMAX, TMIN, TAV, TAMP, XLAT, 
                                                CLAYApsim, SWApsim, DOY, airPressure, 
                                                canopyHeight, SALB, SRAD, ESP, ES, 
                                                EOAD, soilTemp, newTemperature, minSoilTemp, maxSoilTemp, aveSoilTemp,
                                                morningSoilTemp,thermalCondPar1, thermalCondPar2, thermalCondPar3, 
                                                thermalCondPar4, thermalConductivity, thermalConductance, 
                                                heatStorage, volSpecHeatSoil, maxTempYesterday, minTempYesterday, 
                                                instrumentHeight, boundaryLayerConductanceSource, 
                                                netRadiationSource, windSpeed, SLCARBApsim, SLROCKApsim, 
                                                SLSILTApsim, SLSANDApsim, _boundaryLayerConductance)

    #%%CyML Compute End%%
    return (soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp,
        morningSoilTemp, newTemperature, maxTempYesterday, minTempYesterday, thermalCondPar1, thermalCondPar2, 
        thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, 
        heatStorage, volSpecHeatSoil, _boundaryLayerConductance, THICKApsim, DEPTHApsim, BDApsim, SWApsim, 
            CLAYApsim, SLROCKApsim, SLCARBApsim, SLSANDApsim, SLSILTApsim)
#%%CyML Model End%%