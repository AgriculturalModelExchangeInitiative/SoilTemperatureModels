from pprint import pprint
from pathlib import Path

from pycropml import pparse, render_cyml
from pycropml.cyml import transpile_package

dirs = """
ApsimCampbell
BiomaSurfacePartonSoilSWATC
BiomaSurfacePartonSoilSWATHourlyPartonC
DSSAT_EPICST_standalone
DSSAT_ST_standalone
""".split()

apsim_pkg = Path(dirs[0])
models = pparse.model_parser(apsim_pkg)

mu = model_unit = models[0]

#print(f"Model States: {mu.states}")
#print(f"Model Rates: {mu.rates}")
#print(f"Model Auxiliary: {mu.auxiliary}")
#print(f"Model Exogeneous: {mu.exogenous}")

# TODO
# - print the variables : inputs outputs, ...
# - split the variable names by '-'
# - define set and look at what is similar in init and model function

state_name = set(s.name for s in mu.states )
print(f"States : {state_name}")
rate_name = set(r.name for r in mu.rates )
print(f"Rates : {rate_name}")
auxiliary_name = set(a.name for a in mu.auxiliary )
print(f"Auxiliary : {auxiliary_name}")
exogenous_name = set(e.name for e in mu.exogenous )
print(f"Exogenous : {exogenous_name}")  

exos = {}
for e in mu.exogenous:
    res = e.name.split('_')
    klass = res[0]
    if len(res) >= 2:
        name = '_'.join(res[1:])
    else : 
        name= None
    exos.setdefault(klass, []).append(name)

pprint(exos)