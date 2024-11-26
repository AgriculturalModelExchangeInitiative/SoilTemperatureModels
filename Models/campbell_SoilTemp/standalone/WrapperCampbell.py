# -*- coding: utf-8 -*-

from ApsimCampbellPython import *
from datetime import datetime

#Wrapper for 1 scenario : USA/Gainesville - SICL soil - 30 years (1991-2020) - LAI + 2 - AWC = 0.5

"""
Inputs 

LATITUDE (-)
TMAX (C) 
TMIN (C) 
albedo(-) 
TAV (C) 
TAMP (C) 
year (-)
doy (-) 
bulkDensity (t/m3)
thickness (mm) !!! conversion
LL15 (m3/m3) 
soilWater (m3/m3)
volSpecHeatSoil (J/m3/K) !!! conversion
Net Radiation (MJ)
timeS (mn)
T2M (C)
depth (m) !!! conversion
clay (-) !!! conversion
Potential evaporation (mm)
Potential evapotranspiration (mm)
Actual evaporation (mm) !!! We don't have it
Latent heat flux (W/m2) !!! Not sure about the units in our input data AND is it the LE variable ?
canopy height (m) !!!Should be 0 but if so, there is a division by zero
"""

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
    with open("C:/Users/raihauti/Documents/AMEI/19-23_February24/Standalone/Standalone/InputData/WeatherData/USGAL2AW0.50.WTH", "r") as f:

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
    with open("C:/Users/raihauti/Documents/AMEI/19-23_February24/Standalone/Standalone/InputData/SoilData.txt", "r") as f:
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
            SLCLY.append(float(valeurs[11])*0.01)
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
        
    numNodes = numberLayer + 1
    timeS:int = 1440;     # timestep in minutes

    soilTemp = [0.]*(numNodes+2) # T
    
    volSpecHeatSoil = [0.]*(numNodes+1)     # C in Joules/m^3/K
    volSpecHeatSoil[2:] = SVSE

    depth = [0.] *(numNodes+1) # node depths - get from water module, metres
    depth[1] = 0.01
    depth[2:] = SLLB
    depth.append(soilDepth * 1.1)

    soilWater = [0.]*(numNodes+1) # volumetric water content (cc water / cc soil)
    soilWater[2:] = soilW

    bulkDensity =[0.]*(numNodes+1) # bd (soil bulk density) is name of the APSIM var for bulk density so set bulkDensity = bd later (g/cc)
    bulkDensity[2:]=SLBDM
    thickness = [0.]*(numNodes+1) # APSIM soil layer depths as thickness of layers (mm)
    thickness[1] = 10. # APSIM soil layer depths as thickness of layers (mm)
    thickness[2:] = THICK
    
    clay = [0.] *(numNodes+1)          # Proportion of clay in each layer of profile (0-1)
    clay[2:] = SLCLY
    LL15 = [0.] *(numNodes+1)
    LL15[2:] = SLLL
    
    canopyHeight = 0.000001
    
    
    with open("C:/Users/raihauti/Documents/CampbellOutputs.txt", "w") as file:
        file.write("Date\tSLLT\tSLLB\tTSLD\tTSLX\tTSLN\n")
    
        soilTemp, minTempYesterday, maxTempYesterday = Init(soilTemp, numNodes, XLAT, TMAX[0], TMIN[0], albedo, SRAD[0], 
                         TAV, TAMP, year[0], doy[0], bulkDensity, thickness, LL15, soilWater)
    
        #print("Temp apres init : ", soilTemp)
    
        #for i in range(30):
        for i in range(len(DATE)):
            dateToday = datetime.strptime(DATE[i], "%Y%j")
            date_formattee = dateToday.strftime("%Y-%m-%d")
            

            soilTemp, surfaceTemp, soilTempLayers, minT, maxT = doProcess(soilTemp, numNodes, doy[i], albedo, XLAT, SRAD[i],
                                                                          volSpecHeatSoil,bulkDensity, timeS, TMIN[i], TMAX[i], T2M[i],
                                                         minTempYesterday, maxTempYesterday, thickness, depth, soilWater,
                                                         clay, ESP[i], EOAD[i], ESP[i], LE[i], canopyHeight)
            
            minTempYesterday = minT
            maxTempYesterday = maxT
            #print(soilTemp)
    
            file.write(f"{date_formattee}\t0\t0\t{round(surfaceTemp,6)}\tna\tna\n")
            
            for j in range(numberLayer):
                file.write(f"{date_formattee}\t{int(SLLT[j])}\t{int(SLLB[j]*100)}\t{round(soilTempLayers[j],6)}\tna\tna\n")



if __name__ == "__main__":
    main()
