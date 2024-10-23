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


public class HourlySoilTemperaturesPartonLogan extends FWSimComponent
{
    private FWSimVariable<Double[]> SoilTemperatureByLayersHourly;
    private FWSimVariable<Double> HourOfSunrise;
    private FWSimVariable<Double> HourOfSunset;
    private FWSimVariable<Double> DayLength;
    private FWSimVariable<Double[]> SoilTemperatureMinimum;
    private FWSimVariable<Double[]> SoilTemperatureMaximum;

    public HourlySoilTemperaturesPartonLogan(String aName, HashMap<String, FWSimVariable<?>> aFieldMap, HashMap<String, String> aInputMap, Element aSimComponentElement, FWSimVarMap aVarMap, int aOrderNumber)
    {
        super(aName, aFieldMap, aInputMap, aSimComponentElement, aVarMap, aOrderNumber);
    }

    public HourlySoilTemperaturesPartonLogan(){
        super();
    }

    @Override
    public HashMap<String, FWSimVariable<?>> createVariables()
    {
        addVariable(FWSimVariable.createSimVariable("SoilTemperatureByLayersHourly", "Hourly soil temperature by layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.state,"degC", -50, 50, 15, this));
        addVariable(FWSimVariable.createSimVariable("HourOfSunrise", "Hour of sunrise", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"h", 0, 24, 6, this));
        addVariable(FWSimVariable.createSimVariable("HourOfSunset", "Hour of sunset", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"h", 0, 24, 17, this));
        addVariable(FWSimVariable.createSimVariable("DayLength", "Length of the day", DATA_TYPE.DOUBLE, CONTENT_TYPE.input,"h", 0, 24, 10, this));
        addVariable(FWSimVariable.createSimVariable("SoilTemperatureMinimum", "Minimum soil temperature by layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"degC", -60, 60, 15, this));
        addVariable(FWSimVariable.createSimVariable("SoilTemperatureMaximum", "Maximum soil temperature by layers", DATA_TYPE.DOUBLEARRAY, CONTENT_TYPE.input,"degC", -60, 60, 15, this));

        return iFieldMap;
    }
    @Override
    protected void process()
    {
        Double [] t_SoilTemperatureByLayersHourly = SoilTemperatureByLayersHourly.getValue();
        double t_HourOfSunrise = HourOfSunrise.getValue();
        double t_HourOfSunset = HourOfSunset.getValue();
        double t_DayLength = DayLength.getValue();
        Double [] t_SoilTemperatureMinimum = SoilTemperatureMinimum.getValue();
        Double [] t_SoilTemperatureMaximum = SoilTemperatureMaximum.getValue();
        Integer h;
        Integer i;
        double TemperatureAtSunset;
        for (i=0 ; i!=t_SoilTemperatureMinimum.length ; i+=1)
        {
            for (h=0 ; h!=24 ; h+=1)
            {
                if (h >= (int)(t_HourOfSunrise) && h <= (int)(t_HourOfSunset))
                {
                    t_SoilTemperatureByLayersHourly[i * 24 + h] = t_SoilTemperatureMinimum[i] + ((t_SoilTemperatureMaximum[i] - t_SoilTemperatureMinimum[i]) * Math.sin(Math.PI * (h - 12 + (t_DayLength / 2)) / (t_DayLength + (2 * 1.8d))));
                }
            }
            TemperatureAtSunset = t_SoilTemperatureByLayersHourly[i + (int)(t_HourOfSunset)];
            for (h=0 ; h!=24 ; h+=1)
            {
                if (h > (int)(t_HourOfSunset))
                {
                    t_SoilTemperatureByLayersHourly[i + h] = (t_SoilTemperatureMinimum[i] - (TemperatureAtSunset * Math.exp(-(24 - t_DayLength) / 2.2d)) + ((TemperatureAtSunset - t_SoilTemperatureMinimum[i]) * Math.exp(-(h - t_HourOfSunset) / 2.2d))) / (1 - Math.exp(-(24 - t_DayLength) / 2.2d));
                }
                else if ( h <= (int)(t_HourOfSunrise))
                {
                    t_SoilTemperatureByLayersHourly[i + h] = (t_SoilTemperatureMinimum[i] - (TemperatureAtSunset * Math.exp(-(24 - t_DayLength) / 2.2d)) + ((TemperatureAtSunset - t_SoilTemperatureMinimum[i]) * Math.exp(-(h + 24 - t_HourOfSunset) / 2.2d))) / (1 - Math.exp(-(24 - t_DayLength) / 2.2d));
                }
            }
        }
        SoilTemperatureByLayersHourly.setValue(t_SoilTemperatureByLayersHourly, this);
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
        return new HourlySoilTemperaturesPartonLogan(iName, iFieldMap, iInputMap, iSimComponentElement, aVarMap, iOrderNumber);
    }
}