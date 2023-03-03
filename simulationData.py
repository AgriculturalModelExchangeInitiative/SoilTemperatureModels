# -*- coding: utf-8 -*-
"""
Created on Thu Mar  2 14:38:45 2023

@author: MIDINGOYI
"""

import pandas as pd
import os
from  glob import glob
import re
from path import Path
import numpy as np


def simulationdata(rep_sens_analysis_file, rep_weather_folder, code_var_column_name):
    
    """
    Parameters:
            rep_sens_analysis_file (str: excel file) : Path of Soil temperature sensitivity analysis file where simulations are described
            rep_weather (str): Path of weather data folder (contains files .WTH)
            code_var_column_name (str): name of the column specifying model variables
            
    Returns:
        datas (list): data of all simulation unit
        list(datas[0]) = "sm" (str), "soil" (dict), "param_weather"(dict), "weather" (dict[Var:dataframe])
    
    Examples:
        rep_sens_analysis = "../Soil temperature sensitivity analysis-20230301T231136Z-001/Soil temperature sensitivity analysis/2-Model inputs/SoilTemperature_SensitivityAnalysis_Step1_Inputs.xlsx"
        rep_weather = "../Soil temperature sensitivity analysis-20230301T231136Z-001/Soil temperature sensitivity analysis/1-WeatherData/For_simulation_Step1"
        xx = simulationdata(rep_sens_analysis, rep_weather, code_var_column_name="dssat_var")

    """
    
    datas = []
    dict_var = {} # matching common variables/parameters names and model variables.parameters
    # sheat of simulation description
    df_file_model_inputs = pd.read_excel(rep_sens_analysis_file, sheet_name=0)
    # Replacing empty string with np.NaN
    df_file_model_inputs[code_var_column_name] = df_file_model_inputs[code_var_column_name].replace('', np.nan)
    # Dropping rows where NaN is present. Keeping only rows where model variables are defined
    model_vars = df_file_model_inputs.dropna(subset=[code_var_column_name])

    for k, j in zip(model_vars["Code"], model_vars[code_var_column_name]):
        dict_var[k] = j

    df_file_model_inputs_treatments = pd.read_excel(rep_sens_analysis_file, sheet_name=1, skiprows=2)
    df_file_model_inputs_soil_metadata = pd.read_excel(rep_sens_analysis_file, sheet_name=2, skiprows=2)
    df_file_model_inputs_soil_layers = pd.read_excel(rep_sens_analysis_file, sheet_name=3, skiprows=2)
    df_file_model_inputs_wthdata = pd.read_excel(rep_sens_analysis_file, sheet_name=4, skiprows=2)
    
    files_weather = glob(os.path.join(rep_weather_folder, "*.WTH"))
    var_weather = {}
    
    for p in files_weather:
        name_weather = Path(p).stem
        data =pd.read_csv(p, delimiter=r"\s+")
        var_weather[name_weather] = {}
        var_weather[name_weather] = data
      
    stations = list(var_weather.keys())    
    dd1 = df_file_model_inputs_wthdata
    dd1 = dd1.set_index("WST_ID")
            
    dd2 = df_file_model_inputs_soil_metadata
    dd2 = dd2.set_index("SOIL_ID")
        
    dd3 = df_file_model_inputs_soil_layers 
    dd3 = dd3.set_index("SOIL_ID")
            
    dd4 = df_file_model_inputs_treatments
    dd4 = dd4.set_index("SM")

    for k, j in enumerate(df_file_model_inputs_treatments.iloc): 
        wst = j["WST_DATASET"]
        if wst in stations:  #only if weather data exists. There are some treatments without weather data
            data = {}
            sm = j["SM"]
            treat = j["TREAT_ID"]   
            soil_id = j["SOIL_ID"]
            wst_id = j["WST_ID"]
                
            weather = var_weather[wst]

            var_w = {}
            soil = {}
            par_w = {}
            treat_ = {}
            r = []
            data["sm"] = sm
     
            for u, v in dict_var.items():
                if u in weather.columns:
                    var_w[v] = weather[[u]]
                    r.append(v)      
                    data["weather"] = var_w
        
                if u in dd2.loc[[soil_id]]:
                    soil[v] = int(dd2.loc[soil_id][u])
                    r.append(v)      
                if u in dd3.loc[[soil_id]]:
                    soil[v] = list(dd3.loc[soil_id][u])
                    r.append(v)
                    data["soil"] = soil
                
        
                if u in dd1.loc[[wst_id]]:
                    par_w[v] = dd1.loc[wst_id][u]
                    r.append(v)
                    data["param_weather"] = par_w
                
                if u in dd4.loc[[sm]]:
                    treat_[v] = dd4.loc[sm][u]
                    r.append(v)
                    data["treat"] = treat_
            
            missing = set(dict_var.keys()) - set(r)
            " raise exception for missing values: TODO"
            
            datas.append(data) 
            
    return datas
        
        

"""
rep_sens_analysis = "D:/Docs/AMEI_Workshop/Soil temperature sensitivity analysis-20230301T231136Z-001/Soil temperature sensitivity analysis/2-Model inputs/SoilTemperature_SensitivityAnalysis_Step1_Inputs.xlsx"
rep_weather = "D:/Docs/AMEI_Workshop/Soil temperature sensitivity analysis-20230301T231136Z-001/Soil temperature sensitivity analysis/1-WeatherData/For_simulation_Step1"
xx = simulationdata(rep_sens_analysis, rep_weather, code_var_column_name="dssat_var")

"""
