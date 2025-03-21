#include "SoilTemperature.h"

namespace ApsimCampbell {
class SoiltempComponent
{
private:
    std::vector<double> thermCondPar1;
    int topsoilNode{2};
    int surfaceNode{1};
    int numPhantomNodes{5};
    std::vector<std::string> soilConstituentNames;
    std::vector<double> physical_Thickness;
    double MissingValue{99999};
    double timestep{24.0 * 60.0 * 60.0};
    double soilRoughnessHeight{0};
    int numIterationsForBoundaryLayerConductance{1};
    double defaultTimeOfMaximumTemperature{14.0};
    double pom{0.0};
    double DepthToConstantTemperature{10000};
    double constantBoundaryLayerConductance{20};
    std::vector<double> thermCondPar4;
    std::vector<double> nodeDepth;
    double nu{0.6};
    std::vector<double> pInitialValues;
    double ps{0.0};
    std::string netRadiationSource{"calc"};
    int airNode{0};
    double bareSoilRoughness{57};
    std::vector<double> thermCondPar2;
    double defaultInstrumentHeight{1.2};
    std::vector<double> physical_BD;
    double latentHeatOfVapourisation{2465000};
    double weather_Latitude{0.0};
    double stefanBoltzmannConstant{0.0000000567};
    std::string boundarLayerConductanceSource{"calc"};
    std::vector<double> thermCondPar3;
public:
    SoiltempComponent();

    SoiltempComponent(SoiltempComponent& copy);

    void Calculate_Model(SoiltempState &s, SoiltempState &s1, SoiltempRate &r, SoiltempAuxiliary &a, SoiltempExogenous &ex);

    void Init(SoiltempState &s, SoiltempState &s1, SoiltempRate &r, SoiltempAuxiliary &a, SoiltempExogenous &ex);

    std::vector<double> & getthermCondPar1();
    void setthermCondPar1(const std::vector<double> &  _thermCondPar1);

    int gettopsoilNode();
    void settopsoilNode(int _topsoilNode);

    int getsurfaceNode();
    void setsurfaceNode(int _surfaceNode);

    int getnumPhantomNodes();
    void setnumPhantomNodes(int _numPhantomNodes);

    std::vector<std::string> & getsoilConstituentNames();
    void setsoilConstituentNames(const std::vector<std::string> &  _soilConstituentNames);

    std::vector<double> & getphysical_Thickness();
    void setphysical_Thickness(const std::vector<double> &  _physical_Thickness);

    double getMissingValue();
    void setMissingValue(double _MissingValue);

    double gettimestep();
    void settimestep(double _timestep);

    double getsoilRoughnessHeight();
    void setsoilRoughnessHeight(double _soilRoughnessHeight);

    int getnumIterationsForBoundaryLayerConductance();
    void setnumIterationsForBoundaryLayerConductance(int _numIterationsForBoundaryLayerConductance);

    double getdefaultTimeOfMaximumTemperature();
    void setdefaultTimeOfMaximumTemperature(double _defaultTimeOfMaximumTemperature);

    double getpom();
    void setpom(double _pom);

    double getDepthToConstantTemperature();
    void setDepthToConstantTemperature(double _DepthToConstantTemperature);

    double getconstantBoundaryLayerConductance();
    void setconstantBoundaryLayerConductance(double _constantBoundaryLayerConductance);

    std::vector<double> & getthermCondPar4();
    void setthermCondPar4(const std::vector<double> &  _thermCondPar4);

    std::vector<double> & getnodeDepth();
    void setnodeDepth(const std::vector<double> &  _nodeDepth);

    double getnu();
    void setnu(double _nu);

    std::vector<double> & getpInitialValues();
    void setpInitialValues(const std::vector<double> &  _pInitialValues);

    double getps();
    void setps(double _ps);

    std::string getnetRadiationSource();
    void setnetRadiationSource(std::string _netRadiationSource);

    int getairNode();
    void setairNode(int _airNode);

    double getbareSoilRoughness();
    void setbareSoilRoughness(double _bareSoilRoughness);

    std::vector<double> & getthermCondPar2();
    void setthermCondPar2(const std::vector<double> &  _thermCondPar2);

    double getdefaultInstrumentHeight();
    void setdefaultInstrumentHeight(double _defaultInstrumentHeight);

    std::vector<double> & getphysical_BD();
    void setphysical_BD(const std::vector<double> &  _physical_BD);

    double getlatentHeatOfVapourisation();
    void setlatentHeatOfVapourisation(double _latentHeatOfVapourisation);

    double getweather_Latitude();
    void setweather_Latitude(double _weather_Latitude);

    double getstefanBoltzmannConstant();
    void setstefanBoltzmannConstant(double _stefanBoltzmannConstant);

    std::string getboundarLayerConductanceSource();
    void setboundarLayerConductanceSource(std::string _boundarLayerConductanceSource);

    std::vector<double> & getthermCondPar3();
    void setthermCondPar3(const std::vector<double> &  _thermCondPar3);

    SoilTemperature _SoilTemperature;

};
}