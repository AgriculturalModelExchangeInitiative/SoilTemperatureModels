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


public class RangeOfSoilTemperaturesDAYCENT extends FWSimComponent
{
    private FWSimVariable<Double[]> LayerThickness;
    private FWSimVariable<Double> SurfaceTemperatureMinimum;
    private FWSimVariable<Double[]> ThermalDiffusivity;
    private FWSimVariable<Double[]> SoilTemperatureByLayers;
    private FWSimVariable<Double> SurfaceTemperatureMaximum;
    private FWSimVariable<Double[]> SoilTemperatureRangeByLayers;
    private FWSimVariable<Double[]> SoilTemperatureMinimum;
    private FWSimVariable<Double[]> SoilTemperatureMaximum;

    public RangeOfSoilTemperaturesDAYCENT(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public RangeOfSoilTemperaturesDAYCENT(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("LayerThickness", "Soil layer thickness", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"m", 0.005, 3, 0.05, this));
        addVariable(FWSimVariable.createSimVariable("SurfaceTemperatureMinimum", "Minimum surface soil temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", -60, 60, 10, this));
        addVariable(FWSimVariable.createSimVariable("ThermalDiffusivity", "Thermal diffusivity of soil layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"mm s-1", 0, 1, 0.0025, this));
        addVariable(FWSimVariable.createSimVariable("SoilTemperatureByLayers", "Soil temperature of each layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"degC", -60, 60, 15, this));
        addVariable(FWSimVariable.createSimVariable("SurfaceTemperatureMaximum", "Maximum surface soil temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", -60, 60, 25, this));
        addVariable(FWSimVariable.createSimVariable("SoilTemperatureRangeByLayers", "Soil temperature range by layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.out,"degC", 0, 50, null, this));
        addVariable(FWSimVariable.createSimVariable("SoilTemperatureMinimum", "Minimum soil temperature by layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.out,"", -60, 60, null, this));
        addVariable(FWSimVariable.createSimVariable("SoilTemperatureMaximum", "Maximum soil temperature by layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.out,"degC", -60, 60, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Double [] t_LayerThickness = LayerThickness.getValue();
        Double t_SurfaceTemperatureMinimum = SurfaceTemperatureMinimum.getValue();
        Double [] t_ThermalDiffusivity = ThermalDiffusivity.getValue();
        Double [] t_SoilTemperatureByLayers = SoilTemperatureByLayers.getValue();
        Double t_SurfaceTemperatureMaximum = SurfaceTemperatureMaximum.getValue();
        Double [] t_SoilTemperatureRangeByLayers;
        Double [] t_SoilTemperatureMinimum;
        Double [] t_SoilTemperatureMaximum;
        Integer i;
        Double _DepthBottom;
        Double _DepthCenterLayer;
        Double SurfaceDiurnalRange;
        _DepthBottom = (double)(0);
        _DepthCenterLayer = (double)(0);
        SurfaceDiurnalRange = t_SurfaceTemperatureMaximum - t_SurfaceTemperatureMinimum;
        for (i=0 ; i!=t_SoilTemperatureByLayers.length ; i+=1)
        {
            if (i == 0)
            {
                _DepthCenterLayer = t_LayerThickness[0] * 100 / 2;
                t_SoilTemperatureRangeByLayers[0] = SurfaceDiurnalRange * Math.exp(-_DepthCenterLayer * Math.pow(0.00005d / t_ThermalDiffusivity[0], 0.5d));
                t_SoilTemperatureMaximum[0] = t_SoilTemperatureByLayers[0] + (t_SoilTemperatureRangeByLayers[0] / 2);
                t_SoilTemperatureMinimum[0] = t_SoilTemperatureByLayers[0] - (t_SoilTemperatureRangeByLayers[0] / 2);
            }
            else
            {
                _DepthBottom = _DepthBottom + (t_LayerThickness[(i - 1)] * 100);
                _DepthCenterLayer = _DepthBottom + (t_LayerThickness[i] * 100 / 2);
                t_SoilTemperatureRangeByLayers[i] = SurfaceDiurnalRange * Math.exp(-_DepthCenterLayer * Math.pow(0.00005d / t_ThermalDiffusivity[i], 0.5d));
                t_SoilTemperatureMaximum[i] = t_SoilTemperatureByLayers[i] + (t_SoilTemperatureRangeByLayers[i] / 2);
                t_SoilTemperatureMinimum[i] = t_SoilTemperatureByLayers[i] - (t_SoilTemperatureRangeByLayers[i] / 2);
            }
        }
        SoilTemperatureRangeByLayers.setValue(t_SoilTemperatureRangeByLayers, this);
        SoilTemperatureMinimum.setValue(t_SoilTemperatureMinimum, this);
        SoilTemperatureMaximum.setValue(t_SoilTemperatureMaximum, this);
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
        return new RangeOfSoilTemperaturesDAYCENT(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}