MODULE Surfaceswatsoilswatcmod
    USE Surfacetemperatureswatmod
    USE Soiltemperatureswatmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_surfaceswatsoilswatc(GlobalSolarRadiation, &
        AirTemperatureMaximum, &
        AirTemperatureMinimum, &
        Albedo, &
        AboveGroundBiomass, &
        WaterEquivalentOfSnowPack, &
        LagCoefficient, &
        AirTemperatureAnnualAverage, &
        BulkDensity, &
        LayerThickness, &
        VolumetricWaterContent, &
        SoilProfileDepth, &
        SurfaceSoilTemperature, &
        SoilTemperatureByLayers)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: GlobalSolarRadiation
        REAL, INTENT(IN) :: AirTemperatureMaximum
        REAL, INTENT(IN) :: AirTemperatureMinimum
        REAL, INTENT(IN) :: Albedo
        REAL, INTENT(IN) :: AboveGroundBiomass
        REAL, INTENT(IN) :: WaterEquivalentOfSnowPack
        REAL, INTENT(IN) :: LagCoefficient
        REAL, INTENT(IN) :: AirTemperatureAnnualAverage
        REAL , DIMENSION(: ), INTENT(IN) :: BulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: LayerThickness
        REAL , DIMENSION(: ), INTENT(IN) :: VolumetricWaterContent
        REAL, INTENT(IN) :: SoilProfileDepth
        REAL , DIMENSION(: ), INTENT(OUT) :: SoilTemperatureByLayers
        REAL, INTENT(OUT) :: SurfaceSoilTemperature
        !- Name: SurfaceSWATSoilSWATC -Version: 001, -Time step: 1
        !- Description:
    !            * Title: SurfaceSWATSoilSWATC model
    !            * Authors: simone.bregaglio@unimi.it
    !            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    !            * Institution: Universiy Of Milan
    !            * ExtendedDescription: Composite strategy for the calculation of surface and soil temperature with SWAT method. Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf.  Composite strategy. See also references of the associated strategies.
    !            * ShortDescription: None
        !- inputs:
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
    !            * name: AirTemperatureMinimum
    !                          ** description : Minimum daily air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : -60
    !                          ** default : 5
    !                          ** unit : Â°C
    !            * name: Albedo
    !                          ** description : Albedo of soil
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.2
    !                          ** unit : unitless
    !            * name: AboveGroundBiomass
    !                          ** description : Above ground biomass
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : 0
    !                          ** default : 3
    !                          ** unit : Kg ha-1
    !            * name: WaterEquivalentOfSnowPack
    !                          ** description : Water equivalent of snow pack
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 1000
    !                          ** min : 0
    !                          ** default : 10
    !                          ** unit : mm
    !            * name: LagCoefficient
    !                          ** description : Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLE
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.8
    !                          ** unit : dimensionless
    !            * name: AirTemperatureAnnualAverage
    !                          ** description : Annual average air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : -40
    !                          ** default : 15
    !                          ** unit : Â°C
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
    !            * name: SoilProfileDepth
    !                          ** description : Soil profile depth
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : 0
    !                          ** default : 3
    !                          ** unit : m
        !- outputs:
    !            * name: SurfaceSoilTemperature
    !                          ** description : Average surface soil temperature
    !                          ** datatype : DOUBLE
    !                          ** variablecategory : state
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
        call model_surfacetemperatureswat(GlobalSolarRadiation,  &
                SoilTemperatureByLayers, AirTemperatureMaximum,  &
                AirTemperatureMinimum, Albedo, AboveGroundBiomass,  &
                WaterEquivalentOfSnowPack,SurfaceSoilTemperature)
        call model_soiltemperatureswat(SoilTemperatureByLayers,  &
                LagCoefficient, AirTemperatureAnnualAverage, BulkDensity,  &
                LayerThickness, VolumetricWaterContent, SoilProfileDepth,  &
                SurfaceSoilTemperature)
    END SUBROUTINE model_surfaceswatsoilswatc

END MODULE
