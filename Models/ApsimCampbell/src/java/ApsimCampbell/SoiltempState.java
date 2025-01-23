import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class SoiltempState
{
    private double netRadiation;
    private Double [] aveSoilWater;
    private Double [] bulkDensity;
    private double internalTimeStep;
    private Double [] thermalConductance;
    private Double [] thickness;
    private Boolean doInitialisationStuff;
    private double maxTempYesterday;
    private double timeOfDaySecs;
    private Integer numNodes;
    private Double [] soilWater;
    private Double [] clay;
    private Double [] soilTemp;
    private Double [] silt;
    private double instrumentHeight;
    private Double [] sand;
    private Integer numLayers;
    private Double [] volSpecHeatSoil;
    private double instrumHeight;
    private double canopyHeight;
    private Double [] heatStorage;
    private Double [] minSoilTemp;
    private Double [] maxSoilTemp;
    private Double [] newTemperature;
    private double airTemperature;
    private Double [] thermalConductivity;
    private double minTempYesterday;
    private Double [] carbon;
    private Double [] rocks;
    private Double [] InitialValues;
    private double boundaryLayerConductance;
    private Double [] aveSoilTemp;
    private Double [] morningSoilTemp;
    
    public SoiltempState() { }
    
    public SoiltempState(SoiltempState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.netRadiation = toCopy.getnetRadiation();
            aveSoilWater = new Double[toCopy.getaveSoilWater().length];
        for (int i = 0; i < toCopy.getaveSoilWater().length; i++)
        {
            aveSoilWater[i] = toCopy.getaveSoilWater()[i];
        }
            bulkDensity = new Double[toCopy.getbulkDensity().length];
        for (int i = 0; i < toCopy.getbulkDensity().length; i++)
        {
            bulkDensity[i] = toCopy.getbulkDensity()[i];
        }
            this.internalTimeStep = toCopy.getinternalTimeStep();
            thermalConductance = new Double[toCopy.getthermalConductance().length];
        for (int i = 0; i < toCopy.getthermalConductance().length; i++)
        {
            thermalConductance[i] = toCopy.getthermalConductance()[i];
        }
            thickness = new Double[toCopy.getthickness().length];
        for (int i = 0; i < toCopy.getthickness().length; i++)
        {
            thickness[i] = toCopy.getthickness()[i];
        }
            this.doInitialisationStuff = toCopy.getdoInitialisationStuff();
            this.maxTempYesterday = toCopy.getmaxTempYesterday();
            this.timeOfDaySecs = toCopy.gettimeOfDaySecs();
            this.numNodes = toCopy.getnumNodes();
            soilWater = new Double[toCopy.getsoilWater().length];
        for (int i = 0; i < toCopy.getsoilWater().length; i++)
        {
            soilWater[i] = toCopy.getsoilWater()[i];
        }
            clay = new Double[toCopy.getclay().length];
        for (int i = 0; i < toCopy.getclay().length; i++)
        {
            clay[i] = toCopy.getclay()[i];
        }
            soilTemp = new Double[toCopy.getsoilTemp().length];
        for (int i = 0; i < toCopy.getsoilTemp().length; i++)
        {
            soilTemp[i] = toCopy.getsoilTemp()[i];
        }
            silt = new Double[toCopy.getsilt().length];
        for (int i = 0; i < toCopy.getsilt().length; i++)
        {
            silt[i] = toCopy.getsilt()[i];
        }
            this.instrumentHeight = toCopy.getinstrumentHeight();
            sand = new Double[toCopy.getsand().length];
        for (int i = 0; i < toCopy.getsand().length; i++)
        {
            sand[i] = toCopy.getsand()[i];
        }
            this.numLayers = toCopy.getnumLayers();
            volSpecHeatSoil = new Double[toCopy.getvolSpecHeatSoil().length];
        for (int i = 0; i < toCopy.getvolSpecHeatSoil().length; i++)
        {
            volSpecHeatSoil[i] = toCopy.getvolSpecHeatSoil()[i];
        }
            this.instrumHeight = toCopy.getinstrumHeight();
            this.canopyHeight = toCopy.getcanopyHeight();
            heatStorage = new Double[toCopy.getheatStorage().length];
        for (int i = 0; i < toCopy.getheatStorage().length; i++)
        {
            heatStorage[i] = toCopy.getheatStorage()[i];
        }
            minSoilTemp = new Double[toCopy.getminSoilTemp().length];
        for (int i = 0; i < toCopy.getminSoilTemp().length; i++)
        {
            minSoilTemp[i] = toCopy.getminSoilTemp()[i];
        }
            maxSoilTemp = new Double[toCopy.getmaxSoilTemp().length];
        for (int i = 0; i < toCopy.getmaxSoilTemp().length; i++)
        {
            maxSoilTemp[i] = toCopy.getmaxSoilTemp()[i];
        }
            newTemperature = new Double[toCopy.getnewTemperature().length];
        for (int i = 0; i < toCopy.getnewTemperature().length; i++)
        {
            newTemperature[i] = toCopy.getnewTemperature()[i];
        }
            this.airTemperature = toCopy.getairTemperature();
            thermalConductivity = new Double[toCopy.getthermalConductivity().length];
        for (int i = 0; i < toCopy.getthermalConductivity().length; i++)
        {
            thermalConductivity[i] = toCopy.getthermalConductivity()[i];
        }
            this.minTempYesterday = toCopy.getminTempYesterday();
            carbon = new Double[toCopy.getcarbon().length];
        for (int i = 0; i < toCopy.getcarbon().length; i++)
        {
            carbon[i] = toCopy.getcarbon()[i];
        }
            rocks = new Double[toCopy.getrocks().length];
        for (int i = 0; i < toCopy.getrocks().length; i++)
        {
            rocks[i] = toCopy.getrocks()[i];
        }
            InitialValues = new Double[toCopy.getInitialValues().length];
        for (int i = 0; i < toCopy.getInitialValues().length; i++)
        {
            InitialValues[i] = toCopy.getInitialValues()[i];
        }
            this.boundaryLayerConductance = toCopy.getboundaryLayerConductance();
            aveSoilTemp = new Double[toCopy.getaveSoilTemp().length];
        for (int i = 0; i < toCopy.getaveSoilTemp().length; i++)
        {
            aveSoilTemp[i] = toCopy.getaveSoilTemp()[i];
        }
            morningSoilTemp = new Double[toCopy.getmorningSoilTemp().length];
        for (int i = 0; i < toCopy.getmorningSoilTemp().length; i++)
        {
            morningSoilTemp[i] = toCopy.getmorningSoilTemp()[i];
        }
        }
    }
    public double getnetRadiation()
    { return netRadiation; }

    public void setnetRadiation(double _netRadiation)
    { this.netRadiation= _netRadiation; } 
    
    public Double [] getaveSoilWater()
    { return aveSoilWater; }

    public void setaveSoilWater(Double [] _aveSoilWater)
    { this.aveSoilWater= _aveSoilWater; } 
    
    public Double [] getbulkDensity()
    { return bulkDensity; }

    public void setbulkDensity(Double [] _bulkDensity)
    { this.bulkDensity= _bulkDensity; } 
    
    public double getinternalTimeStep()
    { return internalTimeStep; }

    public void setinternalTimeStep(double _internalTimeStep)
    { this.internalTimeStep= _internalTimeStep; } 
    
    public Double [] getthermalConductance()
    { return thermalConductance; }

    public void setthermalConductance(Double [] _thermalConductance)
    { this.thermalConductance= _thermalConductance; } 
    
    public Double [] getthickness()
    { return thickness; }

    public void setthickness(Double [] _thickness)
    { this.thickness= _thickness; } 
    
    public Boolean getdoInitialisationStuff()
    { return doInitialisationStuff; }

    public void setdoInitialisationStuff(Boolean _doInitialisationStuff)
    { this.doInitialisationStuff= _doInitialisationStuff; } 
    
    public double getmaxTempYesterday()
    { return maxTempYesterday; }

    public void setmaxTempYesterday(double _maxTempYesterday)
    { this.maxTempYesterday= _maxTempYesterday; } 
    
    public double gettimeOfDaySecs()
    { return timeOfDaySecs; }

    public void settimeOfDaySecs(double _timeOfDaySecs)
    { this.timeOfDaySecs= _timeOfDaySecs; } 
    
    public Integer getnumNodes()
    { return numNodes; }

    public void setnumNodes(Integer _numNodes)
    { this.numNodes= _numNodes; } 
    
    public Double [] getsoilWater()
    { return soilWater; }

    public void setsoilWater(Double [] _soilWater)
    { this.soilWater= _soilWater; } 
    
    public Double [] getclay()
    { return clay; }

    public void setclay(Double [] _clay)
    { this.clay= _clay; } 
    
    public Double [] getsoilTemp()
    { return soilTemp; }

    public void setsoilTemp(Double [] _soilTemp)
    { this.soilTemp= _soilTemp; } 
    
    public Double [] getsilt()
    { return silt; }

    public void setsilt(Double [] _silt)
    { this.silt= _silt; } 
    
    public double getinstrumentHeight()
    { return instrumentHeight; }

    public void setinstrumentHeight(double _instrumentHeight)
    { this.instrumentHeight= _instrumentHeight; } 
    
    public Double [] getsand()
    { return sand; }

    public void setsand(Double [] _sand)
    { this.sand= _sand; } 
    
    public Integer getnumLayers()
    { return numLayers; }

    public void setnumLayers(Integer _numLayers)
    { this.numLayers= _numLayers; } 
    
    public Double [] getvolSpecHeatSoil()
    { return volSpecHeatSoil; }

    public void setvolSpecHeatSoil(Double [] _volSpecHeatSoil)
    { this.volSpecHeatSoil= _volSpecHeatSoil; } 
    
    public double getinstrumHeight()
    { return instrumHeight; }

    public void setinstrumHeight(double _instrumHeight)
    { this.instrumHeight= _instrumHeight; } 
    
    public double getcanopyHeight()
    { return canopyHeight; }

    public void setcanopyHeight(double _canopyHeight)
    { this.canopyHeight= _canopyHeight; } 
    
    public Double [] getheatStorage()
    { return heatStorage; }

    public void setheatStorage(Double [] _heatStorage)
    { this.heatStorage= _heatStorage; } 
    
    public Double [] getminSoilTemp()
    { return minSoilTemp; }

    public void setminSoilTemp(Double [] _minSoilTemp)
    { this.minSoilTemp= _minSoilTemp; } 
    
    public Double [] getmaxSoilTemp()
    { return maxSoilTemp; }

    public void setmaxSoilTemp(Double [] _maxSoilTemp)
    { this.maxSoilTemp= _maxSoilTemp; } 
    
    public Double [] getnewTemperature()
    { return newTemperature; }

    public void setnewTemperature(Double [] _newTemperature)
    { this.newTemperature= _newTemperature; } 
    
    public double getairTemperature()
    { return airTemperature; }

    public void setairTemperature(double _airTemperature)
    { this.airTemperature= _airTemperature; } 
    
    public Double [] getthermalConductivity()
    { return thermalConductivity; }

    public void setthermalConductivity(Double [] _thermalConductivity)
    { this.thermalConductivity= _thermalConductivity; } 
    
    public double getminTempYesterday()
    { return minTempYesterday; }

    public void setminTempYesterday(double _minTempYesterday)
    { this.minTempYesterday= _minTempYesterday; } 
    
    public Double [] getcarbon()
    { return carbon; }

    public void setcarbon(Double [] _carbon)
    { this.carbon= _carbon; } 
    
    public Double [] getrocks()
    { return rocks; }

    public void setrocks(Double [] _rocks)
    { this.rocks= _rocks; } 
    
    public Double [] getInitialValues()
    { return InitialValues; }

    public void setInitialValues(Double [] _InitialValues)
    { this.InitialValues= _InitialValues; } 
    
    public double getboundaryLayerConductance()
    { return boundaryLayerConductance; }

    public void setboundaryLayerConductance(double _boundaryLayerConductance)
    { this.boundaryLayerConductance= _boundaryLayerConductance; } 
    
    public Double [] getaveSoilTemp()
    { return aveSoilTemp; }

    public void setaveSoilTemp(Double [] _aveSoilTemp)
    { this.aveSoilTemp= _aveSoilTemp; } 
    
    public Double [] getmorningSoilTemp()
    { return morningSoilTemp; }

    public void setmorningSoilTemp(Double [] _morningSoilTemp)
    { this.morningSoilTemp= _morningSoilTemp; } 
    
}