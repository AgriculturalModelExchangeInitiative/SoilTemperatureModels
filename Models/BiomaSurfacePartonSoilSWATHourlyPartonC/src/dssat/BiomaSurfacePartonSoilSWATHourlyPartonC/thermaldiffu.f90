MODULE Thermaldiffumod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_thermaldiffu(ThermalDiffusivity, &
        ThermalConductivity, &
        HeatCapacity, &
        layersNumber)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(INOUT) :: ThermalDiffusivity
        REAL , DIMENSION(: ), INTENT(IN) :: ThermalConductivity
        REAL , DIMENSION(: ), INTENT(IN) :: HeatCapacity
        INTEGER, INTENT(IN) :: layersNumber
        INTEGER:: i
        !- Name: ThermalDiffu -Version: 001, -Time step: 1
        !- Description:
    !            * Title: ThermalDiffu model
    !            * Authors: simone.bregaglio
    !            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    !            * Institution: University Of Milan
    !            * ExtendedDescription: Strategy for the calculation of thermal diffusitivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series
    !            * ShortDescription: Strategy for the calculation of thermal diffusitivity
        !- inputs:
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
    !            * name: ThermalConductivity
    !                          ** description : Thermal conductivity of soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 8
    !                          ** min : 0.025
    !                          ** default : 1
    !                          ** unit : W m-1 K-1
    !            * name: HeatCapacity
    !                          ** description : Volumetric specific heat of soil
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 300
    !                          ** min : 0
    !                          ** default : 20
    !                          ** unit : MJ m-3
    !            * name: layersNumber
    !                          ** description : Number of layersl
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : INT
    !                          ** max : 300
    !                          ** min : 0
    !                          ** default : 10
    !                          ** unit : dimensionless
        !- outputs:
    !            * name: ThermalDiffusivity
    !                          ** description : Thermal diffusivity of soil layer
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 1
    !                          ** min : 0
    !                          ** unit : mm s-1
        DO i = 0 , layersNumber-1, 1
            ThermalDiffusivity(i+1) = ThermalConductivity(i+1) /  &
                    HeatCapacity(i+1) / 100
        END DO
    END SUBROUTINE model_thermaldiffu

END MODULE
