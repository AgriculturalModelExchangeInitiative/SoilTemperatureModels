"""
        #region Outputs
        public double[] soilTemp;
        public double[] minSoilTemp;
        public double[] maxSoilTemp;
        public double[] aveSoilTemp;
        public double[] morningSoilTemp;
        public double[] tempNew;
        public double[] volSpecHeatSoil;
        public double[] thermalConductivity;
        public double[] thermalConductance;
        public double[] heatStorage;
        #endregion
"""
def model_SoilTemperatureCampbell():
    """
    - Name: SoilTemperatureCampbell
    - Version: 1.0
    - Time step: 1
    - Description:
                * Title: SoilTemperature model from Campbell implemented in APSIM
                * Author: Teiki Raihauti and Christophe Pradal
                * Reference: Campbell model (TODO)
                * Institution: CIRAD and INRAE
                * ExtendedDescription: TODO
                * ShortDescription: TODO
    
    - inputs: 

    - outputs: 
                * name: soilTemp
                            ** description :  Temperature at end of last time-step within a day - midnight in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: minSoilTemp
                            ** description : Minimum soil temperature in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: maxSoilTemp
                            ** description :  Maximum soil temperature in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: aveSoilTemp
                            ** description : Temperature averaged over all time-steps within a day in layers.
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: morningSoilTemp
                            ** description : Temperature  in the morning in layers.
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: tempNew
                            ** description : Soil temperature at the end of one iteration
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : -60.
                            ** max : 60.
                            ** unit : degC
                            ** uri : 
                * name: heatCapacity
                            ** description : Heat Capacity in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : 
                            ** max : 
                            ** unit : J/m3/K/s
                            ** uri : 
                * name: thermalConductivity
                            ** description : thermal conductivity in layers
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : 
                            ** max : 
                            ** unit : (W/m2/K)
                            ** uri : 
                * name: thermalConductance
                            ** description : Thermal conductance between layers 
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : 
                            ** max : 
                            ** unit : 
                            ** uri : 
                * name: heatStorage
                            ** description : Heat storage between layers (internal)
                            ** variablecategory : state
                            ** datatype : DOUBLEARRAY
                            ** min : 
                            ** max : 
                            ** unit : J/s/K
                            ** uri : 
    """