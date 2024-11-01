
# -*- coding: latin-1 -*-
# This file has been generated at Fri Nov  1 06:09:49 2024

from openalea.core import *


__name__ = 'amei.monica_soiltemp.soiltemperaturecomp'

__editable__ = True
__version__ = '0.0.1'
__license__ = 'CECILL-C'
__authors__ = 'AMEI Consortium'
__institutes__ = ''
__description__ = 'CropML Model library.'
__url__ = 'http://crop2ml.org'
__icon__ = ''
__alias__ = ['SoilTemperatureComp']


__all__ = ['soiltemperature_model_soiltemperature', 'nosnowsoilsurfacetemperature_model_nosnowsoilsurfacetemperature', 'withsnowsoilsurfacetemperature_model_withsnowsoilsurfacetemperature', 'SoilTemperatureComp']



soiltemperature_model_soiltemperature = Factory(name='SoilTemperature',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='soiltemperature',
                nodeclass='model_soiltemperature',
                inputs=[{'name': 'noOfSoilLayers', 'interface': IInt, 'value': 20}, {'name': 'noOfTempLayers', 'interface': IInt, 'value': 22}, {'name': 'noOfTempLayersPlus1', 'interface': IInt, 'value': 23}, {'name': 'soilSurfaceTemperature', 'interface': IFloat(min=-50, max=80, step=1.000000), 'value': 0.0}, {'name': 'timeStep', 'interface': IFloat, 'value': 1.0}, {'name': 'soilMoistureConst', 'interface': ISequence, 'value': 0}, {'name': 'baseTemp', 'interface': IFloat, 'value': 9.5}, {'name': 'initialSurfaceTemp', 'interface': IFloat, 'value': 10.0}, {'name': 'densityAir', 'interface': IFloat, 'value': 1.25}, {'name': 'specificHeatCapacityAir', 'interface': IFloat, 'value': 1005.0}, {'name': 'densityHumus', 'interface': IFloat, 'value': 1300.0}, {'name': 'specificHeatCapacityHumus', 'interface': IFloat, 'value': 1920.0}, {'name': 'densityWater', 'interface': IFloat, 'value': 1000.0}, {'name': 'specificHeatCapacityWater', 'interface': IFloat, 'value': 4192.0}, {'name': 'quartzRawDensity', 'interface': IFloat, 'value': 2650.0}, {'name': 'specificHeatCapacityQuartz', 'interface': IFloat, 'value': 750.0}, {'name': 'nTau', 'interface': IFloat, 'value': 0.65}, {'name': 'layerThickness', 'interface': ISequence, 'value': 0}, {'name': 'soilBulkDensity', 'interface': ISequence, 'value': 0}, {'name': 'saturation', 'interface': ISequence, 'value': 0}, {'name': 'soilOrganicMatter', 'interface': ISequence, 'value': 0}, {'name': 'soilTemperature', 'interface': ISequence, 'value': 0}, {'name': 'V', 'interface': ISequence, 'value': 0}, {'name': 'B', 'interface': ISequence, 'value': 0}, {'name': 'volumeMatrix', 'interface': ISequence, 'value': 0}, {'name': 'volumeMatrixOld', 'interface': ISequence, 'value': 0}, {'name': 'matrixPrimaryDiagonal', 'interface': ISequence, 'value': 0}, {'name': 'matrixSecondaryDiagonal', 'interface': ISequence, 'value': 0}, {'name': 'heatConductivity', 'interface': ISequence, 'value': 0}, {'name': 'heatConductivityMean', 'interface': ISequence, 'value': 0}, {'name': 'heatCapacity', 'interface': ISequence, 'value': 0}, {'name': 'solution', 'interface': ISequence, 'value': 0}, {'name': 'matrixDiagonal', 'interface': ISequence, 'value': 0}, {'name': 'matrixLowerTriangle', 'interface': ISequence, 'value': 0}, {'name': 'heatFlow', 'interface': ISequence, 'value': 0}],
                outputs=[{'name': 'soilTemperature', 'interface': ISequence}],
                widgetmodule=None,
                widgetclass=None,
               )




nosnowsoilsurfacetemperature_model_nosnowsoilsurfacetemperature = Factory(name='NoSnowSoilSurfaceTemperature',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='nosnowsoilsurfacetemperature',
                nodeclass='model_nosnowsoilsurfacetemperature',
                inputs=[{'name': 'tmin', 'interface': IFloat(min=-50, max=70, step=1.000000), 'value': 0}, {'name': 'tmax', 'interface': IFloat(min=-50, max=70, step=1.000000), 'value': 0}, {'name': 'globrad', 'interface': IFloat(min=0, max=30, step=1.000000), 'value': 0.0}, {'name': 'soilCoverage', 'interface': IFloat(min=0, max=16777216, step=1.000000), 'value': 0.0}, {'name': 'dampingFactor', 'interface': IFloat, 'value': 0.8}, {'name': 'soilSurfaceTemperature', 'interface': IFloat, 'value': 0.0}],
                outputs=[{'name': 'soilSurfaceTemperature', 'interface': IFloat}],
                widgetmodule=None,
                widgetclass=None,
               )




withsnowsoilsurfacetemperature_model_withsnowsoilsurfacetemperature = Factory(name='WithSnowSoilSurfaceTemperature',
                authors='AMEI Consortium (wralea authors)',
                description=None,
                category='Unclassified',
                nodemodule='withsnowsoilsurfacetemperature',
                nodeclass='model_withsnowsoilsurfacetemperature',
                inputs=[{'name': 'noSnowSoilSurfaceTemperature', 'interface': IFloat, 'value': 0.0}, {'name': 'soilSurfaceTemperatureBelowSnow', 'interface': IFloat, 'value': 0.0}, {'name': 'hasSnowCover', 'interface': IBool, 'value': 'False'}],
                outputs=[{'name': 'soilSurfaceTemperature', 'interface': IFloat}],
                widgetmodule=None,
                widgetclass=None,
               )




SoilTemperatureComp = CompositeNodeFactory(name='SoilTemperatureComp',
                             description=('\n'
 '\n'
 '    SoilTemperature model\n'
 '    -Version: 1  -Time step: 1\n'
 '    Authors: Michael Berg-Mohnicke\n'
 '    Reference: None\n'
 '    Institution: ZALF e.V.\n'
 '    ExtendedDescription: None\n'
 '    ShortDescription: Calculates the soil temperature in all layers and soil '
 'surface temperature\n'),
                             category='',
                             doc='',
                             inputs=[  {'interface': IFloat(min=-50, max=70, step=1.000000), 'name': 'tmin'},
   {'interface': IFloat(min=-50, max=70, step=1.000000), 'name': 'tmax'},
   {'interface': IFloat(min=0, max=30, step=1.000000), 'name': 'globrad'},
   {'interface': IFloat, 'name': 'dampingFactor', 'value': 0.8},
   {  'interface': IFloat(min=0, max=16777216, step=1.000000),
      'name': 'soilCoverage'},
   {'interface': IFloat, 'name': 'soilSurfaceTemperatureBelowSnow'},
   {'interface': IBool, 'name': 'hasSnowCover', 'value': 'False'},
   {'interface': IFloat, 'name': 'timeStep', 'value': 1.0},
   {'interface': ISequence, 'name': 'soilMoistureConst'},
   {'interface': IFloat, 'name': 'baseTemp', 'value': 9.5},
   {'interface': IFloat, 'name': 'initialSurfaceTemp', 'value': 10.0},
   {'interface': IFloat, 'name': 'densityAir', 'value': 1.25},
   {'interface': IFloat, 'name': 'specificHeatCapacityAir', 'value': 1005.0},
   {'interface': IFloat, 'name': 'densityHumus', 'value': 1300.0},
   {'interface': IFloat, 'name': 'specificHeatCapacityHumus', 'value': 1920.0},
   {'interface': IFloat, 'name': 'densityWater', 'value': 1000.0},
   {'interface': IFloat, 'name': 'specificHeatCapacityWater', 'value': 4192.0},
   {'interface': IFloat, 'name': 'quartzRawDensity', 'value': 2650.0},
   {'interface': IFloat, 'name': 'specificHeatCapacityQuartz', 'value': 750.0},
   {'interface': IFloat, 'name': 'nTau', 'value': 0.65},
   {'interface': IInt, 'name': 'noOfTempLayers', 'value': 22},
   {'interface': IInt, 'name': 'noOfTempLayersPlus1', 'value': 23},
   {'interface': IInt, 'name': 'noOfSoilLayers', 'value': 20},
   {'interface': ISequence, 'name': 'layerThickness'},
   {'interface': ISequence, 'name': 'soilBulkDensity'},
   {'interface': ISequence, 'name': 'saturation'},
   {'interface': ISequence, 'name': 'soilOrganicMatter'},
   {'interface': ISequence, 'name': 'V'},
   {'interface': ISequence, 'name': 'B'},
   {'interface': ISequence, 'name': 'volumeMatrix'},
   {'interface': ISequence, 'name': 'volumeMatrixOld'},
   {'interface': ISequence, 'name': 'matrixPrimaryDiagonal'},
   {'interface': ISequence, 'name': 'matrixSecondaryDiagonal'},
   {'interface': ISequence, 'name': 'heatConductivity'},
   {'interface': ISequence, 'name': 'heatConductivityMean'},
   {'interface': ISequence, 'name': 'heatCapacity'},
   {'interface': ISequence, 'name': 'solution'},
   {'interface': ISequence, 'name': 'matrixDiagonal'},
   {'interface': ISequence, 'name': 'matrixLowerTriangle'},
   {'interface': ISequence, 'name': 'heatFlow'}],
                             outputs=[  {'interface': IFloat, 'name': 'soilSurfaceTemperature'},
   {'interface': ISequence, 'name': 'soilTemperature'}],
                             elt_factory={  2: ('amei.monica_soiltemp.soiltemperaturecomp', 'SoilTemperature'),
   3: (  'amei.monica_soiltemp.soiltemperaturecomp',
         'NoSnowSoilSurfaceTemperature'),
   4: (  'amei.monica_soiltemp.soiltemperaturecomp',
         'WithSnowSoilSurfaceTemperature')},
                             elt_connections={  4368906384: (4, 0, '__out__', 0),
   4368906416: (2, 0, '__out__', 1),
   4368906448: ('__in__', 0, 3, 0),
   4368906480: ('__in__', 1, 3, 1),
   4368906512: ('__in__', 2, 3, 2),
   4368906544: ('__in__', 3, 3, 4),
   4368906576: ('__in__', 4, 3, 3),
   4368906608: ('__in__', 5, 4, 1),
   4368906640: ('__in__', 6, 4, 2),
   4368906672: ('__in__', 7, 2, 4),
   4368906704: ('__in__', 8, 2, 5),
   4368906736: ('__in__', 9, 2, 6),
   4368906768: ('__in__', 10, 2, 7),
   4368906800: ('__in__', 11, 2, 8),
   4368906832: ('__in__', 12, 2, 9),
   4368906864: ('__in__', 13, 2, 10),
   4368906896: ('__in__', 14, 2, 11),
   4368906928: ('__in__', 15, 2, 12),
   4368906960: ('__in__', 16, 2, 13),
   4368906992: ('__in__', 17, 2, 14),
   4368907024: ('__in__', 18, 2, 15),
   4368907056: ('__in__', 19, 2, 16),
   4368907088: ('__in__', 20, 2, 1),
   4368907120: ('__in__', 21, 2, 2),
   4368907152: ('__in__', 22, 2, 0),
   4368907184: ('__in__', 23, 2, 17),
   4368907216: ('__in__', 24, 2, 18),
   4368907248: ('__in__', 25, 2, 19),
   4368907280: ('__in__', 26, 2, 20),
   4368907312: ('__in__', 27, 2, 22),
   4368907344: ('__in__', 28, 2, 23),
   4368907376: ('__in__', 29, 2, 24),
   4368907408: ('__in__', 30, 2, 25),
   4368907440: ('__in__', 31, 2, 26),
   4368907472: ('__in__', 32, 2, 27),
   4368907504: ('__in__', 33, 2, 28),
   4368907536: ('__in__', 34, 2, 29),
   4368907568: ('__in__', 35, 2, 30),
   4368907600: ('__in__', 36, 2, 31),
   4368907632: ('__in__', 37, 2, 32),
   4368907664: ('__in__', 38, 2, 33),
   4368907696: ('__in__', 39, 2, 34),
   4368907728: (3, 0, 4, 0),
   4368907760: (4, 0, 2, 3)},
                             elt_data={  2: {  'block': False,
         'caption': 'SoilTemperature',
         'delay': 0,
         'hide': True,
         'id': 2,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 63.0,
         'posy': 250.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   3: {  'block': False,
         'caption': 'NoSnowSoilSurfaceTemperature',
         'delay': 0,
         'hide': True,
         'id': 3,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 0.0,
         'posy': 125.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   4: {  'block': False,
         'caption': 'WithSnowSoilSurfaceTemperature',
         'delay': 0,
         'hide': True,
         'id': 4,
         'lazy': True,
         'port_hide_changed': set(),
         'posx': 125.0,
         'posy': 125.0,
         'priority': 0,
         'use_user_color': True,
         'user_application': None,
         'user_color': None},
   '__in__': {  'block': False,
                'caption': 'In',
                'delay': 0,
                'hide': True,
                'id': 0,
                'lazy': True,
                'port_hide_changed': set(),
                'posx': 250.0,
                'posy': 0,
                'priority': 0,
                'use_user_color': True,
                'user_application': None,
                'user_color': None},
   '__out__': {  'block': False,
                 'caption': 'Out',
                 'delay': 0,
                 'hide': True,
                 'id': 1,
                 'lazy': True,
                 'port_hide_changed': set(),
                 'posx': 250.0,
                 'posy': 500,
                 'priority': 0,
                 'use_user_color': True,
                 'user_application': None,
                 'user_color': None}},
                             elt_value={2: [(21, '0')], 3: [(5, '0.0')], 4: [], '__in__': [], '__out__': []},
                             elt_ad_hoc={  2: {'position': [63.0, 250.0], 'userColor': None, 'useUserColor': True},
   3: {'position': [0.0, 125.0], 'userColor': None, 'useUserColor': True},
   4: {'position': [125.0, 125.0], 'userColor': None, 'useUserColor': True},
   '__in__': {'position': [250.0, 0], 'userColor': None, 'useUserColor': True},
   '__out__': {'position': [250.0, 500], 'userColor': None, 'useUserColor': True}},
                             lazy=True,
                             eval_algo=None,
                             )




