package net.simplace.sim.components.BiomaSurfaceSWATSoilSWATC;
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


public class SurfaceTemperatureSWAT extends FWSimComponent
{
    private FWSimVariable<Double> GlobalSolarRadiation;
    private FWSimVariable<Double[]> SoilTemperatureByLayers;
    private FWSimVariable<Double> AirTemperatureMaximum;
    private FWSimVariable<Double> AirTemperatureMinimum;
    private FWSimVariable<Double> Albedo;
    private FWSimVariable<Double> AboveGroundBiomass;
    private FWSimVariable<Double> WaterEquivalentOfSnowPack;
    private FWSimVariable<Double> SurfaceSoilTemperature;

    public SurfaceTemperatureSWAT(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public SurfaceTemperatureSWAT(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("GlobalSolarRadiation", "Daily global solar radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Mj m-2 d-1", 0, 50, 15, this));
        addVariable(FWSimVariable.createSimVariable("SoilTemperatureByLayers", "Soil temperature of each layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"", -60, 60, 15, this));
        addVariable(FWSimVariable.createSimVariable("AirTemperatureMaximum", "Maximum daily air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"", -40, 60, 15, this));
        addVariable(FWSimVariable.createSimVariable("AirTemperatureMinimum", "Minimum daily air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"", -60, 50, 5, this));
        addVariable(FWSimVariable.createSimVariable("Albedo", "Albedo of soil", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"unitless", 0, 1, 0.2, this));
        addVariable(FWSimVariable.createSimVariable("AboveGroundBiomass", "Above ground biomass", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Kg ha-1", 0, 60, 3, this));
        addVariable(FWSimVariable.createSimVariable("WaterEquivalentOfSnowPack", "Water equivalent of snow pack", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", 0, 1000, 10, this));
        addVariable(FWSimVariable.createSimVariable("SurfaceSoilTemperature", "Average surface soil temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"degC", -60, 60, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Double t_GlobalSolarRadiation = GlobalSolarRadiation.getValue();
        Double [] t_SoilTemperatureByLayers = SoilTemperatureByLayers.getValue();
        Double t_AirTemperatureMaximum = AirTemperatureMaximum.getValue();
        Double t_AirTemperatureMinimum = AirTemperatureMinimum.getValue();
        Double t_Albedo = Albedo.getValue();
        Double t_AboveGroundBiomass = AboveGroundBiomass.getValue();
        Double t_WaterEquivalentOfSnowPack = WaterEquivalentOfSnowPack.getValue();
        Double t_SurfaceSoilTemperature;
        Double _Tavg;
        Double _Hterm;
        Double _Tbare;
        Double _WeightingCover;
        Double _WeightingSnow;
        Double _WeightingActual;
        _Tavg = (t_AirTemperatureMaximum + t_AirTemperatureMinimum) / 2;
        _Hterm = (t_GlobalSolarRadiation * (1 - t_Albedo) - 14) / 20;
        _Tbare = _Tavg + (_Hterm * (t_AirTemperatureMaximum - t_AirTemperatureMinimum) / 2);
        _WeightingCover = t_AboveGroundBiomass / (t_AboveGroundBiomass + Math.exp(7.563d - (0.0001297d * t_AboveGroundBiomass)));
        _WeightingSnow = t_WaterEquivalentOfSnowPack / (t_WaterEquivalentOfSnowPack + Math.exp(6.055d - (0.3002d * t_WaterEquivalentOfSnowPack)));
        _WeightingActual = Math.max(_WeightingCover, _WeightingSnow);
        t_SurfaceSoilTemperature = _WeightingActual * t_SoilTemperatureByLayers[0] + ((1 - _WeightingActual) * _Tbare);
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
        return new SurfaceTemperatureSWAT(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}