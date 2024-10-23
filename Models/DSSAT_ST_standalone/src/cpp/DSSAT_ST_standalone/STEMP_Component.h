#include "STEMP.h"

namespace DSSAT_ST_standalone {
class STEMP_Component
{
    private:
        double MSALB ;
        int NL ;
        std::vector<double> LL ;
        int NLAYR ;
        std::vector<double> DS ;
        std::vector<double> DLAYR ;
        std::string ISWWAT ;
        std::vector<double> BD ;
        std::vector<double> SW ;
        double XLAT ;
        std::vector<double> DUL ;
    public:
        STEMP_Component();
        STEMP_Component(STEMP_Component& copy);
        void Calculate_Model(STEMP_State &s, STEMP_State &s1, STEMP_Rate &r, STEMP_Auxiliary &a, STEMP_Exogenous &ex);
        void Init(STEMP_State &s, STEMP_State &s1, STEMP_Rate &r, STEMP_Auxiliary &a, STEMP_Exogenous &ex);
        double getMSALB();
        void setMSALB(double _MSALB);
        int getNL();
        void setNL(int _NL);
        std::vector<double> & getLL();
        void setLL(const std::vector<double> &  _LL);
        int getNLAYR();
        void setNLAYR(int _NLAYR);
        std::vector<double> & getDS();
        void setDS(const std::vector<double> &  _DS);
        std::vector<double> & getDLAYR();
        void setDLAYR(const std::vector<double> &  _DLAYR);
        std::string getISWWAT();
        void setISWWAT(std::string _ISWWAT);
        std::vector<double> & getBD();
        void setBD(const std::vector<double> &  _BD);
        std::vector<double> & getSW();
        void setSW(const std::vector<double> &  _SW);
        double getXLAT();
        void setXLAT(double _XLAT);
        std::vector<double> & getDUL();
        void setDUL(const std::vector<double> &  _DUL);

        STEMP _STEMP;

};
}
