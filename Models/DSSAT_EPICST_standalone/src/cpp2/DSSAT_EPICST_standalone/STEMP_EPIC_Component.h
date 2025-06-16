#include "STEMP_EPIC.h"

namespace DSSAT_EPICST_standalone {
class STEMP_EPIC_Component
{
private:
    std::vector<double> DUL;
    int NL{0};
    int NLAYR{0};
    std::vector<double> DS;
    std::string ISWWAT{"Y"};
    std::vector<double> BD;
    std::vector<double> LL;
    std::vector<double> DLAYR;
    std::vector<double> SW;
public:
    STEMP_EPIC_Component();

    STEMP_EPIC_Component(STEMP_EPIC_Component& copy);

    void Calculate_Model(STEMP_EPIC_State &s, STEMP_EPIC_State &s1, STEMP_EPIC_Rate &r, STEMP_EPIC_Auxiliary &a, STEMP_EPIC_Exogenous &ex);

    void Init(STEMP_EPIC_State &s, STEMP_EPIC_State &s1, STEMP_EPIC_Rate &r, STEMP_EPIC_Auxiliary &a, STEMP_EPIC_Exogenous &ex);

    std::vector<double> & getDUL();
    void setDUL(const std::vector<double> &  _DUL);

    int getNL();
    void setNL(int _NL);

    int getNLAYR();
    void setNLAYR(int _NLAYR);

    std::vector<double> & getDS();
    void setDS(const std::vector<double> &  _DS);

    std::string getISWWAT();
    void setISWWAT(std::string _ISWWAT);

    std::vector<double> & getBD();
    void setBD(const std::vector<double> &  _BD);

    std::vector<double> & getLL();
    void setLL(const std::vector<double> &  _LL);

    std::vector<double> & getDLAYR();
    void setDLAYR(const std::vector<double> &  _DLAYR);

    std::vector<double> & getSW();
    void setSW(const std::vector<double> &  _SW);

    STEMP_EPIC _STEMP_EPIC;

};
}