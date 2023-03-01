package net.simplace.sim.components.BiomaSurfacePartonSoilSWATHourlyPartonC;
import  java.io.*;
import  java.util.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import net.simplace.sim.model.FWSimComponent;
import net.simplace.sim.util.FWSimVarMap;
import net.simplace.sim.util.FWSimVariable;
import net.simplace.sim.util.FWSimVariable.CONTENT_TYPE;
import net.simplace.sim.util.FWSimVariable.DATA_TYPE;
import org.jdom2.Element;


public class SurfaceTemperatureParton extends FWSimComponent
{
    private FWSimVariable<Double> DayLength;
    private FWSimVariable<Double> AirTemperatureMinimum;
    private FWSimVariable<Double> GlobalSolarRadiation;
    private FWSimVariable<Double> AirTemperatureMaximum;
    private FWSimVariable<Double> SurfaceTemperatureMaximum;
    private FWSimVariable<Double> SurfaceTemperatureMinimum;
    private FWSimVariable<Double> AboveGroundBiomass;
    private FWSimVariable<Double> SurfaceSoilTemperature;

    public SurfaceTemperatureParton(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public SurfaceTemperatureParton(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("DayLength", "Length of the day", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"h", 0, 24, 10, this));
        addVariable(FWSimVariable.createSimVariable("AirTemperatureMinimum", "Minimum daily air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Â°C", -60, 50, 5, this));
        addVariable(FWSimVariable.createSimVariable("GlobalSolarRadiation", "Daily global solar radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Mj m-2 d-1", 0, 50, 15, this));
        addVariable(FWSimVariable.createSimVariable("AirTemperatureMaximum", "Maximum daily air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Â°C", -40, 60, 15, this));
        addVariable(FWSimVariable.createSimVariable("SurfaceTemperatureMaximum", "Maximum surface soil temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Â°C", -60, 60, 25, this));
        addVariable(FWSimVariable.createSimVariable("SurfaceTemperatureMinimum", "Minimum surface soil temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Â°C", -60, 60, 10, this));
        addVariable(FWSimVariable.createSimVariable("AboveGroundBiomass", "Above ground biomass", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"Kg ha-1", 0, 60, 3, this));
        addVariable(FWSimVariable.createSimVariable("SurfaceSoilTemperature", "Average surface soil temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.state,"Â°C", -60, 60, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Double t_DayLength = DayLength.getValue();
        Double t_AirTemperatureMinimum = AirTemperatureMinimum.getValue();
        Double t_GlobalSolarRadiation = GlobalSolarRadiation.getValue();
        Double t_AirTemperatureMaximum = AirTemperatureMaximum.getValue();
        Double t_SurfaceTemperatureMaximum = SurfaceTemperatureMaximum.getValue();
        Double t_SurfaceTemperatureMinimum = SurfaceTemperatureMinimum.getValue();
        Double t_AboveGroundBiomass = AboveGroundBiomass.getValue();
        Double t_SurfaceSoilTemperature;
        Double _AGB;
        Double _AirTMax;
        Double _AirTmin;
        Double _SolarRad;
        _AGB = t_AboveGroundBiomass / 10000;
        _AirTMax = t_AirTemperatureMaximum;
        _AirTmin = t_AirTemperatureMinimum;
        _SolarRad = t_GlobalSolarRadiation;
        if (_AGB > 0.15d)
        {
            t_SurfaceTemperatureMaximum = _AirTMax + ((24 * (1 - Math.exp(-0.038d * _SolarRad)) + (0.35d * _AirTMax)) * (Math.exp(-4.8d * _AGB) - 0.13d));
            t_SurfaceTemperatureMinimum = _AirTmin + (6 * _AGB) - 1.82d;
        }
        else
        {
            t_SurfaceTemperatureMaximum = t_AirTemperatureMaximum;
            t_SurfaceTemperatureMinimum = t_AirTemperatureMinimum;
        }
        t_SurfaceSoilTemperature = 0.41d * t_SurfaceTemperatureMaximum + (0.59d * t_SurfaceTemperatureMinimum);
        if (t_DayLength != (double)(0))
        {
            t_SurfaceSoilTemperature = t_DayLength / 24 * _AirTMax + ((1 - (t_DayLength / 24)) * _AirTmin);
        }
        SurfaceTemperatureMaximum.setValue(t_SurfaceTemperatureMaximum, this);
        SurfaceTemperatureMinimum.setValue(t_SurfaceTemperatureMinimum, this);
        SurfaceSoilTemperature.setValue(t_SurfaceSoilTemperature, this);
    }

    @Override
    protected void init()
    {
    }
    public HashMap<String, FWSimVariable<?>> fillTestVariables(int aParamIndex, TEST_STATE aDefineOrCheck)
    {
        return iFieldMap;
    }

    @Override
    protected FWSimComponent clone(FWSimVarMap aVarMap)
    {
        return new SurfaceTemperatureParton(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}