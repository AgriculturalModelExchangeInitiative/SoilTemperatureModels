package net.simplace.usermodules.amei.Bioma;
import  java.util.*;
import net.simplace.sim.model.FWSimComponent;
import net.simplace.sim.util.FWSimVarMap;
import net.simplace.sim.util.FWSimVariable;
import net.simplace.sim.util.FWSimVariable.CONTENT_TYPE;
import net.simplace.sim.util.FWSimVariable.DATA_TYPE;
import org.jdom2.Element;


public class SoilTemperatureSWAT extends FWSimComponent
{
    private FWSimVariable<Double[]> VolumetricWaterContent;
    private FWSimVariable<Double> SurfaceSoilTemperature;
    private FWSimVariable<Double[]> LayerThickness;
    private FWSimVariable<Double> LagCoefficient;
    private FWSimVariable<Double[]> SoilTemperatureByLayers;
    private FWSimVariable<Double> AirTemperatureAnnualAverage;
    private FWSimVariable<Double[]> BulkDensity;
    private FWSimVariable<Double> SoilProfileDepth;

    public SoilTemperatureSWAT(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public SoilTemperatureSWAT(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("VolumetricWaterContent", "Volumetric soil water content", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"m3 m-3", 0, 0.8, null, this));
        addVariable(FWSimVariable.createSimVariable("SurfaceSoilTemperature", "Average surface soil temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"degC", -60d, 60d, 25d, this));
        addVariable(FWSimVariable.createSimVariable("LayerThickness", "Soil layer thickness", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"m", 0.005, 3d, null, this));
        addVariable(FWSimVariable.createSimVariable("LagCoefficient", "Lag coefficient that controls the influence of the previous day's temperature on the current day's temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"dimensionless", 0, 1, 0.8, this));
        addVariable(FWSimVariable.createSimVariable("SoilTemperatureByLayers", "Soil temperature of each layer", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", -60, 60, null, this));
        addVariable(FWSimVariable.createSimVariable("AirTemperatureAnnualAverage", "Annual average air temperature", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"degC", -40d, 50d, 15d, this));
        addVariable(FWSimVariable.createSimVariable("BulkDensity", "Bulk density", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.constant,"t m-3", 0.9, 1.8, null, this));
        addVariable(FWSimVariable.createSimVariable("SoilProfileDepth", "Soil profile depth", DATA_TYPE.DOUBLE, CONTENT_TYPE.constant,"m", 0, 50d, 3d, this));

        return iFieldMap;
    }
    @Override
    protected void init()
    {
        Double [] t_VolumetricWaterContent = VolumetricWaterContent.getValue();
        Double [] t_LayerThickness = LayerThickness.getValue();
        double t_LagCoefficient = LagCoefficient.getValue();
        double t_AirTemperatureAnnualAverage = AirTemperatureAnnualAverage.getValue();
        Double [] t_BulkDensity = BulkDensity.getValue();
        double t_SoilProfileDepth = SoilProfileDepth.getValue();
        Double [] t_SoilTemperatureByLayers = new Double[t_LayerThickness.length];
        Integer i;
        Arrays.fill(t_SoilTemperatureByLayers, 0.0d);
        for (i=0 ; i!=t_LayerThickness.length ; i+=1)
        {
            t_SoilTemperatureByLayers[i] = (double)(15);
        }
        SoilTemperatureByLayers.setValue(t_SoilTemperatureByLayers, this);
    }
    @Override
    protected void process()
    {
        Double [] t_VolumetricWaterContent = VolumetricWaterContent.getValue();
        double t_SurfaceSoilTemperature = SurfaceSoilTemperature.getValue();
        Double [] t_LayerThickness = LayerThickness.getValue();
        double t_LagCoefficient = LagCoefficient.getValue();
        Double [] t_SoilTemperatureByLayers = SoilTemperatureByLayers.getValue();
        double t_AirTemperatureAnnualAverage = AirTemperatureAnnualAverage.getValue();
        Double [] t_BulkDensity = BulkDensity.getValue();
        double t_SoilProfileDepth = SoilProfileDepth.getValue();
        Integer i;
        double _SoilProfileDepthmm;
        double _TotalWaterContentmm;
        double _MaximumDumpingDepth;
        double _DumpingDepth;
        double _ScalingFactor;
        double _DepthBottom;
        double _RatioCenter;
        double _DepthFactor;
        double _DepthCenterLayer;
        _SoilProfileDepthmm = t_SoilProfileDepth * 1000;
        _TotalWaterContentmm = (double)(0);
        for (i=0 ; i!=t_LayerThickness.length ; i+=1)
        {
            _TotalWaterContentmm = _TotalWaterContentmm + (t_VolumetricWaterContent[i] * t_LayerThickness[i]);
        }
        _TotalWaterContentmm = _TotalWaterContentmm * 1000;
        _MaximumDumpingDepth = (double)(0);
        _DumpingDepth = (double)(0);
        _ScalingFactor = (double)(0);
        _DepthBottom = (double)(0);
        _RatioCenter = (double)(0);
        _DepthFactor = (double)(0);
        _DepthCenterLayer = t_LayerThickness[0] * 1000 / 2;
        _MaximumDumpingDepth = 1000 + (2500 * t_BulkDensity[0] / (t_BulkDensity[0] + (686 * Math.exp(-5.63d * t_BulkDensity[0]))));
        _ScalingFactor = _TotalWaterContentmm / ((0.356d - (0.144d * t_BulkDensity[0])) * _SoilProfileDepthmm);
        _DumpingDepth = _MaximumDumpingDepth * Math.exp(Math.log(500 / _MaximumDumpingDepth) * Math.pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2));
        _RatioCenter = _DepthCenterLayer / _DumpingDepth;
        _DepthFactor = _RatioCenter / (_RatioCenter + Math.exp(-0.867d - (2.078d * _RatioCenter)));
        t_SoilTemperatureByLayers[0] = t_LagCoefficient * t_SoilTemperatureByLayers[0] + ((1 - t_LagCoefficient) * (_DepthFactor * (t_AirTemperatureAnnualAverage - t_SurfaceSoilTemperature) + t_SurfaceSoilTemperature));
        for (i=1 ; i!=t_LayerThickness.length ; i+=1)
        {
            _DepthBottom = _DepthBottom + (t_LayerThickness[(i - 1)] * 1000);
            _DepthCenterLayer = _DepthBottom + (t_LayerThickness[i] * 1000 / 2);
            _MaximumDumpingDepth = 1000 + (2500 * t_BulkDensity[i] / (t_BulkDensity[i] + (686 * Math.exp(-5.63d * t_BulkDensity[i]))));
            _ScalingFactor = _TotalWaterContentmm / ((0.356d - (0.144d * t_BulkDensity[i])) * _SoilProfileDepthmm);
            _DumpingDepth = _MaximumDumpingDepth * Math.exp(Math.log(500 / _MaximumDumpingDepth) * Math.pow((1 - _ScalingFactor) / (1 + _ScalingFactor), 2));
            _RatioCenter = _DepthCenterLayer / _DumpingDepth;
            _DepthFactor = _RatioCenter / (_RatioCenter + Math.exp(-0.867d - (2.078d * _RatioCenter)));
            t_SoilTemperatureByLayers[i] = t_LagCoefficient * t_SoilTemperatureByLayers[i] + ((1 - t_LagCoefficient) * (_DepthFactor * (t_AirTemperatureAnnualAverage - t_SurfaceSoilTemperature) + t_SurfaceSoilTemperature));
        }
        SoilTemperatureByLayers.setValue(t_SoilTemperatureByLayers, this);
    }

    public HashMap<String, FWSimVariable<?>> fillTestVariables(int aParamIndex, TEST_STATE aDefineOrCheck)
    {
        return iFieldMap;
    }

    @Override
    protected FWSimComponent clone(FWSimVarMap aVarMap)
    {
        return new SoilTemperatureSWAT(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}