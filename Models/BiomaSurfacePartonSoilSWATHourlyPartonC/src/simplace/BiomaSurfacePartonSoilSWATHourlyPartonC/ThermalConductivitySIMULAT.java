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


public class ThermalConductivitySIMULAT extends FWSimComponent
{
    private FWSimVariable<Double[]> VolumetricWaterContent;
    private FWSimVariable<Double[]> BulkDensity;
    private FWSimVariable<Double[]> Clay;
    private FWSimVariable<Double[]> ThermalConductivity;

    public ThermalConductivitySIMULAT(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public ThermalConductivitySIMULAT(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("VolumetricWaterContent", "Volumetric soil water content", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"m3 m-3", 0, 0.8, 0.25, this));
        addVariable(FWSimVariable.createSimVariable("BulkDensity", "Bulk density", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"t m-3", 0.9, 1.8, 1.3, this));
        addVariable(FWSimVariable.createSimVariable("Clay", "Clay content of soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"", 0, 100, 0, this));
        addVariable(FWSimVariable.createSimVariable("ThermalConductivity", "Thermal conductivity of soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.out,"W m-1 K-1", 0.025, 8, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Double [] t_VolumetricWaterContent = VolumetricWaterContent.getValue();
        Double [] t_BulkDensity = BulkDensity.getValue();
        Double [] t_Clay = Clay.getValue();
        Double [] t_ThermalConductivity;
        Integer i;
        Double Aterm;
        Double Bterm;
        Double Cterm;
        Double Dterm;
        Double Eterm;
        Aterm = (double)(0);
        Bterm = (double)(0);
        Cterm = (double)(0);
        Dterm = (double)(0);
        Eterm = (double)(4);
        for (i=0 ; i!=t_VolumetricWaterContent.length ; i+=1)
        {
            Aterm = 0.65d - (0.78d * t_BulkDensity[i]) + (0.6d * Math.pow(t_BulkDensity[i], 2));
            Bterm = 1.06d * t_BulkDensity[i] * t_VolumetricWaterContent[i];
            Cterm = 1 + (2.6d * Math.sqrt(t_Clay[i] / 100));
            Dterm = 0.03d + (0.1d * Math.pow(t_BulkDensity[i], 2));
            t_ThermalConductivity[i] = Aterm + (Bterm * t_VolumetricWaterContent[i]) - ((Aterm - Dterm) * Math.pow(Math.exp(-(Cterm * t_VolumetricWaterContent[i])), Eterm));
        }
        ThermalConductivity.setValue(t_ThermalConductivity, this);
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
        return new ThermalConductivitySIMULAT(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}