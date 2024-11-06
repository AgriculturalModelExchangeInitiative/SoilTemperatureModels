from pathlib import Path
import pandas as pd

import standalone, model
from model import na

code2model = dict()
code2model['APC']='APSIM_Campbell' # OK
code2model['PSC']='BioMA_Parton_SWAT'
code2model['SWC']='BioMA_SWAT'
code2model['DEC']='DSSAT_EPIC' # error
code2model['DSC']='DSSAT_ST'   # error
code2model['MOC']='MONICA'
code2model['SAC']='SIMPLACE_APEX' # error
code2model['SQC']='SiriusQuality' #OK
code2model['STC']='STICS'

#code2model['EPC']='EPIC'
#code2model['CAC']='BioMA_Campbell'

models = model.Model.models()

def read_config(path='result/SoilTemperature_SQ',
                select_models = ['SIMPLACE_APEX']):
    
    d = Path(path)
    files = d.glob('*.txt')

    trt=standalone.Treatment()

    configs=[]
    for fn in files:
        name = fn.name
        prefix = name[:-4]
        fields = prefix.split('_')
        #print(fields)

        model_name = code2model.get(fields[2])
        if select_models and (model_name not in select_models):
            #print(f'{model_name} is not in {select_models}')
            #print('We will not consider it')
            continue

        weather_station = fields[3]

        soil = fields[4]

        lai = int(fields[5][1:])

        water_content = float(fields[6][2:])

        config= trt(weather_station=weather_station, 
                    soil=soil, 
                    water_content=water_content, 
                    lai=lai)
        configs.append((fn, model_name, config))

    return configs


def compare(filename, model_name, config):
    
    if model_name not in models:
        return
    
    model = models[model_name]()
    res = model.run(config, nb_steps=1)

    base = read_result(filename, 1)

    
    res.TSLD=round(res.TSLD, 6)
    res=res[res.TSLD!=na]
    base = base[base.TSLD!='na']
    
    res.TSLD=pd.to_numeric(res.TSLD)
    base.TSLD=pd.to_numeric(base.TSLD)
    diff=(res.TSLD-base.TSLD)
    diff = round(diff, 6)

    #print(f'min = {diff.min()} | max = {diff.max()}')

    if max(abs(diff.min()), abs(diff.max())) > 1e-5:
        print ("#"*90)
        print (f"ERROR File : {filename}")
        print(f'min = {diff.min()} | max = {diff.max()}')
        print ("#"*90)
    else:
        print(f"SUCCESS {filename}")
        
    return diff

def read_result(filename, nb_steps=-1):
    df = pd.read_csv(filename, sep='\t')
    if nb_steps>1:
        df = df[:nb_steps*11]

    
    return df



"""
Test
%matplotlib qt
import seaborn as sns
import matplotlib as mpl

%run compare

configs=read_config()
diffs = [compare(*c) for c in configs]
index = [i for i, df in enumerate(diffs) if df is not None]
i=1;print(configs[index[i]][1]);mpl.pyplot.clf(); sns.lineplot(data=diffs[index[i]])
"""

    


