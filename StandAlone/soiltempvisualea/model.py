import pandas as pd
from collections import OrderedDict 
import dataclasses 

from Campbell.campbell import init_campbell, model_campbell

class Model:
    """ Define an model interface for soil temperature models"""

    def init(self, config):
        pass

    def run(self, config, nb_steps=0):
        pass

    @classmethod
    def models(cls):
        return dict((m.__name__, m) for m in cls.__subclasses__())


class Campbell(Model):
    """ APSIM implementation of the Cambell model.
    """

    def run(self, config, nb_steps=0):

        c = config
        soil = c.soil
        weather = c.weather
        
        # Parameters not in the config
        CONSTANT_TEMPdepth:float = 10000.0
        airPressure:float = 1010.0
        canopyHeight:float = 0.057
        instrumentHeight: float = 1.2
        ES = 0.0
        boundaryLayerConductanceSource:str = 'calc'
        netRadiationSource:str = 'calc'
        windSpeed:float = 3.0

        # variable
        soil_water = soil.SLLL + c.AWC * (soil.SLDUL - soil.SLLL)

        # Soil parameter
        SLLT = soil.SLLT.tolist()
        SLLB = soil.SLLB.tolist()
        THICK=soil.THICK.tolist()
        BD=soil.SLBDM.tolist()
        SLCARB=soil.SLOC.tolist() 
        CLAY=soil.SLCLY.tolist()
        SLROCK=soil.SLROCK.tolist() 
        SLSILT=soil.SLSILT.tolist() 
        SLSAND=soil.SLSAND.tolist()
        SW=soil_water.tolist()

        _wi = dict(config.weather.iloc[0])
        WeatherRecord = dataclasses.make_dataclass('WeatherRecord',list(config.weather.columns) )
        wi = WeatherRecord(**_wi) 

        # init
        data_init = init_campbell(
            NLAYR=c.nb_layers,
            CONSTANT_TEMPdepth=CONSTANT_TEMPdepth, 
            T2M=wi.T2M, #
            TMAX=wi.TMAX, #
            TMIN=wi.TMIN, #
            TAV=c.TAV,
            TAMP=c.TAMP,
            XLAT=c.XLAT,
            DOY=wi.DATE.dayofyear, #
            canopyHeight=canopyHeight,
            SALB=c.albedo,
            SRAD=wi.SRAD, #
            ESP=wi.ESP, #
            ES=ES, 
            EOAD=wi.EOAD, #
            instrumentHeight=instrumentHeight, 
            # soil
            THICK=THICK, 
            BD=BD, 
            SLCARB=SLCARB, 
            CLAY=CLAY, 
            SLROCK=SLROCK, 
            SLSILT=SLSILT, 
            SLSAND=SLSAND,
            SW=SW,     
            airPressure=airPressure, 
            boundaryLayerConductanceSource=boundaryLayerConductanceSource,
            netRadiationSource=netRadiationSource, 
            windSpeed=windSpeed)        
        
        (thickness, 
        depth, 
        bulkDensity, 
        clay, 
        soilWater, 
        soilTemp, 
        newTemperature, 
        minSoilTemp, 
        maxSoilTemp, 
        aveSoilTemp, 
        morningSoilTemp,
        thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, 
        thermalConductivity, thermalConductance, 
        heatStorage, volSpecHeatSoil, 
        maxTempYesterday,
        minTempYesterday, 
        carbon, rocks, silt, sand, 
        boundaryLayerConductance) = data_init



        # Outputs
        columns = "Date SLLT SLLB TSLD TSLX TSLN Layer".split()
        Dates = []
        SLLTs = []
        SLLBs = []
        TSLDs = []
        TSLXs = []
        TSLNs = []
        Layers = []

        count = 0
        
        for i, _wi in weather.iterrows():
            if count == nb_steps:
                break
            else:
                count += 1

            wi = WeatherRecord(**_wi) 

            # Call the model
            (soilTemp, 
            minSoilTemp, 
            maxSoilTemp, 
            aveSoilTemp,
            morningSoilTemp, 
            newTemperature, 
            maxTempYesterday, 
            minTempYesterday, 
            thermalCondPar1, thermalCondPar2, thermalCondPar3, thermalCondPar4, 
            thermalConductivity, thermalConductance, 
            heatStorage, 
            volSpecHeatSoil, 
            boundaryLayerConductance, 
            thickness, 
            depth, 
            bulkDensity, 
            soilWater, 
            clay,
            rocks, 
            carbon, 
            sand, 
            silt) = model_campbell(
                # idem from init
                NLAYR=c.nb_layers,
                CONSTANT_TEMPdepth=CONSTANT_TEMPdepth, 
                T2M=wi.T2M, 
                TMAX=wi.TMAX, 
                TMIN=wi.TMIN,
                TAV=c.TAV, 
                TAMP=c.TAMP, 
                XLAT=c.XLAT,
                DOY=wi.DATE.dayofyear,
                canopyHeight=canopyHeight, 
                SALB=c.albedo,
                SRAD=wi.SRAD, 
                ESP=wi.ESP, 
                ES=ES, 
                EOAD=wi.EOAD,
                instrumentHeight=instrumentHeight,

                # soil
                THICK=THICK, 
                BD=BD, 
                SLCARB=SLCARB, 
                CLAY=CLAY, 
                SLROCK=SLROCK, 
                SLSILT=SLSILT, 
                SLSAND=SLSAND,
                SW=SW,     

                # APSIM soil internal variable 
                THICKApsim=thickness, 
                BDApsim=bulkDensity, 
                CLAYApsim=clay, 
                SLROCKApsim=rocks, 
                SLSILTApsim=silt, 
                SLSANDApsim=sand, 
                SWApsim=soilWater,
                DEPTHApsim =depth, 
                SLCARBApsim=carbon, 

                soilTemp=soilTemp, 
                minSoilTemp=minSoilTemp, 
                maxSoilTemp=maxSoilTemp, 
                aveSoilTemp=aveSoilTemp,
                morningSoilTemp=morningSoilTemp, 
                newTemperature=newTemperature, 
                maxTempYesterday=maxTempYesterday, 
                minTempYesterday=minTempYesterday, 
                thermalCondPar1=thermalCondPar1,
                thermalCondPar2=thermalCondPar2, 
                thermalCondPar3=thermalCondPar3, 
                thermalCondPar4=thermalCondPar4, 
                thermalConductivity=thermalConductivity, 
                thermalConductance=thermalConductance, 
                heatStorage=heatStorage, 
                volSpecHeatSoil=volSpecHeatSoil, 
                _boundaryLayerConductance=boundaryLayerConductance, 
                
                # parameters
                airPressure=airPressure, 
                boundaryLayerConductanceSource=boundaryLayerConductanceSource,
                netRadiationSource=netRadiationSource, windSpeed=windSpeed
                ) 
            
            # Store the outputs
            #date_formattee = wi.DATE.strftime("%Y-%m-%d")
            #Dates.append(wi.DATE.dayofyear); 
            Dates.append(wi.DATE); 
            SLLTs.append(0); SLLBs.append(0); TSLDs.append(aveSoilTemp[1]); TSLXs.append(maxSoilTemp[1]); TSLNs.append(minSoilTemp[1]); Layers.append(0)
            for j in range(2, c.nb_layers+2):
                #Dates.append(wi.DATE.dayofyear); 
                Dates.append(wi.DATE); 
                SLLTs.append(int(SLLT[j-2])); SLLBs.append(int(SLLB[j-2]*100)); TSLDs.append(aveSoilTemp[j]); TSLXs.append(maxSoilTemp[j]); TSLNs.append(minSoilTemp[j]); Layers.append(j-1)
 
        df = pd.DataFrame( OrderedDict(
                Date = Dates,
                SLLT = SLLTs,
                SLLB = SLLBs,
                TSLD = TSLDs,
                TSLX = TSLXs,
                TSLN = TSLNs,
                Layer =Layers            
                ),
                columns=columns)
        
        return df
            
#######################################################################################
# DSSAT EPIC ST
from DSSAT_EPICST_standalone import stemp_epic

class DSSAT_EPIC(Model):
    # TODO : Write the wmapping explicitly

    def run(self, config, nb_steps=0):

        init_fun = stemp_epic.init_stemp_epic
        model_fun = stemp_epic.model_stemp_epic 


        c = config
        soil = c.soil
        weather = c.weather
        
        ###########################################
        # TODO : Revisit for DSSAT
        # Parameters not in the config
        CONSTANT_TEMPdepth:float = 10000.0
        airPressure:float = 1010.0
        canopyHeight:float = 0.057
        instrumentHeight: float = 1.2
        ES = 0.0
        boundaryLayerConductanceSource:str = 'calc'
        netRadiationSource:str = 'calc'
        windSpeed:float = 3.0
        ###########################################



        # variable
        soil_water = soil.SLLL + c.AWC * (soil.SLDUL - soil.SLLL)

        # Soil parameter
        SLLT = soil.SLLT.tolist()
        SLLB = soil.SLLB.tolist()
        THICK=soil.THICK.tolist()
        BD=soil.SLBDM.tolist()
        SLCARB=soil.SLOC.tolist() 
        CLAY=soil.SLCLY.tolist()
        SLROCK=soil.SLROCK.tolist() 
        SLSILT=soil.SLSILT.tolist() 
        SLSAND=soil.SLSAND.tolist()
        SW=soil_water.tolist()
        SLDUL = soil.SLDUL.tolist()
        DS = soil.THICK.cumsum().tolist()
        SLLL = soil.SLLL.tolist()

        _wi = dict(config.weather.iloc[0])
        WeatherRecord = dataclasses.make_dataclass('WeatherRecord',list(config.weather.columns) )
        wi = WeatherRecord(**_wi) 

        ####################################
        # ADAPTAION to DSSAT

        BD = BD
        DLAYR = THICK
        SW = soil_water
        DS = DS
        DUL = SLDUL
        ISWWAT = "Y"
        LL = SLLL
        NL = c.nb_layers
        NLAYR = NL

        BIOMAS = c.above_ground_dry_mass
        DEPIR = c.irrig
        MULCHMASS = c.mulch
        RAIN = wi.RAIN
        SNOW = wi.SNOW
        TAMP = c.TAMP
        TAV = c.TAV
        TAVG = wi.T2M
        TMAX = wi.TMAX
        TMIN = wi.TMIN


        # init
        data_init = init_fun(
            NL=NL, 
            ISWWAT=ISWWAT,
            BD=BD,
            DLAYR=DLAYR, DS=DS, DUL=DUL, LL=LL, NLAYR=NLAYR, TAMP=TAMP, RAIN=RAIN, SW=SW, 
            TAVG=TAVG, TMAX=TMAX, TMIN=TMIN, TAV=TAV, DEPIR=DEPIR, BIOMAS=BIOMAS, MULCHMASS=MULCHMASS, SNOW=SNOW)
        
        (CUMDPT, DSMID, TDL, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST) = data_init



        # Outputs
        columns = "Date SLLT SLLB TSLD TSLX TSLN Layer".split()
        Dates = []
        SLLTs = []
        SLLBs = []
        TSLDs = []
        TSLXs = []
        TSLNs = []
        Layers = []

        count = 0
        
        for i, _wi in weather.iterrows():
            if count == nb_steps:
                break
            else:
                count += 1

            wi = WeatherRecord(**_wi) 

            # Update some variables
            RAIN = wi.RAIN
            SNOW = wi.SNOW
            TAVG = wi.T2M
            TMAX = wi.TMAX
            TMIN = wi.TMIN

            # Call the model
            results = model_fun(
                TAV=TAV, RAIN=RAIN, DUL=DUL, WetDay=WetDay,
                SRFTEMP=SRFTEMP,NDays=NDays,BIOMAS=BIOMAS,
                NL=NL,
                NLAYR=NLAYR,
                ST=ST,
                SNOW=SNOW,
                TMA=TMA,
                DS=DS,
                ISWWAT=ISWWAT,
                BD=BD,
                TAVG=TAVG,
                LL=LL,
                DEPIR=DEPIR,
                DLAYR=DLAYR,
                TDL=TDL,
                MULCHMASS=MULCHMASS,
                TMAX=TMAX,
                TMIN=TMIN,
                X2_PREV=X2_PREV,
                DSMID=DSMID,
                TAMP=TAMP,
                CUMDPT=CUMDPT,
                SW=SW,
                ) 
            (CUMDPT, DSMID, TDL, TMA, NDays, WetDay, X2_PREV, SRFTEMP, ST) = results

            # Store the outputs
            #date_formattee = wi.DATE.strftime("%Y-%m-%d")
            #Dates.append(wi.DATE.dayofyear); 
            Dates.append(wi.DATE); 
            SLLTs.append(0); SLLBs.append(0); TSLDs.append(SRFTEMP); TSLXs.append(SRFTEMP); TSLNs.append(SRFTEMP); Layers.append(0)
            for j in range(c.nb_layers):
                #Dates.append(wi.DATE.dayofyear); 
                Dates.append(wi.DATE); 
                SLLTs.append(int(SLLT[j])); SLLBs.append(int(SLLB[j]*100)); TSLDs.append(ST[j]); TSLXs.append(ST[j]); TSLNs.append(ST[j]); Layers.append(j+1)
 
        df = pd.DataFrame( OrderedDict(
                Date = Dates,
                SLLT = SLLTs,
                SLLB = SLLBs,
                TSLD = TSLDs,
                TSLX = TSLXs,
                TSLN = TSLNs,
                Layer =Layers            
                ),
                columns=columns)
        
        return df
            


#######################################################################################

"""
# ICASA

DSSAT_ICASA = dict(NL='NLAYER')

class ICASA(Model)
    
    def __init__(self, mapping, name):
        self.name=name
        self.mapping=mapping

    def run(self, config):
        dssat_input = dssasmodel.inputs()
        icasa_input = [DSSAT_ICASA[input] for input in dssat_input]
        outputs = run_my_model()

        dssasmodel.inputs()
        ICASA_DSSAT = dict((v,k) for k, v in DSSAT_ICASA.iteritems())

"""