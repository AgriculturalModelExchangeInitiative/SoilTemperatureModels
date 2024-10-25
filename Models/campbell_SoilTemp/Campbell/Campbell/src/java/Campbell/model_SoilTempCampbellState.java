import  java.io.*;
import  java.util.*;
import java.time.LocalDateTime;
public class Model_SoilTempCampbellState
{
    private List<Double> THICKApsim;
    private List<Double> DEPTHApsim;
    private List<Double> BDApsim;
    private List<Double> CLAYApsim;
    private List<Double> SWApsim;
    private List<Double> soilTemp;
    private List<Double> newTemperature;
    private List<Double> minSoilTemp;
    private List<Double> maxSoilTemp;
    private List<Double> aveSoilTemp;
    private List<Double> morningSoilTemp;
    private List<Double> thermalCondPar1;
    private List<Double> thermalCondPar2;
    private List<Double> thermalCondPar3;
    private List<Double> thermalCondPar4;
    private List<Double> thermalConductivity;
    private List<Double> thermalConductance;
    private List<Double> heatStorage;
    private List<Double> volSpecHeatSoil;
    private double maxTempYesterday;
    private double minTempYesterday;
    private List<Double> SLCARBApsim;
    private List<Double> SLROCKApsim;
    private List<Double> SLSILTApsim;
    private List<Double> SLSANDApsim;
    private double _boundaryLayerConductance;
    
    public Model_SoilTempCampbellState() { }
    
    public Model_SoilTempCampbellState(Model_SoilTempCampbellState toCopy, boolean copyAll) // copy constructor 
    {
        if (copyAll)
        {
            List <Double> _THICKApsim = new ArrayList<>();
            for (Double c : toCopy.getTHICKApsim())
            {
                _THICKApsim.add(c);
            }
            this.THICKApsim = _THICKApsim;
            List <Double> _DEPTHApsim = new ArrayList<>();
            for (Double c : toCopy.getDEPTHApsim())
            {
                _DEPTHApsim.add(c);
            }
            this.DEPTHApsim = _DEPTHApsim;
            List <Double> _BDApsim = new ArrayList<>();
            for (Double c : toCopy.getBDApsim())
            {
                _BDApsim.add(c);
            }
            this.BDApsim = _BDApsim;
            List <Double> _CLAYApsim = new ArrayList<>();
            for (Double c : toCopy.getCLAYApsim())
            {
                _CLAYApsim.add(c);
            }
            this.CLAYApsim = _CLAYApsim;
            List <Double> _SWApsim = new ArrayList<>();
            for (Double c : toCopy.getSWApsim())
            {
                _SWApsim.add(c);
            }
            this.SWApsim = _SWApsim;
            List <Double> _soilTemp = new ArrayList<>();
            for (Double c : toCopy.getsoilTemp())
            {
                _soilTemp.add(c);
            }
            this.soilTemp = _soilTemp;
            List <Double> _newTemperature = new ArrayList<>();
            for (Double c : toCopy.getnewTemperature())
            {
                _newTemperature.add(c);
            }
            this.newTemperature = _newTemperature;
            List <Double> _minSoilTemp = new ArrayList<>();
            for (Double c : toCopy.getminSoilTemp())
            {
                _minSoilTemp.add(c);
            }
            this.minSoilTemp = _minSoilTemp;
            List <Double> _maxSoilTemp = new ArrayList<>();
            for (Double c : toCopy.getmaxSoilTemp())
            {
                _maxSoilTemp.add(c);
            }
            this.maxSoilTemp = _maxSoilTemp;
            List <Double> _aveSoilTemp = new ArrayList<>();
            for (Double c : toCopy.getaveSoilTemp())
            {
                _aveSoilTemp.add(c);
            }
            this.aveSoilTemp = _aveSoilTemp;
            List <Double> _morningSoilTemp = new ArrayList<>();
            for (Double c : toCopy.getmorningSoilTemp())
            {
                _morningSoilTemp.add(c);
            }
            this.morningSoilTemp = _morningSoilTemp;
            List <Double> _thermalCondPar1 = new ArrayList<>();
            for (Double c : toCopy.getthermalCondPar1())
            {
                _thermalCondPar1.add(c);
            }
            this.thermalCondPar1 = _thermalCondPar1;
            List <Double> _thermalCondPar2 = new ArrayList<>();
            for (Double c : toCopy.getthermalCondPar2())
            {
                _thermalCondPar2.add(c);
            }
            this.thermalCondPar2 = _thermalCondPar2;
            List <Double> _thermalCondPar3 = new ArrayList<>();
            for (Double c : toCopy.getthermalCondPar3())
            {
                _thermalCondPar3.add(c);
            }
            this.thermalCondPar3 = _thermalCondPar3;
            List <Double> _thermalCondPar4 = new ArrayList<>();
            for (Double c : toCopy.getthermalCondPar4())
            {
                _thermalCondPar4.add(c);
            }
            this.thermalCondPar4 = _thermalCondPar4;
            List <Double> _thermalConductivity = new ArrayList<>();
            for (Double c : toCopy.getthermalConductivity())
            {
                _thermalConductivity.add(c);
            }
            this.thermalConductivity = _thermalConductivity;
            List <Double> _thermalConductance = new ArrayList<>();
            for (Double c : toCopy.getthermalConductance())
            {
                _thermalConductance.add(c);
            }
            this.thermalConductance = _thermalConductance;
            List <Double> _heatStorage = new ArrayList<>();
            for (Double c : toCopy.getheatStorage())
            {
                _heatStorage.add(c);
            }
            this.heatStorage = _heatStorage;
            List <Double> _volSpecHeatSoil = new ArrayList<>();
            for (Double c : toCopy.getvolSpecHeatSoil())
            {
                _volSpecHeatSoil.add(c);
            }
            this.volSpecHeatSoil = _volSpecHeatSoil;
            this.maxTempYesterday = toCopy.getmaxTempYesterday();
            this.minTempYesterday = toCopy.getminTempYesterday();
            List <Double> _SLCARBApsim = new ArrayList<>();
            for (Double c : toCopy.getSLCARBApsim())
            {
                _SLCARBApsim.add(c);
            }
            this.SLCARBApsim = _SLCARBApsim;
            List <Double> _SLROCKApsim = new ArrayList<>();
            for (Double c : toCopy.getSLROCKApsim())
            {
                _SLROCKApsim.add(c);
            }
            this.SLROCKApsim = _SLROCKApsim;
            List <Double> _SLSILTApsim = new ArrayList<>();
            for (Double c : toCopy.getSLSILTApsim())
            {
                _SLSILTApsim.add(c);
            }
            this.SLSILTApsim = _SLSILTApsim;
            List <Double> _SLSANDApsim = new ArrayList<>();
            for (Double c : toCopy.getSLSANDApsim())
            {
                _SLSANDApsim.add(c);
            }
            this.SLSANDApsim = _SLSANDApsim;
            this._boundaryLayerConductance = toCopy.get_boundaryLayerConductance();
        }
    }
    public List<Double> getTHICKApsim()
    { return THICKApsim; }

    public void setTHICKApsim(List<Double> _THICKApsim)
    { this.THICKApsim= _THICKApsim; } 
    
    public List<Double> getDEPTHApsim()
    { return DEPTHApsim; }

    public void setDEPTHApsim(List<Double> _DEPTHApsim)
    { this.DEPTHApsim= _DEPTHApsim; } 
    
    public List<Double> getBDApsim()
    { return BDApsim; }

    public void setBDApsim(List<Double> _BDApsim)
    { this.BDApsim= _BDApsim; } 
    
    public List<Double> getCLAYApsim()
    { return CLAYApsim; }

    public void setCLAYApsim(List<Double> _CLAYApsim)
    { this.CLAYApsim= _CLAYApsim; } 
    
    public List<Double> getSWApsim()
    { return SWApsim; }

    public void setSWApsim(List<Double> _SWApsim)
    { this.SWApsim= _SWApsim; } 
    
    public List<Double> getsoilTemp()
    { return soilTemp; }

    public void setsoilTemp(List<Double> _soilTemp)
    { this.soilTemp= _soilTemp; } 
    
    public List<Double> getnewTemperature()
    { return newTemperature; }

    public void setnewTemperature(List<Double> _newTemperature)
    { this.newTemperature= _newTemperature; } 
    
    public List<Double> getminSoilTemp()
    { return minSoilTemp; }

    public void setminSoilTemp(List<Double> _minSoilTemp)
    { this.minSoilTemp= _minSoilTemp; } 
    
    public List<Double> getmaxSoilTemp()
    { return maxSoilTemp; }

    public void setmaxSoilTemp(List<Double> _maxSoilTemp)
    { this.maxSoilTemp= _maxSoilTemp; } 
    
    public List<Double> getaveSoilTemp()
    { return aveSoilTemp; }

    public void setaveSoilTemp(List<Double> _aveSoilTemp)
    { this.aveSoilTemp= _aveSoilTemp; } 
    
    public List<Double> getmorningSoilTemp()
    { return morningSoilTemp; }

    public void setmorningSoilTemp(List<Double> _morningSoilTemp)
    { this.morningSoilTemp= _morningSoilTemp; } 
    
    public List<Double> getthermalCondPar1()
    { return thermalCondPar1; }

    public void setthermalCondPar1(List<Double> _thermalCondPar1)
    { this.thermalCondPar1= _thermalCondPar1; } 
    
    public List<Double> getthermalCondPar2()
    { return thermalCondPar2; }

    public void setthermalCondPar2(List<Double> _thermalCondPar2)
    { this.thermalCondPar2= _thermalCondPar2; } 
    
    public List<Double> getthermalCondPar3()
    { return thermalCondPar3; }

    public void setthermalCondPar3(List<Double> _thermalCondPar3)
    { this.thermalCondPar3= _thermalCondPar3; } 
    
    public List<Double> getthermalCondPar4()
    { return thermalCondPar4; }

    public void setthermalCondPar4(List<Double> _thermalCondPar4)
    { this.thermalCondPar4= _thermalCondPar4; } 
    
    public List<Double> getthermalConductivity()
    { return thermalConductivity; }

    public void setthermalConductivity(List<Double> _thermalConductivity)
    { this.thermalConductivity= _thermalConductivity; } 
    
    public List<Double> getthermalConductance()
    { return thermalConductance; }

    public void setthermalConductance(List<Double> _thermalConductance)
    { this.thermalConductance= _thermalConductance; } 
    
    public List<Double> getheatStorage()
    { return heatStorage; }

    public void setheatStorage(List<Double> _heatStorage)
    { this.heatStorage= _heatStorage; } 
    
    public List<Double> getvolSpecHeatSoil()
    { return volSpecHeatSoil; }

    public void setvolSpecHeatSoil(List<Double> _volSpecHeatSoil)
    { this.volSpecHeatSoil= _volSpecHeatSoil; } 
    
    public double getmaxTempYesterday()
    { return maxTempYesterday; }

    public void setmaxTempYesterday(double _maxTempYesterday)
    { this.maxTempYesterday= _maxTempYesterday; } 
    
    public double getminTempYesterday()
    { return minTempYesterday; }

    public void setminTempYesterday(double _minTempYesterday)
    { this.minTempYesterday= _minTempYesterday; } 
    
    public List<Double> getSLCARBApsim()
    { return SLCARBApsim; }

    public void setSLCARBApsim(List<Double> _SLCARBApsim)
    { this.SLCARBApsim= _SLCARBApsim; } 
    
    public List<Double> getSLROCKApsim()
    { return SLROCKApsim; }

    public void setSLROCKApsim(List<Double> _SLROCKApsim)
    { this.SLROCKApsim= _SLROCKApsim; } 
    
    public List<Double> getSLSILTApsim()
    { return SLSILTApsim; }

    public void setSLSILTApsim(List<Double> _SLSILTApsim)
    { this.SLSILTApsim= _SLSILTApsim; } 
    
    public List<Double> getSLSANDApsim()
    { return SLSANDApsim; }

    public void setSLSANDApsim(List<Double> _SLSANDApsim)
    { this.SLSANDApsim= _SLSANDApsim; } 
    
    public double get_boundaryLayerConductance()
    { return _boundaryLayerConductance; }

    public void set_boundaryLayerConductance(double __boundaryLayerConductance)
    { this._boundaryLayerConductance= __boundaryLayerConductance; } 
    
}