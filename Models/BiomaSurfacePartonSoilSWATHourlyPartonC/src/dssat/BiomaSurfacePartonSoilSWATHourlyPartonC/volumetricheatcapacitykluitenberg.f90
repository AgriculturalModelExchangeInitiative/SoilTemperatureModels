MODULE Volumetricheatcapacitykluitenbergmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_volumetricheatcapacitykluitenberg(VolumetricWaterContent, &
        Sand, &
        BulkDensity, &
        OrganicMatter, &
        HeatCapacity, &
        Clay, &
        Silt)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(IN) :: VolumetricWaterContent
        REAL , DIMENSION(: ), INTENT(IN) :: Sand
        REAL , DIMENSION(: ), INTENT(IN) :: BulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: OrganicMatter
        REAL , DIMENSION(: ), INTENT(INOUT) :: HeatCapacity
        REAL , DIMENSION(: ), INTENT(IN) :: Clay
        REAL , DIMENSION(: ), INTENT(IN) :: Silt
        INTEGER:: i
        REAL:: SandFraction
        REAL:: SiltFraction
        REAL:: ClayFraction
        REAL:: FractionMinerals
        REAL:: OrganicMatterFraction
        !- Name: VolumetricHeatCapacityKluitenberg -Version: 001, -Time step: 1
        !- Description:
    !            * Title: VolumetricHeatCapacityKluitenberg model
    !            * Authors: simone.bregaglio
    !            * Reference: http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl
    !            * Institution: University Of Milan
    !            * ExtendedDescription: Strategy for the calculation of soil thermal diffusivity. Reference: J.M.H.Hendrickx, H. Xie, B. Borchers, J.B.J. Harrison, 2008. Global Prediction of Thermal Soil Regimes. SPIE Proceedings Volume 6953 Detection and Sensing of Mines, Explosive Objects, and Obscured Targets XIII.
    !            * ShortDescription: Strategy for the calculation of volumetric heat capacity. Kluitenberg, G.J., Heat capacity and specific heat, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series
        !- inputs:
    !            * name: VolumetricWaterContent
    !                          ** description : Volumetric soil water content
    !                          ** inputtype : variable
    !                          ** variablecategory : exogenous
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 0.8
    !                          ** min : 0
    !                          ** default : 0.25
    !                          ** unit : m3 m-3
    !            * name: Sand
    !                          ** description : Sand content of soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 30
    !                          ** unit : 
    !            * name: BulkDensity
    !                          ** description : Bulk density
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 1.8
    !                          ** min : 0.9
    !                          ** default : 1.3
    !                          ** unit : t m-3
    !            * name: OrganicMatter
    !                          ** description : Organic matter content of soil layer
    !                          ** inputtype : variable
    !                          ** variablecategory : auxiliary
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 20
    !                          ** min : 0
    !                          ** default : 1.5
    !                          ** unit : 
    !            * name: HeatCapacity
    !                          ** description : Volumetric specific heat of soil
    !                          ** inputtype : variable
    !                          ** variablecategory : state
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 300
    !                          ** min : 0
    !                          ** default : 20
    !                          ** unit : MJ m-3
    !            * name: Clay
    !                          ** description : Clay content of soil layer
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 0
    !                          ** unit : 
    !            * name: Silt
    !                          ** description : Silt content of soil layer
    !                          ** inputtype : parameter
    !                          ** parametercategory : constant
    !                          ** datatype : DOUBLEARRAY
    !                          ** len : 
    !                          ** max : 100
    !                          ** min : 0
    !                          ** default : 20
    !                          ** unit : 
        !- outputs:
    !            * name: HeatCapacity
    !                          ** description : Volumetric specific heat of soil
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 300
    !                          ** min : 0
    !                          ** unit : MJ m-3
        SandFraction = REAL(0)
        SiltFraction = REAL(0)
        ClayFraction = REAL(0)
        FractionMinerals = REAL(0)
        OrganicMatterFraction = REAL(0)
        DO i = 0 , SIZE(HeatCapacity)-1, 1
            SandFraction = Sand(i+1) / (Sand(i+1) + Silt(i+1) + Clay(i+1) +  &
                    OrganicMatter(i+1))
            SiltFraction = Silt(i+1) / (Sand(i+1) + Silt(i+1) + Clay(i+1) +  &
                    OrganicMatter(i+1))
            ClayFraction = Clay(i+1) / (Sand(i+1) + Silt(i+1) + Clay(i+1) +  &
                    OrganicMatter(i+1))
            FractionMinerals = SandFraction + SiltFraction + ClayFraction
            OrganicMatterFraction = OrganicMatter(i+1) / (Sand(i+1) + Silt(i+1) +  &
                    Clay(i+1) + OrganicMatter(i+1))
            HeatCapacity(i+1) = BulkDensity(i+1) * 0.73 * FractionMinerals +  &
                    (BulkDensity(i+1) * 1.9 * OrganicMatterFraction) + (4.18 *  &
                    VolumetricWaterContent(i+1))
        END DO
    END SUBROUTINE model_volumetricheatcapacitykluitenberg

END MODULE
