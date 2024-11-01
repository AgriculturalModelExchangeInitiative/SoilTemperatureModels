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

def get_filename(weather_station, soil, water_content, lai, model_code):
    """ Return the filename for each simulation

    get_filename(WST_IDs[1], SOIL_IDs[0], AWCs[1], LAIDs[0], list(code2model)[0])
    
    """
    filename = f'SoilTemperature_OA_{model_code}_{weather_station}_{soil}_L{lai}_AW{water_content}.txt'
    return filename


def simulate(weather_station, soil, water_content, lai, model_code, nb_steps=-1):
    fn = get_filename(weather_station, soil, water_content, lai, model_code)
    
    config = trt(weather_station, soil,  water_content, lai)
    m= code2M[model_code]
    df = m.run(config, nb_steps)
    
    df = df.drop(['Layer'], axis=1)

    df.to_csv(output_dir/fn, sep='\t', na_rep='na', float_format='%.6f', date_format="%Y-%m-%d", index=False)
    return df


    

def run_all(soil_id='SICL', lai=0):
    
    for weather_station in WST_IDs:
        for water_content in AWCs:
            for model_code in code2model:
                if code2model[model_code] not in models:
                    continue 
                fn = get_filename(weather_station, soil_id, water_content, lai, model_code)
                print(f'Run {weather_station, soil_id, water_content, lai, model_code}')
                if (output_dir/fn).exists():
                    print(f'{fn} is already computed')
                    continue
                simulate(weather_station, soil=soil_id, water_content=water_content, 
                         lai=lai, model_code=model_code,
                         nb_steps=30)
                
def one_process(index=0)

"""
Test

%run simul

simulate(WST_IDs[0], SOIL_IDs[0], AWCs[0], LAIDs[0], list(code2model)[0], nb_steps=30)
"""

    


