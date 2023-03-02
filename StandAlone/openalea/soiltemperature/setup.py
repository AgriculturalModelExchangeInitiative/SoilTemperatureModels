# -*- coding: utf-8 -*-
import sys
import os
from pathlib import Path
from setuptools import setup, find_packages

version = '0.1.0'

name = 'AMEI.SoilTemperature'
description= 'AMEI initiative for comparing Soil Temperature models'
long_description= description
authors= 'AMEI consortium'
authors_email = 'christophe.pradal@cirad.fr'
url = 'https://github.com/AgriculturalModelExchangeInitiative/SoilTemperatureModels'
license = 'BSD'

packages = find_packages('src')
package_dir = {'':'src'}

setup_requires = ['openalea.deploy']
install_requires = []

def find_workflows_entry_points(dir):
    """ Find the wralea files """
    d = Path(dir)
    wraleas = d.glob('**/__wralea__.py')
    wralea_epoint = []
    for wralea in wraleas:
        wdir = str(wralea.parent)
        dirs = wdir.split(os.sep)[1:]
        name = '.'.join(dirs)
        wralea_epoint.append('%s = %s'%(name, name))
    return wralea_epoint

entry_points = dict()
entry_points['wralea'] = find_workflows_entry_points('src')

setup(
    # Meta data (no edition needed if you correctly defined the variables above)
    name=name,
    version=version,
    description=description,
    long_description=long_description,
    author=authors,
    author_email=authors_email,
    url=url,
    license=license,
    keywords = 'AMEI, SimPlace, OpenAlea, DSSAT, BioMA',	
    
    # package installation
    packages= packages,	
    package_dir= package_dir,

    # Namespace packages creation by deploy
    #namespace_packages = [namespace],
    #create_namespaces = True,
    zip_safe= False,
    
    # Dependencies
    setup_requires = setup_requires,
    install_requires = install_requires,
    
    include_package_data = True,
    
    entry_points = entry_points,

    )
