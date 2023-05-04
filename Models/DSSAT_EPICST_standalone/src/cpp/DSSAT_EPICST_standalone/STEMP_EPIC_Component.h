#include "STEMP_EPIC.h"
using namespace std;

class STEMP_EPIC_Component
{
    private:
        vector<double> DUL ;
        string ISWWAT ;
        vector<double> LL ;
        vector<double> DS ;
        vector<double> SW ;
        vector<double> BD ;
        int NLAYR ;
        int NL ;
        vector<double> DLAYR ;
    public:
        STEMP_EPIC_Component();
        STEMP_EPIC_Component(const STEMP_EPIC_Component& copy);
        void  Calculate_Model(STEMP_EPIC_State& s, STEMP_EPIC_State& s1, STEMP_EPIC_Rate& r, STEMP_EPIC_Auxiliary& a, STEMP_EPIC_Exogenous& ex);
        void  Init(STEMP_EPIC_State& s,STEMP_EPIC_State& s1, STEMP_EPIC_Rate& r, STEMP_EPIC_Auxiliary& a, STEMP_EPIC_Exogenous& ex);
        vector<double> & getDUL();
        void setDUL(const vector<double> &  _DUL);
        string getISWWAT();
        void setISWWAT(string _ISWWAT);
        vector<double> & getLL();
        void setLL(const vector<double> &  _LL);
        vector<double> & getDS();
        void setDS(const vector<double> &  _DS);
        vector<double> & getSW();
        void setSW(const vector<double> &  _SW);
        vector<double> & getBD();
        void setBD(const vector<double> &  _BD);
        int getNLAYR();
        void setNLAYR(int _NLAYR);
        int getNL();
        void setNL(int _NL);
        vector<double> & getDLAYR();
        void setDLAYR(const vector<double> &  _DLAYR);

        STEMP_EPIC _STEMP_EPIC;

};