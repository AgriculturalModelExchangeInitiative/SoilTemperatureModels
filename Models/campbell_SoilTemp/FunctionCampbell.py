
from math import (
    pi, cos, sin, sqrt, exp,
    pow, log
)

def doNetRadiation(
        solarRadn: 'Array[float]',
        cloudFr: float,
        cva: float,
        ITERATIONSperDAY: int,
        doy: float,
        rad: float,
        tmin: float, 
        latitude: float
        ):
    
    DAYSinYear: float = 365.25
    DAYhrs: float = 24.0
    MIN2SEC: float = 60.0
    HR2MIN: float = 60.0
    SEC2HR: float = 1.0 / (HR2MIN * MIN2SEC)
    DAYmins: float = DAYhrs * HR2MIN
    DAYsecs: float = DAYmins * MIN2SEC
    PA2HPA: float  = 1.0 / 100.0
    MJ2J: float = 1000000.0
    J2MJ: float = 1.0 / MJ2J
    DEG2RAD: float = pi / 180.0
    DOY2RAD: float = DEG2RAD * 360.0 / DAYSinYear
    TSTEPS2RAD: float = Divide(DEG2RAD * 360., float(ITERATIONSperDAY), 0)          # convert timestep of day to radians

    SOLARconst: float = 1360.0     # W/M^2
    solarDeclination: float = 0.3985 * sin(4.869 + doy * DOY2RAD + 0.03345 * sin(6.224 + doy * DOY2RAD))
    cD: float = sqrt(1.0 - solarDeclination * solarDeclination)
    m1: 'Array[float]' = [0.]*(ITERATIONSperDAY + 1)
    m1Tot: float = 0.0

    timestepNumber: int =1
    for timestepNumber in range(1, ITERATIONSperDAY+1):
        m1[timestepNumber] = ((solarDeclination * sin(latitude * DEG2RAD) + cD * cos(latitude * DEG2RAD) *
            cos(TSTEPS2RAD * (float(timestepNumber) - float(ITERATIONSperDAY) / 2.0))) * 
            24.0 / float(ITERATIONSperDAY))
        if (m1[timestepNumber] > 0.0):
            m1Tot += m1[timestepNumber]
        else:
            m1[timestepNumber] = 0.0


    W2MJ: float = HR2MIN * MIN2SEC * J2MJ      # convert W to MJ
    psr: float = m1Tot * SOLARconst * W2MJ   # potential solar radiation for the day (MJ/m^2)
    fr: float = Divide(max(rad, 0.1), psr, 0)               # ratio of potential to measured daily solar radiation (0-1)
    cloudFr = 2.33 - 3.33 * fr    # fractional cloud cover (0-1)
    if (cloudFr < 0.0):
        cloudFr = 0.0
    elif (cloudFr > 1.0): 
        cloudFr = 1.0

    for  timestepNumber in range(1, ITERATIONSperDAY+1):
        solarRadn[timestepNumber] = max(rad, 0.1) * Divide(m1[timestepNumber], m1Tot, 0)

    # cva is vapour concentration of the air (g/m^3)
    cva = exp(31.3716 - 6014.79 / kelvinT(tmin) - 0.00792495 * kelvinT(tmin)) / kelvinT(tmin)


    return solarRadn, cloudFr, cva


def Divide(val1, val2, errVal):
    returnValue: float = errVal
    if val2 != 0:
        returnValue = val1 / val2
    return returnValue

def kelvinT(celciusT: float) -> float:
    """ Convert deg Celcius to deg Kelvin.
    """
    ZEROTkelvin: float = 273.18
    return celciusT + ZEROTkelvin

def Zero( arr: 'Array[float]'):
    "Zero the specified array."
    i: int = 0
    for i in range(len(arr)):
        arr[i] = 0.
    
def doVolumetricSpecificHeat(soilWater: 'Array[float]'):
    return

def doThermConductivityCampbell(soilWater: 'Array[float]'):
    return


def InterpTemp(time_hours: float, tmax: float, tmin: float, max_temp_yesterday: float, min_temp_yesterday: float) -> float:
    """
    Interpolates the temperature for a given time based on maximum and minimum temperatures for today and yesterday.
    
    Parameters:
    time_hours (float): The current time in hours.
    tmax (float): Today's maximum temperature.
    tmin (float): Today's minimum temperature.
    max_temp_yesterday (float): Yesterday's maximum temperature.
    min_temp_yesterday (float): Yesterday's minimum temperature.
    
    Returns:
    float: The interpolated temperature at the given time.
    """
    DAYhrs: float = 24.0

    # Convert current time and times for max and min temperatures to fractions of a day
    time: float = time_hours / DAYhrs  # Current time as a fraction of the day
    max_t_time: float = tmax / DAYhrs  # Time of max temperature as a fraction of the day
    min_t_time: float = max_t_time - 0.5  # Time of minimum temperature, 12 hours before max temp
    current_temp: float
    if time < min_t_time:
        # Before the time of minimum temperature
        midnight_temp: float = math.sin((0.0 + 0.25 - max_t_time) * 2.0 * math.pi) \
                               * (max_temp_yesterday - min_temp_yesterday) / 2.0 \
                               + (max_temp_yesterday + min_temp_yesterday) / 2.0
        t_scale: float = (min_t_time - time) / min_t_time

        # Ensure t_scale is within bounds (0 <= t_scale <= 1)
        t_scale = max(0, min(t_scale, 1))

        current_temp = tmin + t_scale * (midnight_temp - tmin)
    
    else:
        # At or after the time of minimum temperature
        current_temp = (sin((time + 0.25 - max_t_time) * 2.0 * pi) 
                              * (tmax - tmin) / 2.0 
                              + (tmax + tmin) / 2.0 )
    return current_temp


def longWaveRadn(emissivity: float, tDegC: float) -> float:
    """
    Calculate longwave radiation using the Stefan-Boltzmann law.
    
    Parameters:
    emissivity (float): Emissivity of the surface or atmosphere.
    tDegC (float): Temperature in degrees Celsius.
    
    Returns:
    float: Longwave radiation.
    """
    STEFAN_BOLTZMANNconst: float = 5.67e-8  # Stefan-Boltzmann constant in W/m^2K^4
    return STEFAN_BOLTZMANNconst * emissivity * (kelvinT(tDegC) ** 4)

def RadnNetInterpolate(solarRadn: float, cloudFr: float, cva: float, potE: float, potET: float, tMean: float, albedo: float, gDt: float, soilTemp: 'Array[float]') -> float:
    """
    Calculate the net radiation at the soil surface.
    
    Parameters:
    solarRadn (float): Incoming solar radiation.
    cloudFr (float): Cloud fraction.
    cva (float): Clear sky view angle.
    potE (float): Potential evaporation.
    potET (float): Potential evapotranspiration.
    tMean (float): Mean temperature in degrees Celsius.
    
    Returns:
    float: Net radiation (SW and LW) for timestep (MJ).
    """
    EMISSIVITYsurface = 0.96  # Campbell Eqn. 12.1
    MJ2J: float = 1000000.0
    J2MJ: float = 1.0 / MJ2J
    SURFACEnode: int = 1  # Index of surface node 


    # Convert W to MJ
    w2MJ: float = gDt * J2MJ

    # Eqns 12.2 & 12.3: Atmospheric emissivity
    emissivityAtmos: float = (1 - 0.84 * cloudFr) * 0.58 * pow(cva, (1.0 / 7.0)) + 0.84 * cloudFr

    # Penetration constant using Soilwat algorithm
    PenetrationConstant: float = Divide(max(0.1, potE), max(0.1, potET), 0)

    # Longwave radiation incoming and outgoing at the soil surface
    lwRinSoil: float = longWaveRadn(emissivityAtmos, tMean) * PenetrationConstant * w2MJ
    lwRoutSoil: float = longWaveRadn(EMISSIVITYsurface, soilTemp[SURFACEnode]) * PenetrationConstant * w2MJ

    # Net longwave radiation at the soil surface
    lwRnetSoil: float = lwRinSoil - lwRoutSoil

    # Shortwave radiation incoming and outgoing at the soil surface
    swRin: float = solarRadn
    swRout: float = albedo * solarRadn

    # Net shortwave radiation at the soil surface
    swRnetSoil: float = (swRin - swRout) * PenetrationConstant

    # Total net radiation (SW and LW)
    return swRnetSoil + lwRnetSoil

def RhoA(temperature: float, AirPressure: float) -> float:
    """
    Calculate the density of air (kg/m³) at a given temperature and pressure.
    
    Parameters:
    temperature (float): Temperature in degrees Celsius.
    AirPressure (float): Air pressure in hPa (hectopascals).
    
    Returns:
    float: The density of air in kg/m³.
    """
    MWair = 0.02897  # Molecular weight of air (kg/mol)
    RGAS = 8.3143  # Universal gas constant (J/mol/K)
    HPA2PA = 100.0  # Conversion factor from hPa to Pascals
    
    return Divide(MWair * AirPressure * HPA2PA, kelvinT(temperature) * RGAS, 0.0)

def boundaryLayerConductanceF(TNew_zb: list, 
                              tMean: float, 
                              potE: float, 
                              potET: float, 
                              airPressure: float, 
                              canopyHeight: float
                              ) -> float:
    """
    Calculate atmospheric boundary layer conductance.
    
    Parameters:
    TNew_zb (list): Surface temperature profile.
    tMean (float): Mean air temperature (°C).
    potE (float): Potential evaporation.
    potET (float): Potential evapotranspiration.
    
    Returns:
    float: Thermal conductivity of the surface layer (W/m²/K).
    """
    # Constants
    VONK: float = 0.41  # von Karman's constant
    GRAVITATIONALconst: float = 9.8  # Gravitational constant (m/s²)
    CAPP: float = 1010.0  # Specific heat of air at constant pressure (J/kg/K)
    EMISSIVITYsurface: float = 0.98  # Surface emissivity
    SURFACEnode: int = 1
    STEFAN_BOLTZMANNconst: float = 5.67e-8  # Stefan-Boltzmann constant in W/m^2K^4
    windSpeed: float = 259.2
    instrumentHeight: float = 1.2

    SpecificHeatAir: float = CAPP * RhoA(tMean, airPressure)  # Volumetric specific heat of air (J/m³/K)
    
    # Roughness and zero-plane displacement
    RoughnessFacMomentum: float = 0.13 * canopyHeight  # Surface roughness factor for momentum
    RoughnessFacHeat: float = 0.2 * RoughnessFacMomentum  # Surface roughness factor for heat
    d: float = 0.77 * canopyHeight  # Zero-plane displacement
    
    SurfaceTemperature: float = TNew_zb[SURFACEnode]  # Surface temperature (°C)
    
    # Diffuse penetration constant
    PenetrationConstant: float = max(0.1, potE) / max(0.1, potET)
    
    # Radiative conductance
    radiativeConductance: float = 4.0 * STEFAN_BOLTZMANNconst * EMISSIVITYsurface * PenetrationConstant * pow(kelvinT(tMean), 3)
    
    # Initialize variables
    FrictionVelocity: float = 0.0
    BoundaryLayerCond: float = 0.0
    StabilityParam: float = 0.0
    StabilityCorMomentum: float = 0.0
    StabilityCorHeat: float = 0.0
    HeatFluxDensity: float = 0.0
    
    # Iterative calculation for boundary layer conductance
    iteration: int = 1
    for iteration in range(1, 4):
        FrictionVelocity = Divide(windSpeed * VONK, log(Divide(instrumentHeight - d + RoughnessFacMomentum, RoughnessFacMomentum, 0)) + StabilityCorMomentum, 0)
        
        BoundaryLayerCond = Divide(SpecificHeatAir * VONK * FrictionVelocity, log(Divide(instrumentHeight - d + RoughnessFacHeat, RoughnessFacHeat, 0)) + StabilityCorHeat, 0)
        BoundaryLayerCond += radiativeConductance  # Add radiative conductance
        
        HeatFluxDensity = BoundaryLayerCond * (SurfaceTemperature - tMean)
        
        # Stability parameter (Eqn 12.14)
        StabilityParam = Divide(-VONK * instrumentHeight * GRAVITATIONALconst * HeatFluxDensity, SpecificHeatAir * kelvinT(tMean) * pow(FrictionVelocity, 3), 0)
        
        # Stability correction (Eqns 12.15 - 12.17)
        if StabilityParam > 0.0:
            StabilityCorHeat = 4.7 * StabilityParam
            StabilityCorMomentum = StabilityCorHeat
        else:
            StabilityCorHeat = -2.0 * log((1.0 + sqrt(1.0 - 16.0 * StabilityParam)) / 2.0)
            StabilityCorMomentum = 0.6 * StabilityCorHeat

    return BoundaryLayerCond


def doProcess(
        numLayers: int,
        thickness: 'Array[float]',
        bulkDensity: 'Array[float]',
        tmax: float, 
        tmin: float, 
        tav: float,
        tamp: float,
        latitude: float,
        clay: 'Array[float]',
        sw: 'Array[float]',
        depth: 'Array[float]',
        doy: float, 
        canopyHeight: float,
        albedo: float,
        rad: float, 
        potE: float, 
        potET: float, 
        actE: float, 
        airPressure: float,
        # add input/outputs
        soilTemp: 'Array[float]',
        minSoilTemp: 'Array[float]',
        maxSoilTemp: 'Array[float]',
        aveSoilTemp: 'Array[float]',
        morningSoilTemp: 'Array[float]',
        tempNew: 'Array[float]',
        volSpecHeatSoil: 'Array[float]',
        thermalConductivity: 'Array[float]',
        thermalConductance: 'Array[float]',
        heatStorage: 'Array[float]'
        ):
    """ Main loop"""

    # Constant
    AIRnode: int = 0
    SURFACEnode: int = 1
    TOPSOILnode: int = 2
    ITERATIONSperDAY : int = 48 # number of iterations in a day
    NUM_PHANTOM_NODES : int = 5
    DAYhrs: float = 24.0
    MIN2SEC: float = 60.0
    HR2MIN: float = 60.0
    SEC2HR: float = 1.0 / (HR2MIN * MIN2SEC)
    DAYmins: float = DAYhrs * HR2MIN
    DAYsecs: float = DAYmins * MIN2SEC
    PA2HPA: float  = 1.0 / 100.0
    MJ2J: float = 1000000.0
    J2MJ: float = 1.0 / MJ2J
    tempStepSec: float = 1440.0 * 60.0
    BoundaryLayerConductanceIterations: int  = 1



    cva: float = 0.0
    cloudFr: float = 0.0
    solarRadn: 'Array[float]' = [0.] * 49   # Total incoming short wave solar radiation per timestep
    solarRadn, cloudFr, cva = doNetRadiation(solarRadn, cloudFr, cva, ITERATIONSperDAY, doy, rad, tmin, latitude)

    # zero the temperature profiles
    Zero(minSoilTemp)
    Zero(maxSoilTemp)
    Zero(aveSoilTemp)
    _boundaryLayerConductance: float = 0.0

    # calc dt
    gDt: float = round(tempStepSec / float(ITERATIONSperDAY))

    # These two call used to be inside the timestep loop. I've taken them outside,
    # as the results do not appear to vary over the course of the day.
    # The results would vary if soil water content were to vary, so if future versions
    # to more communication within subday time steps, these may need to be moved
    # back into the loop. EZJ March 2014
    soilWater: 'Array[float]' = [0.0] * (numLayers + 1 + NUM_PHANTOM_NODES)

    copyLength: int = min(numLayers + 1 + NUM_PHANTOM_NODES, len(sw))
    soilWater[:copyLength] = sw[:copyLength]     # SW dimensioned for layers 1 to gNumlayers + extra for zone below bottom layer

    layer: int = 0
    for layer in range(numLayers + 1, numLayers + 1 + NUM_PHANTOM_NODES + 1):
        soilWater[layer] = soilWater[numLayers]

    #####
    doVolumetricSpecificHeat(soilWater)      # RETURNS volSpecHeatSoil() (volumetric heat capacity of nodes)
    doThermConductivityCampbell(soilWater)     # RETURNS gThermConductivity_zb()

    timeStepIteration: int = 1
    for timeStepIteration in range(1, ITERATIONSperDAY+1):
        timeOfDaySecs: float = gDt * float(timeStepIteration)
        tMean: float
        if (tempStepSec < DAYsecs):
            tMean = 0.5 * (tmax + tmin)
        else:
            tMean = InterpTemp(timeOfDaySecs * SEC2HR, tmax, tmin)
        tempNew[AIRnode] = tMean

        netRadiation: float = RadnNetInterpolate(solarRadn[timeStepIteration], 
                                                 cloudFr, cva, potE, potET, tMean, albedo, soilTemp)


        thermalConductivity[AIRnode] = boundaryLayerConductanceF(tempNew, tMean, potE, potET, airPressure, canopyHeight)
    
        # Iteratively update thermal conductivity and temperature using boundary layer conductance
        iteration: int= 1
        for iteration in range(1, BoundaryLayerConductanceIterations + 1):
            doThomas(tempNew, netRadiation, actE)  # Update tempNew
            thermalConductivity[AIRnode] = boundaryLayerConductanceF(tempNew, tMean, potE, potET)
        
        # Final calculation with updated boundary layer conductance
        doThomas(tempNew, netRadiation, actE)  # Update tempNew again
        doUpdate(ITERATIONSperDAY, timeOfDaySecs)
        
        # Check for precision and update morning soil temperature
        precision: float = min(timeOfDaySecs, 5.0 * HR2MIN * MIN2SEC) * 0.0001
        if abs(timeOfDaySecs - 5.0 * HR2MIN * MIN2SEC) <= precision:
            soilTemp[:] = morningSoilTemp[:]  # Copy soilTemp to morningSoilTemp
        
        # Update previous day's minimum and maximum temperatures
        minTempYesterday = tmin
        maxTempYesterday = tmax

