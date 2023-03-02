MODULE Soiltemperatureswatmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_soiltemperatureswat(SoilProfileDepth, &
        SurfaceSoilTemperature, &
        LayerThickness, &
        LagCoefficient, &
        VolumetricWaterContent, &
        SoilTemperatureByLayers, &
        BulkDensity, &
        AirTemperatureAnnualAverage)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL, INTENT(IN) :: SoilProfileDepth
        REAL, INTENT(IN) :: SurfaceSoilTemperature
        REAL , DIMENSION(: ), INTENT(IN) :: LayerThickness
        REAL, INTENT(IN) :: LagCoefficient
        REAL , DIMENSION(: ), INTENT(IN) :: VolumetricWaterContent
        REAL , DIMENSION(: ), INTENT(INOUT) :: SoilTemperatureByLayers
        REAL , DIMENSION(: ), INTENT(IN) :: BulkDensity
        REAL, INTENT(IN) :: AirTemperatureAnnualAverage
        INTEGER:: i
        REAL:: _SoilProfileDepthmm
        REAL:: _TotalWaterContentmm
        REAL:: _MaximumDumpingDepth
        REAL:: _DumpingDepth
        REAL:: _ScalingFactor
        REAL:: _DepthBottom
        REAL:: _RatioCenter
        REAL:: _DepthFactor
        REAL:: _DepthCenterLayer
        !- Name: SoilTemperatureSWAT -Version: 001, -Time step: 1
        !- Description:
    !            * Title: SoilTemperatureSWAT model
    !            * Authors: simone.bregaglio@unimi.it
    !            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    !            * Institution: University Of Milan
    !            * ExtendedDescription: Strategy for the calculation of soil temperature with SWAT method. Reference: Neitsch,S.L., Arnold, J.G., Kiniry, J.R., Williams, J.R., King, K.W. Soil and Water Assessment Tool. Theoretical documentation. Version 2000. http://swatmodel.tamu.edu/media/1290/swat2000theory.pdf
    !            * ShortDescription: None
        !- inputs:
    !            * name: SoilProfileDepth
    !                          ** description : Soil profile depth
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : 0
    !                          ** default : 3
    !                          ** unit : m
    !            * name: SurfaceSoilTemperature
    !                          ** description : Average surface soil temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 25
    !                          ** unit : Â°C
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
    !            * name: SoilTemperatureByLayers
    !                          ** description : Soil temperature of each layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 60
    !                          ** min : -60
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
    !            * name: AirTemperatureAnnualAverage
    !                          ** description : Annual average air temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLE
    !                          ** max : 50
    !                          ** min : -40
    !                          ** default : 15
    !                          ** unit : Â°C
        !- outputs:
    !            * name: SoilTemperatureByLayers
    !                          ** description : Soil temperature of each layer
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 60
    !                          ** min : -60
    !                          ** unit : Â°C
        _SoilProfileDepthmm = SoilProfileDepth * 1000
        _TotalWaterContentmm = REAL(0)
        DO i = 0 , SIZE(LayerThickness)-1, 1
            _TotalWaterContentmm = _TotalWaterContentmm +  &
                    (VolumetricWaterContent(i+1) * LayerThickness(i+1))
        END DO
        _TotalWaterContentmm = _TotalWaterContentmm * 1000
        _MaximumDumpingDepth = REAL(0)
        _DumpingDepth = REAL(0)
        _ScalingFactor = REAL(0)
        _DepthBottom = REAL(0)
        _RatioCenter = REAL(0)
        _DepthFactor = REAL(0)
        _DepthCenterLayer = LayerThickness(1) * 1000 / 2
        _MaximumDumpingDepth = 1000 + (2500 * BulkDensity(1) /  &
                (BulkDensity(1) + (686 * EXP((-5.63) * BulkDensity(1)))))
        _ScalingFactor = _TotalWaterContentmm / ((0.356 - (0.144 *  &
                BulkDensity(1))) * _SoilProfileDepthmm)
        _DumpingDepth = _MaximumDumpingDepth * EXP(LOG(500 /  &
                _MaximumDumpingDepth) *  (((1 - _ScalingFactor) / (1 +  &
                _ScalingFactor)) ** 2))
        _RatioCenter = _DepthCenterLayer / _DumpingDepth
        _DepthFactor = _RatioCenter / (_RatioCenter + EXP(-0.867 - (2.078 *  &
                _RatioCenter)))
        SoilTemperatureByLayers(1) = LagCoefficient *  &
                SoilTemperatureByLayers(1) + ((1 - LagCoefficient) * (_DepthFactor *  &
                (AirTemperatureAnnualAverage - SurfaceSoilTemperature) +  &
                SurfaceSoilTemperature))
        DO i = 1 , SIZE(LayerThickness)-1, 1
            _DepthBottom = _DepthBottom + (LayerThickness((i - 1)+1) * 1000)
            _DepthCenterLayer = _DepthBottom + (LayerThickness(i+1) * 1000 / 2)
            _MaximumDumpingDepth = 1000 + (2500 * BulkDensity(i+1) /  &
                    (BulkDensity(i+1) + (686 * EXP((-5.63) * BulkDensity(i+1)))))
            _ScalingFactor = _TotalWaterContentmm / ((0.356 - (0.144 *  &
                    BulkDensity(i+1))) * _SoilProfileDepthmm)
            _DumpingDepth = _MaximumDumpingDepth * EXP(LOG(500 /  &
                    _MaximumDumpingDepth) *  (((1 - _ScalingFactor) / (1 +  &
                    _ScalingFactor)) ** 2))
            _RatioCenter = _DepthCenterLayer / _DumpingDepth
            _DepthFactor = _RatioCenter / (_RatioCenter + EXP(-0.867 - (2.078 *  &
                    _RatioCenter)))
            SoilTemperatureByLayers(i+1) = LagCoefficient *  &
                    SoilTemperatureByLayers(i+1) + ((1 - LagCoefficient) * (_DepthFactor  &
                    * (AirTemperatureAnnualAverage - SurfaceSoilTemperature) +  &
                    SurfaceSoilTemperature))
        END DO
    END SUBROUTINE model_soiltemperatureswat

END MODULE
