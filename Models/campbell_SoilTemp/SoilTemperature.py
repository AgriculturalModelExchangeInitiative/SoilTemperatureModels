

def model_SoilTemperature():
    """
    - Name: SoilTemperature
    - Version: 1.0
    - Time step: 1
    - Description:
                * Title: SoilTemperature model
                * Author: name
                * Reference: ref
                * Institution: CIRAD
                * ExtendedDescription: TODO
                * ShortDescription: TODO
    
    - inputs: 
                * name:  
                            ** description : Sum of photoperiods received by the crop since the beginning of the vegetative phase.
                            ** inputtype : variable
                            ** variablecategory : state
                            ** datatype : DOUBLE
                            ** default : 0.0
                            ** min : 0.0
                            ** max : 
                            ** unit : h
                            ** uri : 
                * name: PPSens
                            ** description : Photoperiod sensitivity of the crop. Range 0.3-0.6 is PP sensitive, sensititivity disappears towards values of 0.7 to 1.
                            ** inputtype : parameter
                            ** parametercategory : species
                            ** datatype : DOUBLE
                            ** default : 0.4
                            ** min : 0.2
                            ** max : 3.0
                            ** unit : dimensionless
                            ** uri : 
                * name: SommeDegresJour
                            ** description : Sum of degree days accumulated by the crop since the beginning of the simulation.
                            ** inputtype : variable
                            ** variablecategory : state
                            ** datatype : DOUBLE
                            ** default : 
                            ** min : 0.0
                            ** max : 
                            ** unit : degC*d
                            ** uri : 
                * name: SeuilTempLevee
                            ** description : Temperature threshold for crop emergence / germination (but may be overrode by drought).
                            ** inputtype : parameter
                            ** parametercategory : species
                            ** datatype : DOUBLE
                            ** default : 50.0
                            ** min : 0.0
                            ** max : 
                            ** unit : degC*d
                            ** uri : 
                * name: SeuilTempBVP
                            ** description : Temperature threshold for earliest possible panicle initiation (PI), onset of basic vegetative phase (BVP) with internode and panicle (structural component) development.
                            ** inputtype : parameter
                            ** parametercategory : species
                            ** datatype : DOUBLE
                            ** default : 400.0
                            ** min : 200.0
                            ** max : 1000.0
                            ** unit : degC*d
                            ** uri : 
                * name: SeuilTempRPR
                            ** description : Temperature threshold for flowering (reproductive phase). 
                            ** inputtype : parameter
                            ** parametercategory : species
                            ** datatype : DOUBLE
                            ** default : 400.0
                            ** min : 200.0
                            ** max : 600.0
                            ** unit : degC*d
                            ** uri : 
                * name: SeuilTempMatu1
                            ** description : Temperature threshold for end of grain filling. No more structural growth happens.
                            ** inputtype : parameter
                            ** parametercategory : species
                            ** datatype : DOUBLE
                            ** default : 400.0
                            ** min : 200.0
                            ** max : 600.0
                            ** unit : degC*d
                            ** uri : 
                * name: SeuilTempMatu2
                            ** description : Temperature threshold for maturity/harvest date. No more growth but Assimilation & Rm continue, causing changes in IN.
                            ** inputtype : parameter
                            ** parametercategory : species
                            ** datatype : DOUBLE
                            ** default : 50.0
                            ** min : 0.0
                            ** max : 300.0
                            ** unit : degC*d
                            ** uri : 
                * name: StockSurface
                            ** description : Water column stored in topsoil layer.
                            ** inputtype : variable
                            ** variablecategory : state
                            ** datatype : DOUBLE
                            ** default : 
                            ** min : 0.0
                            ** max : 20.0
                            ** unit : mm
                            ** uri : 
                * name: PourcRuSurfGermi
                            ** description : Top soil relative water content required for germination. 
                            ** inputtype : parameter
                            ** parametercategory : species
                            ** datatype : DOUBLE
                            ** default : 0.6
                            ** min : 0.4
                            ** max : 1.0
                            ** unit : dimensionless
                            ** uri : 
                * name: RuSurf
                            ** description : Useful water reserve of surface horizon.
                            ** inputtype : variable
                            ** variablecategory : state
                            ** datatype : DOUBLE
                            ** default : 
                            ** min : 0.0
                            ** max : 
                            ** unit : mm
                            ** uri : 
                * name: stRu
                            ** description : Total water column stored in soil profile.
                            ** inputtype : variable
                            ** variablecategory : state
                            ** datatype : DOUBLE
                            ** default : 
                            ** min : 0.0
                            ** max : 
                            ** unit : mm
                            ** uri : 
                * name: NumPhase
                            ** description : Current crop phenological phase (e.g., 1 for germination, 2 for BVP, etc.).
                            ** inputtype : variable
                            ** variablecategory : state
                            ** datatype : INT
                            ** default : 0
                            ** min : 0
                            ** max : 7
                            ** unit : dimensionless
                            ** uri : 
                * name: SommeDegresJourPhasePrec
                            ** description : Sum of degree days accumulated during the previous phenological phase.
                            ** inputtype : variable
                            ** variablecategory : state
                            ** datatype : DOUBLE
                            ** default : 
                            ** min : 0.0
                            ** max : 
                            ** unit : degC*d
                            ** uri : 
                * name: SeuilTempPhaseSuivante
                            ** description : Temperature threshold for the next phenological phase.
                            ** inputtype : variable
                            ** variablecategory : state
                            ** datatype : DOUBLE
                            ** default : 400.0
                            ** min : 200.0
                            ** max : 1000.0
                            ** unit : degC*d
                            ** uri : 
                * name: SeuilTempSousPhaseSuivante
                            ** description : Temperature threshold for the next phenological subphase.
                            ** inputtype : variable
                            ** variablecategory : state
                            ** datatype : DOUBLE
                            ** default : 
                            ** min : 
                            ** max : 
                            ** unit : degC*d
                            ** uri : 
                * name: NumSousPhase
                            ** description : Current crop RPR subphase.
                            ** inputtype : variable
                            ** variablecategory : state
                            ** datatype : INT
                            ** default : 0
                            ** min : 0
                            ** max : 4
                            ** unit : dimensionless
                            ** uri : 
                * name: MonCompteur
                            ** description : Number of days spent in a RPR subphase.
                            ** inputtype : variable
                            ** variablecategory : auxiliary
                            ** datatype : INT
                            ** default : 0
                            ** min : 0
                            ** max : 
                            ** unit : dimensionless
                            ** uri : 
    - outputs: 
                * name: NumPhase
                            ** description : Current crop phenological phase (e.g., 1 for germination, 2 for BVP, etc.).
                            ** variablecategory : state
                            ** datatype : INT
                            ** min : 0
                            ** max : 7
                            ** unit : dimensionless
                            ** uri : 
                * name: SommeDegresJourPhasePrec
                            ** description : Sum of degree days accumulated during the previous phenological phase.
                            ** variablecategory : state
                            ** datatype : DOUBLE
                            ** min : 0.0
                            ** max : 
                            ** unit : degC*d
                            ** uri : 
                * name: SeuilTempPhaseSuivante
                            ** description : Temperature threshold for the next phenological phase.
                            ** variablecategory : state
                            ** datatype : DOUBLE
                            ** min : 200.0
                            ** max : 1000.0
                            ** unit : degC*d
                            ** uri : 
                * name: ChangePhase
                            ** description : Indicates whether the current day is a day of phenological phase change (1) or not (0). Makes initialization easier.
                            ** variablecategory : auxiliary
                            ** datatype : BOOLEAN
                            ** min : 
                            ** max : 
                            ** unit : dimensionless
                            ** uri : 
                * name: SeuilTempSousPhaseSuivante
                            ** description : Temperature threshold for the next phenological subphase.
                            ** variablecategory : state
                            ** datatype : DOUBLE
                            ** min : 
                            ** max : 
                            ** unit : degC*d
                            ** uri : 
                * name: ChangeSousPhase
                            ** description : Indicates whether the current day is a day of RPR subphase change (1) or not (0).
                            ** variablecategory : auxiliary
                            ** datatype : BOOLEAN
                            ** min : 
                            ** max : 
                            ** unit : dimensionless
                            ** uri : 
                * name: NumSousPhase
                            ** description : Current crop RPR subphase.
                            ** variablecategory : state
                            ** datatype : INT
                            ** min : 0
                            ** max : 4
                            ** unit : dimensionless
                            ** uri : 
                * name: MonCompteur
                            ** description : Number of days spent in a RPR subphase.
                            ** variablecategory : auxiliary
                            ** datatype : INT
                            ** min : 0
                            ** max : 
                            ** unit : dimensionless
                            ** uri : 
    """