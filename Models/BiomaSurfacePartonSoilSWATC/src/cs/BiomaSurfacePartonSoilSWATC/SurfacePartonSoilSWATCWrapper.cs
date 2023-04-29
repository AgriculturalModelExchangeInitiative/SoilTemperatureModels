using System;
using System.Collections.Generic;
using System.Linq;
class SurfacePartonSoilSWATCWrapper
{
    private SurfacePartonSoilSWATCState s;
    private SurfacePartonSoilSWATCState s1;
    private SurfacePartonSoilSWATCRate r;
    private SurfacePartonSoilSWATCAuxiliary a;
    private SurfacePartonSoilSWATCExogenous ex;
    private SurfacePartonSoilSWATCComponent surfacepartonsoilswatcComponent;

    public SurfacePartonSoilSWATCWrapper()
    {
        s = new SurfacePartonSoilSWATCState();
        r = new SurfacePartonSoilSWATCRate();
        a = new SurfacePartonSoilSWATCAuxiliary();
        ex = new SurfacePartonSoilSWATCExogenous();
        surfacepartonsoilswatcComponent = new SurfacePartonSoilSWATCComponent();
        loadParameters();
    }

        double LagCoefficient;

    public double SurfaceSoilTemperature{ get { return s.SurfaceSoilTemperature;}} 
     
    public double[] SoilTemperatureByLayers{ get { return s.SoilTemperatureByLayers;}} 
     
    public double SurfaceTemperatureMinimum{ get { return a.SurfaceTemperatureMinimum;}} 
     
    public double SurfaceTemperatureMaximum{ get { return a.SurfaceTemperatureMaximum;}} 
     

    public SurfacePartonSoilSWATCWrapper(SurfacePartonSoilSWATCWrapper toCopy, bool copyAll) : this()
    {
        s = (toCopy.s != null) ? new SurfacePartonSoilSWATCState(toCopy.s, copyAll) : null;
        r = (toCopy.r != null) ? new SurfacePartonSoilSWATCRate(toCopy.r, copyAll) : null;
        a = (toCopy.a != null) ? new SurfacePartonSoilSWATCAuxiliary(toCopy.a, copyAll) : null;
        ex = (toCopy.ex != null) ? new SurfacePartonSoilSWATCExogenous(toCopy.ex, copyAll) : null;
        if (copyAll)
        {
            surfacepartonsoilswatcComponent = (toCopy.surfacepartonsoilswatcComponent != null) ? new SurfacePartonSoilSWATCComponent(toCopy.surfacepartonsoilswatcComponent) : null;
        }
    }

    public void Init(){
        surfacepartonsoilswatcComponent.Init(s, r, a);
        loadParameters();
    }

    private void loadParameters()
    {
        surfacepartonsoilswatcComponent.LagCoefficient = LagCoefficient;
    }

    public void EstimateSurfacePartonSoilSWATC(double DayLength, double AirTemperatureMaximum, double AirTemperatureMinimum, double GlobalSolarRadiation, double AirTemperatureAnnualAverage)
    {
        a.DayLength = DayLength;
        a.AirTemperatureMaximum = AirTemperatureMaximum;
        a.AirTemperatureMinimum = AirTemperatureMinimum;
        a.GlobalSolarRadiation = GlobalSolarRadiation;
        a.AirTemperatureAnnualAverage = AirTemperatureAnnualAverage;
        surfacepartonsoilswatcComponent.CalculateModel(s,s1, r, a, ex);
    }

}