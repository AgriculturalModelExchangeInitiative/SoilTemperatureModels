# coding: utf8
"""
Standalone wrapper around soil temperature models

1. Run on a specific dataset
2. Generalised by reading parameters on other files
3. deocompose code into functions
4. Make a smulation based on queries

"""
import pandas as pd
from collections import OrderedDict 

from Campbell.campbell import init_campbell, model_campbell


#Weather arrays

#Soil metadata
soilID = "SICL"
albedo = 0.11
#numberLayer = 10
soilDepth = 210 * 0.01
bd = 1.36

#Site metadata
WST_ID = "USGA"
SITE_NAME = "Gainesville"
FL_LOC_1 = "USA"
XLAT = 29.652
XLONG = -82.325
TAMP = 21.8
TAV = 15.8

#Treatment
LAI = 2
AWC = 0.50
BIOMAS = 1800

# Treatment is one of SOIL_ID, WST_ID, AWC, LAID
SOIL_IDs = ['SICL', 'SILO', 'SALO', 'SAND']
WST_IDs = ['USGA', 'DEMU', 'COCA', 'FRLU', 'USMA', 'FRMO', 'CAQC']
AWCs = [0.0, 0.25, 0.5, 0.75, 1.0]
LAIDs = [0, 2, 7]

#Read all the weather daily values from file
def read_treatments(fn="InputData/Treatment.txt"):
    trt_df = pd.read_csv(fn, sep='\t', header=2)

    return trt_df

def read_one_treatment(trt_df, soil=SOIL_IDs[0], weather_station=WST_IDs[0], water_content=AWCs[0], LAI= LAIDs[0]):
    mask1 = trt_df.SOIL_ID==soil
    mask2 = trt_df.WST_ID==weather_station
    mask3 = trt_df.AWC==water_content
    mask4 = trt_df.LAID==LAI
    record = trt_df[mask1 & mask2 & mask3 & mask4]

    data = record.iloc[0]

    WST_DATASET = data.WST_DATASET
    AWC = water_content
    LAI = LAI
    soilID = soil

    weather_fn = f'InputData/WeatherData/{WST_DATASET}.WTH'
    weather = read_weather(weather_fn)
    soil_df = read_soil_layers()
    mask = soil_df.SOIL_ID==soilID
    my_soil = soil_df[mask]

    # TODO : albedo, AWC
    return weather, my_soil, AWC, LAI, XLAT 



def read_weather(fn="InputData/WeatherData/USGAL2AW0.50.WTH"):
    weather_df = pd.read_csv(fn, sep='\t')
    weather_df.DATE = pd.to_datetime(weather_df.DATE, format="%Y%j")

    return weather_df

def read_soil_layers(fn="InputData/SoilData.txt"):
    soil = pd.read_csv(fn, sep='\t', header=2)

    # Convert units
    soil.SLLB *= 0.01
    soil.THICK *= 10
    soil.SVSE *= 10**6

    soil['SLROCK'] = 0.
    soil['SLSAND'] = 15.
    soil['SLSILT'] = 35.

    return soil


#Read the soil layers values from file

def simulate(weather, soil_type, AWC, albedo, XLAT, TAMP, TAV, LAI):
    #weather = read_weather()
    #soil_type = read_soil_layers()

    #Soil metadata
    # treatment
    soilID = "SICL"
    #albedo = 0.11
    #numberLayer = 10
    soilDepth = 210 * 0.01
    bd = 1.36
    my_soil_type = soil_type
    #my_soil_type  = soil_type[soil_type.SOIL_ID == soilID]

    #Site metadata
    WST_ID = "USGA"
    SITE_NAME = "Gainesville"
    FL_LOC_1 = "USA"
    #XLAT = 29.652
    XLONG = -82.325
    #TAMP = 21.8
    #TAV = 15.8

    #Treatment
    #LAI = 2
    #AWC = 0.50
    BIOMAS = 1800    

    # Extract data from files / dataframes
    numberLayer = len(my_soil_type)
    SLLT = my_soil_type.SLLT.tolist()
    SLLB = my_soil_type.SLLB.tolist()
    THICK = my_soil_type.THICK.tolist()
    SLBDM = my_soil_type.SLBDM.tolist()
    SLOC = my_soil_type.SLOC.tolist()
    SLCLY = my_soil_type.SLCLY.tolist()
    SLROCK = my_soil_type.SLROCK.tolist()
    SLSILT = my_soil_type.SLSILT.tolist()
    SLSAND = my_soil_type.SLSAND.tolist()

    soilW = my_soil_type.SLLL + AWC * (my_soil_type.SLDUL - my_soil_type.SLLL)
    soilW = soilW.tolist()

    # Parameters
    CONSTANT_TEMPdepth:float = 10000.0
    airPressure:float = 1010.0
    canopyHeight:float = 0.057
    instrumentHeight: float = 1.2
    ES = 0.0
    boundaryLayerConductanceSource:str = 'calc'
    netRadiationSource:str = 'calc'
    windSpeed:float = 3.0


    # Read first row in weather data 
    weather_gen = weather.iterrows()

    # intial values
    (_, wi) = next(weather_gen) 

    (thickness, 
     depth, 
     bulkDensity, 
     clay, 
     soilWater, 
     soilTemp, 
     newTemperature, 
     minSoilTemp, 
     maxSoilTemp, 
     aveSoilTemp, 
     morningSoilTemp,
     thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, 
     thermalConductivity, thermalConductance, 
     heatStorage, volSpecHeatSoil, 
     maxTempYesterday,
     minTempYesterday, 
     carbon, rocks, silt, sand, 
     boundaryLayerConductance) = init_campbell(
        NLAYR=numberLayer,
        CONSTANT_TEMPdepth=CONSTANT_TEMPdepth, 
        T2M=wi.T2M,
        TMAX=wi.TMAX,
        TMIN=wi.TMIN,
        TAV=TAV,
        TAMP=TAMP,
        XLAT=XLAT,
        DOY=wi.DATE.dayofyear,
        canopyHeight=canopyHeight,
        SALB=albedo,
        SRAD=wi.SRAD,
        ESP=wi.ESP,
        ES=ES,
        EOAD=wi.EOAD,
        instrumentHeight=instrumentHeight, 
        THICK=THICK,
        BD=SLBDM, 
        SLCARB=SLOC, 
        CLAY=SLCLY, 
        SLROCK=SLROCK, 
        SLSILT=SLSILT, 
        SLSAND=SLSAND,
        SW=soilW, 
        airPressure=airPressure, 
        boundaryLayerConductanceSource=boundaryLayerConductanceSource,
        netRadiationSource=netRadiationSource, 
        windSpeed=windSpeed)
    
    # TODO : check why we have negative values...
    print(soilTemp)

    # Outputs
    columns = "Date SLLT SLLB TSLD TSLX TSLN Layer".split()
    Dates = []
    SLLTs = []
    SLLBs = []
    TSLDs = []
    TSLXs = []
    TSLNs = []
    Layers = []
    
    nb_days = 300

    count = 0
    
    for i, wi in weather.iterrows():
        if count == nb_days:
            break
        else:
            count += 1


        # Call the model
        (soilTemp, 
         minSoilTemp, 
         maxSoilTemp, 
         aveSoilTemp,
         morningSoilTemp, 
         newTemperature, 
         maxTempYesterday, 
         minTempYesterday, 
         thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, 
         thermalConductivity, thermalConductance, 
         heatStorage, 
         volSpecHeatSoil, 
         boundaryLayerConductance, 
         thickness, 
         depth, 
         bulkDensity, 
         soilWater, 
         clay,
         rocks, 
         carbon, 
         sand, 
         silt) = model_campbell(
             NLAYR=numberLayer,
             CONSTANT_TEMPdepth=CONSTANT_TEMPdepth, 
             T2M=wi.T2M, TMAX=wi.TMAX, TMIN=wi.TMIN,
             TAV=TAV, TAMP=TAMP, XLAT=XLAT,
             DOY=wi.DATE.dayofyear,
             airPressure=airPressure, canopyHeight=canopyHeight, SALB=albedo,
             SRAD=wi.SRAD, ESP=wi.ESP, ES=ES, EOAD=wi.EOAD,
             instrumentHeight=instrumentHeight,
             boundaryLayerConductanceSource=boundaryLayerConductanceSource,
             netRadiationSource=netRadiationSource, windSpeed=windSpeed,
             THICKApsim=thickness, 
             DEPTHApsim =depth, 
             BDApsim=bulkDensity, 
             SLCARBApsim=carbon, 
             CLAYApsim=clay, 
             SLROCKApsim=rocks, 
             SLSILTApsim=silt, 
             SLSANDApsim=sand, 
             SWApsim=soilWater,
             soilTemp=soilTemp, 
             minSoilTemp=minSoilTemp, maxSoilTemp=maxSoilTemp, aveSoilTemp=aveSoilTemp,
             morningSoilTemp=morningSoilTemp, 
             newTemperature=newTemperature, 
             maxTempYesterday=maxTempYesterday, minTempYesterday=minTempYesterday, 
             thermalCondPar1=thermalCondPar1,
             thermalCondPar2=thermalCondPar2, 
             thermalCondPar3=thermalCondPar3, 
             thermalCondPar4=thermalCondPar4, 
             thermalConductivity=thermalConductivity, 
             thermalConductance=thermalConductance, heatStorage=heatStorage, 
             volSpecHeatSoil=volSpecHeatSoil, 
             _boundaryLayerConductance=boundaryLayerConductance, 
             THICK=THICK, 
             BD=SLBDM,
             SLCARB=SLOC, 
             CLAY=SLCLY, 
             SLROCK=SLROCK, 
             SLSILT=SLSILT, 
             SLSAND=SLSAND, 
             SW=soilW)  

        # Store the outputs
        date_formattee = wi.DATE.strftime("%Y-%m-%d")
        Dates.append(date_formattee); SLLTs.append(0); SLLBs.append(0); TSLDs.append(aveSoilTemp[1]); TSLXs.append(maxSoilTemp[1]); TSLNs.append(minSoilTemp[1]); Layers.append(1)
        for j in range(2, numberLayer+2):
            Dates.append(date_formattee); SLLTs.append(int(SLLT[j-2])); SLLBs.append(int(SLLB[j-2]*100)); TSLDs.append(aveSoilTemp[j]); TSLXs.append(maxSoilTemp[j]); TSLNs.append(minSoilTemp[j]); Layers.append(j)


    df = pd.DataFrame( OrderedDict(
            Date = Dates,
            SLLT = SLLTs,
            SLLB = SLLBs,
            TSLD = TSLDs,
            TSLX = TSLXs,
            TSLN = TSLNs,
            Layer =Layers            
            ),
            columns=columns)
    return df


if __name__ == "__main__":
    trt_df = read_treatments()
    weather, my_soil, AWC, LAI, XLAT = read_one_treatment(trt_df)
    df = simulate(weather, my_soil,
                  AWC, albedo, XLAT, TAMP, TAV, LAI)
