import math
import numpy as np
from datetime import datetime, timedelta


#final_soil_temp_surface	°C	Soil surface temperature at the end of the final internal Soiltemp timestep.
#final_soil_temp[nz]	°C	Soil temperature at the end of the final internal Soiltemp timestep.

AIRnode = 0
SURFACEnode = 1
#TOPSOILnode = 2

TAV	= 20        # °C Average annual temperature. Also determines the temperature at the lower boundary.
NZ = 5          # Number of nodes
MINT = 5	    # °C Minimum air temperature.
MAXT = 15	    # °C Maximum air temperature.
#DLAYER[NZ]  # mm Array of layer depths used to specify the nodes, converted to m internally.
#SW[NZ]	    # m3 m-3 Volumetric soil water content.
#BD[NZ]	    # Mg m-3 Soil bulk density.
#EOS	        # mm Potential soil water evaporation, or the water-depth equivalent of the net radiation reaching the soil surface, converted to J s-1 m-2 K-1 internally.
#ES          # mm Actual soil water evaporation, or the water-depth equivalent of the evaporation from the soil surface, converted to J s-1 m-2 K-1 internally.
#CLAY[NZ]	# – proportion of clay	0.0 – 1.0
#BOUND_LAYER_COND	#J s-1 m-2 K-1	boundary layer conductance	0.0 – 100.0
SALB = 0.13		# Bare soil albedo
RADN = 11		# Net radiation
soilTemp = np.empty(NZ+1)
LATITUDE = 30
DOY = 50 # day of year
YEAR = 2015 #year
AMP = 12 #year
BD = np.ones(NZ) * 1.5
THICKNESS = np.ones(NZ) * 100


def DampingDepth():
    # Constants
    SW_AVAIL_TOT_MIN = 0.01

    # Get average bulk density
    bd_tot = sum(BD[i] * THICKNESS[i] for i in range(NZ))
    cum_depth = sum(THICKNESS[:NZ])
    ave_bd = bd_tot / cum_depth

    # Calculate favbd
    favbd = ave_bd / (ave_bd + 686.0 * math.exp(-5.63 * ave_bd))
    damp_depth_max = 1000.0 + 2500.0 * favbd
    damp_depth_max = max(damp_depth_max, 0.0)

# Potential sw above lower limit
ww = 0.356 - 0.144 * ave_bd
ww = max(ww, 0.0)

# Calculate amount of soil water
ll15mm = [physical.LL15[i] * physical.Thickness[i] for i in range(numLayers - 1)]
ll_tot = sum(ll15mm)
sw_dep_tot = sum(waterBalance.SWmm[:numLayers - 1])
sw_avail_tot = sw_dep_tot - ll_tot
sw_avail_tot = max(sw_avail_tot, SW_AVAIL_TOT_MIN)

# Calculate fractional water content
wc = sw_avail_tot / (ww * cum_depth)
wc = max(0.0, min(wc, 1.0))
wcf = (1.0 - wc) / (1.0 + wc)

# Calculate b and f
b = math.log(500.0 / damp_depth_max) if damp_depth_max != 0 else -math.inf
f = math.exp(b * wcf**2)

# Get the temperature damping depth
soiln2_SoilTemp_DampDepth = f * damp_depth_max



def CalcSoilTemp(soilTemp):
    
    SUMMER_SOLSTICE_NTH = 173.0
    TEMPERATURE_DELAY = 27.0
    HOTTEST_DAY_NTH = SUMMER_SOLSTICE_NTH + TEMPERATURE_DELAY
    SUMMER_SOLSTICE_STH = SUMMER_SOLSTICE_NTH + 365.25 / 2.0  # Assuming 365.25 days in a year
    HOTTEST_DAY_STH = SUMMER_SOLSTICE_STH + TEMPERATURE_DELAY
    ANG = math.radians(1.0)  # Length of one day in radians (assuming 1 radian = 1 day)

    # Initialize soilTemp array
    soil_temp = [0.0] * (NZ + 1 + 1)

    # Copy values from soilTempIO to soilTemp
    soil_temp[SURFACEnode:NZ] = soilTemp[0:NZ]

    # Get a factor to calculate "normal" soil temperature
    alx = 0.0

    # Check for northern or southern hemisphere
    if LATITUDE > 0.0:
        alx = ANG * (datetime(YEAR, 1, 1) + timedelta(DOY - 1 + -HOTTEST_DAY_NTH)).timetuple().tm_yday
    else:
        alx = ANG * (datetime(YEAR, 1, 1) + timedelta(DOY - 1 + -HOTTEST_DAY_STH)).timetuple().tm_yday

    # Get change in soil temperature since the hottest day in degrees Celsius
    temp_a = TAV + (AMP / 2.0 * math.cos(alx - 0) + 0) * math.exp(0)
    surface_init = (1.0 - SALB) * (ave_temp + (MAXT - ave_temp) * math.sqrt(max(RADN, 0.1) * 23.8846 / 800.0)) + SALB * ave_temp
    dlt_temp = surface_init - temp_a

    # Get temperature damping depth in mm per radian of a year
    damp = DampingDepth()

    cum_depth = 0.0  # Cumulative depth in the profile
    depth_lag = 0.0  # Temperature lag factor in radians for depth

    # Calculate average soil temperature for each layer
    soil_temp = [0.0] * (num_nodes + 1)
    for layer in range(1, num_layers + 1):
        cum_depth += thickness[layer]
        depth_lag = cum_depth / damp
        soil_temp[layer] = layer_temp(depth_lag, alx, dlt_temp)
        bound_check(soil_temp[layer], -20.0, 80.0, "soil_temp")

    # Copy values from soilTemp to soilTempIO
    soil_temp_io[SURFACEnode:num_nodes] = soil_temp[0:num_nodes]



def doProcess():
    print("do process")



def Init():

    #Function read somewhere else
    #GetOtherVariables()
    CalcSoilTemp(soilTemp)
    
    ave_temp = (MAXT + MINT) * 0.5
    surfaceT = (1.0 - SALB) * (ave_temp + (MAXT - ave_temp) * math.sqrt(max(RADN, 0.1) * 23.8846 / 800.0)) + SALB * ave_temp

    soilTemp[AIRnode] = (MAXT + MINT) * 0.5
    soilTemp[SURFACEnode] = surfaceT
    soilTemp[NZ + 1] = TAV

    #tempNew = soilTemp.copy()
    #maxTempYesterday = MAXT
    #minTempYesterday = MINT

    print(ave_temp)
    print(surfaceT)
    doProcess()


if __name__ == "__main__":
    print("Hello World")
    Init()