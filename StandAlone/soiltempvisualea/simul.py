from pathlib import Path
import pandas as pd

import standalone, model, compare
from standalone import SOIL_IDs, WST_IDs, AWCs, LAIDs
from compare import code2model

from model import na
from pathlib import Path

trt=standalone.Treatment()
models = model.Model.models()
code2M = dict((code, models[name]()) for code, name in code2model.items() if name in models)

output_dir = Path('OutputData')
output_monica = Path('OutputData')/'monica'
output_simplace = Path('OutputData')/'simplace'

def get_filename(weather_station, soil, water_content, lai, model_code):
    """ Return the filename for each simulation

    get_filename(WST_IDs[1], SOIL_IDs[0], AWCs[1], LAIDs[0], list(code2model)[0])
    
    """
    filename = f'SoilTemperature_OA_{model_code}_{weather_station}_{soil}_L{lai}_AW{water_content}.txt'
    return filename


def simulate(weather_station, soil, water_content, lai, model_code, nb_steps=-1, output_dir=output_dir):
    fn = get_filename(weather_station, soil, water_content, lai, model_code)
    
    config = trt(weather_station, soil,  water_content, lai)
    m= code2M[model_code]
    df = m.run(config, nb_steps)
    
    df = df.drop(['Layer'], axis=1)

    df.to_csv(output_dir/fn, sep='\t', na_rep='na', float_format='%.6f', date_format="%Y-%m-%d", index=False)
    return df


    

def run_all(weather_station, soil, water_content, lai):
    failure = 0
    for model_code in code2model:
        if code2model[model_code] not in models:
            continue 
        fn = get_filename(weather_station, soil, water_content, lai, model_code)
        if (output_dir/fn).exists():
            print(f'{fn} is already computed')
            continue
        try:
            print(f'Run {weather_station, soil, water_content, lai, code2model[model_code]}')
            simulate(weather_station, soil=soil, water_content=water_content, 
                lai=lai, model_code=model_code,
                nb_steps=-1)
        except: 
            print('#'*80)
            print(f'ERROR : Run {weather_station, soil, water_content, lai, model_code}')    
            failure +=1
    return failure

def run_monica(weather_station, soil, water_content, lai):
    failure = 0
    model_code = 'MOC'
    if code2model[model_code] not in models:
        return 
    fn = get_filename(weather_station, soil, water_content, lai, model_code)
    if (output_monica/fn).exists():
        print(f'{fn} is already computed')
        return
    try:
        print(f'Run {weather_station, soil, water_content, lai, code2model[model_code]}')
        simulate(weather_station, soil=soil, water_content=water_content, 
            lai=lai, model_code=model_code,
            nb_steps=-1, output_dir=output_monica)
    except: 
        print('#'*80)
        print(f'ERROR : Run {weather_station, soil, water_content, lai, model_code}')    
        failure +=1
    return failure

def run_simplace(weather_station, soil, water_content, lai):
    failure = 0
    model_code = 'SAC'
    if code2model[model_code] not in models:
        return 
    fn = get_filename(weather_station, soil, water_content, lai, model_code)
    if (output_simplace/fn).exists():
        print(f'{fn} is already computed')
        return
    #try:
    print(f'Run {weather_station, soil, water_content, lai, code2model[model_code]}')
    simulate(weather_station, soil=soil, water_content=water_content, 
        lai=lai, model_code=model_code,
        nb_steps=-1, output_dir=output_simplace)
    #except: 
    #    print('#'*80)
    #    print(f'ERROR : Run {weather_station, soil, water_content, lai, model_code}')    
    #    failure +=1
    return failure

def main(i=0):
    ws = WST_IDs[i]
    for soil in SOIL_IDs:
        for lai in LAIDs:
            for water_content in AWCs:
                run_all(ws, soil, water_content, lai)

def mainmoc(i=0):
    ws = WST_IDs[i]
    for soil in SOIL_IDs:
        for lai in LAIDs:
            for water_content in AWCs:
                run_monica(ws, soil, water_content, lai)

def mainsim(i=0):
    ws = WST_IDs[i]
    for soil in SOIL_IDs:
        for lai in LAIDs:
            for water_content in AWCs:
                run_simplace(ws, soil, water_content, lai)



"""
Test

%run simul

simulate(WST_IDs[0], SOIL_IDs[0], AWCs[0], LAIDs[0], list(code2model)[0], nb_steps=30)

from joblib import Parallel, delayed
Parallel(n_jobs=-1)(run_all(ws, soil, water_content, lai) for ws in WST_IDs for soil in SOIL_IDs for lai in LAIDs for water_content in AWCs)

# run in a shell to use 7 proc
python -c 'from simul import main; main(O)'&
python -c 'from simul import main; main(1)'&
python -c 'from simul import main; main(2)'&
python -c 'from simul import main; main(3)'&
python -c 'from simul import main; main(4)'&
python -c 'from simul import main; main(5)'&
python -c 'from simul import main; main(6)'&

# run in a shell to use 7 proc
python -c 'from simul import mainmoc; mainmoc(0)'&
python -c 'from simul import mainmoc; mainmoc(1)'&
python -c 'from simul import mainmoc; mainmoc(2)'&
python -c 'from simul import mainmoc; mainmoc(3)'&
python -c 'from simul import mainmoc; mainmoc(4)'&
python -c 'from simul import mainmoc; mainmoc(5)'&
python -c 'from simul import mainmoc; mainmoc(6)'&

# run in a shell to use 7 proc
python -c 'from simul import mainsim; mainsim(0)'&
python -c 'from simul import mainsim; mainsim(1)'&
python -c 'from simul import mainsim; mainsim(2)'&
python -c 'from simul import mainsim; mainsim(3)'&
python -c 'from simul import mainsim; mainsim(4)'&
python -c 'from simul import mainsim; mainsim(5)'&
python -c 'from simul import mainsim; mainsim(6)'&

"""

    


