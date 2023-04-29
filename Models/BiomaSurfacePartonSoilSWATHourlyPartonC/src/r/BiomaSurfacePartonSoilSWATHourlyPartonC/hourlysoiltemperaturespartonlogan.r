library(gsubfn)

model_hourlysoiltemperaturespartonlogan <- function (SoilTemperatureByLayersHourly,
         HourOfSunrise,
         HourOfSunset,
         DayLength,
         SoilTemperatureMinimum,
         SoilTemperatureMaximum){
    #'- Name: HourlySoilTemperaturesPartonLogan -Version: 001, -Time step: 1
    #'- Description:
    #'            * Title: HourlySoilTemperaturesPartonLogan model
    #'            * Authors: simone.bregaglio@unimi.it
    #'            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    #'            * Institution: University Of Milan
    #'            * ExtendedDescription: Strategy for the calculation of hourly soil temperature. Reference: Parton, W.J.  and  Logan, J.A.,  1981. A model for diurnal variation  in soil  and  air temperature. Agric. Meteorol., 23: 205-216.
    #'            * ShortDescription: None
    #'- inputs:
    #'            * name: SoilTemperatureByLayersHourly
    #'                          ** description : Hourly soil temperature by layers
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 50
    #'                          ** min : -50
    #'                          ** default : 15
    #'                          ** unit : Â°C
    #'            * name: HourOfSunrise
    #'                          ** description : Hour of sunrise
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 24
    #'                          ** min : 0
    #'                          ** default : 6
    #'                          ** unit : h
    #'            * name: HourOfSunset
    #'                          ** description : Hour of sunset
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 24
    #'                          ** min : 0
    #'                          ** default : 17
    #'                          ** unit : h
    #'            * name: DayLength
    #'                          ** description : Length of the day
    #'                          ** inputtype : variable
    #'                          ** variablecategory : exogenous
    #'                          ** datatype : DOUBLE
    #'                          ** max : 24
    #'                          ** min : 0
    #'                          ** default : 10
    #'                          ** unit : h
    #'            * name: SoilTemperatureMinimum
    #'                          ** description : Minimum soil temperature by layers
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** default : 15
    #'                          ** unit : Â°C
    #'            * name: SoilTemperatureMaximum
    #'                          ** description : Maximum soil temperature by layers
    #'                          ** inputtype : variable
    #'                          ** variablecategory : state
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** len : 
    #'                          ** max : 60
    #'                          ** min : -60
    #'                          ** default : 15
    #'                          ** unit : Â°C
    #'- outputs:
    #'            * name: SoilTemperatureByLayersHourly
    #'                          ** description : Hourly soil temperature by layers
    #'                          ** datatype : DOUBLEARRAY
    #'                          ** variablecategory : state
    #'                          ** len : 
    #'                          ** max : 50
    #'                          ** min : -50
    #'                          ** unit : Â°C
    for( i in seq(0, length(SoilTemperatureMinimum)-1, 1)){
        for( h in seq(0, 24-1, 1)){
            if (h >= as.integer(HourOfSunrise) && h <= as.integer(HourOfSunset))
            {
                SoilTemperatureByLayersHourly[i * 24 + h+1] <- SoilTemperatureMinimum[i+1] + ((SoilTemperatureMaximum[i+1] - SoilTemperatureMinimum[i+1]) * sin(pi * (h - 12 + (DayLength / 2)) / (DayLength + (2 * 1.8))))
            }
        }
        TemperatureAtSunset <- SoilTemperatureByLayersHourly[i + as.integer(HourOfSunset)+1]
        for( h in seq(0, 24-1, 1)){
            if (h > as.integer(HourOfSunset))
            {
                SoilTemperatureByLayersHourly[i + h+1] <- (SoilTemperatureMinimum[i+1] - (TemperatureAtSunset * exp(-(24 - DayLength) / 2.2)) + ((TemperatureAtSunset - SoilTemperatureMinimum[i+1]) * exp(-(h - HourOfSunset) / 2.2))) / (1 - exp(-(24 - DayLength) / 2.2))
            }
            else if ( h <= as.integer(HourOfSunrise))
            {
                SoilTemperatureByLayersHourly[i + h+1] <- (SoilTemperatureMinimum[i+1] - (TemperatureAtSunset * exp(-(24 - DayLength) / 2.2)) + ((TemperatureAtSunset - SoilTemperatureMinimum[i+1]) * exp(-(h + 24 - HourOfSunset) / 2.2))) / (1 - exp(-(24 - DayLength) / 2.2))
            }
        }
    }
    return (list('SoilTemperatureByLayersHourly' = SoilTemperatureByLayersHourly))
}