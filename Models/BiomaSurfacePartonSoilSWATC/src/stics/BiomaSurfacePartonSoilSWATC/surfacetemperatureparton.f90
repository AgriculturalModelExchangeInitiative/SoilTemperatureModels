MODULE Surfacetemperaturepartonmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_surfacetemperatureparton(AboveGroundBiomass, &
        GlobalSolarRadiation, &
        AirTemperatureMinimum, &
        SurfaceTemperatureMaximum, &
        DayLength, &
        SurfaceTemperatureMinimum, &
        AirTemperatureMaximum, &
        SurfaceSoilTemperature)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: AboveGroundBiomass
        REAL, INTENT(IN) :: GlobalSolarRadiation
        REAL, INTENT(IN) :: AirTemperatureMinimum
        REAL, INTENT(INOUT) :: SurfaceTemperatureMaximum
        REAL, INTENT(IN) :: DayLength
        REAL, INTENT(INOUT) :: SurfaceTemperatureMinimum
        REAL, INTENT(IN) :: AirTemperatureMaximum
        REAL, INTENT(OUT) :: SurfaceSoilTemperature
        REAL:: _AGB
        REAL:: _AirTMax
        REAL:: _AirTmin
        REAL:: _SolarRad
        !- Name: SurfaceTemperatureParton -Version: 001, -Time step: 1
        !- Description:
    !            * Title: SurfaceTemperatureParton model
    !            * Authors: simone.bregaglio@unimi.it
    !            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    !            * Institution: University Of Milan
    !            * ExtendedDescription: Strategy for the calculation of soil surface temperature with Parton's method. Reference: Parton, W. J. 1984. Predicting soil temperatures in a shortgrass steppe. Soil Science 138:93-101.
    !            * ShortDescription: None
        !- inputs:
    !            * name: AboveGroundBiomass
    !                          ** description : Above ground biomass
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : 0
    !                          ** default : 3
    !                          ** unit : Kg ha-1
    !            * name: GlobalSolarRadiation
    !                          ** description : Daily global solar radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : 0
    !                          ** default : 15
    !                          ** unit : Mj m-2 d-1
    !            * name: AirTemperatureMinimum
    !                          ** description : Minimum daily air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : -60
    !                          ** default : 5
    !                          ** unit : Â°C
    !            * name: SurfaceTemperatureMaximum
    !                          ** description : Maximum surface soil temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 25
    !                          ** unit : Â°C
    !            * name: DayLength
    !                          ** description : Length of the day
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 24
    !                          ** min : 0
    !                          ** default : 10
    !                          ** unit : h
    !            * name: SurfaceTemperatureMinimum
    !                          ** description : Minimum surface soil temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 10
    !                          ** unit : Â°C
    !            * name: AirTemperatureMaximum
    !                          ** description : Maximum daily air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -40
    !                          ** default : 15
    !                          ** unit : Â°C
        !- outputs:
    !            * name: SurfaceSoilTemperature
    !                          ** description : Average surface soil temperature
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
    !                          ** max : 60
    !                          ** min : -60
    !                          ** unit : Â°C
    !            * name: SurfaceTemperatureMaximum
    !                          ** description : Maximum surface soil temperature
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 60
    !                          ** min : -60
    !                          ** unit : Â°C
    !            * name: SurfaceTemperatureMinimum
    !                          ** description : Minimum surface soil temperature
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : auxiliary
    !                          ** max : 60
    !                          ** min : -60
    !                          ** unit : Â°C
        _AGB = AboveGroundBiomass / 10000
        _AirTMax = AirTemperatureMaximum
        _AirTmin = AirTemperatureMinimum
        _SolarRad = GlobalSolarRadiation
        IF(_AGB .GT. 0.15) THEN
            SurfaceTemperatureMaximum = _AirTMax + ((24 * (1 - EXP((-0.038) *  &
                    _SolarRad)) + (0.35 * _AirTMax)) * (EXP((-4.8) * _AGB) - 0.13))
            SurfaceTemperatureMinimum = _AirTmin + (6 * _AGB) - 1.82
        ELSE
            SurfaceTemperatureMaximum = AirTemperatureMaximum
            SurfaceTemperatureMinimum = AirTemperatureMinimum
        END IF
        SurfaceSoilTemperature = 0.41 * SurfaceTemperatureMaximum + (0.59 *  &
                SurfaceTemperatureMinimum)
        IF(DayLength .NE. REAL(0)) THEN
            SurfaceSoilTemperature = DayLength / 24 * _AirTMax + ((1 - (DayLength  &
                    / 24)) * _AirTmin)
        END IF
    END SUBROUTINE model_surfacetemperatureparton

END MODULE
