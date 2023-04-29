using System;
using System.Collections.Generic;
using System.Linq;
class SurfaceSWATSoilSWATCWrapper
{
    private SurfaceSWATSoilSWATCState s;
    private SurfaceSWATSoilSWATCState s1;
    private SurfaceSWATSoilSWATCRate r;
    private SurfaceSWATSoilSWATCAuxiliary a;
    private SurfaceSWATSoilSWATCExogenous ex;
    private SurfaceSWATSoilSWATCComponent surfaceswatsoilswatcComponent;

    public SurfaceSWATSoilSWATCWrapper()
    {
        s = new SurfaceSWATSoilSWATCState();
        r = new SurfaceSWATSoilSWATCRate();
        a = new SurfaceSWATSoilSWATCAuxiliary();
        ex = new SurfaceSWATSoilSWATCExogenous();
        surfaceswatsoilswatcComponent = new SurfaceSWATSoilSWATCComponent();
        loadParameters();
    }

        double LagCoefficient;

    public double SurfaceSoilTemperature{ get { return s.SurfaceSoilTemperature;}} 
     
    public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     

    public SurfaceSWATSoilSWATCWrapper(SurfaceSWATSoilSWATCWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new SurfaceSWATSoilSWATCState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new SurfaceSWATSoilSWATCRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new SurfaceSWATSoilSWATCAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new SurfaceSWATSoilSWATCExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            surfaceswatsoilswatcComponent = (toCopy.surfaceswatsoilswatcComponent != null) ? new SurfaceSWATSoilSWATCComponent(toCopy.surfaceswatsoilswatcComponent) : null;
        }
    }

    public void Init(){
        surfaceswatsoilswatcComponent.Init(s, r, a);
        loadParameters();
    }

    private void loadParameters()
    {
        surfaceswatsoilswatcComponent.LagCoefficient = LagCoefficient;
    }

    public void EstimateSurfaceSWATSoilSWATC(double GlobalSolarRadiation, double AirTemperatureMaximum, double AirTemperatureMinimum, double Albedo, double WaterEquivalentOfSnowPack, double AirTemperatureAnnualAverage)
    {
        a.GlobalSolarRadiation = GlobalSolarRadiation;
        a.AirTemperatureMaximum = AirTemperatureMaximum;
        a.AirTemperatureMinimum = AirTemperatureMinimum;
        a.Albedo = Albedo;
        a.WaterEquivalentOfSnowPack = WaterEquivalentOfSnowPack;
        a.AirTemperatureAnnualAverage = AirTemperatureAnnualAverage;
        surfaceswatsoilswatcComponent.CalculateModel(s,s1, r, a, ex);
    }

}