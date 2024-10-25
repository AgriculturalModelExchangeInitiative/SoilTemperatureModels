# coding: utf8
import pandas as pd

from Campbell.campbell import init_campbell, model_campbell


#Weather arrays
DATE = []
T2M = []
TMIN = []
TMAX = []
RAIN = []
SRAD = []
DAYLD = []
SUNUP = []
SUNDN = []
EOAD = []
ESP = []
LE = []
G = []
SNOW = []

#Soil arrays
SOILID = []
SOILNAME = []
SLID = []
SLLT = []
SLLB = []
THICK = []
SLBDM = []
SLOC = []
SLSAT = []
SLDUL = []
SLLL = []
SLCLY = []
SVSE = []
SLCARB = []
SLROCK = []
SLSAND = []
SLSILT = []

#Soil metadata
soilID = "SICL"
albedo = 0.11
numberLayer = 10
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


#Read all the weather daily values from file
def readVarWeather():
    with open("InputData/WeatherData/USGAL2AW0.50.WTH", "r") as f:

    # Lire chaque ligne du fichier
        for ligne in f:
            valeurs = ligne.strip().split("\t")
            if (valeurs[0] == "DATE"):
                continue
        
            DATE.append(valeurs[0])
            T2M.append(float(valeurs[1]))
            TMIN.append(float(valeurs[2]))
            TMAX.append(float(valeurs[3]))
            RAIN.append(float(valeurs[4]))
            SRAD.append(float(valeurs[5]))
            DAYLD.append(float(valeurs[6]))
            SUNUP.append(float(valeurs[7]))
            SUNDN.append(float(valeurs[8]))
            EOAD.append(float(valeurs[9]))
            ESP.append(float(valeurs[10]))
            LE.append(float(valeurs[11]))
            G.append(float(valeurs[12]))
            SNOW.append(float(valeurs[13]))
  
#Read the soil layers values from file
def readSoilLayers():
    with open("InputData/SoilData.txt", "r") as f:
        for _ in range(3):
            ligne = f.readline()
            
        for _ in range(10):
            ligne = f.readline()
        
            valeurs = ligne.strip().split("\t")
        
            SOILID.append(valeurs[0])
            SOILNAME.append(valeurs[1])
            SLID.append(float(valeurs[2]))
            SLLT.append(float(valeurs[3]))
            SLLB.append(float(valeurs[4])*0.01)
            THICK.append(float(valeurs[5])*10)
            SLBDM.append(float(valeurs[6]))
            SLOC.append(float(valeurs[7]))
            SLSAT.append(float(valeurs[8]))
            SLDUL.append(float(valeurs[9]))
            SLLL.append(float(valeurs[10]))
            SLCLY.append(float(valeurs[11]))
            SLROCK.append(0.0)
            SLSAND.append(15.0)
            SLSILT.append(35.0)
            SVSE.append(float(valeurs[12])*10**6)

def main():
    readVarWeather()
    readSoilLayers()
    
    soilW = [] 
    year = []
    doy = []
    
    for i in range(numberLayer):
        soilW.append(SLLL[i] + AWC * (SLDUL[i] - SLLL[i]))
        
    for i in range(len(DATE)):
        year.append(int(DATE[i][:4]))
        doy.append(int(DATE[i][-3:]))

    columns = "Date SLLT SLLB TSLD TSLX TSLN Layer".split()
    Dates = []
    SLLTs = []
    SLLBs = []
    TSLDs = []
    TSLXs = []
    TSLNs = []
    Layers = []

    #with open("C:/Users/raihauti/Documents/CampbellOutputs.txt", "w") as file:
    #    file.write("Date\tSLLT\tSLLB\tTSLD\tTSLX\tTSLN\n")
    
    airPressure:float = 1010.0
    canopyHeight:float = 0.057
    soilTemp: 'Array[float]' = []
    thermalCondPar1: 'Array[float]' = []
    thermalCondPar2: 'Array[float]' = []
    thermalCondPar3: 'Array[float]' = []
    thermalCondPar4: 'Array[float]' = []
    newTemperature: 'Array[float]' = []
    heatCapacity: 'Array[float]' = []
    thermalConductivity: 'Array[float]' = []
    thermalConductance: 'Array[float]' = []
    heatStorage: 'Array[float]' = []
    volSpecHeatSoil: 'Array[float]' = []
    bulkDensity: 'Array[float]' = []
    clay: 'Array[float]' = []
    rocks: 'Array[float]' = []
    carbon: 'Array[float]' = []
    silt: 'Array[float]' = []
    sand: 'Array[float]' = []
    depth: 'Array[float]' = []
    soilWater: 'Array[float]' = []
    maxTempYesterday: float = TMAX
    minTempYesterday: float = TMIN
    instrumentHeight: float = 1.2
    boundaryLayerConductanceSource:str = 'calc'
    netRadiationSource:str = 'calc'
    windSpeed:float = 3.0
    CONSTANT_TEMPdepth:float = 10000.0
    boundaryLayerConductance:float = 0.0


    (thickness, depth, bulkDensity, clay, soilWater, soilTemp, newTemperature, minSoilTemp, maxSoilTemp, aveSoilTemp, morningSoilTemp,
        thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, 
        heatStorage, volSpecHeatSoil, maxTempYesterday,
    minTempYesterday, carbon, rocks, silt, sand, boundaryLayerConductance) = init_campbell(NLAYR=numberLayer,CONSTANT_TEMPdepth=CONSTANT_TEMPdepth, T2M=T2M[0],
                                        TMAX=TMAX[0],TMIN=TMIN[0],TAV=TAV,TAMP=TAMP,XLAT=XLAT,DOY=doy[0],
                                        canopyHeight=canopyHeight,SALB=albedo,
                                        SRAD=SRAD[0],ESP=ESP[0],ES=0.0,EOAD=EOAD[0],
                                        instrumentHeight=instrumentHeight, THICK=THICK,
                                        BD=SLBDM, SLCARB=SLOC, CLAY=SLCLY, SLROCK=SLROCK, SLSILT=SLSILT, SLSAND=SLSAND,
                                        SW=soilW, airPressure=airPressure, boundaryLayerConductanceSource=boundaryLayerConductanceSource,
                                        netRadiationSource=netRadiationSource, windSpeed=windSpeed)


    for i in range(0,30):
    #for i in range(len(DATE)):
        dateToday = datetime.strptime(DATE[i], "%Y%j")
        date_formattee = dateToday.strftime("%Y-%m-%d")
        
        (soilTemp, minSoilTemp, maxSoilTemp, aveSoilTemp,
    morningSoilTemp, newTemperature, maxTempYesterday, minTempYesterday, thermalCondPar1, thermalCondPar2, 
    thermalCondPar3, thermalCondPar4, thermalConductivity, thermalConductance, 
    heatStorage, volSpecHeatSoil, boundaryLayerConductance, thickness, depth, bulkDensity, soilWater, clay,
    rocks, carbon, sand, silt) = model_campbell(NLAYR=numberLayer,CONSTANT_TEMPdepth=CONSTANT_TEMPdepth, T2M=T2M[i],
                                        TMAX=TMAX[i],TMIN=TMIN[i],TAV=TAV,TAMP=TAMP,XLAT=XLAT,DOY=doy[i],
                                        airPressure=airPressure,canopyHeight=canopyHeight,SALB=albedo,
                                        SRAD=SRAD[i],ESP=ESP[i],ES=0.0,EOAD=EOAD[i],
                                        instrumentHeight=instrumentHeight,
                                        boundaryLayerConductanceSource=boundaryLayerConductanceSource,
                                        netRadiationSource=netRadiationSource, windSpeed=windSpeed,
                                        THICKApsim=thickness, DEPTHApsim =depth, BDApsim=bulkDensity, SLCARBApsim=carbon, CLAYApsim=clay, 
                                        SLROCKApsim=rocks, SLSILTApsim=silt, SLSANDApsim=sand, SWApsim=soilWater,
                                        soilTemp=soilTemp, minSoilTemp=minSoilTemp, maxSoilTemp=maxSoilTemp, 
                                        aveSoilTemp=aveSoilTemp,morningSoilTemp=morningSoilTemp, 
                                        newTemperature=newTemperature, maxTempYesterday=maxTempYesterday, 
                                        minTempYesterday=minTempYesterday, thermalCondPar1=thermalCondPar1, 
    thermalCondPar2=thermalCondPar2, thermalCondPar3=thermalCondPar3, thermalCondPar4=thermalCondPar4, 
    thermalConductivity=thermalConductivity, thermalConductance=thermalConductance, heatStorage=heatStorage, 
                    volSpecHeatSoil=volSpecHeatSoil, _boundaryLayerConductance=boundaryLayerConductance, THICK=THICK, BD=SLBDM,
                    SLCARB=SLCARB, CLAY=SLCLY, SLROCK=SLROCK, SLSILT=SLSILT, SLSAND=SLSAND, SW=soilW) 

        Dates.append(date_formattee); SLLTs.append(0); SLLBs.append(0); TSLDs.append(aveSoilTemp[1]); TSLXs.append(maxSoilTemp[1]); TSLNs.append(minSoilTemp[1]); Layers.append(1)
        #file.write(f"{date_formattee}\t0\t0\t{round(aveSoilTemp[1],6)}\t{round(maxSoilTemp[1],6)}\t{round(minSoilTemp[1],6)}\n")
        
        for j in range(2, numberLayer+2):
            Dates.append(date_formattee); SLLTs.append(int(SLLT[j-2])); SLLBs.append(int(SLLB[j-2]*100)); TSLDs.append(aveSoilTemp[j]); TSLXs.append(maxSoilTemp[j]); TSLNs.append(minSoilTemp[j]); Layers.append(j)
            #file.write(f"{date_formattee}\t{int(SLLT[j-2])}\t{int(SLLB[j-2]*100)}\t{round(aveSoilTemp[j],6)}\t{round(maxSoilTemp[j],6)}\t{round(minSoilTemp[j],6)}\n")

    df = pd.DataFrame( OrderedDict(
            Dates = Dates,
            SLLTs = SLLTs,
            SLLBs = SLLBs,
            TSLDs = TSLDs,
            TSLXs = TSLXs,
            TSLNs = TSLNs,
            Layers =Layers            
            ),
            columns=columns)
    return df

if __name__ == "__main__":
    df = main()
