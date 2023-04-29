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


public class ThermalDiffu extends FWSimComponent
{
    private FWSimVariable<Double[]> ThermalDiffusivity;
    private FWSimVariable<Double[]> ThermalConductivity;
    private FWSimVariable<Double[]> HeatCapacity;

    public ThermalDiffu(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public ThermalDiffu(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("ThermalDiffusivity", "Thermal diffusivity of soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"mm s-1", 0, 1, 0.0025, this));
        addVariable(FWSimVariable.createSimVariable("ThermalConductivity", "Thermal conductivity of soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"W m-1 K-1", 0.025, 8, 1, this));
        addVariable(FWSimVariable.createSimVariable("HeatCapacity", "Volumetric specific heat of soil", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"MJ m-3 Â°C-1", 0, 300, 20, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Double [] t_ThermalDiffusivity = ThermalDiffusivity.getValue();
        Double [] t_ThermalConductivity = ThermalConductivity.getValue();
        Double [] t_HeatCapacity = HeatCapacity.getValue();
        Integer i;
        for (i=0 ; i!=t_ThermalDiffusivity.length ; i+=1)
        {
            t_ThermalDiffusivity[i] = t_ThermalConductivity[i] / t_HeatCapacity[i] / 100;
        }
        ThermalDiffusivity.setValue(t_ThermalDiffusivity, this);
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
        return new ThermalDiffu(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}