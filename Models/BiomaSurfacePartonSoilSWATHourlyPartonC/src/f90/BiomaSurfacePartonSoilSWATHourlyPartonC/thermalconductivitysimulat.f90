MODULE Thermalconductivitysimulatmod
    IMPLICIT NONE
CONTAINS

    SUBROUTINE model_thermalconductivitysimulat(VolumetricWaterContent, &
        BulkDensity, &
        Clay, &
        ThermalConductivity)
        IMPLICIT NONE
        INTEGER:: i_cyml_r
        REAL , DIMENSION(: ), INTENT(IN) :: VolumetricWaterContent
        REAL , DIMENSION(: ), INTENT(IN) :: BulkDensity
        REAL , DIMENSION(: ), INTENT(IN) :: Clay
        REAL , DIMENSION(: ), INTENT(OUT) :: ThermalConductivity
        INTEGER:: i
        REAL:: Aterm
        REAL:: Bterm
        REAL:: Cterm
        REAL:: Dterm
        REAL:: Eterm
        !- Name: ThermalConductivitySIMULAT -Version: 001, -Time step: 1
        !- Description:
    !            * Title: ThermalConductivitySIMULAT model
    !            * Authors: simone.bregaglio@unimi.it
    !            * Reference: ('http://bioma.jrc.ec.europa.eu/ontology/JRC_MARS_biophysical_domain.owl',)
    !            * Institution: University Of Milan
    !            * ExtendedDescription: Strategy for the calculation of thermal conductivity. Bristow, K.L., Thermal conductivity, in Methods of Soil Analysis. Part 4. Physical Methods, J.H. Dane and G.C. Topp, Editors. 2002, Soil Science Society of America Book Series #5: Madison, Wisconsin. p. 1209-1226. Diekkruger, B. (1996) SIMULAT - Ein Modellsystem zur Berechnung der Wasser- und Stoffdynamik landwirtschaftlich genutzter Standorte (SIMULAT - a model system for the calculation of water and matter dynamics on agricultural sites, in German). In: Wasser- und Stoffdynamik in AgrarÃ´kosystemen, Sonderf.
    !            * ShortDescription: None
        !- inputs:
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
        !- outputs:
    !            * name: ThermalConductivity
    !                          ** description : Thermal conductivity of soil layer
    !                          ** datatype : DOUBLEARRAY
    !                          ** variablecategory : state
    !                          ** len : 
    !                          ** max : 8
    !                          ** min : 0.025
    !                          ** unit : W m-1 K-1
        Aterm = REAL(0)
        Bterm = REAL(0)
        Cterm = REAL(0)
        Dterm = REAL(0)
        Eterm = REAL(4)
        DO i = 0 , SIZE(VolumetricWaterContent)-1, 1
            Aterm = 0.65 - (0.78 * BulkDensity(i+1)) + (0.6 *  (BulkDensity(i+1)  &
                    ** 2))
            Bterm = 1.06 * BulkDensity(i+1) * VolumetricWaterContent(i+1)
            Cterm = 1 + (2.6 * SQRT(Clay(i+1) / 100))
            Dterm = 0.03 + (0.1 *  (BulkDensity(i+1) ** 2))
            ThermalConductivity(i+1) = Aterm + (Bterm *  &
                    VolumetricWaterContent(i+1)) - ((Aterm - Dterm) *  (EXP((-Cterm *  &
                    VolumetricWaterContent(i+1))) ** Eterm))
        END DO
    END SUBROUTINE model_thermalconductivitysimulat

END MODULE
