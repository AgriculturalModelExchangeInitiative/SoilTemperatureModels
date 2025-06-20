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


class model:
    def __init__(self, config):
        self.internal = {}

    def init(self):
        # call the init function of the model
        # update internal with structured variables or flat dict.
        pass

    def step(self, weather):
        # call the model function
        # update internal with structured variables or flat dict.
        pass

    def run(self, config):
        pass


a=1
b=2

def f(a, b):
    " c,d=f(a,b) "
    return a + b, a-b

inputs = {'a': a, 'b': b}
outputs = f(**inputs)
outs = dict(zip(('c', 'd'), outputs))
print(f"Outputs: {outs}")

# 1. définir notre modèle objet (weather, soil, crop, management
# 2. Retourver celui de APSIM à partir de crop2ml
# 3. Analyser et classer les variables (input/output) de APSIM 
# 4. Mapper les datat APSIM avec le modèle de donnée
# 5. gérer les states/rates à récuperer du init à passer au modèle en entrée et à mettre à jour en sortie
)