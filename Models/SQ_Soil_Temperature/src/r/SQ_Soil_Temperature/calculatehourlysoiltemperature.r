library(gsubfn)

model_calculatehourlysoiltemperature <- function (minTSoil,
         dayLength,
         b,
         a,
         maxTSoil,
         c){
    #'- Name: CalculateHourlySoilTemperature -Version: 001, -Time step: 1
    #'- Description:
    #'            * Title: CalculateHourlySoilTemperature model
    #'            * Authors: loic.manceau@inra.fr
    #'            * Reference: ('http://biomamodelling.org',)
    #'            * Institution: INRA
    #'            * ExtendedDescription: Calculate Soil temperature on a hourly basis.Parton, W.J. and Logan, J.A., 1981. A model for diurnal variation in soil and air temperature. Agric. Meteorol., 23: 205-216
    #'            * ShortDescription: None
    #'- inputs:
    #'            * name: minTSoil
    #'                          ** description : Minimum Soil Temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** default : 20
    #'                          ** unit : Â°C
    #'            * name: dayLength
    #'                          ** description : Length of the day
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 24
    #'                          ** min : 0
    #'                          ** default : 12
    #'                          ** unit : hour
    #'            * name: b
    #'                          ** description : Delay between sunrise and time when minimum temperature is reached
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** max : 10
    #'                          ** min : 0
    #'                          ** default : 1.81
    #'                          ** unit : Hour
    #'            * name: a
    #'                          ** description : Delay between sunset and time when maximum temperature is reached
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** max : 10
    #'                          ** min : 0
    #'                          ** default : 0.5
    #'                          ** unit : Hour
    #'            * name: maxTSoil
    #'                          ** description : Maximum Soil Temperature
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLE
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** default : 20
    #'                          ** unit : Â°C
    #'            * name: c
    #'                          ** description : Nighttime temperature coefficient
    #'                          ** inputtype : parameter
    #'                          ** parametercategory : constant
    #'                          ** datatype : DOUBLE
    #'                          ** max : 10
    #'                          ** min : 0
    #'                          ** default : 0.49
    #'                          ** unit : Dpmensionless
    #'- outputs:
    #'            * name: hourlySoilT
    #'                          ** description : Hourly Soil Temperature
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 24
    #'                          ** max : 80
    #'                          ** min : -30
    #'                          ** unit : Â°C
    hourlySoilT <- vector(,24)
    if (maxTSoil == as.double(-999) && minTSoil == as.double(999))
    {
        for( i in seq(0, 12-1, 1)){
            hourlySoilT[i+1] <- as.double(999)
        }
        for( i in seq(12, 24-1, 1)){
            hourlySoilT[i+1] <- as.double(-999)
        }
    }
    else
    {
        for( i in seq(0, 24-1, 1)){
            hourlySoilT[i+1] <- 0.0
        }
        hourlySoilT <- getHourlySoilSurfaceTemperature(maxTSoil, minTSoil, dayLength, b, a, c)
    }
    return (list('hourlySoilT' = hourlySoilT))
}

getHourlySoilSurfaceTemperature <- function (TMax,
         TMin,
         ady,
         b,
         a,
         c){
    result <- vector(,24)
    ahou <- pi * (ady / 24.0)
    ani <- 24 - ady
    bb <- 12 - (ady / 2) + c
    be <- 12 + (ady / 2)
    for( i in seq(0, 24-1, 1)){
        if (i >= as.integer(bb) && i <= as.integer(be))
        {
            result[i+1] <- (TMax - TMin) * sin(3.14 * (i - bb) / (ady + (2 * a))) + TMin
        }
        else
        {
            if (i > as.integer(be))
            {
                bbd <- i - be
            }
            else
            {
                bbd <- 24 + be + i
            }
            ddy <- ady - c
            tsn <- (TMax - TMin) * sin(3.14 * ddy / (ady + (2 * a))) + TMin
            result[i+1] <- TMin + ((tsn - TMin) * exp(-b * bbd / ani))
        }
    }
    return( result)
}