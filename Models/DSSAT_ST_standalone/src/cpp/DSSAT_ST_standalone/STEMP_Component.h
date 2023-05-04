#include "STEMP.h"
using namespace std;

class STEMP_Component
{
    private:
        double XLAT ;
        string ISWWAT ;
        int NLAYR ;
        vector<double> DUL ;
        vector<double> DS ;
        vector<double> LL ;
        vector<double> BD ;
        double MSALB ;
        int NL ;
        vector<double> DLAYR ;
        vector<double> SW ;
    public:
        STEMP_Component();
        STEMP_Component(const STEMP_Component& copy);
        void  Calculate_Model(STEMP_State& s, STEMP_State& s1, STEMP_Rate& r, STEMP_Auxiliary& a, STEMP_Exogenous& ex);
        void  Init(STEMP_State& s,STEMP_State& s1, STEMP_Rate& r, STEMP_Auxiliary& a, STEMP_Exogenous& ex);
        double getXLAT();
        void setXLAT(double _XLAT);
        string getISWWAT();
        void setISWWAT(string _ISWWAT);
        int getNLAYR();
        void setNLAYR(int _NLAYR);
        vector<double> & getDUL();
        void setDUL(const vector<double> &  _DUL);
        vector<double> & getDS();
        void setDS(const vector<double> &  _DS);
        vector<double> & getLL();
        void setLL(const vector<double> &  _LL);
        vector<double> & getBD();
        void setBD(const vector<double> &  _BD);
        double getMSALB();
        void setMSALB(double _MSALB);
        int getNL();
        void setNL(int _NL);
        vector<double> & getDLAYR();
        void setDLAYR(const vector<double> &  _DLAYR);
        vector<double> & getSW();
        void setSW(const vector<double> &  _SW);

        STEMP _STEMP;

};