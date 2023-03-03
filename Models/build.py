import os
import logging
from path import Path
from pycropml.transpiler.main import languages

logger = logging.getLogger(__name__)

TARGET = """
BiomaSurfacePartonSoilSWATC bioma
BiomaSurfacePartonSoilSWATHourlyPartonC bioma
BiomaSurfaceSWATSoilSWATC bioma
DSSAT_EPICST_standalone dssat
SQ_Soil_Temperature bioma
Simplace_Soil_Temperature simplace
Stics_soil_temperature stics
"""

def targets(TARGET=TARGET):
    targets = {}

    TARGET = TARGET.strip().split('\n')
    for t in TARGET:
        k, v = t.split()
        targets[k]=v

    return targets
 

def sh(cmd):
    logger.info(cmd)
    return os.system(cmd)

def clean(d, targets=['src', 'test', 'doc', 'crop2ml']):
    """ Remove src and test directories """
    d = Path(d)
    for t in targets:
        tgt = d / t
        if tgt.isdir():
            cmd = 'rm -rf '+ str(tgt)
            logger.info(cmd)
            tgt.rmtree()

def to_crop2ml(d):
    """ one platform to crop2ml """
    plats = ['bioma', 'ddsat', 'sq_', 'simplace', 'stics']
    plat=''
    for p in plats:
        if p in d.lower():
            plat = p
            break
    
    cmd = "cyml -c %s %s %s"%(d, d, plat)
    sh(cmd)


def to_platforms(d, platforms=[]):
    """ Transpile from Crop2ml to platforms"""
    if not platforms:
        exclude = 'check cpp record apsim sirius sirius2'.split()
        platforms =  ' '.join([l for l in languages if l not in exclude])
    clean(d, targets=['src', 'test', 'doc'])
    cmd = "cyml -p %s %s"%(d, platforms)
    sh(cmd)

def build():
    _targets = targets()
    for dir, plat in _targets.items():
        to_platforms(dir)
    logger.info('SUCCESS!! ')

if __name__ == '__main__':
    build()