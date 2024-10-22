import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class model_SoilTempCampbellState
{
    private double airPressure;
    private Double [] soilTemp;
    private Double [] newTemperature;
    private Double [] minSoilTemp;
    private Double [] maxSoilTemp;
    private Double [] aveSoilTemp;
    private Double [] morningSoilTemp;
    private Double [] thermalCondPar1;
    private Double [] thermalCondPar2;
    private Double [] thermalCondPar3;
    private Double [] thermalCondPar4;
    private Double [] thermalConductivity;
    private Double [] thermalConductance;
    private Double [] heatStorage;
    private Double [] volSpecHeatSoil;
    private double maxTempYesterday;
    private double minTempYesterday;
    private Double [] SLCARB;
    private Double [] SLROCK;
    private Double [] SLSILT;
    private Double [] SLSAND;
    private double _boundaryLayerConductance;
    
    public model_SoilTempCampbellState() { }
    
    public model_SoilTempCampbellState(model_SoilTempCampbellState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            this.airPressure = toCopy.getairPressure();
            soilTemp = new Double[toCopy.getsoilTemp().length];
        for (int i = 0; i < toCopy.getsoilTemp().length; i++)
        {
            soilTemp[i] = toCopy.getsoilTemp()[i];
        }
            newTemperature = new Double[toCopy.getnewTemperature().length];
        for (int i = 0; i < toCopy.getnewTemperature().length; i++)
        {
            newTemperature[i] = toCopy.getnewTemperature()[i];
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
            thermalCondPar1 = new Double[toCopy.getthermalCondPar1().length];
        for (int i = 0; i < toCopy.getthermalCondPar1().length; i++)
        {
            thermalCondPar1[i] = toCopy.getthermalCondPar1()[i];
        }
            thermalCondPar2 = new Double[toCopy.getthermalCondPar2().length];
        for (int i = 0; i < toCopy.getthermalCondPar2().length; i++)
        {
            thermalCondPar2[i] = toCopy.getthermalCondPar2()[i];
        }
            thermalCondPar3 = new Double[toCopy.getthermalCondPar3().length];
        for (int i = 0; i < toCopy.getthermalCondPar3().length; i++)
        {
            thermalCondPar3[i] = toCopy.getthermalCondPar3()[i];
        }
            thermalCondPar4 = new Double[toCopy.getthermalCondPar4().length];
        for (int i = 0; i < toCopy.getthermalCondPar4().length; i++)
        {
            thermalCondPar4[i] = toCopy.getthermalCondPar4()[i];
        }
            thermalConductivity = new Double[toCopy.getthermalConductivity().length];
        for (int i = 0; i < toCopy.getthermalConductivity().length; i++)
        {
            thermalConductivity[i] = toCopy.getthermalConductivity()[i];
        }
            thermalConductance = new Double[toCopy.getthermalConductance().length];
        for (int i = 0; i < toCopy.getthermalConductance().length; i++)
        {
            thermalConductance[i] = toCopy.getthermalConductance()[i];
        }
            heatStorage = new Double[toCopy.getheatStorage().length];
        for (int i = 0; i < toCopy.getheatStorage().length; i++)
        {
            heatStorage[i] = toCopy.getheatStorage()[i];
        }
            volSpecHeatSoil = new Double[toCopy.getvolSpecHeatSoil().length];
        for (int i = 0; i < toCopy.getvolSpecHeatSoil().length; i++)
        {
            volSpecHeatSoil[i] = toCopy.getvolSpecHeatSoil()[i];
        }
            this.maxTempYesterday = toCopy.getmaxTempYesterday();
            this.minTempYesterday = toCopy.getminTempYesterday();
            SLCARB = new Double[toCopy.getSLCARB().length];
        for (int i = 0; i < toCopy.getSLCARB().length; i++)
        {
            SLCARB[i] = toCopy.getSLCARB()[i];
        }
            SLROCK = new Double[toCopy.getSLROCK().length];
        for (int i = 0; i < toCopy.getSLROCK().length; i++)
        {
            SLROCK[i] = toCopy.getSLROCK()[i];
        }
            SLSILT = new Double[toCopy.getSLSILT().length];
        for (int i = 0; i < toCopy.getSLSILT().length; i++)
        {
            SLSILT[i] = toCopy.getSLSILT()[i];
        }
            SLSAND = new Double[toCopy.getSLSAND().length];
        for (int i = 0; i < toCopy.getSLSAND().length; i++)
        {
            SLSAND[i] = toCopy.getSLSAND()[i];
        }
            this._boundaryLayerConductance = toCopy.get_boundaryLayerConductance();
        }
    }
    public double getairPressure()
    { return airPressure; }

    public void setairPressure(double _airPressure)
    { this.airPressure= _airPressure; } 
    
    public Double [] getsoilTemp()
    { return soilTemp; }

    public void setsoilTemp(Double [] _soilTemp)
    { this.soilTemp= _soilTemp; } 
    
    public Double [] getnewTemperature()
    { return newTemperature; }

    public void setnewTemperature(Double [] _newTemperature)
    { this.newTemperature= _newTemperature; } 
    
    public Double [] getminSoilTemp()
    { return minSoilTemp; }

    public void setminSoilTemp(Double [] _minSoilTemp)
    { this.minSoilTemp= _minSoilTemp; } 
    
    public Double [] getmaxSoilTemp()
    { return maxSoilTemp; }

    public void setmaxSoilTemp(Double [] _maxSoilTemp)
    { this.maxSoilTemp= _maxSoilTemp; } 
    
    public Double [] getaveSoilTemp()
    { return aveSoilTemp; }

    public void setaveSoilTemp(Double [] _aveSoilTemp)
    { this.aveSoilTemp= _aveSoilTemp; } 
    
    public Double [] getmorningSoilTemp()
    { return morningSoilTemp; }

    public void setmorningSoilTemp(Double [] _morningSoilTemp)
    { this.morningSoilTemp= _morningSoilTemp; } 
    
    public Double [] getthermalCondPar1()
    { return thermalCondPar1; }

    public void setthermalCondPar1(Double [] _thermalCondPar1)
    { this.thermalCondPar1= _thermalCondPar1; } 
    
    public Double [] getthermalCondPar2()
    { return thermalCondPar2; }

    public void setthermalCondPar2(Double [] _thermalCondPar2)
    { this.thermalCondPar2= _thermalCondPar2; } 
    
    public Double [] getthermalCondPar3()
    { return thermalCondPar3; }

    public void setthermalCondPar3(Double [] _thermalCondPar3)
    { this.thermalCondPar3= _thermalCondPar3; } 
    
    public Double [] getthermalCondPar4()
    { return thermalCondPar4; }

    public void setthermalCondPar4(Double [] _thermalCondPar4)
    { this.thermalCondPar4= _thermalCondPar4; } 
    
    public Double [] getthermalConductivity()
    { return thermalConductivity; }

    public void setthermalConductivity(Double [] _thermalConductivity)
    { this.thermalConductivity= _thermalConductivity; } 
    
    public Double [] getthermalConductance()
    { return thermalConductance; }

    public void setthermalConductance(Double [] _thermalConductance)
    { this.thermalConductance= _thermalConductance; } 
    
    public Double [] getheatStorage()
    { return heatStorage; }

    public void setheatStorage(Double [] _heatStorage)
    { this.heatStorage= _heatStorage; } 
    
    public Double [] getvolSpecHeatSoil()
    { return volSpecHeatSoil; }

    public void setvolSpecHeatSoil(Double [] _volSpecHeatSoil)
    { this.volSpecHeatSoil= _volSpecHeatSoil; } 
    
    public double getmaxTempYesterday()
    { return maxTempYesterday; }

    public void setmaxTempYesterday(double _maxTempYesterday)
    { this.maxTempYesterday= _maxTempYesterday; } 
    
    public double getminTempYesterday()
    { return minTempYesterday; }

    public void setminTempYesterday(double _minTempYesterday)
    { this.minTempYesterday= _minTempYesterday; } 
    
    public Double [] getSLCARB()
    { return SLCARB; }

    public void setSLCARB(Double [] _SLCARB)
    { this.SLCARB= _SLCARB; } 
    
    public Double [] getSLROCK()
    { return SLROCK; }

    public void setSLROCK(Double [] _SLROCK)
    { this.SLROCK= _SLROCK; } 
    
    public Double [] getSLSILT()
    { return SLSILT; }

    public void setSLSILT(Double [] _SLSILT)
    { this.SLSILT= _SLSILT; } 
    
    public Double [] getSLSAND()
    { return SLSAND; }

    public void setSLSAND(Double [] _SLSAND)
    { this.SLSAND= _SLSAND; } 
    
    public double get_boundaryLayerConductance()
    { return _boundaryLayerConductance; }

    public void set_boundaryLayerConductance(double __boundaryLayerConductance)
    { this._boundaryLayerConductance= __boundaryLayerConductance; } 
    
}