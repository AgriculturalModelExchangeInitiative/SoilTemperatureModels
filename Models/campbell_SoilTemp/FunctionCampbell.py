
from math import (
    pi, cos, sin, sqrt, exp,
    isinf, isnan,
)

def doNetRadiation(
        solarRadn: 'Array[float]',
        cloudFr: float,
        cva: float,
        ITERATIONSperDAY: int,
        doy: float,
        rad: float,
        tmin: float
        ):
    
    DEG2RAD: float = pi / 180.0
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
    returnValue = val1 / val2
    if isinf(returnValue) or isnan(returnValue):    
        return errVal
    return returnValue

def kelvinT(celciusT: float) -> float:
    """ Convert deg Celcius to deg Kelvin.
    """
    ZEROTkelvin: float = 273.18
    return celciusT + ZEROTkelvin


def doProcess():
    pass