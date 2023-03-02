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


public class VolumetricHeatCapacityKluitenberg extends FWSimComponent
{
    private FWSimVariable<Double[]> Silt;
    private FWSimVariable<Double[]> OrganicMatter;
    private FWSimVariable<Double[]> Sand;
    private FWSimVariable<Double[]> VolumetricWaterContent;
    private FWSimVariable<Double[]> BulkDensity;
    private FWSimVariable<Double[]> Clay;
    private FWSimVariable<Double[]> HeatCapacity;

    public VolumetricHeatCapacityKluitenberg(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public VolumetricHeatCapacityKluitenberg(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("Silt", "Silt content of soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"%", 0, 100, 20, this));
        addVariable(FWSimVariable.createSimVariable("OrganicMatter", "Organic matter content of soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"%", 0, 20, 1.5, this));
        addVariable(FWSimVariable.createSimVariable("Sand", "Sand content of soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"%", 0, 100, 30, this));
        addVariable(FWSimVariable.createSimVariable("VolumetricWaterContent", "Volumetric soil water content", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"m3 m-3", 0, 0.8, 0.25, this));
        addVariable(FWSimVariable.createSimVariable("BulkDensity", "Bulk density", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"t m-3", 0.9, 1.8, 1.3, this));
        addVariable(FWSimVariable.createSimVariable("Clay", "Clay content of soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"%", 0, 100, 0, this));
        addVariable(FWSimVariable.createSimVariable("HeatCapacity", "Volumetric specific heat of soil", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"MJ m-3 Â°C-1", 0, 300, 20, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Double [] t_Silt = Silt.getValue();
        Double [] t_OrganicMatter = OrganicMatter.getValue();
        Double [] t_Sand = Sand.getValue();
        Double [] t_VolumetricWaterContent = VolumetricWaterContent.getValue();
        Double [] t_BulkDensity = BulkDensity.getValue();
        Double [] t_Clay = Clay.getValue();
        Double [] t_HeatCapacity = HeatCapacity.getValue();
        Integer i;
        Double SandFraction;
        Double SiltFraction;
        Double ClayFraction;
        Double FractionMinerals;
        Double OrganicMatterFraction;
        SandFraction = (double)(0);
        SiltFraction = (double)(0);
        ClayFraction = (double)(0);
        FractionMinerals = (double)(0);
        OrganicMatterFraction = (double)(0);
        for (i=0 ; i!=t_HeatCapacity.length ; i+=1)
        {
            SandFraction = t_Sand[i] / (t_Sand[i] + t_Silt[i] + t_Clay[i] + t_OrganicMatter[i]);
            SiltFraction = t_Silt[i] / (t_Sand[i] + t_Silt[i] + t_Clay[i] + t_OrganicMatter[i]);
            ClayFraction = t_Clay[i] / (t_Sand[i] + t_Silt[i] + t_Clay[i] + t_OrganicMatter[i]);
            FractionMinerals = SandFraction + SiltFraction + ClayFraction;
            OrganicMatterFraction = t_OrganicMatter[i] / (t_Sand[i] + t_Silt[i] + t_Clay[i] + t_OrganicMatter[i]);
            t_HeatCapacity[i] = t_BulkDensity[i] * 0.73d * FractionMinerals + (t_BulkDensity[i] * 1.9d * OrganicMatterFraction) + (4.18d * t_VolumetricWaterContent[i]);
        }
        HeatCapacity.setValue(t_HeatCapacity, this);
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
        return new VolumetricHeatCapacityKluitenberg(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}