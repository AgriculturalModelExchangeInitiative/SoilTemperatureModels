MODULE Surfacepartonsoilswathourlypartoncmod
    USE Surfacetemperaturepartonmod
    USE Soiltemperatureswatmod
    USE Volumetricheatcapacitykluitenbergmod
    USE Thermalconductivitysimulatmod
    USE Thermaldiffumod
    USE Rangeofsoiltemperaturesdaycentmod
    USE Hourlysoiltemperaturespartonloganmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_surfacepartonsoilswathourlypartonc(DayLength, &
        AirTemperatureMinimum, &
        GlobalSolarRadiation, &
        AirTemperatureMaximum, &
        AboveGroundBiomass, &
        SoilProfileDepth, &
        LayerThickness, &
        LagCoefficient, &
        VolumetricWaterContent, &
        BulkDensity, &
        AirTemperatureAnnualAverage, &
        Silt, &
        OrganicMatter, &
        Sand, &
        Clay, &
        HourOfSunset, &
        HourOfSunrise, &
        SurfaceSoilTemperature, &
        SurfaceTemperatureMaximum, &
        SurfaceTemperatureMinimum, &
        SoilTemperatureByLayers, &
        HeatCapacity, &
        ThermalConductivity, &
        ThermalDiffusivity, &
        SoilTemperatureMinimum, &
        SoilTemperatureRangeByLayers, &
        SoilTemperatureMaximum, &
        SoilTemperatureByLayersHourly)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: DayLength
        REAL, INTENT(IN) :: AirTemperatureMinimum
        REAL, INTENT(IN) :: GlobalSolarRadiation
        REAL, INTENT(IN) :: AirTemperatureMaximum
        REAL, INTENT(IN) :: AboveGroundBiomass
        REAL, INTENT(IN) :: SoilProfileDepth
        REAL , DIMENSION(: ), INTENT(IN) :: LayerThickness
        REAL, INTENT(IN) :: LagCoefficient
        REAL , DIMENSION(: ), INTENT(IN) :: VolumetricWaterContent
        REAL , DIMENSION(: ), INTENT(IN) :: BulkDensity
        REAL, INTENT(IN) :: AirTemperatureAnnualAverage
        REAL , DIMENSION(: ), INTENT(IN) :: Silt
        REAL , DIMENSION(: ), INTENT(IN) :: OrganicMatter
        REAL , DIMENSION(: ), INTENT(IN) :: Sand
        REAL , DIMENSION(: ), INTENT(IN) :: Clay
        REAL, INTENT(IN) :: HourOfSunset
        REAL, INTENT(IN) :: HourOfSunrise
        REAL, INTENT(OUT) :: SurfaceTemperatureMaximum
        REAL, INTENT(OUT) :: SurfaceTemperatureMinimum
        REAL, INTENT(OUT) :: SurfaceSoilTemperature
        REAL , DIMENSION(: ), INTENT(OUT) :: SoilTemperatureByLayers
        REAL , DIMENSION(: ), INTENT(OUT) :: HeatCapacity
        REAL , DIMENSION(: ), INTENT(OUT) :: ThermalConductivity
        REAL , DIMENSION(: ), INTENT(OUT) :: ThermalDiffusivity
        REAL , DIMENSION(: ), INTENT(OUT) :: SoilTemperatureMinimum
        REAL , DIMENSION(: ), INTENT(OUT) :: SoilTemperatureRangeByLayers
        REAL , DIMENSION(: ), INTENT(OUT) :: SoilTemperatureMaximum
        REAL , DIMENSION(: ), INTENT(OUT) :: SoilTemperatureByLayersHourly
        !- Name: SurfacePartonSoilSWATHourlyPartonC -Version: 001, -Time step: 1
        !- Description:
    !            * Title: SurfacePartonSoilSWATHourlyPartonC model
    !            * Authors: simone.bregaglio@unimi.it
    !            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    !            * Institution: Universiy Of Milan
    !            * ExtendedDescription: Composite strategy for the calculation of surface temperature with Parton's method and soil temperature with SWAT method. See also references of the associated strategies.
    !            * ShortDescription: None
        !- inputs:
    !            * name: DayLength
    !                          ** description : Length of the day
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 24
    !                          ** min : 0
    !                          ** default : 10
    !                          ** unit : h
    !            * name: AirTemperatureMinimum
    !                          ** description : Minimum daily air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : -60
    !                          ** default : 5
    !                          ** unit : Â°C
    !            * name: GlobalSolarRadiation
    !                          ** description : Daily global solar radiation
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : 0
    !                          ** default : 15
    !                          ** unit : Mj m-2 d-1
    !            * name: AirTemperatureMaximum
    !                          ** description : Maximum daily air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -40
    !                          ** default : 15
    !                          ** unit : Â°C
    !            * name: AboveGroundBiomass
    !                          ** description : Above ground biomass
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : 0
    !                          ** default : 3
    !                          ** unit : Kg ha-1
    !            * name: SoilProfileDepth
    !                          ** description : Soil profile depth
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : 0
    !                          ** default : 3
    !                          ** unit : m
    !            * name: LayerThickness
    !                          ** description : Soil layer thickness
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 3
    !                          ** min : 0.005
    !                          ** default : 0.05
    !                          ** unit : m
    !            * name: LagCoefficient
    !                          ** description : Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.8
    !                          ** unit : dimensionless
    !            * name: VolumetricWaterContent
    !                          ** description : Volumetric soil water content
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 0.8
    !                          ** min : 0
    !                          ** default : 0.25
    !                          ** unit : m3 m-3
    !            * name: BulkDensity
    !                          ** description : Bulk density
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 1.8
    !                          ** min : 0.9
    !                          ** default : 1.3
    !                          ** unit : t m-3
    !            * name: AirTemperatureAnnualAverage
    !                          ** description : Annual average air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : -40
    !                          ** default : 15
    !                          ** unit : Â°C
    !            * name: Silt
    !                          ** description : Silt content of soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 20
    !                          ** unit : %
    !            * name: OrganicMatter
    !                          ** description : Organic matter content of soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 20
    !                          ** min : 0
    !                          ** default : 1.5
    !                          ** unit : %
    !            * name: Sand
    !                          ** description : Sand content of soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 30
    !                          ** unit : %
    !            * name: Clay
    !                          ** description : Clay content of soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : %
    !            * name: HourOfSunset
    !                          ** description : Hour of sunset
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 24
    !                          ** min : 0
    !                          ** default : 17
    !                          ** unit : h
    !            * name: HourOfSunrise
    !                          ** description : Hour of sunrise
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 24
    !                          ** min : 0
    !                          ** default : 6
    !                          ** unit : h
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
    !            * name: SoilTemperatureByLayers
    !                          ** description : Soil temperature of each layer
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 60
    !                          ** min : -60
    !                          ** unit : Â°C
    !            * name: HeatCapacity
    !                          ** description : Volumetric specific heat of soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 300
    !                          ** min : 0
    !                          ** unit : MJ m-3 Â°C-1
    !            * name: ThermalConductivity
    !                          ** description : Thermal conductivity of soil layer
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 8
    !                          ** min : 0.025
    !                          ** unit : W m-1 K-1
    !            * name: ThermalDiffusivity
    !                          ** description : Thermal diffusivity of soil layer
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 1
    !                          ** min : 0
    !                          ** unit : mm s-1
    !            * name: SoilTemperatureMinimum
    !                          ** description : Minimum soil temperature by layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 60
    !                          ** min : -60
    !                          ** unit : Â°C
    !            * name: SoilTemperatureRangeByLayers
    !                          ** description : Soil temperature range by layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 50
    !                          ** min : 0
    !                          ** unit : Â°C
    !            * name: SoilTemperatureMaximum
    !                          ** description : Maximum soil temperature by layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 60
    !                          ** min : -60
    !                          ** unit : Â°C
    !            * name: SoilTemperatureByLayersHourly
    !                          ** description : Hourly soil temperature by layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 50
    !                          ** min : -50
    !                          ** unit : Â°C
        call model_surfacetemperatureparton(DayLength, AirTemperatureMinimum,  &
                GlobalSolarRadiation, AirTemperatureMaximum,  &
                SurfaceTemperatureMaximum, SurfaceTemperatureMinimum,  &
                AboveGroundBiomass,SurfaceSoilTemperature)
        call model_volumetricheatcapacitykluitenberg(Silt, OrganicMatter,  &
                Sand, VolumetricWaterContent, BulkDensity, Clay, HeatCapacity)
        call model_thermalconductivitysimulat(VolumetricWaterContent,  &
                BulkDensity, Clay,ThermalConductivity)
        call model_soiltemperatureswat(SoilProfileDepth,  &
                SurfaceSoilTemperature, LayerThickness, LagCoefficient,  &
                VolumetricWaterContent, SoilTemperatureByLayers, BulkDensity,  &
                AirTemperatureAnnualAverage)
        call model_thermaldiffu(ThermalConductivity, ThermalDiffusivity,  &
                HeatCapacity)
        call model_rangeofsoiltemperaturesdaycent(LayerThickness,  &
                SoilTemperatureByLayers, SurfaceTemperatureMaximum,  &
                ThermalDiffusivity,  &
                SurfaceTemperatureMinimum,SoilTemperatureMinimum,SoilTemperatureRangeByLayers,SoilTemperatureMaximum)
        call model_hourlysoiltemperaturespartonlogan(SoilTemperatureMinimum,  &
                DayLength, SoilTemperatureMaximum, HourOfSunset,  &
                SoilTemperatureByLayersHourly, HourOfSunrise)
    END SUBROUTINE model_surfacepartonsoilswathourlypartonc

END MODULE
