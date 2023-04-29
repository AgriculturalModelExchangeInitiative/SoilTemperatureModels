MODULE Rangeofsoiltemperaturesdaycentmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_rangeofsoiltemperaturesdaycent(LayerThickness, &
        SurfaceTemperatureMinimum, &
        ThermalDiffusivity, &
        SoilTemperatureByLayers, &
        SurfaceTemperatureMaximum, &
        SoilTemperatureRangeByLayers, &
        SoilTemperatureMinimum, &
        SoilTemperatureMaximum)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(IN) :: LayerThickness
        REAL, INTENT(IN) :: SurfaceTemperatureMinimum
        REAL , DIMENSION(: ), INTENT(IN) :: ThermalDiffusivity
        REAL , DIMENSION(: ), INTENT(IN) :: SoilTemperatureByLayers
        REAL, INTENT(IN) :: SurfaceTemperatureMaximum
        REAL , DIMENSION(: ), INTENT(OUT) :: SoilTemperatureRangeByLayers
        REAL , DIMENSION(: ), INTENT(OUT) :: SoilTemperatureMinimum
        REAL , DIMENSION(: ), INTENT(OUT) :: SoilTemperatureMaximum
        INTEGER:: i
        REAL:: _DepthBottom
        REAL:: _DepthCenterLayer
        REAL:: SurfaceDiurnalRange
        !- Name: RangeOfSoilTemperaturesDAYCENT -Version: 001, -Time step: 1
        !- Description:
    !            * Title: RangeOfSoilTemperaturesDAYCENT model
    !            * Authors: simone.bregaglio@unimi.it
    !            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    !            * Institution: University Of Milan
    !            * ExtendedDescription: Strategy for the calculation of soil thermal conductivity.Reference: DAYCENT model written in C code 
    !            * ShortDescription: None
        !- inputs:
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
    !            * name: SurfaceTemperatureMinimum
    !                          ** description : Minimum surface soil temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 10
    !                          ** unit : Â°C
    !            * name: ThermalDiffusivity
    !                          ** description : Thermal diffusivity of soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 1
    !                          ** min : 0
    !                          ** default : 0.0025
    !                          ** unit : mm s-1
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
    !            * name: SurfaceTemperatureMaximum
    !                          ** description : Maximum surface soil temperature
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLE
    !                          ** max : 60
    !                          ** min : -60
    !                          ** default : 25
    !                          ** unit : Â°C
        !- outputs:
    !            * name: SoilTemperatureRangeByLayers
    !                          ** description : Soil temperature range by layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 50
    !                          ** min : 0
    !                          ** unit : Â°C
    !            * name: SoilTemperatureMinimum
    !                          ** description : Minimum soil temperature by layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 60
    !                          ** min : -60
    !                          ** unit : Â°C
    !            * name: SoilTemperatureMaximum
    !                          ** description : Maximum soil temperature by layers
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 60
    !                          ** min : -60
    !                          ** unit : Â°C
        _DepthBottom = REAL(0)
        _DepthCenterLayer = REAL(0)
        SurfaceDiurnalRange = SurfaceTemperatureMaximum -  &
                SurfaceTemperatureMinimum
        DO i = 0 , SIZE(SoilTemperatureByLayers)-1, 1
            IF(i .EQ. 0) THEN
                _DepthCenterLayer = LayerThickness(1) * 100 / 2
                SoilTemperatureRangeByLayers(1) = SurfaceDiurnalRange *  &
                        EXP((-_DepthCenterLayer) *  ((0.00005 / ThermalDiffusivity(1)) **  &
                        0.5))
                SoilTemperatureMaximum(1) = SoilTemperatureByLayers(1) +  &
                        (SoilTemperatureRangeByLayers(1) / 2)
                SoilTemperatureMinimum(1) = SoilTemperatureByLayers(1) -  &
                        (SoilTemperatureRangeByLayers(1) / 2)
            ELSE
                _DepthBottom = _DepthBottom + (LayerThickness((i - 1)+1) * 100)
                _DepthCenterLayer = _DepthBottom + (LayerThickness(i+1) * 100 / 2)
                SoilTemperatureRangeByLayers(i+1) = SurfaceDiurnalRange *  &
                        EXP((-_DepthCenterLayer) *  ((0.00005 / ThermalDiffusivity(i+1)) **  &
                        0.5))
                SoilTemperatureMaximum(i+1) = SoilTemperatureByLayers(i+1) +  &
                        (SoilTemperatureRangeByLayers(i+1) / 2)
                SoilTemperatureMinimum(i+1) = SoilTemperatureByLayers(i+1) -  &
                        (SoilTemperatureRangeByLayers(i+1) / 2)
            END IF
        END DO
    END SUBROUTINE model_rangeofsoiltemperaturesdaycent

END MODULE
