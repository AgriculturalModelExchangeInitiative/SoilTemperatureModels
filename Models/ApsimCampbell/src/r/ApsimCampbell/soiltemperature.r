library(gsubfn)

#' Initialization of the SoilTemperature
#' 
#' This function initialize the SoilTemperature
#' @param weather_MinT (oC) Minimum temperature exogenous (, -) 
#' @param weather_MaxT (oC) Maximum temperature exogenous (, -) 
#' @param weather_MeanT (oC) Mean temperature exogenous (, -) 
#' @param weather_Tav (oC) Annual average temperature exogenous (, -) 
#' @param weather_Amp (oC) Annual average temperature amplitude exogenous (, -) 
#' @param weather_AirPressure (hPa) Air pressure exogenous (, -) 
#' @param weather_Wind (m/s) Wind speed exogenous (, -) 
#' @param weather_Latitude (deg) Latitude constant (, -) 
#' @param weather_Radn (MJ/m2/day) Solar radiation exogenous (, -) 
#' @param clock_Today_DayOfYear (day number) Day of year exogenous (, -) 
#' @param microClimate_CanopyHeight (mm) Canopy height exogenous (, -) 
#' @param physical_Thickness (mm) Soil layer thickness constant (, -) 
#' @param physical_BD (g/cc) Bulk density constant (, -) 
#' @param ps () ps constant (, -) 
#' @param physical_Rocks (%) Rocks exogenous (, -) 
#' @param physical_ParticleSizeSand (%) Particle size sand exogenous (, -) 
#' @param physical_ParticleSizeSilt (%) Particle size silt exogenous (, -) 
#' @param physical_ParticleSizeClay (%) Particle size clay exogenous (, -) 
#' @param organic_Carbon (%) Total organic carbon exogenous (, -) 
#' @param waterBalance_SW (mm/mm) Volumetric water content exogenous (, -) 
#' @param waterBalance_Eos (mm) Potential soil evaporation from soil surface exogenous (, -) 
#' @param waterBalance_Eo (mm) Potential soil evapotranspiration from soil surface exogenous (, -) 
#' @param waterBalance_Es (mm) Actual (realised) soil water evaporation exogenous (, -) 
#' @param waterBalance_Salb (0-1) Fraction of incoming radiation reflected from bare soil exogenous (, -) 
#' @param pInitialValues (oC) Initial soil temperature constant (, -) 
#' @param DepthToConstantTemperature (mm) Soil depth to constant temperature constant (10000, -) 
#' @param timestep (minutes) Internal time-step (minutes) constant (24.0 * 60.0 * 60.0, -) 
#' @param latentHeatOfVapourisation (miJ/kg) Latent heat of vapourisation for water constant (2465000, -) 
#' @param stefanBoltzmannConstant (W/m2/K4) The Stefan-Boltzmann constant constant (0.0000000567, -) 
#' @param airNode () The index of the node in the atmosphere (aboveground) constant (0, -) 
#' @param surfaceNode () The index of the node on the soil surface (depth = 0) constant (1, -) 
#' @param topsoilNode () The index of the first node within the soil (top layer) constant (2, -) 
#' @param numPhantomNodes () The number of phantom nodes below the soil profile constant (5, -) 
#' @param constantBoundaryLayerConductance (K/W) Boundary layer conductance, if constant constant (20, -) 
#' @param numIterationsForBoundaryLayerConductance () Number of iterations to calculate atmosphere boundary layer conductance constant (1, -None) 
#' @param defaultTimeOfMaximumTemperature (minutes) Time of maximum temperature constant (14.0, -) 
#' @param defaultInstrumentHeight (m) Default instrument height constant (1.2, -) 
#' @param bareSoilRoughness (mm) Roughness element height of bare soil constant (57, -) 
#' @param nodeDepth (mm) Depths of nodes private (, -) 
#' @param thermCondPar1 () Parameter 1 for computing thermal conductivity of soil solids private (, -) 
#' @param thermCondPar2 () Parameter 2 for computing thermal conductivity of soil solids private (, -) 
#' @param thermCondPar3 () Parameter 3 for computing thermal conductivity of soil solids private (, -) 
#' @param thermCondPar4 () Parameter 4 for computing thermal conductivity of soil solids private (, -) 
#' @param pom (Mg/m3) Particle density of organic matter constant (, -) 
#' @param soilRoughnessHeight (mm) Height of soil roughness private (0, -) 
#' @param nu (0-1) Forward/backward differencing coefficient constant (0.6, -) 
#' @param boundarLayerConductanceSource () Flag whether boundary layer conductance is calculated or gotten from inpu constant (calc, -) 
#' @param netRadiationSource (m) Flag whether net radiation is calculated or gotten from input constant (calc, -) 
#' @param MissingValue (m) missing value constant (99999, -) 
#' @param soilConstituentNames (m) soilConstituentNames constant (["Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"], -) 
#'
#' @return
#' \describe{
#'   \item{heatStorage (J/K)}{CP, heat storage between nodes state (-)}
#'   \item{instrumentHeight (mm)}{Height of instruments above soil surface state (-)}
#'   \item{canopyHeight (mm)}{Height of canopy above ground state (-)}
#'   \item{minSoilTemp (oC)}{Minimum soil temperature state (-)}
#'   \item{maxSoilTemp (oC)}{Maximum soil temperature state (-)}
#'   \item{aveSoilTemp (oC)}{average soil temperature state (-)}
#'   \item{volSpecHeatSoil (J/K/m3)}{Volumetric specific heat over the soil profile state (-)}
#'   \item{soilTemp (oC)}{Soil temperature over the soil profile at morning state (-)}
#'   \item{morningSoilTemp (oC)}{Soil temperature over the soil profile at morning state (-)}
#'   \item{newTemperature (oC)}{Soil temperature at the end of this iteration state (-)}
#'   \item{thermalConductivity (W.m/K)}{Thermal conductivity state (-)}
#'   \item{thermalConductance (W/K)}{K, conductance of element between nodes state (-)}
#'   \item{boundaryLayerConductance ()}{Average daily atmosphere boundary layer conductance state (-)}
#'   \item{soilWater (mm3/mm3)}{Volumetric water content of each soil layer state (-)}
#'   \item{doInitialisationStuff ()}{Flag whether initialisation is needed state (-)}
#'   \item{maxTempYesterday (oC)}{Yesterday's maximum daily air temperature (oC) state (-)}
#'   \item{minTempYesterday (oC)}{Yesterday's minimum daily air temperature (oC) state (-)}
#'   \item{airTemperature (oC)}{Air temperature state (-)}
#'   \item{internalTimeStep (sec)}{Internal time-step state (-)}
#'   \item{timeOfDaySecs (sec)}{Time of day from midnight state (-)}
#'   \item{netRadiation (MJ)}{Net radiation per internal time-step state (-)}
#'   \item{InitialValues (oC)}{Initial soil temperature state (-)}
#' }
#' @export
init_soiltemperature <- function (weather_MinT,
         weather_MaxT,
         weather_MeanT,
         weather_Tav,
         weather_Amp,
         weather_AirPressure,
         weather_Wind,
         weather_Latitude,
         weather_Radn,
         clock_Today_DayOfYear,
         microClimate_CanopyHeight,
         physical_Thickness,
         physical_BD,
         ps,
         physical_Rocks,
         physical_ParticleSizeSand,
         physical_ParticleSizeSilt,
         physical_ParticleSizeClay,
         organic_Carbon,
         waterBalance_SW,
         waterBalance_Eos,
         waterBalance_Eo,
         waterBalance_Es,
         waterBalance_Salb,
         pInitialValues,
         DepthToConstantTemperature,
         timestep,
         latentHeatOfVapourisation,
         stefanBoltzmannConstant,
         airNode,
         surfaceNode,
         topsoilNode,
         numPhantomNodes,
         constantBoundaryLayerConductance,
         numIterationsForBoundaryLayerConductance,
         defaultTimeOfMaximumTemperature,
         defaultInstrumentHeight,
         bareSoilRoughness,
         nodeDepth,
         thermCondPar1,
         thermCondPar2,
         thermCondPar3,
         thermCondPar4,
         pom,
         soilRoughnessHeight,
         nu,
         boundarLayerConductanceSource,
         netRadiationSource,
         MissingValue,
         soilConstituentNames){
    InitialValues<- vector()
    doInitialisationStuff <- FALSE
    internalTimeStep <- 0.0
    timeOfDaySecs <- 0.0
    numNodes <- 0
    numLayers <- 0
    volSpecHeatSoil<- vector()
    soilTemp<- vector()
    morningSoilTemp<- vector()
    heatStorage<- vector()
    thermalConductance<- vector()
    thermalConductivity<- vector()
    boundaryLayerConductance <- 0.0
    newTemperature<- vector()
    airTemperature <- 0.0
    maxTempYesterday <- 0.0
    minTempYesterday <- 0.0
    soilWater<- vector()
    minSoilTemp<- vector()
    maxSoilTemp<- vector()
    aveSoilTemp<- vector()
    aveSoilWater<- vector()
    thickness<- vector()
    bulkDensity<- vector()
    rocks<- vector()
    carbon<- vector()
    sand<- vector()
    silt<- vector()
    clay<- vector()
    instrumentHeight <- 0.0
    netRadiation <- 0.0
    canopyHeight <- 0.0
    instrumHeight <- 0.0
    InitialValues <- NULL
    volSpecHeatSoil <- NULL
    soilTemp <- NULL
    morningSoilTemp <- NULL
    heatStorage <- NULL
    thermalConductance <- NULL
    thermalConductivity <- NULL
    newTemperature <- NULL
    soilWater <- NULL
    minSoilTemp <- NULL
    maxSoilTemp <- NULL
    aveSoilTemp <- NULL
    aveSoilWater <- NULL
    thickness <- NULL
    bulkDensity <- NULL
    rocks <- NULL
    carbon <- NULL
    sand <- NULL
    silt <- NULL
    clay <- NULL
    doInitialisationStuff <- TRUE
    instrumentHeight <- getIniVariables(instrumentHeight, instrumHeight, defaultInstrumentHeight)
    result <-  getProfileVariables(heatStorage, minSoilTemp, bulkDensity, numNodes, physical_BD, maxSoilTemp, waterBalance_SW, organic_Carbon, physical_Rocks, nodeDepth, topsoilNode, newTemperature, surfaceNode, soilWater, thermalConductance, thermalConductivity, sand, carbon, thickness, numPhantomNodes, physical_ParticleSizeSand, rocks, clay, physical_ParticleSizeSilt, airNode, physical_ParticleSizeClay, soilTemp, numLayers, physical_Thickness, silt, volSpecHeatSoil, aveSoilTemp, morningSoilTemp, DepthToConstantTemperature, MissingValue)
    heatStorage <- result[[1]]
    minSoilTemp <- result[[2]]
    bulkDensity <- result[[3]]
    maxSoilTemp <- result[[4]]
    nodeDepth <- result[[5]]
    newTemperature <- result[[6]]
    soilWater <- result[[7]]
    thermalConductance <- result[[8]]
    thermalConductivity <- result[[9]]
    sand <- result[[10]]
    carbon <- result[[11]]
    thickness <- result[[12]]
    rocks <- result[[13]]
    clay <- result[[14]]
    soilTemp <- result[[15]]
    silt <- result[[16]]
    volSpecHeatSoil <- result[[17]]
    aveSoilTemp <- result[[18]]
    morningSoilTemp <- result[[19]]
    numNodes <- result[[20]]
    numLayers <- result[[21]]
    result <-  readParam(bareSoilRoughness, newTemperature, soilRoughnessHeight, soilTemp, thermCondPar2, numLayers, bulkDensity, numNodes, thermCondPar3, thermCondPar4, clay, thermCondPar1, weather_Tav, clock_Today_DayOfYear, surfaceNode, weather_Amp, thickness, weather_Latitude)
    newTemperature <- result[[1]]
    soilTemp <- result[[2]]
    thermCondPar2 <- result[[3]]
    thermCondPar3 <- result[[4]]
    thermCondPar4 <- result[[5]]
    thermCondPar1 <- result[[6]]
    soilRoughnessHeight <- result[[7]]
    InitialValues <- pInitialValues
    return (list ("InitialValues" = InitialValues,"doInitialisationStuff" = doInitialisationStuff,"internalTimeStep" = internalTimeStep,"timeOfDaySecs" = timeOfDaySecs,"numNodes" = numNodes,"numLayers" = numLayers,"nodeDepth" = nodeDepth,"thermCondPar1" = thermCondPar1,"thermCondPar2" = thermCondPar2,"thermCondPar3" = thermCondPar3,"thermCondPar4" = thermCondPar4,"volSpecHeatSoil" = volSpecHeatSoil,"soilTemp" = soilTemp,"morningSoilTemp" = morningSoilTemp,"heatStorage" = heatStorage,"thermalConductance" = thermalConductance,"thermalConductivity" = thermalConductivity,"boundaryLayerConductance" = boundaryLayerConductance,"newTemperature" = newTemperature,"airTemperature" = airTemperature,"maxTempYesterday" = maxTempYesterday,"minTempYesterday" = minTempYesterday,"soilWater" = soilWater,"minSoilTemp" = minSoilTemp,"maxSoilTemp" = maxSoilTemp,"aveSoilTemp" = aveSoilTemp,"aveSoilWater" = aveSoilWater,"thickness" = thickness,"bulkDensity" = bulkDensity,"rocks" = rocks,"carbon" = carbon,"sand" = sand,"silt" = silt,"clay" = clay,"soilRoughnessHeight" = soilRoughnessHeight,"instrumentHeight" = instrumentHeight,"netRadiation" = netRadiation,"canopyHeight" = canopyHeight,"instrumHeight" = instrumHeight))
}

#' SoilTemperature
#'
#' This function compute the SoilTemperature
#' @param weather_MinT (oC) Minimum temperature exogenous (, -) 
#' @param weather_MaxT (oC) Maximum temperature exogenous (, -) 
#' @param weather_MeanT (oC) Mean temperature exogenous (, -) 
#' @param weather_Tav (oC) Annual average temperature exogenous (, -) 
#' @param weather_Amp (oC) Annual average temperature amplitude exogenous (, -) 
#' @param weather_AirPressure (hPa) Air pressure exogenous (, -) 
#' @param weather_Wind (m/s) Wind speed exogenous (, -) 
#' @param weather_Latitude (deg) Latitude constant (, -) 
#' @param weather_Radn (MJ/m2/day) Solar radiation exogenous (, -) 
#' @param clock_Today_DayOfYear (day number) Day of year exogenous (, -) 
#' @param microClimate_CanopyHeight (mm) Canopy height exogenous (, -) 
#' @param physical_Thickness (mm) Soil layer thickness constant (, -) 
#' @param physical_BD (g/cc) Bulk density constant (, -) 
#' @param ps () ps constant (, -) 
#' @param physical_Rocks (%) Rocks exogenous (, -) 
#' @param physical_ParticleSizeSand (%) Particle size sand exogenous (, -) 
#' @param physical_ParticleSizeSilt (%) Particle size silt exogenous (, -) 
#' @param physical_ParticleSizeClay (%) Particle size clay exogenous (, -) 
#' @param organic_Carbon (%) Total organic carbon exogenous (, -) 
#' @param waterBalance_SW (mm/mm) Volumetric water content exogenous (, -) 
#' @param waterBalance_Eos (mm) Potential soil evaporation from soil surface exogenous (, -) 
#' @param waterBalance_Eo (mm) Potential soil evapotranspiration from soil surface exogenous (, -) 
#' @param waterBalance_Es (mm) Actual (realised) soil water evaporation exogenous (, -) 
#' @param waterBalance_Salb (0-1) Fraction of incoming radiation reflected from bare soil exogenous (, -) 
#' @param InitialValues (oC) Initial soil temperature state (, -) 
#' @param pInitialValues (oC) Initial soil temperature constant (, -) 
#' @param DepthToConstantTemperature (mm) Soil depth to constant temperature constant (10000, -) 
#' @param timestep (minutes) Internal time-step (minutes) constant (24.0 * 60.0 * 60.0, -) 
#' @param latentHeatOfVapourisation (miJ/kg) Latent heat of vapourisation for water constant (2465000, -) 
#' @param stefanBoltzmannConstant (W/m2/K4) The Stefan-Boltzmann constant constant (0.0000000567, -) 
#' @param airNode () The index of the node in the atmosphere (aboveground) constant (0, -) 
#' @param surfaceNode () The index of the node on the soil surface (depth = 0) constant (1, -) 
#' @param topsoilNode () The index of the first node within the soil (top layer) constant (2, -) 
#' @param numPhantomNodes () The number of phantom nodes below the soil profile constant (5, -) 
#' @param constantBoundaryLayerConductance (K/W) Boundary layer conductance, if constant constant (20, -) 
#' @param numIterationsForBoundaryLayerConductance () Number of iterations to calculate atmosphere boundary layer conductance constant (1, -None) 
#' @param defaultTimeOfMaximumTemperature (minutes) Time of maximum temperature constant (14.0, -) 
#' @param defaultInstrumentHeight (m) Default instrument height constant (1.2, -) 
#' @param bareSoilRoughness (mm) Roughness element height of bare soil constant (57, -) 
#' @param doInitialisationStuff (mintes) Flag whether initialisation is needed state (false, -) 
#' @param internalTimeStep (sec) Internal time-step state (0, -) 
#' @param timeOfDaySecs (sec) Time of day from midnight state (0, -) 
#' @param numNodes () Number of nodes over the soil profile state (0, -) 
#' @param numLayers () Number of layers in the soil profile state (0, -) 
#' @param nodeDepth (mm) Depths of nodes private (, -) 
#' @param thermCondPar1 () Parameter 1 for computing thermal conductivity of soil solids private (, -) 
#' @param thermCondPar2 () Parameter 2 for computing thermal conductivity of soil solids private (, -) 
#' @param thermCondPar3 () Parameter 3 for computing thermal conductivity of soil solids private (, -) 
#' @param thermCondPar4 () Parameter 4 for computing thermal conductivity of soil solids private (, -) 
#' @param volSpecHeatSoil (J/K/m3) Volumetric specific heat over the soil profile state (, -) 
#' @param soilTemp (oC) Soil temperature over the soil profile at morning state (, -) 
#' @param morningSoilTemp (oC) Soil temperature over the soil profile at morning state (, -) 
#' @param heatStorage (J/K) CP, heat storage between nodes state (, -) 
#' @param thermalConductance (W/K) K, conductance of element between nodes state (, -) 
#' @param thermalConductivity (W.m/K) Thermal conductivity state (, -) 
#' @param boundaryLayerConductance () Average daily atmosphere boundary layer conductance state (0, -) 
#' @param newTemperature (oC) Soil temperature at the end of this iteration state (, -) 
#' @param airTemperature (oC) Air temperature state (0, -) 
#' @param maxTempYesterday (oC) Yesterday's maximum daily air temperature state (0, -) 
#' @param minTempYesterday (oC) Yesterday's minimum daily air temperature state (0, -) 
#' @param soilWater (mm3/mm3) Volumetric water content of each soil layer state (, -) 
#' @param minSoilTemp (oC) Minimum soil temperature state (, -) 
#' @param maxSoilTemp (oC) Maximum soil temperature state (, -) 
#' @param aveSoilTemp (oC) average soil temperature state (, -) 
#' @param aveSoilWater (oC) Average soil temperaturer state (, -) 
#' @param thickness (mm) Thickness of each soil, includes phantom layer state (, -) 
#' @param bulkDensity (g/cm3) Soil bulk density, includes phantom layer state (, -) 
#' @param rocks (%) Volumetric fraction of rocks in each soil laye state (, -) 
#' @param carbon (%) Volumetric fraction of carbon (CHECK, OM?) in each soil layer state (, -) 
#' @param sand (%) Volumetric fraction of sand in each soil layer state (, -) 
#' @param pom (Mg/m3) Particle density of organic matter constant (, -) 
#' @param silt (%) Volumetric fraction of silt in each soil layer state (, -) 
#' @param clay (%) Volumetric fraction of clay in each soil layer state (, -) 
#' @param soilRoughnessHeight (mm) Height of soil roughness private (0, -) 
#' @param instrumentHeight (mm) Height of instruments above soil surface state (0, -) 
#' @param netRadiation (MJ) Net radiation per internal time-step state (0, -) 
#' @param canopyHeight (mm) Height of canopy above ground state (0, -) 
#' @param instrumHeight (mm) Height of instruments above ground state (0, -) 
#' @param nu (0-1) Forward/backward differencing coefficient constant (0.6, -) 
#' @param boundarLayerConductanceSource () Flag whether boundary layer conductance is calculated or gotten from inpu constant (calc, -) 
#' @param netRadiationSource (m) Flag whether net radiation is calculated or gotten from input constant (calc, -) 
#' @param MissingValue (m) missing value constant (99999, -) 
#' @param soilConstituentNames (m) soilConstituentNames constant (["Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"], -) 
#'
#' @return
#' \describe{
#'   \item{heatStorage (J/K)}{CP, heat storage between nodes state (-)} 
#'   \item{instrumentHeight (mm)}{Height of instruments above soil surface state (-)} 
#'   \item{canopyHeight (mm)}{Height of canopy above ground state (-)} 
#'   \item{minSoilTemp (oC)}{Minimum soil temperature state (-)} 
#'   \item{maxSoilTemp (oC)}{Maximum soil temperature state (-)} 
#'   \item{aveSoilTemp (oC)}{average soil temperature state (-)} 
#'   \item{volSpecHeatSoil (J/K/m3)}{Volumetric specific heat over the soil profile state (-)} 
#'   \item{soilTemp (oC)}{Soil temperature over the soil profile at morning state (-)} 
#'   \item{morningSoilTemp (oC)}{Soil temperature over the soil profile at morning state (-)} 
#'   \item{newTemperature (oC)}{Soil temperature at the end of this iteration state (-)} 
#'   \item{thermalConductivity (W.m/K)}{Thermal conductivity state (-)} 
#'   \item{thermalConductance (W/K)}{K, conductance of element between nodes state (-)} 
#'   \item{boundaryLayerConductance ()}{Average daily atmosphere boundary layer conductance state (-)} 
#'   \item{soilWater (mm3/mm3)}{Volumetric water content of each soil layer state (-)} 
#'   \item{doInitialisationStuff ()}{Flag whether initialisation is needed state (-)} 
#'   \item{maxTempYesterday (oC)}{Yesterday's maximum daily air temperature (oC) state (-)} 
#'   \item{minTempYesterday (oC)}{Yesterday's minimum daily air temperature (oC) state (-)} 
#'   \item{airTemperature (oC)}{Air temperature state (-)} 
#'   \item{internalTimeStep (sec)}{Internal time-step state (-)} 
#'   \item{timeOfDaySecs (sec)}{Time of day from midnight state (-)} 
#'   \item{netRadiation (MJ)}{Net radiation per internal time-step state (-)} 
#'   \item{InitialValues (oC)}{Initial soil temperature state (-)} 
#' }
#' @export
model_soiltemperature <- function (weather_MinT,
         weather_MaxT,
         weather_MeanT,
         weather_Tav,
         weather_Amp,
         weather_AirPressure,
         weather_Wind,
         weather_Latitude,
         weather_Radn,
         clock_Today_DayOfYear,
         microClimate_CanopyHeight,
         physical_Thickness,
         physical_BD,
         ps,
         physical_Rocks,
         physical_ParticleSizeSand,
         physical_ParticleSizeSilt,
         physical_ParticleSizeClay,
         organic_Carbon,
         waterBalance_SW,
         waterBalance_Eos,
         waterBalance_Eo,
         waterBalance_Es,
         waterBalance_Salb,
         InitialValues,
         pInitialValues,
         DepthToConstantTemperature,
         timestep,
         latentHeatOfVapourisation,
         stefanBoltzmannConstant,
         airNode,
         surfaceNode,
         topsoilNode,
         numPhantomNodes,
         constantBoundaryLayerConductance,
         numIterationsForBoundaryLayerConductance,
         defaultTimeOfMaximumTemperature,
         defaultInstrumentHeight,
         bareSoilRoughness,
         doInitialisationStuff,
         internalTimeStep,
         timeOfDaySecs,
         numNodes,
         numLayers,
         nodeDepth,
         thermCondPar1,
         thermCondPar2,
         thermCondPar3,
         thermCondPar4,
         volSpecHeatSoil,
         soilTemp,
         morningSoilTemp,
         heatStorage,
         thermalConductance,
         thermalConductivity,
         boundaryLayerConductance,
         newTemperature,
         airTemperature,
         maxTempYesterday,
         minTempYesterday,
         soilWater,
         minSoilTemp,
         maxSoilTemp,
         aveSoilTemp,
         aveSoilWater,
         thickness,
         bulkDensity,
         rocks,
         carbon,
         sand,
         pom,
         silt,
         clay,
         soilRoughnessHeight,
         instrumentHeight,
         netRadiation,
         canopyHeight,
         instrumHeight,
         nu,
         boundarLayerConductanceSource,
         netRadiationSource,
         MissingValue,
         soilConstituentNames){
    i <- 0
    result <-  getOtherVariables(numLayers, numNodes, soilWater, instrumentHeight, soilRoughnessHeight, waterBalance_SW, microClimate_CanopyHeight, canopyHeight)
    soilWater <- result[[1]]
    instrumentHeight <- result[[2]]
    canopyHeight <- result[[3]]
    if (doInitialisationStuff)
    {
        if (ValuesInArray(InitialValues, MissingValue))
        {
            soilTemp <-  rep(0.0,numNodes + 1 + 1)
            soilTemp[(topsoilNode + 1):(topsoilNode + length(InitialValues))] <- InitialValues[(0 + 1):(0 + length(InitialValues))]
        }
        else
        {
            soilTemp <- calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude)
            InitialValues <-  rep(0.0,numLayers)
            InitialValues[(0 + 1):(0 + numLayers)] <- soilTemp[(topsoilNode + 1):(topsoilNode + numLayers)]
        }
        soilTemp[airNode+1] <- weather_MeanT
        soilTemp[surfaceNode+1] <- calcSurfaceTemperature(weather_MeanT, weather_MaxT, waterBalance_Salb, weather_Radn)
        for( i in seq(numNodes + 1, length(soilTemp)-1, 1)){
            soilTemp[i+1] <- weather_Tav
        }
        newTemperature[(0 + 1):(0 + length(soilTemp))] <- soilTemp
        maxTempYesterday <- weather_MaxT
        minTempYesterday <- weather_MinT
        doInitialisationStuff <- FALSE
    }
    result <-  doProcess(timeOfDaySecs, netRadiation, minSoilTemp, maxSoilTemp, numIterationsForBoundaryLayerConductance, timestep, boundaryLayerConductance, maxTempYesterday, airNode, soilTemp, airTemperature, newTemperature, weather_MaxT, internalTimeStep, boundarLayerConductanceSource, thermalConductivity, minTempYesterday, aveSoilTemp, morningSoilTemp, weather_MeanT, constantBoundaryLayerConductance, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude, soilConstituentNames, numNodes, volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, defaultTimeOfMaximumTemperature, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, stefanBoltzmannConstant, weather_AirPressure, weather_Wind, instrumentHeight, canopyHeight, heatStorage, netRadiationSource, latentHeatOfVapourisation, waterBalance_Es, thermalConductance, nu)
    minSoilTemp <- result[[1]]
    maxSoilTemp <- result[[2]]
    soilTemp <- result[[3]]
    newTemperature <- result[[4]]
    thermalConductivity <- result[[5]]
    aveSoilTemp <- result[[6]]
    morningSoilTemp <- result[[7]]
    volSpecHeatSoil <- result[[8]]
    heatStorage <- result[[9]]
    thermalConductance <- result[[10]]
    timeOfDaySecs <- result[[11]]
    netRadiation <- result[[12]]
    airTemperature <- result[[13]]
    internalTimeStep <- result[[14]]
    minTempYesterday <- result[[15]]
    boundaryLayerConductance <- result[[16]]
    maxTempYesterday <- result[[17]]
    return (list ("heatStorage" = heatStorage,"instrumentHeight" = instrumentHeight,"canopyHeight" = canopyHeight,"minSoilTemp" = minSoilTemp,"maxSoilTemp" = maxSoilTemp,"aveSoilTemp" = aveSoilTemp,"volSpecHeatSoil" = volSpecHeatSoil,"soilTemp" = soilTemp,"morningSoilTemp" = morningSoilTemp,"newTemperature" = newTemperature,"thermalConductivity" = thermalConductivity,"thermalConductance" = thermalConductance,"boundaryLayerConductance" = boundaryLayerConductance,"soilWater" = soilWater,"doInitialisationStuff" = doInitialisationStuff,"maxTempYesterday" = maxTempYesterday,"minTempYesterday" = minTempYesterday,"airTemperature" = airTemperature,"internalTimeStep" = internalTimeStep,"timeOfDaySecs" = timeOfDaySecs,"netRadiation" = netRadiation,"InitialValues" = InitialValues))
}

getIniVariables <- function (instrumentHeight,
         instrumHeight,
         defaultInstrumentHeight){
    if (instrumHeight > 0.00001)
    {
        instrumentHeight <- instrumHeight
    }
    else
    {
        instrumentHeight <- defaultInstrumentHeight
    }
    return( instrumentHeight)
}

getProfileVariables <- function (heatStorage,
         minSoilTemp,
         bulkDensity,
         numNodes,
         physical_BD,
         maxSoilTemp,
         waterBalance_SW,
         organic_Carbon,
         physical_Rocks,
         nodeDepth,
         topsoilNode,
         newTemperature,
         surfaceNode,
         soilWater,
         thermalConductance,
         thermalConductivity,
         sand,
         carbon,
         thickness,
         numPhantomNodes,
         physical_ParticleSizeSand,
         rocks,
         clay,
         physical_ParticleSizeSilt,
         airNode,
         physical_ParticleSizeClay,
         soilTemp,
         numLayers,
         physical_Thickness,
         silt,
         volSpecHeatSoil,
         aveSoilTemp,
         morningSoilTemp,
         DepthToConstantTemperature,
         MissingValue){
    layer <- 0
    node <- 0
    i <- 0
    belowProfileDepth <- 0.0
    thicknessForPhantomNodes <- 0.0
    firstPhantomNode <- 0
    oldDepth<- vector()
    oldBulkDensity<- vector()
    oldSoilWater<- vector()
    numLayers <- length(physical_Thickness)
    numNodes <- numLayers + numPhantomNodes
    thickness <-  rep(0.0,numLayers + numPhantomNodes + 1)
    thickness[(1 + 1):(1 + length(physical_Thickness))] <- physical_Thickness
    belowProfileDepth <- max(DepthToConstantTemperature - Sum(thickness, 1, numLayers, MissingValue), 1000.0)
    thicknessForPhantomNodes <- belowProfileDepth * 2.0 / numPhantomNodes
    firstPhantomNode <- numLayers
    for( i in seq(firstPhantomNode, firstPhantomNode + numPhantomNodes-1, 1)){
        thickness[i+1] <- thicknessForPhantomNodes
    }
    oldDepth <- nodeDepth
    nodeDepth <-  rep(0.0,numNodes + 1 + 1)
    if (!is.null(oldDepth))
    {
        nodeDepth[(0 + 1):min(numNodes + 1 + 1, length(oldDepth))] <- oldDepth[(0 + 1):min(numNodes + 1 + 1, length(oldDepth))]
    }
    nodeDepth[airNode+1] <- 0.0
    nodeDepth[surfaceNode+1] <- 0.0
    nodeDepth[topsoilNode+1] <- 0.5 * thickness[2] / 1000.0
    for( node in seq(topsoilNode, numNodes + 1-1, 1)){
        nodeDepth[node + 1+1] <- (Sum(thickness, 1, node - 1, MissingValue) + (0.5 * thickness[node+1])) / 1000.0
    }
    oldBulkDensity <- bulkDensity
    bulkDensity <-  rep(0.0,numLayers + 1 + numPhantomNodes)
    if (!is.null(oldBulkDensity))
    {
        bulkDensity[(0 + 1):min(numLayers + 1 + numPhantomNodes, length(oldBulkDensity))] <- oldBulkDensity[(0 + 1):min(numLayers + 1 + numPhantomNodes, length(oldBulkDensity))]
    }
    bulkDensity[(1 + 1):(1 + length(physical_BD))] <- physical_BD
    bulkDensity[numNodes+1] <- bulkDensity[numLayers+1]
    for( layer in seq(numLayers + 1, numLayers + numPhantomNodes + 1-1, 1)){
        bulkDensity[layer+1] <- bulkDensity[numLayers+1]
    }
    oldSoilWater <- soilWater
    soilWater <-  rep(0.0,numLayers + 1 + numPhantomNodes)
    if (!is.null(oldSoilWater))
    {
        soilWater[(0 + 1):min(numLayers + 1 + numPhantomNodes, length(oldSoilWater))] <- oldSoilWater[(0 + 1):min(numLayers + 1 + numPhantomNodes, length(oldSoilWater))]
    }
    if (!is.null(waterBalance_SW))
    {
        for( layer in seq(1, numLayers + 1-1, 1)){
            soilWater[layer+1] <- Divide(waterBalance_SW[(layer - 1)+1] * thickness[(layer - 1)+1], thickness[layer+1], as.double(0))
        }
        for( layer in seq(numLayers + 1, numLayers + numPhantomNodes + 1-1, 1)){
            soilWater[layer+1] <- soilWater[numLayers+1]
        }
    }
    carbon <-  rep(0.0,numLayers + 1 + numPhantomNodes)
    for( layer in seq(1, numLayers + 1-1, 1)){
        carbon[layer+1] <- organic_Carbon[layer - 1+1]
    }
    for( layer in seq(numLayers + 1, numLayers + numPhantomNodes + 1-1, 1)){
        carbon[layer+1] <- carbon[numLayers+1]
    }
    rocks <-  rep(0.0,numLayers + 1 + numPhantomNodes)
    for( layer in seq(1, numLayers + 1-1, 1)){
        rocks[layer+1] <- physical_Rocks[layer - 1+1]
    }
    for( layer in seq(numLayers + 1, numLayers + numPhantomNodes + 1-1, 1)){
        rocks[layer+1] <- rocks[numLayers+1]
    }
    sand <-  rep(0.0,numLayers + 1 + numPhantomNodes)
    for( layer in seq(1, numLayers + 1-1, 1)){
        sand[layer+1] <- physical_ParticleSizeSand[layer - 1+1]
    }
    for( layer in seq(numLayers + 1, numLayers + numPhantomNodes + 1-1, 1)){
        sand[layer+1] <- sand[numLayers+1]
    }
    silt <-  rep(0.0,numLayers + 1 + numPhantomNodes)
    for( layer in seq(1, numLayers + 1-1, 1)){
        silt[layer+1] <- physical_ParticleSizeSilt[layer - 1+1]
    }
    for( layer in seq(numLayers + 1, numLayers + numPhantomNodes + 1-1, 1)){
        silt[layer+1] <- silt[numLayers+1]
    }
    clay <-  rep(0.0,numLayers + 1 + numPhantomNodes)
    for( layer in seq(1, numLayers + 1-1, 1)){
        clay[layer+1] <- physical_ParticleSizeClay[layer - 1+1]
    }
    for( layer in seq(numLayers + 1, numLayers + numPhantomNodes + 1-1, 1)){
        clay[layer+1] <- clay[numLayers+1]
    }
    maxSoilTemp <-  rep(0.0,numLayers + 1 + numPhantomNodes)
    minSoilTemp <-  rep(0.0,numLayers + 1 + numPhantomNodes)
    aveSoilTemp <-  rep(0.0,numLayers + 1 + numPhantomNodes)
    volSpecHeatSoil <-  rep(0.0,numNodes + 1)
    soilTemp <-  rep(0.0,numNodes + 1 + 1)
    morningSoilTemp <-  rep(0.0,numNodes + 1 + 1)
    newTemperature <-  rep(0.0,numNodes + 1 + 1)
    thermalConductivity <-  rep(0.0,numNodes + 1)
    heatStorage <-  rep(0.0,numNodes + 1)
    thermalConductance <-  rep(0.0,numNodes + 1 + 1)
    return (list ("heatStorage" = heatStorage,"minSoilTemp" = minSoilTemp,"bulkDensity" = bulkDensity,"maxSoilTemp" = maxSoilTemp,"nodeDepth" = nodeDepth,"newTemperature" = newTemperature,"soilWater" = soilWater,"thermalConductance" = thermalConductance,"thermalConductivity" = thermalConductivity,"sand" = sand,"carbon" = carbon,"thickness" = thickness,"rocks" = rocks,"clay" = clay,"soilTemp" = soilTemp,"silt" = silt,"volSpecHeatSoil" = volSpecHeatSoil,"aveSoilTemp" = aveSoilTemp,"morningSoilTemp" = morningSoilTemp,"numNodes" = numNodes,"numLayers" = numLayers))
}

doThermalConductivityCoeffs <- function (thermCondPar2,
         numLayers,
         bulkDensity,
         numNodes,
         thermCondPar3,
         thermCondPar4,
         clay,
         thermCondPar1){
    layer <- 0
    oldGC1<- vector()
    oldGC2<- vector()
    oldGC3<- vector()
    oldGC4<- vector()
    element <- 0
    oldGC1 <- thermCondPar1
    thermCondPar1 <-  rep(0.0,numNodes + 1)
    if (!is.null(oldGC1))
    {
        thermCondPar1[(0 + 1):min(numNodes + 1, length(oldGC1))] <- oldGC1[(0 + 1):min(numNodes + 1, length(oldGC1))]
    }
    oldGC2 <- thermCondPar2
    thermCondPar2 <-  rep(0.0,numNodes + 1)
    if (!is.null(oldGC2))
    {
        thermCondPar2[(0 + 1):min(numNodes + 1, length(oldGC2))] <- oldGC2[(0 + 1):min(numNodes + 1, length(oldGC2))]
    }
    oldGC3 <- thermCondPar3
    thermCondPar3 <-  rep(0.0,numNodes + 1)
    if (!is.null(oldGC3))
    {
        thermCondPar3[(0 + 1):min(numNodes + 1, length(oldGC3))] <- oldGC3[(0 + 1):min(numNodes + 1, length(oldGC3))]
    }
    oldGC4 <- thermCondPar4
    thermCondPar4 <-  rep(0.0,numNodes + 1)
    if (!is.null(oldGC4))
    {
        thermCondPar4[(0 + 1):min(numNodes + 1, length(oldGC4))] <- oldGC4[(0 + 1):min(numNodes + 1, length(oldGC4))]
    }
    for( layer in seq(1, numLayers + 1 + 1-1, 1)){
        element <- layer
        thermCondPar1[element+1] <- 0.65 - (0.78 * bulkDensity[layer+1]) + (0.6 * bulkDensity[layer+1] ^ 2)
        thermCondPar2[element+1] <- 1.06 * bulkDensity[layer+1]
        thermCondPar3[element+1] <- 1.0 + Divide(2.6, sqrt(clay[layer+1]), as.double(0))
        thermCondPar4[element+1] <- 0.03 + (0.1 * bulkDensity[layer+1] ^ 2)
    }
    return (list ("thermCondPar2" = thermCondPar2,"thermCondPar3" = thermCondPar3,"thermCondPar4" = thermCondPar4,"thermCondPar1" = thermCondPar1))
}

readParam <- function (bareSoilRoughness,
         newTemperature,
         soilRoughnessHeight,
         soilTemp,
         thermCondPar2,
         numLayers,
         bulkDensity,
         numNodes,
         thermCondPar3,
         thermCondPar4,
         clay,
         thermCondPar1,
         weather_Tav,
         clock_Today_DayOfYear,
         surfaceNode,
         weather_Amp,
         thickness,
         weather_Latitude){
    result <-  doThermalConductivityCoeffs(thermCondPar2, numLayers, bulkDensity, numNodes, thermCondPar3, thermCondPar4, clay, thermCondPar1)
    thermCondPar2 <- result[[1]]
    thermCondPar3 <- result[[2]]
    thermCondPar4 <- result[[3]]
    thermCondPar1 <- result[[4]]
    soilTemp <- calcSoilTemperature(soilTemp, weather_Tav, clock_Today_DayOfYear, surfaceNode, numNodes, weather_Amp, thickness, weather_Latitude)
    newTemperature[(0 + 1):(0 + length(soilTemp))] <- soilTemp
    soilRoughnessHeight <- bareSoilRoughness
    return (list ("newTemperature" = newTemperature,"soilTemp" = soilTemp,"thermCondPar2" = thermCondPar2,"thermCondPar3" = thermCondPar3,"thermCondPar4" = thermCondPar4,"thermCondPar1" = thermCondPar1,"soilRoughnessHeight" = soilRoughnessHeight))
}

getOtherVariables <- function (numLayers,
         numNodes,
         soilWater,
         instrumentHeight,
         soilRoughnessHeight,
         waterBalance_SW,
         microClimate_CanopyHeight,
         canopyHeight){
    soilWater[(1 + 1):(1 + length(waterBalance_SW))] <- waterBalance_SW
    soilWater[numNodes+1] <- soilWater[numLayers+1]
    canopyHeight <- max(microClimate_CanopyHeight, soilRoughnessHeight) / 1000.0
    instrumentHeight <- max(instrumentHeight, canopyHeight + 0.5)
    return (list ("soilWater" = soilWater,"instrumentHeight" = instrumentHeight,"canopyHeight" = canopyHeight))
}

volumetricFractionOrganicMatter <- function (layer,
         carbon,
         bulkDensity,
         pom){
    return( carbon[layer+1] / 100.0 * 2.5 * bulkDensity[layer+1] / pom)
}

volumetricFractionRocks <- function (layer,
         rocks){
    return( rocks[layer+1] / 100.0)
}

volumetricFractionIce <- function (layer){
    return( 0.0)
}

volumetricFractionWater <- function (layer,
         soilWater,
         carbon,
         bulkDensity,
         pom){
    return( (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom)) * soilWater[layer+1])
}

volumetricFractionClay <- function (layer,
         bulkDensity,
         ps,
         clay,
         carbon,
         pom,
         rocks){
    return( (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * clay[layer+1] / 100.0 * bulkDensity[layer+1] / ps)
}

volumetricFractionSilt <- function (layer,
         bulkDensity,
         silt,
         ps,
         carbon,
         pom,
         rocks){
    return( (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * silt[layer+1] / 100.0 * bulkDensity[layer+1] / ps)
}

volumetricFractionSand <- function (layer,
         bulkDensity,
         sand,
         ps,
         carbon,
         pom,
         rocks){
    return( (1 - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionRocks(layer, rocks)) * sand[layer+1] / 100.0 * bulkDensity[layer+1] / ps)
}

kelvinT <- function (celciusT){
    celciusToKelvin <- 0.0
    celciusToKelvin <- 273.18
    return( celciusT + celciusToKelvin)
}

Divide <- function (value1,
         value2,
         errVal){
    if (value2 != as.double(0))
    {
        return( value1 / value2)
    }
    return( errVal)
}

Sum <- function (values,
         startIndex,
         endIndex,
         MissingValue){
    value <- 0.0
    result <- 0.0
    index <- 0
    result <- 0.0
    index <- -1
    for( value in values)
    {
        index <- index + 1
        if (index >= startIndex && value != MissingValue)
        {
            result <- result + value
        }
        if (index == endIndex)
        {
            break
        }}
    return( result)
}

volumetricSpecificHeat <- function (name,
         layer){
    specificHeatRocks <- 0.0
    specificHeatOM <- 0.0
    specificHeatSand <- 0.0
    specificHeatSilt <- 0.0
    specificHeatClay <- 0.0
    specificHeatWater <- 0.0
    specificHeatIce <- 0.0
    specificHeatAir <- 0.0
    result <- 0.0
    specificHeatRocks <- 7.7
    specificHeatOM <- 0.25
    specificHeatSand <- 7.7
    specificHeatSilt <- 2.74
    specificHeatClay <- 2.92
    specificHeatWater <- 0.57
    specificHeatIce <- 2.18
    specificHeatAir <- 0.025
    result <- 0.0
    if (name == 'Rocks')
    {
        result <- specificHeatRocks
    }
    else if ( name == 'OrganicMatter')
    {
        result <- specificHeatOM
    }
    else if ( name == 'Sand')
    {
        result <- specificHeatSand
    }
    else if ( name == 'Silt')
    {
        result <- specificHeatSilt
    }
    else if ( name == 'Clay')
    {
        result <- specificHeatClay
    }
    else if ( name == 'Water')
    {
        result <- specificHeatWater
    }
    else if ( name == 'Ice')
    {
        result <- specificHeatIce
    }
    else if ( name == 'Air')
    {
        result <- specificHeatAir
    }
    return( result)
}

volumetricFractionAir <- function (layer,
         rocks,
         carbon,
         bulkDensity,
         pom,
         sand,
         ps,
         silt,
         clay,
         soilWater){
    return( 1.0 - volumetricFractionRocks(layer, rocks) - volumetricFractionOrganicMatter(layer, carbon, bulkDensity, pom) - volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks) - volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks) - volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks) - volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) - volumetricFractionIce(layer))
}

airDensity <- function (temperature,
         AirPressure){
    MWair <- 0.0
    RGAS <- 0.0
    HPA2PA <- 0.0
    MWair <- 0.02897
    RGAS <- 8.3143
    HPA2PA <- 100.0
    return( Divide(MWair * AirPressure * HPA2PA, kelvinT(temperature) * RGAS, 0.0))
}

longWaveRadn <- function (emissivity,
         tDegC,
         stefanBoltzmannConstant){
    return( stefanBoltzmannConstant * emissivity * kelvinT(tDegC) ^ 4)
}

mapLayer2Node <- function (layerArray,
         nodeArray,
         nodeDepth,
         numNodes,
         thickness,
         surfaceNode,
         MissingValue){
    node <- 0
    layer <- 0
    depthLayerAbove <- 0.0
    d1 <- 0.0
    d2 <- 0.0
    dSum <- 0.0
    for( node in seq(surfaceNode, numNodes + 1-1, 1)){
        layer <- node - 1
        depthLayerAbove <-  if (layer >= 1)Sum(thickness, 1, layer, MissingValue) else 0.0
        d1 <- depthLayerAbove - (nodeDepth[node+1] * 1000.0)
        d2 <- nodeDepth[(node + 1)+1] * 1000.0 - depthLayerAbove
        dSum <- d1 + d2
        nodeArray[node+1] <- Divide(layerArray[layer+1] * d1, dSum, as.double(0)) + Divide(layerArray[(layer + 1)+1] * d2, dSum, as.double(0))
    }
    return( nodeArray)
}

ThermalConductance <- function (name,
         layer,
         rocks,
         bulkDensity,
         sand,
         ps,
         carbon,
         pom,
         silt,
         clay){
    thermalConductanceRocks <- 0.0
    thermalConductanceOM <- 0.0
    thermalConductanceSand <- 0.0
    thermalConductanceSilt <- 0.0
    thermalConductanceClay <- 0.0
    thermalConductanceWater <- 0.0
    thermalConductanceIce <- 0.0
    thermalConductanceAir <- 0.0
    result <- 0.0
    thermalConductanceRocks <- 0.182
    thermalConductanceOM <- 2.50
    thermalConductanceSand <- 0.182
    thermalConductanceSilt <- 2.39
    thermalConductanceClay <- 1.39
    thermalConductanceWater <- 4.18
    thermalConductanceIce <- 1.73
    thermalConductanceAir <- 0.0012
    result <- 0.0
    if (name == 'Rocks')
    {
        result <- thermalConductanceRocks
    }
    else if ( name == 'OrganicMatter')
    {
        result <- thermalConductanceOM
    }
    else if ( name == 'Sand')
    {
        result <- thermalConductanceSand
    }
    else if ( name == 'Silt')
    {
        result <- thermalConductanceSilt
    }
    else if ( name == 'Clay')
    {
        result <- thermalConductanceClay
    }
    else if ( name == 'Water')
    {
        result <- thermalConductanceWater
    }
    else if ( name == 'Ice')
    {
        result <- thermalConductanceIce
    }
    else if ( name == 'Air')
    {
        result <- thermalConductanceAir
    }
    else if ( name == 'Minerals')
    {
        result <- thermalConductanceRocks ^ volumetricFractionRocks(layer, rocks) * thermalConductanceSand ^ volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks) + thermalConductanceSilt ^ volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks) + thermalConductanceClay ^ volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks)
    }
    result <- volumetricSpecificHeat(name, layer)
    return( result)
}

shapeFactor <- function (name,
         layer,
         soilWater,
         carbon,
         bulkDensity,
         pom,
         rocks,
         sand,
         ps,
         silt,
         clay){
    shapeFactorRocks <- 0.0
    shapeFactorOM <- 0.0
    shapeFactorSand <- 0.0
    shapeFactorSilt <- 0.0
    shapeFactorClay <- 0.0
    shapeFactorWater <- 0.0
    result <- 0.0
    shapeFactorRocks <- 0.182
    shapeFactorOM <- 0.5
    shapeFactorSand <- 0.182
    shapeFactorSilt <- 0.125
    shapeFactorClay <- 0.007755
    shapeFactorWater <- 1.0
    result <- 0.0
    if (name == 'Rocks')
    {
        result <- shapeFactorRocks
    }
    else if ( name == 'OrganicMatter')
    {
        result <- shapeFactorOM
    }
    else if ( name == 'Sand')
    {
        result <- shapeFactorSand
    }
    else if ( name == 'Silt')
    {
        result <- shapeFactorSilt
    }
    else if ( name == 'Clay')
    {
        result <- shapeFactorClay
    }
    else if ( name == 'Water')
    {
        result <- shapeFactorWater
    }
    else if ( name == 'Ice')
    {
        result <- 0.333 - (0.333 * volumetricFractionIce(layer) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)))
        return( result)
    }
    else if ( name == 'Air')
    {
        result <- 0.333 - (0.333 * volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater) / (volumetricFractionWater(layer, soilWater, carbon, bulkDensity, pom) + volumetricFractionIce(layer) + volumetricFractionAir(layer, rocks, carbon, bulkDensity, pom, sand, ps, silt, clay, soilWater)))
        return( result)
    }
    else if ( name == 'Minerals')
    {
        result <- shapeFactorRocks * volumetricFractionRocks(layer, rocks) + (shapeFactorSand * volumetricFractionSand(layer, bulkDensity, sand, ps, carbon, pom, rocks)) + (shapeFactorSilt * volumetricFractionSilt(layer, bulkDensity, silt, ps, carbon, pom, rocks)) + (shapeFactorClay * volumetricFractionClay(layer, bulkDensity, ps, clay, carbon, pom, rocks))
    }
    result <- volumetricSpecificHeat(name, layer)
    return( result)
}

doUpdate <- function (numInterationsPerDay,
         timeOfDaySecs,
         boundaryLayerConductance,
         minSoilTemp,
         airNode,
         soilTemp,
         newTemperature,
         numNodes,
         surfaceNode,
         internalTimeStep,
         maxSoilTemp,
         aveSoilTemp,
         thermalConductivity){
    node <- 0
    soilTemp[(0 + 1):(0 + length(newTemperature))] <- newTemperature
    if (timeOfDaySecs < (internalTimeStep * 1.2))
    {
        for( node in seq(surfaceNode, numNodes + 1-1, 1)){
            minSoilTemp[node+1] <- soilTemp[node+1]
            maxSoilTemp[node+1] <- soilTemp[node+1]
        }
    }
    for( node in seq(surfaceNode, numNodes + 1-1, 1)){
        if (soilTemp[node+1] < minSoilTemp[node+1])
        {
            minSoilTemp[node+1] <- soilTemp[node+1]
        }
        else if ( soilTemp[node+1] > maxSoilTemp[node+1])
        {
            maxSoilTemp[node+1] <- soilTemp[node+1]
        }
        aveSoilTemp[node+1] <- aveSoilTemp[node+1] + Divide(soilTemp[node+1], as.double(numInterationsPerDay), as.double(0))
    }
    boundaryLayerConductance <- boundaryLayerConductance + Divide(thermalConductivity[airNode+1], as.double(numInterationsPerDay), as.double(0))
    return (list ("minSoilTemp" = minSoilTemp,"soilTemp" = soilTemp,"maxSoilTemp" = maxSoilTemp,"aveSoilTemp" = aveSoilTemp,"boundaryLayerConductance" = boundaryLayerConductance))
}

doThomas <- function (newTemps,
         netRadiation,
         heatStorage,
         waterBalance_Eos,
         numNodes,
         timestep,
         netRadiationSource,
         latentHeatOfVapourisation,
         nodeDepth,
         waterBalance_Es,
         airNode,
         soilTemp,
         surfaceNode,
         internalTimeStep,
         thermalConductance,
         thermalConductivity,
         nu,
         volSpecHeatSoil){
    node <- 0
    a <- vector(,numNodes + 1 + 1)
    b <- vector(,numNodes + 1)
    c <- vector(,numNodes + 1)
    d <- vector(,numNodes + 1)
    volumeOfSoilAtNode <- 0.0
    elementLength <- 0.0
    g <- 0.0
    sensibleHeatFlux <- 0.0
    radnNet <- 0.0
    latentHeatFlux <- 0.0
    soilSurfaceHeatFlux <- 0.0
    thermalConductance[airNode+1] <- thermalConductivity[airNode+1]
    for( node in seq(surfaceNode, numNodes + 1-1, 1)){
        volumeOfSoilAtNode <- 0.5 * (nodeDepth[node + 1+1] - nodeDepth[node - 1+1])
        heatStorage[node+1] <- Divide(volSpecHeatSoil[node+1] * volumeOfSoilAtNode, internalTimeStep, as.double(0))
        elementLength <- nodeDepth[node + 1+1] - nodeDepth[node+1]
        thermalConductance[node+1] <- Divide(thermalConductivity[node+1], elementLength, as.double(0))
    }
    g <- 1 - nu
    for( node in seq(surfaceNode, numNodes + 1-1, 1)){
        c[node+1] <- -nu * thermalConductance[node+1]
        a[node + 1+1] <- c[node+1]
        b[node+1] <- nu * (thermalConductance[node+1] + thermalConductance[node - 1+1]) + heatStorage[node+1]
        d[node+1] <- g * thermalConductance[(node - 1)+1] * soilTemp[(node - 1)+1] + ((heatStorage[node+1] - (g * (thermalConductance[node+1] + thermalConductance[node - 1+1]))) * soilTemp[node+1]) + (g * thermalConductance[node+1] * soilTemp[(node + 1)+1])
    }
    a[surfaceNode+1] <- 0.0
    sensibleHeatFlux <- nu * thermalConductance[airNode+1] * newTemps[airNode+1]
    radnNet <- 0.0
    if (netRadiationSource == 'calc')
    {
        radnNet <- Divide(netRadiation * 1000000.0, internalTimeStep, as.double(0))
    }
    else if ( netRadiationSource == 'eos')
    {
        radnNet <- Divide(waterBalance_Eos * latentHeatOfVapourisation, timestep, as.double(0))
    }
    latentHeatFlux <- Divide(waterBalance_Es * latentHeatOfVapourisation, timestep, as.double(0))
    soilSurfaceHeatFlux <- sensibleHeatFlux + radnNet - latentHeatFlux
    d[surfaceNode+1] <- d[surfaceNode+1] + soilSurfaceHeatFlux
    d[numNodes+1] <- d[numNodes+1] + (nu * thermalConductance[numNodes+1] * newTemps[(numNodes + 1)+1])
    for( node in seq(surfaceNode, numNodes - 1 + 1-1, 1)){
        c[node+1] <- Divide(c[node+1], b[node+1], as.double(0))
        d[node+1] <- Divide(d[node+1], b[node+1], as.double(0))
        b[node + 1+1] <- b[node + 1+1] - (a[(node + 1)+1] * c[node+1])
        d[node + 1+1] <- d[node + 1+1] - (a[(node + 1)+1] * d[node+1])
    }
    newTemps[numNodes+1] <- Divide(d[numNodes+1], b[numNodes+1], as.double(0))
    for( node in seq(numNodes - 1, surfaceNode - 1+1, -1)){
        newTemps[node+1] <- d[node+1] - (c[node+1] * newTemps[(node + 1)+1])
    }
    return (list ("newTemps" = newTemps,"heatStorage" = heatStorage,"thermalConductance" = thermalConductance))
}

getBoundaryLayerConductance <- function (TNew_zb,
         weather_AirPressure,
         stefanBoltzmannConstant,
         waterBalance_Eos,
         weather_Wind,
         airTemperature,
         surfaceNode,
         waterBalance_Eo,
         instrumentHeight,
         canopyHeight){
    iteration <- 0
    vonKarmanConstant <- 0.0
    gravitationalConstant <- 0.0
    specificHeatOfAir <- 0.0
    surfaceEmissivity <- 0.0
    SpecificHeatAir <- 0.0
    roughnessFactorMomentum <- 0.0
    roughnessFactorHeat <- 0.0
    d <- 0.0
    surfaceTemperature <- 0.0
    diffusePenetrationConstant <- 0.0
    radiativeConductance <- 0.0
    frictionVelocity <- 0.0
    boundaryLayerCond <- 0.0
    stabilityParammeter <- 0.0
    stabilityCorrectionMomentum <- 0.0
    stabilityCorrectionHeat <- 0.0
    heatFluxDensity <- 0.0
    vonKarmanConstant <- 0.41
    gravitationalConstant <- 9.8
    specificHeatOfAir <- 1010.0
    surfaceEmissivity <- 0.98
    SpecificHeatAir <- specificHeatOfAir * airDensity(airTemperature, weather_AirPressure)
    roughnessFactorMomentum <- 0.13 * canopyHeight
    roughnessFactorHeat <- 0.2 * roughnessFactorMomentum
    d <- 0.77 * canopyHeight
    surfaceTemperature <- TNew_zb[surfaceNode+1]
    diffusePenetrationConstant <- max(0.1, waterBalance_Eos) / max(0.1, waterBalance_Eo)
    radiativeConductance <- 4.0 * stefanBoltzmannConstant * surfaceEmissivity * diffusePenetrationConstant * kelvinT(airTemperature) ^ 3
    frictionVelocity <- 0.0
    boundaryLayerCond <- 0.0
    stabilityParammeter <- 0.0
    stabilityCorrectionMomentum <- 0.0
    stabilityCorrectionHeat <- 0.0
    heatFluxDensity <- 0.0
    for( iteration in seq(1, 3 + 1-1, 1)){
        frictionVelocity <- Divide(weather_Wind * vonKarmanConstant, log(Divide(instrumentHeight - d + roughnessFactorMomentum, roughnessFactorMomentum, as.double(0))) + stabilityCorrectionMomentum, as.double(0))
        boundaryLayerCond <- Divide(SpecificHeatAir * vonKarmanConstant * frictionVelocity, log(Divide(instrumentHeight - d + roughnessFactorHeat, roughnessFactorHeat, as.double(0))) + stabilityCorrectionHeat, as.double(0))
        boundaryLayerCond <- boundaryLayerCond + radiativeConductance
        heatFluxDensity <- boundaryLayerCond * (surfaceTemperature - airTemperature)
        stabilityParammeter <- Divide(-vonKarmanConstant * instrumentHeight * gravitationalConstant * heatFluxDensity, SpecificHeatAir * kelvinT(airTemperature) * frictionVelocity ^ 3.0, as.double(0))
        if (stabilityParammeter > 0.0)
        {
            stabilityCorrectionHeat <- 4.7 * stabilityParammeter
            stabilityCorrectionMomentum <- stabilityCorrectionHeat
        }
        else
        {
            stabilityCorrectionHeat <- -2.0 * log((1.0 + sqrt(1.0 - (16.0 * stabilityParammeter))) / 2.0)
            stabilityCorrectionMomentum <- 0.6 * stabilityCorrectionHeat
        }
    }
    return (list ("boundaryLayerCond" = boundaryLayerCond,"TNew_zb" = TNew_zb))
}

interpolateNetRadiation <- function (solarRadn,
         cloudFr,
         cva,
         waterBalance_Eo,
         waterBalance_Eos,
         waterBalance_Salb,
         soilTemp,
         airTemperature,
         surfaceNode,
         internalTimeStep,
         stefanBoltzmannConstant){
    surfaceEmissivity <- 0.0
    w2MJ <- 0.0
    emissivityAtmos <- 0.0
    PenetrationConstant <- 0.0
    lwRinSoil <- 0.0
    lwRoutSoil <- 0.0
    lwRnetSoil <- 0.0
    swRin <- 0.0
    swRout <- 0.0
    swRnetSoil <- 0.0
    surfaceEmissivity <- 0.96
    w2MJ <- internalTimeStep / 1000000.0
    emissivityAtmos <- (1 - (0.84 * cloudFr)) * 0.58 * cva ^ (1.0 / 7.0) + (0.84 * cloudFr)
    PenetrationConstant <- Divide(max(0.1, waterBalance_Eos), max(0.1, waterBalance_Eo), as.double(0))
    lwRinSoil <- longWaveRadn(emissivityAtmos, airTemperature, stefanBoltzmannConstant) * PenetrationConstant * w2MJ
    lwRoutSoil <- longWaveRadn(surfaceEmissivity, soilTemp[surfaceNode+1], stefanBoltzmannConstant) * PenetrationConstant * w2MJ
    lwRnetSoil <- lwRinSoil - lwRoutSoil
    swRin <- solarRadn
    swRout <- waterBalance_Salb * solarRadn
    swRnetSoil <- (swRin - swRout) * PenetrationConstant
    return( swRnetSoil + lwRnetSoil)
}

interpolateTemperature <- function (timeHours,
         minTempYesterday,
         maxTempYesterday,
         weather_MeanT,
         weather_MaxT,
         weather_MinT,
         defaultTimeOfMaximumTemperature){
    time <- 0.0
    maxT_time <- 0.0
    minT_time <- 0.0
    midnightT <- 0.0
    tScale <- 0.0
    currentTemperature <- 0.0
    time <- timeHours / 24.0
    maxT_time <- defaultTimeOfMaximumTemperature / 24.0
    minT_time <- maxT_time - 0.5
    if (time < minT_time)
    {
        midnightT <- sin((0.0 + 0.25 - maxT_time) * 2.0 * pi) * (maxTempYesterday - minTempYesterday) / 2.0 + ((maxTempYesterday + minTempYesterday) / 2.0)
        tScale <- (minT_time - time) / minT_time
        if (tScale > 1.0)
        {
            tScale <- 1.0
        }
        else if ( tScale < as.double(0))
        {
            tScale <- as.double(0)
        }
        currentTemperature <- weather_MinT + (tScale * (midnightT - weather_MinT))
        return( currentTemperature)
    }
    else
    {
        currentTemperature <- sin((time + 0.25 - maxT_time) * 2.0 * pi) * (weather_MaxT - weather_MinT) / 2.0 + weather_MeanT
        return( currentTemperature)
    }
}

doThermalConductivity <- function (soilConstituentNames,
         numNodes,
         soilWater,
         thermalConductivity,
         carbon,
         bulkDensity,
         pom,
         rocks,
         sand,
         ps,
         silt,
         clay,
         nodeDepth,
         thickness,
         surfaceNode,
         MissingValue){
    node <- 0
    constituentName <- ''
    thermCondLayers <- vector(,numNodes + 1)
    numerator <- 0.0
    denominator <- 0.0
    shapeFactorConstituent <- 0.0
    thermalConductanceConstituent <- 0.0
    thermalConductanceWater <- 0.0
    k <- 0.0
    for( node in seq(1, numNodes + 1-1, 1)){
        numerator <- 0.0
        denominator <- 0.0
        for( constituentName in soilConstituentNames)
        {
            shapeFactorConstituent <- shapeFactor(constituentName, node, soilWater, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay)
            thermalConductanceConstituent <- ThermalConductance(constituentName, node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay)
            thermalConductanceWater <- ThermalConductance('Water', node, rocks, bulkDensity, sand, ps, carbon, pom, silt, clay)
            k <- 2.0 / 3.0 * (1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0))) ^ (-1) + (1.0 / 3.0 * (1 + (shapeFactorConstituent * (thermalConductanceConstituent / thermalConductanceWater - 1.0) * (1 - (2 * shapeFactorConstituent)))) ^ (-1))
            numerator <- numerator + (thermalConductanceConstituent * soilWater[node+1] * k)
            denominator <- denominator + (soilWater[node+1] * k)}
        thermCondLayers[node+1] <- numerator / denominator
    }
    thermalConductivity <- mapLayer2Node(thermCondLayers, thermalConductivity, nodeDepth, numNodes, thickness, surfaceNode, MissingValue)
    return( thermalConductivity)
}

doVolumetricSpecificHeat <- function (soilConstituentNames,
         numNodes,
         volSpecHeatSoil,
         soilWater,
         nodeDepth,
         thickness,
         surfaceNode,
         MissingValue){
    node <- 0
    constituentName <- ''
    volspecHeatSoil_ <- vector(,numNodes + 1)
    for( node in seq(1, numNodes + 1-1, 1)){
        volspecHeatSoil_[node+1] <- as.double(0)
        for( constituentName in soilConstituentNames)
        {
            if (!(constituentName %in% c('Minerals')))
            {
                volspecHeatSoil_[node+1] <- volspecHeatSoil_[node+1] + (volumetricSpecificHeat(constituentName, node) * 1000000.0 * soilWater[node+1])
            }}
    }
    volSpecHeatSoil <- mapLayer2Node(volspecHeatSoil_, volSpecHeatSoil, nodeDepth, numNodes, thickness, surfaceNode, MissingValue)
    return( volSpecHeatSoil)
}

Zero <- function (arr){
    i <- 0
    if (!is.null(arr))
    {
        for( i in seq(0, length(arr)-1, 1)){
            arr[i+1] <- as.double(0)
        }
    }
    return( arr)
}

doNetRadiation <- function (solarRadn,
         cloudFr,
         cva,
         ITERATIONSperDAY,
         weather_MinT,
         clock_Today_DayOfYear,
         weather_Radn,
         weather_Latitude){
    timestepNumber <- 0
    TSTEPS2RAD <- 0.0
    solarConstant <- 0.0
    solarDeclination <- 0.0
    cD <- 0.0
    m1 <- vector(,ITERATIONSperDAY + 1)
    m1Tot <- 0.0
    psr <- 0.0
    fr <- 0.0
    TSTEPS2RAD <- Divide(2.0 * pi, as.double(ITERATIONSperDAY), as.double(0))
    solarConstant <- 1360.0
    solarDeclination <- 0.3985 * sin((4.869 + (clock_Today_DayOfYear * 2.0 * pi / 365.25) + (0.03345 * sin((6.224 + (clock_Today_DayOfYear * 2.0 * pi / 365.25))))))
    cD <- sqrt(1.0 - (solarDeclination * solarDeclination))
    m1Tot <- 0.0
    for( timestepNumber in seq(1, ITERATIONSperDAY + 1-1, 1)){
        m1[timestepNumber+1] <- (solarDeclination * sin(weather_Latitude * pi / 180.0) + (cD * cos(weather_Latitude * pi / 180.0) * cos(TSTEPS2RAD * (timestepNumber - (ITERATIONSperDAY / 2.0))))) * 24.0 / ITERATIONSperDAY
        if (m1[timestepNumber+1] > 0.0)
        {
            m1Tot <- m1Tot + m1[timestepNumber+1]
        }
        else
        {
            m1[timestepNumber+1] <- 0.0
        }
    }
    psr <- m1Tot * solarConstant * 3600.0 / 1000000.0
    fr <- Divide(max(weather_Radn, 0.1), psr, as.double(0))
    cloudFr <- 2.33 - (3.33 * fr)
    cloudFr <- min(max(cloudFr, 0.0), 1.0)
    for( timestepNumber in seq(1, ITERATIONSperDAY + 1-1, 1)){
        solarRadn[timestepNumber+1] <- max(weather_Radn, 0.1) * Divide(m1[timestepNumber+1], m1Tot, as.double(0))
    }
    cva <- exp((31.3716 - (6014.79 / kelvinT(weather_MinT)) - (0.00792495 * kelvinT(weather_MinT)))) / kelvinT(weather_MinT)
    return (list ("solarRadn" = solarRadn,"cloudFr" = cloudFr,"cva" = cva))
}

doProcess <- function (timeOfDaySecs,
         netRadiation,
         minSoilTemp,
         maxSoilTemp,
         numIterationsForBoundaryLayerConductance,
         timestep,
         boundaryLayerConductance,
         maxTempYesterday,
         airNode,
         soilTemp,
         airTemperature,
         newTemperature,
         weather_MaxT,
         internalTimeStep,
         boundarLayerConductanceSource,
         thermalConductivity,
         minTempYesterday,
         aveSoilTemp,
         morningSoilTemp,
         weather_MeanT,
         constantBoundaryLayerConductance,
         weather_MinT,
         clock_Today_DayOfYear,
         weather_Radn,
         weather_Latitude,
         soilConstituentNames,
         numNodes,
         volSpecHeatSoil,
         soilWater,
         nodeDepth,
         thickness,
         surfaceNode,
         MissingValue,
         carbon,
         bulkDensity,
         pom,
         rocks,
         sand,
         ps,
         silt,
         clay,
         defaultTimeOfMaximumTemperature,
         waterBalance_Eo,
         waterBalance_Eos,
         waterBalance_Salb,
         stefanBoltzmannConstant,
         weather_AirPressure,
         weather_Wind,
         instrumentHeight,
         canopyHeight,
         heatStorage,
         netRadiationSource,
         latentHeatOfVapourisation,
         waterBalance_Es,
         thermalConductance,
         nu){
    timeStepIteration <- 0
    iteration <- 0
    interactionsPerDay <- 0
    cva <- 0.0
    cloudFr <- 0.0
    solarRadn <- vector(,49)
    interactionsPerDay <- 48
    cva <- 0.0
    cloudFr <- 0.0
    result <-  doNetRadiation(solarRadn, cloudFr, cva, interactionsPerDay, weather_MinT, clock_Today_DayOfYear, weather_Radn, weather_Latitude)
    solarRadn <- result[[1]]
    cloudFr <- result[[2]]
    cva <- result[[3]]
    minSoilTemp <- Zero(minSoilTemp)
    maxSoilTemp <- Zero(maxSoilTemp)
    aveSoilTemp <- Zero(aveSoilTemp)
    boundaryLayerConductance <- 0.0
    internalTimeStep <- round(timestep / interactionsPerDay)
    volSpecHeatSoil <- doVolumetricSpecificHeat(soilConstituentNames, numNodes, volSpecHeatSoil, soilWater, nodeDepth, thickness, surfaceNode, MissingValue)
    thermalConductivity <- doThermalConductivity(soilConstituentNames, numNodes, soilWater, thermalConductivity, carbon, bulkDensity, pom, rocks, sand, ps, silt, clay, nodeDepth, thickness, surfaceNode, MissingValue)
    for( timeStepIteration in seq(1, interactionsPerDay + 1-1, 1)){
        timeOfDaySecs <- internalTimeStep * as.double(timeStepIteration)
        if (timestep < (24.0 * 60.0 * 60.0))
        {
            airTemperature <- weather_MeanT
        }
        else
        {
            airTemperature <- interpolateTemperature(timeOfDaySecs / 3600.0, minTempYesterday, maxTempYesterday, weather_MeanT, weather_MaxT, weather_MinT, defaultTimeOfMaximumTemperature)
        }
        newTemperature[airNode+1] <- airTemperature
        netRadiation <- interpolateNetRadiation(solarRadn[timeStepIteration+1], cloudFr, cva, waterBalance_Eo, waterBalance_Eos, waterBalance_Salb, soilTemp, airTemperature, surfaceNode, internalTimeStep, stefanBoltzmannConstant)
        if (boundarLayerConductanceSource == 'constant')
        {
            thermalConductivity[airNode+1] <- constantBoundaryLayerConductance
        }
        else if ( boundarLayerConductanceSource == 'calc')
        {
            result <-  getBoundaryLayerConductance(newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight)
            thermalConductivity[airNode+1] <- result[[1]]
            newTemperature <- result[[2]]
            for( iteration in seq(1, numIterationsForBoundaryLayerConductance + 1-1, 1)){
                result <-  doThomas(newTemperature, netRadiation, heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, thermalConductance, thermalConductivity, nu, volSpecHeatSoil)
                newTemperature <- result[[1]]
                heatStorage <- result[[2]]
                thermalConductance <- result[[3]]
                result <-  getBoundaryLayerConductance(newTemperature, weather_AirPressure, stefanBoltzmannConstant, waterBalance_Eos, weather_Wind, airTemperature, surfaceNode, waterBalance_Eo, instrumentHeight, canopyHeight)
                thermalConductivity[airNode+1] <- result[[1]]
                newTemperature <- result[[2]]
            }
        }
        result <-  doThomas(newTemperature, netRadiation, heatStorage, waterBalance_Eos, numNodes, timestep, netRadiationSource, latentHeatOfVapourisation, nodeDepth, waterBalance_Es, airNode, soilTemp, surfaceNode, internalTimeStep, thermalConductance, thermalConductivity, nu, volSpecHeatSoil)
        newTemperature <- result[[1]]
        heatStorage <- result[[2]]
        thermalConductance <- result[[3]]
        result <-  doUpdate(interactionsPerDay, timeOfDaySecs, boundaryLayerConductance, minSoilTemp, airNode, soilTemp, newTemperature, numNodes, surfaceNode, internalTimeStep, maxSoilTemp, aveSoilTemp, thermalConductivity)
        minSoilTemp <- result[[1]]
        soilTemp <- result[[2]]
        maxSoilTemp <- result[[3]]
        aveSoilTemp <- result[[4]]
        boundaryLayerConductance <- result[[5]]
        if (abs(timeOfDaySecs - (5.0 * 3600.0)) <= (min(timeOfDaySecs, 5.0 * 3600.0) * 0.0001))
        {
            morningSoilTemp[(0 + 1):(0 + length(soilTemp))] <- soilTemp
        }
    }
    minTempYesterday <- weather_MinT
    maxTempYesterday <- weather_MaxT
    return (list ("minSoilTemp" = minSoilTemp,"maxSoilTemp" = maxSoilTemp,"soilTemp" = soilTemp,"newTemperature" = newTemperature,"thermalConductivity" = thermalConductivity,"aveSoilTemp" = aveSoilTemp,"morningSoilTemp" = morningSoilTemp,"volSpecHeatSoil" = volSpecHeatSoil,"heatStorage" = heatStorage,"thermalConductance" = thermalConductance,"timeOfDaySecs" = timeOfDaySecs,"netRadiation" = netRadiation,"airTemperature" = airTemperature,"internalTimeStep" = internalTimeStep,"minTempYesterday" = minTempYesterday,"boundaryLayerConductance" = boundaryLayerConductance,"maxTempYesterday" = maxTempYesterday))
}

ToCumThickness <- function (Thickness){
    Layer <- 0
    CumThickness <- vector(,length(Thickness))
    if (length(Thickness) > 0)
    {
        CumThickness[1] <- Thickness[1]
        for( Layer in seq(1, length(Thickness)-1, 1)){
            CumThickness[Layer+1] <- Thickness[Layer+1] + CumThickness[Layer - 1+1]
        }
    }
    return( CumThickness)
}

calcSoilTemperature <- function (soilTempIO,
         weather_Tav,
         clock_Today_DayOfYear,
         surfaceNode,
         numNodes,
         weather_Amp,
         thickness,
         weather_Latitude){
    nodes <- 0
    cumulativeDepth<- vector()
    w <- 0.0
    dh <- 0.0
    zd <- 0.0
    offset <- 0.0
    soilTemp <- vector(,numNodes + 1 + 1)
    cumulativeDepth <- ToCumThickness(thickness)
    w <- 2 * pi / (365.25 * 24 * 3600)
    dh <- 0.6
    zd <- sqrt(2 * dh / w)
    offset <- 0.25
    if (weather_Latitude > 0.0)
    {
        offset <- -0.25
    }
    for( nodes in seq(1, numNodes + 1-1, 1)){
        soilTemp[nodes+1] <- weather_Tav + (weather_Amp * exp(-1 * cumulativeDepth[nodes+1] / zd) * sin(((clock_Today_DayOfYear / 365.0 + offset) * 2.0 * pi - (cumulativeDepth[nodes+1] / zd))))
    }
    soilTempIO[(surfaceNode + 1):(surfaceNode + numNodes)] <- soilTemp[(0 + 1):(0 + numNodes)]
    return( soilTempIO)
}

calcSurfaceTemperature <- function (weather_MeanT,
         weather_MaxT,
         waterBalance_Salb,
         weather_Radn){
    surfaceT <- 0.0
    surfaceT <- (1.0 - waterBalance_Salb) * (weather_MeanT + ((weather_MaxT - weather_MeanT) * sqrt(max(weather_Radn, 0.1) * 23.8846 / 800.0))) + (waterBalance_Salb * weather_MeanT)
    return( surfaceT)
}

ValuesInArray <- function (Values,
         MissingValue){
    Value <- 0.0
    if (!is.null(Values))
    {
        for( Value in Values)
        {
            if (Value != MissingValue && !is.nan(Value))
            {
                return( TRUE)
            }}
    }
    return( FALSE)
}