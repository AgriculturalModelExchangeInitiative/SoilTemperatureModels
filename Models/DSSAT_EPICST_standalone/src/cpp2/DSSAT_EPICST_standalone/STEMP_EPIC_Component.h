#include "STEMP_EPIC.h"
using namespace std;

class STEMP_EPIC_Component
{
    private:
        vector<double> BD ;
        vector<double> DUL ;
        vector<double> DS ;
        vector<double> DLAYR ;
        vector<double> LL ;
        vector<double> SW ;
        int NLAYR ;
        int NL ;
        string ISWWAT ;
    public:
        STEMP_EPIC_Component();
        STEMP_EPIC_Component(const STEMP_EPIC_Component& copy);
        void  Calculate_Model(STEMP_EPIC_State& s, STEMP_EPIC_State& s1, STEMP_EPIC_Rate& r, STEMP_EPIC_Auxiliary& a, STEMP_EPIC_Exogenous& ex);
        void  Init(STEMP_EPIC_State& s,STEMP_EPIC_State& s1, STEMP_EPIC_Rate& r, STEMP_EPIC_Auxiliary& a, STEMP_EPIC_Exogenous& ex);
        vector<double> & getBD();
        void setBD(const vector<double> &  _BD);
        vector<double> & getDUL();
        void setDUL(const vector<double> &  _DUL);
        vector<double> & getDS();
        void setDS(const vector<double> &  _DS);
        vector<double> & getDLAYR();
        void setDLAYR(const vector<double> &  _DLAYR);
        vector<double> & getLL();
        void setLL(const vector<double> &  _LL);
        vector<double> & getSW();
        void setSW(const vector<double> &  _SW);
        int getNLAYR();
        void setNLAYR(int _NLAYR);
        int getNL();
        void setNL(int _NL);
        string getISWWAT();
        void setISWWAT(string _ISWWAT);

        STEMP_EPIC _STEMP_EPIC;

};