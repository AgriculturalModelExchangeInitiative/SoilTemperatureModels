package net.simplace.usermodules.amei.Bioma;
import java.util.HashMap;

import org.jdom2.Element;

import net.simplace.sim.model.FWSimComponent;
import net.simplace.sim.util.FWSimVarMap;
import net.simplace.sim.util.FWSimVariable;
import net.simplace.sim.util.FWSimVariable.CONTENT_TYPE;
import net.simplace.sim.util.FWSimVariable.DATA_TYPE;


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
        addVariable(FWSimVariable.createSimVariable("GlobalSolarRadiation", "Daily global solar radiation", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Mj m-2 d-1", 0, 50, 15d, this));
        addVariable(FWSimVariable.createSimVariable("SoilTemperatureByLayers", "Soil temperature of each layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"", -60, 60, null, this));
        addVariable(FWSimVariable.createSimVariable("AirTemperatureMaximum", "Maximum daily air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"", -40, 60, 15d, this));
        addVariable(FWSimVariable.createSimVariable("AirTemperatureMinimum", "Minimum daily air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"", -60, 50, 5d, this));
        addVariable(FWSimVariable.createSimVariable("Albedo", "Albedo of soil", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"unitless", 0, 1, 0.2, this));
        addVariable(FWSimVariable.createSimVariable("AboveGroundBiomass", "Above ground biomass", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"Kg ha-1", 0, 60, 3d, this));
        addVariable(FWSimVariable.createSimVariable("WaterEquivalentOfSnowPack", "Water equivalent of snow pack", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"mm", 0, 1000, 10d, this));
        addVariable(FWSimVariable.createSimVariable("SurfaceSoilTemperature", "Average surface soil temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.out,"degC", -60, 60, null, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        double t_GlobalSolarRadiation = GlobalSolarRadiation.getValue();
        Double [] t_SoilTemperatureByLayers = SoilTemperatureByLayers.getValue();
        double t_AirTemperatureMaximum = AirTemperatureMaximum.getValue();
        double t_AirTemperatureMinimum = AirTemperatureMinimum.getValue();
        double t_Albedo = Albedo.getValue();
        double t_AboveGroundBiomass = AboveGroundBiomass.getValue();
        double t_WaterEquivalentOfSnowPack = WaterEquivalentOfSnowPack.getValue();
        double t_SurfaceSoilTemperature;
        double _Tavg;
        double _Hterm;
        double _Tbare;
        double _WeightingCover;
        double _WeightingSnow;
        double _WeightingActual;
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