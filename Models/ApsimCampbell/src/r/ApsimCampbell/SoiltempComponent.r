library(gsubfn)

#' Soiltemp model
#'
#' This function compute the Soiltemp model
#' @param netRadiation (MJ) Net radiation per internal time-step state (0, -) 
#' @param aveSoilWater (oC) Average soil temperaturer state (, -) 
#' @param bulkDensity (g/cm3) Soil bulk density, includes phantom layer state (, -) 
#' @param waterBalance_Eo (mm) Potential soil evapotranspiration from soil surface exogenous (, -) 
#' @param thermCondPar1 () Parameter 1 for computing thermal conductivity of soil solids private (, -) 
#' @param topsoilNode () The index of the first node within the soil (top layer) constant (2, -) 
#' @param surfaceNode () The index of the node on the soil surface (depth = 0) constant (1, -) 
#' @param internalTimeStep (sec) Internal time-step state (0, -) 
#' @param thermalConductance (W/K) K, conductance of element between nodes state (, -) 
#' @param thickness (mm) Thickness of each soil, includes phantom layer state (, -) 
#' @param numPhantomNodes () The number of phantom nodes below the soil profile constant (5, -) 
#' @param soilConstituentNames (m) soilConstituentNames constant (["Rocks", "OrganicMatter", "Sand", "Silt", "Clay", "Water", "Ice", "Air"], -) 
#' @param doInitialisationStuff (mintes) Flag whether initialisation is needed state (false, -) 
#' @param maxTempYesterday (oC) Yesterday's maximum daily air temperature state (0, -) 
#' @param waterBalance_Salb (0-1) Fraction of incoming radiation reflected from bare soil exogenous (, -) 
#' @param physical_Thickness (mm) Soil layer thickness constant (, -) 
#' @param MissingValue (m) missing value constant (99999, -) 
#' @param timeOfDaySecs (sec) Time of day from midnight state (0, -) 
#' @param numNodes () Number of nodes over the soil profile state (0, -) 
#' @param timestep (minutes) Internal time-step (minutes) constant (24.0 * 60.0 * 60.0, -) 
#' @param organic_Carbon (%) Total organic carbon exogenous (, -) 
#' @param waterBalance_Es (mm) Actual (realised) soil water evaporation exogenous (, -) 
#' @param weather_Wind (m/s) Wind speed exogenous (, -) 
#' @param soilWater (mm3/mm3) Volumetric water content of each soil layer state (, -) 
#' @param soilRoughnessHeight (mm) Height of soil roughness private (0, -) 
#' @param physical_ParticleSizeSand (%) Particle size sand exogenous (, -) 
#' @param numIterationsForBoundaryLayerConductance () Number of iterations to calculate atmosphere boundary layer conductance constant (1, -None) 
#' @param clay (%) Volumetric fraction of clay in each soil layer state (, -) 
#' @param weather_AirPressure (hPa) Air pressure exogenous (, -) 
#' @param soilTemp (oC) Soil temperature over the soil profile at morning state (, -) 
#' @param clock_Today_DayOfYear (day number) Day of year exogenous (, -) 
#' @param silt (%) Volumetric fraction of silt in each soil layer state (, -) 
#' @param defaultTimeOfMaximumTemperature (minutes) Time of maximum temperature constant (14.0, -) 
#' @param pom (Mg/m3) Particle density of organic matter constant (, -) 
#' @param DepthToConstantTemperature (mm) Soil depth to constant temperature constant (10000, -) 
#' @param microClimate_CanopyHeight (mm) Canopy height exogenous (, -) 
#' @param constantBoundaryLayerConductance (K/W) Boundary layer conductance, if constant constant (20, -) 
#' @param waterBalance_Eos (mm) Potential soil evaporation from soil surface exogenous (, -) 
#' @param instrumentHeight (mm) Height of instruments above soil surface state (0, -) 
#' @param thermCondPar4 () Parameter 4 for computing thermal conductivity of soil solids private (, -) 
#' @param waterBalance_SW (mm/mm) Volumetric water content exogenous (, -) 
#' @param weather_Amp (oC) Annual average temperature amplitude exogenous (, -) 
#' @param nodeDepth (mm) Depths of nodes private (, -) 
#' @param nu (0-1) Forward/backward differencing coefficient constant (0.6, -) 
#' @param sand (%) Volumetric fraction of sand in each soil layer state (, -) 
#' @param pInitialValues (oC) Initial soil temperature constant (, -) 
#' @param weather_MinT (oC) Minimum temperature exogenous (, -) 
#' @param ps () ps constant (, -) 
#' @param netRadiationSource (m) Flag whether net radiation is calculated or gotten from input constant (calc, -) 
#' @param weather_Radn (MJ/m2/day) Solar radiation exogenous (, -) 
#' @param airNode () The index of the node in the atmosphere (aboveground) constant (0, -) 
#' @param numLayers () Number of layers in the soil profile state (0, -) 
#' @param volSpecHeatSoil (J/K/m3) Volumetric specific heat over the soil profile state (, -) 
#' @param instrumHeight (mm) Height of instruments above ground state (0, -) 
#' @param canopyHeight (mm) Height of canopy above ground state (0, -) 
#' @param heatStorage (J/K) CP, heat storage between nodes state (, -) 
#' @param minSoilTemp (oC) Minimum soil temperature state (, -) 
#' @param bareSoilRoughness (mm) Roughness element height of bare soil constant (57, -) 
#' @param thermCondPar2 () Parameter 2 for computing thermal conductivity of soil solids private (, -) 
#' @param defaultInstrumentHeight (m) Default instrument height constant (1.2, -) 
#' @param maxSoilTemp (oC) Maximum soil temperature state (, -) 
#' @param physical_BD (g/cc) Bulk density constant (, -) 
#' @param latentHeatOfVapourisation (miJ/kg) Latent heat of vapourisation for water constant (2465000, -) 
#' @param weather_Latitude (deg) Latitude constant (, -) 
#' @param physical_Rocks (%) Rocks exogenous (, -) 
#' @param stefanBoltzmannConstant (W/m2/K4) The Stefan-Boltzmann constant constant (0.0000000567, -) 
#' @param weather_Tav (oC) Annual average temperature exogenous (, -) 
#' @param newTemperature (oC) Soil temperature at the end of this iteration state (, -) 
#' @param airTemperature (oC) Air temperature state (0, -) 
#' @param weather_MaxT (oC) Maximum temperature exogenous (, -) 
#' @param boundarLayerConductanceSource () Flag whether boundary layer conductance is calculated or gotten from inpu constant (calc, -) 
#' @param thermalConductivity (W.m/K) Thermal conductivity state (, -) 
#' @param minTempYesterday (oC) Yesterday's minimum daily air temperature state (0, -) 
#' @param carbon (%) Volumetric fraction of carbon (CHECK, OM?) in each soil layer state (, -) 
#' @param weather_MeanT (oC) Mean temperature exogenous (, -) 
#' @param rocks (%) Volumetric fraction of rocks in each soil laye state (, -) 
#' @param InitialValues (oC) Initial soil temperature state (, -) 
#' @param thermCondPar3 () Parameter 3 for computing thermal conductivity of soil solids private (, -) 
#' @param physical_ParticleSizeSilt (%) Particle size silt exogenous (, -) 
#' @param boundaryLayerConductance () Average daily atmosphere boundary layer conductance state (0, -) 
#' @param physical_ParticleSizeClay (%) Particle size clay exogenous (, -) 
#' @param aveSoilTemp (oC) average soil temperature state (, -) 
#' @param morningSoilTemp (oC) Soil temperature over the soil profile at morning state (, -) 
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
model_soiltemp <- function (netRadiation,
         aveSoilWater,
         bulkDensity,
         waterBalance_Eo,
         thermCondPar1,
         topsoilNode,
         surfaceNode,
         internalTimeStep,
         thermalConductance,
         thickness,
         numPhantomNodes,
         soilConstituentNames,
         doInitialisationStuff,
         maxTempYesterday,
         waterBalance_Salb,
         physical_Thickness,
         MissingValue,
         timeOfDaySecs,
         numNodes,
         timestep,
         organic_Carbon,
         waterBalance_Es,
         weather_Wind,
         soilWater,
         soilRoughnessHeight,
         physical_ParticleSizeSand,
         numIterationsForBoundaryLayerConductance,
         clay,
         weather_AirPressure,
         soilTemp,
         clock_Today_DayOfYear,
         silt,
         defaultTimeOfMaximumTemperature,
         pom,
         DepthToConstantTemperature,
         microClimate_CanopyHeight,
         constantBoundaryLayerConductance,
         waterBalance_Eos,
         instrumentHeight,
         thermCondPar4,
         waterBalance_SW,
         weather_Amp,
         nodeDepth,
         nu,
         sand,
         pInitialValues,
         weather_MinT,
         ps,
         netRadiationSource,
         weather_Radn,
         airNode,
         numLayers,
         volSpecHeatSoil,
         instrumHeight,
         canopyHeight,
         heatStorage,
         minSoilTemp,
         bareSoilRoughness,
         thermCondPar2,
         defaultInstrumentHeight,
         maxSoilTemp,
         physical_BD,
         latentHeatOfVapourisation,
         weather_Latitude,
         physical_Rocks,
         stefanBoltzmannConstant,
         weather_Tav,
         newTemperature,
         airTemperature,
         weather_MaxT,
         boundarLayerConductanceSource,
         thermalConductivity,
         minTempYesterday,
         carbon,
         weather_MeanT,
         rocks,
         InitialValues,
         thermCondPar3,
         physical_ParticleSizeSilt,
         boundaryLayerConductance,
         physical_ParticleSizeClay,
         aveSoilTemp,
         morningSoilTemp){
    result <-  model_soiltemperature(weather_MinT, weather_MaxT, weather_MeanT, weather_Tav, weather_Amp, weather_AirPressure, weather_Wind, weather_Latitude, weather_Radn, clock_Today_DayOfYear, microClimate_CanopyHeight, physical_Thickness, physical_BD, ps, physical_Rocks, physical_ParticleSizeSand, physical_ParticleSizeSilt, physical_ParticleSizeClay, organic_Carbon, waterBalance_SW, waterBalance_Eos, waterBalance_Eo, waterBalance_Es, waterBalance_Salb, InitialValues, pInitialValues, DepthToConstantTemperature, timestep, latentHeatOfVapourisation, stefanBoltzmannConstant, airNode, surfaceNode, topsoilNode, numPhantomNodes, constantBoundaryLayerConductance, numIterationsForBoundaryLayerConductance, defaultTimeOfMaximumTemperature, defaultInstrumentHeight, bareSoilRoughness, doInitialisationStuff, internalTimeStep, timeOfDaySecs, numNodes, numLayers, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, volSpecHeatSoil, soilTemp, morningSoilTemp, heatStorage, thermalConductance, thermalConductivity, boundaryLayerConductance, newTemperature, airTemperature, maxTempYesterday, minTempYesterday, soilWater, minSoilTemp, maxSoilTemp, aveSoilTemp, aveSoilWater, thickness, bulkDensity, rocks, carbon, sand, pom, silt, clay, soilRoughnessHeight, instrumentHeight, netRadiation, canopyHeight, instrumHeight, nu, boundarLayerConductanceSource, netRadiationSource, MissingValue, soilConstituentNames)
    heatStorage <- result[[1]]
    instrumentHeight <- result[[2]]
    canopyHeight <- result[[3]]
    minSoilTemp <- result[[4]]
    maxSoilTemp <- result[[5]]
    aveSoilTemp <- result[[6]]
    volSpecHeatSoil <- result[[7]]
    soilTemp <- result[[8]]
    morningSoilTemp <- result[[9]]
    newTemperature <- result[[10]]
    thermalConductivity <- result[[11]]
    thermalConductance <- result[[12]]
    boundaryLayerConductance <- result[[13]]
    soilWater <- result[[14]]
    doInitialisationStuff <- result[[15]]
    maxTempYesterday <- result[[16]]
    minTempYesterday <- result[[17]]
    airTemperature <- result[[18]]
    internalTimeStep <- result[[19]]
    timeOfDaySecs <- result[[20]]
    netRadiation <- result[[21]]
    InitialValues <- result[[22]]
    return (list ("heatStorage" = heatStorage,"instrumentHeight" = instrumentHeight,"canopyHeight" = canopyHeight,"minSoilTemp" = minSoilTemp,"maxSoilTemp" = maxSoilTemp,"aveSoilTemp" = aveSoilTemp,"volSpecHeatSoil" = volSpecHeatSoil,"soilTemp" = soilTemp,"morningSoilTemp" = morningSoilTemp,"newTemperature" = newTemperature,"thermalConductivity" = thermalConductivity,"thermalConductance" = thermalConductance,"boundaryLayerConductance" = boundaryLayerConductance,"soilWater" = soilWater,"doInitialisationStuff" = doInitialisationStuff,"maxTempYesterday" = maxTempYesterday,"minTempYesterday" = minTempYesterday,"airTemperature" = airTemperature,"internalTimeStep" = internalTimeStep,"timeOfDaySecs" = timeOfDaySecs,"netRadiation" = netRadiation,"InitialValues" = InitialValues))
}

#' Initialization of the Soiltemp model
#' 
#' This function initialize the Soiltemp model
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
init_soiltemp <- function (weather_MinT,
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
    netRadiation <- 0.0
    aveSoilWater<- vector()
    bulkDensity<- vector()
    internalTimeStep <- 0.0
    thermalConductance<- vector()
    thickness<- vector()
    doInitialisationStuff <- FALSE
    maxTempYesterday <- 0.0
    timeOfDaySecs <- 0.0
    numNodes <- 0
    soilWater<- vector()
    clay<- vector()
    soilTemp<- vector()
    silt<- vector()
    instrumentHeight <- 0.0
    sand<- vector()
    numLayers <- 0
    volSpecHeatSoil<- vector()
    instrumHeight <- 0.0
    canopyHeight <- 0.0
    heatStorage<- vector()
    minSoilTemp<- vector()
    maxSoilTemp<- vector()
    newTemperature<- vector()
    airTemperature <- 0.0
    thermalConductivity<- vector()
    minTempYesterday <- 0.0
    carbon<- vector()
    rocks<- vector()
    InitialValues<- vector()
    boundaryLayerConductance <- 0.0
    aveSoilTemp<- vector()
    morningSoilTemp<- vector()
    result <-  init_soiltemperature(weather_MinT, weather_MaxT, weather_MeanT, weather_Tav, weather_Amp, weather_AirPressure, weather_Wind, weather_Latitude, weather_Radn, clock_Today_DayOfYear, microClimate_CanopyHeight, physical_Thickness, physical_BD, ps, physical_Rocks, physical_ParticleSizeSand, physical_ParticleSizeSilt, physical_ParticleSizeClay, organic_Carbon, waterBalance_SW, waterBalance_Eos, waterBalance_Eo, waterBalance_Es, waterBalance_Salb, pInitialValues, DepthToConstantTemperature, timestep, latentHeatOfVapourisation, stefanBoltzmannConstant, airNode, surfaceNode, topsoilNode, numPhantomNodes, constantBoundaryLayerConductance, numIterationsForBoundaryLayerConductance, defaultTimeOfMaximumTemperature, defaultInstrumentHeight, bareSoilRoughness, nodeDepth, thermCondPar1, thermCondPar2, thermCondPar3, thermCondPar4, pom, soilRoughnessHeight, nu, boundarLayerConductanceSource, netRadiationSource, MissingValue, soilConstituentNames)
    InitialValues <- result[[1]]
    doInitialisationStuff <- result[[2]]
    internalTimeStep <- result[[3]]
    timeOfDaySecs <- result[[4]]
    numNodes <- result[[5]]
    numLayers <- result[[6]]
    nodeDepth <- result[[7]]
    thermCondPar1 <- result[[8]]
    thermCondPar2 <- result[[9]]
    thermCondPar3 <- result[[10]]
    thermCondPar4 <- result[[11]]
    volSpecHeatSoil <- result[[12]]
    soilTemp <- result[[13]]
    morningSoilTemp <- result[[14]]
    heatStorage <- result[[15]]
    thermalConductance <- result[[16]]
    thermalConductivity <- result[[17]]
    boundaryLayerConductance <- result[[18]]
    newTemperature <- result[[19]]
    airTemperature <- result[[20]]
    maxTempYesterday <- result[[21]]
    minTempYesterday <- result[[22]]
    soilWater <- result[[23]]
    minSoilTemp <- result[[24]]
    maxSoilTemp <- result[[25]]
    aveSoilTemp <- result[[26]]
    aveSoilWater <- result[[27]]
    thickness <- result[[28]]
    bulkDensity <- result[[29]]
    rocks <- result[[30]]
    carbon <- result[[31]]
    sand <- result[[32]]
    silt <- result[[33]]
    clay <- result[[34]]
    soilRoughnessHeight <- result[[35]]
    instrumentHeight <- result[[36]]
    netRadiation <- result[[37]]
    canopyHeight <- result[[38]]
    instrumHeight <- result[[39]]
    return (list ("InitialValues" = InitialValues,"doInitialisationStuff" = doInitialisationStuff,"internalTimeStep" = internalTimeStep,"timeOfDaySecs" = timeOfDaySecs,"numNodes" = numNodes,"numLayers" = numLayers,"nodeDepth" = nodeDepth,"thermCondPar1" = thermCondPar1,"thermCondPar2" = thermCondPar2,"thermCondPar3" = thermCondPar3,"thermCondPar4" = thermCondPar4,"volSpecHeatSoil" = volSpecHeatSoil,"soilTemp" = soilTemp,"morningSoilTemp" = morningSoilTemp,"heatStorage" = heatStorage,"thermalConductance" = thermalConductance,"thermalConductivity" = thermalConductivity,"boundaryLayerConductance" = boundaryLayerConductance,"newTemperature" = newTemperature,"airTemperature" = airTemperature,"maxTempYesterday" = maxTempYesterday,"minTempYesterday" = minTempYesterday,"soilWater" = soilWater,"minSoilTemp" = minSoilTemp,"maxSoilTemp" = maxSoilTemp,"aveSoilTemp" = aveSoilTemp,"aveSoilWater" = aveSoilWater,"thickness" = thickness,"bulkDensity" = bulkDensity,"rocks" = rocks,"carbon" = carbon,"sand" = sand,"silt" = silt,"clay" = clay,"soilRoughnessHeight" = soilRoughnessHeight,"instrumentHeight" = instrumentHeight,"netRadiation" = netRadiation,"canopyHeight" = canopyHeight,"instrumHeight" = instrumHeight))
}