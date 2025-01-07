import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class SoiltempState
{
    private Double [] thermalConductance;
    private Double [] newTemperature;
    private double instrumentHeight;
    private Double [] aveSoilWater;
    private Double [] thermalConductivity;
    private Double [] silt;
    private Double [] bulkDensity;
    private double netRadiation;
    private Double [] rocks;
    private Integer numLayers;
    private Double [] minSoilTemp;
    private double instrumHeight;
    private Double [] soilTemp;
    private Boolean doInitialisationStuff;
    private double canopyHeight;
    private double boundaryLayerConductance;
    private Double [] soilWater;
    private double maxTempYesterday;
    private Double [] clay;
    private Double [] thickness;
    private Double [] maxSoilTemp;
    private double timeOfDaySecs;
    private Double [] carbon;
    private Double [] heatStorage;
    private Double [] aveSoilTemp;
    private double minTempYesterday;
    private Integer numNodes;
    private Double [] volSpecHeatSoil;
    private Double [] sand;
    private Double [] morningSoilTemp;
    private double airTemperature;
    private double internalTimeStep;
    
    public SoiltempState() { }
    
    public SoiltempState(SoiltempState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            thermalConductance = new Double[toCopy.getthermalConductance().length];
        for (int i = 0; i < toCopy.getthermalConductance().length; i++)
        {
            thermalConductance[i] = toCopy.getthermalConductance()[i];
        }
            newTemperature = new Double[toCopy.getnewTemperature().length];
        for (int i = 0; i < toCopy.getnewTemperature().length; i++)
        {
            newTemperature[i] = toCopy.getnewTemperature()[i];
        }
            this.instrumentHeight = toCopy.getinstrumentHeight();
            aveSoilWater = new Double[toCopy.getaveSoilWater().length];
        for (int i = 0; i < toCopy.getaveSoilWater().length; i++)
        {
            aveSoilWater[i] = toCopy.getaveSoilWater()[i];
        }
            thermalConductivity = new Double[toCopy.getthermalConductivity().length];
        for (int i = 0; i < toCopy.getthermalConductivity().length; i++)
        {
            thermalConductivity[i] = toCopy.getthermalConductivity()[i];
        }
            silt = new Double[toCopy.getsilt().length];
        for (int i = 0; i < toCopy.getsilt().length; i++)
        {
            silt[i] = toCopy.getsilt()[i];
        }
            bulkDensity = new Double[toCopy.getbulkDensity().length];
        for (int i = 0; i < toCopy.getbulkDensity().length; i++)
        {
            bulkDensity[i] = toCopy.getbulkDensity()[i];
        }
            this.netRadiation = toCopy.getnetRadiation();
            rocks = new Double[toCopy.getrocks().length];
        for (int i = 0; i < toCopy.getrocks().length; i++)
        {
            rocks[i] = toCopy.getrocks()[i];
        }
            this.numLayers = toCopy.getnumLayers();
            minSoilTemp = new Double[toCopy.getminSoilTemp().length];
        for (int i = 0; i < toCopy.getminSoilTemp().length; i++)
        {
            minSoilTemp[i] = toCopy.getminSoilTemp()[i];
        }
            this.instrumHeight = toCopy.getinstrumHeight();
            soilTemp = new Double[toCopy.getsoilTemp().length];
        for (int i = 0; i < toCopy.getsoilTemp().length; i++)
        {
            soilTemp[i] = toCopy.getsoilTemp()[i];
        }
            this.doInitialisationStuff = toCopy.getdoInitialisationStuff();
            this.canopyHeight = toCopy.getcanopyHeight();
            this.boundaryLayerConductance = toCopy.getboundaryLayerConductance();
            soilWater = new Double[toCopy.getsoilWater().length];
        for (int i = 0; i < toCopy.getsoilWater().length; i++)
        {
            soilWater[i] = toCopy.getsoilWater()[i];
        }
            this.maxTempYesterday = toCopy.getmaxTempYesterday();
            clay = new Double[toCopy.getclay().length];
        for (int i = 0; i < toCopy.getclay().length; i++)
        {
            clay[i] = toCopy.getclay()[i];
        }
            thickness = new Double[toCopy.getthickness().length];
        for (int i = 0; i < toCopy.getthickness().length; i++)
        {
            thickness[i] = toCopy.getthickness()[i];
        }
            maxSoilTemp = new Double[toCopy.getmaxSoilTemp().length];
        for (int i = 0; i < toCopy.getmaxSoilTemp().length; i++)
        {
            maxSoilTemp[i] = toCopy.getmaxSoilTemp()[i];
        }
            this.timeOfDaySecs = toCopy.gettimeOfDaySecs();
            carbon = new Double[toCopy.getcarbon().length];
        for (int i = 0; i < toCopy.getcarbon().length; i++)
        {
            carbon[i] = toCopy.getcarbon()[i];
        }
            heatStorage = new Double[toCopy.getheatStorage().length];
        for (int i = 0; i < toCopy.getheatStorage().length; i++)
        {
            heatStorage[i] = toCopy.getheatStorage()[i];
        }
            aveSoilTemp = new Double[toCopy.getaveSoilTemp().length];
        for (int i = 0; i < toCopy.getaveSoilTemp().length; i++)
        {
            aveSoilTemp[i] = toCopy.getaveSoilTemp()[i];
        }
            this.minTempYesterday = toCopy.getminTempYesterday();
            this.numNodes = toCopy.getnumNodes();
            volSpecHeatSoil = new Double[toCopy.getvolSpecHeatSoil().length];
        for (int i = 0; i < toCopy.getvolSpecHeatSoil().length; i++)
        {
            volSpecHeatSoil[i] = toCopy.getvolSpecHeatSoil()[i];
        }
            sand = new Double[toCopy.getsand().length];
        for (int i = 0; i < toCopy.getsand().length; i++)
        {
            sand[i] = toCopy.getsand()[i];
        }
            morningSoilTemp = new Double[toCopy.getmorningSoilTemp().length];
        for (int i = 0; i < toCopy.getmorningSoilTemp().length; i++)
        {
            morningSoilTemp[i] = toCopy.getmorningSoilTemp()[i];
        }
            this.airTemperature = toCopy.getairTemperature();
            this.internalTimeStep = toCopy.getinternalTimeStep();
        }
    }
    public Double [] getthermalConductance()
    { return thermalConductance; }

    public void setthermalConductance(Double [] _thermalConductance)
    { this.thermalConductance= _thermalConductance; } 
    
    public Double [] getnewTemperature()
    { return newTemperature; }

    public void setnewTemperature(Double [] _newTemperature)
    { this.newTemperature= _newTemperature; } 
    
    public double getinstrumentHeight()
    { return instrumentHeight; }

    public void setinstrumentHeight(double _instrumentHeight)
    { this.instrumentHeight= _instrumentHeight; } 
    
    public Double [] getaveSoilWater()
    { return aveSoilWater; }

    public void setaveSoilWater(Double [] _aveSoilWater)
    { this.aveSoilWater= _aveSoilWater; } 
    
    public Double [] getthermalConductivity()
    { return thermalConductivity; }

    public void setthermalConductivity(Double [] _thermalConductivity)
    { this.thermalConductivity= _thermalConductivity; } 
    
    public Double [] getsilt()
    { return silt; }

    public void setsilt(Double [] _silt)
    { this.silt= _silt; } 
    
    public Double [] getbulkDensity()
    { return bulkDensity; }

    public void setbulkDensity(Double [] _bulkDensity)
    { this.bulkDensity= _bulkDensity; } 
    
    public double getnetRadiation()
    { return netRadiation; }

    public void setnetRadiation(double _netRadiation)
    { this.netRadiation= _netRadiation; } 
    
    public Double [] getrocks()
    { return rocks; }

    public void setrocks(Double [] _rocks)
    { this.rocks= _rocks; } 
    
    public Integer getnumLayers()
    { return numLayers; }

    public void setnumLayers(Integer _numLayers)
    { this.numLayers= _numLayers; } 
    
    public Double [] getminSoilTemp()
    { return minSoilTemp; }

    public void setminSoilTemp(Double [] _minSoilTemp)
    { this.minSoilTemp= _minSoilTemp; } 
    
    public double getinstrumHeight()
    { return instrumHeight; }

    public void setinstrumHeight(double _instrumHeight)
    { this.instrumHeight= _instrumHeight; } 
    
    public Double [] getsoilTemp()
    { return soilTemp; }

    public void setsoilTemp(Double [] _soilTemp)
    { this.soilTemp= _soilTemp; } 
    
    public Boolean getdoInitialisationStuff()
    { return doInitialisationStuff; }

    public void setdoInitialisationStuff(Boolean _doInitialisationStuff)
    { this.doInitialisationStuff= _doInitialisationStuff; } 
    
    public double getcanopyHeight()
    { return canopyHeight; }

    public void setcanopyHeight(double _canopyHeight)
    { this.canopyHeight= _canopyHeight; } 
    
    public double getboundaryLayerConductance()
    { return boundaryLayerConductance; }

    public void setboundaryLayerConductance(double _boundaryLayerConductance)
    { this.boundaryLayerConductance= _boundaryLayerConductance; } 
    
    public Double [] getsoilWater()
    { return soilWater; }

    public void setsoilWater(Double [] _soilWater)
    { this.soilWater= _soilWater; } 
    
    public double getmaxTempYesterday()
    { return maxTempYesterday; }

    public void setmaxTempYesterday(double _maxTempYesterday)
    { this.maxTempYesterday= _maxTempYesterday; } 
    
    public Double [] getclay()
    { return clay; }

    public void setclay(Double [] _clay)
    { this.clay= _clay; } 
    
    public Double [] getthickness()
    { return thickness; }

    public void setthickness(Double [] _thickness)
    { this.thickness= _thickness; } 
    
    public Double [] getmaxSoilTemp()
    { return maxSoilTemp; }

    public void setmaxSoilTemp(Double [] _maxSoilTemp)
    { this.maxSoilTemp= _maxSoilTemp; } 
    
    public double gettimeOfDaySecs()
    { return timeOfDaySecs; }

    public void settimeOfDaySecs(double _timeOfDaySecs)
    { this.timeOfDaySecs= _timeOfDaySecs; } 
    
    public Double [] getcarbon()
    { return carbon; }

    public void setcarbon(Double [] _carbon)
    { this.carbon= _carbon; } 
    
    public Double [] getheatStorage()
    { return heatStorage; }

    public void setheatStorage(Double [] _heatStorage)
    { this.heatStorage= _heatStorage; } 
    
    public Double [] getaveSoilTemp()
    { return aveSoilTemp; }

    public void setaveSoilTemp(Double [] _aveSoilTemp)
    { this.aveSoilTemp= _aveSoilTemp; } 
    
    public double getminTempYesterday()
    { return minTempYesterday; }

    public void setminTempYesterday(double _minTempYesterday)
    { this.minTempYesterday= _minTempYesterday; } 
    
    public Integer getnumNodes()
    { return numNodes; }

    public void setnumNodes(Integer _numNodes)
    { this.numNodes= _numNodes; } 
    
    public Double [] getvolSpecHeatSoil()
    { return volSpecHeatSoil; }

    public void setvolSpecHeatSoil(Double [] _volSpecHeatSoil)
    { this.volSpecHeatSoil= _volSpecHeatSoil; } 
    
    public Double [] getsand()
    { return sand; }

    public void setsand(Double [] _sand)
    { this.sand= _sand; } 
    
    public Double [] getmorningSoilTemp()
    { return morningSoilTemp; }

    public void setmorningSoilTemp(Double [] _morningSoilTemp)
    { this.morningSoilTemp= _morningSoilTemp; } 
    
    public double getairTemperature()
    { return airTemperature; }

    public void setairTemperature(double _airTemperature)
    { this.airTemperature= _airTemperature; } 
    
    public double getinternalTimeStep()
    { return internalTimeStep; }

    public void setinternalTimeStep(double _internalTimeStep)
    { this.internalTimeStep= _internalTimeStep; } 
    
}