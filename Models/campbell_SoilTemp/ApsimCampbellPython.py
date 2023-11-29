import math
from math import pi as PI
import numpy as np
from datetime import date, timedelta



# Inputs and Parameters

# mapping of layers to nodes -
# layer - air surface 1 2 ... numLayers numLayers+1
# node  - 0   1       2 3 ... Nz+1      Nz+2
# thus the node 1 is at the soil surface and Nz = NumLayers + 1.

##########################################
# Constant
AIRnode = 0
SURFACEnode = 1
TOPSOILnode = 2

##########################################
# Input
numLayers = 5
numNodes = NZ = numLayers+1   # Number of nodes

##########################################
# CONSTANT
# latent heat of vapourisation for water (J/kg); 1 mm evap/day = 1 kg/m^2 day requires 2.45*10^6 J/m^2
LAMBDA: float = 2465000.0      

# defines the power per unit area emitted by a black body as a function of its thermodynamic temperature (W/m^2/K^4).   
STEFAN_BOLTZMANNconst : float = 0.0000000567 

# no of days in one year
DAYSinYear : float = 365.25    
DEG2RAD : float = PI / 180.0;
RAD2DEG : float = 180.0 / PI;
DOY2RAD : float = DEG2RAD * 360.0 / DAYSinYear;          # convert day of year to radians
MIN2SEC : float = 60.0;          # 60 seconds in a minute - conversion minutes to seconds
HR2MIN : float = 60.0;           # 60 minutes in an hour - conversion hours to minutes
SEC2HR : float = 1.0 / (HR2MIN * MIN2SEC);  # conversion seconds to hours
DAYhrs : float  = 24.0;           # hours in a day
DAYmins : float = DAYhrs * HR2MIN;           # minutes in a day
DAYsecs : float = DAYmins * MIN2SEC;         # seconds in a day
M2MM : float = 1000.0;           # 1000 mm in a metre -  conversion Metre to millimetre
MM2M : float = 1 / M2MM;           # 1000 mm in a metre -  conversion millimetre to Metre
PA2HPA : float = 1.0 / 100.0;        # conversion of air pressure pascals to hectopascals
MJ2J : float = 1000000.0;            # convert MJ to J
J2MJ : float = 1.0 / MJ2J;            # convert J to MJ


##########################################
# Input
TAV	= 20        # °C Average annual temperature. Also determines the temperature at the lower boundary.
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

LATITUDE = 30
DOY = 50 # day of year
YEAR = 2015 #year
AMP = 12 #year


# INPUT ARRAY
# TODO : numLayers, NZ or NZ+1?
BD = [1.5]*(NZ+1)
THICKNESS = [100]*(NZ+1)

# PARAMETERS
timestep:int = 1440;     # timestep in minutes
# this was not an input in old apsim. # [Input]    #FIXME - optional input
nu :float= 0.6;                # forward/backward differencing coefficient (0-1).
                          # A weighting factor which may range from 0 to 1. If nu=0, the flux is determined by the temperature difference
                          # at the beginning of the time step. The numerical procedure which results from this choice is called a forward
                          # difference of explicit method. If nu=0.5, the average of the old and new temperatures is used to compute heat flux.
                          # This is called a time-centered or Crank-Nicholson scheme.
                          # The equation for computing T(j+1) is implicit for this choice of nu (and any other except nu=0) since T(j+1) depends
                          # on the values of the new temperatures at the nodes i+1 and i-1. Most heat flow models use either nu=0 or nu=0.5.
                          # The best value for nu is determined by consideration of numerical stability and accuracy.
                          # The explicit scheme with nu=0 predicts more heat transfer between nodes than would actually occur, and can therefore
                          # become unstable if time steps are too large. Stable numerical solutions are only obtained when (Simonson, 1975)
                          # deltaT < CH*(deltaZ)^2 / 2*lambda.
                          # When nu < 0.5, stable solutions to the heat flow problem will always be obtained, but if nu is too small, the solutions
                          # may oscillate. The reason for this is that the simulated heat transfer between nodes overshoots. On the next time step
                          # the excess heat must be transferrec back, so the predicted temperature at that node oscillates. On the other hand, if nu
                          # is too large, the temperature difference will be too small and not enough heat will be transferred. Simulated temperatures
                          # will never oscillate under these conditions, but the simulation will understimate heat flux. The best accuracy is obtained
                          # with nu around 0.4, while best stability is at nu=1. A typical compromise is nu=0.6.

volSpecHeatClay:float = 2.39e6;  # [Joules*m-3*K-1]
volSpecHeatOM:float = 5e6;       # [Joules*m-3*K-1]
volSpecHeatWater:float = 4.18e6; # [Joules*m-3*K-1]

maxTempTime= maxTTimeDefault = 14. # Time of maximum temperature in hours
boundarLayerConductanceSource:str = "calc"
boundaryLayerConductance: float = 20.
BoundaryLayerConductanceIterations : int = 1   # maximum number of iterations to calculate atmosphere boundary layer conductance


# Meteo
windSpeed = defaultWindSpeed = 3.;      # default wind speed (m/s)
altitude = defaultAltitude = 18;    # (m) altitude at site
instrumentHeight = defaultInstrumentHeight = 1.2;  # (m) height of instruments above ground
bareSoilHeight: float = 57;        # roughness element height of bare soil (mm)


# Internal arrays / outputs
soilTemp = [20.]*(NZ+1) # T
thermCondPar1 = [0.]*(NZ+1)       # A in equation 5; soil solids thermal conductivity parameter
thermCondPar2 = [0.]*(NZ+1)       # B in equation 5; soil solids thermal conductivity parameter
thermCondPar3 = [0.]*(NZ+1)       # C in equation 5; soil solids thermal conductivity parameter
thermCondPar4 = [0.]*(NZ+1)       # D in equation 5; soil solids thermal conductivity parameter
volSpecHeatSoil = [0.]*(NZ)     # C in Joules/m^3/K
soilTemp = [17.]*(NZ+1)           # T soil temperature
morningSoilTemp = [20.]*(NZ+1)    # soil temperature
heatStorage  = [0.]*(NZ+1)        # Named S in the equations CP; heat storage between nodes - index is same as upper node (J/s/K or W/K)
thermalConductance = [0.]*(NZ+1)  # K; conductance of element between nodes - index is same as upper node
thermalConductivity = [0.]*(NZ+1) # lambda; thermal conductivity (W/m^2/K)

#tempNew= [20]*(NZ+1);             # soil temperature at the end of this iteration (oC)
depth = [0., 0.] +[i for i in range(NZ)] # node depths - get from water module, metres
soilWater = [0.5]*(NZ+1) # volumetric water content (cc water / cc soil)
minSoilTemp = [10.]*(NZ+1) # min soil temperature (oC)
maxSoilTemp = [10.]*(NZ+1) # maximum soil temperature (oC)

bulkDensity = BD # bd (soil bulk density) is name of the APSIM var for bulk density so set bulkDensity = bd later (g/cc)

thickness = THICKNESS # APSIM soil layer depths as thickness of layers (mm)

airTemp = 16.0;         # Air temperature (oC)
maxAirTemp = 18.0;      # Max daily Air temperature (oC)
minAirTemp = 12.0;      # Min daily Air temperature (oC)
maxTempYesterday = 20.0;
minTempYesterday = 10.0;

potSoilEvap = 3.0;     # (mm) pot sevap after modification for green cover residue wt
potEvapotrans = 5.0;   # (mm) pot evapotranspitation
actualSoilEvap = 1.0;  # actual soil evaporation (mm)

netRadiation = RADN    # Net radiation per internal timestep (MJ)
canopyHeight :float = 5.0;    # (m) height of canopy above ground
soilRoughnessHeight : float = bareSoilHeight    # (mm) height of soil roughness

clay = [0.25] *(NZ+1)          # Proportion of clay in each layer of profile (0-1)
LL15 = [9] *(NZ+1)
# TODO
# LL15 : Lower limit 15 bar (mm/mm)
#ll15 = np.zeros(NZ)

def DampingDepth(bulkDensity=bulkDensity, 
                 thickness=thickness,
                 NZ=NZ, 
                 LL15=LL15,
                 soilWater=soilWater):
    """ 
    """
    # Constants
    SW_AVAIL_TOT_MIN = 0.01 #minimum available sw (mm water)

    # Get average bulk density
    bd_tot = sum(bulkDensity[i] * thickness[i] for i in range(len(bulkDensity)))
    cum_depth = sum(thickness[1:NZ])
    ave_bd = bd_tot / cum_depth

    # Calculate favbd
    favbd = ave_bd / (ave_bd + 686.0 * math.exp(-5.63 * ave_bd))
    damp_depth_max = 1000.0 + 2500.0 * favbd
    damp_depth_max = max(damp_depth_max, 0.0)

    # Potential sw above lower limit  - mm water/mm soil depth
    ww = 0.356 - 0.144 * ave_bd
    ww = max(ww, 0.0)

    # Calculate amount of soil water
    # TODO : define LL15 and Thickness
    ll15mm = [LL15[i] * thickness[i] for i in range(2, NZ+1)]
    ll_tot = sum(ll15mm)
    sw_dep_tot = sum([soilWater[i] * thickness[i] for i in range(2, NZ+1)])
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
    T_DampDepth = f * damp_depth_max

    return T_DampDepth


def CalcSoilTemp(soilTempIO, NZ=NZ,
                 LATITUDE=LATITUDE,
                 TAV=TAV, AMP=AMP, 
                 YEAR=YEAR, DOY=DOY, 
                 RADN=RADN,
                 bulkDensity=bulkDensity, 
                 thickness=thickness,
                 LL15=LL15,
                 soilWater=soilWater):
    """ Calculate Soil Temperature based on EPIC model"""
    
    SUMMER_SOLSTICE_NTH = 173.0
    TEMPERATURE_DELAY = 27.0
    HOTTEST_DAY_NTH = SUMMER_SOLSTICE_NTH + TEMPERATURE_DELAY
    SUMMER_SOLSTICE_STH = SUMMER_SOLSTICE_NTH + 365.25 / 2.0  # Assuming 365.25 days in a year
    HOTTEST_DAY_STH = SUMMER_SOLSTICE_STH + TEMPERATURE_DELAY
    ANG = math.radians(1.0)  # Length of one day in radians (assuming 1 radian = 1 day)

    # Initialize soilTemp array
    soilTemp = [0.0] * (NZ + 1)

    # Copy values from soilTempIO to soilTemp
    #Array.ConstrainedCopy(soilTempIO, SURFACEnode, soilTemp, 0, numNodes);
    soilTemp[0:NZ] = soilTempIO[SURFACEnode:SURFACEnode+NZ]

    # Get a factor to calculate "normal" soil temperature
    alx = 0.0

    # Check for northern or southern hemisphere
    if LATITUDE > 0.0:
        alx = ANG * (date(YEAR, 1, 1) + timedelta(DOY - 1 - HOTTEST_DAY_NTH)).timetuple().tm_yday
    else:
        alx = ANG * (date(YEAR, 1, 1) + timedelta(DOY - 1 - HOTTEST_DAY_STH)).timetuple().tm_yday

    # Get change in soil temperature since the hottest day in degrees Celsius
    # LayerTemp(0.0, alx, 0.0)

    temp_a = TAV + (AMP / 2.0 * math.cos(alx - 0) + 0) * math.exp(0)
    
    surface_init = (1.0 - SALB) * (TAV + (MAXT - TAV) * math.sqrt(max(RADN, 0.1) * 23.8846 / 800.0)) + SALB * TAV
    dlt_temp = surface_init - temp_a

    # Get temperature damping depth in mm per radian of a year
    damp = DampingDepth(bulkDensity, 
                 thickness,
                 NZ, 
                 LL15,
                 soilWater)

    cum_depth = 0.0  # Cumulative depth in the profile
    depth_lag = 0.0  # Temperature lag factor in radians for depth

    # Calculate average soil temperature for each layer
    #soil_temp = [0.0] * (NZ + 1)
    for layer in range(2, NZ+1):
        cum_depth += thickness[layer]
        depth_lag = cum_depth / damp
        _layer_temp = TAV + (AMP / 2. * math.cos(alx - depth_lag) + dlt_temp)* math.exp(-depth_lag)
        soilTemp[layer] = _layer_temp
        # bound_check(soil_temp[layer], -20.0, 80.0, "soil_temp")

    # Copy values from soilTemp to soilTempIO
    return soilTemp


def Init(soilTemp=soilTemp, 
         MAXT=MAXT, MINT=MINT, 
         SALB=SALB, RADN=RADN, TAV=TAV):

    #Function read somewhere else
    # TODO?
    # GetOtherVariables()

    soilTemp = CalcSoilTemp(soilTemp)
    
    ave_temp = (MAXT + MINT) * 0.5
    
    # SurfaceTemperatureInit()
    surfaceT = (1.0 - SALB) * (ave_temp + (MAXT - ave_temp) * math.sqrt(max(RADN, 0.1) * 23.8846 / 800.0)) + SALB * ave_temp

    soilTemp[AIRnode] = (MAXT + MINT) * 0.5
    soilTemp[SURFACEnode] = surfaceT
    soilTemp[NZ] = TAV

    tempNew = soilTemp.copy()
    maxTempYesterday = MAXT
    minTempYesterday = MINT

    print(ave_temp)
    print(surfaceT)
    # CPL : I comment this line because it is done outside init
    # CPL : In ApSim they have a OnProcess function that initialise if needed then call doProcess
    #doProcess()

    return (tempNew, minTempYesterday, maxTempYesterday)

def doNetRadiation(
        ITERATIONSperDAY=48,
        DOY=DOY,
        RADN=RADN,
        ):
    print("do net radiation computation")

    TSTEPS2RAD = DEG2RAD *360. / ITERATIONSperDAY
    SOLARconst = 1360.0;     # W/M^2
    doy_angle = DOY * DOY2RAD
    solarDeclination = 0.3985 * math.sin(4.869 + doy_angle + 0.03345 * math.sin(6.224 + doy_angle))

    cD = math.sqrt(1.0 - solarDeclination * solarDeclination)
    m1 = [0.]*(ITERATIONSperDAY+1)
    m1Tot = 0.

    for timestepNumber in range(1, ITERATIONSperDAY+1):
        m1[timestepNumber] = ((solarDeclination * math.sin(LATITUDE * DEG2RAD) + 
                              cD * math.cos(LATITUDE * DEG2RAD) * math.cos(TSTEPS2RAD * (timestepNumber - ITERATIONSperDAY / 2.0))) 
                              * 24.0 / ITERATIONSperDAY)
        if (m1[timestepNumber] > 0.0):
            m1Tot += m1[timestepNumber]
        else:
            m1[timestepNumber] = 0.0

    W2MJ = HR2MIN * MIN2SEC * J2MJ
    psr = m1Tot * SOLARconst * W2MJ   # potential solar radiation for the day (MJ/m^2)
    fr = max(RADN, 0.1) / psr
    cloudFr = 2.33 - 3.33 * fr
    cloudFr = min(1., max(cloudFr, 0.))

    solarRadn = [0.] * (ITERATIONSperDAY+1)
    for timestepNumber in range(1, ITERATIONSperDAY+1):
        solarRadn[timestepNumber] = max(RADN, 0.1) * m1[timestepNumber]/ m1Tot

    # convert celsius to kelvin
    ZEROTkelvin = 273.18
    minAirTempK = minAirTemp + ZEROTkelvin

    cva = math.exp(31.3716 - 6014.79 / minAirTempK - 0.00792495 * minAirTempK) / minAirTempK
    return solarRadn, cloudFr, cva

def doVolumetricSpecificHeat(NZ=NZ, 
                             volSpecHeatSoil=volSpecHeatSoil,
                             bulkDensity=bulkDensity,
                             ):
    print("do Volumetric Specific Heat")
    SPECIFICbd = 2.65   # (g/cc) specific bulk density

    #volSpecHeatSoil = [0.]*NZ
    for layer in range(1,NZ):
        solidity = bulkDensity[layer] / SPECIFICbd
        volSpecHeatSoil[layer] = (volSpecHeatClay * solidity
                                 + volSpecHeatWater * soilWater[layer])
        
    return volSpecHeatSoil

def doThermConductivity():
    print("do Thermal Conductivity")

def doProcess( NZ=NZ, 
               volSpecHeatSoil=volSpecHeatSoil,
               bulkDensity=bulkDensity):
    print("do process")

    ITERATIONSperDAY = 48 # number of iterations in a day

    solarRadn, cloudFr, cva = doNetRadiation(ITERATIONSperDAY)

    # debug
    print(solarRadn, cloudFr, cva) 

    # TODO Check the scale order. Be sure everything (soilWater) is correct
    volSpecHeatSoil = doVolumetricSpecificHeat(
        NZ=NZ, 
        volSpecHeatSoil=volSpecHeatSoil,
        bulkDensity=bulkDensity)
    print(volSpecHeatSoil)

    #...
    doThermConductivity()

    # Solver of soil temperature : equantions + thomas
    # for ...


    return #...

if __name__ == "__main__":
    print("Hello World")
    Init(soilTemp, )
    doProcess()