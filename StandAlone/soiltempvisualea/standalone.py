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
#soilID = "SICL"
#numberLayer = 10
#soilDepth = 210 * 0.01
#bd = 1.36

# albedo = 0.11 #TODO

#Site metadata
#WST_ID = "USGA" #TODO
#SITE_NAME = "Gainesville" #TODO
#FL_LOC_1 = "USA" #TODO
#XLAT = 29.652
#XLONG = -82.325
#TAMP = 21.8
#TAV = 15.8

#Treatment
#LAI = 2
#AWC = 0.50
#BIOMAS = 1800

# Treatment is one of SOIL_ID, WST_ID, AWC, LAID
SOIL_IDs = ['SICL', 'SILO', 'SALO', 'SAND']
WST_IDs = ['USGA', 'DEMU', 'COCA', 'FRLU', 'USMA', 'FRMO', 'CAQC']
AWCs = [0.0, 0.25, 0.5, 0.75, 1.0]
LAIDs = [0, 2, 7]

class OneTreatment:
    def __init__(self, trt, 
                 weather, soil, AWC, 
                 LAI, XLAT, TAMP, TAV, 
                 albedo, nb_layers, soil_depth, bulk_density,
                 irrig, surfOrgResidue, aboveGroundDM, mulch, soil_id):
        self.trt = trt
        self.weather = weather
        self.soil = soil
        self.AWC = AWC
        self.LAI = LAI
        self.XLAT = XLAT
        self.TAMP = TAMP
        self.TAV = TAV

        self.albedo = albedo
        self.nb_layers = nb_layers
        self.soil_depth = soil_depth
        self.bulk_density = bulk_density 

        self.irrig = self.IRVAL = irrig
        self.surf_org_residue = surfOrgResidue
        self.above_ground_dry_mass = self.CWAD = aboveGroundDM 
        self.mulch = self.MLTHK = mulch
        self.soil_id=soil_id

    def to_dict(self):
        d = self.__dict__.copy()
        del d['trt']
        return d
    

class Treatment:

    def __init__(self, fn = "./InputData/Treatment.txt"):
        self.trt_df = pd.read_csv(fn, sep='\t', header=2)
        self.weather_metadata = read_weather_metadata()
        self.soil_metadata = read_soil_metadata()

    def __call__(self, weather_station, soil,  water_content, lai):
        weather, my_soil, AWC, LAI, irrig, surfOrgResidue, aboveGroundDM, mulch = read_one_treatment(self.trt_df, soil, 
                                                        weather_station=weather_station,
                                                        water_content=water_content, 
                                                        LAI=lai)
        wm = self.weather_metadata
        metainfo = wm[wm.WST_ID==weather_station]
        mymetainfo = metainfo.iloc[0]
        XLAT = mymetainfo.XLAT
        TAMP = mymetainfo.TAMP
        TAV = mymetainfo.TAV

        sm = self.soil_metadata
        metainfo = sm[sm.SOIL_ID==soil]
        mymetainfo = metainfo.iloc[0]
        albedo = mymetainfo.SALB
        nb_layers = mymetainfo.NLAYR
        soil_depth = mymetainfo.SLDP
        bulk_density = mymetainfo.SABDM


        return OneTreatment(self, weather, my_soil, AWC, LAI, XLAT, TAMP, TAV,
                            albedo, nb_layers, soil_depth, bulk_density,
                            irrig, surfOrgResidue, aboveGroundDM, mulch, soil)


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

    _, data = next(record.iterrows())

    WST_DATASET = data.WST_DATASET
    AWC = water_content
    LAI = LAI
    soilID = soil

    weather_fn = f'InputData/WeatherData/{WST_DATASET}.WTH'
    weather = read_weather(weather_fn)
    soil_df = read_soil_layers()
    mask = soil_df.SOIL_ID==soilID
    my_soil = soil_df[mask]

    irrig = IRVAL = data.IRVAL # irrigation
    surfOrgResidue = data['LC0D'] # Surface organic residue, dry mass
    aboveGroundDM = CWAD = data.CWAD #Total above ground dry mass
    mulch = MLTHK = data.MLTHK

    return weather, my_soil, AWC, LAI, irrig, surfOrgResidue, aboveGroundDM, mulch

def read_soil_metadata(fn="InputData/SoilMetadata.txt"):
    wmd_df = pd.read_csv(fn, sep='\t', header=2)
    return wmd_df


def read_weather(fn="InputData/WeatherData/USGAL2AW0.50.WTH"):
    weather_df = pd.read_csv(fn, sep='\t')
    weather_df.DATE = pd.to_datetime(weather_df.DATE, format="%Y%j")

    return weather_df

def read_weather_metadata(fn="InputData/WeatherMetadata.txt"):
    wmd_df = pd.read_csv(fn, sep='\t', header=2)
    return wmd_df

def read_soil_layers(fn="InputData/SoilData.txt"):
    soil = pd.read_csv(fn, sep='\t', header=2)

    # Convert units
    #soil.SLLB *= 0.01
    #soil.THICK *= 10
    #soil.SVSE *= 10**6

    # TODO
    soil['SLROCK'] = 0.
    soil['SLSAND'] = 15.
    soil['SLSILT'] = 35.

    return soil



#Read the soil layers values from file
def my_cambel(config):
    c = config
    return simulate(c.weather, c.soil, c.AWC, albedo, XLAT, TAMP, TAV, LAI, nb_layers)



def simulate(weather, soil, AWC, albedo, XLAT, TAMP, TAV, LAI, nb_layers, *args, **kwds):
    #weather = read_weather()
    #soil_type = read_soil_layers()

    #Soil metadata
    # treatment
    #soilID = "SICL"
    #albedo = 0.11
    #numberLayer = 10
    #soilDepth = 210 * 0.01
    #bd = 1.36
    my_soil_type = soil
    #my_soil_type  = soil_type[soil_type.SOIL_ID == soilID]

    #Site metadata
    #WST_ID = "USGA"
    #SITE_NAME = "Gainesville"
    #FL_LOC_1 = "USA"
    #XLAT = 29.652
    #XLONG = -82.325
    #TAMP = 21.8
    #TAV = 15.8

    #Treatment
    #LAI = 2
    #AWC = 0.50
    #BIOMAS = 1800    

    # Extract data from files / dataframes
    numberLayer = nb_layers
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
    
    # Outputs
    columns = "Date SLLT SLLB TSLD TSLX TSLN Layer".split()
    Dates = []
    SLLTs = []
    SLLBs = []
    TSLDs = []
    TSLXs = []
    TSLNs = []
    Layers = []
    
    nb_steps = 30

    count = 0
    
    for i, wi in weather.iterrows():
        if count == nb_steps:
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
        Dates.append(wi.DATE); SLLTs.append(0); SLLBs.append(0); TSLDs.append(aveSoilTemp[1]); TSLXs.append(maxSoilTemp[1]); TSLNs.append(minSoilTemp[1]); Layers.append(0)
        for j in range(2, numberLayer+2):
            Dates.append(wi.DATE.dayofyear); SLLTs.append(int(SLLT[j-2])); SLLBs.append(int(SLLB[j-2]*100)); TSLDs.append(aveSoilTemp[j]); TSLXs.append(maxSoilTemp[j]); TSLNs.append(minSoilTemp[j]); Layers.append(j-1)


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


def test():
    trt = Treatment()
    config = trt(WST_IDs[0], soil=SOIL_IDs[0], water_content=AWCs[0],lai=LAIDs[0])
    res = simulate(**config.to_dict())
    return res


if __name__ == "__main__":
    #trt_df = read_treatments()
    #weather, my_soil, AWC, LAI, XLAT = read_one_treatment(trt_df)
    #df = simulate(weather, my_soil,
    #              AWC, albedo, XLAT, TAMP, TAV, LAI)
    pass