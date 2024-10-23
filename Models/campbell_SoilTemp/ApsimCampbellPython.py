import math
from math import pi as PI
from math import sin, cos, exp, log, inf, radians, sqrt
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

ZEROTkelvin = 273.18
##########################################
# Input
"""
numLayers = 10
numNodes = NZ = numLayers+1   # Number of nodes
"""
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
"""
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
AMP = 12 #temperature amplitude


# INPUT ARRAY
# TODO : numLayers, NZ or NZ+1?
BD = [1.5]*(NZ+1)
THICKNESS = [100]*(NZ+1)
"""
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
boundaryLayerConductanceIterations : int = 1   # maximum number of iterations to calculate atmosphere boundary layer conductance


# Meteo
windSpeed = defaultWindSpeed = 3.;      # default wind speed (m/s)
altitude = defaultAltitude = 18;    # (m) altitude at site
instrumentHeight = defaultInstrumentHeight = 3.;  # (m) height of instruments above ground
#bareSoilHeight: float = 57;        # roughness element height of bare soil (mm)


# Internal arrays / outputs
"""
soilTemp = [18.]*(NZ+1) # T
thermCondPar1 = [0.]*(NZ+1)       # A in equation 5; soil solids thermal conductivity parameter
thermCondPar2 = [0.]*(NZ+1)       # B in equation 5; soil solids thermal conductivity parameter
thermCondPar3 = [0.]*(NZ+1)       # C in equation 5; soil solids thermal conductivity parameter
thermCondPar4 = [0.]*(NZ+1)       # D in equation 5; soil solids thermal conductivity parameter
volSpecHeatSoil = [0.]*(NZ+1)     # C in Joules/m^3/K
soilTemp = [17.]*(NZ+2)           # T soil temperature
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
canopyHeight :float = 1.0;    # (m) height of canopy above ground
soilRoughnessHeight : float = bareSoilHeight    # (mm) height of soil roughness

clay = [0.25] *(NZ+1)          # Proportion of clay in each layer of profile (0-1)
LL15 = [9] *(NZ+1)
# TODO
# LL15 : Lower limit 15 bar (mm/mm)
#ll15 = np.zeros(NZ)
"""
def DampingDepth(bulkDensity, 
                 thickness,
                 NZ, 
                 LL15,
                 soilWater):
    """ 
    """
    # Constants
    SW_AVAIL_TOT_MIN = 0.01 #minimum available sw (mm water)

    # Get average bulk density
    bd_tot = sum(bulkDensity[i] * thickness[i] for i in range(len(bulkDensity)))
    cum_depth = sum(thickness[1:NZ])
    ave_bd = bd_tot / cum_depth

    # Calculate favbd
    favbd = ave_bd / (ave_bd + 686.0 * exp(-5.63 * ave_bd))
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
    b = log(500.0 / damp_depth_max) if damp_depth_max != 0 else -inf
    f = exp(b * wcf**2)

    # Get the temperature damping depth
    T_DampDepth = f * damp_depth_max

    return T_DampDepth


def CalcSoilTemp(soilTempIO, NZ,
                 LATITUDE,
                 TAV, AMP, 
                 YEAR, DOY, 
                 MAXT, MINT,
                 SALB, RADN,
                 bulkDensity, 
                 thickness,
                 LL15,
                 soilWater):
    """ Calculate Soil Temperature based on EPIC model"""
    
    SUMMER_SOLSTICE_NTH = 173.0
    TEMPERATURE_DELAY = 27.0
    HOTTEST_DAY_NTH = SUMMER_SOLSTICE_NTH + TEMPERATURE_DELAY
    SUMMER_SOLSTICE_STH = SUMMER_SOLSTICE_NTH + 365.25 / 2.0  # Assuming 365.25 days in a year
    HOTTEST_DAY_STH = SUMMER_SOLSTICE_STH + TEMPERATURE_DELAY
    ANG = radians(1.0)  # Length of one day in radians (assuming 1 radian = 1 day)

    numNodes = NZ

    # Initialize soilTemp array
    soilTemp = [0.0] * (NZ + 2)

    # Copy values from soilTempIO to soilTemp
    #Array.ConstrainedCopy(soilTempIO, SURFACEnode, soilTemp, 0, numNodes);
    soilTemp[0:NZ+1] = soilTempIO[SURFACEnode:SURFACEnode+NZ+1]

    # Get a factor to calculate "normal" soil temperature
    alx = 0.0

    # Check for northern or southern hemisphere
    if LATITUDE > 0.0:
        alx = ANG * (date(YEAR, 1, 1) + timedelta(DOY - 1 - HOTTEST_DAY_NTH)).timetuple().tm_yday
    else:
        alx = ANG * (date(YEAR, 1, 1) + timedelta(DOY - 1 - HOTTEST_DAY_STH)).timetuple().tm_yday

    # Get change in soil temperature since the hottest day in degrees Celsius
    # LayerTemp(0.0, alx, 0.0)

    temp_a = TAV + (AMP / 2.0 * cos(alx - 0) + 0) * exp(0)
    
    surface_init = (1.0 - SALB) * (TAV + (MAXT - TAV) * sqrt(max(RADN, 0.1) * 23.8846 / 800.0)) + SALB * TAV
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
    for layer in range(1, NZ):
        cum_depth += thickness[layer]
        depth_lag = cum_depth / damp
        _layer_temp = TAV + (AMP / 2. * cos(alx - depth_lag) + dlt_temp)* exp(-depth_lag)
        soilTemp[layer] = _layer_temp
        # bound_check(soil_temp[layer], -20.0, 80.0, "soil_temp")


    # Copy values from soilTemp to soilTempIO
    soilTempIO[SURFACEnode:numNodes+SURFACEnode] = soilTemp[0:numNodes]
    return soilTempIO


def Init(soilTemp, NZ, LATITUDE,
         MAXT, MINT, 
         SALB, RADN, TAV,
         AMP, YEAR, DOY,
         bulkDensity, 
         thickness,
         LL15,
         soilWater):

    #Function read somewhere else
    # TODO?
    # GetOtherVariables()

    soilTemp = CalcSoilTemp(
        soilTemp, 
        NZ,
        LATITUDE,
        TAV, AMP, 
        YEAR, DOY,
        MAXT, MINT,
        SALB,  
        RADN,
        bulkDensity, 
        thickness,
        LL15,
        soilWater)
    
    ave_temp = (MAXT + MINT) * 0.5
    
    # SurfaceTemperatureInit()
    surfaceT = (1.0 - SALB) * (ave_temp + (MAXT - ave_temp) * sqrt(max(RADN, 0.1) * 23.8846 / 800.0)) + SALB * ave_temp

    soilTemp[AIRnode] = (MAXT + MINT) * 0.5
    soilTemp[SURFACEnode] = surfaceT
    soilTemp[NZ+1] = TAV

    tempNew = soilTemp.copy()
    maxTempYesterday = MAXT
    minTempYesterday = MINT

   ##print(ave_temp)
   # #print(surfaceT)
    # CPL : I comment this line because it is done outside init
    # CPL : In ApSim they have a OnProcess function that initialise if needed then call doProcess
    #doProcess()

    return (tempNew, minTempYesterday, maxTempYesterday)

def doNetRadiation(
        ITERATIONSperDAY,
        DOY, LATITUDE,
        RADN,minAirTemp
        ):
    #print("do net radiation computation")

    TSTEPS2RAD = DEG2RAD *360. / ITERATIONSperDAY
    SOLARconst = 1360.0;     # W/M^2
    doy_angle = DOY * DOY2RAD
    solarDeclination = 0.3985 * sin(4.869 + doy_angle + 0.03345 * sin(6.224 + doy_angle))

    cD = sqrt(1.0 - solarDeclination * solarDeclination)
    m1 = [0.]*(ITERATIONSperDAY+1)
    m1Tot = 0.

    for timestepNumber in range(1, ITERATIONSperDAY+1):
        m1[timestepNumber] = ((solarDeclination * sin(LATITUDE * DEG2RAD) + 
                              cD * cos(LATITUDE * DEG2RAD) * cos(TSTEPS2RAD * (timestepNumber - ITERATIONSperDAY / 2.0))) 
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

    cva = exp(31.3716 - 6014.79 / minAirTempK - 0.00792495 * minAirTempK) / minAirTempK
    return solarRadn, cloudFr, cva

def doVolumetricSpecificHeat(NZ, 
                             volSpecHeatSoil,
                             bulkDensity,
                             soilWater
                             ):
   # #print("do Volumetric Specific Heat")
    SPECIFICbd = 2.65   # (g/cc) specific bulk density

    volSpecHeatSoil = [0.]*(NZ+1)
    for layer in range(1,NZ+1):
        solidity = bulkDensity[layer] / SPECIFICbd
        volSpecHeatSoil[layer] = (volSpecHeatClay * solidity
                                 + volSpecHeatWater * soilWater[layer])
    volSpecHeatSoil[1] = volSpecHeatSoil[2] 
    return volSpecHeatSoil

def doThermalConductivityCoeffs(
        NZ,
        bulkDensity, 
        clay):
    
    ##print('do Thermal Conductivity Coeffs')
    thermCondPar1 = [0.65 - 0.78 * bulkDensity[layer] + 0.6 * bulkDensity[layer]**2 for layer in range(1, NZ+1)]
    thermCondPar1.insert(0, 0.)

    thermCondPar2 = [1.06 *bdl for bdl in bulkDensity[1:]]
    thermCondPar2.insert(0, 0.)

    thermCondPar3 = [1. + 2.6/math.sqrt(clayi) if clayi else 1. for clayi in clay[1:] ]
    thermCondPar3.insert(0, 0.)

    thermCondPar4 = [0.03 + 0.1 * bdi**2 for bdi in bulkDensity[1:]]
    thermCondPar4.insert(0, 0.)
    return thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4

def doThermConductivity(
        NZ,
        thermCondPar1,
        thermCondPar2,
        thermCondPar3,
        thermCondPar4,
        soilWater, 
        thickness,
        depth,
        ):
    """
    /// Calculate the thermal conductivity of the soil layer following,
    /// to Campbell, G.S. (1985) "Soil physics with BASIC: Transport
    /// models for soil-plant systems" (Amsterdam, Elsevier)
    /// Equation 4.20 where Lambda = A + B*Theta - (A-D)*exp[-(C*theta)^E]
    /// Lambda is the thermal conductivity, theta is volumetric water content and A, B, C, D, E are coefficients.
    /// When theta = 0, lambda = D. At saturation, the last term becomes zero and Lambda = A + B*theta.
    /// The constant E can be assigned a value of 4. The constant C determines the water content where thermal
    /// conductivity begins to increase rapidly and is highly correlated with clay content.
    /// Here C1=A, C2=B, SW=theta, C3=C, C4=D, 4=E.
    /// RETURNS gThermConductivity_zb() (W/m2/K)
    """
    ##print("do Thermal Conductivity")

    thermalConductivity = [0.]*(NZ+1)
    thermCondLayers = [0.]*(NZ+1)
    for layer in range(1, NZ+1):
        temp = -((thermCondPar3[layer] * soilWater[layer])**4)
        # Eqn 4.20 Campbell.
        thermCondLayers[layer] = (
            thermCondPar1[layer] + (thermCondPar2[layer] * soilWater[layer])
            - (thermCondPar1[layer] - thermCondPar4[layer]) * exp(temp)
            )  
        
    # get weighted average for soil elements between the nodes. i.e. map layers to nodes
    for node in range(SURFACEnode, NZ+1):
        layer = node - 1
        depthLayerAbove = sum(thickness[1:layer])
        d1 = depthLayerAbove - (depth[node] * M2MM)
        d2 = depth[node + 1] * M2MM - depthLayerAbove
        dSum = d1 + d2
        if dSum > 0:
            thermalConductivity[node] = ((thermCondLayers[layer] * d1) / dSum) + ((thermCondLayers[layer + 1] * d2) / dSum)
        else:
            thermalConductivity[node] = 0.

    return thermalConductivity


def InterpTemp(
        timeHours,
        minTempYesterday,
        maxTempYesterday,
        minAirTemp,
        maxAirTemp,
        ):
    #print('InterpTemp')

    time = timeHours / DAYhrs         # Current time of day as a fraction of a day
    maxT_time = maxTempTime / DAYhrs  # Time of maximum temperature as a fraction of a day
    minT_time = maxT_time - 0.5       # Time of minimum temperature as a fraction of a day
    
    if time < minT_time:
        # Current time of day is between midnight and time of minimum temperature
        midnightT = (sin((0.25 - maxT_time) * 2 * PI)
                             * (maxTempYesterday - minTempYesterday) / 2.
                             + (maxTempYesterday + minTempYesterday) / 2.)
        tScale = (minT_time - time) / minT_time
        tScale = max(min(tScale, 1.), 0.)
        current_temp = minAirTemp + tScale * (midnightT - minAirTemp)
    else:
        current_temp = (sin((time + 0.25 - maxT_time) * 2 * PI)
                * (maxAirTemp - minAirTemp) / 2.
                + (maxAirTemp + minAirTemp) / 2.)
    #print('Current Temperature ', current_temp)
    return current_temp

def longWaveRadn(emissivity: float, tDegC: float) -> float:
    return STEFAN_BOLTZMANNconst * emissivity * (tDegC+ZEROTkelvin)**4

def RadnNetInterpolate(solarRadn, airTemp, cloudFr, cva, gDt, potSoilEvap, potEvapotrans, SALB, soilTemp):
    """ Calculate the net radiation at the soil surface.
    /// <param name="solarRadn"></param>
    /// <param name="cloudFr"></param>
    /// <param name="cva"></param>
    /// <returns>Net radiation (SW and LW) for timestep (MJ)</returns>
    /// <remarks></remarks>    
    """
    #print('RadnNetInterpolate')

    EMISSIVITYsurface = 0.96    # Campbell Eqn. 12.1
    w2MJ = gDt * J2MJ

    # Eqns 12.2 & 12.3
    emissivityAtmos = (1 - 0.84 * cloudFr) * 0.58 * (cva ** (1. / 7.)) + 0.84 * cloudFr

    # To calculate the longwave radiation out, we need to account for canopy and residue cover
    # Calculate a penetration constant. Here we estimate this using the Soilwat algorithm for calculating EOS from EO and the cover effects.
    PenetrationConstant = max(0.1, potSoilEvap) / max(0.1, potEvapotrans)

    # Eqn 12.1 modified by cover.
    lwRinSoil = longWaveRadn(emissivityAtmos, airTemp) * PenetrationConstant * w2MJ

    lwRoutSoil = longWaveRadn(EMISSIVITYsurface, soilTemp[SURFACEnode]) * PenetrationConstant * w2MJ

    # Ignore (mulch/canopy) temperature and heat balance
    lwRnetSoil = lwRinSoil - lwRoutSoil

    swRin = solarRadn
    swRout = SALB * solarRadn
    # Dim swRout As Double = (salb + (1.0 - salb) * (1.0 - sunAngleAdjust())) * solarRadn   'FIXME temp test
    swRnetSoil = (swRin - swRout) * PenetrationConstant
    
    #print('Net Radiation', swRnetSoil + lwRnetSoil)
    return swRnetSoil + lwRnetSoil

def RhoA(temperature: float, AirPressure: float):
    """
    /// <summary>
    ///     calculate the density of air (kg/m3) at a given temperature and pressure
    /// </summary>
    /// <param name="temperature">temperature (oC)</param>
    /// <param name="AirPressure">air pressure (hPa)</param>
    /// <returns>density of air</returns>
    /// <remarks></remarks>
    """
    MWair = 0.02897     # molecular weight air (kg/mol)
    RGAS = 8.3143       # universal gas constant (J/mol/K)
    HPA2PA = 100.0     # hectoPascals to Pascals

    rhoa = MWair * AirPressure * HPA2PA / ((temperature+ZEROTkelvin) * RGAS)
    return rhoa

def boundaryLayerConductanceF(
        soilTemp, 
        airTemp, 
        airPressure, 
        canopyHeight,
        potSoilEvap,
        potEvapotrans):
    """ Calculate atmospheric boundary layer conductance.
        From Program 12.2, p140, Campbell, Soil Physics with Basic.

    Return : thermal conductivity of surface layer (W/m2/K)

    Remarks:  During first stage drying, evaporation prevents the surface from becoming hot,
    /// so stability corrections are small. Once the surface dries and becomes hot, boundary layer
    /// resistance is relatively unimportant in determining evaporation rate.
    /// A dry soil surface reaches temperatures well above air temperatures during the day, and can be well
    /// below air temperature on a clear night. Thermal stratification on a clear night can be strong enough
    /// to reduce sensible heat exchange between the soil surface and the air to almost nothing. If stability
    /// corrections are not made, soil temperature profiles can have large errors.
    /// </remarks>
    """
    #print('boundaryLayerConductanceF')
    VONK = 0.41      # von Karman's constant
    GRAVITATIONALconst = 9.8    # GR; gravitational constant (m/s/s)
    CAPP = 1010.0               # (J/kg/K) Specific heat of air at constant pressure
    EMISSIVITYsurface = 0.98
    SpecificHeatAir = CAPP * RhoA(airTemp, airPressure) # CH; volumetric specific heat of air (J/m3/K) (1200 at 200C at sea level)

    # Zero plane displacement and roughness parameters depend on the height, density and shape of
    # surface roughness elements. For typical crop surfaces, the following empirical correlations have
    # been obtained. (Extract from Campbell p138.). Canopy height is the height of the roughness elements.
    RoughnessFacMomentum = 0.13 * canopyHeight    # ZM; surface roughness factor for momentum
    RoughnessFacHeat = 0.2 * RoughnessFacMomentum # ZH; surface roughness factor for heat
    d = 0.77 * canopyHeight                       # D; zero plane displacement for the surface

    SurfaceTemperature = soilTemp[SURFACEnode]    # surface temperature (oC)

    # To calculate the radiative conductance term of the boundary layer conductance, we need to account for canopy and residue cover
    # Calculate a diffuce penetration constant (KL Bristow, 1988. Aust. J. Soil Res, 26, 269-80. The Role of Mulch and its Architecture
    # in modifying soil temperature). Here we estimate this using the Soilwat algorithm for calculating EOS from EO and the cover effects,
    # assuming the cover effects on EO are similar to Bristow's diffuse penetration constant - 0.26 for horizontal mulch treatment and 0.44
    # for vertical mulch treatment.
    PenetrationConstant = max(0.1, potSoilEvap) / max(0.1, potEvapotrans)

    # Campbell, p136, indicates the radiative conductance is added to the boundary layer conductance to form a combined conductance for
    # heat transfer in the atmospheric boundary layer. Eqn 12.9 modified for residue and plant canopy cover
    radiativeConductance = (4.0 * STEFAN_BOLTZMANNconst * EMISSIVITYsurface * PenetrationConstant
                                        * (airTemp+ZEROTkelvin)** 3)    # Campbell uses air temperature in leiu of surface temperature

    # Zero iteration variables
    FrictionVelocity = 0.0        # FV; UStar
    BoundaryLayerCond = 0.0       # KH; sensible heat flux in the boundary layer;(OUTPUT) thermal conductivity  (W/m2/K)
    StabilityParam = 0.0          # SP; Index of the relative importance of thermal and mechanical turbulence in boundary layer transport.
    StabilityCorMomentum = 0.0    # PM; stability correction for momentum
    StabilityCorHeat = 0.0        # PH; stability correction for heat
    HeatFluxDensity = 0.0         # H; sensible heat flux in the boundary layer

    # Since the boundary layer conductance is a function of the heat flux density, an iterative metnod must be used to find the boundary layer conductance.
    for i in range(3):
        # Heat and water vapour are transported by eddies in the turbulent atmosphere above the crop.
        # Boundary layer conductance would therefore be expected to vary depending on the wind speed and level
        # of turbulence above the crop. The level of turbulence, in turn, is determined by the roughness of the surface,
        # the distance from the surface and the thermal stratification of the boundary layer.
        # Eqn 12.11 Campbell
        FrictionVelocity = windSpeed * VONK
        FrictionVelocity /= log( (instrumentHeight - d + RoughnessFacMomentum)
                                / RoughnessFacMomentum) + StabilityCorMomentum

        # Eqn 12.10 Campbell
        BoundaryLayerCond = SpecificHeatAir * VONK * FrictionVelocity
        BoundaryLayerCond /= log((instrumentHeight - d + RoughnessFacHeat) / RoughnessFacHeat) + StabilityCorHeat

        BoundaryLayerCond += radiativeConductance # * (1.0 - sunAngleAdjust())

        HeatFluxDensity = BoundaryLayerCond * (SurfaceTemperature - airTemp)

        # Eqn 12.14
        StabilityParam = -VONK * instrumentHeight * GRAVITATIONALconst * HeatFluxDensity
        StabilityParam /= SpecificHeatAir * (airTemp + ZEROTkelvin) * FrictionVelocity ** 3.0

        # The stability correction parameters correct the boundary layer conductance for the effects
        # of buoyancy in the atmosphere. When the air near the surface is hotter than the air above,
        # the atmosphere becomes unstable, and mixing at a given wind speed is greater than would occur
        # in a neutral atmosphere. If the air near the surface is colder than the air above, the atmosphere
        # is unstable and mixing is supressed.

        if (StabilityParam > 0.0):
            # Stable conditions, when surface temperature is lower than air temperature, the sensible heat flux
            # in the boundary layer is negative and stability parameter is positive.
            # Eqn 12.15
            StabilityCorHeat = 4.7 * StabilityParam
            StabilityCorMomentum = StabilityCorHeat
        else:
            # Unstable conditions, when surface temperature is higher than air temperature, sensible heat flux in the
            # boundary layer is positive and stability parameter is negative.
            StabilityCorHeat = -2.0 * log((1.0 + sqrt(1.0 - 16.0 * StabilityParam)) / 2.0)    # Eqn 12.16
            StabilityCorMomentum = 0.6 * StabilityCorHeat                # Eqn 12.17

    #print('BoundaryLayerCond', BoundaryLayerCond)
    return BoundaryLayerCond   # thermal conductivity  (W/m2/K)

def ThomasSolver(a, b, c, d):
    '''
    Thomas solver, a b c d are Python list type.
    refer to http://en.wikipedia.org/wiki/Tridiagonal_matrix_algorithm
    and to http://www.cfd-online.com/Wiki/Tridiagonal_matrix_algorithm_-_TDMA_(Thomas_algorithm)
    
    This is a modify version of https://gist.github.com/cbellei/8ab3ab8551b8dfc8b081c518ccd9ada9
    
    a, b, c, d are list of size n
    return t of same size (the solution).
    '''
    n = len(d) # number of equations
    a, b, c, d = map(list, (a, b, c, d)) # copy lists
    for i in range(1, n):
        m = a[i]/b[i-1]
        b[i] = b[i] - m*c[i-1] 
        d[i] = d[i] - m*d[i-1]
       
    t = b
    t[-1] = d[-1]/b[-1]

    for i in range(n-2, -1, -1):
        t[i] = (d[i]-c[i]*t[i+1])/b[i]

    return t

def ThomasSolverApsim(a, b, c, d, temp, NZ):
    '''
    Thomas solver, a b c d are Python list type.
    refer to http://en.wikipedia.org/wiki/Tridiagonal_matrix_algorithm
    and to http://www.cfd-online.com/Wiki/Tridiagonal_matrix_algorithm_-_TDMA_(Thomas_algorithm)
    
    This is a modify version of https://gist.github.com/cbellei/8ab3ab8551b8dfc8b081c518ccd9ada9
    
    a, b, c, d are list of size n
    return t of same size (the solution).
    '''
   # #print('Solver')
    
    a, b, c, d = map(list, (a, b, c, d)) # copy lists
    for i in range(1, NZ):
        c[i] = c[i] / b[i]
        d[i] = d[i] / b[i]
        b[i+1] -= a[i+1] * c[i]
        d[i+1] -= a[i+1] * d[i]

    temp[NZ] = d[NZ] / b[NZ]

    for i in range(NZ-1, 0, -1):
        temp[i] = (d[i]-c[i]*temp[i+1])

    return temp

def doThomas(newTemps, 
             soilTemp, 
             thermalConductivity,
             depth,
             volSpecHeatSoil,
             gDt,
             #heatStorage,
             netRadiation, 
             actualSoilEvap,
             tempStepSec,
             NZ
             ):
    ##print('doThomas')
    a = [0.]*(NZ+1+1) # A; thermal conductance at node (W/m/K)
    b = [0.]*(NZ+1) # B; heat storage at node (W/K)
    c = [0.]*(NZ+1) # C; thermal conductance at node (W/m/K)
    d = [0.]*(NZ+1) # D; heat flux at node (w/m) and then temperature

    thermalConductance = [0.]*(NZ+1)
    thermalConductance[AIRnode] = thermalConductivity[AIRnode];

    heatStorage = [0.]*(NZ+1)
    for node in range(SURFACEnode, NZ+1):
        VolSoilAtNode = 0.5 * (depth[node + 1] - depth[node - 1])   # Volume of soil around node (m^3), assuming area is 1 m^2
        heatStorage[node] = (volSpecHeatSoil[node] * VolSoilAtNode) / gDt       # Joules/s/K or W/K
        elementLength = depth[node + 1] - depth[node]             # (m)
        thermalConductance[node] = thermalConductivity[node] / elementLength  # (W/m/K)

    # modify a[node+1 by a[node]
    g = 1 - nu
    for node in range(SURFACEnode, NZ+1):
        c[node] = (-nu) * thermalConductance[node]
        a[node+1] = c[node];             # Eqn 4.13
        b[node] = nu * (thermalConductance[node] + thermalConductance[node - 1]) + heatStorage[node]    # Eqn 4.12
                                                                                                        # Eqn 4.14
        d[node] = (g * thermalConductance[node - 1] * soilTemp[node - 1]
                + (heatStorage[node] - g * (thermalConductance[node] + thermalConductance[node - 1])) * soilTemp[node]
                + g * thermalConductance[node] * soilTemp[node + 1])

    a[SURFACEnode] = 0.

    # The boundary condition at the soil surface is more complex since convection and radiation may be important.
    # When radiative and latent heat transfer are unimportant, then D(1) = D(1) + nu*K(0)*TN(0).
    # d(SURFACEnode) += nu * thermalConductance(AIRnode) * newTemps(AIRnode)       ' Eqn. 4.16
    sensibleHeatFlux = nu * thermalConductance[AIRnode] * newTemps[AIRnode]       # Eqn. 4.16

    # When significant radiative and/or latent heat transfer occur they are added as heat sources at node 1
    # to give D(1) = D(1) = + nu*K(0)*TN(0) - Rn + LE, where Rn is net radiation at soil surface and LE is the
    # latent heat flux. Eqn. 4.17

    RadnNet = (netRadiation * MJ2J) /  gDt       # net Radiation Rn heat flux (J/m2/s or W/m2).     # (W/m)
    LatentHeatFlux = (actualSoilEvap * LAMBDA) / tempStepSec      # Es*L = latent heat flux LE (W/m)
    SoilSurfaceHeatFlux = sensibleHeatFlux + RadnNet - LatentHeatFlux  # from Rn = G + H + LE (W/m)
    d[SURFACEnode] += SoilSurfaceHeatFlux    
    
    # last line is unfulfilled soil water evaporation
    # The boundary condition at the bottom of the soil column is usually specified as remaining at some constant,
    # measured temperature, TN(M+1). The last value for D is therefore -

    d[NZ] += nu * thermalConductance[NZ] * newTemps[NZ + 1];

    newTemps = ThomasSolverApsim(a, b, c, d, newTemps, NZ)
    return newTemps

#def doUpdate(ITERATIONSperDAY):
    #print('TODO :',)
    #print('doUpdate')

def doProcess( soilTemp, 
               NZ, 
               DOY, SALB,
               LATITUDE, RADN,
               volSpecHeatSoil,
               bulkDensity, 
               timestep, 
               minAirTemp,
               maxAirTemp,
               airTemp,
               minTempYesterday, maxTempYesterday,
               thickness,
               depth, soilWater,
               clay,
               potSoilEvap, potEvapotrans, actualSoilEvap, latent_heat_flux,
               canopyHeight
               ):
    ##print("do process")

    airPressure = 101325.0 * ((1.0 - 2.25577 * 0.00001 * altitude) ** 5.25588) * PA2HPA

    #depth[TOPSOILnode] = 0.5 * thickness[1] * MM2M
    #for i in range(TOPSOILnode, NZ+1):
     #   depth[i] = sum(thickness[1:i])

    tempStepSec = timestep * MIN2SEC

    ITERATIONSperDAY = 48 # number of iterations in a day

    solarRadn, cloudFr, cva = doNetRadiation(
        ITERATIONSperDAY, DOY, LATITUDE, 
        RADN, minAirTemp)

    # debug
    ##print(solarRadn, cloudFr, cva) 

    # TODO Check the scale order. Be sure everything (soilWater) is correct
    volSpecHeatSoil = doVolumetricSpecificHeat(
        NZ=NZ, 
        volSpecHeatSoil=volSpecHeatSoil,
        bulkDensity=bulkDensity,
        soilWater=soilWater)
    ##print(volSpecHeatSoil)

    #...
    ##print('BD ', bulkDensity)
    thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4 = \
        doThermalConductivityCoeffs(
            NZ=NZ,
            bulkDensity=bulkDensity, 
            clay=clay
        )

    thermalConductivity = doThermConductivity(
        NZ=NZ,
        thermCondPar1=thermCondPar1,
        thermCondPar2=thermCondPar2,
        thermCondPar3=thermCondPar3,
        thermCondPar4=thermCondPar4,
        soilWater=soilWater,
        thickness=thickness,
        depth=depth)

    _boundaryLayerConductance = 0.0
    RnTot = 0.0
    gDt = round(tempStepSec / ITERATIONSperDAY)
    ##print('Thermal cond is : ', thermalConductivity)
    
    ################################################
    # Solver of soil temperature : equantions + thomas
    # for ...

    ##print('Begin solver loop')
    tempNew = list(soilTemp)
    for timeStepIteration in range(1, ITERATIONSperDAY+1):
        
        timeOfDaySecs = gDt * timeStepIteration
        if (tempStepSec < DAYsecs):
            airTemp = 0.5 * (maxAirTemp + minAirTemp)
        else:
            airTemp = InterpTemp(
                timeOfDaySecs * SEC2HR, 
                minTempYesterday,
                maxTempYesterday,
                minAirTemp,
                maxAirTemp
                )
        # Convert to hours //most of the arguments in FORTRAN version are global vars so
        # do not need to pass them here, they can be accessed inside InterpTemp
        tempNew[AIRnode] = airTemp;

        netRadiation = RadnNetInterpolate(
            solarRadn[timeStepIteration], 
            airTemp, 
            cloudFr, 
            cva, 
            gDt, 
            potSoilEvap=potSoilEvap, 
            potEvapotrans=potEvapotrans, 
            SALB=SALB,
            soilTemp=soilTemp)
        
        RnTot += netRadiation   # for debugging only

        # When calculating the boundary layer conductance it is important to iterate the entire
        # heat flow calculation at least once, since surface temperature depends on heat flux to
        # the atmosphere, but heat flux to the atmosphere is determined, in part, by the surface
        # temperature.
        thermalConductivity[AIRnode] = boundaryLayerConductanceF(
            tempNew, airTemp, airPressure, canopyHeight,
            potSoilEvap, potEvapotrans)
        
        for iteration in range(boundaryLayerConductanceIterations):
            tempNew = doThomas(tempNew, 
             soilTemp, 
             thermalConductivity,
             depth,
             volSpecHeatSoil,
             gDt,
             #heatStorage,
             netRadiation, 
             actualSoilEvap,
             tempStepSec,NZ)        # RETURNS TNew_zb()
            thermalConductivity[AIRnode] = boundaryLayerConductanceF(tempNew, airTemp, airPressure, canopyHeight,
            potSoilEvap, potEvapotrans)

        # Now start again with final atmosphere boundary layer conductance
        tempNew = doThomas(tempNew, 
             soilTemp, 
             thermalConductivity,
             depth,
             volSpecHeatSoil,
             gDt,
             #heatStorage,
             netRadiation, 
             actualSoilEvap,
             tempStepSec,NZ)        # RETURNS gTNew_zb()
        #doUpdate(ITERATIONSperDAY)
        #if ((RealsAreEqual(timeOfDaySecs, 5.0 * HR2MIN * MIN2SEC)))
        #    soilTemp.CopyTo(morningSoilTemp, 0);

    # Es*L = latent heat flux LE and Eos*L = net Radiation Rn.

    minTempYesterday = minAirTemp
    maxTempYesterday = maxAirTemp

    return tempNew, tempNew[SURFACEnode], tempNew[TOPSOILnode:NZ+1], minTempYesterday, maxTempYesterday


def standalone(
        LAID,    #Leaf area index
        SALB,    # albedo
        NLAYR,   # number Layers
        SLDP,    # Soil Profile Depth
        SABDM,   # soil bulk density
        SLLB,   # Soil Layer Base Depth
        THICK,   # Thickness of soil layers
        SLDUL,   # Volumetric soil water content at Drained Upper limit (Field Capacity)
        SLLL,    # Volumetric soil water content at Lower limit (Permanent wilting point)
        SLBDM,   # Bulk density
        SLCLY,   # Clay content
        SLOC,    # Soil organic matter
        SLSAT,   # Volumetric soil water content at Saturation (Saturation)
        SVSE,    # Volumetric specific heat of soil

        XLAT,    # Latitude
        XLONG,   # Longitude
        TAMP,    # T amplitude
        TAV,     # T average

        # Weather daily
        DATE,    # DOY
        T2M,     # TAV
        TMIN,    # TMIN
        TMAX,    # TMAX
        SRAD,    # solar Radiation
        DAYLD,   # Length of the day
        SUNUP,   # Hour of Sunrise
        SUNDN,   # Hour of Sunset
        EOAD,    # Daily potential
        ESP,     # Potential Evaporation
        LE,      # Surface latent heat flux
        G,       # Soil Heat Flux
        SWLD,    # Volumetri Soil Water
        ):
    """
    Inputs:
        See the args

    Output:
        DATE, TLSD (avg), TLSX (max), TLSN (min)

    """
    SALB = SALB
    numLayers = NLAYR
    numNodes = NZ = numLayers+1
    TAV = TAV
    AMP = TAMP

    _depth = SLDP # soil depth 210 cm
    
    BD = SLBDM
    THICKNESS = THICK
    LATITUDE = XLAT

    # Daily loop
    #i = 0
    
    #-------------------------------------------------------------
    # To modify

    soilTemp = [0.]*(NZ+1) # T
    minSoilTemp = [0.]*(NZ+1) # min soil temperature (oC)
    maxSoilTemp = [0.]*(NZ+1) # maximum soil temperature (oC)

    #thermCondPar1 = [0.]*(NZ+1)       # A in equation 5; soil solids thermal conductivity parameter
    #thermCondPar2 = [0.]*(NZ+1)       # B in equation 5; soil solids thermal conductivity parameter
    #thermCondPar3 = [0.]*(NZ+1)       # C in equation 5; soil solids thermal conductivity parameter
    #thermCondPar4 = [0.]*(NZ+1)       # D in equation 5; soil solids thermal conductivity parameter
    
    volSpecHeatSoil = [0.]*(NZ+1)     # C in Joules/m^3/K
    volSpecHeatSoil[2:]=SVSE

    #morningSoilTemp = [20.]*(NZ+1)    # soil temperature
    #heatStorage  = [0.]*(NZ+1)        # Named S in the equations CP; heat storage between nodes - index is same as upper node (J/s/K or W/K)
    #thermalConductance = [0.]*(NZ+1)  # K; conductance of element between nodes - index is same as upper node
    #thermalConductivity = [0.]*(NZ+1) # lambda; thermal conductivity (W/m^2/K)

    depth = [0., 0., 0.] +SLLB # node depths - get from water module, metres

    soilWater = [0.]*(NZ+1) # volumetric water content (cc water / cc soil)
    soilWater[2:] = SWLD


    bulkDensity =[0.]*(NZ+1) # bd (soil bulk density) is name of the APSIM var for bulk density so set bulkDensity = bd later (g/cc)
    bulkDensity[2:]=BD
    thickness = [0.]*(NZ+1) # APSIM soil layer depths as thickness of layers (mm)
    thickness[2:] = THICK

    # Daily values
    i = 0
    date = DATE[i]
    YEAR = int(str(date)[:4])
    DOY = int(str(date)[4:])
    airTemp = T2M[i]         # Air temperature (oC)
    maxAirTemp = TMAX[i]      # Max daily Air temperature (oC)
    minAirTemp = TMIN[i]     # Min daily Air temperature (oC)
    maxTempYesterday = TMAX[i]
    minTempYesterday = TMIN[i]

    potSoilEvap = EOAD[i]    # (mm) pot sevap after modification for green cover residue wt
    potEvapotrans = ESP[i]   # (mm) pot evapotranspitation

    # TODO: COMPUTE
    actualSoilEvap = 1.0;  # actual soil evaporation (mm)
    # TODO : added by me...
    latent_heat_flux = LE[i]

    netRadiation = SRAD[i]    # Net radiation per internal timestep (MJ)
    # TODO : define
    canopyHeight :float = 1.0;    # (m) height of canopy above ground
    # 
    #soilRoughnessHeight : float = bareSoilHeight    # (mm) height of soil roughness

    clay = [0.] *(NZ+1)          # Proportion of clay in each layer of profile (0-1)
    clay[2:] = SLCLY
    LL15 = [0.] *(NZ+1)
    LL15[2:] = SLLL
    #-------------------------------------------------------------

    soilTemp, minTempYesterday, maxTempYesterday = Init(
        soilTemp, NZ, LATITUDE, 
        maxAirTemp, minAirTemp, 
         SALB, netRadiation, TAV,
         AMP, YEAR, DOY,
         bulkDensity, 
         thickness,
         LL15,
         soilWater)
    soilTemp = doProcess(
        soilTemp,
        NZ, DOY, SALB, 
        LATITUDE, netRadiation,
        volSpecHeatSoil,
        bulkDensity, 
        timestep, 
        minAirTemp,
        maxAirTemp,
        airTemp,
        minTempYesterday, maxTempYesterday,
        thickness,
        depth,
        soilWater,
        clay,
        potSoilEvap, potEvapotrans, actualSoilEvap, latent_heat_flux,
        canopyHeight)
    #print(soilTemp)

if __name__ == "__main__":
    NLAYR = 10
    SLLB = [5,15,30,45,60,90,120,150,180,210]
    THICK = [5, 10, 15, 15, 15]+[30]*5
    SLDUL = [0.385,0.385,0.406,0.406,0.406,0.456,0.341,0.365,0.361,0.361]
    SLLL = [0.228,0.228,0.249,0.249,0.249,0.308,0.207,0.243,0.259,0.259]
    SLDBM = [1.3,1.3,1.3,1.35,1.35,1.35,1.4,1.4,1.4,1.4]
    SLCLY = [50]*NLAYR
    SLOC = [1.75,1.75,1.6,1.45,1.45,1.1,0.65,0.3,0.1,0.01]
    SLSAT = [0.481,0.481,0.482,0.465,0.465,0.468,0.452,0.455,0.457,0.457]
    SVSE=[2.39]*10
    XLAT=46.435    # Latitude
    XLONG=0.122   # Longitude
    TAMP=24.1    # T amplitude
    TAV=7.22     # T average

    weather_header = 'DATE T2M TMIN TMAX RAIN SRAD DAYLD SUNUP SUNDN EOAD ESP LE G SNOW'.split()
    weather_record = '1991279	21.2	19.6	24	1.2	19.7	11.95	6.02	17.98	4.709	1.9145	2.4247	0	0'.split()
    for i in range(len(weather_header)):
        exec('%s=%s'%(weather_header[i], weather_record[i])) 
    #DOY = int(str(DATE)[4:])

    AWC = .5
    LL15 = SLDUL
    SWLD = [SLLL[i] + AWC *(SLDUL[i] - SLLL[i]) for i in range(len(SLLL))]
    soilTemp = standalone(
        LAID=2,    #Leaf area index
        SALB=0.11,    # albedo
        NLAYR=NLAYR,   # number Layers
        SLDP=210,    # Soil Profile Depth
        SABDM=1.36,   # soil bulk density
        SLLB=SLLB,   # Soil Layer Base Depth
        THICK=THICK,   # Thickness of soil layers
        SLDUL=SLDUL,   # Volumetric soil water content at Drained Upper limit (Field Capacity)
        SLLL=SLLL,    # Volumetric soil water content at Lower limit (Permanent wilting point)
        SLBDM=SLDBM,   # Bulk density
        SLCLY=SLCLY,   # Clay content
        SLOC=SLOC,    # Soil organic matter
        SLSAT=SLSAT,   # Volumetric soil water content at Saturation (Saturation)
        SVSE=SVSE,    # Volumetric specific heat of soil

        XLAT=XLAT,    # Latitude
        XLONG=XLONG,   # Longitude
        TAMP=TAMP,    # T amplitude
        TAV=TAV,     # T average

        # Weather daily
        DATE=[DATE],    # DOY
        T2M=[T2M],     # TAV
        TMIN=[TMIN],    # TMIN
        TMAX=[TMAX],    # TMAX
        SRAD=[SRAD],    # solar Radiation
        DAYLD=[DAYLD],   # Length of the day
        SUNUP=[SUNUP],   # Hour of Sunrise
        SUNDN=[SUNDN],   # Hour of Sunset
        EOAD=[EOAD],    # Daily potential
        ESP=[ESP],     # Potential Evaporation
        LE=[LE],      # Surface latent heat flux
        G=[G],       # Soil Heat Flux
        SWLD=SWLD,    # Volumetri Soil Water
        )
    #print(soilTemp)
    